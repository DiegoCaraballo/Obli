using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class Conexion
    {
        //Nadia
         //private static string _cnn = "Data Source=DESKTOP-6PHCMHQ\\SQLEXPRESS; Initial Catalog = BiosRealState; Integrated Security = true";

        //Diego
<<<<<<< HEAD
       //private static string _cnn = "Data Source=.; Initial Catalog = BiosRealState; Integrated Security = true";
=======
       private static string _cnn = "Data Source=.; Initial Catalog = BiosRealState; Integrated Security = true";
>>>>>>> 2a11ad0ed29f3bd60cbf59f70e89e416cf7fdcfb

        //Nico       
       // private static string _cnn = "Data Source=PC-NICO-PC\\SQLEXPRESS; Initial Catalog = BiosRealState; Integrated Security = true";

        public static string Cnn
        {
            get { return _cnn; }
        }

    }
}
