using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Controles;

using Administracion.ServicioWeb;

namespace Administracion
{
    public partial class ABMZona : Form
    {
        private Zona zona;

        public ABMZona()
        {
            InitializeComponent();
            Accesos();
            EstadoInicial();
        }

        public void Accesos()
        {
            MenuItemAyuda.ShortcutKeys = Keys.F1;
            MenuItemIngresar.ShortcutKeys = Keys.F3;
            MenuItemModificar.ShortcutKeys = Keys.F4;
            MenuItemEliminar.ShortcutKeys = Keys.F5;
            MenuItemCancelar.ShortcutKeys = Keys.F6;
        }

        private void MenuItemAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Puede utilizar las siguientes teclas para facil acceso a los Items del Menu:\nF1= Ayuda\nF2= Buscar\nF3= Ingresar\nF4= Modificar\nF5= Eliminar\nF6= Cancelar");
        }

        //Limpio campos
        public void LimpiarCampos()
        {
            txtHabitantes.Text = "";
            txtNombre.Text = "";
            //TODO - Ver como limpiar los servicios del UserControl
            //txtServicio.Text = "";
            //lbServicios.Items.Clear();
        }

        //Deja todo en estado Inicial
        public void EstadoInicial()
        {
            LimpiarCampos();
            //cboDepartamento.SelectedIndex = 0;
            MenuItemIngresar.Enabled = false;
            MenuItemModificar.Enabled = false;
            MenuItemEliminar.Enabled = false;
            //btnAgregar.Enabled = false;
            //btnBorrar.Enabled = false;
            txtNombre.Enabled = false;
            //txtServicio.Enabled = false;
            txtHabitantes.Enabled = false;
        }

        // Botón que cancela y deja en estado inicial
        private void MenuItemCancelar_Click(object sender, EventArgs e)
        {
            EstadoInicial();
            zona = null;
        }

        // Ingreso de una zona
        private void MenuItemIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                // Creo el objeto que me permita trabajar con el WebService
                MiServicio LZona = new MiServicio();

                // Utilizo la operación del WS
                string codigo = codigoDpto1.Codigo.ToString().ToUpper();
                string letraDpto = codigoDpto1.LetraDepto.ToString();
                string nombre = txtNombre.Text.Trim().ToUpper();
                int cantHabitantes = Convert.ToInt32(txtHabitantes.Text);

                Zona unaZona = new Zona();
                unaZona.Abreviacion = codigo;
                unaZona.LetraDpto = letraDpto;
                unaZona.Nombre = nombre;
                unaZona.CantHabitantes = cantHabitantes;
                //unaZona.LosServicios = lbServicios
                //TODO - Ver como paso los servicios (creo un UserControl)
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        // Valido todo el UserControl para buscar la zona
        private void codigoDpto1_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (codigoDpto1.Codigo != "" && codigoDpto1.LetraDepto != "")
                {
                    EPBuscar.Clear();
                }
                else
                {
                    throw new Exception("Error al validar Código + Departamento");
                }
            }
            catch (Exception ex)
            {
                EPBuscar.SetError(codigoDpto1, ex.Message);
                e.Cancel = true;
                return;
            }

            try
            {
                // Si la validación es correcta, busco la Zona
                ServicioWeb.Zona z = null;
                MiServicio serv = new MiServicio();
                z = serv.BuscarZona(codigoDpto1.LetraDepto, codigoDpto1.Codigo);

                if (z == null)
                {
                    // no existe la zona, es un alta, limpio campos y habilito para ingresar
                    MenuItemIngresar.Enabled = true;
                    MenuItemEliminar.Enabled = false;
                    MenuItemModificar.Enabled = false;
                }
                else
                {
                    //existe, cargo y permito eliminar o modificar
                    zona = z;
                    txtHabitantes.Text = zona.CantHabitantes.ToString();
                    txtNombre.Text = zona.Nombre;
                    foreach (Servicio servicio in zona.LosServicios)
                    {
                        //TODO - Ver como pasar los servicios del UserControl
                        //lbServicios.Items.Add(servicio.Servicios.ToString());
                    }
                }
            }
            catch (System.Web.Services.Protocols.SoapException ex)
            {
                if (ex.Detail.InnerText.Length > 40)
                    lblMensaje.Text = ex.Detail.InnerText.Substring(0, 40);
                else
                    lblMensaje.Text = ex.Detail.InnerText;
            }
            catch (Exception ex)
            {
                if (ex.Message.Length > 40)
                    lblMensaje.Text = ex.Message.Substring(0, 40);
                else
                    lblMensaje.Text = ex.Message;
            }
        }



    }
}
