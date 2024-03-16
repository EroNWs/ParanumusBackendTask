using Microsoft.AspNetCore.Identity;
using ProductIdentity.Models;

namespace ProductIdentity.Infrastracture.Interface;

public interface IAuthenticationRepository
{
    Task<string> GenerateJwtToken(User user);
    Task<IdentityResult> RegisterUser(User user, string password, List<string> roles);
}
