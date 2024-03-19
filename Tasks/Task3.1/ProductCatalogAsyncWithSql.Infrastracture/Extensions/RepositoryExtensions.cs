using Microsoft.Extensions.DependencyInjection;

namespace ProductCatalogAsyncWithSql.Infrastracture.Extensions;

public static class RepositoryExtensions
{
    public static IServiceCollection AddInfrastractureExtensions(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
    }
}
