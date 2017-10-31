using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades_Compartidas;
using Persistencia;

namespace Logica
{
    public class FabricaLogica
    {
        public static IEmpleadoLogica getEmpleadoLogica()
        {
            return EmpleadoLogica.GetInstancia();
        }
        public static IPropiedadesLogica getPropiedadesLogica()
        {
            return PropiedadesLogica.GetInstancia();
        }
        public static IZonaLogica getZonaLogica()
        {
            return ZonaLogica.GetInstancia();
        }
        public static IVisitaLogica getVisitaLogica()
        {
            return VisitaLogica.GetInstancia();
        }
    }
}
