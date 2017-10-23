using Sentio.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Sentio.MixedService.SOAP
{
    /// <summary>
    /// Summary description for SentioSOAP
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SentioSOAP : System.Web.Services.WebService
    {

        [LoggingAspect]
        [WebMethod]
        public int Fibonacci(int N)
        {
            return ServiceLogic.Fibonacci(N);
        }

        [LoggingAspect]
        [WebMethod]
        public string XmlToJson(string xml)
        {
            return ServiceLogic.XmlToJson(xml);
        }
    }
}
