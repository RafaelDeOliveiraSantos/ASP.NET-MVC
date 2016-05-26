using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using SignalR.Models;

namespace SignalR.Hubs
{
    public class TarefaHub : Hub
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Refresh()
        {
            Clients.Caller.Refresh(db.TarefaModels.ToList());
        }

        public void Done(int id)
        {
            try
            {
                var model = db.TarefaModels.Find(id);

                model.Done = true;

                db.SaveChanges();

                Clients.Others.todoDone(@"Tarefa Concluída.");
                Clients.All.done(id);
            }
            catch (Exception ex)
            {
                Clients
                    .Caller
                    .error(
                        string.IsNullOrWhiteSpace(ex.Message)
                        ? ex.InnerException.Message
                        : ex.Message);
            }
        }
    }
}