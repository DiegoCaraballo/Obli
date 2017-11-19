using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controles
{
    public partial class MenejoServicios : UserControl
    {
        public MenejoServicios()
        {
            InitializeComponent();
        }

        //Propiedades
        public List<string> ListaServicios
        {
            get
            {
                List<string> _lista = new List<string>();
                foreach (Object unServ in lbServicios.Items)
                    _lista.Add(unServ.ToString());

                return _lista;
            }
            set
            {
                lbServicios.Items.Clear();
                if (value != null)
                {
                    foreach (string _unServ in value)
                        lbServicios.Items.Add(_unServ);
                }
            }
        }

        public string Servicio
        {
            get { return txtServicio.Text; }
            set { txtServicio.Text = value; }
        }

        // Agregar servicio
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Verifico que se haya ingresado algo en la caja de texto de servicios
            if (txtServicio.Text.Trim().Length > 0)
            {
                lbServicios.Items.Add(txtServicio.Text.Trim());
                txtServicio.Text = "";
                lblServicio.Text = "Se agrego el servicio";
            }
            else
            {
                lblServicio.Text = "Debe escribir el nombre del servicio";
            }
        }

        // Borrar servicio
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Determino si hay una linea de la lista seleccionada
            if (lbServicios.SelectedIndex > 0)
            {
                lbServicios.Items.Remove(lbServicios.SelectedIndex);
                lblServicio.Text = "Se elimino el servicio";
            }
            else
            {
                lblServicio.Text = "Debe seleccionar un servicio";
            }
        }

    }
}
