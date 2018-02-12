using Biblioteca.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Data.Mapper
{
    public class AspNetRolesMap
    {
        public AspNetRolesMap(EntityTypeBuilder<AspNetRoles> entityBuilder) {
            entityBuilder.HasIndex(e => e.NormalizedName);

            entityBuilder.Property(e => e.Id).ValueGeneratedNever();

            entityBuilder.Property(e => e.Name).HasMaxLength(256);

            entityBuilder.Property(e => e.NormalizedName).HasMaxLength(256);

        }
    }
}
