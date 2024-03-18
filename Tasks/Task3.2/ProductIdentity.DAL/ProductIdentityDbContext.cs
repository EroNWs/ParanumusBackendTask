using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ProductIdentity.Models;
using System.Reflection;

namespace ProductIdentity.DAL;

public class ProductIdentityDbContext :IdentityDbContext<User>
{
    public DbSet<Product> Products { get; set; }
    public ProductIdentityDbContext(DbContextOptions<ProductIdentityDbContext> options)
                : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }

}
