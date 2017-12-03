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
    public partial class ABMComercio : Form
    {
        private Propiedad prop = null;
        private Empleado emp = null;
        private Zona zona = null;

        public ABMComercio(Empleado e)
        {
            InitializeComponent();

            Accesos();
            cboAccion.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHabilitado.DropDownStyle = ComboBoxStyle.DropDownList;
            EstadoInicial();
            emp = e;
        }



        public void Accesos()
        {
            MenuItemAyuda.ShortcutKeys = Keys.F1;
            MenuItemIngresar.ShortcutKeys = Keys.F3;
            MenuItemModificar.ShortcutKeys = Keys.F4;
            MenuItemEliminar.ShortcutKeys = Keys.F5;
            MenuItemCancelar.ShortcutKeys = Keys.F6;

        }

        // Deja todo en estado Inicial
        public void EstadoInicial()
        {

            MenuItemIngresar.Enabled = false;
            MenuItemEliminar.Enabled = false;
            MenuItemModificar.Enabled = false;
            txtUser.Enabled = false;
            txtPadron.Enabled = true;
            Limpiar();
        }

        // Habilita los controles
        public void HabilitarBM()
        {
            MenuItemEliminar.Enabled = true;
            MenuItemModificar.Enabled = true;
            MenuItemIngresar.Enabled = false;
            txtPadron.Enabled = false;
            lblMensajes.Text = "";

        }

        // Habilita el ingreso
        public void HabilitarIngreso()
        {
            MenuItemEliminar.Enabled = false;
            MenuItemModificar.Enabled = false;
            MenuItemIngresar.Enabled = true;
            txtPadron.Enabled = true;
            lblMensajes.Text = "";

        }

        // Limpia los campos
        public void Limpiar()
        {
            txtPadron.Text = "";
            txtDireccion.Text = "";
            txtPrecio.Text = "";
            cboAccion.SelectedIndex = 0;
            txtBanio.Text = "";
            txtHabitaciones.Text = "";
            txtMt2Const.Text = "";
            ccZona.Codigo = "";
            ccZona.LetraDepto = "";
            txtUser.Text = "";
            cboHabilitado.SelectedIndex = 0;
            lblMensajes.Text = "";
        }

        // Ayuda para el usuario
        private void MenuItemAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Puede utilizar las siguientes teclas para facil acceso a los Items del Menu:\nF1= Ayuda\nF3= Ingresar\nF4= Modificar\nF5= Eliminar\nF6= Cancelar");

        }



        // Validación de un Comercio

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

                if (propiedad == null)
                {
                    HabilitarIngreso();
                    return;
                }
                if (propiedad is Comercio)
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
                    if (((ServicioWeb.Comercio)propiedad).Habilitado == true)
                    {
                        cboHabilitado.SelectedItem = "SI";
                    }
                    else
                    {
                        cboHabilitado.SelectedItem = "NO";
                    }

                    HabilitarBM();

                }
                else
                {
                    lblMensajes.Text = "El padron ingresado no pertence a una propiedad de tipo Aparatamento";
                }


            }
            catch (System.Web.Services.Protocols.SoapException ex)
            {
                string p = ex.Message;
                string[] mensaje = ex.Message.Split('>');
                int count = -1;
                foreach (string texto in mensaje)
                {
                    count += 1;
                }

                lblMensajes.Text = (mensaje[count]);
            }
            catch (Exception ex)
            {
                if (ex.Message.Length > 40)
                    lblMensajes.Text = ex.Message.Substring(0, 40);
                else
                    lblMensajes.Text = ex.Message;
            }


        }

        // Ingreso de un Comercio
        private void MenuItemIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                // MiServicio serv = new MiServicio();
                bool habilitado = false;
                ServicioWeb.Comercio comercio = new ServicioWeb.Comercio();


                comercio.Padron = Convert.ToInt32(txtPadron.Text);
                comercio.Direccion = txtDireccion.Text.Trim();
                comercio.Precio = Convert.ToInt32(txtPrecio.Text);
                comercio.Accion = cboAccion.SelectedItem.ToString().ToUpper().Trim();
                comercio.Baño = Convert.ToInt32(txtBanio.Text);
                comercio.Habitaciones = Convert.ToInt32(txtHabitaciones.Text);
                comercio.Mt2Const = Convert.ToInt32(txtMt2Const.Text);
                comercio.Zona = new ServicioWeb.MiServicio().BuscarTodasZonas(ccZona.LetraDepto, ccZona.Codigo);
                comercio.UltimoEmp = emp;


                if (cboHabilitado.SelectedItem.ToString() == "SI")
                    habilitado = true;
                else
                    habilitado = false;

                comercio.Habilitado = habilitado;

                new ServicioWeb.MiServicio().AltaPropiedad(comercio);

                EstadoInicial();
                lblMensajes.Text = "PROPIEDAD INGRESADA CON EXITO";

            }
            catch (System.Web.Services.Protocols.SoapException ex)
            {
                string p = ex.Message;
                string[] mensaje = ex.Message.Split('>');
                int count = -1;
                foreach (string texto in mensaje)
                {
                    count += 1;
                }

                lblMensajes.Text = (mensaje[count]);
            }
            catch (Exception ex)
            {
                if (ex.Message.Length > 80)
                    lblMensajes.Text = ex.Message.Substring(0, 80);
                else
                    lblMensajes.Text = ex.Message;
            }

        }

        // Cancelo y vuelvo a estado inicial
        private void MenuItemCancelar_Click(object sender, EventArgs e)
        {
            EstadoInicial();
        }

        // Eliminar Comercio

        private void MenuItemEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                new Administracion.ServicioWeb.MiServicio().BajaPropiedad(prop);
                EstadoInicial();
                lblMensajes.Text = "Baja con Exito";
            }
            catch (System.Web.Services.Protocols.SoapException ex)
            {
                string p = ex.Message;
                string[] mensaje = ex.Message.Split('>');
                int count = -1;
                foreach (string texto in mensaje)
                {
                    count += 1;
                }

                lblMensajes.Text = (mensaje[count]);
            }
            catch (Exception ex)
            {
                if (ex.Message.Length > 80)
                    lblMensajes.Text = ex.Message.Substring(0, 80);
                else
                    lblMensajes.Text = ex.Message;
            }
        }

        // Modificar Comercio
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
                prop.Zona = new ServicioWeb.MiServicio().BuscarZona(ccZona.LetraDepto, ccZona.Codigo);
                prop.UltimoEmp.NomUsu = emp.NomUsu;

                if (cboHabilitado.SelectedItem.ToString() == "SI")
                {
                    ((ServicioWeb.Comercio)prop).Habilitado = true;
                }
                else
                {
                    ((ServicioWeb.Comercio)prop).Habilitado = false;
                }

                new Administracion.ServicioWeb.MiServicio().ModificaPropiedad(prop);
                EstadoInicial();
            }
            catch (System.Web.Services.Protocols.SoapException ex)
            {
                string p = ex.Message;
                string[] mensaje = ex.Message.Split('>');
                int count = -1;
                foreach (string texto in mensaje)
                {
                    count += 1;
                }

                lblMensajes.Text = (mensaje[count]);
            }
            catch (Exception ex)
            {
                if (ex.Message.Length > 80)
                    lblMensajes.Text = ex.Message.Substring(0, 80);
                else
                    lblMensajes.Text = ex.Message;
            }

        }


    }
}
