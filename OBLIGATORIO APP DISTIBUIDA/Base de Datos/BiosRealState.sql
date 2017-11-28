--Script
--creo la base de datos de BiosRealState
use master;
if exists(Select * FROM SysDataBases WHERE name='BiosRealState')
BEGIN
	DROP DATABASE BiosRealState
END
go
 
create DataBase BiosRealState
 
go
 
use BiosRealState;
 
go
create table Empleado
(
	nomUsu varchar(20) not null primary key, 
	pass varchar(10) not null check(len(pass) = 10),
	activo bit default(1)
 
)
go
create table Zona
(
	--letraDpto char(1)not null check (len(letraDpto) = 1 AND letraDpto LIKE '%[A-S]%'),
	--abreviacion varchar(3)not null check (len(abreviacion) = 3 and abreviacion LIKE '%[A-Z]%'),
	letraDpto char(1)not null check (letraDpto Like '[A-S]'),
	abreviacion varchar(3)not null check (abreviacion LIKE '[A-Z][A-Z][A-Z]'),
	
	nombre varchar(30)not null,
	habitantes int not null check(habitantes >=0),
	activa bit default (1),
	primary key(letraDpto, abreviacion)
)
 
go

create table servicios
(
	letraDpto char(1) not null,
	abreviacion varchar(3) not null,
	servicio varchar (50) not null,
	foreign key (letraDpto,abreviacion)
	references Zona (letraDpto,abreviacion),
	primary key(letraDpto, abreviacion,servicio)
)
  
go
 
 
go
 
create table Propiedad
(
	padron int not null primary key check(padron >0),
	letraDpto char(1) not null,
	abreviacion varchar(3) not null,
	habitaciones int not null check(habitaciones >=1),
	direccion varchar(100) not null,
	precio int not null check(precio >0),
	accion varchar(10) not null check(accion in ('alquiler','venta','permuta')),
	banios int not null check(banios >0),
	mt2const decimal not null check(mt2const >0),
	nomUsu varchar(20) not null foreign key references Empleado(nomUsu),
	foreign key (letraDpto,abreviacion)
	references Zona (letraDpto,abreviacion)
)
 
go
 
create table Casa
(
	padron int not null primary key foreign key references Propiedad(padron),
	mt2Terreno decimal not null check(mt2Terreno >0),
	fondo bit default(1)
)
 
go
 
create table Apto
(
	padron int not null primary key foreign key references Propiedad(padron),
	piso int not null check(piso >=0),
	ascensor bit default(1)
)
 
go
 
create table Comercio
(
	padron int not null primary key foreign key references Propiedad(padron),
	habilitado bit default(1)
)
go
 select * from Apto
 
create table Visita
(
	id int identity(1,1) not null primary key,
	tel varchar(20) not null,
	nombre varchar(20) not null,
	fecha datetime not null check(fecha > getdate()),
	padron int not null foreign key references propiedad(padron)
)
 
go
 
------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------
------------------------------------ABM Propiedades------------------------------
-----------------------------------------------------------------------------------------
                       
					               ---ABM CASAS---
--Listar Casa
create proc ListarCasa as
begin 
	select c.mt2Terreno,c.fondo, p.* from Casa c join Propiedad p on c.padron=p.padron
end
go

--Buscar Casa
CREATE  PROCEDURE BuscarCasa @padron int AS
BEGIN 
	select c.mt2Terreno,c.fondo, p.* from Casa c join Propiedad p on c.padron=p.padron where c.padron =@padron
END
go

--Alta Casa
Create Proc AltaCasa
@padron int, @letraDpto char(1), @abreviacion varchar(3), @habitaciones int, @direccion varchar(100), 
@precio int , @accion varchar(10), @banios int , @mt2const decimal, @nomUsu varchar(20), @mt2Terreno decimal, @fondo bit as
 
Begin
 If exists (Select padron from Casa where padron = @padron)
   return -1;

