using Biblioteca.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Service
{
    public interface IAutorServicio
    {
        IEnumerable<Autor> ListarAutor();
        Autor ObtenerAutor(int id);
        void InsertarAutor(Autor autor);
        void ActualizarAutor(int id,Autor autor);
        void EliminarAutor(int id);
    }
}
