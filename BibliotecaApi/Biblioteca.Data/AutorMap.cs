using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Data
{
    public class AutorMap
    {
        public AutorMap(EntityTypeBuilder<Autor> entityBuilder) {
            entityBuilder.HasKey(t => t.IdAutor);
            entityBuilder.Property(t=>t.NombreAutor).IsRequired();
        }
    }
}
