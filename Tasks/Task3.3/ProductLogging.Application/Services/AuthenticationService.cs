using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProductLogging.Application.Interfaces;
using ProductLogging.Dtos;
using ProductLogging.Infrastracture.Interface;
using ProductLogging.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductLogging.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;
    private User? _user;
    private readonly IAuthenticationRepository _authenticationRepository;
    private readonly IMapper _mapper;

    public AuthenticationService(UserManager<User> userManager, IConfiguration configuration,
        IAuthenticationRepository authenticationRepository, IMapper mapper)
    {
        _userManager = userManager;
        _configuration = configuration;
        _authenticationRepository = authenticationRepository;
        _mapper = mapper;

    }

    public async Task<IdentityResult> RegisterUserAsync(RegisterUserDtos userRegistrationDto)
    {
        var user = _mapper.Map<User>(userRegistrationDto);
        return await _authenticationRepository.RegisterUser(user, userRegistrationDto.Password, userRegistrationDto.Roles);
    }


    public async Task<bool> AuthenticateAsync(UserAuthenticationDto userLoginDto)
    {
        var user = await _authenticationRepository.AuthenticateAsync(userLoginDto);
        if (user is null)
        {
            return false;
        }

        _user = user;
        return true;

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



    public async Task<string> CreateToken()
    {
        var signinCredentials = GetSignInCredentials();
        var claims = await GetClaims();
        var tokenOptions = GenerateTokenOptions(signinCredentials, claims);
        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);

    }



    private SigningCredentials GetSignInCredentials()
    {
        var jwtSettings = _configuration.GetSection("Jwt");
        var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);
        var secret = new SymmetricSecurityKey(key);
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);

    }





    private async Task<List<Claim>> GetClaims()
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, _user.UserName)
        };

        var roles = await _userManager.GetRolesAsync(_user);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        return claims;

    }


    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    {
        var jwtSettings = _configuration.GetSection("Jwt");

        var tokenOptions = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
            signingCredentials: signingCredentials
            );

        return tokenOptions;
    }


}

