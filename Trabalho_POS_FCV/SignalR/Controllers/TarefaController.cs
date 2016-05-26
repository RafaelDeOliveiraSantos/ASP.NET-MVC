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
    public class TarefaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

		//****** template t4 ******
		IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<TarefaHub>();
		//****** template t4 ******

        // GET: /Tarefa/
        public async Task<ActionResult> Index()
        {
            var tarefamodels = db.TarefaModels.Include(t => t.Pessoa);
            return View(await tarefamodels.ToListAsync());
        }

        // GET: /Tarefa/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TarefaModel tarefamodel = await db.TarefaModels.FindAsync(id);
            if (tarefamodel == null)
            {
                return HttpNotFound();
            }
            return View(tarefamodel);
        }

        // GET: /Tarefa/Create
        public ActionResult Create()
        {
            ViewBag.PessoaModelId = new SelectList(db.PessoaModels, "Id", "Nome");
            return View();
        }

        // POST: /Tarefa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,Nome,Descricao,Done,PessoaModelId")] TarefaModel tarefamodel)
        {
            if (ModelState.IsValid)
            {
                db.TarefaModels.Add(tarefamodel);
                await db.SaveChangesAsync();

                hubContext.Clients.All.todoCreated(@"Cadastro de Tarefa atualizado. Registro incluído.");

                return RedirectToAction("Index");
            }

            ViewBag.PessoaModelId = new SelectList(db.PessoaModels, "Id", "Nome", tarefamodel.PessoaModelId);
            return View(tarefamodel);
        }

        // GET: /Tarefa/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TarefaModel tarefamodel = await db.TarefaModels.FindAsync(id);
            if (tarefamodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.PessoaModelId = new SelectList(db.PessoaModels, "Id", "Nome", tarefamodel.PessoaModelId);
            return View(tarefamodel);
        }

        // POST: /Tarefa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,Nome,Descricao,Done,PessoaModelId")] TarefaModel tarefamodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarefamodel).State = EntityState.Modified;
                await db.SaveChangesAsync();

                hubContext.Clients.All.todoModified(@"Cadastro de Tarefa atualizado. Registro alterado.");

                return RedirectToAction("Index");
            }
            ViewBag.PessoaModelId = new SelectList(db.PessoaModels, "Id", "Nome", tarefamodel.PessoaModelId);
            return View(tarefamodel);
        }

        // GET: /Tarefa/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TarefaModel tarefamodel = await db.TarefaModels.FindAsync(id);
            if (tarefamodel == null)
            {
                return HttpNotFound();
            }
            return View(tarefamodel);
        }

        // POST: /Tarefa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TarefaModel tarefamodel = await db.TarefaModels.FindAsync(id);
            db.TarefaModels.Remove(tarefamodel);
            await db.SaveChangesAsync();

            hubContext.Clients.All.todoDeleted(@"Cadastro de Tarefa atualizado. Registro excluído.");

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
