using Microsoft.AspNetCore.Identity;
using ProductIdentity.Dtos;

namespace ProductIdentity.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {   
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationRepository _authenticationRepository;
        public AccountController(UserManager<User> userManager, IAuthenticationRepository authenticationRepository)
        {
            _userManager = userManager;
            _authenticationRepository = authenticationRepository;
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

            var result = await _authenticationRepository.RegisterUser(user, model.Password, model.Roles);
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
        public async Task<IActionResult> Authenticate([FromBody]UserAuthenticationDto userAuthenticationDto)
        {

            if(!await _authenticationRepository.AuthenticateAsync(userAuthenticationDto))
                return Unauthorized();

            return Ok(
                new
                {
                    Token = await _authenticationRepository.CreateToken()
                }) ;
        }

    }
}