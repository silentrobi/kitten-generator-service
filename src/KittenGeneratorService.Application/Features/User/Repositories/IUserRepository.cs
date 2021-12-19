using KittenGeneratorService.Application.SeedWork;
using KittenGeneratorService.Domain.Entities;
using System;

namespace KittenGeneratorService.Application.Features.User.Repositories
{
    public interface IUserRepository : ICrudRepository<Domain.Entities.User, Guid>
    {
        Domain.Entities.User FindByUsernameAndPassword(string username, string password);
    }
}
