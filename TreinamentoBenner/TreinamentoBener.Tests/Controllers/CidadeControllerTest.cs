using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreinamentoBener.Tests.Factory;
using TreinamentoBener.Tests.Services;
using TreinamentoBenner.Controllers;
using TreinamentoBenner.Core.Model;
using TreinamentoBenner.Core.Service.Interfaces;

namespace TreinamentoBener.Tests.Controllers
{
    [TestClass]
    public class CidadeControllerTest
    {
        private CidadeController GetCidadeController(ICidadeService cidadeService)
        {
            var controller = new CidadeController(cidadeService);
            controller.ControllerContext = new ControllerContext(new RequestContext(), controller);
            return controller;
        }

        [TestMethod]
        public void Index_Get_AsksForIndexView()
        {
            var controller = GetCidadeController( new InMemoryCidadeService());
            ViewResult result = (ViewResult) controller.Index();
            Assert.IsNotNull(result.ViewName);
        }

        [TestMethod]
        public void Index_Get_RetrievesAllCidadesFromRepository()
        {
            //Arrange
            Cidade cidade1 = CidadeFactory.Create(1, "Maringá", "PR");
            Cidade cidade2 = CidadeFactory.Create(2, "Anta Gorda", "RS");
            var repository = new InMemoryCidadeService();
            repository.Save(cidade1);
            repository.Save(cidade2);
            var controller = GetCidadeController(repository);

            //Act
            JsonResult result = controller.AjaxList();

            //Assert
            var model = ((IEnumerable<Cidade>) result.Data).ToList();
            CollectionAssert.Contains(model, cidade1);
            CollectionAssert.Contains(model, cidade2);
        }

        [TestMethod]
        public void Create_Post_putsValidCidadeIntoRepository()
        {
            InMemoryCidadeService repository = new InMemoryCidadeService();
            CidadeController controller = GetCidadeController(repository);
            Cidade cidade = CidadeFactory.Create(1, "Maringá", "PR");

            controller.AjaxAdd(cidade);

            IEnumerable<Cidade> cidades = repository.All();
            Assert.IsTrue(cidades.Contains(cidade));
        }
    }
}
