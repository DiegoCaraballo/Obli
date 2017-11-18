using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            txtServicio.Text = "";
            lbServicios.Items.Clear();
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

        // Agrega servicios
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtServicio.Text.Trim().ToUpper() != "")
                {
                    lblMensaje.Text = "";
                    foreach (var servicio in lbServicios.Items)
                    {
                        if (servicio.ToString().Trim().ToUpper() == txtServicio.Text.Trim().ToUpper())
                        {
                            throw new Exception("El servicio ya fue ingresado");
                        }
                    }
                    lbServicios.Items.Add(txtServicio.Text.Trim().ToUpper());
                    txtServicio.Text = "";
                }
                else
                {
                    lblMensaje.Text = "El servicio no puede ser vacío";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        // Botón que borra servicios del LIstBox
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                //determino si hay una linea de la lista seleccionada
                if (lbServicios.SelectedIndex >= 0)
                {
                    lbServicios.Items.RemoveAt(lbServicios.SelectedIndex);
                    lblMensaje.Text = "";
                }
                else
                {
                    lblMensaje.Text = "Debe seleccionar un Servicio de la lista para eliminar";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }


        private void MenuItemCancelar_Click(object sender, EventArgs e)
        {
            EstadoInicial();
            zona = null;
        }

        private void MenuItemIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtengo los datos del UserControl - CodigoDpto
                string letraDpto = codigoDpto1.LetraDepto;
                string codigo = codigoDpto1.Codigo;
            }
            catch(Exception ex)
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
            catch(Exception ex)
            {
                EPBuscar.SetError(codigoDpto1, ex.Message);
                e.Cancel = true;
                return;
            }

            try
            {
                ServicioWeb.Zona z = null;
                MiServicio serv = new MiServicio();
                zona = serv.BuscarZona(codigoDpto1.LetraDepto, codigoDpto1.Codigo);

                if (zona == null)
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
                        lbServicios.Items.Add(servicio.Servicios.ToString());
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
