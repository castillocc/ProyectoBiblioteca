using Biblioteca.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Repository
{
   public interface IRepository<T>
    {
        IEnumerable<T> ListarTodos();
        T ObtenerPorId(int id);
        void Insertar(T entidad);
        void Eliminar(T entidad);
        void Actualizar(T entidad,int id);
        void Remover(T entidad);
        void GuardarCambios();
    }
}
