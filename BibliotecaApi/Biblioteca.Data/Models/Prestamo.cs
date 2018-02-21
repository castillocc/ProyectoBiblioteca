using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Data.Models
{
    public class Prestamo
    {
       public int IdPrestamos { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public int? DiasPrestamo { get; set; }
        public string IdUsuario { get; set; }
        public int? IdEjemplar { get; set; }

        public Ejemplar Ejemplar { get; set; }
    //    public AspNetUsers Usuario { get; set; }
    }

}
