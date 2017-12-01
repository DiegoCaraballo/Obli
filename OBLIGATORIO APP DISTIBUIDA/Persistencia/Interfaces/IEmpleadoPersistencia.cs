using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades_Compartidas;

namespace Persistencia
{
     public interface IEmpleadoPersistencia
    {
        void AgregarEmpleado(Empleado E);
        void EliminarEmpleado(Empleado E);
        void ModificarEmpleado(Empleado E);
        Empleado BuscarEmpleado(string pNomUsu);
    }
}
