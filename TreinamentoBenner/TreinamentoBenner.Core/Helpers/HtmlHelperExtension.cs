using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TreinamentoBenner.Core.Helpers
{
    public static class HtmlHelperExtension
    {
        public static MvcHtmlString LinkVoltar(this HtmlHelper html, string idLink, string textLink = "Voltar")
        {
            var strLink = string.Format(
                @"<a id =""{0}"" href=""javascript:history.go(-1);"">{1}</a>",
                idLink,
                textLink
            );

            return new MvcHtmlString(strLink);
        }
    }
}
