using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreinamentoBener.Tests.Services;
using TreinamentoBener.Tests.Stub;
using TreinamentoBenner.Controllers;
using TreinamentoBenner.Core.Model;
using TreinamentoBenner.Core.Service.Interfaces;

namespace TreinamentoBener.Tests.Controllers
{
    [TestClass]
    public class PessoaControllerTest
    {
        private PessoaController _controller;
        private IPessoaService _pessoaService;

        [ClassInitialize]
        public static void Init(TestContext context) { }

        [TestInitialize]
        public void Setup()
        {
            _pessoaService = new InMemoryPessoaService();
            _controller = new PessoaController(_pessoaService, new InMemoryCidadeService());
            _controller.ControllerContext = new ControllerContext(new RequestContext(), _controller);
        }

        [TestMethod]
        public void Create_Get_Pessoa()
        {
            var result = _controller.Create() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(Pessoa));
        }

        [TestMethod]
        public void Create_Post_PutsValidPessoaIntoRepository()
        {
            var pessoa = PessoaStub.Valido();
            var result = _controller.Create(pessoa) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, pessoa.Id);
        }

        [TestMethod]
        public void Create_Post_PutsInvalidPessoaIntoRepository()
        {
            var pessoa = PessoaStub.Invalido();
            _controller.ModelState.AddModelError("","");
            var result = _controller.Create(pessoa) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsFalse(_controller.ModelState.IsValid);
            Assert.AreEqual(0, pessoa.Id);
        }

        [TestMethod]
        public void Create_Post_EditPessoaWithId1()
        {
            _pessoaService.Add(PessoaStub.Valido());

            const int idPessoa = 1;
            var result = _controller.Create(idPessoa) as ViewResult;
            
            Assert.IsNotNull(result);
            Assert.AreEqual(idPessoa, ((Pessoa)result.Model).Id);
        }

        [TestMethod]
        public void Delete_Post_Pessoa()
        {
            var pessoa = PessoaStub.Valido();
            _pessoaService.Save(pessoa);

            var result = _controller.Delete(pessoa.Id) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Index_Get_AsksForIndexView()
        {
            var result = _controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(IEnumerable<Pessoa>));
        }

        [TestCleanup]
        public void CleanUp() { }
    }
}
