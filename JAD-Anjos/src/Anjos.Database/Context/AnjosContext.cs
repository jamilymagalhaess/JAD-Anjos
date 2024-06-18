using Microsoft.EntityFrameworkCore;


namespace Anjos.Database.Context;

public class AnjosContext : DbContext
{
    public AnjosContext(DbContextOptions options) : base(options) { }

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
