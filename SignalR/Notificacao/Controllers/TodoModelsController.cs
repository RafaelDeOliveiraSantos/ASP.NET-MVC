using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Notificacao.Models;
using Microsoft.AspNet.SignalR;
using Notificacao.Hubs;

namespace Notificacao.Controllers
{
    [System.Web.Mvc.Authorize]
    public class TodoModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();

        // GET: TodoModels
        public async Task<ActionResult> Index()
        {
            return View(await db.Todos.ToListAsync());
        }

        // GET: TodoModels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoModel todoModel = await db.Todos.FindAsync(id);
            if (todoModel == null)
            {
                return HttpNotFound();
            }
            return View(todoModel);
        }

        // GET: TodoModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TodoModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description,Done")] TodoModel todoModel)
        {
            if (ModelState.IsValid)
            {
                db.Todos.Add(todoModel);
                await db.SaveChangesAsync();

                hubContext.Clients.All.todoCreated($@"O usuário {User.Identity.Name} criou a tarefa {todoModel.Name}");

                return RedirectToAction("Index");
            }

            return View(todoModel);
        }

        // GET: TodoModels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoModel todoModel = await db.Todos.FindAsync(id);
            if (todoModel == null)
            {
                return HttpNotFound();
            }
            return View(todoModel);
        }

        // POST: TodoModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,Done")] TodoModel todoModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(todoModel).State = EntityState.Modified;
                await db.SaveChangesAsync();

                hubContext.Clients.All.todoModified($@"O usuário {User.Identity.Name} alterou a tarefa {todoModel.Name}");

                return RedirectToAction("Index");
            }
            return View(todoModel);
        }

        // GET: TodoModels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoModel todoModel = await db.Todos.FindAsync(id);
            if (todoModel == null)
            {
                return HttpNotFound();
            }
            return View(todoModel);
        }

        // POST: TodoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TodoModel todoModel = await db.Todos.FindAsync(id);
            db.Todos.Remove(todoModel);
            await db.SaveChangesAsync();

            hubContext.Clients.All.todoDeleted($@"O usuário {User.Identity.Name} deletou a tarefa {todoModel.Name}");

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
