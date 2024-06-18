﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Anjos.Domain.Entities;

namespace Anjos.Database.Mapping;

public class CategoriaMapping : IEntityTypeConfiguration<CategoriaEntity>
{
    public void Configure(EntityTypeBuilder<CategoriaEntity> builder)
    {
        builder.ToTable("Categoria", "dbo");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Nome)
            .IsRequired();

        builder.Property(c => c.Descricao)
            .IsRequired();
    }
}
