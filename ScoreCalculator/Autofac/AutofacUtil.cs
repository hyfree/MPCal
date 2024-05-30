using Autofac;
using Autofac.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.Autofac
{
    public class AutofacUtil
    {
        public static IContainer Container { get; set; }
        public static void Autofac()
        {
            // Create your builder.
            var builder = new ContainerBuilder();

            // Usually you're only interested in exposing the type
            // via its interface:
            //builder.RegisterType<SomeType>();

            //// However, if you want BOTH services (not as common)
            //// you can say so:
            //builder.RegisterType<SomeType>().AsSelf().As<IService>();
            Container = builder.Build();
        }

    }
}
