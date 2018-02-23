using Biblioteca.Data.Models;
using Biblioteca.Service.InterfacesServicio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaApi.Controllers
{
    [Produces("application/json")]
    [Route("Biblioteca/Autor")]
    public class AutorsController : Controller
    {
        private readonly IAutorServicio servicio;

        public AutorsController(IAutorServicio servicioAutor)
        {
            this.servicio = servicioAutor;
        }

        // GET: Biblioteca/Autor
        [HttpGet]
        [Authorize]
        public IEnumerable<Autor> ListarAutores()
        {
            return servicio.ListarAutor();
        }

        // GET: Biblioteca/Autor/ObtenerAutorPorId/5
        [Authorize]
        [HttpGet("{id}", Name = "ObtenerPorId")]
        public IActionResult ObtenerAutorPorId([FromRoute] int id)
        {
            var autor = servicio.ObtenerAutor(id);
            if (autor == null)
            {
                return NotFound("Autor no encontrado");
            }
            return Ok(autor);
        }

        // POST: Biblioteca/Autor
        [Authorize]
        [HttpPost]
        public ActionResult PostAutor([FromBody]Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(modelError => modelError.ErrorMessage).ToList());
            }
            servicio.InsertarAutor(autor);
            return Ok("Autor creado");

        }

        // PUT: Biblioteca/Autor/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult ActualizarAutor(int id, [FromBody]Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(modelError => modelError.ErrorMessage).ToList());
            }

            if (id != autor.IdAutor)
            {
                return BadRequest();
            }
            servicio.ActualizarAutor(id, autor);
            return Ok("Autor Actualizado");
        }

        // DELETE: Biblioteca/ApiWithActions/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult EliminarAutor(int id)
        {
            servicio.EliminarAutor(id);
            return Ok("Autor eliminado");

        }
    }
}
