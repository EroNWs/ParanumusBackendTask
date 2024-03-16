using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ProductIdentity.DAL;
using ProductIdentity.Infrastracture.Interface;
using ProductIdentity.Models;

namespace ProductIdentity.Infrastracture.Extensions;

public static class RepositoryExtensions
{
    public static IServiceCollection AddInfrastractureExtensions(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
       
        return services;
    }
    public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
    {
        var builder = services.AddIdentity<User, IdentityRole>(opts =>
        {
            opts.Password.RequireDigit = true;
            opts.Password.RequireLowercase = false;
            opts.Password.RequireUppercase = false;
            opts.Password.RequireNonAlphanumeric = false;
            opts.Password.RequiredLength = 6;
            opts.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<ProductIdentityDbContext>()
        .AddDefaultTokenProviders();

        return services;
    }
}
