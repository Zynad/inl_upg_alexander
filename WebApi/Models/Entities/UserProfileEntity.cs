using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Models.Identity;

namespace WebApi.Models.Entities;

public class UserProfileEntity
{
    [Key,ForeignKey(nameof(User))]
    public string UserId { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public CustomIdentityUser User { get; set; } = null!;
}
