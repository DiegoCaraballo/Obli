using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades_Compartidas;

namespace Persistencia
{
    public interface IVisitaPersistencia
    {
        void AgendaVisita(Visita V);
        List<Visita> ListaVisitas();
        int VecesVisitado(Visita v);
    }
}
