using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Data.Models;
using Biblioteca.Service.InterfacesServicio;
using BibliotecaApi.Helpers;
using BibliotecaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaApi.Controllers
{
    [Produces("application/json")]
    [Route("Biblioteca/Cuenta")]
    public class CuentaController : Controller
    {

        //private readonly IUsuarioServicio servicioUsuario;
        private readonly UserManager<AspNetUsers> userManager;

        public CuentaController(/*IUsuarioServicio servicioUsuario, */UserManager<AspNetUsers> userManager)
        {
           // this.servicioUsuario = servicioUsuario;
            this.userManager =userManager;
        }

        // POST: Biblioteca/Cuenta
        [HttpPost]
        [Route("Registro")]
        public async Task<IActionResult> Post([FromBody]RegistroViewModel usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(modelError => modelError.ErrorMessage).ToList());
            }
            var user = new AspNetUsers {
                UserName = usuario.UserName,
                Email = usuario.Email,
                FirstName = usuario.FirstName,
                LastName = usuario.LastName
            };
            var result = await userManager.CreateAsync(user, usuario.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(x => x.Description).ToList());
            }

            // servicioUsuario.InsertarUsuario(usuario);
            return new OkObjectResult("usuario creado");

        }


        // GET: api/Cuenta
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: Biblioteca/Cuenta/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        

        // PUT: api/Cuenta/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
