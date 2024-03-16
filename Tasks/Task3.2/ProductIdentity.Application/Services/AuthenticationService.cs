using ProductIdentity.Application.InterfacesÜ;
using ProductIdentity.Dtos;

namespace ProductIdentity.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    public Task<bool> AuthenticateAsync(UserAuthenticationDto userAuthenticationDto)
    {
        throw new NotImplementedException();
    }
}
