﻿using System;
using System.Collections.Generic;

namespace Biblioteca.Data.Models
{
    public partial class Editorial 
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
