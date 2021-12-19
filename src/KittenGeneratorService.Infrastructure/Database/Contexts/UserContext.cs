using KittenGeneratorService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KittenGeneratorService.Infrastructure.Database.Contexts
{
    public class UserContext : DbContext
    {
        internal const string TABLE_USER = "User";
        public UserContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserContext).Assembly);
        }
    }
}
