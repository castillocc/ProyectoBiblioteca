using Biblioteca.Data.Models;
using Biblioteca.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Service
{
    public class TemaServicio:ITemaServicio
    {
        private IRepository<Tema> temaRepository;

        public TemaServicio(IRepository<Tema> _temaRepository)
        {
            this.temaRepository = _temaRepository;
        }

        public void ActualizarTema(int id,Tema tema)
        {
            TemaRepository.Actualizar(tema,id);
        }

        public void EliminarTema(int id)
        {
            Tema tema = ObtenerAutor(id);
            TemaRepository.Eliminar(tema);
        }

        public void InsertarTema(Tema tema)
        {
            TemaRepository.Insertar(tema);
        }

        public IEnumerable<Tema> ListarTema()
        {
            return TemaRepository.ListarTodos();
        }

        public Autor ObtenerTema(int id)
        {
            return TemaRepository.ObtenerPorId(id);
        }
    }
}

