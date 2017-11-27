using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades_Compartidas
{
    [Serializable]
    public class Visita
    {
        //Atributos
        private int id;
        private DateTime fecha;
        private string telefono;
        private string nombre;
        private Propiedad aVisitar;

        //Propiedades
        #region propiedades

        public Propiedad AVisitar
        {
            get { return aVisitar; }
            set {
               if (value != null)
                    aVisitar = value;
             else
               throw new Exception("Debe seleccionar una propiedad");
            
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set {
                if (value.Trim().Length > 0 && value.Trim().Length < 21)
                    nombre = value;
                else
                    throw new Exception("El nombre no puede ser vacío ni contener mas de 20 caracteres");
            }
        }

        public string Telefono
        {
            get { return telefono; }
            set {
                if (value.Trim().Length >= 4 && value.Trim().Length < 21)
                    telefono = value;
                else
                    throw new Exception("Ingrese un número de telefono de entre 4 y 20 digitos");
                }
        }


        public DateTime Fecha
        {
            get { return fecha;  }
            set {
                if (value.Date !=null )
                    fecha = value;
                else
                    throw new Exception("Debe ingresar una fecha");
            }
        }

      
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        #endregion


        

        public Visita( DateTime pFecha, string pTelefono, string pNombre, Propiedad pAVisitar)
        {
            Fecha = pFecha;
            Telefono = pTelefono;
            Nombre = pNombre;
            AVisitar = pAVisitar;
        }
       
        public Visita()
        { }
    }
}
