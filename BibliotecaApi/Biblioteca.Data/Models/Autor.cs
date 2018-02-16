using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace Biblioteca.Data.Models
{
    public partial class Autor
    {
        public Autor()
        {
            Libro = new HashSet<Libro>();
        }

        public int IdAutor { get; set; }
        public string NombreAutor { get; set; }
        [JsonIgnore]
        public virtual ICollection<Libro> Libro { get; set; }
    }
}
