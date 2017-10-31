using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades_Compartidas;
using Persistencia;

namespace Logica
{
   internal class ZonaLogica : IZonaLogica
    {
       
        private static ZonaLogica instancia = null;
        private ZonaLogica() { }
        public static ZonaLogica GetInstancia()
        {
            if (instancia == null)
                instancia = new ZonaLogica();
            return instancia;
        }

        public void AgregarZona(Zona Zo)
        {
            FabricaPersistencia.getPersistenciaZona().AgregarZona(Zo);
        }

        public void ModificarZona(Zona Zo)
        {
            FabricaPersistencia.getPersistenciaZona().ModificarZona(Zo);
        }

        public void EliminarZona(Zona Zo)
        {
            FabricaPersistencia.getPersistenciaZona().EliminarZona(Zo);
        }

        public List<Zona> Listo()
        {
            return FabricaPersistencia.getPersistenciaZona().Listo();
        }

        public List<Zona> ListoPorDpto(string _letraDpto)
        {
            return FabricaPersistencia.getPersistenciaZona().ListoPorDpto(_letraDpto);
        }

       public Zona BuscarZona(string pLetra, string pAbrev)
       {
           return FabricaPersistencia.getPersistenciaZona().Busco(pLetra, pAbrev);
       }
    }
}
