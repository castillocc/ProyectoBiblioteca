using Biblioteca.Data.Mapper;
using Biblioteca.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //configuracio de la biblioteca
            new TemaMap(modelBuilder.Entity<Tema>());
            new EditorialMap(modelBuilder.Entity<Editorial>());
            new AutorMap(modelBuilder.Entity<Autor>());
            new LibroMap(modelBuilder.Entity<Libro>());
           /* new EjemplarMap(modelBuilder.Entity<Ejemplar>());
            new PrestamoMap(modelBuilder.Entity<Prestamo>());

            //Configuracion de usuario
            new AspNetRoleClaimsMap(modelBuilder.Entity<AspNetRoleClaims>());
            new AspNetRolesMap(modelBuilder.Entity<AspNetRoles>());
            new AspNetUserClaimsMap(modelBuilder.Entity<AspNetUserClaims>());
            new AspNetUserLoginsMap(modelBuilder.Entity<AspNetUserLogins>());
            new AspNetUserRolesMap(modelBuilder.Entity<AspNetUserRoles>());
            new AspNetUserTokensMap(modelBuilder.Entity<AspNetUserTokens>());*/

        }
    }
}
