using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades_Compartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class VisitaPersistencia : IVisitaPersistencia
    {
        #region SINGLETON

        private static VisitaPersistencia instancia = null;

        private VisitaPersistencia() { }

        public static VisitaPersistencia GetInstancia()
        {
            if (instancia == null)
                instancia = new VisitaPersistencia();

            return instancia;
        }

        #endregion

        #region Operaciones
        public void AgendaVisita(Visita V)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand comando = new SqlCommand("AltaVisita", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter tel = new SqlParameter("@Tel", V.Telefono);
            SqlParameter nombre = new SqlParameter("@Nombre", V.Nombre);
            SqlParameter fecha = new SqlParameter("@Fecha", V.Fecha);
            SqlParameter padron = new SqlParameter("@Padron", V.AVisitar.Padron);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int afectados = -1;

            comando.Parameters.Add(padron);
            comando.Parameters.Add(fecha);
            comando.Parameters.Add(nombre);
            comando.Parameters.Add(tel);

            comando.Parameters.Add(retorno);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                afectados = (int)comando.Parameters["@Retorno"].Value;
                if (afectados == -1)
                    throw new Exception("Ya existe una visita con la misma hora - fecha");
                else if (afectados == -2)
                    throw new Exception("Ya has visitado 2 veces esta propiedad");
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                conexion.Close();
            }

        }

        public List<Visita> ListaVisitas()
        {
            List<Visita> lista = new List<Visita>();
            Propiedad propiedad = null;
            DateTime fecha;
            string nombre;
            string tel;
            int padron;

            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("ListadoVisitas", oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    nombre = (string)oReader["nombre"];
                    padron = (int)oReader["padron"];
                    tel = (string)oReader["tel"];
                    fecha = (DateTime)oReader["fecha"];

                    propiedad = FabricaPersistencia.getPersistenciaApto().BuscarApto(padron);
                    if (propiedad == null)
                    {
                        propiedad = FabricaPersistencia.getPersistenciaCasa().BuscarCasa(padron);
                        if (propiedad == null)
                        {
                            propiedad = FabricaPersistencia.getPersistenciaComercio().BuscarComercio(padron);
                        }
                    }

                    Visita v = new Visita(fecha, tel, nombre, propiedad);

                    lista.Add(v);
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

        public int VecesVisitado(Visita V)
        {

            //TODO - Ver si funciona traer cantidad de visitas
            int visitas = 0;

            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("CantidadVisitas", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@tel", V.Telefono);
            oComando.Parameters.AddWithValue("@padron", V.AVisitar.Padron);

            var retorno = oComando.Parameters.Add("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                var resultado = retorno.Value;
                visitas = Convert.ToInt32(resultado);
            }
            catch (Exception ex)
            {
                throw new Exception("Problemas con la base de datos: " + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return visitas;

        }

        public int HoraVisitas(Visita V)
        {
            int visitas = 0;

            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("HoraVisitas", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@fecha", V.Fecha);
            oComando.Parameters.AddWithValue("@padron", V.AVisitar.Padron);

            var retorno = oComando.Parameters.Add("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                var resultado = retorno.Value;
                visitas = Convert.ToInt32(resultado);
            }
            catch (Exception ex)
            {
                throw new Exception("Problemas con la base de datos: " + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return visitas;
        }

        #endregion
    }
}
