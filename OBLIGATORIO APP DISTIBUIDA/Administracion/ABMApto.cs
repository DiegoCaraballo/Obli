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
    public partial class ABMApto : Form
    {

        private Propiedad prop;
        private Empleado emp = null;
        private Zona zona = null;
        public ABMApto(Empleado e)
        {
            InitializeComponent();

            Accesos();
            cboAccion.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAscensor.DropDownStyle = ComboBoxStyle.DropDownList;
            EstadoInicial();
            emp = e;
        }

        public ABMApto()
        {
            InitializeComponent();
            EstadoInicial();

        }

        // etoy hablando 
        //TODO - Definir si dejamos estos accesos o no
        public void Accesos()
        {
            MenuItemAyuda.ShortcutKeys = Keys.F1;
            MenuItemIngresar.ShortcutKeys = Keys.F3;
            MenuItemModificar.ShortcutKeys = Keys.F4;
            MenuItemEliminar.ShortcutKeys = Keys.F5;
            MenuItemCancelar.ShortcutKeys = Keys.F6;

        }
        public void EstadoInicial()
        {

            MenuItemIngresar.Enabled = false;
            MenuItemEliminar.Enabled = false;
            MenuItemModificar.Enabled = false;
            
            txtPadron.Enabled = true;
            txtDireccion.Enabled = false;
            txtPrecio.Enabled = false;
            cboAccion.Enabled = false;
            txtBanio.Enabled = false;
            txtHabitaciones.Enabled = false;
            txtMt2Const.Enabled = false;
            txtUser.Enabled = false;
            txtPiso.Enabled = false;
            cboAscensor.Enabled = false;
            ccZona.Enabled = false;

            lblMensajes.Text = "";
        }
        public void HabilitarControles()
        {
            MenuItemEliminar.Enabled = true;
            MenuItemModificar.Enabled = true;

            txtPadron.Enabled = false;
            txtDireccion.Enabled = true;
            txtPrecio.Enabled = true;
            cboAccion.Enabled = true;
            txtBanio.Enabled = true;
            txtHabitaciones.Enabled = true;
            txtMt2Const.Enabled = true;
            txtPiso.Enabled = true;
            cboAscensor.Enabled = true;
            ccZona.Enabled = true;

            lblMensajes.Text = "";
  
        }
        public void HabilitarIngreso()
        {

            MenuItemIngresar.Enabled = true;
            
            txtDireccion.Enabled = true;
            txtPrecio.Enabled = true;
            cboAccion.Enabled = true;
            txtBanio.Enabled = true;
            txtHabitaciones.Enabled = true;
            txtMt2Const.Enabled = true;
            txtPiso.Enabled = true;
            cboAscensor.Enabled = true;
            ccZona.Enabled = true;

            lblMensajes.Text = "";

        }
        public void Limpiar()
        {
            txtPadron.Text = "";
            txtDireccion.Text = "";
            txtPrecio.Text = "";
            cboAccion.SelectedIndex =0;
            txtBanio.Text = "";
            txtHabitaciones.Text = "";
            txtMt2Const.Text = "";
            ccZona.Codigo = "";
            ccZona.LetraDepto = "";
            txtUser.Text = "";
            txtPiso.Text = "";
            cboAscensor.SelectedIndex = 0;
            lblMensajes.Text = "";
        }

        private void MenuItemAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Puede utilizar las siguientes teclas para facil acceso a los Items del Menu:\nF1= Ayuda\nF3= Ingresar\nF4= Modificar\nF5= Eliminar\nF6= Cancelar");

        }
        Propiedad p = null;
        public ABMApto(Propiedad pPropiedad)
        {
            p = pPropiedad;

        }
        private void txtPadron_Validating(object sender, CancelEventArgs e)
        {
            try
            {

                Convert.ToInt32(txtPadron.Text);
                EPPadron.Clear();
            }
            catch
            {
                EPPadron.SetError(txtPadron, "Solo se pueden ingresar numeros");
                e.Cancel = true;
            }
            try
            {
                if (Convert.ToInt32(txtPadron.Text) == 0)
                {
                    HabilitarIngreso();
                }
                else
                {
                    ServicioWeb.Propiedad propiedad = null;

                    MiServicio serv = new MiServicio();

                    propiedad = serv.BuscarPropiedad(Convert.ToInt32(txtPadron.Text));

                    if (propiedad == null)
                    {
                        HabilitarControles();
                        return;
                    }
                    if (propiedad is Apto)
                    {
                        prop = propiedad;
                        txtDireccion.Text = propiedad.Direccion;
                        txtPrecio.Text = propiedad.Precio.ToString();
                        cboAccion.SelectedItem = propiedad.Accion.ToString();
                        txtBanio.Text = propiedad.Baño.ToString();
                        txtHabitaciones.Text = propiedad.Habitaciones.ToString();
                        txtMt2Const.Text = propiedad.Mt2Const.ToString();

                        ccZona.LetraDepto = propiedad.Zona.LetraDpto.ToString();
                        ccZona.Codigo = propiedad.Zona.Abreviacion;
                        zona = propiedad.Zona;


                        txtUser.Text = propiedad.UltimoEmp.NomUsu;
                        txtPiso.Text = ((ServicioWeb.Apto)propiedad).Piso.ToString();
                        if (((ServicioWeb.Apto)propiedad).Ascensor == true)
                        {
                            cboAscensor.SelectedItem = "SI";
                        }
                        else
                        {
                            cboAscensor.SelectedItem = "NO";
                        }

                        HabilitarControles();

                    }
                    else
                    {
                        lblMensajes.Text = "El padron ingresado no pertence a una propiedad de tipo Aparatamento";
                    }
                }

            }
            catch (System.Web.Services.Protocols.SoapException ex)
            {
                if (ex.Detail.InnerText.Length > 40)
                    lblMensajes.Text = ex.Detail.InnerText.Substring(0, 40);
                else
                    lblMensajes.Text = ex.Detail.InnerText;
            }
            catch (Exception ex)
            {
                if (ex.Message.Length > 40)
                    lblMensajes.Text = ex.Message.Substring(0, 40);
                else
                    lblMensajes.Text = ex.Message;
            }


        }
        private void MenuItemIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                MiServicio serv = new MiServicio();
                bool ascensor;
                ServicioWeb.Apto apto = new ServicioWeb.Apto();


                apto.Padron = Convert.ToInt32(txtPadron.Text);
                apto.Direccion = txtDireccion.Text.Trim();
                apto.Precio = Convert.ToInt32(txtPrecio.Text);
                apto.Accion = cboAccion.SelectedItem.ToString().ToUpper().Trim();
                apto.Baño = Convert.ToInt32(txtBanio.Text);
                apto.Habitaciones = Convert.ToInt32(txtHabitaciones.Text);
                apto.Mt2Const = Convert.ToInt32(txtMt2Const.Text);
                apto.Zona = serv.BuscarZona(ccZona.LetraDepto, ccZona.Codigo);
                apto.UltimoEmp = emp;

                apto.Piso = Convert.ToInt32(txtPiso.Text);

                if (cboAscensor.SelectedItem.ToString() == "SI")
                    ascensor = true;
                else
                    ascensor = false;

                apto.Ascensor = ascensor;

                serv.AltaPropiedad(apto);

            }
            catch (OverflowException)
            {
                MessageBox.Show("Los digitos en los campos Baño, Padron, Mt2, Precio y Piso no pueden superar los 9 digitos");
            }
            catch (FormatException)
            {
                MessageBox.Show("Revisar datos ingresados");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR EN DAR DE ALTA: " + ex.Message);
            }

        }

     

        private void MenuItemCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            EstadoInicial();
        }

        private void MenuItemEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                new Administracion.ServicioWeb.MiServicio().BajaPropiedad(prop);

                lblMensajes.Text = "Baja con Exito";
            }
            catch (System.Web.Services.Protocols.SoapException ex)
            {
                if (ex.Detail.InnerText.Length > 40)
                    lblMensajes.Text = ex.Detail.InnerText.Substring(0, 40);
                else
                    lblMensajes.Text = ex.Detail.InnerText;
            }
            catch (Exception ex)
            {
                if (ex.Message.Length > 40)
                    lblMensajes.Text = ex.Message.Substring(0, 40);
                else
                    lblMensajes.Text = ex.Message;
            }
        }
        //prueba git
        private void MenuItemModificar_Click(object sender, EventArgs e)
        {

            try
            {
                prop.Direccion = txtDireccion.Text.Trim();
                prop.Precio = Convert.ToInt32(txtPrecio.Text.Trim());
                prop.Accion = cboAccion.SelectedItem.ToString();
                prop.Baño = Convert.ToInt32(txtBanio.Text);
                prop.Habitaciones = Convert.ToInt32(txtHabitaciones.Text);
                prop.Mt2Const = Convert.ToInt32(txtMt2Const.Text);
                prop.Zona.Abreviacion = zona.Abreviacion;
                prop.Zona.LetraDpto = zona.LetraDpto;
                prop.UltimoEmp.NomUsu = txtUser.Text;
                ((ServicioWeb.Apto)prop).Piso = Convert.ToInt32(txtPiso.Text);

                if (cboAscensor.SelectedItem.ToString() == "SI")
                {
                    ((ServicioWeb.Apto)prop).Ascensor = true;
                }
                else
                {
                    ((ServicioWeb.Apto)prop).Ascensor = false;
                }

                new Administracion.ServicioWeb.MiServicio().ModificaPropiedad(prop);
                Limpiar();
            }
            catch (System.Web.Services.Protocols.SoapException ex)
            {
                if (ex.Detail.InnerText.Length > 40)
                    lblMensajes.Text = ex.Detail.InnerText.Substring(0, 40);
                else
                    lblMensajes.Text = ex.Detail.InnerText;
            }
            catch (Exception ex)
            {
                if (ex.Message.Length > 40)
                    lblMensajes.Text = ex.Message.Substring(0, 40);
                else
                    lblMensajes.Text = ex.Message;
            }

        }

  


 

  


       

    }
}
