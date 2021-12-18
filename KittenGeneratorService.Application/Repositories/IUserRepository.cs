using KittenGeneratorService.Application.SeedWork;
using KittenGeneratorService.Domain.Entities;
using System;

namespace KittenGeneratorService.Application.Repositories
{
    public interface IUserRepository : ICrudRepository<User, Guid>
    {
    }
}
