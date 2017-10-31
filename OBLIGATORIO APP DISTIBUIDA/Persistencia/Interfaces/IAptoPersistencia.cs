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
        void AgregarApto(Apto A);
        void ModificarApto(Apto A);
        void EliminarApto(Apto A);
        List<Apto> ListaApto();
    }
}
