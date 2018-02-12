using Biblioteca.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Data.Mapper
{
    public class TemaMap
    {
        public TemaMap(EntityTypeBuilder<Tema> entityBuilder)
        {
            entityBuilder.HasKey(e => e.IdTema);

            entityBuilder.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
