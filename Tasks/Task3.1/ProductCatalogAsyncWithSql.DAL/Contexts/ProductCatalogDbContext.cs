using Microsoft.EntityFrameworkCore;
using ProductCatalogAsyncWithSql.Models;

namespace ProductCatalogAsyncWithSql.DAL.Contexts;

public class ProductCatalogDbContext:DbContext
{
    public DbSet<Product> Products { get; set; }
    public ProductCatalogDbContext(DbContextOptions<ProductCatalogDbContext> options)
                : base(options)
    {
    }

}
