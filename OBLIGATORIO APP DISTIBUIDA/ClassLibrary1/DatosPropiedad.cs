using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;

using ControlesWeb.ServicioWeb;

namespace ControlesWeb
{
    public class DatosPropiedad : WebControl, INamingContainer
    {
        //Controles para mostrar datos de Propiedades 
        private Label lblPadron;
        private Label lblDireccion;
        private Label lblPrecio;
        private Label lblAccion;
        private Label lblBaño;
        private Label lblHabitaciones;
        private Label lblMt2Const;
        private Label lblTipoPropiedad;

        //Controles para mostrar datos de Propiedades de Tipo Casa
        private Label lblFondo;
        private Label lblMt2Terreno;

        //Controles para mostrar datos de Propiedades de tipo Apartamento
        private Label lblPiso;
        private Label lblAscensor;

        //Controles para mostrar datos de Propiedades de tipo Comercio
        private Label lblHabilitado;

        public bool habilitacion;
        //Controles para mostrar datos de Zona
        private Label lblLetraDpto;
        private Label lblAbreviacion;
        private Label lblNombre;
        private Label lblCantHabitantes;
        private List<string> listaServicios;
        private ListBox lbServicios;

        private Panel UnPanel;

        public void DatosCasa(int pPadron, string pDireccion, int pPrecio, string pAccion, int pBanio, int pHabitaciones, decimal pMt2Const, string pTipoPropiedad, string pLetraDpto, string pAbreviacion, string pZonaNombre, int pCantHabitantes, List<string> pLosServicios, decimal pMt2Terreno, bool pFondo)
        {
            try
            {
                EnsureChildControls();
          
                lblPadron.Text = pPadron.ToString();
                lblDireccion.Text = pDireccion;
                lblPrecio.Text = pPrecio.ToString();
                lblAccion.Text = pAccion;
                lblBaño.Text = pBanio.ToString();
                lblHabitaciones.Text = pHabitaciones.ToString();
                lblMt2Const.Text = pMt2Const.ToString();
                lblTipoPropiedad.Text = pTipoPropiedad;

                string fondo;
                if (pFondo == true)
                    fondo = "SI";
                else
                    fondo = "NO";

                lblFondo.Text = fondo;
                lblMt2Terreno.Text = pMt2Terreno.ToString();

                lblLetraDpto.Text = pLetraDpto;
                lblAbreviacion.Text = pAbreviacion;
                lblNombre.Text = pZonaNombre;
                lblCantHabitantes.Text = pCantHabitantes.ToString();

                lbServicios.DataSource = pLosServicios;
                lbServicios.DataBind();

                //Datos que no pertenecen a este tipo de propiedad
                lblPiso.Text = "NO CORRESPONDE";
                lblAscensor.Text = "NO CORRESPONDE";

                lblHabilitado.Text = "NO CORRESPONDE";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DatosComercio(int pPadron, string pDireccion, int pPrecio, string pAccion, int pBanio, int pHabitaciones, decimal pMt2Const, string pTipoPropiedad, string pLetraDpto, string pAbreviacion, string pZonaNombre, int pCantHabitantes, List<string> pLosServicios,  bool pHabilitado)
        {
            try
            {
                EnsureChildControls();

                lblPadron.Text = pPadron.ToString();
                lblDireccion.Text = pDireccion;
                lblPrecio.Text = pPrecio.ToString();
                lblAccion.Text = pAccion;
                lblBaño.Text = pBanio.ToString();
                lblHabitaciones.Text = pHabitaciones.ToString();
                lblMt2Const.Text = pMt2Const.ToString();
                lblTipoPropiedad.Text = pTipoPropiedad;

                string habilitado;
                if (pHabilitado == true)
                    habilitado = "SI";
                else
                    habilitado = "NO";

                lblHabilitado.Text = habilitado;

                lblLetraDpto.Text = pLetraDpto;
                lblAbreviacion.Text = pAbreviacion;
                lblNombre.Text = pZonaNombre;
                lblCantHabitantes.Text = pCantHabitantes.ToString();

                lbServicios.DataSource = pLosServicios;
                lbServicios.DataBind();

                //Datos que no pertenecen a este tipo de propiedad
                lblPiso.Text = "NO CORRESPONDE";
                lblAscensor.Text = "NO CORRESPONDE";

                lblMt2Terreno.Text = "NO CORRESPONDE";
                lblFondo.Text = "NO CORRESPONDE";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void DatosApto(int pPadron, string pDireccion, int pPrecio, string pAccion, int pBanio, int pHabitaciones, decimal pMt2Const, string pTipoPropiedad, string pLetraDpto, string pAbreviacion, string pZonaNombre, int pCantHabitantes, List<string> pLosServicios, int pPiso, bool pAscensor)
        {
            try
            {
                EnsureChildControls();
                lblPadron.Text = pPadron.ToString();
                lblDireccion.Text = pDireccion;
                lblPrecio.Text = pPrecio.ToString();
                lblAccion.Text = pAccion;
                lblBaño.Text = pBanio.ToString();
                lblHabitaciones.Text = pHabitaciones.ToString();
                lblMt2Const.Text = pMt2Const.ToString();
                lblTipoPropiedad.Text = pTipoPropiedad;

                string ascensor;
                if (pAscensor == true)
                    ascensor = "SI";
                else
                    ascensor = "NO";

                lblAscensor.Text = ascensor;
                lblPiso.Text = pPiso.ToString();

                lblLetraDpto.Text = pLetraDpto;
                lblAbreviacion.Text = pAbreviacion;
                lblNombre.Text = pZonaNombre;
                lblCantHabitantes.Text = pCantHabitantes.ToString();


                lbServicios.DataSource = pLosServicios;
                lbServicios.DataBind();

                //Datos que no pertenecen a este tipo de propiedad
                lblMt2Terreno.Text = "NO CORRESPONDE";
                lblFondo.Text = "NO CORRESPONDE";

                lblHabilitado.Text = "NO CORRESPONDE";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            //creacion del Panel donde se insertaran los controles
            UnPanel = new Panel();

            UnPanel.Controls.Add(new LiteralControl("<table>"));

            UnPanel.Controls.Add(new LiteralControl("<tr><td><b>TIPO DE PROPIEDAD:</b> "));
            lblTipoPropiedad = new Label();
            UnPanel.Controls.Add(lblTipoPropiedad);

            UnPanel.Controls.Add(new LiteralControl("</tr><tr><td><b>PADRON:</b> "));
            lblPadron = new Label();
            UnPanel.Controls.Add(lblPadron);

            UnPanel.Controls.Add(new LiteralControl("</tr><tr><td><b>DIRECCION:</b> "));
            lblDireccion = new Label();
            UnPanel.Controls.Add(lblDireccion);

            UnPanel.Controls.Add(new LiteralControl("</tr><tr><td><b>PRECIO:</b> "));
            lblPrecio = new Label();
            UnPanel.Controls.Add(lblPrecio);

            UnPanel.Controls.Add(new LiteralControl("</tr><tr><td><b>ACCION:</b> "));
            lblAccion = new Label();
            UnPanel.Controls.Add(lblAccion);

            UnPanel.Controls.Add(new LiteralControl("</tr><tr><td><b>BAÑOS:</b> "));
            lblBaño = new Label();
            UnPanel.Controls.Add(lblBaño);

            UnPanel.Controls.Add(new LiteralControl("</tr><tr><td><b>HABITACIONES:</b> "));
            lblHabitaciones = new Label();
            UnPanel.Controls.Add(lblHabitaciones);

            UnPanel.Controls.Add(new LiteralControl("</tr><tr><td><b>MT2(CONST):</b> "));
            lblMt2Const = new Label();
            UnPanel.Controls.Add(lblMt2Const);

            UnPanel.Controls.Add(new LiteralControl("</tr><tr><td><b>PISO Nº:</b> "));
            lblPiso = new Label();
            UnPanel.Controls.Add(lblPiso);

            UnPanel.Controls.Add(new LiteralControl("</tr><tr><td><b>ASCENSOR:</b> "));
            lblAscensor = new Label();
            UnPanel.Controls.Add(lblAscensor);

            UnPanel.Controls.Add(new LiteralControl("</tr><tr><td><b>MT2(TERR):</b> "));
            lblMt2Terreno = new Label();
            UnPanel.Controls.Add(lblMt2Terreno);

            UnPanel.Controls.Add(new LiteralControl("</tr><tr><td><b>FONDO:</b> "));
            lblFondo = new Label();
            UnPanel.Controls.Add(lblFondo);

            UnPanel.Controls.Add(new LiteralControl("</tr><tr><td><b>HABILITADO:</b> "));
            lblHabilitado = new Label();
            UnPanel.Controls.Add(lblHabilitado);

            UnPanel.Controls.Add(new LiteralControl("</tr><tr><td><b>DPTO:</b> "));
            lblLetraDpto = new Label();
            UnPanel.Controls.Add(lblLetraDpto);


            UnPanel.Controls.Add(new LiteralControl("</tr><tr><td><b>ABREVIACION:</b> "));
            lblAbreviacion = new Label();
            UnPanel.Controls.Add(lblAbreviacion);


            UnPanel.Controls.Add(new LiteralControl("</tr><tr><td><b>NOMBRE ZONA:</b> "));
            lblNombre = new Label();
            UnPanel.Controls.Add(lblNombre);


            UnPanel.Controls.Add(new LiteralControl("</tr><tr><td><b>HABITANTES:</b> "));
            lblCantHabitantes = new Label();
            UnPanel.Controls.Add(lblCantHabitantes);


            UnPanel.Controls.Add(new LiteralControl("</tr><tr><td><b>SERVICIOS:</b> "));
            lbServicios = new ListBox();
            UnPanel.Controls.Add(lbServicios);
            UnPanel.Controls.Add(new LiteralControl("</td></tr>"));

            UnPanel.Controls.Add(new LiteralControl("</table>"));

            this.Controls.Add(UnPanel);
        }

        //Metodo que carga la lista de servicios de la zona
        private void ListaServiciosZona(Propiedad p)
        {
            // TODO - REVISAR QUE FUNCIONE
            if (p.Zona.LosServicios.ToList().Count != 0)
            {
                foreach (Servicio s in p.Zona.LosServicios)
                {
                    lbServicios.Items.Add(s.Servicios.ToString());
                }
            }
            else
            {
                lbServicios.Items.Add("La zona no cuenta con servicios a destacar");
            }

        }
    }

}