﻿using Biblioteca.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Data.Mapper
{
    public class EjemplarMap
    {
        public EjemplarMap(EntityTypeBuilder<Ejemplar> entityBuilder) {
            entityBuilder.HasKey(e => e.IdEjemplar);
        }

    }
}
