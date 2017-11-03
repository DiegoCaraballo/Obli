using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using Entidades_Compartidas;
using Logica;

namespace Administracion
{
    public partial class ABMApto : Form
    {
        public ABMApto()
        {
            InitializeComponent();
            Accesos();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void Accesos()
        {
            MenuItemAyuda.ShortcutKeys = Keys.F1;
            MenuItemBuscar.ShortcutKeys = Keys.F2;
            MenuItemIngresar.ShortcutKeys = Keys.F3;
            MenuItemModificar.ShortcutKeys = Keys.F4;
            MenuItemEliminar.ShortcutKeys = Keys.F5;
            MenuItemCancelar.ShortcutKeys = Keys.F6;
            
            }

        private void MenuItemAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Puede utilizar las siguientes teclas para facil acceso a los Items del Menu:\nF1= Ayuda\nF2= Buscar\nF3= Ingresar\nF4= Modificar\nF5= Eliminar\nF6= Cancelar");
        
        }
        Propiedad p = null;
        public ABMApto (Propiedad pPropiedad) {
            p = pPropiedad;

        }
        private void MenuItemBuscar_Click(object sender, EventArgs e)
        {
            try
            {
           
                 
           
            }
            catch (FormatException)
            {
          MessageBox.Show("El padron debe tener formato numerico");
            }
            catch (OverflowException)
            {
             MessageBox.Show("El padron debe tener entre 1 y 9 digitos");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MenuItemIngresar_Click(object sender, EventArgs e)
        {
            try
            {Zona z = null;
                Empleado emp=null;
            //    ABMApto a = new ABMApto(p);
                if (1==1)//(Zona)Session["Zona"] != null)
               
                {
                  //  bool ascen = false;
                   // if (cboAscensor.SelectedItem == "SI")
                    //{
                    //    ascen = true;
                    //}
                    //else
                   // {
                    //    ascen = false;
                   // }
                    Apto apto = new Apto(Convert.ToInt32(txtPadron.Text), txtDireccion.Text.Trim().ToUpper(), Convert.ToInt32(txtPrecio.Text), cboAccion.SelectedIndex.ToString(), Convert.ToInt32(txtBanio.Text),
                                      Convert.ToInt32(txtHabitaciones.Text), Convert.ToDecimal(txtMt2Const.Text), z, emp,Convert.ToInt32( txtPiso.Text), true); //((Zona)Session["Zona"]), (//(Empleado)Session["UnEmpleado"]), Convert.ToInt32(txtPiso.Text), ascen);
                    FabricaLogica.getPropiedadesLogica().AltaPropiedad(apto);
                   // Limpiar();
                  //  EstadoInicial();
                    txtPadron.Text = "";
                     MessageBox.Show("ALTA CON EXITO!!!");

                }
              //  else
             //   {
              //    MessageBox.Show("Debe buscar una zona previamente");
              //  }
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
    }
}
