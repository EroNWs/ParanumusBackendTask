using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductIdentity.Dtos;
using ProductIdentity.Models;

namespace ProductIdentity.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {   
        private readonly UserManager<User> _userManager;

        public AccountController(UserManager<User> userManager)
        {   
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDtos model) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                EmailConfirmed = model.EmailConfirmed,
                PhoneNumber = model.PhoneNumber,
                PhoneNumberConfirmed = model.PhoneNumberConfirmed,
                TwoFactorEnabled = model.TwoFactorEnabled,
                LockoutEnabled = model.LockoutEnabled,
                AccessFailedCount = model.AccessFailedCount,
                FirstName = model.FirstName,
                LastName = model.LastName,

            };

            var result = await _userManager.CreateAsync(user, model.Password);

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
    }
}