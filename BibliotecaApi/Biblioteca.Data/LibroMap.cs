using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Data
{
    public class LibroMap
    {
        public LibroMap(EntityTypeBuilder<Libro> entityBuilder)
        {
            entityBuilder.HasKey(t => t.IdLibro);
            entityBuilder.Property(t => t.Titulo);
            entityBuilder.Property(t => t.FechaLanzamiento);
            entityBuilder.Property(t => t.Descripcion);
            entityBuilder.Property(t => t.Categoria);

        }
    }
}
