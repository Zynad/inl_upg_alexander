using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.DTO;

public class AuthenticationLoginModel
{
    [Required]
    public string Email { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
}
