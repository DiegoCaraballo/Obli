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
    public partial class ABMEmpleado : Form
    {
        private Empleado emp;

        public ABMEmpleado()
        {
            InitializeComponent();
            Accesos();
            LimpioControles();
            DesActivoBotones();
        }

        public void Accesos()
        {
            MenuItemAyuda.ShortcutKeys = Keys.F1;
            MenuItemIngresar.ShortcutKeys = Keys.F3;
            MenuItemModificar.ShortcutKeys = Keys.F4;
            MenuItemEliminar.ShortcutKeys = Keys.F5;
            MenuItemCancelar.ShortcutKeys = Keys.F6;
        }

        //Ayuda para el usuario
        private void MenuItemAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Puede utilizar las siguientes teclas para facil acceso a los Items del Menu:\nF1= Ayuda\nF2= Buscar\nF3= Ingresar\nF4= Modificar\nF5= Eliminar\nF6= Cancelar");
        }

        //Validar usuario al buscar
        private void txtUsuario_Validating(object sender, CancelEventArgs e)
        {
            //Verifico que ingrese un usuario
            try
            {
                if (txtUsuario.Text.Trim() != "")
                {
                    EPUsuario.Clear();
                }
                else
                {
                    throw new Exception("El usuario es requerido");                    
                }
            }
            catch (Exception ex)
            {
                EPUsuario.SetError(txtUsuario, ex.Message);
                e.Cancel = true;
                return;
            }

            try
            {
                ServicioWeb.Empleado empleado = null;
                MiServicio serv = new MiServicio();
                empleado = serv.BuscarEmpleado(txtUsuario.Text.Trim());

                if (empleado == null)
                //no existe empleado, es un alta, limpio campos y habilito para ingresar
                {
                    MenuItemIngresar.Enabled = true;
                    MenuItemEliminar.Enabled = false;
                    MenuItemModificar.Enabled = false;
                }
                else
                {
                    //existe, cargo y permito eliminar o modificar
                    emp = empleado;
                    txtPassword.Text = empleado.Pass;
                    MenuItemIngresar.Enabled = false;
                    MenuItemModificar.Enabled = true;
                    MenuItemEliminar.Enabled = true;
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

        //Ingresar Empleado
        private void MenuItemIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                //creo el objeto que me permita trabajar con el ws
                MiServicio LEmpleado = new MiServicio();

                //utilizo la operacion del ws
                string nombre = txtUsuario.Text.Trim().ToUpper();
                string pass = txtPassword.Text;

                Empleado unEmpleado = new Empleado();
                unEmpleado.NomUsu = nombre;
                unEmpleado.Pass = pass;
                LEmpleado.AgregarEmpleado(unEmpleado);
                //Si llego hasta acá todo esta bien
                lblMensaje.Text = "Alta con éxito";
                LimpioControles();
                DesActivoBotones();
            }
            catch(Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        //Modificar Empleado
        private void MenuItemModificar_Click(object sender, EventArgs e)
        {
            try
            {
                //creo el objeto que me permita trabajar con el WS
                MiServicio LEmpleado = new MiServicio();

                emp.NomUsu = txtUsuario.Text.Trim().ToUpper();
                emp.Pass = txtPassword.Text;

                LEmpleado.ModificarEmpleado(emp);

                //si llego acá se modificó el empleado
                lblMensaje.Text = "Modificación Exitosa";
                LimpioControles();
                DesActivoBotones();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        //Eliminar Empleado
        private void MenuItemEliminar_Click(object sender, EventArgs e)
        {
            ServicioWeb.Empleado _unEmpleado = null;
            try
            {
                //creo el objeto que me permita trabajar con el WS
                MiServicio LEmpleado = new MiServicio();

                LEmpleado.EliminarEmpleado(emp);

                //si llego aca elimine el empleado
                lblMensaje.Text = "Se eliminó correctamente";
                LimpioControles();
                DesActivoBotones();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        //Cancelar valores actuales
        private void MenuItemCancelar_Click(object sender, EventArgs e)
        {
            this.LimpioControles();
            this.DesActivoBotones();
            lblMensaje.Text = "";
            emp = null;
        }

        private void DesActivoBotones()
        {
            MenuItemIngresar.Enabled = false;
            MenuItemEliminar.Enabled = false;
            MenuItemModificar.Enabled = false;
            //txtPassword.Enabled = false;
        }

        private void LimpioControles()
        {
            txtUsuario.Text = "";
            txtPassword.Text = "";
        }
        
    }
}
