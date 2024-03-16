using ProductLogging.Application.Interfaces;
using ProductLogging.Dtos;

namespace ProductLogging.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    public Task<bool> AuthenticateAsync(UserAuthenticationDto userAuthenticationDto)
    {
        throw new NotImplementedException();
    }
}

