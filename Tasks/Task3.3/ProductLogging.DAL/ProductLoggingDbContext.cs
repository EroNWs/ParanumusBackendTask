using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductLogging.Models;
using System.Reflection;

namespace ProductLogging.DAL;

public class ProductLoggingDbContext : IdentityDbContext<User>
{
    public DbSet<Product> Products { get; set; }
    public ProductLoggingDbContext(DbContextOptions<ProductLoggingDbContext> options)
                : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }

}