If exists (Select padron from Propiedad where padron = @padron)
   return -2;
 declare @error int
 begin tran

    Insert Into Propiedad(padron,letraDpto,abreviacion,habitaciones,direccion,precio,accion,banios,mt2const,nomUsu)
    Values(@padron,@letraDpto,@abreviacion,@habitaciones,@direccion,@precio,@accion,@banios,@mt2const,@nomUsu);
 SET @error=@@ERROR;

    Insert Into Casa (padron,mt2Terreno,fondo)
	Values(@padron,@mt2Terreno,@fondo);
 		SET @error=@@ERROR+@Error;
if(@@ERROR=0)
begin
commit tran
return 1;
end
else
begin
rollback tran
return -3;
end
End
Go
 
--Eliminar Casa
create proc EliminaCasa @padron int
as
   begin
 
  If not exists (Select padron from Casa where padron = @padron)
   return -1;

If not exists (Select padron from Propiedad where padron = @padron)
   return -2;
      declare @error int
 
  begin tran
 
     delete from Casa where padron=@padron
     set @error=@@ERROR;
 
     Delete from Propiedad where padron =@padron
     set @error=@@ERROR+@error;
 
		if(@@ERROR = 0)
		begin
			commit tran;
			return 1;
		end
		else
		begin
			rollback tran;
			return -4;
		end		
	end	
 
go
 
--Modificar Casa
create proc ModificoCasa
@padron int, @letraDpto char(1), @abreviacion varchar(3), @habitaciones int, @direccion varchar(100), 
@precio int , @accion varchar(10), @banios int , @mt2const decimal, @nomUsu varchar(20), @mt2Terreno decimal, @fondo bit as
 
Begin
 
if (not exists(select * from Propiedad where padron=@padron))
return -1;
 
Declare @error int
 
Begin Tran
 
Update Propiedad set letraDpto = @letraDpto, abreviacion= @abreviacion,habitaciones= @habitaciones,direccion= @direccion, 
                     precio = @precio ,accion= @accion, banios= @banios,mt2const= @mt2const,nomUsu= @nomUsu
					 where padron =@padron;
 
Update Casa set  fondo = @fondo, mt2Terreno = @mt2Terreno
                 where padron =@padron;
			 
set @Error=@@ERROR;
 
	if(@Error=0)
	begin
		commit tran;
		return 1;
	end
	else
	begin
		rollback tran;
		return 0;
	end	
end
 
go
 
 
                                     ---ABM Comercio---


--Listar Comercio
create proc ListarComercio as
begin 
select c.habilitado, p.* from Comercio c join Propiedad p on c.padron=p.padron 
end
go

--Buscar Comercio
CREATE  PROCEDURE BuscarComercio @padron int AS
BEGIN 

select c.habilitado, p.* from Comercio c join Propiedad p on c.padron=p.padron where c.padron =@padron
END
go

--Alta Comercio
create proc AltaComercio
@padron int, @letraDpto char(1), @abreviacion varchar(3), @habitaciones int, @direccion varchar(100), 
@precio int , @accion varchar(10), @banios int , @mt2const decimal, @nomUsu varchar(20),@habilitado bit as
 
Begin
 
 If exists (Select padron from Comercio where padron = @padron)
   return -1;

If exists (select padron from Propiedad where padron = @padron)
   return -2;
 declare @error int
 begin tran
    insert into Propiedad(padron,letraDpto,abreviacion,habitaciones,direccion,precio,accion,banios,mt2const,nomUsu)
    Values(@padron,@letraDpto,@abreviacion,@habitaciones,@direccion,@precio,@accion,@banios,@mt2const,@nomUsu);
 		SET @error=@@ERROR
    insert into Comercio(padron,habilitado)
	values(@padron,@habilitado);
 		SET @error=@@ERROR+@Error;
if(@@ERROR=0)
begin
commit tran
return 1;
end
else
begin
rollback tran
return -3;
end
End
Go
 
