using Biblioteca.Data.Models;
using Biblioteca.Service.InterfacesServicio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BibliotecaApi.Controllers
{
    [Produces("application/json")]
    [Route("Biblioteca/Autor")]
    public class AutorsController : Controller
    {
        private readonly IAutorServicio servicioAutor;

        public AutorsController(IAutorServicio _servicioAutor)
        {
            this.servicioAutor = _servicioAutor;
        }

        // GET: api/Autor
        [HttpGet]
        public IEnumerable<Autor> ListarAutores()
        {
            return servicioAutor.ListarAutor();
        }

        // GET: api/Autor/5
        [HttpGet("{id}", Name = "ObtenerAutorPorId")]
        public IActionResult ObtenerAutorPorId([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var autor = servicioAutor.ObtenerAutor(id);
            if (autor == null)
            {
                return NotFound("Autor no encontrado");
            }
            return Ok(autor);
        }

        // POST: api/Autor
        [HttpPost]
        public ActionResult PostAutor([FromBody]Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            servicioAutor.InsertarAutor(autor);
            return Ok("Autor creado");

        }

        // PUT: api/Autor/5
        [HttpPut("{id}")]
        public IActionResult ActualizarAutor(int id, [FromBody]Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != autor.IdAutor)
            {
                return BadRequest();
            }
            servicioAutor.ActualizarAutor(id, autor);
            return Ok("Autor Actualizado");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult EliminarAutor(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            servicioAutor.EliminarAutor(id);
            return Ok("Autor eliminado");

        }
    }
}
