using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades_Compartidas;

namespace Persistencia
{
    public interface IComercioPersistencia
    {
        Comercio BuscarComercio(int pPadron);
        void AgregarComercio(Comercio Co);
        void ModificarComercio(Comercio Co);
        void EliminarComercio(Comercio Co);
        List<Comercio> ListaComercio();       
    }
}
