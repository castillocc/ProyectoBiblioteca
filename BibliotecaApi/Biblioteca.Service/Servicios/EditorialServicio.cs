using Biblioteca.Data.Models;
using Biblioteca.Repository;
using Biblioteca.Service.InterfacesServicio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Service
{
    public class EditorialServicio:IEditorialServicio
    {
        private IRepository<Editorial> editorialRepository;

        public EditorialServicio(IRepository<Editorial> _editorialRepository)
        {
            this.editorialRepository = _editorialRepository;
        }

        public void ActualizarEditorial(int id,Editorial editorial)
        {
            editorialRepository.Actualizar(editorial,id);
        }

        public void EliminarEditorial(int id)
        {
            Editorial editorial = ObtenerEditorial(id);
            editorialRepository.Eliminar(editorial);
        }

        public void InsertarEditorial(Editorial editorial)
        {
            editorialRepository.Insertar(editorial);
        }

        public IEnumerable<Editorial> ListarEditoriales()
        {
            return editorialRepository.ListarTodos();
        }

        public Editorial ObtenerEditorial(int id)
        {
            return editorialRepository.ObtenerPorId(id);
        }
    }
}