--Eliminar Comercio
create proc EliminaComercio @padron int
as
   begin
  If not exists (Select padron from Comercio where padron = @padron)
   return -1;

If not exists (Select padron from Propiedad where padron = @padron)
   return -2;
      declare @error int
 
  begin tran
 
     delete from Comercio where padron=@padron
     set @error=@@ERROR;
 
     Delete from Propiedad where padron =@padron
     set @error=@@ERROR+@error;
 
		if(@@ERROR = 0)
		begin
			commit tran;
			return 1;
		end
	    else
		begin
			rollback tran;
			return -4;
		end		
	end	
 
go
--Modificar Comercio
create proc ModificoComercio
@padron int, @letraDpto char(1), @abreviacion varchar(3), @habitaciones int, @direccion varchar(100), 
@precio int , @accion varchar(10), @banios int , @mt2const decimal, @nomUsu varchar(20),@habilitado bit as
 
Begin
 
if (not exists(select * from Propiedad where padron=@padron))
return -1;
 
Declare @error int
 
Begin Tran
 
Update Propiedad set padron = @padron, letraDpto = @letraDpto, abreviacion= @abreviacion,habitaciones= @habitaciones,direccion= @direccion, 
                     precio = @precio ,accion= @accion, banios= @banios,mt2const= @mt2const,nomUsu= @nomUsu
					 where padron =@padron;
 
Update Comercio set  habilitado =@habilitado
                 where padron =@padron;
			 
set @Error=@@ERROR;
 
	if(@Error=0)
	begin
		commit tran;
		return 1;
	end
	else
	begin
		rollback tran;
		return 0;
	end	
end
 
go
 
 
                                      
                                       ---ABM Apto---
--Listar Apto
create proc ListarApto as
begin 
select a.piso,a.ascensor,p.* from Apto a join Propiedad p on a.padron= p.padron
end
go

--Buscar Apto
CREATE  PROCEDURE BuscarApto @padron int AS
BEGIN 
select a.piso,a.ascensor,p.* from Apto a join Propiedad p on a.padron= p.padron where a.padron=@padron

END
go

--Alta Casa
create proc AltaApto
@padron int, @letraDpto char(1), @abreviacion varchar(3), @habitaciones int, @direccion varchar(100), 
@precio int , @accion varchar(10), @banios int , @mt2const decimal, @nomUsu varchar(20),@piso int ,@ascensor bit as
 
Begin
 If exists (Select padron from Apto where padron = @padron)
   return -1;

If exists (select padron from Propiedad where padron = @padron)
   return -2;
 declare @error int
 begin tran

    insert into Propiedad(padron,letraDpto,abreviacion,habitaciones,direccion,precio,accion,banios,mt2const,nomUsu)
    Values(@padron,@letraDpto,@abreviacion,@habitaciones,@direccion,@precio,@accion,@banios,@mt2const,@nomUsu);
 SET @error=@@ERROR
    insert into Apto(padron,piso, ascensor)
	values(@padron,@piso,@ascensor);
 SET @error=@@ERROR+@error
if(@@ERROR=0)
begin
commit tran
return 1;
end
else
begin
rollback tran
return -3;
end 
End 
Go
 
--Eliminar Casa
create proc EliminaApto @padron int
as
   begin
  If not exists (Select padron from Apto where padron = @padron)
   return -1;

If not exists (Select padron from Propiedad where padron = @padron)
   return -2;
      declare @error int
 
  begin tran
 
     delete from Apto where padron=@padron
     set @error=@@ERROR;
 
     Delete from Propiedad where padron =@padron
     set @error=@@ERROR+@error;
 
		if(@@ERROR = 0)
		begin
			commit tran;
			return 1;
		end
		else
		begin
			rollback tran;
			return -4;
		end		
	end	
 
