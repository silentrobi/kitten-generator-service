using KittenGeneratorService.Application.Repositories;
using KittenGeneratorService.Infrastructure.Database.Contexts;
using KittenGeneratorService.Infrastructure.Domain.SeedWork;
using System;
using System.Linq;

namespace KittenGeneratorService.Infrastructure.Domain.User
{
    public class UserRepository : CrudRepository<UserContext, KittenGeneratorService.Domain.Entities.User, Guid>, IUserRepository
    {
        protected readonly UserContext _context;

        public UserRepository(UserContext context) : base(context)
        {
            _context = context;
        }

        public KittenGeneratorService.Domain.Entities.User FindByUsernameAndPassword(string username, string password)
        {
            return _context.Users.Where(x => x.Username.Equals(username.Trim()) && x.Password.Equals(password.Trim())).FirstOrDefault();
        }
    }
}
