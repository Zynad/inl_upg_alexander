namespace WebApi.Models.DTO;

public class AuthenticationLoginModel
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}