go
 
 
--Modificar Casa
create proc ModificoApto
@padron int, @letraDpto char(1), @abreviacion varchar(3), @habitaciones int, @direccion varchar(100), 
@precio int , @accion varchar(10), @banios int , @mt2const decimal, @nomUsu varchar(20),@piso int ,@ascensor bit as
 
Begin
 
if (not exists(select * from Propiedad where padron=@padron))
return -1;
 
Declare @error int
 
Begin Tran
 
Update Propiedad set letraDpto = @letraDpto, abreviacion= @abreviacion,habitaciones= @habitaciones,direccion= @direccion, 
                     precio = @precio ,accion= @accion, banios= @banios,mt2const= @mt2const,nomUsu= @nomUsu
					 where padron =@padron;
 
Update Apto set  piso= @piso , ascensor =@ascensor 
                 where padron =@padron;
			 
set @Error=@@ERROR;
 
	if(@Error=0)
	begin
		commit tran;
		return 1;
	end
	else
	begin
		rollback tran;
		return 0;
	end
end
 
go
 create proc ListarPropiedades as
begin 
select p.* from Propiedad p 
end
go
create proc BuscarPropiedad @padron int as
begin
 select * from Propiedad where padron = @padron
 end
 go
 
-----------------------------------------  ABM EMPLEADO   ------------------------------------------
--ALTA EMPLEADO--
CREATE PROCEDURE AgregarEmpleado  @NomUsu varchar(20), @Pass varchar(10)  AS
BEGIN 
	if (EXISTS (SELECT nomUsu FROM Empleado  WHERE nomUsu=@NomUsu and activo =1))
		RETURN -1;
 
	if (EXISTS (SELECT nomUsu FROM Empleado  WHERE nomUsu=@NomUsu and pass=@pass and activo =0))
		update Empleado set activo =1 where nomUsu =@NomUsu 
	else
		Insert into Empleado (nomUsu,pass) Values (@NomUsu,@Pass)
	
	IF(@@Error=0)
		RETURN 1;
	ELSE
		RETURN -2;
END
go
 
-- BUSCO EMPLEADO
CREATE  PROCEDURE BuscarEmpleado @NomUsu varchar(20) AS
BEGIN 
	SELECT * FROM Empleado where  nomUsu =@NomUsu
END
go
 
CREATE  PROCEDURE BuscarEmpleadoActivo @NomUsu varchar(20) AS
BEGIN 
	SELECT * FROM Empleado where  nomUsu =@NomUsu and activo =1
END
go
 
 
-- MODIFICA EMPLEADO
CREATE PROCEDURE ModificarEmpleado @NomUsu varchar(20), @Pass varchar(10)  AS
BEGIN 
	if (NOT EXISTS (SELECT nomUsu FROM Empleado  WHERE nomUsu=@NomUsu))
		RETURN -1;
	IF (EXISTS (SELECT nomUsu FROM Empleado where nomUsu = @NomUsu AND activo =0))
		RETURN -2;
 
	Update Empleado set pass = @Pass where nomUsu =@NomUsu 
	
	IF(@@Error=0)
		RETURN 1;
	ELSE
		RETURN -3;
 
END
go
 
-- ELIMINA EMPLEADO
CREATE PROCEDURE EliminarEmpleado @NomUsu varchar(20) AS
BEGIN
	IF (NOT EXISTS (SELECT nomUsu FROM Empleado  WHERE nomUsu=@NomUsu))
		RETURN -1;

 	IF (EXISTS (SELECT nomUsu FROM Propiedad where nomUsu = @NomUsu))
		Update Empleado set activo =0 where nomUsu =@NomUsu 
	else
		delete from Empleado where nomUsu =@NomUsu 
 
	IF(@@Error=0)
		RETURN 1;
	ELSE
		RETURN -2;
END			
GO


----------------------------------------------------------------------------
--------------------------- ABM ZONAS --------------------------------------
----------------------------------------------------------------------------

