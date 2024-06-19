using Microsoft.EntityFrameworkCore;
using Anjos.Model.Entities.Entrada;
using Anjos.Model.Entities.Parcela;
using Anjos.Model.Entities.Produto;
using Anjos.Model.Entities.Venda;
using Anjos.Model.Entities.Conta;
using Anjos.Model.Entities.Categoria;


namespace Anjos.Database.Context;

public class AnjosContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produto { get; set; }
    public DbSet<Parcela> Parcela { get; set; }
    public DbSet<Entrada> Entrada { get; set; }
    public DbSet<EntradaProduto> EntradaProduto { get; set; }
    public DbSet<ContaPagar> ContaPagar { get; set; }
    public DbSet<ContaReceber> ContaReceber { get; set; }
    public DbSet<Venda> Venda { get; set; }
    public DbSet<VendaProduto>VendaProduto { get; set; }

    public AnjosContext(DbContextOptions<AnjosContext> options) : base(options) { }

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
