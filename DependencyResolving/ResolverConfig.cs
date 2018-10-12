using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SystemMonitor.BLL.Service;
using SystemMonitor.BLL.Interface;

using Ninject;


namespace DependencyResolving
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IService>().To<Service>();
        }
    }
}
