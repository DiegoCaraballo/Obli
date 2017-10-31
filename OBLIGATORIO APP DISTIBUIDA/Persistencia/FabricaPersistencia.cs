using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades_Compartidas;


namespace Persistencia
{
public class FabricaPersistencia
    {
        public static ICasaPersistencia getPersistenciaCasa()
        {
            return (CasaPersistencia.GetInstancia());
        }

        public static IAptoPersistencia getPersistenciaApto()
        {
            return (AptoPersistencia.GetInstancia());
        }

        public static IComercioPersistencia getPersistenciaComercio()
        {
            return (ComercioPersistencia.GetInstancia());
        }

        public static IEmpleadoPersistencia getPersistenciaEmpleado()
        { 
            return (EmpleadoPersistencia.GetInstancia ());
        }
        public static IZonaPersistencia getPersistenciaZona()
        {
            return (ZonaPersistencia.GetInstancia());
        }
        public static IVisitaPersistencia getPersistenciaVisita()
        {
            return (VisitaPersistencia.GetInstancia());
        }
        
    }
}
