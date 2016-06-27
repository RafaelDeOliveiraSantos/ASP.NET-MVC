using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TreinamentoBenner.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            SetCulture(Request);
            base.OnActionExecuting(filterContext);
        }

        private void SetCulture(HttpRequestBase request)
        {
            if(request?.UserLanguages == null) return;
            if(request.UserLanguages.Length == 0) return;

            var cultureName = request.UserLanguages[0];
            SetCulture(cultureName);
        }

        private void SetCulture(string cultureName)
        {
            Thread.CurrentThread.CurrentCulture = 
                Thread.CurrentThread.CurrentUICulture = 
                CultureInfo.CreateSpecificCulture(cultureName);
        }
    }
}
