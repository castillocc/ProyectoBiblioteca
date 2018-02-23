using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Data.Models;
using Biblioteca.Service.InterfacesServicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaBiblioteca.Controllers
{
    [Produces("application/json")]
    [Route("Biblioteca/Libro")]
    public class LibroController : Controller
    {
        private readonly ILibroServicio servicio;

        public LibroController(ILibroServicio libroServicio)
        {
            this.servicio = libroServicio;
        }
        // GET: Biblioteca/Libro
        [HttpGet]
        public IEnumerable<Libro> ListarLibros()
        {
            return servicio.ListarLibros();
        }


        // GET: Biblioteca/Libro/5
        [HttpGet("{id}", Name = "ObtenerPorId")]
        public IActionResult ObtenerLibroPorId(int id)
        {
            var libro = servicio.ObtenerLibro(id);
            if (libro == null)
            {
                return NotFound("Tema no encontrado");
            }
            return Ok(libro);
        }

        // POST: Biblioteca/Libro
        [HttpPost]
        public IActionResult Post([FromBody]Libro libro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(modelError => modelError.ErrorMessage).ToList());
            }
            servicio.InsertarLibro(libro);
            return Ok("Tema creado");

        }

        // PUT: Biblioteca/Libro/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Libro libro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(modelError => modelError.ErrorMessage).ToList());
            }

            if (id != libro.IdTema)
            {
                return BadRequest();
            }
            servicio.ActualizarLibro(id, libro);
            return Ok("Tema Actualizado");
        }

        // DELETE: Biblioteca/BibliotecaWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            servicio.EliminarLibro(id);
            return Ok("Tema eliminado");
        }
    }
}
