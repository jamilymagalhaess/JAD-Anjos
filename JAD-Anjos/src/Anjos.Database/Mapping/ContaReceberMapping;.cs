﻿using Anjos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Anjos.Database.Mapping;


public class ContaReceberMapping : IEntityTypeConfiguration<ContaReceberEntity>
{
    public void Configure(EntityTypeBuilder<ContaReceberEntity> builder)
    {
        builder.ToTable("ContaReceber", "dbo");

        builder.HasKey(cr => cr.Id);

        builder.Property(cr => cr.QuantidadeParcelas)
            .IsRequired();

        builder.Property(cr => cr.Valor)
            .IsRequired();

        builder.Property(cr => cr.VendaId)
            .IsRequired();

    }
}