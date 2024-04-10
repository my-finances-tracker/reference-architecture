using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MyFinancesTracker.ReferenceArchitecture.Presentation.Extensions;

public static class PresentationServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        services.AddControllers()
            .AddApplicationPart(typeof(PresentationAssemblyReference).Assembly);
        services.AddEndpointsApiExplorer();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}
