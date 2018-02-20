using Biblioteca.Data.Models;
using Biblioteca.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Service.InterfacesServicio
{
    public interface ITemaServicio
    {
        IEnumerable<Tema> ListarTemas();
        Tema ObtenerTema(int id);
        void InsertarTema(Tema tema);
        void ActualizarTema(int id,Tema tema);
        void EliminarTema(int id); 
    }
}
