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
        //Atributos
        private TextBox txtUsu;
        private TextBox txtPass;

        private Label lblUsu;
        private Label lblPass;

        private Button btnIngresar;

        //Constructor
        public Logueo()
        {
            //Usuario
            txtUsu = new TextBox();
            txtUsu.Width = 140;
            txtUsu.Height = 20;
            txtUsu.TabIndex = 0;
            this.Controls.Add(txtUsu);

            lblUsu = new Label();
            lblUsu.Text = "Usuario:";
            this.Controls.Add(lblUsu);

            //Contraseña
            txtPass = new TextBox();
          txtPass.UseSystemPasswordChar = true;
            txtPass.Width = 140;
            txtPass.Height = 20;
            txtPass.TabIndex = 1;
            txtPass.MaxLength = 10;
            this.Controls.Add(txtPass);

            lblPass = new Label();
            lblPass.Text = "Contraseña:";
            this.Controls.Add(lblPass);

            //Botón de Login
            btnIngresar = new Button();
            btnIngresar.Width = 120;
            btnIngresar.Height = 25;
            btnIngresar.Text = "Inicio de Sesión";
            btnIngresar.TabIndex = 2;
            btnIngresar.Click += new EventHandler(btnIngresar_Click);
            this.Controls.Add(btnIngresar);         
        }

        //Para hacer uso de la propiedad AcceptButton
        public Button botonLogin
        {
            get { return btnIngresar; }
        }

        //sobreescribo el metodo CreateChilCntrols
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //determino despliegue de los controles en pantalla
           
            lblUsu.Location = new Point(0,0);
            txtUsu.Location = new Point(40, 0);

            lblPass.Location = new Point(0, 35);
            txtPass.Location = new Point(70,35);
   
            btnIngresar.Location = new Point(50, 75);
        }

        public string Usuario
        {
            get { return txtUsu.Text.Trim(); }
        }

        public string Pass
        {
            get { return txtPass.Text.Trim(); }
        }

        public event EventHandler IniciarSession;

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            IniciarSession(this, new EventArgs());
        }
    }
}
