using Biblioteca.Data.Models;
using Biblioteca.Repository;
using Biblioteca.Service.InterfacesServicio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Service
{
    public class PrestamoServicio : IPrestamoServicio
    {
        private IRepository<Prestamo> prestamoRepository;

        public PrestamoServicio(IRepository<Prestamo> _prestamoRepository)
        {
            this.prestamoRepository = _prestamoRepository;
        }

        public void ActualizarPrestamo(int id, Prestamo prestamo)
        {
            prestamoRepository.Actualizar(prestamo, id);
        }

        public void EliminarPrestamo(int id)
        {
            Prestamo prestamo = ObtenerPrestamo(id);
            prestamoRepository.Eliminar(prestamo);
        }

        public void InsertarPrestamo(Prestamo prestamo)
        {
            prestamoRepository.Insertar(prestamo);
        }

        public IEnumerable<Prestamo> ListarPrestamos()
        {
            return prestamoRepository.ListarTodos();
        }

        public Prestamo ObtenerPrestamo(int id)
        {
            return prestamoRepository.ObtenerPorId(id);
        }
    }
}
