using Microsoft.AspNet.SignalR;
using System;
using System.Threading.Tasks;

namespace ChatAula.Hubs
{
    public class ChatHub : Hub
    {
        static int qtde = 0;

        public override Task OnDisconnected(bool stopCalled)
        {
            qtde--;
            Clients.All.quantidade(qtde);
            return base.OnDisconnected(stopCalled);            
        }

        public void Entrar(string name)
        {
            Clients.All.join(name, DateTime.UtcNow.AddHours(-3).ToString("HH:mm"));
            qtde++;
            Clients.All.quantidade(qtde);
        }

        public void Sair(string name)
        {
            Clients.All.logoff(name, DateTime.UtcNow.AddHours(-3).ToString("HH:mm"));
            qtde--;
            Clients.All.quantidade(qtde);
        }

        public void EnviarMensagem(string msg, string name)
        {
            Clients.All.receberMensagem(msg, name, DateTime.UtcNow.AddHours(-3).ToString("HH:mm"));
        }
    }
}