using Biblioteca.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Data.Mapper
{
    public class AspNetUserTokensMap
    {
        public AspNetUserTokensMap(EntityTypeBuilder<AspNetUserTokens> entityBuilder) {
            entityBuilder.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
        }
    }
}
