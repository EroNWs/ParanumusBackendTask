using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductIdentity.Models;

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
        builder.ApplyConfiguration(new RoleConfiguration());

    }

}
