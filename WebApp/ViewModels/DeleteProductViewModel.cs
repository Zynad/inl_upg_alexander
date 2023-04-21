using WebApp.Models.DTO;

namespace WebApp.ViewModels;

public class DeleteProductViewModel
{
    public int Id { get; set; }
    public string ConfirmationMessage { get; set; } = "";
}
