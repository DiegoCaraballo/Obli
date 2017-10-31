using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades_Compartidas;
using Logica;

public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtUsuario.Focus();
    }

    #region Boton Cancelar
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        //Método del botón Cancelar, limpia los campos
        try
        {
            txtUsuario.Text = "";
            txtPass.Text = "";
            LblError.Text = "";
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }
    #endregion

    #region Boton Ingresar
    //Botón que hace el login del usuario
    protected void btnIngresar_Click(object sender, EventArgs e)
    {

        try
        {
            string NomUsu;
            NomUsu = txtUsuario.Text.Trim().ToUpper();

            if (NomUsu.Length > 20 || NomUsu.Length == 0)
                throw new Exception("El nombre de usuario debe tener entre 4 y 20 caracteres");

            Empleado emp = FabricaLogica.getEmpleadoLogica().BuscarEmpleado(txtUsuario.Text.Trim().ToUpper());

            if (emp.Pass == txtPass.Text.Trim().ToUpper())
            {
                Session["UnEmpleado"] = emp;
                Response.Redirect("~/Principal.aspx", true);
            }
            else
            {
                LblError.Text = "Usuario o Contraseña incorrectos";
            }
        }

        catch (Exception ex)
        {
            LblError.Text = ex.Message;

        }
    #endregion

    }
}
