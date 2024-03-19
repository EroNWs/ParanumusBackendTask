using Microsoft.AspNetCore.Identity;
using ProductLogging.Dtos;
using ProductLogging.Models;

namespace ProductLogging.Infrastracture.Interface;

public interface IAuthenticationRepository
{
    Task<IdentityResult> RegisterUser(User user, string password, List<string> roles);
    Task<User> FindByNameAsync(string userName);
    Task<User?> AuthenticateAsync(UserAuthenticationDto userAuthenticationDto);

}

