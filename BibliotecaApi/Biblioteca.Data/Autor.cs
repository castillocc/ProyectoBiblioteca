using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Data
{
    public class Autor:BaseEntity
    {
        public int IdAutor { get; set; }
        public string NombreAutor { get; set; }
    }
}
