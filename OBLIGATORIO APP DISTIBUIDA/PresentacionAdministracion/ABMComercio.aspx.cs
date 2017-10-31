using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades_Compartidas;
using Logica;

public partial class ABMComercio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Zona> zonas = FabricaLogica.getZonaLogica().Listo();
        if (zonas.Count == 0)
        {
            EstadoInicial();
            txtPadron.Enabled = false;
            btnBuscar.Enabled = false;
            btnCancelar.Enabled = false;
            lblMensaje.Text = "No puede realizar acciones en esta pagina a menos que se cargue una zona";
        }
        else
        {
            if (!IsPostBack)
            {
                EstadoInicial();

                Limpiar();
            }
        }
    }

    //Desactiva los controles
    private void EstadoInicial()
    {
        btnAlta.Enabled = false;
        btnBaja.Enabled = false;
        btnModificar.Enabled = false;
        txtUsuario.Enabled = false;
        btnBuscaZona.Enabled = false;

        txtDireccion.Enabled = false;
        txtPrecio.Enabled = false;
        ddlAccion.Enabled = false;
        txtBanio.Enabled = false;
        txtHabitacion.Enabled = false;
        txtMt2C.Enabled = false;
        txtAbreviacion.Enabled = false;
        txtLetraDpto.Enabled = false;
        ddlHabilitado.Enabled = false;
    }

    //Limpia los controles
    private void Limpiar()
    {
        lblMensaje.Text = "";
        txtDireccion.Text = "";
        txtPrecio.Text = "";
        txtBanio.Text = "";
        txtHabitacion.Text = "";
        txtMt2C.Text = "";
        txtLetraDpto.Text = "";
        txtAbreviacion.Text = "";
        txtUsuario.Text = "";
        ddlAccion.ClearSelection();
        ddlHabilitado.ClearSelection();
        txtPadron.Enabled = true;
        btnBuscar.Enabled = true;
        txtPadron.Enabled = true;
        btnBuscar.Enabled = true;
   
    }

    //Habilita controles luego de buscar
    private void habilitarCampos()
    {
        btnAlta.Enabled = true;
        btnBuscar.Enabled = false;
        btnBaja.Enabled = true;
        btnModificar.Enabled = true;
        btnBuscaZona.Enabled = true;
        txtDireccion.Enabled = true;
        txtPrecio.Enabled = true;
        ddlAccion.Enabled = true;
        txtBanio.Enabled = true;
        txtHabitacion.Enabled = true;
        txtMt2C.Enabled = true;
        txtAbreviacion.Enabled = true;
        txtLetraDpto.Enabled = true;
        ddlHabilitado.Enabled = true;   
    }

    //Busca un Comercio
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtPadron.Text.Trim() == "")
                throw new Exception("Debe ingresar un padrón");
             Propiedad p = FabricaLogica.getPropiedadesLogica().BuscarPropiedad(Convert.ToInt32(txtPadron.Text));
             Session["Propiedad"] = p;

            if (p == null)
            {
                Limpiar();
                btnAlta.Enabled = true;
                btnBuscar.Enabled = false;
                btnBaja.Enabled = false;
                btnModificar.Enabled = false;
                btnBuscaZona.Enabled = true;
                txtDireccion.Enabled = true;
                txtPrecio.Enabled = true;
                ddlAccion.Enabled = true;
                txtBanio.Enabled = true;
                txtHabitacion.Enabled = true;
                txtMt2C.Enabled = true;
                txtAbreviacion.Enabled = true;
                txtLetraDpto.Enabled = true;
                ddlHabilitado.Enabled = true;
            }
            else
            {
             
                if (p is Comercio)
                {

                    habilitarCampos();
                    btnAlta.Enabled = false;
                    lblMensaje.Text = "";
                    txtPadron.Enabled = false;

                    txtPadron.Text = p.Padron.ToString();
                    txtDireccion.Text = p.Direccion.Trim().ToUpper();
                    txtPrecio.Text = p.Precio.ToString();
                    txtBanio.Text = p.Baño.ToString();
                    txtHabitacion.Text = p.Habitaciones.ToString();
                    txtMt2C.Text = p.Mt2Const.ToString();
                    txtLetraDpto.Text = p.Zona.LetraDpto.ToString();
                    txtAbreviacion.Text = p.Zona.Abreviacion.Trim().ToUpper();
                    txtUsuario.Text = p.UltimoEmp.NomUsu.Trim().ToUpper();
                    ddlAccion.SelectedValue = p.Accion.Trim().ToUpper();

                    string habilitado;
                    if (((Comercio)p).Habilitado == true)
                    {
                        habilitado = "SI";
                    }
                    else
                    {
                        habilitado = "NO";
                    }

                    ddlHabilitado.SelectedValue = habilitado.ToString().Trim().ToUpper();
            
                }
                else
                {
                    lblMensaje.Text = "El padron " + txtPadron.Text + ": no pertenece a un Comercio";
                }

            }
        }
        catch (FormatException)
        {
            lblMensaje.Text = "El padron debe tener formato numerico";
        }
        catch (OverflowException)
        {
            lblMensaje.Text = "El padron debe tener entre 1 y 9 digitos";
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
        }
    }

    //Altar un Comercio
    protected void btnAlta_Click(object sender, EventArgs e)
    {
        try
        {
            if ((Zona)Session["Zona"] != null)
            {
                bool habilitado = false;
                if (ddlHabilitado.SelectedItem.Value == "SI")
                {
                    habilitado = true;
                }
                else
                {
                    habilitado = false;
                }
                Comercio c = new Comercio(Convert.ToInt32(txtPadron.Text), txtDireccion.Text.Trim().ToUpper(), Convert.ToInt32(txtPrecio.Text), ddlAccion.SelectedItem.Value, Convert.ToInt32(txtBanio.Text), Convert.ToInt32(txtHabitacion.Text), Convert.ToDecimal(txtMt2C.Text), ((Zona)Session["Zona"]), ((Empleado)Session["UnEmpleado"]), habilitado);
                FabricaLogica.getPropiedadesLogica().AltaPropiedad(c);
                Limpiar();
                EstadoInicial();
                txtPadron.Text = "";
                lblMensaje.Text = "ALTA CON EXITO!!!";
            }
            else
            {
                lblMensaje.Text = "Debe buscar una zona previamente";
            }
        }
        catch (OverflowException)
        {
            lblMensaje.Text = "Los digitos en los campos Baño, Padron, Mt2, Precio y Piso no pueden superar los 9 digitos";
        }
        catch (FormatException)
        {
            lblMensaje.Text = "Revisar datos ingresados";
        }
        catch (Exception ex)
        {
            lblMensaje.Text = "ERROR EN DAR DE ALTA: " + ex.Message;
        }
    }

    //Eliminar Comercio
    protected void btnBaja_Click(object sender, EventArgs e)
    {
        try
        {
            Comercio c = (Comercio)Session["Propiedad"];
            FabricaLogica.getPropiedadesLogica().BajaPropiedad(c);
            Limpiar();
            EstadoInicial();
            lblMensaje.Text = "ELIMINACION EXITOSA!!!";
            txtPadron.Text = "";
        }
        catch (Exception ex)
        {
            lblMensaje.Text = "ERROR EN BAJA: " + ex.Message;
        }
    }

    //Modificar Comercio
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            bool habilitado = false;
            if (ddlHabilitado.SelectedItem.Value == "SI")
            {
                habilitado = true;
            }
            else
            {
                habilitado = false;
            }
            Comercio c = new Comercio(Convert.ToInt32(txtPadron.Text), txtDireccion.Text.Trim().ToUpper(), Convert.ToInt32(txtPrecio.Text), ddlAccion.SelectedItem.Value, Convert.ToInt32(txtBanio.Text), Convert.ToInt32(txtHabitacion.Text), Convert.ToDecimal(txtMt2C.Text), (FabricaLogica.getZonaLogica().BuscarZona(txtLetraDpto.Text.Trim().ToUpper(), txtAbreviacion.Text.Trim().ToUpper())), ((Empleado)Session["UnEmpleado"]), habilitado);
            FabricaLogica.getPropiedadesLogica().ModificaPropiedad(c);
            Limpiar();
            EstadoInicial();
            txtPadron.Text = "";
            lblMensaje.Text = "MIDIFICACION EXITOSA!!!";
        }
        catch (Exception ex)
        {
            lblMensaje.Text = "ERROR AL MODIFICAR: " + ex.Message;
        }
    }

    //Buscar Zona
    protected void btnBuscarZona_Click(object sender, EventArgs e)
    {
        try
        {
            Zona z = null;
            z = FabricaLogica.getZonaLogica().BuscarZona(txtLetraDpto.Text.Trim().ToUpper(), txtAbreviacion.Text.Trim().ToUpper());

            if (z != null)
            {
                txtLetraDpto.Text = z.LetraDpto.Trim().ToUpper();
                txtAbreviacion.Text = z.Abreviacion.Trim().ToUpper();
                Session["Zona"] = z;
                txtAbreviacion.Enabled = false;
                txtLetraDpto.Enabled = false;
                lblMensaje.Text = "ZONA CORRECTA!";
            }
            else
            { lblMensaje.Text = "No se encontro la zona: " + txtLetraDpto.Text.Trim().ToUpper() + " ," + txtAbreviacion.Text.Trim().ToUpper(); }
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
        }
    }

    //Cancelar Opciones
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Limpiar();
        EstadoInicial();
        txtPadron.Text = "";
    }
}