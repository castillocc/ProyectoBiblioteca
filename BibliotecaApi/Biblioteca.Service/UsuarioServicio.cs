using System;
using System.Collections.Generic;
using System.Text;
using Biblioteca.Data.Models;
using Biblioteca.Repository;

namespace Biblioteca.Service
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private IRepository<AspNetUsers> usuarioRepository;

        public UsuarioServicio(IRepository<AspNetUsers> _usuarioRepository)
        {
            this.usuarioRepository = _usuarioRepository;
        }

        public void ActualizarUsuario(int id,AspNetUsers usuario)
        {
            usuarioRepository.Actualizar(usuario,id);
        }

        public void EliminarUsuario(int id)
        {
            AspNetUsers usuario = ObtenerUsuario(id);
            usuarioRepository.Eliminar(usuario);
        }

        public void InsertarUsuario(AspNetUsers usuario)
        {
            usuarioRepository.Insertar(usuario);
        }

        public IEnumerable<AspNetUsers> ListarUsuarios()
        {
            return usuarioRepository.ListarTodos();
        }

        public AspNetUsers ObtenerUsuario(int id)
        {
            return usuarioRepository.ObtenerPorId(id);
        }
    }
}
