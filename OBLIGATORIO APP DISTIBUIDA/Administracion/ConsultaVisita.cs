using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Xml.Linq;
using Administracion.ServicioWeb;


namespace Administracion
{
    public partial class ConsultaVisita : Form
    {
        public ConsultaVisita()
        {
            InitializeComponent();

                        MiServicio serv = new MiServicio();

                        gvVisitas.DataSource = serv.ListarVisitas();

           
                        //XmlDataDocument xmlDatadoc = new XmlDataDocument();
                        //xmlDatadoc.DataSet.ReadXml("C:\\books.xml");

                        //DataSet ds = new DataSet("Books DataSet");
                        //ds = xmlDatadoc.DataSet;

                        //dataGrid1.DataSource = ds.DefaultViewManager; 
                
        }
    }
}
