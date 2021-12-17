using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KittenGeneratorService.Infrastructure.Domain.User
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<KittenGeneratorService.Domain.Entities.User>
    {
        internal const string TABLE_USER = "User";

        public void Configure(EntityTypeBuilder<KittenGeneratorService.Domain.Entities.User> builder)
        {
            builder.ToTable(TABLE_USER);
            builder.HasKey(nameof(KittenGeneratorService.Domain.Entities.User.Id));
            builder.HasIndex(e => e.Username).IsUnique();
            builder.HasIndex(e => e.Email).IsUnique();
        }
    }
}
