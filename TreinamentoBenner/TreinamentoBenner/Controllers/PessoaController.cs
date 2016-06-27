using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreinamentoBenner.Core.Model;
using TreinamentoBenner.Core.Service.Interfaces;

namespace TreinamentoBenner.Controllers
{
    public class PessoaController : Controller
    {
        private IPessoaService _pessoaService;
        private ICidadeService _cidadeService;

        public PessoaController(IPessoaService pessoaService, ICidadeService cidadeService)
        {
            _pessoaService = pessoaService;
            _cidadeService = cidadeService;
        }

        // GET: Pessoa
        public ActionResult Index()
        {
            return View(_pessoaService.All(true));
        }

        public ActionResult Create(int id = 0)
        {
            var pessoa = _pessoaService.Find(id) ?? new Pessoa();
            Dropdown(pessoa);
            return View(pessoa);
        }

        [HttpPost]
        public ActionResult Create(Pessoa pessoa)
        {
            if (!ModelState.IsValid)
            {
                Dropdown(pessoa);
                return View(pessoa);
            }
            var isNew = pessoa.Id == 0;

            _pessoaService.Save(pessoa);
            return isNew ? RedirectToAction("Create", new {pessoa.Id}) : RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _pessoaService.Delete(id);
            return RedirectToAction("Index");
        }

        private void Dropdown(Pessoa pessoa)
        {
            var uf = pessoa.Cidade?.Uf;
            ViewBag.Ufs = new SelectList(_cidadeService.ListarEstados(), uf);
            ViewBag.IdCidade = new SelectList(_cidadeService.ListarPorEstado(uf), "Id", "Nome", pessoa.Cidade);
        }
    }
}