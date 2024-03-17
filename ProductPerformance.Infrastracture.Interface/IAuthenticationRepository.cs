using Microsoft.AspNetCore.Identity;
using ProductPerformance.Dtos;
using ProductPerformance.Models;

namespace ProductPerformance.Infrastracture.Interface;

public interface IAuthenticationRepository
{
    Task<IdentityResult> RegisterUser(User user, string password, List<string> roles);
    Task<User> FindByNameAsync(string userName);

    Task<User?> AuthenticateAsync(UserAuthenticationDto userAuthenticationDto);
}
