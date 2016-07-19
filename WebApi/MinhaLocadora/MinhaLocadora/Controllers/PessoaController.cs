using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MinhaLocadora.Models;

namespace MinhaLocadora.Controllers
{
    public class PessoaController : ApiController
    {
        private Contexto db = new Contexto();

        // GET: api/Pessoa
        [Route("api/pessoa/lista")]
        public IQueryable<PessoaModel> GetPessoas()
        {
            return db.Pessoas;
        }

        // GET: api/Pessoa/5
        [ResponseType(typeof(PessoaModel))]
        [Route("api/pessoa/pesquisa/{id}")]
        public async Task<IHttpActionResult> GetPessoaModel(int id)
        {
            PessoaModel pessoaModel = await db.Pessoas.FindAsync(id);
            if (pessoaModel == null)
            {
                return NotFound();
            }

            return Ok(pessoaModel);
        }

        // PUT: api/Pessoa/5
        [ResponseType(typeof(void))]
        [Route("api/pessoa/alterar/{id}")]
        public async Task<IHttpActionResult> PutPessoaModel(int id, PessoaModel pessoaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pessoaModel.Id)
            {
                return BadRequest();
            }

            db.Entry(pessoaModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Pessoa
        [ResponseType(typeof(PessoaModel))]
        [Route("api/pessoa/novo")]
        public async Task<IHttpActionResult> PostPessoaModel(PessoaModel pessoaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pessoas.Add(pessoaModel);
            await db.SaveChangesAsync();

            return Ok(pessoaModel);
        }

        // DELETE: api/Pessoa/5
        [ResponseType(typeof(PessoaModel))]
        [Route("api/pessoa/excluir/{Id}")]
        public async Task<IHttpActionResult> DeletePessoaModel(int id)
        {
            PessoaModel pessoaModel = await db.Pessoas.FindAsync(id);
            if (pessoaModel == null)
            {
                return NotFound();
            }

            db.Pessoas.Remove(pessoaModel);
            await db.SaveChangesAsync();

            return Ok(pessoaModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PessoaModelExists(int id)
        {
            return db.Pessoas.Count(e => e.Id == id) > 0;
        }
    }
}