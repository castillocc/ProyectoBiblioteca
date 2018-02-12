using Biblioteca.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Data.Mapper
{
    public class AspNetUserClaimsMap
    {
        public AspNetUserClaimsMap(EntityTypeBuilder<AspNetUserClaims> entityBuilder)
        {
            entityBuilder.HasIndex(e => e.UserId);

            entityBuilder.Property(e => e.UserId).IsRequired();

            entityBuilder.HasOne(d => d.User)
                .WithMany(p => p.AspNetUserClaims)
                .HasForeignKey(d => d.UserId);
        }
    }
}
