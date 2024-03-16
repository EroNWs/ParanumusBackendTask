using System.ComponentModel.DataAnnotations;

namespace ProductIdentity.Dtos;

public record UserAuthenticationDto
{
    [Required(ErrorMessage = "Username is Required")]
    public string? UserName { get; init; }

    [Required(ErrorMessage ="Password is Required")]
    public string? Password { get; init; }

}