--AGREGAR ZONA--
CREATE PROC AgregarZona @LetraDpto char(1), @Abreviacion varchar(3), @Nombre varchar(30), @Habitantes int AS
BEGIN
	
	IF (EXISTS(SELECT * FROM Zona WHERE letraDpto = @LetraDpto AND abreviacion = @Abreviacion AND activa = 1))
		RETURN -1
		
	IF (EXISTS(SELECT * FROM Zona WHERE letraDpto = @LetraDpto AND abreviacion = @Abreviacion AND activa = 0))
		UPDATE Zona SET activa = 1, nombre = @Nombre, habitantes = @Habitantes
		WHERE letraDpto = @LetraDpto AND abreviacion = @Abreviacion
	
	ELSE	
		INSERT INTO Zona(letraDpto, abreviacion, nombre, habitantes) VALUES (@LetraDpto, @Abreviacion, @Nombre, @Habitantes)	
		IF (@@ERROR = 0)
			RETURN 1
		ELSE
			RETURN -2
		
END
go



--LISTAR ZONAS--
CREATE PROCEDURE ListarZonas AS
BEGIN
	SELECT * FROM Zona WHERE activa = 1
END
GO

--LISTAR ZONAS POR DPTO--
CREATE PROCEDURE ListarZonaPorDpto @LetraDpto char(1) AS
BEGIN
	SELECT * FROM ZONA WHERE letraDpto = @LetraDpto
END
GO


--BUSCAR ZONAS ACTIVAS--
CREATE PROCEDURE BuscarZonaActiva @LetraDpto char(1), @Abreviacion varchar(3) AS
BEGIN 
	SELECT * FROM Zona where  letraDpto = @LetraDpto AND abreviacion = @Abreviacion AND activa = 1
END
go


--BUSCAR TODAS LAS ZONAS--
CREATE PROCEDURE BuscarZonas @LetraDpto char(1), @Abreviacion varchar(3) AS
BEGIN 
	SELECT * FROM Zona where  letraDpto = @LetraDpto AND abreviacion = @Abreviacion
END
go

--MODIFICR ZONA--
CREATE PROCEDURE ModificarZona @LetraDpto char(1), @Abreviacion varchar(3), @Nombre varchar(30), @Habitantes int AS
BEGIN

	IF(NOT EXISTS(SELECT * FROM Zona WHERE letraDpto = @LetraDpto AND abreviacion = @Abreviacion))
		RETURN -1
		
	IF (EXISTS(SELECT * FROM Zona WHERE letraDpto = @LetraDpto AND abreviacion = @Abreviacion AND activa = 0))
		RETURN -2
		
	UPDATE Zona SET nombre = @Nombre, habitantes = @Habitantes
		WHERE letraDpto = @LetraDpto AND abreviacion = @Abreviacion
	IF(@@ERROR = 0)
		RETURN 1
	ELSE
		RETURN -3
	
END
go


CREATE PROCEDURE EliminarZona @LetraDpto char(1), @Abreviacion varchar(3) AS
BEGIN
	IF (NOT EXISTS(SELECT * FROM Zona WHERE letraDpto = @LetraDpto AND abreviacion = @Abreviacion))
		RETURN -1
    declare @error int;

		IF not EXISTS(SELECT * FROM Propiedad WHERE letraDpto = @LetraDpto AND abreviacion = @Abreviacion)
		BEGIN
			begin tran
			delete from servicios where letraDpto=@LetraDpto and abreviacion =@Abreviacion 

			delete from Zona where letraDpto =@LetraDpto and abreviacion=@Abreviacion 
			set @error+=@@ERROR;

			if(@@ERROR = 0)
				begin
					commit tran;
					return 1;
				end
			else
				begin
					rollback tran;
					return -2;
				end		
		END
		

	IF EXISTS(SELECT * FROM Propiedad WHERE letraDpto = @LetraDpto AND abreviacion = @Abreviacion)
	
	begin
		UPDATE Zona SET activa = 0  WHERE letraDpto = @LetraDpto AND abreviacion = @Abreviacion
		IF(@@ERROR = 0)
			RETURN 2;
		ELSE	
			RETURN -3
	end;
