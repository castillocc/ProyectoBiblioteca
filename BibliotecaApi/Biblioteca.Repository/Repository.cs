using Biblioteca.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteca.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext context;
        private DbSet<T> entities;
        //Declaracion de constantes
        private const string MENSAJE_ERROR_INSERTAR = "Error al insertar la entidad {0}";
        private const string MENSAJE_ERROR_ACTUALIZAR = "Error al actualizar la entidad {0}";
        private const string MENSAJE_ERROR_ELIMINAR = "Error al eliminar la entidad {0}";
        private const string MENSAJE_ERROR_REMOVER = "Error al remover la entidad {0}";

        public Repository(ApplicationContext _context)
        {
            this.context = _context;
            entities = context.Set<T>();
        }

        public IEnumerable<T> ListarTodos()
        {
            return entities.AsEnumerable();
        }


        public T ObtenerPorId(int id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public void Insertar(T entidad)
        {
            if (entidad is null)
            {
                throw new ArgumentNullException(String.Format(MENSAJE_ERROR_INSERTAR, entidad.ToString()));
            }
            entities.Add(entidad);
            context.SaveChanges();
        }

        public void Actualizar(T entidad)
        {
            if (entidad is null)
            {
                throw new ArgumentNullException(String.Format(MENSAJE_ERROR_ACTUALIZAR, entidad.ToString()));
            }
            context.SaveChanges();
        }

        public void Eliminar(T entidad)
        {
            if (entidad is null)
            {
                throw new ArgumentNullException(String.Format(MENSAJE_ERROR_ELIMINAR, entidad.ToString()));
            }
            entities.Remove(entidad);
            context.SaveChanges();
        }

        public void GuardarCambios()
        {
            context.SaveChanges();
        }

        public void Remover(T entidad)
        {
            if (entidad is null)
            {
                throw new ArgumentNullException(String.Format(MENSAJE_ERROR_REMOVER, entidad.ToString()));
            }
            context.Remove(entidad);
        }
    }
}
