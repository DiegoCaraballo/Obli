using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades_Compartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class AptoPersistencia : IAptoPersistencia
    {
        #region SINGLETON

        private static AptoPersistencia instancia = null;

        private AptoPersistencia() { }

        public static AptoPersistencia GetInstancia()
        {
            if (instancia == null)
                instancia = new AptoPersistencia();

            return instancia;
        }
        #endregion

        #region Operaciones
        public void AgregarApto(Apto A)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand comando = new SqlCommand("AltaApto", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter padron = new SqlParameter("@padron", A.Padron);
            SqlParameter direcc = new SqlParameter("@direccion", A.Direccion);
            SqlParameter pre = new SqlParameter("@precio", A.Precio);
            SqlParameter accion = new SqlParameter("@accion", A.Accion);
            SqlParameter banio = new SqlParameter("@banios", A.Baño);
            SqlParameter hab = new SqlParameter("@habitaciones", A.Habitaciones);
            SqlParameter mt2C = new SqlParameter("@mt2const", A.Mt2Const);
            SqlParameter nomUsu = new SqlParameter("@nomUsu", A.UltimoEmp.NomUsu);
            SqlParameter letraDpto = new SqlParameter("@letraDpto", A.Zona.LetraDpto);
            SqlParameter abreciacion = new SqlParameter("@abreviacion", A.Zona.Abreviacion);

            SqlParameter piso = new SqlParameter("@piso", A.Piso);
            SqlParameter ascensor = new SqlParameter("@ascensor", A.Ascensor);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int afectados = -1;

            comando.Parameters.Add(padron);
            comando.Parameters.Add(direcc);
            comando.Parameters.Add(pre);
            comando.Parameters.Add(accion);
            comando.Parameters.Add(banio);
            comando.Parameters.Add(hab);
            comando.Parameters.Add(mt2C);
            comando.Parameters.Add(nomUsu);
            comando.Parameters.Add(letraDpto);
            comando.Parameters.Add(abreciacion);

            comando.Parameters.Add(piso);
            comando.Parameters.Add(ascensor);

            comando.Parameters.Add(retorno);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                afectados = (int)comando.Parameters["@Retorno"].Value;
                if (afectados == -1)
                    throw new Exception("El apartamento ya existe");
                else if (afectados == -2)
                    throw new Exception("El padron pertenece a otra propiedad");
                else if (afectados == -4)
                    throw new Exception("El empleado no esta activo");
                else if (afectados == -5)
                    throw new Exception("La zona no esta Activa");
                else
                    throw new Exception("Error en dar de alta");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error en la BD" + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

        }

        public void EliminarApto(Apto A)
        {
            SqlConnection coonexion = new SqlConnection(Conexion.Cnn);
            SqlCommand comando = new SqlCommand("EliminaApto", coonexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter padron = new SqlParameter("@padron", A.Padron);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int oAfectados = -1;

            comando.Parameters.Add(padron);
            comando.Parameters.Add(retorno);

            try
            {
                coonexion.Open();
                comando.ExecuteNonQuery();
                oAfectados = (int)comando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error en la BD:" + ex.Message);
            }
            finally
            {
                coonexion.Close();
            }

        }

        public void ModificarApto(Apto A)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand comando = new SqlCommand("ModificoApto", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter padron = new SqlParameter("@padron", A.Padron);
            SqlParameter direcc = new SqlParameter("@direccion", A.Direccion);
            SqlParameter pre = new SqlParameter("@precio", A.Precio);
            SqlParameter accion = new SqlParameter("@accion", A.Accion);
            SqlParameter banio = new SqlParameter("@banios", A.Baño);
            SqlParameter hab = new SqlParameter("@habitaciones", A.Habitaciones);
            SqlParameter mt2C = new SqlParameter("@mt2const", A.Mt2Const);
            SqlParameter nomUsu = new SqlParameter("@nomUsu", A.UltimoEmp.NomUsu);
            SqlParameter letraDpto = new SqlParameter("@letraDpto", A.Zona.LetraDpto);
            SqlParameter abreciacion = new SqlParameter("@abreviacion", A.Zona.Abreviacion);

            SqlParameter piso = new SqlParameter("@piso", A.Piso);
            SqlParameter ascensor = new SqlParameter("@ascensor", A.Ascensor);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int oAfectados = -1;

            comando.Parameters.Add(padron);
            comando.Parameters.Add(direcc);
            comando.Parameters.Add(pre);
            comando.Parameters.Add(accion);
            comando.Parameters.Add(banio);
            comando.Parameters.Add(hab);
            comando.Parameters.Add(mt2C);
            comando.Parameters.Add(nomUsu);
            comando.Parameters.Add(letraDpto);
            comando.Parameters.Add(abreciacion);

            comando.Parameters.Add(piso);
            comando.Parameters.Add(ascensor);

            comando.Parameters.Add(retorno);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                oAfectados = (int)comando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("La propiedad no existe");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

        }


        public Apto BuscarApto(int pPadron)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);

            Apto a = null;

            SqlCommand oComando = new SqlCommand("BuscarApto", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@padron", pPadron);
                  
            int padron;
            string direccion;
            int precio;
            string accion;
            int banio;
            int habitaciones;
            decimal mt2C;
            string nomUsu;
            string letraDpto;
            string abreviacion;

            int piso;
            bool ascensor;
           
            try
            {
                oConexion.Open();

                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    oReader.Read();

                    padron = (int)oReader["padron"];
                    direccion = (string)oReader["direccion"];
                    precio = (int)oReader["precio"];
                    accion = (string)oReader["accion"];
                    banio = (int)oReader["banios"];
                    habitaciones = (int)oReader["habitaciones"];
                    mt2C = (decimal)oReader["mt2const"];
                    nomUsu = (string)oReader["nomUsu"];
                    letraDpto = (string )oReader["letraDpto"];
                    abreviacion = (string)oReader["abreviacion"];

                    piso = (int)oReader["piso"];
                    ascensor = (bool)oReader["ascensor"];
                    a = new Apto(padron, direccion, precio, accion, banio, habitaciones, mt2C, ((ZonaPersistencia.GetInstancia().BuscoTodas(letraDpto, abreviacion))),
                 (EmpleadoPersistencia.GetInstancia().BuscarEmpleado(nomUsu)), piso, ascensor);

                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Problemas con la base de datos: " + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }

            return a;
        }

        public List<Apto> ListaApto()
        {
            List<Apto> lista = new List<Apto>();
            int padron;
            string direccion;
            int precio;
            string accion;
            int banio;
            int habitaciones;
            decimal mt2C;
            string nomUsu;
            string letraDpto;
            string abreviacion;

            int piso;
            bool ascensor;
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("ListarApto", oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    padron = (int)oReader["padron"];
                    direccion = (string)oReader["direccion"];
                    precio = (int)oReader["precio"];
                    accion = (string)oReader["accion"];
                    banio = (int)oReader["banios"];
                    habitaciones = (int)oReader["habitaciones"];
                    mt2C = (decimal)oReader["mt2const"];
                    nomUsu = (string)oReader["nomUsu"];
                    letraDpto = (string)oReader["letraDpto"];
                    abreviacion = (string)oReader["abreviacion"];

                    piso = (int)oReader["piso"];
                    ascensor = (bool)oReader["ascensor"];

                    Apto a = new Apto(padron, direccion, precio, accion, banio, habitaciones, mt2C, ((ZonaPersistencia.GetInstancia().BuscoTodas(letraDpto, abreviacion))),
                   (EmpleadoPersistencia.GetInstancia().BuscarEmpleado(nomUsu)),piso,ascensor);
                    lista.Add(a);
                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Problemas con la base de datos: " + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }

            return lista;
        }       

        #endregion

    }
}
