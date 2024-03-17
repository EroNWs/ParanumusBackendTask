using BookStore.Core.Enums;
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

        await Task.CompletedTask;
    }

    private static async Task AddAdmin(BookStoreDbContext context)
    {
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

        var adminRoleId = context.Roles.FirstOrDefault(role => role.Name == Roles.Admin.ToString())!.Id;

        await context.UserRoles.AddAsync(new IdentityUserRole<string> { UserId = user.Id, RoleId = adminRoleId });


        context.Admins.Add(new Admin
        {
            Status = Status.Added,
            CreatedBy = "Super-Admin",
            CreatedDate = DateTime.Now,
            ModifiedBy = "Super-Admin",
            ModifiedDate = DateTime.Now,
            FirstName = "Admin",
            LastName = "Admin",
            Email = AdminEmail,
            IdentityId = user.Id,
        });

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
