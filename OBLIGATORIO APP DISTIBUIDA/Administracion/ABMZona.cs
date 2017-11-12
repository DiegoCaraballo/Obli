using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Administracion
{
    public partial class ABMZona : Form
    {
        public ABMZona()
        {
            InitializeComponent();
            Accesos();
            EstadoInicial();
        }
        public void Accesos()
        {
            MenuItemAyuda.ShortcutKeys = Keys.F1;
            MenuItemBuscar.ShortcutKeys = Keys.F2;
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
            txtCodigo.Text = "";
            txtHabitantes.Text = "";
            txtNombre.Text = "";
            txtServicio.Text = "";
            lbServicios.Items.Clear();
        }

        //Deja todo en estado Inicial
        public void EstadoInicial()
        {
            LimpiarCampos();
            MenuItemBuscar.Enabled = true;
            txtCodigo.Enabled = true;
            //cboDepartamento.SelectedIndex = 0;
            MenuItemIngresar.Enabled = false;
            MenuItemModificar.Enabled = false;
            MenuItemEliminar.Enabled = false;
            //btnAgregar.Enabled = false;
            //btnBorrar.Enabled = false;
            txtNombre.Enabled = false;
            //txtServicio.Enabled = false;
            txtHabitantes.Enabled = false;
            cboDepartamento.Enabled = true;
        }

        //Buscar Zona
        private void MenuItemBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Text = "";
                if (txtCodigo.Text.Trim() == "")
                    throw new Exception("Debe ingresar un código");


            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
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
            catch(Exception ex)
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
        }

        private void MenuItemIngresar_Click(object sender, EventArgs e)
        {

        }
    }
}
