using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Controles;

using Administracion.ServicioWeb;

namespace Administracion
{
    public partial class ABMZona : Form
    {
        private Zona zona;

        public ABMZona()
        {
            InitializeComponent();
            Accesos();
            EstadoInicial();
        }

        public void Accesos()
        {
            MenuItemAyuda.ShortcutKeys = Keys.F1;
            MenuItemIngresar.ShortcutKeys = Keys.F3;
            MenuItemModificar.ShortcutKeys = Keys.F4;
            MenuItemEliminar.ShortcutKeys = Keys.F5;
            MenuItemCancelar.ShortcutKeys = Keys.F6;
        }

        private void MenuItemAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Puede utilizar las siguientes teclas para facil acceso a los Items del Menu:\nF1= Ayuda\nF2= Buscar\nF3= Ingresar\nF4= Modificar\nF5= Eliminar\nF6= Cancelar");
        }

        //Limpio campos
        public void LimpiarCampos()
        {
            txtHabitantes.Text = "";
            txtNombre.Text = "";
            txtServicio.Text = "";
            lbServicios.Items.Clear();
            //Limpio los campos del userControl de letra de Dpto y Abreviación
            codigoDpto1.Codigo = "";
        }

        //Deja todo en estado Inicial
        public void EstadoInicial()
        {
            LimpiarCampos();
            MenuItemIngresar.Enabled = false;
            MenuItemModificar.Enabled = false;
            MenuItemEliminar.Enabled = false;
            txtNombre.Enabled = false;
            txtServicio.Enabled = false;
            txtHabitantes.Enabled = false;
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;        
        }

        // Botón que cancela y deja en estado inicial
        private void MenuItemCancelar_Click(object sender, EventArgs e)
        {
            EstadoInicial();
            zona = null;
        }

        // Ingreso de una zona
        private void MenuItemIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                // Creo el objeto que me permita trabajar con el WebService
                MiServicio serv = new MiServicio();

                List<string> Servicios = new List<string>();

                // Utilizo la operación del WS
                string codigo = codigoDpto1.Codigo.ToString().ToUpper();
                string letraDpto = codigoDpto1.LetraDepto.ToString();
                string nombre = txtNombre.Text.Trim().ToUpper();
                int cantHabitantes = Convert.ToInt32(txtHabitantes.Text);

                Zona unaZona = new Zona();            
                unaZona.Abreviacion = codigo;
                unaZona.LetraDpto = letraDpto;
                unaZona.Nombre = nombre;
                unaZona.CantHabitantes = cantHabitantes;
  
                foreach (string s in lbServicios.Items)
                {
                    Servicios.Add(s.ToString());
                }

                unaZona.LosServicios = Servicios.ToArray();

                //Ingreso la zona
                serv.AgregarZona(unaZona);
                lblMensaje.Text = "Se agregó la zona";

                EstadoInicial();

            }
            catch (System.Web.Services.Protocols.SoapException ex)
            {
                if (ex.Detail.InnerText.Length > 40)
                    lblMensaje.Text = ex.Detail.InnerText.Substring(0, 40);
                else
                    lblMensaje.Text = ex.Detail.InnerText;
            }
            catch (Exception ex)
            {
                if (ex.Message.Length > 40)
                    lblMensaje.Text = ex.Message.Substring(0, 40);
                else
                    lblMensaje.Text = ex.Message;
            }
        }

        // Valido todo el UserControl para buscar la zona
        private void codigoDpto1_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (codigoDpto1.Codigo != "" && codigoDpto1.LetraDepto != "")
                {
                    EPBuscar.Clear();
                }
                else
                {
                    throw new Exception("Error al validar Código + Departamento");
                }
            }
            catch (Exception ex)
            {
                EPBuscar.SetError(codigoDpto1, ex.Message);
                e.Cancel = true;
                return;
            }

            try
            {
                // Si la validación es correcta, busco la Zona
                ServicioWeb.Zona z = null;
                MiServicio serv = new MiServicio();
                z = serv.BuscarZona(codigoDpto1.LetraDepto, codigoDpto1.Codigo);

                if (z == null)
                {
                    // no existe la zona, es un alta, limpio campos y habilito para ingresar
                    MenuItemIngresar.Enabled = true;
                    MenuItemEliminar.Enabled = false;
                    MenuItemModificar.Enabled = false;  
                    txtHabitantes.Enabled = true;
                    txtNombre.Enabled = true;
                    txtServicio.Enabled = true;
                    lbServicios.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnAgregar.Enabled = true;
                }
                else
                {
                    //existe, cargo y permito eliminar o modificar
                    zona = z;
                    txtHabitantes.Text = zona.CantHabitantes.ToString();
                    txtNombre.Text = zona.Nombre;
                    foreach (string servicio in zona.LosServicios)
                    {                      
                        lbServicios.Items.Add(servicio.ToString());
                    }
                    MenuItemIngresar.Enabled = false;
                    MenuItemEliminar.Enabled = true;
                    MenuItemModificar.Enabled = true;
                    btnAgregar.Enabled = true;
                    btnEliminar.Enabled = true;
                    txtServicio.Enabled = true;
                }
            }
            catch (System.Web.Services.Protocols.SoapException ex)
            {
                if (ex.Detail.InnerText.Length > 40)
                    lblMensaje.Text = ex.Detail.InnerText.Substring(0, 40);
                else
                    lblMensaje.Text = ex.Detail.InnerText;
            }
            catch (Exception ex)
            {
                if (ex.Message.Length > 40)
                    lblMensaje.Text = ex.Message.Substring(0, 40);
                else
                    lblMensaje.Text = ex.Message;
            }
        }

        // Modificar una Zona
        private void MenuItemModificar_Click(object sender, EventArgs e)
        {

        }

        // Eliminar una Zona
        private void MenuItemEliminar_Click(object sender, EventArgs e)
        {

        }

        // Mensaje de ayuda
        private void MenuItemAyuda_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Puede utilizar las siguientes teclas para facil acceso a los Items del Menu:\nF1= Ayuda\nF3= Ingresar\nF4= Modificar\nF5= Eliminar\nF6= Cancelar");
        }

        // Agrega servicios al ListBox
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                //Verifico que se haya ingresado algo en la caja de texto de servicios
                if (txtServicio.Text.Trim().ToUpper() != "")
                {
                    lblMensaje.Text = "";

                    foreach (var servicio in lbServicios.Items)
                    {
                        if (servicio.ToString().Trim().ToUpper() == txtServicio.Text.Trim().ToUpper())
                        {
                            throw new Exception("El servicio ya fue ingresado");
                        }
                    }

                    lbServicios.Items.Add(txtServicio.Text.Trim());
                    txtServicio.Text = "";
                    lblMensaje.Text = "Se agrego el servicio";
                }
                else
                {
                    lblMensaje.Text = "Debe escribir el nombre del servicio";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        // Borrar servicio del ListBox
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                //Determino si hay una linea de la lista seleccionada
                if (lbServicios.SelectedIndex >= 0)
                {
                    lbServicios.Items.RemoveAt(lbServicios.SelectedIndex);
                    lblMensaje.Text = "Se elimino el servicio";
                }
                else
                {
                    lblMensaje.Text = "Debe seleccionar un servicio";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

    }
}
