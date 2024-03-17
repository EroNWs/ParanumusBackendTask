﻿using BookStore.Dal.EntityFramework.Repositories;
using BookStore.Dal.EntityFramework.Seeds;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Dal.EntityFramework.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddEFCoreServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAdminRepository,AdminRepository>();
        services.AddScoped<ICustomerRepository,CustomerRepository>();
        services.AddScoped<IBookRepository,BookRepository>();
        services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        AdminSeed.SeedAsync(configuration).GetAwaiter().GetResult();

        return services;
    }
}