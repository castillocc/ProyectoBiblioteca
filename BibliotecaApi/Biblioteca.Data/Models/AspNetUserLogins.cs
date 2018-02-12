using System;
using System.Collections.Generic;

namespace Biblioteca.Data.Models
{
    public partial class AspNetUserLogins : BaseEntity
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public string UserId { get; set; }

        public AspNetUsers User { get; set; }
    }
}