END	
go

----------------------------------------------------------------------------
--------------------------- ABM SERVICIOS ----------------------------------
----------------------------------------------------------------------------

--AGREGAR SERVICIO
CREATE PROC AgregarServicio @LetraDpto char(1), @Abreviacion varchar(3), @Servicio varchar(50) AS
BEGIN

	IF(EXISTS(SELECT * FROM Servicios WHERE letraDpto = @LetraDpto AND abreviacion = @Abreviacion AND servicio = @Servicio))
		RETURN -1
	INSERT INTO Servicios(letraDpto, abreviacion, servicio) VALUES(@LetraDpto, @Abreviacion, @Servicio)
	IF(@@ERROR = 0)
		RETURN 1
	ELSE
		RETURN -2

END
go

--BUSCAR SERVICIO
CREATE PROC BuscarServicio @LetraDpto char(1), @Abreviacion varchar(3), @Servicio varchar(50) AS
BEGIN
	SELECT * FROM Servicios WHERE letraDpto = @LetraDpto AND abreviacion = @Abreviacion AND servicio = @Servicio
END
go

--MODIFICAR SERVICIO

--SERVICIOS DE UNA ZONA
CREATE PROC ServiciosDeUnaZona @LetraDpto char(1), @Abreviacion varchar(3) AS
BEGIN
	SELECT * FROM Servicios WHERE letraDpto = @LetraDpto AND abreviacion = @Abreviacion
END
go

--ELIMINAR SERVICIO
CREATE PROC EliminarServicio @LetraDpto char(1), @Abreviacion varchar(3) AS
BEGIN
	DELETE FROM Servicios WHERE letraDpto = @LetraDpto AND abreviacion = @Abreviacion
	IF(@@ERROR = 0)
		RETURN 1
	ELSE
		RETURN -2
END
go

----------------------------------------------------------------------------
--------------------------- ABM VISITAS ------------------------------------
----------------------------------------------------------------------------


--AGREGAR VISITA


go
CREATE PROC AltaVisita @Tel varchar(20), @Nombre varchar(20), @Fecha DateTime, @Padron int AS
begin	
	
	if exists (select * from Visita where padron = @Padron and fecha = @Fecha)
		return -1
	
	IF ((SELECT COUNT(*) FROM Visita WHERE padron=@Padron AND tel=@Tel) >= 2)
		return -2
	
INSERT INTO Visita(tel, nombre, fecha, padron)VALUES(@Tel, @Nombre, @Fecha, @Padron)
		IF(@@ERROR = 0)
			RETURN 1
		ELSE
			RETURN -3
	END
GO


create proc ListadoVisitas as
begin


select * from Visita

end

go
create proc CantidadVisitas @tel varchar(30),@padron int as
begin
	declare @Retorno int
	set @Retorno = (select COUNT(*) from Visita where tel = @tel and padron = @padron);
	return @Retorno;
end 
go

create proc HoraVisitas @fecha datetime,@padron int as
begin
	declare @Retorno int
	set @Retorno = (select COUNT(*) from Visita where padron = @padron and fecha = @fecha);
	return @Retorno
end 
go

select * from Visita order by tel

--creacion de usuario IIS para que el webservice pueda acceder a la bd------------------------
USE master
GO

CREATE LOGIN [IIS APPPOOL\DefaultAppPool] FROM WINDOWS WITH DEFAULT_DATABASE = master
GO

USE BiosRealState
GO

CREATE USER [IIS APPPOOL\DefaultAppPool] FOR LOGIN [IIS APPPOOL\DefaultAppPool]
GO

GRANT Execute to [IIS APPPOOL\DefaultAppPool]
go

-------Datos de prueba----


