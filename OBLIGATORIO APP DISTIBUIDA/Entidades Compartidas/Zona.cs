using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades_Compartidas
{
    public class Zona
    {
        //Atributos
        private string letraDpto;
        private string abreviacion;
        private string nombre;
        private int cantHabitantes;
        private List<Servicio> _LosServicios;

        //Propiedades
        #region propiedades
        public List<Servicio> LosServicios //revisar
        {
            get { return _LosServicios; }
            //set { servicios = value; }
        }

        public int CantHabitantes
        {
            get { return cantHabitantes; }
            set
            {
                if (value > 0)
                    cantHabitantes = value;
                else
                    throw new Exception("Debe de haber por lo menos un habitante");
            }
        }


        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (value.Trim().Length > 0 && value.Trim().Length < 31)
                    nombre = value;
                else
                    throw new Exception("El nombre no puede estar vacío ni contener mas de 30 caracteres");
            }
        }


        public string Abreviacion
        {
            get { return abreviacion; }
            set
            {
                if (value.Trim().Length != 3)
                    throw new Exception("La abreviación debe tener 3 caracteres");
                else
                    abreviacion = value;

            }
        }


        public string LetraDpto
        {
            get { return letraDpto; }
            set
            {
                string[] letras = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "Ñ", "O", "P", "Q", "R", "S" };
                if (letras.Contains(value))
                    letraDpto = value;
                else
                    throw new Exception("La letra del departamento tiene que ser una letra de la A  a la S");
            }
        }

        #endregion

        //Constructor
        public Zona(string pLetraDpto, string pAbrev, string pNombre, int pCantHab)
        {
            LetraDpto = pLetraDpto;
            Abreviacion = pAbrev;
            Nombre = pNombre;
            CantHabitantes = pCantHab;
            _LosServicios = new List<Servicio>();
        }

        public Zona(string pLetraDpto, string pAbrev, string pNombre, int pCantHab, List<Servicio> pServicios)
        {
            LetraDpto = pLetraDpto;
            Abreviacion = pAbrev;
            Nombre = pNombre;
            CantHabitantes = pCantHab;
            _LosServicios = pServicios;
        }

        //Operaciones
        public void AgregarServicio(string pUnServicio)
        {
            _LosServicios.Add(new Servicio(pUnServicio));
        }

        public void EliminarTodosLosServicios()
        {
            _LosServicios.Clear();
        }
          public Zona() { }
    }

}
