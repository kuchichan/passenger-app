using System.Reflection;
using Autofac;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Users;

namespace Passenger.Infrastructure.IoC.Modules
{
    public class CommandModule : Autofac.Module
    {
        
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandModule)
                        .GetTypeInfo()
                        .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                    .AsClosedTypesOf(typeof(ICommandHandler<>))
                    .InstancePerLifetimeScope();

            builder.RegisterType<CommandDispatcher>()
                    .As<ICommandDispatcher>()
                    .InstancePerLifetimeScope();
        }
    }
}