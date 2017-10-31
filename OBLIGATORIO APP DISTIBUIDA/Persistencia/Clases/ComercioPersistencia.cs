using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades_Compartidas;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    internal class ComercioPersistencia : IComercioPersistencia
    {
        #region SINGLETON

        private static ComercioPersistencia instancia = null;

        private ComercioPersistencia() { }

        public static ComercioPersistencia GetInstancia()
        {
            if (instancia == null)
                instancia = new ComercioPersistencia();

            return instancia;
        }
        #endregion

        #region Operaciones


        public void AgregarComercio(Comercio pComercio)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand comando = new SqlCommand("AltaComercio", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter padron = new SqlParameter("@padron", pComercio.Padron);
            SqlParameter direcc = new SqlParameter("@direccion", pComercio.Direccion);
            SqlParameter pre = new SqlParameter("@precio", pComercio.Precio);
            SqlParameter accion = new SqlParameter("@accion", pComercio.Accion);
            SqlParameter banio = new SqlParameter("@banios", pComercio.Baño);
            SqlParameter hab = new SqlParameter("@habitaciones", pComercio.Habitaciones);
            SqlParameter mt2C = new SqlParameter("@mt2const", pComercio.Mt2Const);
            SqlParameter nomUsu = new SqlParameter("@nomUsu", pComercio.UltimoEmp.NomUsu);
            SqlParameter letraDpto = new SqlParameter("@letraDpto", pComercio.Zona.LetraDpto);
            SqlParameter abreciacion = new SqlParameter("@abreviacion", pComercio.Zona.Abreviacion);

            SqlParameter habil = new SqlParameter("@habilitado", pComercio.Habilitado);

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

            comando.Parameters.Add(habil);

            comando.Parameters.Add(retorno);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                afectados = (int)comando.Parameters["@Retorno"].Value;
                if (afectados == -1)
                    throw new Exception("");
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

        public void EliminarComercio(Comercio Co)
        {
            SqlConnection coonexion = new SqlConnection(Conexion.Cnn);
            SqlCommand comando = new SqlCommand("EliminaComercio", coonexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter padron = new SqlParameter("@padron", Co.Padron);

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

        public void ModificarComercio(Comercio Co)
        {
            SqlConnection conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand comando = new SqlCommand("ModificoComercio", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter padron = new SqlParameter("@padron", Co.Padron);
            SqlParameter direcc = new SqlParameter("@direccion", Co.Direccion);
            SqlParameter pre = new SqlParameter("@precio", Co.Precio);
            SqlParameter accion = new SqlParameter("@accion", Co.Accion);
            SqlParameter banio = new SqlParameter("@banios", Co.Baño);
            SqlParameter hab = new SqlParameter("@habitaciones", Co.Habitaciones);
            SqlParameter mt2C = new SqlParameter("@mt2const", Co.Mt2Const);
            SqlParameter nomUsu = new SqlParameter("@nomUsu", Co.UltimoEmp.NomUsu);
            SqlParameter letraDpto = new SqlParameter("@letraDpto", Co.Zona.LetraDpto);
            SqlParameter abreciacion = new SqlParameter("@abreviacion", Co.Zona.Abreviacion);

            SqlParameter habil = new SqlParameter("@habilitado", Co.Habilitado);

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

            comando.Parameters.Add(habil);

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

        public Comercio BuscarComercio(int pPadron)
        {
            Comercio co = null;
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

            bool habilitado;

            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("BuscarComercio " + pPadron, oConexion);

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

                    habilitado = (bool)oReader["habilitado"];
                    co = new Comercio(padron, direccion, precio, accion, banio, habitaciones, mt2C,
                 (ZonaPersistencia.GetInstancia().Busco(letraDpto, abreviacion)),
                 (EmpleadoPersistencia.GetInstancia().BuscarEmpleado(nomUsu)), habilitado);

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

            return co;
        }

        public List<Comercio> ListaComercio()
        {
            List<Comercio> lista = new List<Comercio>();
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

            bool habilitado;
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("ListarComercio", oConexion);
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

                    habilitado = Convert.ToBoolean(oReader["habilitado"]);

                    Comercio c = new Comercio(padron, direccion, precio, accion, banio, habitaciones, mt2C, ((ZonaPersistencia.GetInstancia().Busco(letraDpto, abreviacion))),
                   (EmpleadoPersistencia.GetInstancia().BuscarEmpleado(nomUsu)),habilitado);
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
