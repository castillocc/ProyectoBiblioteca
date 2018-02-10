using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Data
{
    public class PrestamoMap
    {
        public PrestamoMap(EntityTypeBuilder<Prestamo> entityBuilder)
        {
            entityBuilder.HasKey(t => t.IdPrestamo);
            entityBuilder.HasMany(t => t.Libros).WithOne(p => p.Prestamo).HasForeignKey<int>(p=>p.IdLibro).IsRequired();
        }
    }
}
