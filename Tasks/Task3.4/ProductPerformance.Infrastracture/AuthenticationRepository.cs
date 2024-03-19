using Microsoft.AspNetCore.Identity;
using ProductPerformance.Dtos;
using ProductPerformance.Infrastracture.Interface;
using ProductPerformance.Models;

namespace ProductPerformance.Infrastracture;

public class AuthenticationRepository: IAuthenticationRepository
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
  
    public AuthenticationRepository(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;

        _roleManager = roleManager;

    }


    public async Task<IdentityResult> RegisterUser(User user, string password, List<string> roles)
    {
        var result = await _userManager.CreateAsync(user, password);

        if (result.Succeeded && roles != null)
        {
            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {

                    await _roleManager.CreateAsync(new IdentityRole(role));

                }

                await _userManager.AddToRoleAsync(user, role);

            }
        }

        return result;

    }

    public async Task<User?> AuthenticateAsync(UserAuthenticationDto userAuthenticationDto)
    {
        var user = await _userManager.FindByNameAsync(userAuthenticationDto.UserName);

        var result = (user != null && await _userManager.CheckPasswordAsync(user, userAuthenticationDto.Password));

        if (!result)
        {

            return null;

        }

        return user;

    }

    public async Task<User> FindByNameAsync(string userName)
    {

        return await _userManager.FindByNameAsync(userName);

    }


}
