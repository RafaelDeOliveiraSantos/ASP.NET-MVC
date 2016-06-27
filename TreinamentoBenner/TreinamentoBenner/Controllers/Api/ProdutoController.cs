using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TreinamentoBenner.Core.Model;
using TreinamentoBenner.Core.Repository;
using TreinamentoBenner.Core.Service;
using TreinamentoBenner.Core.Service.Interfaces;

namespace TreinamentoBenner.Controllers.Api
{
    public class ProdutoController : ApiController
    {
        private readonly IProdutoService _produtoService = new ProdutoService(new ProdutoRepository());

        // GET: Produto
        public IQueryable<Produto> Get()
        {
            return _produtoService.All(true);
        }

        public Produto Get(int id)
        {
            return _produtoService.Find(id);
        }

        [ResponseType(typeof(Produto))]
        public IHttpActionResult Put(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _produtoService.Save(produto);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(Produto))]
        public IHttpActionResult Post(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _produtoService.Save(produto);
            return CreatedAtRoute("DefaultApi", new {id = produto.Id}, produto);
        }

        public IHttpActionResult Delete(int id)
        {
            var produto = _produtoService.Find(id);
            if (produto == null)
                return NotFound();

            _produtoService.Delete(produto);
            return Ok(produto);
        }
    }
}