--EMPLEADOS
exec AgregarEmpleado 'NADIA','1111111111';
exec AgregarEmpleado 'DIEGO','2222222222';
exec AgregarEmpleado 'NICO', '3333333333';

go

--Zonas
exec AgregarZona 'A','CNL','CANELONES',518154
exec AgregarZona 'B','MLD','MALDONADO',161571
exec AgregarZona 'C','RCH','ROCHA',66955
exec AgregarZona 'D','TYT','TREINTA Y TRES',48066
exec AgregarZona 'E','CRL','CERRO LARGO',84555
exec AgregarZona 'F','RIV','RIVERA',103447
exec AgregarZona 'G','ART','ARTIGAS',73162
exec AgregarZona 'H','STO','SALTO',124683
exec AgregarZona 'I','PYD','PAYSANDU',113112
exec AgregarZona 'J','RNG','RIO NEGRO',54434
exec AgregarZona 'K','SRN','SORIANO',82108
exec AgregarZona 'L','COL','COLONIA',122863
exec AgregarZona 'M','SJM','SAN JOSE',108025
exec AgregarZona 'N','FLR','FLORES',25033
exec AgregarZona 'O','FDA','FLORIDA',67093
exec AgregarZona 'P','LVL','LAVALLEJA',58843
exec AgregarZona 'Q','DZN','DURAZNO',57082
exec AgregarZona 'R','TCB','TACUAREMBO',89993
exec AgregarZona 'S','TRC','TRES CRUCES',1292347
exec AgregarZona 'S','MVD','MONTEVIDEO',1292347

GO 


exec AgregarServicio 'A','CNL','BOLICHES'
exec AgregarServicio 'A','CNL','CINE'
exec AgregarServicio 'A','CNL','FIBRA OPTICA'
exec AgregarServicio 'B','MLD','PLAYAS'
exec AgregarServicio 'C','RCH','FREE SHOPS'
exec AgregarServicio 'E','CRL','CENTRO COMERCIAL'
exec AgregarServicio 'F','RIV','ESTADIO'
exec AgregarServicio 'K','SRN','HOSPITAL'
exec AgregarServicio 'K','SRN','COMERCIOS'
exec AgregarServicio 'M','SJM','PARUQES'
exec AgregarServicio 'M','SJM','CANCHAS DE FUTBOL'
exec AgregarServicio 'P','LVL','GIMNASIO'
exec AgregarServicio 'P','LVL','RESTAURANT'
exec AgregarServicio 'S','MVD','FIBRA OPTICA'
exec AgregarServicio 'S','MVD','CENTROS COMERCIAL'
exec AgregarServicio 'S','MVD','VETERINARA'
exec AgregarServicio 'S','MVD','BOLICHES'

GO

--APARTAMENTOS
exec AltaApto 111111, 'A','CNL',3,'AV.ITALIA 8521',25000,'VENTA',1,120,'NADIA',5,1
exec AltaApto 222222, 'E','CRL',2,'COMERCIO 6542',13000,'ALQUILER',1,45,'DIEGO',2,0
exec AltaApto 333333, 'K','SRN',4,'GUANA 2541',32000,'ALQUILER',2,180,'NADIA',4,1
exec AltaApto 444444, 'P','LVL',1,'AV.AGRACIADA 585',11000,'ALQUILER',1,30,'NICO',6,1
exec AltaApto 555555, 'B','MLD',1,'AV.MILLAN 2254',3000,'PERMUTA',1,40,'NICO',1,0
exec AltaApto 666666, 'B','MLD',2,'CNO.CASTRO 963',15000,'VENTA',1,90,'NADIA',2,0
exec AltaApto 777777, 'S','MVD',4,'21 DE SEPTIEMBRE 6341',55000,'VENTA',1,220,'DIEGO',10,1
exec AltaApto 888888, 'S','MVD',2,'ÝAGUARON 9647',4800,'VENTA',1,60,'NADIA',2,0

GO

