using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using TreinamentoBenner.Core.Repository;
using TreinamentoBenner.Core.Repository.Interfaces;

namespace TreinamentoBenner.Core.InversionOfControl.Modules
{
    public class RepositoryNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPessoaRepository>().To<PessoaRepository>();
            Bind<ICidadeRepository>().To<CidadeRepository>();
            Bind<ITelefoneRepository>().To<TelefoneRepository>();
            Bind<IProdutoRepository>().To<ProdutoRepository>();

        }
    }
}
