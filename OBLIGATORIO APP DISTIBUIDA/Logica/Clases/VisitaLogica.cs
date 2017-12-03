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

            // Se controla que el usuario no pueda visitar + de 2 veces la misma propiedad
            if (numero >= 2)
            {
                throw new Exception("Usted ya visito dos veces esta propiedad");
            }

            IVisitaPersistencia visita2 = FabricaPersistencia.getPersistenciaVisita();
            int num = visita.HoraVisitas(V);

            // Se controla que la propiedad no tenga + de una vista en la misma fecha-hora
            if (num > 0)
            {
                throw new Exception("La propiedad ya tiene una vista agendada para la misma Fecha-Hora");
            }
            IVisitaPersistencia visitar = FabricaPersistencia.getPersistenciaVisita();

            visitar.AgendaVisita(V);

        }

        public List<Visita> ListaVisitas()
        {
            return FabricaPersistencia.getPersistenciaVisita().ListaVisitas();
        }

    }
}
