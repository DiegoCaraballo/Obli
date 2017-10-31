using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades_Compartidas;
using Logica;

public partial class ABMEmpleado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            EstadoInicial();
        }
    }
  
    //Deja todo en estado Inicial
    public void EstadoInicial()
    {
        txtUsuario.Text = "";
        txtPass.Text = "";
        txtPass.Enabled = false;
        btnEliminar.Enabled = false;
        btnModificar.Enabled = false;
        btnIngresar.Enabled = false;
        btnBuscar.Enabled = true;
        txtUsuario.Enabled = true;
    
    }

    //Busca empleado y si no encuentra lo habilita para ingresar
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            LblError.Text = "";

            if (txtUsuario.Text.Trim() == "" || txtUsuario.Text.Trim().Length > 20 || txtUsuario.Text.Trim().Length < 4)
            {
                throw new Exception("El usuario debe tener entre 4 y 20 caracteres");
            }
            else
            {
                Empleado unEmpleado = FabricaLogica.getEmpleadoLogica().BuscarEmpleado(txtUsuario.Text.Trim());
                Session["Empleado"] = unEmpleado;

                if (unEmpleado == null)
                {
                    btnIngresar.Enabled = true;
                    txtPass.Enabled = true;
                }
                else
                {
                    txtUsuario.Enabled = false;
                    btnIngresar.Enabled = false;
                    btnEliminar.Enabled = true;
                    btnModificar.Enabled = true;
                    txtPass.Enabled = true;

                    txtUsuario.Text = unEmpleado.NomUsu;
                    txtPass.Text = unEmpleado.Pass;
                }
            }                    
        }

        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    //Deja todo en estado Inicial
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        EstadoInicial();
        LblError.Text = "";
    }

    //Ingreso de Empleado
    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        try
        {
            //Creo el Empleado
            string nombre = txtUsuario.Text.Trim().ToUpper();
            string pass = txtPass.Text;

            Empleado unEmpleado = new Empleado(nombre, pass);
            FabricaLogica.getEmpleadoLogica().AgregarEmpleado(unEmpleado);

            //Si llego acá es porque no hubo errores
            LblError.Text = "Alta con éxito";
            EstadoInicial();
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    //Modificacion de empleado
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            Empleado unEmpleado = (Empleado)Session["Empleado"];
            unEmpleado.Pass = txtPass.Text;

            FabricaLogica.getEmpleadoLogica().ModificarEmpleado(unEmpleado);

            //Si llego acá es porque no hubo errores
            LblError.Text = "Modificación con éxito";
            EstadoInicial();
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    //Eliminar Empleado
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Empleado unEmpleado = (Empleado)Session["Empleado"];
            Empleado empLogueado = (Empleado)Session["UnEmpleado"];

            if (txtUsuario.Text.Trim().ToUpper() == empLogueado.NomUsu)
            {
                throw new Exception("No puede eliminar al usuario logueado");
            }
            else
            {
                FabricaLogica.getEmpleadoLogica().EliminarEmpleado(unEmpleado);

                //Si llego acá es porque no hubo errores
                LblError.Text = "Baja exitosa";
                EstadoInicial();
            }
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }
}