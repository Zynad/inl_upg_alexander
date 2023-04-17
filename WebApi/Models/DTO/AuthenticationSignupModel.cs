using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WebApi.Models.Entities;
using WebApi.Models.Identity;

namespace WebApi.Models.DTO;

public class AuthenticationSignupModel
{
    [Required]
    [MinLength(2)]
    public string FirstName { get; set; } = null!;
    [Required]
    [MinLength(2)]
    public string LastName { get; set; } = null!;
    [Required]
    [MinLength(6)]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
    public string Email { get; set; } = null!;
    [Required]
    [MinLength(8)]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$")]
    public string Password { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string RoleName { get; set; } = "productChief";

    public static implicit operator CustomIdentityUser(AuthenticationSignupModel model)
    {
        if (model.PhoneNumber == null || model.PhoneNumber == "")
        {
            return new CustomIdentityUser
            {
                UserName = model.Email,
                Email = model.Email,
            };
        }
        else
        {
            return new CustomIdentityUser
            {
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };
        }
        
    }

    public static implicit operator UserProfileEntity(AuthenticationSignupModel model)
    {
        return new UserProfileEntity
        {
            FirstName = model.FirstName,
            LastName = model.LastName
        };
    }
}
