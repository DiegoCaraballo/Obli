using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades_Compartidas;
using Persistencia;

namespace Logica
{
    internal class VisitaLogica : IVisitaLogica
    {
        #region singleton
        private static VisitaLogica instancia = null;
        private VisitaLogica() { }
        public static VisitaLogica GetInstancia()
        {
            if (instancia == null)
                instancia = new VisitaLogica();
            return instancia;
        }
        #endregion

        public void AgendaVisita(Visita V)
        {
            FabricaPersistencia.getPersistenciaVisita().AgendaVisita(V);
        }
        public List<Visita> ListaVisitas()
        {
          return  FabricaPersistencia.getPersistenciaVisita().ListaVisitas();
        }

    }
}
