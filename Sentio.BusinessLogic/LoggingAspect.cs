using log4net;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentio.BusinessLogic
{
    [Serializable]
    public class LoggingAspect : OnMethodBoundaryAspect
    {
        public static ILog log = LogManager.GetLogger(typeof(object));
        public override void OnException(MethodExecutionArgs args)
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Debug(string.Format("Exception handled. Message :{0} | StackTrace : {1}", args.Exception.Message, args.Exception.StackTrace));
            args.FlowBehavior = FlowBehavior.Continue;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Debug(string.Format("The {0} method has been entered.", args.Method.Name));
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Debug(string.Format("The {0} method executed successfully.", args.Method.Name));
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Debug(string.Format("The {0} method has exited.", args.Method.Name));
        }


    }
}
