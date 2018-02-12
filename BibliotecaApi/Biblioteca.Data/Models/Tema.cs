using System;
using System.Collections.Generic;

namespace Biblioteca.Data.Models
{
    public partial class Tema : BaseEntity
    {
        public Tema()
        {
            Libro = new HashSet<Libro>();
        }

        public int IdTema { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Libro> Libro { get; set; }
    }
}
