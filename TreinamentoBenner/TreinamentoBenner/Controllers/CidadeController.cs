using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreinamentoBenner.Core.Model;
using TreinamentoBenner.Core.Service.Interfaces;

namespace TreinamentoBenner.Controllers
{
    public class CidadeController : Controller
    {
        private ICidadeService _cidadeService;

        public CidadeController(ICidadeService cidadeService)
        {
            _cidadeService = cidadeService;
        }

        // GET: Cidade
        public ActionResult AjaxOption(string uf)
        {
            return PartialView(_cidadeService.ListarPorEstado(uf));
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult AjaxList()
        {
            return Json(_cidadeService.All(true), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AjaxAdd(Cidade cidade)
        {
            _cidadeService.Save(cidade);
            return Json(new { Status = true, Model = cidade });
        }

        public JsonResult AjaxRemove(int id)
        {
            _cidadeService.Delete(id);
            return Json(new { Status = true });
        }
    }
}