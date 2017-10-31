using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades_Compartidas;
using Persistencia;

namespace Logica
{
    internal class PropiedadesLogica : IPropiedadesLogica
    {

        private static PropiedadesLogica instancia = null;
        private PropiedadesLogica() { }
        public static PropiedadesLogica GetInstancia()
        {
            if (instancia == null)
                instancia = new PropiedadesLogica();
            return instancia;
        }


        public void AltaPropiedad(Propiedad unaProp)
        {
            try
            {
                if (unaProp is Casa)
                {
                    FabricaPersistencia.getPersistenciaCasa().AgregarCasa((Casa)unaProp);
                }
                else if (unaProp is Apto)
                {
                    FabricaPersistencia.getPersistenciaApto().AgregarApto((Apto)unaProp);
                }
                else
                {
                    FabricaPersistencia.getPersistenciaComercio().AgregarComercio((Comercio)unaProp);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void BajaPropiedad(Propiedad unaProp)
        {
            try
            {
                if (unaProp is Casa)
                {
                    FabricaPersistencia.getPersistenciaCasa().EliminarCasa((Casa)unaProp);
                }
                else if (unaProp is Apto)
                {
                    FabricaPersistencia.getPersistenciaApto().EliminarApto((Apto)unaProp);
                }
                else
                {
                    FabricaPersistencia.getPersistenciaComercio().EliminarComercio((Comercio)unaProp);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void ModificaPropiedad(Propiedad unaProp)
        {
            try
            {
                if (unaProp is Casa)
                {
                    FabricaPersistencia.getPersistenciaCasa().ModificarCasa((Casa)unaProp);
                }
                else if (unaProp is Apto)
                {
                    FabricaPersistencia.getPersistenciaApto().ModificarApto((Apto)unaProp);
                }
                else
                {
                    FabricaPersistencia.getPersistenciaComercio().ModificarComercio((Comercio)unaProp);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Propiedad BuscarPropiedad(int pPadron)
        {
            try
            {
                Propiedad p = null;
                p = FabricaPersistencia.getPersistenciaApto().BuscarApto(pPadron);
                if (p == null)
                {
                    p = FabricaPersistencia.getPersistenciaCasa().BuscarCasa(pPadron);
                    if (p == null)
                        p = FabricaPersistencia.getPersistenciaComercio().BuscarComercio(pPadron);

                }
                return p;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Propiedad> ListarPropiedades()
        {
            try
            {
                List<Propiedad> lista = new List<Propiedad>();
                lista.AddRange(FabricaPersistencia.getPersistenciaApto().ListaApto());
                lista.AddRange(FabricaPersistencia.getPersistenciaCasa().ListaCasa());
                lista.AddRange(FabricaPersistencia.getPersistenciaComercio().ListaComercio());
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
