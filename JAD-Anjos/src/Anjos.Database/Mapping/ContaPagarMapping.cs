using Anjos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anjos.Database.Mapping;

public class ContaPagarMapping : IEntityTypeConfiguration<ContaPagarEntity>
{
    public void Configure(EntityTypeBuilder<ContaPagarEntity> builder)
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