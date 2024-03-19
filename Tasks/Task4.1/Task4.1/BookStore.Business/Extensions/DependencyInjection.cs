using BookStore.Business.Contracts;
using BookStore.Business.LoggingService;
using BookStore.Business.Services;
using Marvin.Cache.Headers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookStore.Business.Extensions;

public static class DependencyInjection
{

    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IPurchaseService,PurchaseService>();
        services.AddSingleton<IInMemoryDataStoreService,InMemoryDataStoreService>();
        services.AddSingleton<ILoggerService, LoggerManager>();
        services.AddScoped<IBookService, BookService>();

        return services;

    }

    public static void ConfigureResponseCaching(this IServiceCollection services) => services.AddResponseCaching();

    public static void ConfigureHttpCacheHeaders(this IServiceCollection services) => services.AddHttpCacheHeaders(expirationOptions =>
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
