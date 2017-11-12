﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Entidades_Compartidas;
using Logica;
using Administracion.ServicioWeb;

namespace Administracion
{
    public partial class Login : Form
    {
        //private Empleado empleado = null;

        public Login()
        {

            //InitializeComponent();

            InitializeComponent();  }

        public void IniciarSession(object sender, EventArgs e)
        {

        //    try
        //    {
        //        empleado = FabricaLogica.getEmpleadoLogica().Log(this.ccLog.Usuario, this.ccLog.Contraseña);
        //        creo el objeto que me permita trabajar con el ws
        //        MiServicio LEmpleado = new MiServicio();
        //        utilizo la operacion del ws
        //        string usuario = Controles.Logueo.
        //        string pass = 

        //        Empleado unEmpleado = new Empleado();
        //        unEmpleado.NomUsu = nombre;
        //        unEmpleado.Pass = pass;

        //        if (unEmpleado == null)
        //            lblMensaje.Text = "Usuario o Contraseña incorrectos";
        //        else
        //        {
        //            this.Hide();
        //            Form formu = new Default(unEmpleado);
        //            formu.ShowDialog();
        //            this.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblMensaje.Text = ex.Message;
        //    }
        }

        //private void Logueo_Load(object sender, EventArgs e)
        //{
        //    ccLog.Logueo += new EventHandler(IniciarSession);
        //    this.AcceptButton = this.Controles.Logueo.botonLogin;
        //}

        private void Login_Load(object sender, EventArgs e)
        {


            try
            {
                //empleado = FabricaLogica.getEmpleadoLogica().Log(this.ccLog.Usuario, this.ccLog.Contraseña);
                //creo el objeto que me permita trabajar con el ws
                //MiServicio LEmpleado = new MiServicio();
                //utilizo la operacion del ws
                //string usuario = Controles.Logueo.
                //string pass = 

                //Empleado unEmpleado = new Empleado();
                //unEmpleado.NomUsu = nombre;
                //unEmpleado.Pass = pass;

                //if (unEmpleado == null)
                //    lblMensaje.Text = "Usuario o Contraseña incorrectos";
                //else
                //{
                //    this.Hide();
                //    Form formu = new Default(unEmpleado);
                //    formu.ShowDialog();
                //    this.Close();
                //}
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        private void Logueo_Load(object sender, EventArgs e)
        {
            //ccLog.Logueo += new EventHandler(IniciarSession);
            //this.AcceptButton = this.Controles.Logueo.botonLogin;

        }
    }
}
