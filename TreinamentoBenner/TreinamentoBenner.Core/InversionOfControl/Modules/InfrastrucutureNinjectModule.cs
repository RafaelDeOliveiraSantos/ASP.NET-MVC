using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using TreinamentoBenner.Core.Model;

namespace TreinamentoBenner.Core.InversionOfControl.Modules
{
    public class InfrastrucutureNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<TreinamentoBennerContext>().ToSelf();
        }
    }
}
