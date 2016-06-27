using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreinamentoBenner.Filters;

namespace TreinamentoBenner.Controllers
{
    //[LogActionFilter]
    public class HistoricoController : Controller
    {
        //[LogActionFilter]
        public ActionResult Index()
        {
            ViewBag.Nome = "Danilo";
            ViewData["OutroNome"] = "Bizo";
            TempData["Mensagem"] = "olá";

            var date = DateTime.Now;
            return View(date);
        }

        public ActionResult NotFound()
        {
            return HttpNotFound();
        }

        public ActionResult Redirecionar()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult RedirecionarPermanente()
        {
            return RedirectToActionPermanent("Index", "Home");
        }

        public string Detalhe(int id)
        {
            return id + "";
        }

        //QueryString com parâmetro
        public string Busca(string genero)
        {
            return genero;
        }

        //QueryString sem parâmetro
        public string Busca1()
        {
            return Request.QueryString["genero"];
        }

        public string Arquivo(DateTime data)
        {
            return string.Format("A data é {0:D}", data);
        }
    }
}