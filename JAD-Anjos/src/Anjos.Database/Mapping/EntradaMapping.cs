﻿using Anjos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anjos.Database.Mapping;

public class EntradaMapping : IEntityTypeConfiguration<EntradaEntity>
{
    public void Configure(EntityTypeBuilder<EntradaEntity> builder)
    {
        builder.ToTable("Entrada", "dbo");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Valor)
            .IsRequired();

    }
}