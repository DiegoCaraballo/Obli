using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using Entidades_Compartidas;

namespace Logica
{
    public interface IEmpleadoLogica
    {
        void AgregarEmpleado(Empleado E);
        void EliminarEmpleado(Empleado E);
        void ModificarEmpleado(Empleado E);
        Empleado BuscarEmpleado(string pNomUsu);
    }
}
