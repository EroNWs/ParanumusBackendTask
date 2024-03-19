using Microsoft.AspNetCore.Identity;

namespace ProductPerformance.Models;

public class User : IdentityUser
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

}
