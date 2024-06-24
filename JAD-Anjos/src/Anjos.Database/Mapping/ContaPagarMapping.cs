using Anjos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anjos.Database.Mapping;

public class ContaPagarMapping : IEntityTypeConfiguration<ContaPagar>
{
    public void Configure(EntityTypeBuilder<ContaPagar> builder)
    {
        builder.ToTable("ContaPagar", "dbo");

        builder.HasKey(cp => cp.Id);

        builder.Property(cp => cp.Valor)
            .IsRequired();

        builder.Property(cp => cp.QuantidadeParcelas)
            .IsRequired();

        builder.Property(cp => cp.EntradaId)
            .IsRequired();

    }
}