using Microsoft.Extensions.DependencyInjection;
using ProductIdentity.Infrastracture.Interface;

namespace ProductIdentity.Infrastracture.Extensions;

public static class RepositoryExtensions
{
    public static IServiceCollection AddInfrastractureExtensions(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
