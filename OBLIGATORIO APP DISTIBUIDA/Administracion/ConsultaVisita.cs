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

using System.Xml;

namespace Administracion
{
    public partial class ConsultaVisita : Form
    { 
        public ConsultaVisita()
        {
            InitializeComponent();

            MiServicio serv = new MiServicio();
            gvVisitas.DataSource = null;
            XmlNode midoc = serv.ListarVisitas();

            XElement doc = XElement.Parse(midoc.OuterXml);
            var res = (from unNodo in doc.Elements("Propiedad")
                       select new
                      {
                          Padron = unNodo.Element("Padron").Value,
                          Fecha = unNodo.Element("Fecha").Value,
                          Precio = unNodo.Element("Precio").Value,
                          Accion = unNodo.Element("Accion").Value
                      }).ToList();
            gvVisitas.DataSource = res;
            

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        private void btnContarVisitas_Click(object sender, EventArgs e)
        {

        }
    }
}
