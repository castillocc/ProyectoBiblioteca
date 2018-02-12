using System;
using System.Collections.Generic;

namespace Biblioteca.Data
{
    public partial class AspNetUserClaims : BaseEntity
    {
        public int Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public string UserId { get; set; }

        public AspNetUsers User { get; set; }
    }
}
