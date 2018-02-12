using Biblioteca.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Data.Mapper
{
    public class AspNetUserLoginsMap
    {
        public AspNetUserLoginsMap(EntityTypeBuilder<AspNetUserLogins> entityBuilder)
        {
            entityBuilder.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entityBuilder.HasIndex(e => e.UserId);

            entityBuilder.Property(e => e.UserId).IsRequired();

            entityBuilder.HasOne(d => d.User)
                .WithMany(p => p.AspNetUserLogins)
                .HasForeignKey(d => d.UserId);
        }
    }
}
