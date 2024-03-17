using BookStore.Dal.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookStore.WebApi.ContextFactory;

public class BookStoreDbContextFactory:IDesignTimeDbContextFactory<BookStoreDbContext>
{
public BookStoreDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

        var builder = new DbContextOptionsBuilder<BookStoreDbContext>().UseSqlServer(configuration.GetConnectionString("ParanamusDbContext"), prj=>prj.MigrationsAssembly("BookStore.Dal"));

        return new BookStoreDbContext(builder.Options);
    }

}
