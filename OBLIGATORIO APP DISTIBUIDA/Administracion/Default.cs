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
    public partial class Default : Form
    {
        private Empleado EmpLogueado;

        public Default(Empleado pEmp)
       {
           InitializeComponent();
           EmpLogueado = pEmp;
          lblUSU.Text = "Empleado: " + EmpLogueado.NomUsu;
       }

        public Default()
        {
            InitializeComponent();
        }  

        // Form de ABM Empleados
        private void aBMEmleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABMEmpleado _unForm = new ABMEmpleado();
            _unForm.ShowDialog();
        }

        // Form de ABM Zonas
        private void aBMZonasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ABMZona _unForm = new ABMZona();
            _unForm.ShowDialog();
        }

        // Form de ABM Casas
        private void aBMCasasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABMCasa _unForm = new ABMCasa(EmpLogueado);
            _unForm.ShowDialog();
        }

        // Form de ABM Apartamento
        private void aBMApartamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABMApto _unForm = new ABMApto(EmpLogueado);
            _unForm.ShowDialog();
        }

        // Form de ABM Local Comercial
        private void aBMLocalComercialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABMComercio _unForm = new ABMComercio(EmpLogueado);
            _unForm.ShowDialog();
        }

        // Form Consulta visitas
        private void consultaDeVisitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaVisita _unForm = new ConsultaVisita();
            _unForm.ShowDialog();
        }
    }
}
