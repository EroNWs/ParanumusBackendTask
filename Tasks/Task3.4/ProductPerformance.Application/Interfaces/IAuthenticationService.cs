using Microsoft.AspNetCore.Identity;
using ProductPerformance.Dtos;
using ProductPerformance.Models;

namespace ProductPerformance.Application.Interfaces;

public interface IAuthenticationService
{
    Task<string> CreateToken();
    Task<string> GenerateJwtToken(User user);
    Task<bool> AuthenticateAsync(UserAuthenticationDto userLoginDto);
    Task<IdentityResult> RegisterUserAsync(RegisterUserDtos userRegistrationDto);

}
