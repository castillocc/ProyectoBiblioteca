using Biblioteca.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Data.Mapper
{
    public class AspNetUserRolesMap
    {
        public AspNetUserRolesMap(EntityTypeBuilder<AspNetUserRoles> entityBuilder)
        {
            entityBuilder.HasKey(e => new { e.UserId, e.RoleId });

            entityBuilder.HasIndex(e => e.RoleId);

            entityBuilder.HasIndex(e => e.UserId);

            entityBuilder.HasOne(d => d.Role)
                .WithMany(p => p.AspNetUserRoles)
                .HasForeignKey(d => d.RoleId);

            entityBuilder.HasOne(d => d.User)
                .WithMany(p => p.AspNetUserRoles)
                .HasForeignKey(d => d.UserId);
        }
    }
}
