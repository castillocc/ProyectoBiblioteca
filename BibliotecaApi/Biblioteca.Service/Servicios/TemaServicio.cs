using Biblioteca.Data.Models;
using Biblioteca.Repository;
using Biblioteca.Service.InterfacesServicio;
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
            temaRepository.Actualizar(tema,id);
        }

        public void EliminarTema(int id)
        {
            Tema tema = ObtenerTema(id);
            temaRepository.Eliminar(tema);
        }

        public void InsertarTema(Tema tema)
        {
            temaRepository.Insertar(tema);
        }

        public IEnumerable<Tema> ListarTemas()
        {
            return temaRepository.ListarTodos();
        }

        public Tema ObtenerTema(int id)
        {
            return temaRepository.ObtenerPorId(id);
        }
    }
}

