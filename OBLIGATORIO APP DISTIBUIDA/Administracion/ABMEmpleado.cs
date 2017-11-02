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

        }

        //Modificar Empleado
        private void MenuItemModificar_Click(object sender, EventArgs e)
        {

        }

        //Eliminar Empleado
        private void MenuItemEliminar_Click(object sender, EventArgs e)
        {

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

        }

        private void DesActivoBotones()
        {
            MenuItemIngresar.Enabled = false;
            MenuItemEliminar.Enabled = false;
            MenuItemModificar.Enabled = false;
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
