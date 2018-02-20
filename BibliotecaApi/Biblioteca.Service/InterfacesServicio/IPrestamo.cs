using Biblioteca.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Service.InterfacesServicio
{
    public interface IPrestamoServicio
    {
        IEnumerable<Prestamo> ListarPrestamos();
        Prestamo ObtenerPrestamo(int id);
        void InsertarPrestamo(Prestamo autor);
        void ActualizarPrestamo(int id, Prestamo autor);
        void EliminarPrestamo(int id);
    }
}
