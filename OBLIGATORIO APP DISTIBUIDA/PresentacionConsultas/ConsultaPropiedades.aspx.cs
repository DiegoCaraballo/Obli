using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ServicioWeb;
using System.Drawing;

public partial class ConsultaPropiedades : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            MiServicio serv = new MiServicio();
            Propiedad p = ((Propiedad)Session["Propiedad"]);

            //Datos usados por todos los tipos de propiedad
            int padron = p.Padron;
            string direccion = p.Direccion;
            int precio = p.Precio;
            string accion = p.Accion;
            int banio = p.Baño;
            int habitaciones = p.Habitaciones;
            decimal mt2Const = p.Mt2Const;

            string letraDpto = p.Zona.LetraDpto;
            string abreviacion = p.Zona.Abreviacion;
            string nombre = p.Zona.Nombre;
            int cantHabitantes = p.Zona.CantHabitantes;
            // TODO - Al parecer es lo unico que queda de Servicios
            List<string> listaServiciosZona = new List<string>();//p.Zona.LosServicios.ToArray();

            if (p == null)
            {
                Response.Redirect("~/Default.aspx", false);
            }
            else
            {
                if (!IsPostBack)
                {
                    CargarFecha();

                    if (p is Casa)
                    {

                        decimal mt2Terreno = ((Casa)p).Mt2Terreno;
                        bool fondo = ((Casa)p).Fondo;
                        string tipoPropiedad = ((Casa)p).TipoPropiedad;
                        DatosPropiedad.DatosCasa(padron, direccion, precio, accion, banio, habitaciones, mt2Const, tipoPropiedad, letraDpto, abreviacion, nombre, cantHabitantes, listaServiciosZona, mt2Terreno, fondo);

                    }
                    else if (p is ServicioWeb.Comercio)
                    {

                        bool habilitado = ((Comercio)p).Habilitado;
                        string tipoPropiedad = ((Comercio)p).TipoPropiedad;
                        DatosPropiedad.DatosComercio(padron, direccion, precio, accion, banio, habitaciones, mt2Const, tipoPropiedad, letraDpto, abreviacion, nombre, cantHabitantes, listaServiciosZona, habilitado);


                    }
                    else
                    {
                        int piso = ((Apto)p).Piso;
                        bool ascensor = ((Apto)p).Ascensor;
                        string tipoPropiedad = ((Apto)p).TipoPropiedad;
                        DatosPropiedad.DatosApto(padron, direccion, precio, accion, banio, habitaciones, mt2Const, tipoPropiedad, letraDpto, abreviacion, nombre, cantHabitantes, listaServiciosZona, piso, ascensor);

                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


    #region Control de Fechas
    private void VerificoBisiesto()
    {
        try
        {
            int dia = Convert.ToInt32(ddlDia.SelectedItem.Value);
            int mes = Convert.ToInt32(ddlMes.SelectedItem.Value);
            int anio = Convert.ToInt32(ddlAnio.SelectedItem.Value);


            if ((DateTime.IsLeapYear(anio)) && mes == 2)
            {
                ddlDia.Items.Clear();

                for (int i = 1; i <= 29; i++)
                {
                    ddlDia.Items.Add(i.ToString());
                }
            }
            else if (!(DateTime.IsLeapYear(anio)) && mes == 2)
            {
                ddlDia.Items.Clear();
                for (int i = 1; i <= 28; i++)
                {
                    ddlDia.Items.Add(i.ToString());
                }
            }
            else if (mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12)
            {
                ddlDia.Items.Clear();
                for (int i = 1; i <= 31; i++)
                {
                    ddlDia.Items.Add(i.ToString());
                }
            }
            else
            {
                ddlDia.Items.Clear();
                for (int i = 1; i <= 30; i++)
                {
                    ddlDia.Items.Add(i.ToString());
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void ddlMes_SelectedIndexChanged(object sender, EventArgs e)
    {
        VerificoBisiesto();
    }

    protected void ddlAnio_SelectedIndexChanged(object sender, EventArgs e)
    {
        VerificoBisiesto();
    }

    public void CargarFecha()
    {
        try
        {
            //ddl Desde
            for (int i = 1; i <= 31; i++)
            {
                ddlDia.Items.Add(i.ToString());
            }
            for (int i = 1; i <= 12; i++)
            {
                ddlMes.Items.Add(i.ToString());
            }
            for (int i = DateTime.Now.Year; i <= DateTime.Now.Year + 1; i++)
            {
                ddlAnio.Items.Add(i.ToString());
            }
            for (int i = 8; i < 19; i++)
            {
                ddlHora.Items.Add(i.ToString());
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    #endregion

    //Limpia el formulario de visita
    public void limpiarVisita()
    {
        txtNombre.Text = "";
        txtTelefono.Text = "";
    }

    //Agendar una Visita
    protected void btnVisita_Click(object sender, EventArgs e)
    {
        try
        {
            MiServicio serv = new MiServicio();
            // lblError.BackColor = Color.White;
            lblError.Text = "";

            int dia = Convert.ToInt32(ddlDia.SelectedItem.Value);

            int mes = Convert.ToInt32(ddlMes.SelectedItem.Value);

            int anio = Convert.ToInt32(ddlAnio.SelectedItem.Value);

            int hora = Convert.ToInt32(ddlHora.SelectedItem.Value);

            Propiedad p = ((Propiedad)Session["Propiedad"]);
            DateTime fecha = new DateTime(anio, mes, dia, hora, 0, 0);

            if (fecha < DateTime.Now)
                throw new Exception("La fecha de visita no puede ser menor a la fecha actual");

            int telefono = Convert.ToInt32(txtTelefono.Text);
            string nombre = txtNombre.Text;

            Visita v = new Visita();
            v.Fecha = fecha;
            v.Telefono = telefono.ToString();
            v.Nombre = nombre;
            v.AVisitar = p;
            serv.AltaVisita(v);

            //Si llego acá la visita se agendó
            //  lblError.BackColor = Color.LightGreen;
            lblError.Text = "Visita agendada con éxito";
            limpiarVisita();
        }
        catch (System.Web.Services.Protocols.SoapException ex)
        {
            if (ex.Detail.InnerText.Length > 40)
                lblError.Text = ex.Detail.InnerText.Substring(0, 40);
            else
                lblError.Text = ex.Detail.InnerText;
        }
        catch (FormatException)
        {
            lblError.Text = "El telefono debe tener formato numérico";
        }
        catch (Exception ex)
        {
            // lblError.BackColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }

    //Vuelve a la pantalla de las propiedades
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx", false);
    }
}