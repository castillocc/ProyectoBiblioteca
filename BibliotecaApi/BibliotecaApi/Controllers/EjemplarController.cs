using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Data.Models;
using Biblioteca.Service.InterfacesServicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaApi.Controllers
{
    [Produces("application/json")]
    [Route("Biblioteca/Ejemplar")]
    public class EjemplarController : Controller
    {
        private readonly IEjemplarServicio servicio;

        public EjemplarController(IEjemplarServicio ejemplarServicio) {
            this.servicio = ejemplarServicio;
        }
        // GET: api/Ejemplar
        [HttpGet]
        public IEnumerable<Ejemplar> ListarLibros()
        {
            return servicio.ListarEjemplares();
        }

        // GET: api/Ejemplar/5
        [HttpGet("{id}", Name = "ObtenerEjemplarPorId")]
        public IActionResult ObtenerEjemplarPorId(int id)
        {
            var ejemplar = servicio.ObtenerEjemplar(id);
            if (ejemplar == null)
            {
                return NotFound("Ejemplar no encontrado");
            }
            return Ok(ejemplar);
        }

        // POST: api/Ejemplar
        [HttpPost]
        public IActionResult Post([FromBody]Ejemplar ejemplar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(modelError => modelError.ErrorMessage).ToList());
            }
            servicio.InsertarEjemplar(ejemplar);
            return Ok("Tema creado");

        }

        // PUT: api/Ejemplar/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Ejemplar ejemplar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(modelError => modelError.ErrorMessage).ToList());
            }

            if (id != ejemplar.IdEjemplar)
            {
                return BadRequest();
            }
            servicio.ActualizarEjemplar(id, ejemplar);
            return Ok("Ejemplar Actualizado");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            servicio.EliminarEjemplar(id);
            return Ok("Ejemplar eliminado");
        }
    }
}
