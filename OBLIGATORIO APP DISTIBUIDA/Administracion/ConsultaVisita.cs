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
        private XElement documento = null;
        public ConsultaVisita()
        {
            InitializeComponent();
            CargoListaVisitas();


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            gvVisitas.DataSource = null;
            XElement doc = documento;


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

        private void btnContarVisitas_Click(object sender, EventArgs e)
        {
            gvVisitas.DataSource = null;
            try
            {
                XElement doc = documento;

                var res = (from unNodo in doc.Elements("Propiedad")

                           group unNodo by unNodo.Element("Padron").Value into resu
                           select new
                           {
                               Padron = resu.First().Element("Padron").Value,
                               Cantidad_Visitas = resu.Count()
                           }
                    ).ToList();


                gvVisitas.DataSource = res;




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CargoListaVisitas()
        {
            MiServicio serv = new MiServicio();
     
            XmlNode lista = serv.ListarVisitas();
     
            documento = XElement.Parse(lista.OuterXml);
            var res = (from unNodo in documento.Elements("Propiedad")
                     
                       select new
                       {
                           Padron = unNodo.Element("Padron").Value,
                           Fecha = unNodo.Element("Fecha").Value,
                           Precio = unNodo.Element("Precio").Value,
                           Accion = unNodo.Element("Accion").Value
                       }).ToList();

            gvVisitas.DataSource = res;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
          
             
        }

        private void cboAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvVisitas.DataSource = null;
            try
            {
                XElement doc = documento;


                var res = (from unNodo in doc.Elements("Propiedad")
                           where unNodo.Element("Accion").Value == cboAccion.SelectedItem.ToString()
                           select new
                           {
                               Padron = unNodo.Element("Padron").Value,
                               Fecha = unNodo.Element("Fecha").Value,
                               Precio = unNodo.Element("Precio").Value,
                               Accion = unNodo.Element("Accion").Value
                           }).ToList();

                gvVisitas.DataSource = res;




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtPadron_Validating(object sender, CancelEventArgs e)
        {
            gvVisitas.DataSource = null;
            try
            {
                Convert.ToInt32(txtPadron.Text);
                EPPadron.Clear();
            }
            catch
            {
                EPPadron.SetError(txtPadron, "Solo se pueden ingresar numeros");
                e.Cancel = true;
            }
            try
            {
                XElement doc = documento;


                var res = (from unNodo in doc.Elements("Propiedad")
                           where unNodo.Element("Padron").Value == txtPadron.Text
                           select new
                           {
                               Padron = unNodo.Element("Padron").Value,
                               Fecha = unNodo.Element("Fecha").Value,
                               Precio = unNodo.Element("Precio").Value,
                               Accion = unNodo.Element("Accion").Value
                           }).ToList();

                gvVisitas.DataSource = res;




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ConsultaVisita_Load(object sender, EventArgs e)
        {

        }
    }
}
