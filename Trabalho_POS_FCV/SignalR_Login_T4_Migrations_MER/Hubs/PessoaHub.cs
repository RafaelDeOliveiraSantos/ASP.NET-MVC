using System.Linq;
using Microsoft.AspNet.SignalR;
using SignalR.Models;
using System;

namespace SignalR.Hubs
{
    public class PessoaHub : Hub
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Refresh()
        {            
            Clients.Caller.Refresh(db.PessoaModels.ToList());            
        }        
    }
}