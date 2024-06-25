// DependencyInjectionConfig.cs
using Anjos.Application.Interfaces;
using Anjos.Application.Services;
using Anjos.Database.Repositories.Produto;

namespace Anjos.API.Configuration;

public static class DependencyInjectionConfig
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        AddRepositories(services);
        AddServices(services);
        AddFactories(services);
    }
    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IProdutoService, ProdutoService>();
    }

    private static void AddFactories(IServiceCollection services)
    {
        // factory
    }
}
