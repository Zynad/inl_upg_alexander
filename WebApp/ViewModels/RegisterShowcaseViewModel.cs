using System.ComponentModel.DataAnnotations;
using WebApp.Models.DTO;

namespace WebApp.ViewModels;

public class RegisterShowcaseViewModel
{
    [Required(ErrorMessage = "This field is required")]
    [MaxLength(50)]
    public string Title { get; set; } = null!;
    [Required(ErrorMessage = "This field is required")]
    [MaxLength(50)]
    public string Ingress { get; set; } = null!;
    [Required(ErrorMessage = "This field is required")]
    [MaxLength (100)]
    public string DeliveryText { get; set; } = null!;
    [Required(ErrorMessage = "This field is required")]
    [MaxLength(30)]
    public string ButtonText { get; set; } = null!;
    [Required(ErrorMessage = "This field is required")]
    public string ImageUrl { get; set; } = null!;
    public string ConfirmationMessage { get; set; } = "";

    public static implicit operator CreateShowCaseDTO(RegisterShowcaseViewModel model)
    {
        return new CreateShowCaseDTO
        {
            Title = model.Title,
            Ingress = model.Ingress,
            DeliveryText = model.DeliveryText,
            ButtonText = model.ButtonText,
            ImageUrl = model.ImageUrl,
        };
    }
}
