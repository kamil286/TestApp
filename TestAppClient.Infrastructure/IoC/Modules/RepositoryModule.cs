using Autofac;
using System.Linq;
using System.Reflection;

namespace TestAppClient.Infrastructure.IoC.Modules
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(RepositoryModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                   .Where(x => x.IsAssignableTo<IRepository>())
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
        }
    }
}
