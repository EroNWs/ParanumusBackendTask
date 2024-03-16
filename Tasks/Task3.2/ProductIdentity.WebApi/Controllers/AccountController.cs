using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductIdentity.Infrastracture.Interface;
using ProductIdentity.Models;

namespace ProductIdentity.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationRepository _authRepository;
        private readonly UserManager<User> _userManager;

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] User user)
        {
            var result = await _userManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);

                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }
    }
}
