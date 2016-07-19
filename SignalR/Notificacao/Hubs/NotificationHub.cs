using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Notificacao.Models;

namespace Notificacao.Hubs
{
    public class NotificationHub : Hub
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Refresh()
        {
            Clients.Caller.Refresh(db.Todos.ToList());
        }

        public void Done(int id)
        {
            try
            {
                var model = db.Todos.Find(id);

                model.Done = true;

                db.SaveChanges();

                Clients.Others.todoDone($@"O usuário {Context.User.Identity.Name} concluiu a tarefa {model.Name}");
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