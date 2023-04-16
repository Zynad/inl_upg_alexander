using System.ComponentModel.DataAnnotations;

namespace InlamningsUppgiftFixxo.ViewModels
{
    public class ContactsViewModel
    {
        [Required(ErrorMessage = "Name can't be blank")]
        public string Name { get; set; } = null!;

        [EmailAddress(ErrorMessage = "Not a valid email")]
        public string Email { get; set; } = null!;
        public string Comment { get; set; } = null!;
    }
}
