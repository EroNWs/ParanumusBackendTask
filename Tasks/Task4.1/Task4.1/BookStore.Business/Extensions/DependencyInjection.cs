using BookStore.Business.Interfaces;
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
        services.AddScoped<IBookService, BookService>();
        return services;
    }
}
