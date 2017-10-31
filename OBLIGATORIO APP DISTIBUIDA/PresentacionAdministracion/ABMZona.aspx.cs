using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades_Compartidas;
using Logica;

public partial class ABMZona : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //si es el primer ingreso a la pagina
        if (!IsPostBack)
        {
            EstadoInicial();
        }
    }

    //Limpiar campos
    public void LimpiarCampos()
    {
        txtCantHab.Text = "";
        txtNombre.Text = "";
        txtServicios.Text = "";
        lbServicios.Items.Clear();
    }

    // Deja todo en estado Inicial
    public void EstadoInicial()
    {
        btnBuscar.Enabled = true;
        LimpiarCampos();
        txtCodigo.Enabled = true;
        txtCodigo.Text = "";
        ddlDepartamento.SelectedIndex = 0;
        btnBuscar.Enabled = true;
        btnIngresar.Enabled = false;
        btnEliminar.Enabled = false;
        btnModificar.Enabled = false;
        btnAgregar.Enabled = false;
        txtCodigo.Enabled = true;
        txtNombre.Enabled = false;
        txtServicios.Enabled = false;
        txtCantHab.Enabled = false;
        ddlDepartamento.Enabled = true;
    }

    //Boton que agrega servicios al ListBox
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtServicios.Text.Trim().ToUpper() != "")
            {

                lblError.Text = "";

                foreach (var servicio in lbServicios.Items)
                {
                    if (servicio.ToString().Trim().ToUpper() == txtServicios.Text.Trim().ToUpper())
                    {
                        throw new Exception("El servicio ya fue ingresado");
                    }
                }
                lbServicios.Items.Add(new ListItem(txtServicios.Text.Trim().ToUpper()));
                txtServicios.Text = "";
            }
            else
            {
                lblError.Text = "El servicio no puede ser vacío";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    //Boton Cancelar deja todo en estado inicial
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        try
        {
            EstadoInicial();
            lblError.Text = "";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    //Botón que busca Zona
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            lblError.Text = "";
            if (txtCodigo.Text.Trim() == "")
                throw new Exception("Debe ingresar un código");

            Zona unaZona = FabricaLogica.getZonaLogica().BuscarZona(ddlDepartamento.SelectedValue, txtCodigo.Text.Trim());
            Session["Zona"] = unaZona;

            if (unaZona == null)
            {
                btnBuscar.Enabled = false;
                LimpiarCampos();
                btnIngresar.Enabled = true;
                btnAgregar.Enabled = true;
                txtServicios.Enabled = true;
                txtNombre.Enabled = true;
                txtCantHab.Enabled = true;
               
            }
            else
            {
                ddlDepartamento.Enabled = false;
                txtCodigo.Enabled = false;
                btnIngresar.Enabled = false;
                btnAgregar.Enabled = true;
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;
                txtNombre.Enabled = true;
                txtServicios.Enabled = true;
                txtCantHab.Enabled = true;
                
                
                txtNombre.Text = unaZona.Nombre;
                txtCantHab.Text = unaZona.CantHabitantes.ToString();
                lbServicios.DataSource = unaZona.LosServicios;
                lbServicios.DataTextField = "Servicios";
                lbServicios.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    //Boton que borra servicios del ListBox
    protected void btnBorrarServicio_Click(object sender, EventArgs e)
    {
        try
        {
            //determino si hay una linea de la lista seleccionada
            if (lbServicios.SelectedIndex >= 0)
            {
                lbServicios.Items.RemoveAt(lbServicios.SelectedIndex);
                lblError.Text = "";
            }
            else
            {
                lblError.Text = "Debe seleccionar un Servicio de la lista para eliminar";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    //Ingresar Zona con Servicios
    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        try
        {
            //Creo la zona para dar el alta
            string letraDpto = ddlDepartamento.SelectedValue;
            string abreviacion = txtCodigo.Text.Trim().ToUpper();
            string nombre = txtNombre.Text.Trim().ToUpper();
            int cantHabitantes = Convert.ToInt32(txtCantHab.Text);
            Zona unaZona = new Zona(letraDpto, abreviacion, nombre, cantHabitantes);
            foreach (ListItem s in lbServicios.Items)
            {
                unaZona.AgregarServicio(s.Text.Trim());
            }

            FabricaLogica.getZonaLogica().AgregarZona(unaZona);

            //Si llego acá es porque no hubo errores
            lblError.Text = "Alta con éxito";
            EstadoInicial();

        }
        catch (FormatException)
        {
            lblError.Text = "Ingrese un número positivo para la cantidad de habitantes";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    //Modificar Zona
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            Zona unaZona = (Zona)Session["Zona"];
            unaZona.Nombre = txtNombre.Text.Trim().ToUpper();
            unaZona.CantHabitantes = Convert.ToInt32(txtCantHab.Text);
            unaZona.EliminarTodosLosServicios();

            foreach (ListItem s in lbServicios.Items)
            {
                unaZona.AgregarServicio(s.Text.Trim());
            }

            FabricaLogica.getZonaLogica().ModificarZona(unaZona);

            //Si llego acá es porque no hubo errores
            lblError.Text = "Modificación con éxito";
            EstadoInicial();

        }
        catch (FormatException)
        {
            lblError.Text = "Ingrese un número positivo para la cantidad de habitantes";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    //Eliminar Zona
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Zona unaZona = (Zona)Session["Zona"];
            FabricaLogica.getZonaLogica().EliminarZona(unaZona);

            //Si llego acá es porque no hubo errores
            lblError.Text = "Baja exitosa";
            EstadoInicial();
        }
        catch(Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}