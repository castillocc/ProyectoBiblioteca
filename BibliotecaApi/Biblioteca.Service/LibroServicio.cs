using Biblioteca.Data.Models;
using Biblioteca.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Service
{
    public class LibroServicio:ILibroServicio
    {
        private IRepository<Libro> libroRepository;

        public LibroServicio(IRepository<Libro> _libroRepository)
        {
            this.libroRepository = _libroRepository;
        }

        public void ActualizarLibro(int id,Libro libro)
        {
            libroRepository.Actualizar(libro,id);
        }

        public void EliminarLibro(int id)
        {
            Libro libro = ObtenerAutor(id);
            libroRepository.Eliminar(libro);
        }

        public void InsertarLibro(Libro libro)
        {
            libroRepository.Insertar(libro);
        }

        public IEnumerable<Libro> ListarLibro()
        {
            return libroRepository.ListarTodos();
        }

        public Autor ObtenerLibro(int id)
        {
            return libroRepository.ObtenerPorId(id);
        }
    }
}


