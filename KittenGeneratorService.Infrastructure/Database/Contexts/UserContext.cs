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

            modelBuilder.HasPostgresExtension("uuid-ossp");

            //modelBuilder.Entity<User>(
            //    p =>
            //    {
            //        p.HasKey(nameof(User.Id));
            //        p.HasIndex(e => e.Username).IsUnique();
            //        p.HasIndex(e => e.Email).IsUnique();
            //    });
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserContext).Assembly);
        }
    }
}
