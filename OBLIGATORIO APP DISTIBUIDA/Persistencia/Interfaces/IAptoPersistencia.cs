using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades_Compartidas;

namespace Persistencia
{
    public interface IAptoPersistencia
    {
        Apto BuscarApto(int pPadron);
        void EliminarApto(Apto A);
        void AgregarApto(Apto A);
        void ModificarApto(Apto A);
        List<Apto> ListaApto();
    }
}
