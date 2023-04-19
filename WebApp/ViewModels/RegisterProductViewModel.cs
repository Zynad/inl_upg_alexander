using Mvc.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels;

public class RegisterProductViewModel
{
    [Required(ErrorMessage = "This field is required")]
    [MaxLength(50, ErrorMessage = "Max 50 characters")]
    public string Title { get; set; } = null!;
    [Required(ErrorMessage = "This field is required")]
    [Range(0, double.MaxValue, ErrorMessage = "Invalid price")]
    public double Price { get; set; }
    [Required(ErrorMessage = "This field is required")]
    public string ImageUrl { get; set; } = null!;
    [Required(ErrorMessage = "This field is required")]
    public string Tag { get; set; } = null!;
    [Required(ErrorMessage = "This field is required")]
    public string Category { get; set; } = null!;
    [Required(ErrorMessage = "This field is required")]
    [MaxLength(200, ErrorMessage = "Max 200 characters")]
    public string Description { get; set; } = null!;
    [Required(ErrorMessage = "This field is required")]
    [Range(1, 5, ErrorMessage = "Invalid rating")]
    public int StarRating { get; set; }
    [StringLength(8)]
    [Required(ErrorMessage = "This field is required")]
    public string SKU { get; set; } = null!;
    [Required(ErrorMessage = "This field is required")]
    public string Brand { get; set; } = null!;
    public string ConfirmationMessage { get; set; } = "";


    public static implicit operator CreateProductDTO(RegisterProductViewModel model)
    {
        return new CreateProductDTO
        {
            Title = model.Title,
            Price = model.Price,
            ImageUrl = model.ImageUrl,
            Tag = model.Tag,
            Category = model.Category,
            Description = model.Description,
            StarRating = model.StarRating,
            SKU = model.SKU,
            Brand = model.Brand,
        };
    }
}