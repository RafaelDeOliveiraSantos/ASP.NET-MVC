using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Notificacao.Startup))]
namespace Notificacao
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
