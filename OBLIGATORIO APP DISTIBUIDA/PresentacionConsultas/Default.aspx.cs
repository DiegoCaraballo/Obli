using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ServicioWeb;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                CargaLista();
                ddlZona.Items.Add("--Seleccione Opción--");
            }
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }

    //Limpia los filtros de búsqueda
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        try
        {
            ddlAccion.SelectedIndex = 0;
            ddlDepartamento.SelectedIndex = 0;
            ddlPrecio.SelectedIndex = 0;
            ddlProp.SelectedIndex = 0;
            ddlZona.Items.Clear();
            ddlZona.Items.Add("--Seleccione Opción--");
            List<Propiedad> listaCompleta = (List<Propiedad>)Session["ListaPropiedades"];
            rpPropiedades.DataSource = listaCompleta;
            rpPropiedades.DataBind();
            lblCount.Text = "Mostrando " + rpPropiedades.Items.Count + " resultados";
        }
        catch (Exception)
        {
            throw new Exception();
        }
    }

    //Funcionalidad Mostrar dentro del Repeater
    protected void rpPropiedades_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Mostrar")
            {
                try
                {

                    MiServicio serv = new MiServicio();

                    int padron = Convert.ToInt32(((Label)e.Item.FindControl("lblPadron")).Text);
                    Propiedad p = serv.BuscarPropiedad(padron);
                    Session["Propiedad"] = p;
                    Response.Redirect("ConsultaPropiedades.aspx", false);

                }
                catch (System.Web.Services.Protocols.SoapException ex)
                {
                    if (ex.Detail.InnerText.Length > 80)
                        lblError.Text = ex.Detail.InnerText.Substring(0, 80);
                    else
                        lblError.Text = ex.Detail.InnerText;
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    //Filtros de Busqueda
    protected void btnFiltrar_Click(object sender, EventArgs e)
    {
        try
        {
            lblError.Text = "";

            List<Propiedad> listaCompleta = (List<Propiedad>)Session["ListaPropiedades"];

            //Aplicando filtro
            if (ddlAccion.SelectedIndex != 0)
            {
                //Ingresa si selecciono una Acción
                lblError.Text = "";

                List<Propiedad> listaFiltrada = (from p in listaCompleta
                                                 where
                                                 p.Accion == ddlAccion.SelectedItem.Value.ToString()
                                                 select p).ToList<Propiedad>();


                //Ingresa si seleccionó una Propiedad
                if (ddlProp.SelectedIndex != 0)
                {
                    //TODO
                    List<Propiedad> listaFiltroPropiedad = (from p in listaFiltrada
                                                            where
                                                              p.TipoPropiedad == ddlProp.SelectedItem.Value.ToString()
                                                            select p).ToList<Propiedad>();

                    listaFiltrada = listaFiltroPropiedad.ToList();

                }

                //Ingresa si seleccionó un Departamento
                if (ddlDepartamento.SelectedIndex != 0)
                {

                    List<Propiedad> listaFiltroZona = (from p in listaFiltrada
                                                       where
                                                       p.Zona.LetraDpto == ddlDepartamento.SelectedItem.Value.ToString()
                                                       &&
                                                       p.Zona.Abreviacion == ddlZona.SelectedItem.Value.ToString()
                                                       select p).ToList<Propiedad>();

                    listaFiltrada = listaFiltroZona.ToList();
                }

                //Ingresa si selecciono un Precio
                if (ddlPrecio.SelectedIndex != 0)
                {
                    int precioMin;
                    int precioMax;
                    if (ddlPrecio.SelectedIndex == 1)
                    {
                        precioMin = 0;
                        precioMax = 4999;
                    }
                    else if (ddlPrecio.SelectedIndex == 2)
                    {
                        precioMin = 5000;
                        precioMax = 9999;
                    }
                    else if (ddlPrecio.SelectedIndex == 3)
                    {
                        precioMin = 10000;
                        precioMax = 14999;
                    }
                    else if (ddlPrecio.SelectedIndex == 4)
                    {
                        precioMin = 15000;
                        precioMax = 19999;
                    }
                    else if (ddlPrecio.SelectedIndex == 5)
                    {
                        precioMin = 20000;
                        precioMax = 99999999;
                    }
                    else
                    {
                        precioMin = 0;
                        precioMax = 99999999;
                    }
                    List<Propiedad> listaFiltroPrecio = (from p in listaFiltrada
                                                         where
                                                         p.Precio >= precioMin && p.Precio <= precioMax
                                                         select p).ToList<Propiedad>();

                    listaFiltrada = listaFiltroPrecio.ToList();
                }

                //Actualiza los resultados
                rpPropiedades.DataSource = listaFiltrada;
                rpPropiedades.DataBind();
                if (rpPropiedades.Items.Count == 0)
                {
                    lblCount.Text = "No hay resultados para el filtro aplicado";
                }
                else
                {
                    lblCount.Text = "Mostrando " + rpPropiedades.Items.Count + " resultados";
                }
            }

            else
            {
                lblError.Text = "Debe seleccionar una acción";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = "Error: " + ex.Message;
        }
    }

    //Carga la lista de propiedades en el repeater
    protected void CargaLista()
    {
        try
        {

            MiServicio serv = new MiServicio();

            Session["ListaPropiedades"] = (List<Propiedad>)serv.ListarPropiedades().ToList();
            rpPropiedades.DataSource = Session["ListaPropiedades"];
            rpPropiedades.DataBind();
            if (rpPropiedades.Items.Count == 0)
            {
                lblCount.Text = "No hay resultados para el filtro aplicado";
            }
            else
            {
                lblCount.Text = "Mostrando " + rpPropiedades.Items.Count + " resultados";
            }
        }
        catch (System.Web.Services.Protocols.SoapException ex)
        {
            if (ex.Detail.InnerText.Length > 80)
                lblError.Text = ex.Detail.InnerText.Substring(0, 80);
            else
                lblError.Text = ex.Detail.InnerText;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    //Se cargan las Zonas según el departamento seleccionado
    protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //borro ddl NombreZonas
            ddlZona.Items.Clear();

            MiServicio serv = new MiServicio();

            string _letraDpto = ddlDepartamento.SelectedItem.Value;
            List<Zona> zonas = serv.ListoPorDpto(_letraDpto).ToList(); 
            int c = 0;
            foreach (Zona z in zonas)
            {
                c++;
                ddlZona.Items.Add(z.Nombre.ToString());

                ddlZona.SelectedIndex = c - 1;
                ddlZona.SelectedItem.Value = (z.Abreviacion.ToString());
            }
        }
        catch (System.Web.Services.Protocols.SoapException ex)
        {
            if (ex.Detail.InnerText.Length > 80)
                lblError.Text = ex.Detail.InnerText.Substring(0, 80);
            else
                lblError.Text = ex.Detail.InnerText;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}