﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaApi.Models
{
    public class RegistroViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

    }
}
