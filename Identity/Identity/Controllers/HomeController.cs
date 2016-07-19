using Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Identity.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult TesteDecimal()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TesteDecimal(TesteModelBinder model)
        {
            if(ModelState.IsValid)
            {
                return View(model);
            }
            return View(model);
        }
    }
}