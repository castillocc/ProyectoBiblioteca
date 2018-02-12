using System;
using System.Collections.Generic;

namespace Biblioteca.Data.Models
{
    public partial class Autor : BaseEntity
    {
        public Autor()
        {
            Libro = new HashSet<Libro>();
        }

        public int IdAutor { get; set; }
        public string NombreAutor { get; set; }

        public ICollection<Libro> Libro { get; set; }
    }
}
