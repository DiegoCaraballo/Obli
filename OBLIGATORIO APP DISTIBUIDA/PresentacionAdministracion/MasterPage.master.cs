using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades_Compartidas;
using Logica;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Empleado emp = (Empleado)Session["UnEmpleado"];
        if (emp == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        else
        {
            lblUsuario.Text = emp.NomUsu;
        }
    }

    //Salir del sistema
    protected void lblLogout_Click(object sender, EventArgs e)
    {
        //Al salir borra la Session
        Session.RemoveAll();

        Response.Redirect("~/Default.aspx");
    }
}
