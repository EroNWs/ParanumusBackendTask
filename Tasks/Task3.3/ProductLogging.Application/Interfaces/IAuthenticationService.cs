using Microsoft.AspNetCore.Identity;
using ProductLogging.Dtos;
using ProductLogging.Models;

namespace ProductLogging.Application.Interfaces;

public interface IAuthenticationService
{
    Task<string> CreateToken();
    Task<string> GenerateJwtToken(User user);
    Task<bool> AuthenticateAsync(UserAuthenticationDto userLoginDto);
    Task<IdentityResult> RegisterUserAsync(RegisterUserDtos userRegistrationDto);

}
