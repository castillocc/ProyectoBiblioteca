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
    [Route("Biblioteca/Editorial")]
    public class EditorialController : Controller
    {
        private readonly IEditorialServicio servicio;

        public EditorialController(IEditorialServicio editorialServicio) {
            this.servicio = editorialServicio;
        }
        // GET: Biblioteca/Editorial
        [HttpGet]
        public IEnumerable<Editorial> ObtenerEditoriales()
        {
            return servicio.ListarEditoriales();
        }

        // GET: Biblioteca/Editorial/5
        [HttpGet("{id}", Name = "ObtenerEditorialPorId")]
        public IActionResult ObtenerEditorialPorId(int id)
        {
            var editorial = servicio.ObtenerEditorial(id);
            if (editorial == null)
            {
                return NotFound("Editorial no encontrada");
            }
            return Ok(editorial);
        }
        
        // POST: Biblioteca/Editorial
        [HttpPost]
        public IActionResult Post([FromBody]Editorial editorial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(modelError => modelError.ErrorMessage).ToList());
            }
            servicio.InsertarEditorial(editorial);
            return Ok("Editorial creada");

        }
        
        // PUT: Biblioteca/Editorial/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Editorial editorial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(modelError => modelError.ErrorMessage).ToList());
            }

            if (id != editorial.IdEditorial)
            {
                return BadRequest();
            }
            servicio.ActualizarEditorial(id, editorial);
            return Ok("Editorial Actualizada");
        }
        
        // DELETE: Biblioteca/BibliotecaWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            servicio.EliminarEditorial(id);
            return Ok("Autor eliminado");
        }
    }
}
