
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
            entityBuilder.HasKey(e => e.IdPrestamos);

            entityBuilder.Property(e => e.DiasPrestamo);

            entityBuilder.Property(e => e.FechaDevolucion);

            entityBuilder.Property(e => e.FechaPrestamo);

            entityBuilder.Property(e => e.IdUsuario)
                .IsRequired()
                .HasMaxLength(450);

            entityBuilder.HasOne(d => d.Ejemplar)
                .WithMany(p => p.Prestamo)
                .HasForeignKey(d => d.IdEjemplar);

            entityBuilder.HasOne(d => d.Usuario)
                .WithMany(p => p.Prestamo)
                .HasForeignKey(d => d.IdUsuario);
        }
    }
}
