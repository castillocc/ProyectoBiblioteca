
using Biblioteca.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Service.InterfacesServicio
{
    public interface IEditorialServicio
    {
        IEnumerable<Editorial> ListarEditoriales();
        Editorial ObtenerEditorial(int id);
        void InsertarEditorial(Editorial editorial);
        void ActualizarEditorial(int id,Editorial editorial);
        void EliminarEditorial(int id);
    }
}
