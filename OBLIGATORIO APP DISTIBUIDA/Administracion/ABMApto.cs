﻿using System;
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

        private Propiedad prop = null;
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
            txtPiso.Text = "";
            cboAscensor.SelectedIndex = 0;
            lblMensajes.Text = "";
        }

        // Ayuda para el usuario
        private void MenuItemAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Puede utilizar las siguientes teclas para facil acceso a los Items del Menu:\nF1= Ayuda\nF3= Ingresar\nF4= Modificar\nF5= Eliminar\nF6= Cancelar");

        }

        // Validación de un Apto
        private void txtPadron_Validating(object sender, CancelEventArgs e)
        {
            try
            {

                Convert.ToInt32(txtPadron.Text);
                EPPadron.Clear();
            }
            catch (OverflowException)
            {
                EPPadron.SetError(txtPadron, "El padron debe tenere entre 1 y 9 digitos");
                e.Cancel = true;
                return;
            }
            catch
            {
                EPPadron.SetError(txtPadron, "Solo se pueden ingresar numeros");
                e.Cancel = true;
                return;
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
                if (propiedad is Apto)
                {
                    prop = propiedad;

                    txtDireccion.Text = propiedad.Direccion;
                    txtPrecio.Text = propiedad.Precio.ToString();
                    cboAccion.SelectedItem = propiedad.Accion.ToString();
                    txtBanio.Text = propiedad.Baño.ToString();
                    txtHabitaciones.Text = propiedad.Habitaciones.ToString();
                    txtMt2Const.Text = propiedad.Mt2Const.ToString();

                    ccZona.LetraDepto = propiedad.Zona.LetraDpto.Trim().ToUpper();
                    ccZona.Codigo = propiedad.Zona.Abreviacion.Trim().ToUpper();
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

                    HabilitarBM();

                }
                else
                {
                    lblMensajes.Text = "El padron ingresado no pertence a una propiedad de tipo Aparatamento";
                }


            }
            catch (System.Web.Services.Protocols.SoapException ex)
            {
                if (ex.Detail.InnerText.Length > 80)
                    lblMensajes.Text = ex.Detail.InnerText.Substring(0, 80);
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

        // Ingreso de un Apto
        private void MenuItemIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                // MiServicio serv = new MiServicio();
                bool ascensor = false;
                ServicioWeb.Apto apto = new ServicioWeb.Apto();


                apto.Padron = Convert.ToInt32(txtPadron.Text);
                apto.Direccion = txtDireccion.Text.Trim();
                apto.Precio = Convert.ToInt32(txtPrecio.Text);
                apto.Accion = cboAccion.SelectedItem.ToString().ToUpper().Trim();
                apto.Baño = Convert.ToInt32(txtBanio.Text);
                apto.Habitaciones = Convert.ToInt32(txtHabitaciones.Text);
                apto.Mt2Const = Convert.ToInt32(txtMt2Const.Text);
                if (ccZona.LetraDepto == "" || ccZona.Codigo == "")
                {
                    EPPadron.SetError(ccZona, "Verificar datos de Zona");
                }
                apto.Zona = new ServicioWeb.MiServicio().BuscarZona(ccZona.LetraDepto.Trim().ToUpper(), ccZona.Codigo.Trim().ToUpper());
                if (apto.Zona == null)
                {
                    throw new Exception("Zona no encontrada");
                }
                apto.UltimoEmp = emp;

                apto.Piso = Convert.ToInt32(txtPiso.Text);

                if (cboAscensor.SelectedItem.ToString() == "SI")
                    ascensor = true;
                else
                    ascensor = false;

                apto.Ascensor = ascensor;

                new ServicioWeb.MiServicio().AltaPropiedad(apto);

                EstadoInicial();
                lblMensajes.Text = "PROPIEDAD INGRESADA CON EXITO";

            }
            catch (System.Web.Services.Protocols.SoapException ex)
            {
                if (ex.Detail.InnerText.Length > 80)
                    lblMensajes.Text = ex.Detail.InnerText.Substring(0, 80);
                else
                    lblMensajes.Text = ex.Detail.InnerText;
            }
                  catch (FormatException)
            {
                lblMensajes.Text = "Revisar que el valor de los campos numericos sean correctos";
            }
            catch (OverflowException)
            {
                lblMensajes.Text = "Revisar que los campos numericos no tengan mas de 9 digitos";
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

        // Eliminar Apto
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
                if (ex.Detail.InnerText.Length > 80)
                    lblMensajes.Text = ex.Detail.InnerText.Substring(0, 80);
                else
                    lblMensajes.Text = ex.Detail.InnerText;
            }
            catch (Exception ex)
            {
                if (ex.Message.Length > 80)
                    lblMensajes.Text = ex.Message.Substring(0, 80);
                else
                    lblMensajes.Text = ex.Message;
            }
        }

        // Modificar Apto
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
                if (ccZona.LetraDepto == "" || ccZona.Codigo == "")
                {
                    EPPadron.SetError(ccZona, "Verificar datos de Zona");
                }
                prop.Zona = new ServicioWeb.MiServicio().BuscarZona(ccZona.LetraDepto.Trim().ToUpper(), ccZona.Codigo.Trim().ToUpper());
                if (prop.Zona == null)
                {
                    throw new Exception("Zona no encontrada");
                }
                prop.UltimoEmp.NomUsu = emp.NomUsu;
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
                EstadoInicial();
                lblMensajes.Text = "PROPIEDAD MODIFICADA CON EXITO";
            }
            catch (System.Web.Services.Protocols.SoapException ex)
            {
                if (ex.Detail.InnerText.Length > 80)
                    lblMensajes.Text = ex.Detail.InnerText.Substring(0, 80);
                else
                    lblMensajes.Text = ex.Detail.InnerText;
            }
            catch (FormatException)
            {
                lblMensajes.Text = "Revisar que el valor de los campos numericos sean correctos";
            }
            catch (OverflowException)
            {
                lblMensajes.Text = "Revisar que los campos numericos no tengan mas de 9 digitos";
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
