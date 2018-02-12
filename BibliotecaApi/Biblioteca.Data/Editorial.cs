using System;
using System.Collections.Generic;

namespace Biblioteca.Data
{
    public partial class Editorial : BaseEntity
    {
        public Editorial()
        {
            Libro = new HashSet<Libro>();
        }

        public int IdEditorial { get; set; }
        public string NombreEditorial { get; set; }

        public ICollection<Libro> Libro { get; set; }
    }
}
