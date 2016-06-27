using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonServiceLocator.NinjectAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using TreinamentoBenner.Core.InversionOfControl.Modules;

namespace TreinamentoBenner.Core.InversionOfControl
{
    public class IoC
    {
        public IKernel Kernel { get; set; }

        public IoC()
        {
            Kernel = GetNinjectModules();
            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(Kernel));
        }

        private IKernel GetNinjectModules()
        {
            return new StandardKernel(
                new ServiceNinjectModule(),
                new RepositoryNinjectModule(),
                new InfrastrucutureNinjectModule()
            );
        }
    }
}
