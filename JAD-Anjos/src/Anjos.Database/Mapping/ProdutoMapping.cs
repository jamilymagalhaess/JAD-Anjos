using Anjos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anjos.Database.Mapping;

public class ProdutoMapping : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produto", "dbo");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Nome)
            .IsRequired();

        builder.Property(c => c.Descricao)
            .IsRequired();

        builder.Property(c => c.Valor)
            .IsRequired();

        builder.Property(c => c.Quantidade)
            .IsRequired();

        builder.Property(c => c.ExibeNoSite);

        builder.Property(c => c.CategoriaId)
            .IsRequired();
    }
}