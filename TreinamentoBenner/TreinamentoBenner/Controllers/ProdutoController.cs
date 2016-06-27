using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TreinamentoBenner.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return PartialView();
        }

        public ActionResult Delete()
        {
            return PartialView();
        }

        public ActionResult Edit()
        {
            return PartialView();
        }
    }
}