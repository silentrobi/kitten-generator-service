using Autofac;
using KittenGeneratorService.Application.Repositories;
using KittenGeneratorService.Application.SeedWork;
using KittenGeneratorService.Infrastructure.Domain.SeedWork;
using KittenGeneratorService.Infrastructure.Domain.User;

namespace KittenGeneratorService.Infrastructure.Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
