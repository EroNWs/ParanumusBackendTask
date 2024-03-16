using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProductIdentity.Dtos;
using ProductIdentity.Infrastracture.Interface;
using ProductIdentity.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductIdentity.Infrastracture;

public class AuthenticationRepository : IAuthenticationRepository
{
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;
    private readonly RoleManager<IdentityRole> _roleManager;

    private User? _user;
    public AuthenticationRepository(UserManager<User> userManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _configuration = configuration;
        _roleManager = roleManager;
    }

    public async Task<string> GenerateJwtToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
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

    public async Task<bool> AuthenticateAsync(UserAuthenticationDto userAuthenticationDto)
    {
        _user = await _userManager.FindByNameAsync(userAuthenticationDto.UserName);

        var result = (_user !=null && await _userManager.CheckPasswordAsync(_user, userAuthenticationDto.Password));

        if (!result)
        {
            return false;
        }

        return result; 
    }


}
