using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Data.Models
{
    public class Usuario:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
