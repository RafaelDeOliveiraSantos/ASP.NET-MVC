using System.Linq;
using Microsoft.AspNet.SignalR;
using SignalR.Models;

namespace SignalR.Hubs
{
    public class NotificationHub : Hub
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Refresh()
        {            
            Clients.Caller.Refresh(db.PessoaModels.ToList());
        }
    }
}