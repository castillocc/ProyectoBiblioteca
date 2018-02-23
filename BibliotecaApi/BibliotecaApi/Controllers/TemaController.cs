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
    [Route("Biblioteca/Tema")]
    public class TemaController : Controller
    {
        private readonly ITemaServicio servicio;
        public TemaController(ITemaServicio temaServicio)
        {
            this.servicio = temaServicio;
        }

        // GET: Biblioteca/Tema/
        [HttpGet]
        public IEnumerable<Tema> ObtenerTemas()
        {
            return servicio.ListarTemas();
        }

        // GET: Biblioteca/Tema/5
        [HttpGet("{id}", Name = "ObtenerPorId")]
        public IActionResult ObtenerTemaPorId(int id)
        {
            var tema = servicio.ObtenerTema(id);
            if (tema == null)
            {
                return NotFound("Tema no encontrado");
            }
            return Ok(tema);
        }

        // POST: Biblioteca/Tema
        [HttpPost]
        public IActionResult Post([FromBody]Tema tema)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(modelError => modelError.ErrorMessage).ToList());
            }
            servicio.InsertarTema(tema);
            return Ok("Tema creado");

        }

        // PUT: Biblioteca/Tema/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Tema tema)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(modelError => modelError.ErrorMessage).ToList());
            }

            if (id != tema.IdTema)
            {
                return BadRequest();
            }
            servicio.ActualizarTema(id, tema);
            return Ok("Tema Actualizado");
        }

        // DELETE: Biblioteca/Tema/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            servicio.EliminarTema(id);
            return Ok("Tema eliminado");
        }
    }
}
