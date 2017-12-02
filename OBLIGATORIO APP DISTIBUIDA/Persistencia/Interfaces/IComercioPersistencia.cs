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
        void EliminarComercio(Comercio Co);
        void AgregarComercio(Comercio Co);
        void ModificarComercio(Comercio Co);
        List<Comercio> ListaComercio();       
    }
}
