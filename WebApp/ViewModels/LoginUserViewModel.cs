using System.ComponentModel.DataAnnotations;

namespace InlamningsUppgiftFixxo.ViewModels
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "Email field can't be blank")]
        public string Email { get; set; } = null!;

        [Required (ErrorMessage = "Password field can't be blank")]
        public string Password { get; set; } = null!;
    }
}