--CASAS
exec AltaCasa  111112, 'I','PYD',2,'CUAREIM 5423',28000,'VENTA',1,280,'NICO',250,1
exec AltaCasa  111113, 'I','PYD',5,'MINAS 682',588000,'VENTA',2,280,'NADIA',220,1
exec AltaCasa  111114, 'I','PYD',4,'URUGUAYANA 555',3800,'ALQUILER',2,280,'DIEGO',280,0
exec AltaCasa  111115, 'D','TYT',3,'OBVIEDO 4723',25800,'VENTA',1,170,'NADIA',160,1
exec AltaCasa  111116, 'G','ART',2,'ANADOR 6672',3000,'PERMUTA',1,140,'NICO',120,1
exec AltaCasa  111117, 'G','ART',1,'LARRAVIDE 9978',30550,'PERMUTA',1,190,'NADIA',190,0
exec AltaCasa  111119, 'N','FLR',1,'18 DE JULIO 5858',8000,'VENTA',1,80,'NICO',80,0
exec AltaCasa  111110, 'O','FDA',1,'VOLTA 6921',6090,'VENTA',1,110,'DIEGO',90,1
exec AltaCasa  111120, 'M','SJM',2,'EDISON 9892',7000,'VENTA',1,280,'NICO',250,1
exec AltaCasa  111130, 'M','SJM',3,'CARLOS ANAYA 2448',30000,'PERMUTA',1,130,'NADIA',130,0
exec AltaCasa  111140, 'M','SJM',1,'AV.GARZON 882',3000,'ALQUILER',1,280,'NICO',250,0
exec AltaCasa  111150, 'S','MVD',6,'BV.ARTIGAS 4427',800000,'VENTA',4,500,'NADIA',450,1
exec AltaCasa  111160, 'S','TRC',6,'BV.ARTIGAS 4427',800000,'VENTA',4,500,'NADIA',450,1
    
GO

--COMERCIOS
exec AltaComercio 123123, 'C','RCH',1,'RONDEAU 5552',1500,'ALQUILER',1,40,'NICO',0
exec AltaComercio 456456, 'C','RCH',1,'ARAPEY 7782',3800,'ALQUILER',1,45,'NICO',1
exec AltaComercio 789789, 'L','COL',2,'ESPINILLO 856',10000,'PERMUTA',1,150,'DIEGO',0
exec AltaComercio 321321, 'S','MVD',4,'ITUZAINGO 7812',6000,'ALQUILER',1,500,'NADIA',1
exec AltaComercio 654654, 'S','MVD',3,'AV.RIVERA 3333',20000,'PERMUTA',1,230,'DIEGO',0
exec AltaComercio 987987, 'S','MVD',2,'DR.PENA 7458',9500,'ALQUILER',1,200,'NICO',1

GO

select * from Visita
go
exec ListadoVisitas
go

exec AltaVisita 111119,'nico', '30-11-2018 15:00:00.000', 123123;
exec AltaVisita 312321,'nadia', '01-12-2018 13:00:00.000', 789789;
exec AltaVisita 325721,'diego', '01-12-2018 18:00:00.000', 789789;
exec AltaVisita 111119,'sergio', '01-12-2018 14:00:00.000', 123123;
exec AltaVisita 321721,'pepe', '01-12-2018 13:00:00.000', 123123;
exec AltaVisita 654654,'ahri', '01-12-2018 16:00:00.000', 111112;
exec AltaVisita 987987,'naty', '01-12-2018 17:00:00.000', 123123;
exec AltaVisita 321721,'maria', '01-12-2018 15:00:00.000', 111112;
exec AltaVisita 325721,'juan', '01-12-2018 14:00:00.000', 123123;
exec AltaVisita 111119,'jose', '01-12-2018 13:00:00.000', 111130;

select padron,count(padron) as 'asd' from Visita group by padron

select * from Visita order by padron asc



use BiosRealState;
select * from Propiedad where padron = 135321

select * from Apto where padron = 135321










