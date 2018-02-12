using Biblioteca.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Data.Mapper
{
    public class AutorMap
    {
        public AutorMap(EntityTypeBuilder<Autor> entityBuilder) {
            entityBuilder.HasKey(e => e.IdAutor);

            entityBuilder.Property(e => e.IdAutor).ValueGeneratedNever();

            entityBuilder.Property(e => e.NombreAutor)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
