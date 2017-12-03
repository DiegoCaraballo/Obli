using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class Conexion
    {
      
        //Diego 
       // private static string _cnn = "Data Source=.; Initial Catalog = BiosRealState; Integrated Security = true";

        //Nico       
        private static string _cnn = "Data Source=PC-NICO-PC\\SQLEXPRESS; Initial Catalog = BiosRealState; Integrated Security = true";

        public static string Cnn
        {
            get { return _cnn; }
        }

    }
}
