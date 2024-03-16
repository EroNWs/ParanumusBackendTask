using Microsoft.Extensions.DependencyInjection;
using ProductLogging.Application.Contracts;
using ProductLogging.Application.Interfaces;
using ProductLogging.Application.MappingConfig;
using ProductLogging.Application.Services;

namespace ProductLogging.Application.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureLoggerService(this IServiceCollection services)
 => services.AddSingleton<ILoggerService, LoggerManager>();

    public static IServiceCollection AddServiceExtensions(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IProductService, ProductService>();  
        services.AddAutoMapper(typeof(MappingProfile));
        return services;
    }
}
