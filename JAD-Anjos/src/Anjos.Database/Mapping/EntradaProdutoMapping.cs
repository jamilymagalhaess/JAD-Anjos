using Anjos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Anjos.Database.Mapping;

public class EntradaProdutoMapping : IEntityTypeConfiguration<EntradaProdutoEntity>
{
    public void Configure(EntityTypeBuilder<EntradaProdutoEntity> builder)
    {
        builder.ToTable("EntradaProduto", "dbo");

        builder.HasKey(ep => ep.Id);

        builder.Property(ep => ep.Quantidade)
            .IsRequired();

        builder.Property(ep => ep.Valor)
            .IsRequired();

        builder.Property(ep => ep.DataEntrada)
            .IsRequired();

        builder.Property(ep => ep.DataInclusao)
            .IsRequired();

        builder.Property(ep => ep.EntradaId)
            .IsRequired();

        builder.Property(ep => ep.ProdutoId)
            .IsRequired();
    }
}