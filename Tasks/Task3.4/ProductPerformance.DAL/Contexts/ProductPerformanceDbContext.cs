using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductPerformance.Models;
using System.Reflection;

namespace ProductPerformance.DAL.Contexts;

public class ProductPerformanceDbContext : IdentityDbContext<User>
{
    public DbSet<Product> Products { get; set; }
    public ProductPerformanceDbContext(DbContextOptions<ProductPerformanceDbContext> options)
                : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }

}