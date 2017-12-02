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
    internal class CasaPersistencia : ICasaPersistencia
    {
        #region SINGLETON

        private static CasaPersistencia instancia = null;

        private CasaPersistencia() { }

        public static CasaPersistencia GetInstancia()
        {
            if (instancia == null)
                instancia = new CasaPersistencia();

            return instancia;
        }
        #endregion

        #region Operaciones
        public Casa BuscarCasa(int pPadron)
        {
            Casa c = null;
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

            decimal mt2Terreno;
            bool fondo;

            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("BuscarCasa " + pPadron, oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
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

                    mt2Terreno = (decimal)oReader["mt2Terreno"];
                    fondo = Convert.ToBoolean(oReader["fondo"]);

                    c = new Casa(padron, direccion, precio, accion, banio, habitaciones, mt2C,
                 (ZonaPersistencia.GetInstancia().BuscoTodas(letraDpto, abreviacion)),
                 (EmpleadoPersistencia.GetInstancia().BuscarEmpleado(nomUsu)), mt2Terreno, fondo);

                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }

            return c;
        }
        public void EliminarCasa(Casa C)
        {
            SqlConnection coonexion = new SqlConnection(Conexion.Cnn);
            SqlCommand comando = new SqlCommand("EliminaCasa", coonexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter padron = new SqlParameter("@padron", C.Padron);

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
        public void AgregarCasa(Casa C)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand comando = new SqlCommand("AltaCasa", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter padron = new SqlParameter("@padron", C.Padron);
            SqlParameter direcc = new SqlParameter("@direccion", C.Direccion);
            SqlParameter pre = new SqlParameter("@precio", C.Precio);
            SqlParameter accion = new SqlParameter("@accion", C.Accion);
            SqlParameter banio = new SqlParameter("@banios", C.Baño);
            SqlParameter hab = new SqlParameter("@habitaciones", C.Habitaciones);
            SqlParameter mt2C = new SqlParameter("@mt2const", C.Mt2Const);
            SqlParameter nomUsu = new SqlParameter("@nomUsu", C.UltimoEmp.NomUsu);
            SqlParameter letraDpto = new SqlParameter("@letraDpto", C.Zona.LetraDpto);
            SqlParameter abreciacion = new SqlParameter("@abreviacion", C.Zona.Abreviacion);

            SqlParameter mt2T = new SqlParameter("@mt2Terreno", C.Mt2Terreno);
            SqlParameter fondo = new SqlParameter("@fondo", C.Fondo);

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

            comando.Parameters.Add(mt2T);
            comando.Parameters.Add(fondo);

            comando.Parameters.Add(retorno);

            try
            {

                conexion.Open();
                comando.ExecuteNonQuery();
                afectados = (int)comando.Parameters["@Retorno"].Value;
                if (afectados == -1)
                    throw new Exception("La Casa ya existe");
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
        public void ModificarCasa(Casa C)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand comando = new SqlCommand("ModificoCasa", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter padron = new SqlParameter("@padron", C.Padron);
            SqlParameter direcc = new SqlParameter("@direccion", C.Direccion);
            SqlParameter pre = new SqlParameter("@precio", C.Precio);
            SqlParameter accion = new SqlParameter("@accion", C.Accion);
            SqlParameter banio = new SqlParameter("@banios", C.Baño);
            SqlParameter hab = new SqlParameter("@habitaciones", C.Habitaciones);
            SqlParameter mt2C = new SqlParameter("@mt2const", C.Mt2Const);
            SqlParameter nomUsu = new SqlParameter("@nomUsu", C.UltimoEmp.NomUsu);
            SqlParameter letraDpto = new SqlParameter("@letraDpto", C.Zona.LetraDpto);
            SqlParameter abreciacion = new SqlParameter("@abreviacion", C.Zona.Abreviacion);

            SqlParameter mt2T = new SqlParameter("@mt2Terreno", C.Mt2Terreno);
            SqlParameter fondo = new SqlParameter("@fondo", C.Fondo);

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

            comando.Parameters.Add(mt2T);
            comando.Parameters.Add(fondo);

            comando.Parameters.Add(retorno);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                oAfectados = (int)comando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("La propiedad no existe");
                else if (oAfectados == -2)
                    throw new Exception("El padron no pertenece a una Casa");
                else if (oAfectados == -3)
                    throw new Exception("El empleado no esta activo");
                else if (oAfectados == -4)
                    throw new Exception("La Zona no esta activa");

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
        public List<Casa> ListaCasa()
        {
            List<Casa> lista = new List<Casa>();
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

            decimal mt2Terreno;
            bool fondo;

            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("ListarCasa", oConexion);
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

                    mt2Terreno = (decimal)oReader["mt2Terreno"];
                    fondo = Convert.ToBoolean(oReader["fondo"]);

                    Casa c = new Casa(padron, direccion, precio, accion, banio, habitaciones, mt2C, ((ZonaPersistencia.GetInstancia().BuscoTodas(letraDpto, abreviacion))),
                   (EmpleadoPersistencia.GetInstancia().BuscarEmpleado(nomUsu)), mt2Terreno, fondo);
                    lista.Add(c);
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
