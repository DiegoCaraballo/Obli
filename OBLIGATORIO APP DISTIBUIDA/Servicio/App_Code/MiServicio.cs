using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using Logica;
using Entidades_Compartidas;
using System.Xml;
using System.Web.Services.Protocols;

/// <summary>
/// Descripción breve de MiServicio
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class MiServicio : System.Web.Services.WebService
{

    #region Propiedad
    [WebMethod]
    public void ParaPoderSerializar(Casa unaCasa, Apto unApto, Comercio unComercio)
    { }

    [WebMethod]
    public void AltaPropiedad(Propiedad p)
    {
        try
        {
            FabricaLogica.getPropiedadesLogica().AltaPropiedad(p);
        }
        catch (Exception ex)
        {
            this.GeneroSoapException(ex);
        }
    }

    [WebMethod]
    public void BajaPropiedad(Propiedad p)
    {
        try
        {
            FabricaLogica.getPropiedadesLogica().BajaPropiedad(p);
        }
        catch (Exception ex)
        {
            this.GeneroSoapException(ex);
        }
    }

    [WebMethod]
    public void ModificaPropiedad(Propiedad p)
    {
        try
        {
            FabricaLogica.getPropiedadesLogica().ModificaPropiedad(p);
        }
        catch (Exception ex)
        {
            this.GeneroSoapException(ex);
        }
    }

    [WebMethod]
    public Propiedad BuscarPropiedad(int pPadron)
    {
        Propiedad prop = null;
        try
        {
            prop = FabricaLogica.getPropiedadesLogica().BuscarPropiedad(pPadron);
        }
        catch (Exception ex)
        {
            this.GeneroSoapException(ex);
        }
        return prop;
    }

    [WebMethod]
    //operacion para poder serializar el tipo de pripidad(Casa) que no se usa directamente con el WS
    public Casa ParaPoderSerializarCAsa()
    {
        return new Casa();
    }
    [WebMethod]
    //operacion para poder serializar el tipo de pripidad(Apto) que no se usa directamente con el WS
    public Apto ParaPoderSerializarApto()
    {
        return new Apto();
    }
    [WebMethod]
    //operacion para poder serializar el tipo de pripidad(Comercio) que no se usa directamente con el WS
    public Comercio ParaPoderSerializarComercio()
    {
        return new Comercio();
    }

    [WebMethod]
    public List<Propiedad> ListarPropiedades()
    {
        List<Propiedad> lista = new List<Propiedad>();
        try
        {
            lista = FabricaLogica.getPropiedadesLogica().ListarPropiedades();

        }
        catch (Exception ex)
        {
            this.GeneroSoapException(ex);
        }
        return lista;

    }
    #endregion //listo
    //servicio de propiedades listo

    #region Zona
    [WebMethod]
    public void AgregarZona(Zona unaZona)
    {
        try
        {
            FabricaLogica.getZonaLogica().AgregarZona(unaZona);
        }
        catch (Exception ex)
        {
            this.GeneroSoapException(ex);
        }
    }

    [WebMethod]
    public void EliminarZona(Zona unaZona)
    {
        try
        {
            FabricaLogica.getZonaLogica().EliminarZona(unaZona);
        }
        catch (Exception ex)
        {
            this.GeneroSoapException(ex);
        }
    }

    [WebMethod]
    public void ModificarZona(Zona unaZona)
    {
        try
        {
            FabricaLogica.getZonaLogica().ModificarZona(unaZona);
        }
        catch (Exception ex)
        {
            this.GeneroSoapException(ex);
        }
    }

    [WebMethod]
    public Zona BuscarZona(string pLetra, string pAbrev)
    {
        Zona unaZona = null;
        try
        {
            unaZona = FabricaLogica.getZonaLogica().BuscarZona(pLetra, pAbrev);
        }
        catch (Exception ex)
        {
            this.GeneroSoapException(ex);
        }
        return unaZona;
    }

    [WebMethod]
    public List<Zona> Listo()
    {
        List<Zona> lista = null;
        try
        {
            lista = FabricaLogica.getZonaLogica().Listo();
        }
        catch (Exception ex)
        {
            this.GeneroSoapException(ex);
        }
        return lista;
    }

    [WebMethod]
    public List<Zona> ListoPorDpto(string pLetraDpto)
    {
        List<Zona> lista = null;
        try
        {
            lista = FabricaLogica.getZonaLogica().ListoPorDpto(pLetraDpto);
        }
        catch (Exception ex)
        {
            this.GeneroSoapException(ex);
        }
        return lista;
    }
    #endregion
    //servicio de zonas listo

    #region Empleado

    [WebMethod]
    public void AgregarEmpleado(Empleado E)
    {
        try
        {
            FabricaLogica.getEmpleadoLogica().AgregarEmpleado(E);
        }
        catch (Exception ex)
        {
            this.GeneroSoapException(ex);
        }
    }

    [WebMethod]
    public void EliminarEmpleado(Empleado E)
    {
        try
        {
            FabricaLogica.getEmpleadoLogica().EliminarEmpleado(E);
        }
        catch (Exception ex)
        {
            this.GeneroSoapException(ex);
        }
    }
    [WebMethod]
    public void ModificarEmpleado(Empleado E)
    {
        try
        {
            FabricaLogica.getEmpleadoLogica().ModificarEmpleado(E);
        }
        catch (Exception ex)
        {
            this.GeneroSoapException(ex);
        }
    }
    [WebMethod]
    public Empleado BuscarEmpleado(string pNomUsu)
    {
        Empleado unEmpleado = null;
        try
        {
            unEmpleado = FabricaLogica.getEmpleadoLogica().BuscarEmpleado(pNomUsu);
        }
        catch (Exception ex)
        {
            this.GeneroSoapException(ex);
        }
        return unEmpleado;
    }



    #endregion
    //servicio de empleados listo
   
    #region Visita

    [WebMethod]
    public XmlDocument ListarVisitas()
    {
        try
        {
            IVisitaLogica Lista = FabricaLogica.getVisitaLogica();

            XmlDocument exportar = ListarVisitasXML(Lista.ListaVisitas());
            

            return exportar;
        }
        catch (Exception ex)
        {
            XmlDocument _undoc = new XmlDocument();
            XmlNode NodoError = _undoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);
            XmlNode _NodoDetalle = _undoc.CreateNode(XmlNodeType.Element, "Error", "");
            _NodoDetalle.InnerText = ex.Message;
            NodoError.AppendChild(_NodoDetalle);

            SoapException _MiEx = new SoapException("Error WS", SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, NodoError);

            throw _MiEx;
        }
    }
    public void AltaVisita(Visita v)
    {
        try
        {
            FabricaLogica.getVisitaLogica().AgendaVisita(v);
        }
        catch (Exception ex)
        {
            this.GeneroSoapException(ex);
        }
    }
    #endregion


    #region Operaciones

    private XmlDocument ListarVisitasXML(List<Visita> lista)
    {
        List<Visita> listado = new List<Visita>();
        XmlDocument exportar = new XmlDocument();

        XmlNode Visitas = exportar.CreateNode(XmlNodeType.Element, "Visitas", "");
        exportar.AppendChild(Visitas);
        foreach (Visita v in lista)
        {
            XmlNode nodoPropiedad = exportar.CreateNode(XmlNodeType.Element, "Propiedad", "");

            XmlNode nodoAccion = exportar.CreateNode(XmlNodeType.Element, "Accion", "");
            nodoAccion.InnerXml = v.AVisitar.Accion;
            nodoPropiedad.AppendChild(nodoAccion);

            XmlNode nodoPadron = exportar.CreateNode(XmlNodeType.Element, "Padron", "");
            nodoPadron.InnerXml = v.AVisitar.Padron.ToString();
            nodoPropiedad.AppendChild(nodoPadron);

            XmlNode nodoPrecio = exportar.CreateNode(XmlNodeType.Element, "Precio", "");
            nodoPrecio.InnerXml = v.AVisitar.Precio.ToString();
            nodoPropiedad.AppendChild(nodoPrecio);

            XmlNode nodoFecha = exportar.CreateNode(XmlNodeType.Element, "Fecha", "");
            nodoFecha.InnerXml = v.Fecha.ToShortDateString();
            nodoPropiedad.AppendChild(nodoFecha);

            Visitas.AppendChild(nodoPropiedad);
         
            
        }
        return exportar;
    }
    #endregion

    #region SoapException
    private void GeneroSoapException(Exception ex)
    {


        //Se crea un nodo xml (NodoError) el cual sera utilizado  para cargar el atributo Details de la exception SOAP
        XmlDocument _undoc = new System.Xml.XmlDocument();
        XmlNode _NodoError = _undoc.CreateNode(XmlNodeType.Element, SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace);

        //Se crea un nodo xml (NodoDetalle) q contendra el texto del error
        XmlNode _NodoDetalle = _undoc.CreateNode(XmlNodeType.Element, "Error", "");
        _NodoDetalle.InnerText = ex.Message;
        _NodoError.AppendChild(_NodoDetalle);

        //Creacion manual y lanzamiento de la exception SOAP
        SoapException _MiEx = new SoapException("Error WS", SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, _NodoError);
        throw _MiEx;
    }



    #endregion

}
