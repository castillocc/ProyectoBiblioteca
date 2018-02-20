using Biblioteca.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Service.InterfacesServicio
{
    public interface IEjemplarServicio
    {
        IEnumerable<Ejemplar> ListarEjemplares();
        Ejemplar ObtenerEjemplar(int id);
        void InsertarEjemplar(Ejemplar usuario);
        void ActualizarEjemplar(int id, Ejemplar usuario);
        void EliminarEjemplar(int id);
    }
}
