using BookStore.Core.Enums;
using BookStore.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BookStore.Dal.EntityFramework.Seeds;

internal static class AdminSeed
{
    private const string AdminEmail = "admin@paranamus.com";

    private const string AdminPassword = "Paranamus1!";
    public static async Task SeedAsync(IConfiguration configuration)
    {
        var dbContextBuilder = new DbContextOptionsBuilder<BookStoreDbContext>();

        dbContextBuilder.UseSqlServer(configuration.GetConnectionString(BookStoreDbContext.ConnectionName));

        using BookStoreDbContext context = new(dbContextBuilder.Options);
        if (!context.Roles.Any())
        {
            await AddRoles(context);
        }

        if (!context.Users.Any(user => user.Email == AdminEmail))
        {
            await AddAdmin(context);
        }
        if (!context.Books.Any())
        {
            await AddBooks(context);
        }

        if (!context.Customers.Any())
        {
            await AddCustomers(context);
        }

        await Task.CompletedTask;
    }

    private static async Task AddAdmin(BookStoreDbContext context)
    {
        if (context.Users.Any(user => user.Email == AdminEmail)) return;

        IdentityUser user = new()
        {
            UserName = AdminEmail,
            NormalizedUserName = AdminEmail.ToUpper(),
            Email = AdminEmail,
            NormalizedEmail = AdminEmail.ToUpper(),
            EmailConfirmed = true
        };
        user.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(user, AdminPassword);
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync(); 


        var adminRole = context.Roles.FirstOrDefault(role => role.Name == Roles.Admin.ToString());
        if (adminRole != null)
        {
            await context.UserRoles.AddAsync(new IdentityUserRole<string> { UserId = user.Id, RoleId = adminRole.Id });
            await context.SaveChangesAsync();
        }
        else
        {

            Console.WriteLine("Admin Role not Found. Please Add Admin Roles!");

        }

    }


    private static async Task AddBooks(BookStoreDbContext context)
    {
        List<Book> books = new List<Book>
        {
            new Book { Title = "Book 1", Author = "Author 1", Isbn = "ISBN0001", ListPrice = 20.00 },
            new Book { Title = "Book 2", Author = "Author 2", Isbn = "ISBN0002", ListPrice = 25.00 },
            new Book { Title = "Book 3", Author = "Author 3", Isbn = "ISBN0003", ListPrice = 30.00 },
        };

        await context.Books.AddRangeAsync(books);
        await context.SaveChangesAsync(); 
    }

    private static async Task AddCustomers(BookStoreDbContext context)
    {
        List<Customer> customers = new List<Customer>
        {
            new Customer { FirstName = "Customer 1", LastName = "One", Email = "customer1@example.com", CustomerRole = CustomerRole.RegularCustomer },
            new Customer { FirstName = "Customer 2", LastName = "Two", Email = "customer2@example.com", CustomerRole = CustomerRole.PremiumCustomer },
            new Customer { FirstName = "Customer 3", LastName = "Three", Email = "customer3@example.com", CustomerRole = CustomerRole.RegularCustomer },
        };

        await context.Customers.AddRangeAsync(customers);
        await context.SaveChangesAsync();
    }


    private static async Task AddRoles(BookStoreDbContext context)
    {
        string[] roles = Enum.GetNames(typeof(Roles));
        for (int i = 0; i < roles.Length; i++)
        {
            if (await context.Roles.AnyAsync(role => role.Name == roles[i]))
            {
                continue;
            }

            await context.Roles.AddAsync(new IdentityRole(roles[i]));
        }
    }
}
