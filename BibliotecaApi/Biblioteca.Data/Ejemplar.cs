using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Data
{
    public class Ejemplar:BaseEntity
    {
        public Ejemplar()
        {
            Prestamo = new HashSet<Prestamo>();
        }

        public int IdEjemplar { get; set; }
        public int IdLibro { get; set; }
        public int Cantidad { get; set; }
        public short EstadoEjemplar { get; set; }
        public int Origen { get; set; }

        public ICollection<Prestamo> Prestamo { get; set; }
    }
}
