using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TreinamentoBenner.Core.Model;
using TreinamentoBenner.Core.Service.Interfaces;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace TreinamentoBenner.Controllers
{
    public class TelefoneController : Controller
    {
        private readonly ITelefoneService _telefoneService;

        public TelefoneController(ITelefoneService telefoneService)
        {
            _telefoneService = telefoneService;
        }

        public ActionResult DialogForm()
        {
            return PartialView(new Telefone());
        }

        [HttpPost]
        public ActionResult AjaxAdd(Telefone telefone)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    Message = "Telefone inserido com sucesso!",
                    Status = true
                });
            }

            _telefoneService.Save(telefone);
            return Json(new {Message = "Telefone inserido com sucesso!", Status = true});
        }

        public JsonResult AjaxRemove(int id)
        {
            _telefoneService.Delete(id);
            return Json(new
            {
                Message = "Telefone excluído com sucesso!",
                Status = true
            }, JsonRequestBehavior.AllowGet);
        }

        // GET: Telefone
        public ActionResult AjaxList(int id)
        {
            return PartialView(_telefoneService.ListarPorPessoa(id));
        }
    }
}