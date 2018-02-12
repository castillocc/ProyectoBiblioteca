using Biblioteca.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Data.Mapper
{
    public class LibroMap
    {
        public LibroMap(EntityTypeBuilder<Libro> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Idlibro);

            entityBuilder.Property(e => e.Isbn);

            entityBuilder.Property(e => e.Titulo)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entityBuilder.HasOne(d => d.IdAutorNavigation)
                .WithMany(p => p.Libro)
                .HasForeignKey(d => d.IdAutor);

            entityBuilder.HasOne(d => d.IdEditorialNavigation)
                .WithMany(p => p.Libro)
                .HasForeignKey(d => d.IdEditorial);

            entityBuilder.HasOne(d => d.IdTemaNavigation)
                .WithMany(p => p.Libro)
                .HasForeignKey(d => d.IdTema);

        }
    }
}
