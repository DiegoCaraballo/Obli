using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades_Compartidas;
using Persistencia;

namespace Logica
{
    internal class EmpleadoLogica : IEmpleadoLogica
    {
        private static EmpleadoLogica instancia = null;
        private EmpleadoLogica() { }

        public static EmpleadoLogica GetInstancia()
        {
            if (instancia == null)
                instancia = new EmpleadoLogica();
            return instancia;
        }

        public void AgregarEmpleado(Empleado E)
        {

            try
            {
                FabricaPersistencia.getPersistenciaEmpleado().AgregarEmpleado(E);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarEmpleado(Empleado E)
        {
            FabricaPersistencia.getPersistenciaEmpleado().EliminarEmpleado(E);
        }

        public void ModificarEmpleado(Empleado E)
        {
            FabricaPersistencia.getPersistenciaEmpleado().ModificarEmpleado(E);
        }

        public Empleado BuscarEmpleado(string pNomUsu)
        {
           return FabricaPersistencia.getPersistenciaEmpleado().BuscarEmpleado(pNomUsu);
        }

    }
}
