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
    public class CarrosController : ApiController
    {
        private Contexto db = new Contexto();

        // GET: api/Carros
        [Route("api/carro/lista")]
        public IQueryable<CarrosModel> GetCarros()
        {
            return db.Carros.Include(i => i.Pessoa);
        }

        // GET: api/Carros/5
        [ResponseType(typeof(CarrosModel))]
        [Route("api/carro/pesquisa/{id}")]
        public async Task<IHttpActionResult> GetCarrosModel(int id)
        {
            CarrosModel carrosModel = await db.Carros.FindAsync(id);
            if (carrosModel == null)
            {
                return NotFound();
            }

            return Ok(carrosModel);
        }

        // PUT: api/Carros/5
        [ResponseType(typeof(void))]
        [Route("api/carro/alterar/{id}")]
        public async Task<IHttpActionResult> PutCarrosModel(int id, CarrosModel carrosModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carrosModel.Id)
            {
                return BadRequest();
            }

            db.Entry(carrosModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarrosModelExists(id))
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

        // POST: api/Carros
        [ResponseType(typeof(CarrosModel))]
        [Route("api/carro/novo")]
        public async Task<IHttpActionResult> PostCarrosModel(CarrosModel carrosModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Carros.Add(carrosModel);
            await db.SaveChangesAsync();

            return Ok(carrosModel);
        }

        // DELETE: api/Carros/5
        [ResponseType(typeof(CarrosModel))]
        [Route("api/carro/excluir/{Id}")]
        public async Task<IHttpActionResult> DeleteCarrosModel(int id)
        {
            CarrosModel carrosModel = await db.Carros.FindAsync(id);
            if (carrosModel == null)
            {
                return NotFound();
            }

            db.Carros.Remove(carrosModel);
            await db.SaveChangesAsync();

            return Ok(carrosModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarrosModelExists(int id)
        {
            return db.Carros.Count(e => e.Id == id) > 0;
        }
    }
}