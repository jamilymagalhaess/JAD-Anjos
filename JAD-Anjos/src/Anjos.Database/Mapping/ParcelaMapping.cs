using Anjos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anjos.Database.Mapping;


public class ParcelaMapping : IEntityTypeConfiguration<ParcelaEntity>
{
    public void Configure(EntityTypeBuilder<ParcelaEntity> builder)
    {
        builder.ToTable("Parcela", "dbo");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Tipo)
            .IsRequired();

        builder.Property(p => p.Numero)
            .IsRequired();

        builder.Property(p => p.Valor)
            .IsRequired();

        builder.Property(p => p.Juros)
            .IsRequired();

        builder.Property(p => p.DataVencimento)
            .IsRequired();

        builder.Property(p => p.ContaPagarId)
            .IsRequired();

        builder.Property(p => p.ContaReceberId)
            .IsRequired();

    }
}