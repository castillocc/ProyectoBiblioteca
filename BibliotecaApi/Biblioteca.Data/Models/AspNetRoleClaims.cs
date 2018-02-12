using System;
using System.Collections.Generic;

namespace Biblioteca.Data.Models
{
    public partial class AspNetRoleClaims : BaseEntity
    {
        public int Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public string RoleId { get; set; }

        public AspNetRoles Role { get; set; }
    }
}
