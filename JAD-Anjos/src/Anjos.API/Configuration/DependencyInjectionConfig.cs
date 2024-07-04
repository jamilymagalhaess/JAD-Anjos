// DependencyInjectionConfig.cs
using Anjos.Application.Interfaces;
using Anjos.Application.Services;
using Anjos.Database.Repositories;

namespace Anjos.API.Configuration;

public static class DependencyInjectionConfig
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        AddRepositories(services);
        AddServices(services);
    }
    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<ICategoriaRepository, CategoriaRepository>();
        services.AddScoped<IEntradaRepository, EntradaRepository>();
        services.AddScoped<IEntradaProdutoRepository, EntradaProdutoRepository>();
        services.AddScoped<IParcelaRepository, ParcelaRepository>();
        services.AddScoped<IVendaRepository, VendaRepository>();
        services.AddScoped<IVendaProdutoRepository, VendaProdutoRepository>();
        services.AddScoped<IContaPagarRepository, ContaPagarRepository>();
        services.AddScoped<IContaReceberRepository, ContaReceberRepository>();
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IProdutoService, ProdutoService>();
        services.AddScoped<ICategoriaService, CategoriaService>();
        services.AddScoped<IEntradaRepository, EntradaRepository>();
        services.AddScoped<IEntradaProdutoRepository, EntradaProdutoRepository>();
        services.AddScoped<IParcelaRepository, ParcelaRepository>();
        services.AddScoped<IVendaRepository, VendaRepository>();
        services.AddScoped<IVendaProdutoRepository, VendaProdutoRepository>();
        services.AddScoped<IContaPagarRepository, ContaPagarRepository>();
        services.AddScoped<IContaReceberRepository, ContaReceberRepository>();
    }
}
