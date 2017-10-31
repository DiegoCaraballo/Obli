using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades_Compartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class ZonaPersistencia : IZonaPersistencia
    {

        #region SINGLETON

        private static ZonaPersistencia instancia = null;

        private ZonaPersistencia() { }

        public static ZonaPersistencia GetInstancia()
        {
            if (instancia == null)
                instancia = new ZonaPersistencia();

            return instancia;
        }

        #endregion

        #region OPERACIONES

        public void AgregarZona(Zona unaZona)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("AgregarZona", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _LetraDpto = new SqlParameter("@LetraDpto", unaZona.LetraDpto);
            SqlParameter _Abreviacion = new SqlParameter("@Abreviacion", unaZona.Abreviacion);
            SqlParameter _Nombre = new SqlParameter("@Nombre", unaZona.Nombre);
            SqlParameter _Habitantes = new SqlParameter("@Habitantes", unaZona.CantHabitantes);
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(_LetraDpto);
            oComando.Parameters.Add(_Abreviacion);
            oComando.Parameters.Add(_Nombre);
            oComando.Parameters.Add(_Habitantes);
            oComando.Parameters.Add(_Retorno);

            int afectados = -1;
            SqlTransaction _miTransaccion = null;

            try
            {
                //conecto a la bd
                oConexion.Open();

                //determino que voy a trabajar en una unica transaccion
                _miTransaccion = oConexion.BeginTransaction();

                //ejecuto comando de alta del servicio en la transaccion
                oComando.Transaction = _miTransaccion;
                oComando.ExecuteNonQuery();

                //verifico si hay errores

                afectados = (int)oComando.Parameters["@Retorno"].Value;
                if (afectados == -1)
                    throw new Exception("La Zona ya existe");
                else if (afectados == -2)
                    throw new Exception("Error en la base de datos");

                //si llego hasta aca es xq pude dar de alta la Zona

                //genero alta para los servicios
                foreach (Servicio unServ in unaZona.LosServicios)
                {
                    ServicioPersistencia.AgregarServicio(unServ, unaZona.LetraDpto, unaZona.Abreviacion, _miTransaccion);
                }

                //si llegue aca es xq no hubo problemas con los servicios
                _miTransaccion.Commit();
            }
            catch (Exception ex)
            {
                _miTransaccion.Rollback();
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }

        }

        //Modificar Zona
        public void ModificarZona(Zona unaZona)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("ModificarZona", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _LetraDpto = new SqlParameter("@LetraDpto", unaZona.LetraDpto);
            SqlParameter _Abreviacion = new SqlParameter("@Abreviacion", unaZona.Abreviacion);
            SqlParameter _Nombre = new SqlParameter("@Nombre", unaZona.Nombre);
            SqlParameter _Habitantes = new SqlParameter("@Habitantes", unaZona.CantHabitantes);
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(_LetraDpto);
            oComando.Parameters.Add(_Abreviacion);
            oComando.Parameters.Add(_Nombre);
            oComando.Parameters.Add(_Habitantes);
            oComando.Parameters.Add(_Retorno);

            int afectados = -1;
            SqlTransaction _miTransaccion = null;

            try
            {
                //conecto a la bd
                oConexion.Open();

                //determino que voy a trabajar en una unica transaccion
                _miTransaccion = oConexion.BeginTransaction();

                //ejecuto comando de alta del servicio en la transaccion
                oComando.Transaction = _miTransaccion;
                oComando.ExecuteNonQuery();

                //verifico si hay errores
                afectados = (int)oComando.Parameters["@Retorno"].Value;
                if (afectados == -1)
                    throw new Exception("La Zona no existe");
                else if (afectados == -2)
                    throw new Exception("La Zona existe pero no está activa");
                else if (afectados == -3)
                    throw new Exception("Error al modificar Zona");

                //si llego hasta aca es xq pude dar de alta la Zona

                //elimino todos los servicios anteriores
                ServicioPersistencia.EliminarServiciosZona(unaZona, _miTransaccion);

                //genero alta para los servicios
                foreach (Servicio unServ in unaZona.LosServicios)
                {
                    ServicioPersistencia.AgregarServicio(unServ, unaZona.LetraDpto, unaZona.Abreviacion, _miTransaccion);
                }

                //si llegue aca es xq no hubo problemas con los servicios
                _miTransaccion.Commit();
            }
            catch (Exception ex)
            {
                _miTransaccion.Rollback();
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }

        public void EliminarZona(Zona unaZona)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand comando = new SqlCommand("EliminarZona", _cnn);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter _LetraDpto = new SqlParameter("@LetraDpto", unaZona.LetraDpto);
            SqlParameter _Abreviacion = new SqlParameter("@Abreviacion", unaZona.Abreviacion);
            SqlParameter _retorno = new SqlParameter("@Retorno", System.Data.SqlDbType.Int);

            _retorno.Direction = ParameterDirection.ReturnValue;

            comando.Parameters.Add(_LetraDpto);
            comando.Parameters.Add(_Abreviacion);
            comando.Parameters.Add(_retorno);

            try
            {
                _cnn.Open();
                comando.ExecuteNonQuery();
                if ((int)_retorno.Value == -1)
                    throw new Exception("La Zona no existe");
                else if ((int)_retorno.Value == -2)
                    throw new Exception("Problema al Eliminar la Zona");
                else if((int)_retorno.Value == -3)
                    throw new Exception("Problema al Eliminar la Zona");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
        }

        //Listar Zonas
        public List<Zona> Listo()
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand comando = new SqlCommand("ListarZonas", _cnn);
            comando.CommandType = CommandType.StoredProcedure;

            List<Zona> _Lista = new List<Zona>();
            Zona unaZona = null;

            try
            {
                //me conecto
                _cnn.Open();

                //ejecuto consulta
                SqlDataReader _lector = comando.ExecuteReader();

                //verifico si hay servicios
                if (_lector.HasRows)
                {
                    while (_lector.Read())
                    {
                        string letraDpto = (string)_lector["letraDpto"];
                        string abreviacion = (string)_lector["abreviacion"];
                        string nombre = (string)_lector["nombre"];
                        int cantHabitantes = (int)_lector["habitantes"];
                        unaZona = new Zona(letraDpto, abreviacion, nombre, cantHabitantes);
                        ServicioPersistencia.CargoServicio(unaZona);

                        _Lista.Add(unaZona);
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

            //retorno la lista de Zonas
            return _Lista;
        }

        //Listar Zonas
        public List<Zona> ListoPorDpto(string _letraDpto)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand comando = new SqlCommand("ListarZonaPorDpto", _cnn);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter _LetraDpto = new SqlParameter("@LetraDpto", _letraDpto);
            SqlParameter _retorno = new SqlParameter("@Retorno", System.Data.SqlDbType.Int);

            _retorno.Direction = ParameterDirection.ReturnValue;

            comando.Parameters.Add(_LetraDpto);
            comando.Parameters.Add(_retorno);

            List<Zona> _Lista = new List<Zona>();
            Zona unaZona = null;

            try
            {
                //me conecto
                _cnn.Open();

                //ejecuto consulta
                SqlDataReader _lector = comando.ExecuteReader();

                //verifico si hay servicios
                if (_lector.HasRows)
                {
                    while (_lector.Read())
                    {
                        string letraDpto = (string)_lector["letraDpto"];
                        string abreviacion = (string)_lector["abreviacion"];
                        string nombre = (string)_lector["nombre"];
                        int cantHabitantes = (int)_lector["habitantes"];
                        unaZona = new Zona(letraDpto, abreviacion, nombre, cantHabitantes);
                        ServicioPersistencia.CargoServicio(unaZona);

                        _Lista.Add(unaZona);
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

            //retorno la lista de Zonas
            return _Lista;
        }

        //Buscar Zonas
        public Zona Busco(string letraDpto, string abreviacion)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand comando = new SqlCommand("BuscarZonaActiva", _cnn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@letraDpto", letraDpto);
            comando.Parameters.AddWithValue("@abreviacion", abreviacion);
            Zona unaZona = null;

            try
            {
                //me conecto
                _cnn.Open();

                //ejecuto consulta
                SqlDataReader _lector = comando.ExecuteReader();

                //verifico si hay servicios
                if (_lector.HasRows)
                {
                    _lector.Read();
                    string _letraDpto = (string)_lector["letraDpto"];
                    string _abreviacion = (string)_lector["abreviacion"];
                    string nombre = (string)_lector["nombre"];
                    int cantHabitantes = (int)_lector["habitantes"];
                    unaZona = new Zona(letraDpto, abreviacion, nombre, cantHabitantes);
                    ServicioPersistencia.CargoServicio(unaZona);
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

            //retorno la zona
            return unaZona;
        }

        #endregion

    }
}
