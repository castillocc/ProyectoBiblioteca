using System;
using System.Collections.Generic;

namespace Biblioteca.Data
{
    public partial class AspNetUserTokens : BaseEntity
    {
        public string UserId { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
