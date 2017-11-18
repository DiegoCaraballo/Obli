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



        //public List<Visita> ListaVisitas()
        //{
        //    List<Visita> lista = new List<Visita>();
          
        //    DateTime fecha;
        //    string accion;
        //    int precio;
        //    int padron;

        //    SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
        //    SqlCommand oComando = new SqlCommand("ListadoVisitas", oConexion);
        //    SqlDataReader oReader;

        //    try
        //    {
        //        oConexion.Open();
        //        oReader = oComando.ExecuteReader();

        //        while (oReader.Read())
        //        {
        //            accion = (string)oReader["accion"];
        //            padron = (int)oReader["padron"];
        //            precio = (int)oReader["precio"];
        //            fecha = (DateTime)oReader["fecha"];
                                  
                                      
        //            Visita v = new Visita(accion,padron,precio,fecha);
        //            lista.Add(v);
        //        }
        //        oReader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Problemas con la base de datos: " + ex.Message);
        //    }
        //    finally
        //    {
        //        oConexion.Close();
        //    }

        //    return lista;
        //}

        public List<Visita> ListaVisitas()
        {
            List<Visita> lista = new List<Visita>();

            DateTime fecha;
            string accion;
            int precio;
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
                    accion = (string)oReader["accion"];
                    padron = (int)oReader["padron"];
                    precio = (int)oReader["precio"];
                    fecha = (DateTime)oReader["fecha"];


                    Visita v = new Visita(accion, padron, precio, fecha);
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
        #endregion
    }
}
