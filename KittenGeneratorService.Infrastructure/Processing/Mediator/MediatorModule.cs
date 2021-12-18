using Autofac;
using KittenGeneratorService.Application.Commands;
using MediatR;
using System.Reflection;

namespace KittenGeneratorService.Infrastructure.Processing.Mediator
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder
            //    .RegisterType<Mediator>()
            //    .As<IMediator>()
            //    .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

            // request & notification handlers
            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            builder.RegisterAssemblyTypes(typeof(CreateUser).GetTypeInfo().Assembly).AsImplementedInterfaces();
            builder.RegisterGeneric(typeof(CommandValidationBehavior<,>)).As(typeof(IPipelineBehavior<,>));
        }
    }
}
