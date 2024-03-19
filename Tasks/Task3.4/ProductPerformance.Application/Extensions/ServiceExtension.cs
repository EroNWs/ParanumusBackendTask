using Marvin.Cache.Headers;
using Microsoft.Extensions.DependencyInjection;
using ProductPerformance.Application.Contracts;
using ProductPerformance.Application.Interfaces;
using ProductPerformance.Application.Mapping;
using ProductPerformance.Application.Services;

namespace ProductPerformance.Application.Extensions;

public static class ServiceExtension
{
    public static void ConfigureLoggerService(this IServiceCollection services)
=> services.AddSingleton<ILoggerService, LoggerManager>();

    public static IServiceCollection AddServiceExtensions(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddSingleton<ILoggerService, LoggerManager>();
        services.AddAutoMapper(typeof(MappingProfile));

        return services;

    }

    public static void ConfigureResponseCaching(this IServiceCollection services) => services.AddResponseCaching();

    public static void ConfigureHttpCacheHeaders(this IServiceCollection services)=> services.AddHttpCacheHeaders(expirationOptions =>
    {

        expirationOptions.MaxAge = 70;
        expirationOptions.CacheLocation = CacheLocation.Private;

    },
        validatonOptions =>
        {
            validatonOptions.MustRevalidate = false;
        }
    );
}
