using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades_Compartidas
{
    [Serializable]
    public class Comercio:Propiedad 
    {
        //Atributos
        private bool habilitado;

        //Propiedades
        public bool Habilitado
        {
            get { return habilitado; }
            set { habilitado = value; }
        }

        //Para saber el tipo de Propiedad
        public override string TipoPropiedad
        {
            get { return "COMERCIO"; }
        }

        //Constructor
        public Comercio(int pPadron,string pDireccion, int pPrecio, string pAccion, int pBaño,int pHab,decimal pMt2,Zona pZona,Empleado pUltimoEmp,bool pHabilitado):
            base(pPadron, pDireccion, pPrecio, pAccion, pBaño, pHab, pMt2, pZona, pUltimoEmp)
        {
            Habilitado = pHabilitado;
        }
        public Comercio() { }
    }
}
