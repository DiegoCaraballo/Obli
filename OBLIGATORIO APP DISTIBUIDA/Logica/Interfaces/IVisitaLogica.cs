using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using Entidades_Compartidas;

namespace Logica
{
    public interface IVisitaLogica
    {
        void AgendaVisita(Visita V);
        List<Visita> ListaVisitas();
    }
}
