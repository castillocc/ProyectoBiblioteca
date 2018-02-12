using System;
using System.Collections.Generic;

namespace Biblioteca.Data.Models
{
    public partial class Libro : BaseEntity
    {
        public int Idlibro { get; set; }
        public string Titulo { get; set; }
        public int Paginas { get; set; }
        public int Edicion { get; set; }
        public int Ejemplares { get; set; }
        public long Isbn { get; set; }
        public int IdEditorial { get; set; }
        public int IdAutor { get; set; }
        public int IdTema { get; set; }

        public Autor IdAutorNavigation { get; set; }
        public AspNetUserClaims IdEditorialNavigation { get; set; }
        public Tema IdTemaNavigation { get; set; }
    }
}
