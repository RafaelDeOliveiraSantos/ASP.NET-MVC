using PostGetModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostGetModel.Controllers
{
    public class HomeController : Controller
    {
        //Por default as Actions respondem por métodos GET, portanto nao precisa anotar [HttpGet]        
        public ActionResult Index()
        {
            var pessoa = new Pessoa
            {
                PessoaId = 1,
                Nome = "Rafa Santos",
                Twitter = "@RafaelSantos"
            };

            //Existe 3 formas de passar dados para a View, usando ViewBag, ViewData ou View Tipada
            //ViewBag é uma forma melhorada do ViewData

            //ViewData["PessoaId"] = pessoa.PessoaId;
            //ViewData["Nome"] = pessoa.Nome;
            //ViewData["Twitter"] = pessoa.Twitter;

            //ViewBag.PessoaId = pessoa.PessoaId;
            //ViewBag.Nome = pessoa.Nome;
            //ViewBag.Twitter = pessoa.Twitter;

            //View Tipada, logo a View tem que ser tipada!!!
            return View(pessoa);
        }

        #region 3 formas de receber dados dentro da action

        /// <summary>
        /// Recebe todos as propriedades do formulaeio por parametro
        /// </summary>
        /// <param name="PessoaId"></param>
        /// <param name="Nome"></param>
        /// <param name="Twitter"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ListaRecebePorParametro(int PessoaId, string Nome, string Twitter)
        {
            ViewData["PessoaId"] = PessoaId;
            ViewData["Nome"] = Nome;
            ViewData["Twitter"] = Twitter;

            return View();
        }

        /// <summary>
        /// o parâmetro do tipo FormColletion representa a colecao de dados do formulario
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ListaRecebePorFormCollection(FormCollection form)
        {
            ViewData["PessoaId"] = form["PessoaId"];
            ViewData["Nome"] = form["Nome"];
            ViewData["Twitter"] = form["Twitter"];

            return View();
        }

        /// <summary>
        ///  Quando a view é tipada, pode receber o tipo da View
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Lista(Pessoa pessoa)
        {
            return View(pessoa);
        }
        #endregion



    }
}
