using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace TreinamentoBenner.Filters
{
    public class LogActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log(filterContext.RouteData);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log(filterContext.RouteData);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Log(filterContext.RouteData);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Log(filterContext.RouteData);
        }

        private static void Log(RouteData routeData, [CallerMemberName] string methodName = "")
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = string.Format("{0} controller: {1} action: {2}", methodName, controllerName, actionName);
            Debug.WriteLine(message, "Action Filter Log");
        }
    }

}
