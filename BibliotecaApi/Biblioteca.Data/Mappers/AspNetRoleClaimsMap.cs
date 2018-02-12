using Biblioteca.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Biblioteca.Data.Mapper
{
    public class AspNetRoleClaimsMap
    {
        public AspNetRoleClaimsMap(EntityTypeBuilder<AspNetRoleClaims> entityBuilder)
        {
            entityBuilder.HasIndex(e => e.RoleId);

            entityBuilder.Property(e => e.RoleId).IsRequired();

            entityBuilder.HasOne(d => d.Role)
                .WithMany(p => p.AspNetRoleClaims)
                .HasForeignKey(d => d.RoleId);
        }
    }
}
