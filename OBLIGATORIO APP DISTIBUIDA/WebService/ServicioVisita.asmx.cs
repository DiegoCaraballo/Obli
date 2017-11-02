using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using Logica;
using Entidades_Compartidas;
using System.Xml;
using System.Web.Services.Protocols;

namespace WebService
{
    /// <summary>
    /// Descripción breve de ServicioVisita
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]


    public class ServicioVisita : System.Web.Services.WebService
    {
        [WebMethod]
        public List<Visita> ListarVisitas()
        {
            try
            {
                IVisitaLogica Lista = FabricaLogica.getVisitaLogica();
                return Lista.ListaVisitas();
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

    }
}
