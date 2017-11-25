﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controles
{
    public partial class CodigoDpto : UserControl
    {
        public CodigoDpto()
        {
            InitializeComponent();
            cboDepartamento.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // Devuelvo el indice del Departamento seleccionado
        public string LetraDepto
        {
            get
            {
                int indice = cboDepartamento.SelectedIndex;
                string letraDpto;

                switch (indice)
                {
                    case 0:
                        letraDpto = "G";
                        return letraDpto;
                    case 1:
                        letraDpto = "A";
                        return letraDpto;
                    case 2:
                        letraDpto = "E";
                        return letraDpto;
                    case 3:
                        letraDpto = "L";
                        return letraDpto;
                    case 4:
                        letraDpto = "Q";
                        return letraDpto;
                    case 5:
                        letraDpto = "N";
                        return letraDpto;
                    case 6:
                        letraDpto = "O";
                        return letraDpto;
                    case 7:
                        letraDpto = "P";
                        return letraDpto;
                    case 8:
                        letraDpto = "B";
                        return letraDpto;
                    case 9:
                        letraDpto = "S";
                        return letraDpto;
                    case 10:
                        letraDpto = "I";
                        return letraDpto;
                    case 11:
                        letraDpto = "J";
                        return letraDpto;
                    case 12:
                        letraDpto = "F";
                        return letraDpto;
                    case 13:
                        letraDpto = "C";
                        return letraDpto;
                    case 14:
                        letraDpto = "H";
                        return letraDpto;
                    case 15:
                        letraDpto = "M";
                        return letraDpto;
                    case 16:
                        letraDpto = "K";
                        return letraDpto;
                    case 17:
                        letraDpto = "R";
                        return letraDpto;
                    case 18:
                        letraDpto = "D";
                        return letraDpto;
                    default:
                        letraDpto = "";
                        return letraDpto;                     
                }
                
            }
        }

        // Código
        public string Codigo
        {
            get {return txtCodigo.Text.Trim();}
            set { txtCodigo.Text = value; }
        }

        // Cargo los items del combo
        private void CodigoDpto_Load(object sender, EventArgs e)
        {
            cboDepartamento.Items.Add("Artigas");
            cboDepartamento.Items.Add("Canelones");
            cboDepartamento.Items.Add("Cerro Largo");
            cboDepartamento.Items.Add("Colonia");
            cboDepartamento.Items.Add("Durazno");
            cboDepartamento.Items.Add("Flores");
            cboDepartamento.Items.Add("Florida");
            cboDepartamento.Items.Add("Lavalleja");
            cboDepartamento.Items.Add("Maldonado");
            cboDepartamento.Items.Add("Montevideo");
            cboDepartamento.Items.Add("Paysandu");
            cboDepartamento.Items.Add("Rio Negro");
            cboDepartamento.Items.Add("Rivera");
            cboDepartamento.Items.Add("Rocha");
            cboDepartamento.Items.Add("Salto");
            cboDepartamento.Items.Add("San Jose");
            cboDepartamento.Items.Add("Soriano");
            cboDepartamento.Items.Add("Tacuarembo");
            cboDepartamento.Items.Add("Treinta y Tres");
        }

        // Validación del código |Vacío|Distinto de 3 caracteres|Que sea letra
        private void txtCodigo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtCodigo.Text == "" || txtCodigo.Text.Length != 3 || !validarLetras(txtCodigo.Text))
                {
                    throw new Exception("El código debe contener 3 letras");
                }
                else
                {
                    EPCodigo.Clear();
                }
            }
            catch (Exception ex)
            {
                EPCodigo.SetError(txtCodigo, ex.Message);
                e.Cancel = true;
                return;
            }
        }

        // Verifica que lo ingresado en el código sean letras
        private bool validarLetras(string codigo)
        {
            try
            {
                bool bandera = true;

                for (int i = 0; i < codigo.Length; i++)
                {
                    if (!Char.IsLetter(codigo[i]))
                    {
                        bandera = false;
                        break;
                    }
                }

                return bandera;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Valido que seleccione un Departamento
        private void cboDepartamento_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (cboDepartamento.SelectedIndex >= 0)
                {
                    EPDpto.Clear();
                }
                else
                {
                    throw new Exception("Debe seleccionar un Departamento");
                }
            }
            catch(Exception ex)
            {
                EPDpto.SetError(cboDepartamento, ex.Message);
                e.Cancel = true;
                return;
            }
        }
    }
}