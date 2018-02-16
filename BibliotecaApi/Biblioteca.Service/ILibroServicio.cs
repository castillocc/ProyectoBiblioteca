using Biblioteca.Data.Models;
using Biblioteca.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Service
{
    public interface ILibroServicio
    {
        IEnumerable<Libro> ListarLibros);
        Libro ObtenerLibro(int id);
        void InsertarLibro(Libro libro);
        void ActualizarLibroes(int id,Libro libro);
        void EliminarLibroes(int id); 
    }
}
