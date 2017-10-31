using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades_Compartidas
{
    public class Apto:Propiedad 
    {
        //Atributos
        private int piso;
        private bool ascensor;

        //Propiedades
        #region propiedades
        public bool Ascensor
        {
            get { return ascensor; }
            set { ascensor = value; }
        }

        public int Piso 
        {
            get { return piso; }
            set {
                if (value > -1 && value <= 100)
                    piso = value;
                else
                    throw new Exception("El piso no debe ser menor a 0 ni mayor a 100");            
            }
        }

        //Para saber el tipo de Propiedad
        public override string TipoPropiedad
        {
            get { return "APARTAMENTO"; }
        }
        #endregion

        //Constructor
        public Apto(int pPadron,string pDireccion, int pPrecio, string pAccion,
           int pBaño,int pHab,decimal pMt2,Zona pZona,Empleado pUltimoEmp,
           int pPiso,bool pAscensor) : base(pPadron,pDireccion,pPrecio,pAccion,pBaño,pHab,pMt2,pZona,pUltimoEmp)
        {
            Piso = pPiso;
            Ascensor = pAscensor;
        }
    }
}
