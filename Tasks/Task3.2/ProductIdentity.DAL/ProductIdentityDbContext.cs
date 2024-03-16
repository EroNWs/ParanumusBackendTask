using Microsoft.EntityFrameworkCore;
using ProductIdentity.Models;

namespace ProductIdentity.DAL;

public class ProductIdentityDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public ProductIdentityDbContext(DbContextOptions<ProductIdentityDbContext> options)
                : base(options)
    {
    }

}
