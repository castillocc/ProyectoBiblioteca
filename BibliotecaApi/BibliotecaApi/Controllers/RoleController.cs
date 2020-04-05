using System;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Data.Models;
using BibliotecaApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace BibliotecaApi.Controllers
{
    [Produces("application/json")]
    [Route("Biblioteca/Role")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<Usuario> userManager;

        public RoleController(UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        //POST: Biblioteca/Role
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CrearRol([FromBody]RoleViewModel model)
        {
            var elRolExiste = await roleManager.RoleExistsAsync(model.NombreRol);
            if (elRolExiste)
            {
                return BadRequest(String.Format("El rol {0} ya se encuentra creado", model.NombreRol));
            }
            var result = await roleManager.CreateAsync(new IdentityRole(model.NombreRol));
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(x => x.Description).ToList());
            }
            return Ok("El rol se ha creado exitosamente");
        }

        //Put: Biblioteca/Libro
        [HttpPut("{role}")]
        [AllowAnonymous]
        public async Task<IActionResult> ActualizarRol(string role, [FromBody]RoleViewModel model)
        {
            var elRolExiste = await roleManager.RoleExistsAsync(role);
            if (!elRolExiste)
            {
                return BadRequest(String.Format("El rol {0}no se encuentra creado", model.NombreRol));
            }
            var roleUpdate = roleManager.FindByNameAsync(role).Result;
            roleUpdate.Name = model.NombreRol;
            var result = await roleManager.UpdateAsync(roleUpdate);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(x => x.Description).ToList());
            }
            return Ok("El rol se ha actualizado exitosamente");
        }

        //Delete: Biblioteca/Libro
        [HttpDelete]
        [AllowAnonymous]
        public async Task<IActionResult> ElimnarRol([FromBody]RoleViewModel model)
        {
            var elRolExiste = await roleManager.RoleExistsAsync(model.NombreRol);
            if (!elRolExiste)
            {
                return BadRequest(String.Format("El rol {0}no se encuentra creado", model.NombreRol));
            }
            var roleDelete = roleManager.FindByNameAsync(model.NombreRol).Result;
            var result = await roleManager.DeleteAsync(roleDelete);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(x => x.Description).ToList());
            }
            return Ok("El rol se ha elimnado exitosamente");
        }

        #region ConfiguracionRolUsuario
        //Esta seccion se encarga de manejar todas las peticiones para actualizar los roles con los que cuenta un usuario
        [HttpPost("AgregarRolUsuario")]
        [AllowAnonymous]
        [Route("AsignarRolUsuario")]
        public async Task<IActionResult> AgregarRolPorUsuario([FromBody]RoleViewModel model)
        {
            var usuario = await userManager.FindByEmailAsync(model.EmailUsuario);
            if (usuario == null)
            {
                return BadRequest(String.Format("El usuario asociado al correo {0} no existe", model.EmailUsuario));
            }
            var elRolFueAgregado = await userManager.AddToRoleAsync(usuario, model.NombreRol);
            if (!elRolFueAgregado.Succeeded)
            {
                return BadRequest(elRolFueAgregado.Errors.Select(x => x.Description).ToList());
            }
            return Ok(string.Format("Se agrego el rol {0} para el usuario {1}", model.NombreRol, model.EmailUsuario));
        }

        [HttpPost("RemoverRolUsuario")]
        [AllowAnonymous]
        [Route("RemoverRolUsuario")]
        public async Task<IActionResult> RemoverRolUsuario([FromBody]RoleViewModel model)
        {
            var usuario = await userManager.FindByEmailAsync(model.EmailUsuario);
            if (usuario == null)
            {
                return BadRequest(String.Format("El usuario asociado al correo \"{0}\" no existe", model.EmailUsuario));
            }
            var elRolFueEliminado = await userManager.RemoveFromRoleAsync(usuario, model.NombreRol);
            if (!elRolFueEliminado.Succeeded)
            {
                return BadRequest(elRolFueEliminado.Errors.Select(x => x.Description).ToList());
            }
            return Ok(string.Format("Se elimino el rol \"{0}\" para el usuario {1}", model.NombreRol, model.EmailUsuario));
        }
        #endregion
    }
}
