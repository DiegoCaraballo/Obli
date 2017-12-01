using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades_Compartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class ServicioPersistencia
    {
        internal static void AgregarServicio(string unServicio, string pLetraDpto, string pAbreviacion, SqlTransaction pTransaccion)
        {
            SqlCommand comando = new SqlCommand("AgregarServicio", pTransaccion.Connection);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@LetraDpto", pLetraDpto);
            comando.Parameters.AddWithValue("@Abreviacion", pAbreviacion);
            comando.Parameters.AddWithValue("@Servicio", unServicio);
            SqlParameter ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            ParmRetorno.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add(ParmRetorno);

            try
            {
                //determino que debo trabajar con l misma transaccion
                comando.Transaction = pTransaccion;

                //ejecuto comando
                comando.ExecuteNonQuery();

                //veriico si hay errores
                int retorno = Convert.ToInt32(ParmRetorno.Value);
                if (retorno == -1)
                    throw new Exception("La zona esta inactiva y ya tiene un servicio con este nombre");
                else if (retorno == -2)
                    throw new Exception("Error no especificado");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //TODO - revisar si no se usa, eliminarla
        //internal static void EliminarServicio(Entidades_Compartidas.Zona unaZona, SqlTransaction _pTransaction)
        //{
        //    SqlCommand comando = new SqlCommand("EliminarServicio", _pTransaction.Connection);
        //    comando.CommandType = CommandType.StoredProcedure;
        //    comando.Parameters.AddWithValue("@LetraDpto", SqlDbType.Char);
        //    comando.Parameters.AddWithValue("@Abreviacion", SqlDbType.VarChar);
        //    comando.Parameters.AddWithValue("@Servicio", SqlDbType.VarChar);
        //    SqlParameter _ParamRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
        //    _ParamRetorno.Direction = ParameterDirection.ReturnValue;
        //    comando.Parameters.Add(_ParamRetorno);

        //    try
        //    {
        //        Determino que debo trabajar con la misma transaccion
        //        comando.Transaction = _pTransaction;

        //        ejecuto comando
        //        comando.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        internal static void CargoServicio(Entidades_Compartidas.Zona unaZona)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand comando = new SqlCommand("ServiciosDeUnaZona", _cnn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@LetraDpto", unaZona.LetraDpto);
            comando.Parameters.AddWithValue("@Abreviacion", unaZona.Abreviacion);

            try
            {
                _cnn.Open();

                SqlDataReader _lector = comando.ExecuteReader();

                if (_lector.HasRows)
                {
                    while (_lector.Read())
                    {
                        unaZona.AgregarServicio((string)_lector["servicio"]);
                    }
                }
                _lector.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _cnn.Close();
            }
        }

        internal static void EliminarServiciosZona(Entidades_Compartidas.Zona unaZona, SqlTransaction _pTransaccion)
        {
            SqlCommand comando = new SqlCommand("EliminarServicio", _pTransaccion.Connection);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@LetraDpto", unaZona.LetraDpto);
            comando.Parameters.AddWithValue("@Abreviacion", unaZona.Abreviacion);
            SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _ParmRetorno.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add(_ParmRetorno);

            try
            {
                //determino que debo trabajar con la misma transaccion
                comando.Transaction = _pTransaccion;

                //ejecuto comando
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
