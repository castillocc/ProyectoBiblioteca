using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Data.Models
{
    public partial class Libro 
    {
        public int Idlibro { get; set; }
        [Required(ErrorMessage ="El titulo es requerido")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Las paginas del libro son requeridas")]   
        [MinLength(49,ErrorMessage ="El minimo de paginas para un libro es 49 pag.")]
        public int Paginas { get; set; }
        [Required(ErrorMessage = "El titulo es requerido")]
        public int Edicion { get; set; }
        [Required(ErrorMessage = "El titulo es requerido")]
        public int Ejemplares { get; set; }
        [Required(ErrorMessage = "El Isbn es requerido")]
        public long Isbn { get; set; }
        [Required(ErrorMessage ="La editorial es requerida")]
        public int IdEditorial { get; set; }
        [Required(ErrorMessage ="El autor es requerido")]
        public int IdAutor { get; set; }
        [Required(ErrorMessage = "El tema es requerido")]
        public int IdTema { get; set; }

        public Autor IdAutorNavigation { get; set; }
        public Editorial IdEditorialNavigation { get; set; }
        public Tema IdTemaNavigation { get; set; }
    }
}
