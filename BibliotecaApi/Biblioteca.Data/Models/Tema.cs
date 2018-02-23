using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Data.Models
{
    public partial class Tema 
    {
        public Tema()
        {
            Libro = new HashSet<Libro>();
        }

        public int IdTema { get; set; }
        [Required(ErrorMessage ="La descripcion es requerida")]
        public string Descripcion { get; set; }

        public ICollection<Libro> Libro { get; set; }
    }
}
