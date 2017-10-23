using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace Sentio.MixedService.Filters
{
    public class ErrorFilter : ExceptionFilterAttribute
    {
        public static ILog log = LogManager.GetLogger(typeof(object));
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var exception = actionExecutedContext.Exception;
            log.Debug("Message :" + exception.Message + "StackTrace :" + exception.StackTrace);
            base.OnException(actionExecutedContext);
        }
    }
}