using Anjos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anjos.Database.Mapping;

public class VendaMapping : IEntityTypeConfiguration<VendaEntity>
{
    public void Configure(EntityTypeBuilder<VendaEntity> builder)
    {
        builder.ToTable("Venda", "dbo");

        builder.HasKey(v => v.Id);

        builder.Property(v => v.Valor)
            .IsRequired();

        builder.Property(v => v.DataVenda)
            .IsRequired();

        builder.Property(v => v.DataInclusao)
            .IsRequired();

        builder.Property(v => v.FormaPagamento)
            .IsRequired();
    }
}