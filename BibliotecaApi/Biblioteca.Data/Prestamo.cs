using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Data
{
    public class Prestamo: BaseEntity
    {
        public int IdPrestamo { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int EstadoPrestamo { get; set; }
        public int IdLibro { get; set; }
        public string IdUsuario { get; set; }

        //referencia de las clases libro y usuario puede ser que no exista.
        public ICollection<Libro> Libros { get; set; }
    }

}
