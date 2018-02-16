
using Biblioteca.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Service
{
    public interface IEditorialServicio
    {
        IEnumerable<Editorial> ListarEditoriales);
        Editorial ObtenerEditorial(int id);
        void InsertarEditorial(Editorial autor);
        void ActualizarEditoriales(int id,Editorial autor);
        void EliminarEditoriales(int id);
    }
}
