using Microsoft.EntityFrameworkCore;
using Anjos.Domain.Entities;

namespace Anjos.Database.Context;

public class AnjosContext : DbContext
{
    public AnjosContext(DbContextOptions<AnjosContext> options) : base(options) { }

    public DbSet<Produto> Produto { get; set; }
    public DbSet<Venda> Venda { get; set; }
    public DbSet<VendaProduto> VendaProduto { get; set; }
    public DbSet<Categoria> Categoria { get; set; }
    public DbSet<Entrada> Entrada { get; set; }
    public DbSet<EntradaProduto> EntradaProduto { get; set; }
    public DbSet<Parcela> Parcela { get; set; }
    public DbSet<ContaPagar> ContaPagar { get; set; }
    public DbSet<ContaReceber> ContaReceber { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        AddMappingsDynamically(builder);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    private static void AddMappingsDynamically(ModelBuilder builder)
    {
        var currentAssembly = typeof(AnjosContext).Assembly;
        var efMappingTypes = currentAssembly.GetTypes().Where(t =>
            t.FullName != null && t.FullName.StartsWith("Anjos.Database.Mapping.") && t.FullName.EndsWith("Mapping"));

        foreach (var map in efMappingTypes.Select(Activator.CreateInstance))
        {
            builder.ApplyConfiguration((dynamic)map!);
        }
    }
}
