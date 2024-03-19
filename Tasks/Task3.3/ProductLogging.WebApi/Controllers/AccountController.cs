using Microsoft.AspNetCore.Mvc;
using ProductLogging.Application.Contracts;
using ProductLogging.Application.Interfaces;
using ProductLogging.Dtos;

namespace ProductLogging.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{

    private readonly IAuthenticationService _authenticationService;
    private readonly ILoggerService _logger;

    public AccountController(IAuthenticationService authenticationService, ILoggerService logger)
    {

        _authenticationService = authenticationService;
        _logger = logger;

    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDtos model)
    {
        _logger.LogInfo("Registering a new user.");

        if (!ModelState.IsValid)
        {
            _logger.LogError("User registration failed due to invalid model state.");
            return BadRequest(ModelState);

        }

        var result = await _authenticationService.RegisterUserAsync(model);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {

                ModelState.TryAddModelError(error.Code, error.Description);

                _logger.LogError($"User registration error: {error.Description}");

            }

            return BadRequest(ModelState);

        }

        _logger.LogInfo("User registered successfully.");
        return Ok(new { Message = "User registered successfully" });

    }

    [HttpPost("login")]
    public async Task<IActionResult> Authenticate([FromBody] UserAuthenticationDto userAuthenticationDto)
    {
        _logger.LogInfo("Authenticating user.");
        var result = await _authenticationService.AuthenticateAsync(userAuthenticationDto);

        if (!result)
        {
            _logger.LogError("User authentication failed.");
            return Unauthorized();
        }

        var token = await _authenticationService.CreateToken();
        _logger.LogInfo("User authenticated successfully, token created.");

        return Ok(new { Token = token });
    }
}
