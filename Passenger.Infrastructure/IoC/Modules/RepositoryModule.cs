using System.Reflection;
using Autofac;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Repositories;

namespace Passenger.Infrastructure.IoC.Modules
{
    public class RepositoryModule: Autofac.Module
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