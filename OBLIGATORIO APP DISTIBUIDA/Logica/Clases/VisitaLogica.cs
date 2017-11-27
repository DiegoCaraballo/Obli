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
            IVisitaPersistencia visita = FabricaPersistencia.getPersistenciaVisita();
            int numero = visita.VecesVisitado(V);
            if (numero < 2)
            {

                FabricaPersistencia.getPersistenciaVisita().AgendaVisita(V);
            }
            else
            {
                throw new Exception("usted ya visito dos veces esta propiedad");
            }
        }
        public List<Visita> ListaVisitas()
        {
            return FabricaPersistencia.getPersistenciaVisita().ListaVisitas();
        }



    }
}
