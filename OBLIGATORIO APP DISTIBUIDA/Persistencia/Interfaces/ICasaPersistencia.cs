using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades_Compartidas;

namespace Persistencia
{
    public interface ICasaPersistencia
    {
        Casa BuscarCasa(int pPadron);
        void EliminarCasa(Casa C);
        void AgregarCasa(Casa C);
        void ModificarCasa(Casa C);
        List<Casa> ListaCasa();
    }
}
