using Microsoft.AspNetCore.Identity;

namespace ProductLogging.Models;

public class User : IdentityUser
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }
}
