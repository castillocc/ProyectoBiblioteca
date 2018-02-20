using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Data.Models;
using Biblioteca.Service.InterfacesServicio;
using BibliotecaApi.Helpers;
using BibliotecaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BibliotecaApi.Controllers
{
    [Produces("application/json")]
    [Route("Biblioteca/Cuenta")]
    public class CuentaController : Controller
    {

        private readonly IUsuarioServicio servicioUsuario;
        private readonly UserManager<AspNetUsers> userManager;
        private readonly SignInManager<AspNetUsers> signInManager;
        private readonly IConfiguration configuration;

        public CuentaController(UserManager<AspNetUsers> userManager,SignInManager<AspNetUsers> signInManager, 
            IConfiguration configuration, IUsuarioServicio servicioUsuario)
        {
            // this.servicioUsuario = servicioUsuario;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.servicioUsuario = servicioUsuario;
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
            var user = new AspNetUsers
            {
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

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model)
        {
            var resultado = await signInManager.SignInAsync(model.Email,model.Clave,false);
           // var x = await signInManager.p(model.Email, model.Clave, false, false);
            if (resultado.Succeeded)
            {
                var appUser = userManager.FindByEmailAsync(model.Email).Result;
               // return await GenerateJwtToken(model.Email, appUser);
            }

            return BadRequest("Error al loguiar");
        }

        private async Task<object> GenerateJwtToken(string email, AspNetUsers user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //var expires = DateTime.Now.AddDays(Convert.ToDouble(configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Issuer"],
                claims,
               // expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
