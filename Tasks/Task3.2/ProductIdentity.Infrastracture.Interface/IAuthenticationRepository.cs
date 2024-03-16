using Microsoft.AspNetCore.Identity;
using ProductIdentity.Dtos;
using ProductIdentity.Models;

namespace ProductIdentity.Infrastracture.Interface;

public interface IAuthenticationRepository
{
    Task<string> GenerateJwtToken(User user);
    Task<IdentityResult> RegisterUser(User user, string password, List<string> roles);
    Task<bool> AuthenticateAsync(UserAuthenticationDto userAuthenticationDto);,

    Task<string> CreateToken();
}
