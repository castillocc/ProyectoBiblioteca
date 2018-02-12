using Biblioteca.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Data.Mapper    
{
    public class EditorialMap
    {
        public EditorialMap(EntityTypeBuilder<AspNetUserClaims> entityBuilder)
        {
            entityBuilder.HasKey(e => e.IdEditorial);

            entityBuilder.Property(e => e.IdEditorial).ValueGeneratedNever();

            entityBuilder.Property(e => e.NombreEditorial)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
