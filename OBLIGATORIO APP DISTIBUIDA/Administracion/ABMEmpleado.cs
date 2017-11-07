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
        public ABMEmpleado()
        {
            InitializeComponent();
            Accesos();
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

        //Ayuda para el usuario
        private void MenuItemAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Puede utilizar las siguientes teclas para facil acceso a los Items del Menu:\nF1= Ayuda\nF2= Buscar\nF3= Ingresar\nF4= Modificar\nF5= Eliminar\nF6= Cancelar");
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
                lblError.Text = "Alta con éxito";
                LimpioControles();
                DesActivoBotones();
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        //Modificar Empleado
        private void MenuItemModificar_Click(object sender, EventArgs e)
        {
            ServicioWeb.Empleado _unEmpleado = null;
            try
            {
                //creo el objeto que me permita trabajar con el WS
                MiServicio LEmpleado = new MiServicio();

                //Utilizo la operación del WS
                string nombre = txtUsuario.Text.Trim().ToUpper();
                _unEmpleado = LEmpleado.BuscarEmpleado(nombre);
                string pass = txtPassword.Text;
                Empleado unEmpleado = new Empleado();
                unEmpleado.NomUsu = nombre;
                unEmpleado.Pass = pass;
                LEmpleado.ModificarEmpleado(unEmpleado);

                //si llego acá se modificó el empleado
                lblError.Text = "Modificación Exitosa";
                LimpioControles();
                DesActivoBotones();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
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
                //Utilizo la operación del WS
                string nombre = txtUsuario.Text.Trim().ToUpper();
                _unEmpleado = LEmpleado.BuscarEmpleado(nombre);
                LEmpleado.EliminarEmpleado(_unEmpleado);

                //si llego aca elimine el empleado
                lblError.Text = "Se eliminó correctamente";
                LimpioControles();
                DesActivoBotones();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        //Cancelar valores actuales
        private void MenuItemCancelar_Click(object sender, EventArgs e)
        {
            this.LimpioControles();
            this.DesActivoBotones();
        }

        //Buscar empleado
        private void MenuItemBuscar_Click(object sender, EventArgs e)
        {
            ServicioWeb.Empleado _unEmpleado = null;
            try
            {
                lblError.Text = "";

                if (txtUsuario.Text.Trim() == "" || txtUsuario.Text.Trim().Length > 20 || txtUsuario.Text.Trim().Length < 4)
                {
                    throw new Exception("El usuario debe tener entre 4 y 20 caracteres");
                }
                else
                {
                    //creo un objeto que me permita trabajar con el WS
                    MiServicio LEmpleado = new MiServicio();
                    //utilizo la operacion del WebService
                    _unEmpleado = LEmpleado.BuscarEmpleado(txtUsuario.Text.Trim());
                    //determino acción
                    if (_unEmpleado == null)
                    //no existe empleado, es un alta, limpio campos y habilito para ingresar
                    {
                        MenuItemIngresar.Enabled = true;
                        MenuItemEliminar.Enabled = false;
                        MenuItemModificar.Enabled = false;
                        txtPassword.Enabled = true;
                    }
                    else
                    {
                        //existe, cargo y permito eliminar o modificar
                        txtPassword.Text = _unEmpleado.Pass;
                        MenuItemIngresar.Enabled = false;
                        MenuItemModificar.Enabled = true;
                        MenuItemEliminar.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "ERROR" + ex.Message;
            }
            
        }

        private void DesActivoBotones()
        {
            MenuItemIngresar.Enabled = false;
            MenuItemEliminar.Enabled = false;
            MenuItemModificar.Enabled = false;
            txtPassword.Enabled = false;
        }

        private void LimpioControles()
        {
            txtUsuario.Text = "";
            txtPassword.Text = "";
        }

        //Abre el ABM de Zonas
        private void aBMZonaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //Abre el ABM de Apto
        private void aBMEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //Abre el ABM de Casa
        private void aBMCASAToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //Abre el ABM de Comercio
        private void aBMAptoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
