using Sentio.BusinessLogic;
using Sentio.MixedService.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sentio.MixedService.Controllers
{
    [RequestFilter]
    [ErrorFilter]
    public class SentioRESTController : ApiController
    {
        [HttpGet]
        public int Fibonacci(int N)
        {
            return ServiceLogic.Fibonacci(N);
        }

        [HttpGet]
        public string XmlToJson(string xml)
        {
            return ServiceLogic.XmlToJson(xml);
        }
    }
}
