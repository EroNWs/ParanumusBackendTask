using BookStore.Business.Contracts;
using BookStore.Business.LoggingService;
using BookStore.Business.Services;
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
}
