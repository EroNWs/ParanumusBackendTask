using Microsoft.AspNetCore.Identity;
using ProductIdentity.Models;

namespace ProductIdentity.Infrastracture.Interface;

public interface IAuthenticationRepository
{
    Task<IdentityResult> RegisterUser(User user);
}
