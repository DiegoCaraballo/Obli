using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades_Compartidas;
using Logica;

using System.Web.UI;
using System.Web.UI.WebControls;


namespace ControlesWeb
{
    public class DatosPropiedad : WebControl, INamingContainer

    {
        //atributos
        private Label UnTitulo;
        private  Label padron;
        private Label direccion;
        private Label precio;
        private Label accion;
        private Label baño;
        private Label habitaciones;
        private Label mt2Const;

        private Label fondo;
        private Label mt2Terreno;

        private Label piso;
        private Label ascencor;

        private Label habilitado;
        

        private Label letraDpto;
        private Label abreviacion;
        private Label nombre;
        private Label cantHabitantes;
        private ListBox losServicios;



        private Panel UnPanel;

        
        //protected override void CreateChildControls()
        //{
          //  base.CreateChildControls();
           //}


        

       public void Datos(Propiedad pPropiedad, Zona pZona)
       {
           Propiedad p = pPropiedad;
           Zona z = pZona;

            UnPanel = new Panel();
            UnPanel.Controls.Add(new LiteralControl("<table>"));
         
            UnPanel.Controls.Add(new LiteralControl("<tr><td>Padron:</td><td>"));

            padron = new Label();
            padron.Text = p.Padron.ToString();
            padron.ForeColor = System.Drawing.Color.Red;
            padron.Font.Bold = true;
            padron.Font.Underline = true;
            UnPanel.Controls.Add(padron);
            UnPanel.Controls.Add(new LiteralControl("</td><BR /></tr>"));


            UnPanel.Controls.Add(new LiteralControl("<tr><td>Direccion:</td><td>"));
           
            direccion = new Label();
            direccion.Text = p.Direccion;
            direccion.ForeColor = System.Drawing.Color.Red;
            direccion.Font.Bold = true;
            direccion.Font.Underline = true;
            UnPanel.Controls.Add(direccion);
            UnPanel.Controls.Add(new LiteralControl("</td><BR /></tr>"));


            UnPanel.Controls.Add(new LiteralControl("<tr></td><td>Precio:</td><td>"));
            precio = new Label();
            precio.Text = "Precio: " + p.Precio.ToString();
            precio.ForeColor = System.Drawing.Color.Red;
            precio.Font.Bold = true;
            precio.Font.Underline = true;
            UnPanel.Controls.Add(precio);
            UnPanel.Controls.Add(new LiteralControl("</td><BR /></tr>"));


            UnPanel.Controls.Add(new LiteralControl("<tr><td>Estado:</td><td>"));
            accion = new Label();
            accion.Text = "Estado: " + p.Accion.ToString();
            accion.ForeColor = System.Drawing.Color.Red;
            accion.Font.Bold = true;
            accion.Font.Underline = true;
            UnPanel.Controls.Add(accion);
            UnPanel.Controls.Add(new LiteralControl("</td><BR /></tr>"));

            UnPanel.Controls.Add(new LiteralControl("<tr><td>Baños:</td><td>"));
            baño = new Label();
            baño.Text = p.Baño.ToString();
            baño.ForeColor = System.Drawing.Color.Red;
            baño.Font.Bold = true;
            baño.Font.Underline = true;
            UnPanel.Controls.Add(baño);
            UnPanel.Controls.Add(new LiteralControl("</td><BR /></tr>"));


            UnPanel.Controls.Add(new LiteralControl("<tr><td>Habitaciones:</td><td>"));
            habitaciones = new Label();
            habitaciones.Text = p.Habitaciones.ToString();
            habitaciones.ForeColor = System.Drawing.Color.Red;
            habitaciones.Font.Bold = true;
            habitaciones.Font.Underline = true;
            UnPanel.Controls.Add(habitaciones);
            UnPanel.Controls.Add(new LiteralControl("</td><BR /></tr>"));

            UnPanel.Controls.Add(new LiteralControl("<tr><td>Mt2:</td><td>"));

            mt2Const = new Label();
            mt2Const.Text = p.Mt2Const.ToString();
            mt2Const.ForeColor = System.Drawing.Color.Red;
            mt2Const.Font.Bold = true;
            mt2Const.Font.Underline = true;
            UnPanel.Controls.Add(mt2Const);
            UnPanel.Controls.Add(new LiteralControl("</td><BR /></tr>"));


             UnPanel.Controls.Add(new LiteralControl("<tr><td>Dpto:</td><td>"));

            letraDpto = new Label();
            letraDpto.Text = z.LetraDpto.ToString();
            letraDpto.ForeColor = System.Drawing.Color.Red;
            letraDpto.Font.Bold = true;
            letraDpto.Font.Underline = true;
            UnPanel.Controls.Add(letraDpto);
            UnPanel.Controls.Add(new LiteralControl("</td><BR /></tr>"));

           UnPanel.Controls.Add(new LiteralControl("<tr><td>Abreviacion:</td><td>"));

            abreviacion = new Label();
            abreviacion.Text = z.Abreviacion.ToString();
            abreviacion.ForeColor = System.Drawing.Color.Red;
            abreviacion.Font.Bold = true;
            abreviacion.Font.Underline = true;
            UnPanel.Controls.Add(abreviacion);
            UnPanel.Controls.Add(new LiteralControl("</td><BR /></tr>"));


            UnPanel.Controls.Add(new LiteralControl("<tr><td>Zona:</td><td>"));

            nombre = new Label();
            nombre.Text = z.Nombre.ToString();
            nombre.ForeColor = System.Drawing.Color.Red;
            nombre.Font.Bold = true;
            nombre.Font.Underline = true;
            UnPanel.Controls.Add(nombre);
            UnPanel.Controls.Add(new LiteralControl("</td><BR /></tr>"));

            UnPanel.Controls.Add(new LiteralControl("<tr><td>Habitantes:</td><td>"));

            cantHabitantes = new Label();
            cantHabitantes.Text = z.CantHabitantes.ToString();
            cantHabitantes.ForeColor = System.Drawing.Color.Red;
            cantHabitantes.Font.Bold = true;
            cantHabitantes.Font.Underline = true;
            UnPanel.Controls.Add(cantHabitantes);
            UnPanel.Controls.Add(new LiteralControl("</td><BR /></tr>"));


            UnPanel.Controls.Add(new LiteralControl("<tr><td>Servicios:</td><td>"));

            losServicios = new ListBox();
            foreach (Servicio s in z.LosServicios)
            {
                losServicios.Items.Add(s.Servicios.ToString());
            }
           
            losServicios.ForeColor = System.Drawing.Color.Red;
            losServicios.Font.Bold = true;
            losServicios.Font.Underline = true;
            UnPanel.Controls.Add(losServicios);
            UnPanel.Controls.Add(new LiteralControl("</td><BR /></tr>"));
           
           if (p is Casa)
            {
                string Fondo;

                if (((Casa)p).Fondo == true)
                {
                    Fondo = "SI";
                }
                else
                {
                    Fondo = "NO";
                }
                UnPanel.Controls.Add(new LiteralControl("<tr><td>Fondo:</td><td>"));

                fondo = new Label();
                fondo.Text =  Fondo;
                fondo.ForeColor = System.Drawing.Color.Red;
                fondo.Font.Bold = true;
                fondo.Font.Underline = true;
                UnPanel.Controls.Add(fondo);
                UnPanel.Controls.Add(new LiteralControl("</td><BR /></tr>"));

                UnPanel.Controls.Add(new LiteralControl("<tr><td>Mt2(Terrreno):</td><td>"));

                mt2Terreno = new Label();
                mt2Terreno.Text = ((Casa)p).Mt2Terreno.ToString();
                mt2Terreno.ForeColor = System.Drawing.Color.Red;
                mt2Terreno.Font.Bold = true;
                mt2Terreno.Font.Underline = true;
                UnPanel.Controls.Add(mt2Terreno);
                UnPanel.Controls.Add(new LiteralControl("</td><BR /></tr>"));
            }
            else if (p is Apto)
            {
                string Ascen;

                if (((Apto)p).Ascensor == true)
                {
                    Ascen = "SI";
                }
                else
                {
                    Ascen = "NO";
                }

                UnPanel.Controls.Add(new LiteralControl("<tr><td>Ascensor:</td><td>"));

                ascencor = new Label();
                ascencor.Text =  Ascen;
                ascencor.ForeColor = System.Drawing.Color.Red;
                ascencor.Font.Bold = true;
                ascencor.Font.Underline = true;
                UnPanel.Controls.Add(ascencor);
                UnPanel.Controls.Add(new LiteralControl("</td><BR /></tr>"));

                UnPanel.Controls.Add(new LiteralControl("<tr><td>Piso:</td><td>"));

                piso = new Label();
                piso.Text = ((Apto)p).Piso.ToString();
                piso.ForeColor = System.Drawing.Color.Red;
                piso.Font.Bold = true;
                piso.Font.Underline = true;
                UnPanel.Controls.Add(piso);
                UnPanel.Controls.Add(new LiteralControl("</td><BR /></tr>"));
            }
            else
            {

                string Habilitado;

                if (((Comercio)p).Habilitado == true)
                {
                    Habilitado = "SI";
                }
                else
                {
                    Habilitado = "NO";
                }

                UnPanel.Controls.Add(new LiteralControl("<tr><td>Habilitado:</td><td>"));

                habilitado = new Label();
                habilitado.Text = Habilitado;
                habilitado.ForeColor = System.Drawing.Color.Red;
                habilitado.Font.Bold = true;
                habilitado.Font.Underline = true;
                UnPanel.Controls.Add(habilitado);
                UnPanel.Controls.Add(new LiteralControl("</td><BR /></tr>"));
            }

           UnPanel.Controls.Add(new LiteralControl("</Table>"));
           this.Controls.Add(UnPanel);


          
       }
       
    }
}
