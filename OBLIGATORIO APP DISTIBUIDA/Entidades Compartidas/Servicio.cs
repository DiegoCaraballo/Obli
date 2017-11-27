using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades_Compartidas
{
    [Serializable]
    public class Servicio
    {
        //Atributos
        private string servicios;

        //Propiedades
        #region PROPIEDADES

        public string Servicios
        {
            get { return servicios; }
            set
            {
                if (value.Trim().Length > 0 && value.Trim().Length < 51)
                    servicios = value;
                else
                    throw new Exception("El nombre no puede estar vacío ni contener mas de 50 caracteres");
            }
        }


        //public string Abreviacion
        //{
        //    get { return abreviacion; }
        //    set
        //    {
        //        //averiguar como hacer control abreviacion  
        //        abreviacion = value;

        //    }
        //}


        //public char LetraDpto
        //{
        //    get { return letraDpto; }
        //    set
        //    {
        //        if (value.ToString().Contains("ABCDEFGHIJKLMNOPQRS"))
        //            letraDpto = value;
        //        else
        //            throw new Exception("La letra del departamento tiene que ser una letra de la A  a la S");
        //    }
        //}

        #endregion

        //Constructor
        public Servicio(string pServicios)
        {
            Servicios = pServicios;
        }

        public Servicio() { }
    }
}
