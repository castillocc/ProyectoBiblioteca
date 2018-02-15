using Biblioteca.Data.Models;
using Biblioteca.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Service
{
    public class AutorServicio:IAutorServicio
    {
        private IRepository<Autor> autorRepository;

        public AutorServicio(IRepository<Autor> _autorRepository)
        {
            this.autorRepository = _autorRepository;
        }

        public void ActualizarAutor(Autor autor)
        {
            autorRepository.Actualizar(autor);
        }

        public void EliminarAutor(int id)
        {
            Autor autor = ObtenerAutor(id);
            autorRepository.Eliminar(autor);
        }

        public void InsertarAutor(Autor autor)
        {
            autorRepository.Insertar(autor);
        }

        public IEnumerable<Autor> ListarAutor()
        {
            return autorRepository.ListarTodos();
        }

        public Autor ObtenerAutor(int id)
        {
            return autorRepository.ObtenerPorId(id);
        }
    }
}
