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
    public partial class ABMCasa : Form
    {  private Empleado emp;
        public ABMCasa(Empleado e)
        {
            emp = e;
        }
        public ABMCasa()
        {
            InitializeComponent();
            Accesos();
        }

        private void aBMCASAToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
    }
}
