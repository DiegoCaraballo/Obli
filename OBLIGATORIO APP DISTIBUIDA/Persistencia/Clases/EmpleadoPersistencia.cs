using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades_Compartidas;
using System.Data.SqlClient ;
using System.Data ;

namespace Persistencia
{
    internal class EmpleadoPersistencia:IEmpleadoPersistencia
    {
        #region Singleton
        private static EmpleadoPersistencia instancia = null;
        private EmpleadoPersistencia() { }
        public static EmpleadoPersistencia GetInstancia()
        {
            if (instancia == null)
                instancia = new EmpleadoPersistencia();
            return instancia;
        }
        #endregion

        #region Operaciones

        public void AgregarEmpleado(Empleado E)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("AgregarEmpleado", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _NomUsu = new SqlParameter("@NomUsu", E.NomUsu);
            SqlParameter _Pass = new SqlParameter("@Pass", E.Pass);
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int oAfectados = -1;

            oComando.Parameters.Add(_NomUsu);
            oComando.Parameters.Add(_Pass);
            oComando.Parameters.Add(_Retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("El empleado ya existe en la base de datos");
                else if (oAfectados == -2)
                    throw new Exception("Problema en la base de datos, vuelva a intentar");
            }
            catch (Exception ex)
            {
                throw new Exception("Problemas con la base de datos" + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }

        }

        public void EliminarEmpleado(Empleado E)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("EliminarEmpleado", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _NomUsu = new SqlParameter("@NomUsu", E.NomUsu);
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            int oAfectados = -1;

            oComando.Parameters.Add(_NomUsu);
            oComando.Parameters.Add(_Retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("El empleado no existe en la base de datos");
                else if (oAfectados == -2)
                    throw new Exception("Problema en la base de datos, vuelva a intentar");
            }
            catch (Exception ex)
            {
                throw new Exception("Problema con la base de datos " + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }

        }

        public void ModificarEmpleado(Empleado E)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("ModificarEmpleado", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _NomUsu = new SqlParameter("@NomUsu", E.NomUsu);
            SqlParameter _Pass = new SqlParameter("@Pass", E.Pass);
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(_NomUsu);
            oComando.Parameters.Add(_Pass);
            oComando.Parameters.Add(_Retorno);

            int oAfectados = -1;

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("El empleado no existe en la base de datos");
                else if (oAfectados == -2)
                    throw new Exception("El empleado no se encuentra activo");
                else if (oAfectados == -3)
                    throw new Exception("Problema en la base de datos, vuelva a intentar");
            }
            catch (Exception ex)
            {
                throw new Exception("Problemas con la base de datos: " + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }


        public Empleado BuscarEmpleadoActivo(string pNomUsu)
        {
            Empleado e = null;
            string _nomUsu;
            string _pass;

            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("BuscarEmpleadoActivo " + pNomUsu, oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {
                    _nomUsu = (string)oReader["NomUsu"];
                    _pass = (string)oReader["Pass"];
                    e = new Empleado(_nomUsu, _pass);
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

            return e;
        }

        public Empleado BuscarEmpleado(string pNomUsu)
        {
            Empleado e = null;
            string _nomUsu;
            string _pass;

            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("BuscarEmpleado " + pNomUsu, oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {
                    _nomUsu = (string)oReader["NomUsu"];
                    _pass = (string)oReader["Pass"];
                    e = new Empleado(_nomUsu, _pass);
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

            return e;
        }

        #endregion
    }
}
