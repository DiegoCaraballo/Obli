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
        void AgregarCasa(Casa C);
        void ModificarCasa(Casa C);
        void EliminarCasa(Casa C);
        List<Casa> ListaCasa();
    }
}
