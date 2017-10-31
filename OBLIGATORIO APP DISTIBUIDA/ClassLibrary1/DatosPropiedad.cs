using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using Entidades_Compartidas;

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

        //Controles para mostrar datos de Zona
        private Label lblLetraDpto;
        private Label lblAbreviacion;
        private Label lblNombre;
        private Label lblCantHabitantes;
        private List<string> listaServicios;
        private ListBox lbServicios;

        private Panel UnPanel;

        #region Propiedades

        //Propiedad que recibe una Casa y carga los datos en los controles
        public Casa DatosCasa
        {
            set
            {
                EnsureChildControls();

                Casa c = value;

                lblPadron.Text = c.Padron.ToString();
                lblDireccion.Text = c.Direccion;
                lblPrecio.Text = c.Precio.ToString();
                lblAccion.Text = c.Accion;
                lblBaño.Text = c.Baño.ToString();
                lblHabitaciones.Text = c.Habitaciones.ToString();
                lblMt2Const.Text = c.Mt2Const.ToString();
                lblTipoPropiedad.Text = c.TipoPropiedad;

                string fondo;

                if (c.Fondo == true)
                {
                    fondo = "SI";
                }
                else
                {
                    fondo = "NO";
                }

                lblFondo.Text = fondo;
                lblMt2Terreno.Text = c.Mt2Terreno.ToString();

                lblLetraDpto.Text = (c.Zona.LetraDpto).ToUpper();
                lblAbreviacion.Text = c.Zona.Abreviacion.ToString();
                lblNombre.Text = c.Zona.Nombre;
                lblCantHabitantes.Text = c.Zona.CantHabitantes.ToString();
                ListaServiciosZona(c);

                lbServicios.DataSource = listaServicios;
                lbServicios.DataBind();

                //Datos que no pertenecen a este tipo de propiedad
                lblPiso.Text = "NO CORRESPONDE";
                lblAscensor.Text = "NO CORRESPONDE";

                lblHabilitado.Text = "NO CORRESPONDE";
            }
        }

        //Propiedad que recibe un Apto y carga los datos en los controles
        public Apto DatosApto
        {
            set
            {
                EnsureChildControls();

                Apto a = value;

                lblPadron.Text = a.Padron.ToString();
                lblDireccion.Text = a.Direccion;
                lblPrecio.Text = a.Precio.ToString();
                lblAccion.Text = a.Accion;
                lblBaño.Text = a.Baño.ToString();
                lblMt2Const.Text = a.Mt2Const.ToString();
                lblHabitaciones.Text = a.Habitaciones.ToString();
                lblTipoPropiedad.Text = a.TipoPropiedad;

                string ascensor;
                if (a.Ascensor == true)
                {
                    ascensor = "SI";
                }
                else
                {
                    ascensor = "NO";
                }

                lblPiso.Text = a.Piso.ToString();
                lblAscensor.Text = ascensor;

                lblLetraDpto.Text = (a.Zona.LetraDpto).ToUpper();
                lblAbreviacion.Text = a.Zona.Abreviacion.ToString();
                lblNombre.Text = a.Zona.Nombre;
                lblCantHabitantes.Text = a.Zona.CantHabitantes.ToString();
                ListaServiciosZona(a);

                lbServicios.DataSource = listaServicios;
                lbServicios.DataBind();

                //Datos que no pertenecen a este tipo de propiedad
                lblFondo.Text = "NO CORRESPONDE";
                lblMt2Terreno.Text = "NO CORRESPONDE";

                lblHabilitado.Text = "NO CORRESPONDE";
            }
        }

        //Propiedad que recibe un Comercio y carga los datos en los controles
        public Comercio DatosComercio
        {
            set
            {
                EnsureChildControls();

                Comercio c = value;

                lblPadron.Text = c.Padron.ToString();
                lblDireccion.Text = c.Direccion;
                lblPrecio.Text = c.Precio.ToString();
                lblAccion.Text = c.Accion;
                lblBaño.Text = c.Baño.ToString();
                lblMt2Const.Text = c.Mt2Const.ToString();
                lblHabitaciones.Text = c.Habitaciones.ToString();
                lblTipoPropiedad.Text = c.TipoPropiedad;


                string habilitado;
                if (c.Habilitado == true)
                    habilitado = "SI";
                else
                    habilitado = "NO";

                lblHabilitado.Text = habilitado;

                lblLetraDpto.Text = (c.Zona.LetraDpto).ToUpper();
                lblAbreviacion.Text = c.Zona.Abreviacion.ToString();
                lblNombre.Text = c.Zona.Nombre;
                lblCantHabitantes.Text = c.Zona.CantHabitantes.ToString();
                ListaServiciosZona(c);

                lbServicios.DataSource = listaServicios;
                lbServicios.DataBind();

                //Datos que no pertenecen a este tipo de propiedad
                lblFondo.Text = "NO CORRESPONDE";
                lblMt2Terreno.Text = "NO CORRESPONDE";

                lblPiso.Text = "NO CORRESPONDE";
                lblAscensor.Text = "NO CORRESPONDE";

            }
        }
        #endregion


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

            //agrego el panel con los controles
            this.Controls.Add(UnPanel);
        }

        //Metodo que carga la lista de servicios de la zona
        private void ListaServiciosZona(Propiedad p)
        {
            if (p.Zona.LosServicios.Count != 0)
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