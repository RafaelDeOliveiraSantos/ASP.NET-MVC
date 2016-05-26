using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
//****** template t4 ******
using SignalR.Models;
using Microsoft.AspNet.SignalR;
using SignalR.Hubs;
//****** template t4 ******
using SignalR.Models;

namespace SignalR.Controllers
{
	//****** template t4 ******
	[System.Web.Mvc.Authorize]
	//****** template t4 ******	
    public class PessoaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

		//****** template t4 ******
		IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<PessoaHub>();
		//****** template t4 ******

        // GET: /Pessoa/
        public async Task<ActionResult> Index()
        {
            return View(await db.PessoaModels.ToListAsync());
        }

        // GET: /Pessoa/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaModel pessoamodel = await db.PessoaModels.FindAsync(id);
            if (pessoamodel == null)
            {
                return HttpNotFound();
            }
            return View(pessoamodel);
        }

        // GET: /Pessoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Pessoa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,Nome,Idade,Nacionalidade,EstadoCivil,Inativo")] PessoaModel pessoamodel)
        {
            if (ModelState.IsValid)
            {
                db.PessoaModels.Add(pessoamodel);
                await db.SaveChangesAsync();

                hubContext.Clients.All.todoCreated(@"Cadastro de Pessoa atualizado. Registro incluído.");

                return RedirectToAction("Index");
            }

            return View(pessoamodel);
        }

        // GET: /Pessoa/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaModel pessoamodel = await db.PessoaModels.FindAsync(id);
            if (pessoamodel == null)
            {
                return HttpNotFound();
            }
            return View(pessoamodel);
        }

        // POST: /Pessoa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,Nome,Idade,Nacionalidade,EstadoCivil,Inativo")] PessoaModel pessoamodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoamodel).State = EntityState.Modified;
                await db.SaveChangesAsync();

                hubContext.Clients.All.todoModified(@"Cadastro de Pessoa atualizado. Registro alterado.");

                return RedirectToAction("Index");
            }
            return View(pessoamodel);
        }

        // GET: /Pessoa/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaModel pessoamodel = await db.PessoaModels.FindAsync(id);
            if (pessoamodel == null)
            {
                return HttpNotFound();
            }
            return View(pessoamodel);
        }

        // POST: /Pessoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PessoaModel pessoamodel = await db.PessoaModels.FindAsync(id);
            db.PessoaModels.Remove(pessoamodel);
            await db.SaveChangesAsync();

            hubContext.Clients.All.todoDeleted(@"Cadastro de Pessoa atualizado. Registro excluído.");

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
