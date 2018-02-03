using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Data
{
    public class BaseEntity
    {
        public Int64 Id { get; set; }
        public DateTime Creado { get; set; }
        public DateTime Modificado { get; set; }

    }
}
