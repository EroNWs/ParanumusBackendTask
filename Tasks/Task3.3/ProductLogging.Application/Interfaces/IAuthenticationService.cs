using ProductLogging.Dtos;

namespace ProductLogging.Application.Interfaces;

public interface IAuthenticationService
{
    Task<bool> AuthenticateAsync(UserAuthenticationDto userAuthenticationDto);
}
