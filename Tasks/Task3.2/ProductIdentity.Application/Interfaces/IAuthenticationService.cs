using ProductIdentity.Dtos;

namespace ProductIdentity.Application.InterfacesÜ;

public interface IAuthenticationService
{
    Task<bool> AuthenticateAsync(UserAuthenticationDto userAuthenticationDto);
}
