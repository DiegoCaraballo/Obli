using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades_Compartidas
{
    [Serializable]
    public class Propiedad
    {
        //Atributos
        private int padron;
        private string direccion;
        private int precio;
        private string accion;
        private int baño;
        private int habitaciones;
        private decimal mt2Const;
        private Zona zona;
        private Empleado ultimoEmp;

        //Propiedades
        #region propiedades
        public Empleado UltimoEmp
        {
            get { return ultimoEmp; }
            set
            {
                if (value != null)
                    ultimoEmp = value;
                else
                    throw new Exception("El usuario no puede ser nulo");
            }
        }

        public Zona Zona
        {
            get { return zona; }
            set
            {
                if (value != null)
                    zona = value;
                else
                    throw new Exception("La zona no puede ser vacia");
            }
        }

        public decimal Mt2Const
        {
            get { return mt2Const; }
            set
            {
                if (value >= 1 && value.ToString().Length < 10)
                    mt2Const = value;
                else
                    throw new Exception("Los metros de contruccion pueden tener hasta 9 digitos");
            }
        }

        public int Habitaciones
        {
            get { return habitaciones; }
            set
            {
                if (value >= 1 && value < 100)
                    habitaciones = value;
                else
                    throw new Exception("Debe  contar con al menos una habitacion y menos de 100");
            }
        }

        public int Baño
        {
            get { return baño; }
            set
            {
                if (value >= 1 && value <= 20)
                    baño = value;
                else
                    throw new Exception("Debe de tener por lo menos un baño y no mas de 20");
            }
        }

        public string Accion
        {
            get { return accion; }
            set
            {
                if (value == "VENTA" || value == "PERMUTA" || value == "ALQUILER")
                    accion = value;
                else
                    throw new Exception("No existe esa acción");
            }
        }

        public int Precio
        {
            get { return precio; }
            set
            {
                if (value > 0 && value.ToString().Length < 10)
                    precio = value;
                else
                    throw new Exception("El precio debe ser mayor a 0 y menor a 1.000.000.000");
            }
        }


        public string Direccion
        {
            get { return direccion; }
            set
            {
                if (value.Trim().Length >= 8 && value.Trim().Length < 101)
                    direccion = value;
                else
                    throw new Exception("La direccion no debe contener menos de 8 caracteres y mas de 100");
            }
        }


        public int Padron
        {
            get { return padron; }
            set
            {
                if (value > 0 && value.ToString().Length < 10)
                    padron = value;
                else
                    throw new Exception("El padron debe tener entre 1 y 9 digitos");

            }
        }

        public string ZonaNombre
        {
            get { return zona.Abreviacion + " - " + zona.LetraDpto; }
            set { }

        }

        public virtual string TipoPropiedad
        {
            get { return ""; }
            set { }

        }
        #endregion

        //Constructor
        public Propiedad(int pPadron, string pDireccion, int pPrecio, string pAccion, int pBaño, int pHab, decimal pMt2, Zona pZona, Empleado pUltimoEmp)
        {
            Padron = pPadron;
            Direccion = pDireccion;
            Precio = pPrecio;
            Accion = pAccion;
            Baño = pBaño;
            Habitaciones = pHab;
            Mt2Const = pMt2;
            Zona = pZona;
            UltimoEmp = pUltimoEmp;
        }

        public Propiedad() { }
    }
}
