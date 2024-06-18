using Anjos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anjos.Database.Mapping;

public class VendaProdutoMapping : IEntityTypeConfiguration<VendaProdutoEntity>
{
    public void Configure(EntityTypeBuilder<VendaProdutoEntity> builder)
    {
        builder.ToTable("VendaProduto", "dbo");

        builder.HasKey(vp => vp.Id);

        builder.Property(vp => vp.Valor)
            .IsRequired();

        builder.Property(vp => vp.Quantidade)
            .IsRequired();

        builder.Property(vp => vp.VendaId)
            .IsRequired();

        builder.Property(vp => vp.ProdutoId)
            .IsRequired();
    }
}