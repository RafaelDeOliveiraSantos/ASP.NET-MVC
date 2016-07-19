using Owin;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(ChatAula.Startup))]
namespace ChatAula
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}