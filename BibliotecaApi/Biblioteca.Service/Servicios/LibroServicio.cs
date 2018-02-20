using Biblioteca.Data.Models;
using Biblioteca.Repository;
using Biblioteca.Service.InterfacesServicio;
using System;
using System.Collections.Generic;


namespace Biblioteca.Service.Servicio
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
            Libro libro = ObtenerLibro(id);
            libroRepository.Eliminar(libro);
        }

        public void InsertarLibro(Libro libro)
        {
            libroRepository.Insertar(libro);
        }

        public IEnumerable<Libro> ListarLibros()
        {
            return libroRepository.ListarTodos();
        }

        public Libro ObtenerLibro(int id)
        {
            return libroRepository.ObtenerPorId(id);
        }
    }
}


