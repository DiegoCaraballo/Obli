using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades_Compartidas
{
    [Serializable]
    public class Empleado
    {
        //Atributos
        private string nomUsu;
        private string pass;

        //Propiedades
        #region propiedades
        public string Pass
        {
            get { return pass; }
            set
            {
                if (value.Length == 10)
                    pass = value;
                else
                    throw new Exception("La contraseña debe contener 10 caracteres");
            }
        }

        public string NomUsu
        {
            get { return nomUsu; }
            set
            {
                if (value.Trim().Length > 3 && value.Trim().Length<21)
                    nomUsu = value;
                else
                    throw new Exception("Debe contener al menos una letra y menos de 21 caracteres");
            }
        }
        #endregion

        //Constructor
        public Empleado(string pNom, string pPass)
        {
            NomUsu = pNom;
            Pass= pPass;
        }

        public Empleado() { }
    }
}
