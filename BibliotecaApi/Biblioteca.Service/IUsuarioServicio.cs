using Biblioteca.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Service
{
   public interface IUsuarioServicio
    {
        IEnumerable<AspNetUsers> ListarUsuarios();
        AspNetUsers ObtenerUsuario(int id);
        void InsertarUsuario(AspNetUsers usuario);
        void ActualizarUsuario(int id,AspNetUsers usuario);
        void EliminarUsuario(int id);
    }
}
