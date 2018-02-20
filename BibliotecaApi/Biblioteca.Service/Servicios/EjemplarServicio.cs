using Biblioteca.Data.Models;
using Biblioteca.Repository;
using Biblioteca.Service.InterfacesServicio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Service
{
    public class EjemplarServicio : IEjemplarServicio
    {
        private IRepository<Ejemplar> ejemplarRepository;

        public EjemplarServicio(IRepository<Ejemplar> _ejemplarRepository)
        {
            this.ejemplarRepository = _ejemplarRepository;
        }

        public void ActualizarEjemplar(int id, Ejemplar ejemplar)
        {
            ejemplarRepository.Actualizar(ejemplar, id);
        }

        public void EliminarEjemplar(int id)
        {
            Ejemplar Ejemplar = ObtenerEjemplar(id);
            ejemplarRepository.Eliminar(Ejemplar);
        }

        public void InsertarEjemplar(Ejemplar ejemplar)
        {
            ejemplarRepository.Insertar(ejemplar);
        }

        public IEnumerable<Ejemplar> ListarEjemplares()
        {
            return ejemplarRepository.ListarTodos();
        }

        public Ejemplar ObtenerEjemplar(int id)
        {
            return ejemplarRepository.ObtenerPorId(id);
        }
    }
}
