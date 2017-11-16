﻿using System;
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
    public partial class Login : Form
    {
        private ServicioWeb.Empleado emp = null;

        public Login()
        {
            InitializeComponent();
        }

        public void IniciarSession2(object sender, EventArgs e)
        {
            try
            {
                ServicioWeb.Empleado empleado = null;
                MiServicio serv = new MiServicio();
                empleado = serv.BuscarEmpleado(ccLogin.Usuario);
                if (empleado == null)
                {
                    lblMensaje.Text = "No existe el empleado";
                }
                else if (empleado.Pass == ccLogin.Pass.ToString())
                {
                    this.Hide();
                    Form abm = new Default(empleado);
                    abm.ShowDialog();
                    this.Close();
                }
                else
                {
                    lblMensaje.Text = "La Password no es correcta";
                }


            }
            catch (Exception ex) 
            { 
                lblMensaje.Text = ex.Message; 
            }


        }

      

        private void Login_Load(object sender, EventArgs e)
        {


            try
            {
                ccLogin.IniciarSession +=  new EventHandler(IniciarSession2);
                this.AcceptButton = ccLogin.botonLogin;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        private void ccLogin_Click(object sender, EventArgs e)
        {

        }

      
    }
}
