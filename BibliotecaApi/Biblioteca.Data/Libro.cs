using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Data
{
   public class Libro
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }

        //Referencia del objeto Presto 
        public virtual Prestamo Prestamo { get; set; }
    }
}
