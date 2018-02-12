using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Data.Models
{
    public class AspNetUsersMap
    {
        public AspNetUsersMap(EntityTypeBuilder<AspNetUsers> entityBuilder)
        {
            entityBuilder.HasIndex(e => e.NormalizedEmail);

            entityBuilder.HasIndex(e => e.NormalizedUserName)
                .IsUnique();

            entityBuilder.Property(e => e.Id).ValueGeneratedNever();

            entityBuilder.Property(e => e.Email).HasMaxLength(256);

            entityBuilder.Property(e => e.NormalizedEmail).HasMaxLength(256);

            entityBuilder.Property(e => e.NormalizedUserName).HasMaxLength(256);

            entityBuilder.Property(e => e.UserName).HasMaxLength(256);

        }
    }
}
