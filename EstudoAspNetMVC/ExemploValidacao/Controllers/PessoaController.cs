using ExemploValidacao.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExemploValidacao.Controllers
{
    public class PessoaController : Controller
    {
        public ActionResult Index()
        {
            var pessoa = new Pessoa();
            return View(pessoa);
        }

        [HttpPost]
        public ActionResult Index(Pessoa pessoa)
        {
            //Validações do lado do servidor é aqui, no lado cliente, seria no java script
            //O ideal é que essas validações sejam feitas no cliente, para nao ter o custo de enviar todas as informacoes para o servidor

            #region Validação de uma propriedade do modelo > usado ValidationMessageFor
            //if (string.IsNullOrEmpty(pessoa.Nome))
            //{
            //    ModelState.AddModelError("Nome", "O campo nome é obrigatório.");
            //}
            #endregion

            #region validação do modelo > usado ValidationSummary
            //if (pessoa.Senha != pessoa.ConfirmarSenha)
            //{
            //    ModelState.AddModelError("","As senhas não conferem.");
            //}
            #endregion

            //Aqui é verificado todas as validaçoes do modelo (Pessoa) quando chega no servidor, caso o usuário desative o java script do navegador...
            if (ModelState.IsValid)
            {
                return View("Resultado", pessoa);
            }

            return View(pessoa);
        }

        public ActionResult Resultado(Pessoa pessoa)
        {
            return View(pessoa);
        }

        public ActionResult LoginUnico(string login)
        {
            //Acesso a BD, exemplo de validação no lado do servidor, foi incluido a annotation [Remote] na propriedade Login
            //Mesmo com o Jquery.Validate, foi executado a validação no servidor
            //É disparado via Ajax para o servidor, maneira mais rápida.
            var bancoDeNomesDeExemplo = new Collection<string>
            {
                "Rafael",
                "Elen"
            };
            return Json(bancoDeNomesDeExemplo.All(x => x.ToLower() != login.ToLower()), JsonRequestBehavior.AllowGet);
        }

    }
}
