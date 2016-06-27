using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using TreinamentoBenner.Core.Service;
using TreinamentoBenner.Core.Service.Interfaces;

namespace TreinamentoBenner.Core.InversionOfControl.Modules
{
    public class ServiceNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPessoaService>().To<PessoaService>();
            Bind<ICidadeService>().To<CidadeService>();
            Bind<ITelefoneService>().To<TelefoneService>();
            Bind<IProdutoService>().To<ProdutoService>();
        }
    }
}
