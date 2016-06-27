using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TreinamentoBenner.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public string Index()
        {
            return DateTime.Now.ToString();
        }
    }
}