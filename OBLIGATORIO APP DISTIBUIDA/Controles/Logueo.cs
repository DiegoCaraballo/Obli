using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

//TODO - ver por que usa entidades compartidas

namespace Controles
{
    public partial class Logueo : ContainerControl
    {
        //Atributos
        private TextBox txtUsu;
        private TextBox txtPass;

        private Label lblUsu;
        private Label lblPass;
        private Label lblMensaje;

        private Button btnIngresar;

        //Constructor
        public Logueo()
        {
            //Mensaje
            lblMensaje = new Label();
            lblMensaje.Text = "";
            this.Controls.Add(lblMensaje);
            lblMensaje.AutoSize = true;

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

            lblUsu.Location = new Point(0, 0);
            txtUsu.Location = new Point(70, 0);

            lblPass.Location = new Point(0, 35);
            txtPass.Location = new Point(70, 35);

            lblMensaje.Location = new Point(50, 110);

            btnIngresar.Location = new Point(80, 75);
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
            try
            {
                // Se controla que ingrese un usuario y una contraseña
                if (txtUsu.Text.Trim() == "" || txtPass.Text.Trim() == "")
                {
                    lblMensaje.Text = "Usuario y Contraseña requeridos";
                }
                else
                {
                    lblMensaje.Text = "";
                    IniciarSession(this, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

    }
}
