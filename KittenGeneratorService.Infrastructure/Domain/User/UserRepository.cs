using KittenGeneratorService.Application.Repositories;
using KittenGeneratorService.Infrastructure.Database.Contexts;
using KittenGeneratorService.Infrastructure.Domain.SeedWork;
using System;

namespace KittenGeneratorService.Infrastructure.Domain.User
{
    public class UserRepository : CrudRepository<UserContext, KittenGeneratorService.Domain.Entities.User, Guid>, IUserRepository
    {
        protected readonly UserContext _context;

        public UserRepository(UserContext context) : base(context)
        {
            _context = context;
        }
    }
}
