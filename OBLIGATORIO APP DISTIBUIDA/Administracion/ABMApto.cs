using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using Administracion.ServicioWeb;

namespace Administracion
{
    public partial class ABMApto : Form
    {
      
        private Propiedad prop;
        private Empleado emp;
        public ABMApto(Empleado e)
        {
            emp = e;
        }

        public ABMApto()
        {
            InitializeComponent();
            Accesos();
            cboAccion.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAscensor.DropDownStyle = ComboBoxStyle.DropDownList;
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
                txtLetraDpto.Enabled = false;
                txtAbrev.Enabled = false;
                txtUser.Enabled = false;
                txtPiso.Enabled = false;
                lblMensajes.Text = "";
                cboAscensor.Enabled = false;
        }
        public void HabilitarControles()
        {
            MenuItemIngresar.Enabled = true;
            MenuItemEliminar.Enabled = true;
            MenuItemModificar.Enabled = true;

            MenuItemIngresar.Enabled = true;
            MenuItemEliminar.Enabled = true;
            MenuItemModificar.Enabled = true;
            txtDireccion.Enabled = true;
            txtPrecio.Enabled = true;
            cboAccion.Enabled = true;
            txtBanio.Enabled = true;
            txtHabitaciones.Enabled = true;
            txtMt2Const.Enabled = true;
            txtAbrev.Enabled = true;
            txtLetraDpto.Enabled = true;
            txtUser.Enabled = true;
            txtPiso.Enabled = true;
            lblMensajes.Text = "";
            cboAscensor.Enabled = true;
       
        }
        public void Limpiar()
        {
            txtPadron.Text = "";
            txtDireccion.Text = "";
            txtPrecio.Text = "";
            cboAccion.Text = "";
            txtBanio.Text = "";
            txtHabitaciones.Text = "";
            txtMt2Const.Text = "";
            txtAbrev.Text = "";
            txtLetraDpto.Text = "";
            txtUser.Text = "";
            txtPiso.Text = "";
            lblMensajes.Text="";
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
        private void MenuItemBuscar_Click(object sender, EventArgs e)
        {

        }

        private void MenuItemIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                ServicioWeb.Apto apto = new ServicioWeb.Apto();
                apto.Padron = Convert.ToInt32(txtPadron.Text);
                apto.Direccion = txtDireccion.Text;
                apto.Precio = Convert.ToInt32(txtPrecio.Text);
                apto.Accion = "Alquiler";//cboAccion.SelectedValue.ToString();
                apto.Baño = Convert.ToInt32(txtBanio.Text);
                apto.Habitaciones = Convert.ToInt32(txtHabitaciones.Text);
                apto.Mt2Const = Convert.ToInt32(txtMt2Const.Text);
                apto.Zona = null;
                apto.UltimoEmp = null;
                apto.Piso = Convert.ToInt32(txtPiso.Text);
                apto.Ascensor = true;

                new ServicioWeb.MiServicio().AltaPropiedad(apto);

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
                ServicioWeb.Propiedad propiedad = null;
                MiServicio serv = new MiServicio();
                propiedad = serv.BuscarPropiedad(Convert.ToInt32(txtPadron.Text));
                if (propiedad is Apto)
                {
                    prop = propiedad;
                    txtDireccion.Text = propiedad.Direccion;
                    txtPrecio.Text = propiedad.Precio.ToString();
                    cboAccion.SelectedItem = propiedad.Accion.ToString();
                    txtBanio.Text = propiedad.Baño.ToString();
                    txtHabitaciones.Text = propiedad.Habitaciones.ToString();
                    txtMt2Const.Text = propiedad.Mt2Const.ToString();
                    txtAbrev.Text = propiedad.Zona.Abreviacion;
                    txtLetraDpto.Text = propiedad.Zona.LetraDpto;
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

                    txtPadron.Enabled = false;
                    HabilitarControles();
                   
                }
                else
                {
                    lblMensajes.Text = "El padron ingresado no pertence a una propiedad de tipo Aparatamento"; 
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
                prop.Zona.Abreviacion = txtAbrev.Text;
                prop.Zona.LetraDpto = txtLetraDpto.Text;
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

        private void txtPrecio_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Convert.ToInt32(txtPrecio.Text);
                EPPadron.Clear();
            }
            catch
            {
                EPPadron.SetError(txtPrecio, "Solo se pueden ingresar numeros");
                e.Cancel = true;
            }
        }


        private void txtBanio_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Convert.ToInt32(txtBanio.Text);
                EPPadron.Clear();
            }
            catch
            {
                EPPadron.SetError(txtBanio, "Solo se pueden ingresar numeros");
                e.Cancel = true;
            }
        }
        private void txtHabitaciones_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Convert.ToInt32(txtHabitaciones.Text);
                EPPadron.Clear();
            }
            catch
            {
                EPPadron.SetError(txtHabitaciones, "Solo se pueden ingresar numeros");
                e.Cancel = true;
            }
        }
        private void txtMt2Const_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Convert.ToInt32(txtMt2Const.Text);
                EPPadron.Clear();
            }
            catch
            {
                EPPadron.SetError(txtMt2Const, "Solo se pueden ingresar numeros");
                e.Cancel = true;
            }
        }

        private void ABMApto_Load(object sender, EventArgs e)
        {

        }

    }
}
