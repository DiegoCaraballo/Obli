using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Entidades_Compartidas;

using System.Windows.Forms;
using System.Drawing;
namespace Controles
{
   public partial class Logueo : ContainerControl
    {
        private TextBox txtUsu;
        private TextBox txtPass;
        private Button btnIngresar;
        private Button btnCancelar;


        public Logueo()
        {
     
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            txtUsu = new TextBox();
            txtUsu.Width = 130;
            txtUsu.Height = 30;
            txtUsu.Location = new Point(10, 40);

            txtPass = new TextBox();
            txtPass.Width = 130;
            txtPass.Height = 30;
            txtPass.Location = new Point(10, 10);
         
  
        }
    }
}
