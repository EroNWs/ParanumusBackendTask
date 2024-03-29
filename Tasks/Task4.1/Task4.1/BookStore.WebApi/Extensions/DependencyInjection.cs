﻿using BookStore.Dal.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.Extensions
{
    public static class DependencyInjection
    {
        public static void ConfigureSqlContext(this IServiceCollection services,
    IConfiguration configuration) =>
    services.AddDbContext<BookStoreDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ParanamusDbContext")));

        public static void ConfigureInMemoryContext(this IServiceCollection services) =>
            services.AddDbContext<BookStoreDbContext>(options =>
                options.UseInMemoryDatabase("BookStoreDb"));

    }
}
