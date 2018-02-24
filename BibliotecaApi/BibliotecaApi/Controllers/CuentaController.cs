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
using Microsoft.AspNetCore.Authorization;
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
        private readonly UserManager<Usuario> userManager;
        private readonly SignInManager<Usuario> signInManager;
        private readonly IConfiguration configuration;

        public CuentaController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager,
           RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;

        }

        #region Controladores
        // POST: Biblioteca/Cuenta
        [HttpPost]
        [AllowAnonymous]
        [Route("Registro")]
        public async Task<IActionResult> Post([FromBody]RegistroViewModel usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(modelError => modelError.ErrorMessage).ToList());
            }
            var user = new Usuario
            {
                UserName = usuario.Email,
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
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                var appUser = userManager.Users.SingleOrDefault(r => r.Email == model.Email);
                var token = GenerarTokenJWT(model.Email, appUser);
                return new OkObjectResult(token);
            }

            return new BadRequestObjectResult(result);
        }

        #endregion
        #region Metodos Privados
        private string GenerarTokenJWT(string email, Usuario user)
        {
            var claims = new List<Claim>
               {
                   new Claim(JwtRegisteredClaimNames.Sub, email),
                   new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                   new Claim(ClaimTypes.NameIdentifier, user.Id)
               };

            var token = new JwtSecurityToken(
          issuer: configuration["Jwt:Issuer"],
          claims: claims,
          expires: DateTime.UtcNow.AddDays(60),
         notBefore: DateTime.UtcNow,
         signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                 SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion
    }
}
