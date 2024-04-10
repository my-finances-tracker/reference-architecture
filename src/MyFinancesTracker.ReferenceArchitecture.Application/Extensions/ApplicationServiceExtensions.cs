using System.Reflection;
using System.Reflection.Metadata;
using Microsoft.Extensions.DependencyInjection;
using MyFinancesTracker.Common.Crosscutting.Attributes.ServiceLifetime;

namespace MyFinancesTracker.Reference.Application.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // services.AddValidatorsFromAssembly(typeof(AssemblyReference).Assembly, includeInternalTypes: true);

        services.Scan(scan => scan.FromAssemblies(typeof(ApplicationAssemblyReference).Assembly)
            .AddClasses(classes => classes.WithAttribute<SingletonLifetimeAttribute>()).AsImplementedInterfaces().WithSingletonLifetime()
            .AddClasses(classes => classes.WithAttribute<ScopedLifetimeAttribute>()).AsImplementedInterfaces().WithScopedLifetime()
            .AddClasses(classes => classes.WithAttribute<TransientLifetimeAttribute>()).AsImplementedInterfaces().WithTransientLifetime());

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        
        return services;
    }
}
