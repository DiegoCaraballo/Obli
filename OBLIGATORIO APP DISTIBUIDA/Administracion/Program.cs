using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Administracion
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
           Application.Run(new ConsultaVisita());
=======
            Application.Run(new Default());
>>>>>>> 5da046f01d3b9740b37072e3b3ffc0e23443d09d
           // Application.Run(new ABMApto());

        }
    }
}
