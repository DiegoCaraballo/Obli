using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades_Compartidas;



namespace Logica
{
     public interface IZonaLogica
        {
            void AgregarZona(Zona Zo);
            void ModificarZona(Zona Zo);
            void EliminarZona(Zona Zo);
            List<Zona> Listo();
            List<Zona> ListoPorDpto(string _letraDpto);
            Zona BuscarZona(string pLetra, string pAbrev);
        }
}
