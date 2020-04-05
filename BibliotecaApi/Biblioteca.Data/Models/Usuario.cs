using Microsoft.AspNetCore.Identity;

namespace Biblioteca.Data.Models
{
    public class Usuario:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
