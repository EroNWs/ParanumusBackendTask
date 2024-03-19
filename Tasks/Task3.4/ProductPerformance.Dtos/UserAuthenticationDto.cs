using System.ComponentModel.DataAnnotations;

namespace ProductPerformance.Dtos;

public record UserAuthenticationDto
{
    public string UserName { get; init; }

    public string Password { get; init; }

}
