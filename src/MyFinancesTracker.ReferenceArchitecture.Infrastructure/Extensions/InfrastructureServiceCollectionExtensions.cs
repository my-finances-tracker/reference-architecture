using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyFinancesTracker.Common.Crosscutting.Attributes.ServiceLifetime;
using MyFinancesTracker.Common.Crosscutting.Extensions;
using MyFinancesTracker.ReferenceArchitecture.Infrastructure.Context;

namespace MyFinancesTracker.ReferenceArchitecture.Infrastructure.Extensions;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        if (configuration.GetRequiredBool("RunInMemoryDatabase"))
        {
            services.AddDatabaseAccessInMemory("MyFinancesTracker");
        }
        else
        {
            services.AddDatabaseAccess(configuration.GetRequiredConnectionString("DefaultConnection"));
        }
        
        services.Scan(scan => scan.FromAssemblies(typeof(InfrastructureAssemblyReference).Assembly)
            .AddClasses(classes => classes.WithAttribute<SingletonLifetimeAttribute>()).AsImplementedInterfaces().WithSingletonLifetime()
            .AddClasses(classes => classes.WithAttribute<ScopedLifetimeAttribute>()).AsImplementedInterfaces().WithScopedLifetime()
            .AddClasses(classes => classes.WithAttribute<TransientLifetimeAttribute>()).AsImplementedInterfaces().WithTransientLifetime());
        return services;
    }
    
    private static IServiceCollection AddDatabaseAccess(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<TransactionDbContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped<ITransactionDbContext>(p => p.GetRequiredService<TransactionDbContext>());

        return services;
    }

    // INFO: handy for development and possibly component testing.
    private static IServiceCollection AddDatabaseAccessInMemory(this IServiceCollection services, string databaseName)
    {
        services.AddDbContext<TransactionDbContext>(options => options.UseInMemoryDatabase(databaseName));
        services.AddScoped<TransactionDbContext>(p => p.GetRequiredService<TransactionDbContext>());

        return services;
    }
}
