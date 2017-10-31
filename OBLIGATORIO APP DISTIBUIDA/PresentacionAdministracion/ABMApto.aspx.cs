using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades_Compartidas;
using Logica;

public partial class ABMApto : System.Web.UI.Page
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

    //Desactivar Botones
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
        txtPiso.Enabled = false;
        ddlAscensor.Enabled = false;
        txtPadron.Enabled = true;
    }

    //Limpiar controles
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
        txtPiso.Text = "";
        ddlAccion.ClearSelection();
        ddlAscensor.ClearSelection();
        txtPadron.Enabled = true;
        btnBuscar.Enabled = true;

        btnBuscar.Enabled = true;
   
    }
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
        txtPiso.Enabled = true;
        ddlAscensor.Enabled = true;
    }
    //Buscar un Apartamento
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
                txtPiso.Enabled = true;
                ddlAscensor.Enabled = true;
            }
            else
            {

                if (p is Apto)
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
                    txtLetraDpto.Text = p.Zona.LetraDpto.ToString().Trim().ToUpper();
                    txtAbreviacion.Text = p.Zona.Abreviacion.Trim().ToUpper();
                    txtUsuario.Text = p.UltimoEmp.NomUsu.Trim().ToUpper();
                    txtPiso.Text = ((Apto)p).Piso.ToString();

                    ddlAccion.SelectedValue = p.Accion.Trim().ToUpper();

                    string ascensor;
                    if (((Apto)p).Ascensor == true)
                    {
                        ascensor = "SI";
                    }
                    else
                    {
                        ascensor = "NO";
                    }
                    ddlAscensor.SelectedValue = ascensor.ToString().Trim().ToUpper();
                }
                else
                {
                    lblMensaje.Text = "El padrón " + txtPadron.Text + " : no pertenece a un Apartamento";
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

    //Ingreso de un Apartamento
    protected void btnAlta_Click(object sender, EventArgs e)
    {
        try
        {
            if ((Zona)Session["Zona"] != null)
            {
                bool ascen = false;
                if (ddlAscensor.SelectedItem.Value == "SI")
                {
                    ascen = true;
                }
                else
                {
                    ascen = false;
                }
                Apto a = new Apto(Convert.ToInt32(txtPadron.Text), txtDireccion.Text.Trim().ToUpper(), Convert.ToInt32(txtPrecio.Text), ddlAccion.SelectedItem.Value.Trim().ToUpper(), Convert.ToInt32(txtBanio.Text),
                                  Convert.ToInt32(txtHabitacion.Text), Convert.ToDecimal(txtMt2C.Text), ((Zona)Session["Zona"]), ((Empleado)Session["UnEmpleado"]), Convert.ToInt32(txtPiso.Text), ascen);
                FabricaLogica.getPropiedadesLogica().AltaPropiedad(a);
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

    //Buscar Zona
    protected void btnBuscaZona_Click(object sender, EventArgs e)
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

    //Cancela opciones
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        txtPadron.Text = "";
        Limpiar();
        EstadoInicial();
    }

    //Eliminar Apartamento
    protected void btnBaja_Click(object sender, EventArgs e)
    {
        try
        {
            Apto p = (Apto)Session["Propiedad"];
            FabricaLogica.getPropiedadesLogica().BajaPropiedad(p);
           
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

    //Modifivar Apartamento
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            bool ascen = false;
            if (ddlAscensor.SelectedItem.Value == "SI")
            {
                ascen = true;
            }
            else
            {
                ascen = false;
            }
            Apto a = new Apto(Convert.ToInt32(txtPadron.Text), txtDireccion.Text.Trim().ToUpper(), Convert.ToInt32(txtPrecio.Text), ddlAccion.SelectedItem.Value, Convert.ToInt32(txtBanio.Text), Convert.ToInt32(txtHabitacion.Text), Convert.ToDecimal(txtMt2C.Text), (FabricaLogica.getZonaLogica().BuscarZona(txtLetraDpto.Text.Trim().ToUpper(), txtAbreviacion.Text.Trim().ToUpper())), ((Empleado)Session["UnEmpleado"]), Convert.ToInt32(txtPiso.Text), ascen);
            FabricaLogica.getPropiedadesLogica().ModificaPropiedad(a);
            
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
}