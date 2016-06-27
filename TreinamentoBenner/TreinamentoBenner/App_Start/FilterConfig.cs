using System.Web;
using System.Web.Mvc;
using TreinamentoBenner.Filters;

namespace TreinamentoBenner
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LogActionFilter());
            //filters.Add(new AuthorizeAttribute());
        }
    }
}
