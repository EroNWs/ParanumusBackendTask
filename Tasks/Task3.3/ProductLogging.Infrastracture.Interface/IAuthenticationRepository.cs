using ProductLogging.Dtos;
using ProductLogging.Models;
using Microsoft.AspNetCore.Identity;

namespace ProductLogging.Infrastracture.Interface;

public interface IAuthenticationRepository
{
    Task<string> GenerateJwtToken(User user);
    Task<IdentityResult> RegisterUser(User user, string password, List<string> roles);
    Task<bool> AuthenticateAsync(UserAuthenticationDto userAuthenticationDto);

    Task<string> CreateToken();
}
