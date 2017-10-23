using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Sentio.MixedService.Filters
{
    public class RequestFilter : ActionFilterAttribute
    {
        public static ILog log = LogManager.GetLogger(typeof(object));
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var url = actionContext.RequestContext.Url.Request.RequestUri;
            log.Debug("Url request sent to : " + url);
            base.OnActionExecuting(actionContext);
        }
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var url = actionExecutedContext.Request.RequestUri;
            log.Debug("Url request executed : " + url);
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}