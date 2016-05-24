using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using SignalR.Models;

namespace SignalR.Hubs
{
    public class NotificationHub : Hub
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Hello()
        {            
            Clients.Caller.Refresh(db.PessoaModels.ToList());
        }
    }
}