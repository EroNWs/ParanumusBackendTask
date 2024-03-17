using Microsoft.AspNetCore.Mvc;
using ProductLogging.Application.Interfaces;
using ProductLogging.Dtos;

namespace ProductLogging.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AccountController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDtos model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _authenticationService.RegisterUserAsync(model);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.TryAddModelError(error.Code, error.Description);
            }
            return BadRequest(ModelState);
        }

        return Ok(new { Message = "User registered successfully" });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Authenticate([FromBody] UserAuthenticationDto userAuthenticationDto)
    {
        var result = await _authenticationService.AuthenticateAsync(userAuthenticationDto);

        if (!result)
            return Unauthorized();

        var token = await _authenticationService.CreateToken();

        return Ok(new { Token = token });
    }
}
