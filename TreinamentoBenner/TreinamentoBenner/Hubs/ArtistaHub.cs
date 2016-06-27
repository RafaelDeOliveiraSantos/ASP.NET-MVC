using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.EnterpriseServices;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using TreinamentoBenner.Core.Context;
using TreinamentoBenner.Core.Model;

namespace TreinamentoBenner.Hubs
{
    public class ArtistaHub : Hub
    {
        private readonly LojaContext _db = new LojaContext();
        public static readonly ConcurrentDictionary<string, int> Locks = new ConcurrentDictionary<string,int>();
        private static readonly object Lock = new object();

        public override async Task OnConnected()
        {
            var artistas = _db.Artistas.OrderBy(q => q.Nome);

            await Clients.Caller.all(artistas);
            await Clients.Caller.allLocks(Locks);
        }

        public override async Task OnReconnected()
        {
            await OnConnected();
        }

        public override async Task OnDisconnected(bool stopCalled)
        {
            int removed;
            if (Locks.TryRemove(Context.ConnectionId, out removed))
            {
                await Clients.All.allLocks(Locks.Values);
            }
        }

        public void TakeLock(Artista value)
        {
            lock (Lock)
            {
                if (Locks.Values.Any(id => value.Id == id))
                {
                    return;
                }
            }

            Locks.AddOrUpdate(Context.ConnectionId, value.Id, (key, oldValue) => value.Id);
            Clients.Caller.takeLockSuccess(value);
            Clients.All.allLocks(Locks.Values);
        }

        public void Add(Artista value)
        {
            _db.Artistas.Add(value);
            _db.SaveChanges();
            Clients.All.add(value);
        }

        public void Delete(Artista value)
        {
            _db.Artistas.Remove(_db.Artistas.Find(value.Id));
            _db.SaveChanges();
            Clients.All.delete(value);
        }

        public void Update(Artista value)
        {
            _db.Artistas.AddOrUpdate(value);
            _db.SaveChanges();
            Clients.All.update(value);

            int removed;
            Locks.TryRemove(Context.ConnectionId, out removed);
            Clients.All.allLocks(Locks.Values);
        }
    }
}