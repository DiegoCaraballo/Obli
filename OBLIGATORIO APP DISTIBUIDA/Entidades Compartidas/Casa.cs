using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades_Compartidas
{
    [Serializable]
    public class Casa: Propiedad 
    {
        //Atributos
        private decimal mt2Terreno;
        private bool fondo;

        //Propiedades
        #region propiedades
        public bool Fondo
        {
            get { return fondo; }
            set { fondo = value; }
        }

        public decimal Mt2Terreno
        {
            get { return mt2Terreno; }
            set {
                if (value > 1 || value >= Mt2Const)
                    mt2Terreno = value;
                else
                    throw new Exception("El terreno debe ser mayor a 1mt2 y no puede ser menor a los mt2 de la Construccion en el terreno");
            }
        }

        //Para saber el tipo de Propiedad
        public override string TipoPropiedad
        {
            get { return "CASA"; }
        }
        #endregion

        //Contructor
        public Casa(int pPadron,string pDireccion, int pPrecio, string pAccion, int pBaño,int pHab,decimal pMt2,Zona pZona,Empleado pUltimoEmp, decimal pMt2Terreno,bool pFondo):
            base(pPadron,pDireccion,pPrecio,pAccion,pBaño,pHab,pMt2,pZona,pUltimoEmp)
        {
            Mt2Terreno = pMt2;
            Fondo = pFondo;
        }
        public Casa()
        { }
    }
}
