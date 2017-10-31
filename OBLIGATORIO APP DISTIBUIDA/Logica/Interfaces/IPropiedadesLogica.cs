using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades_Compartidas;

namespace Logica
{
    public interface IPropiedadesLogica
    {
        void AltaPropiedad(Propiedad pPropiedad);
        void BajaPropiedad(Propiedad pPropiedad);
        void ModificaPropiedad(Propiedad pPropiedad);
        List<Propiedad> ListarPropiedades();
        Propiedad BuscarPropiedad(int pPadron);
    }
}