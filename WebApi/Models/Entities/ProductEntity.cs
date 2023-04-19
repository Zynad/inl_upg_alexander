using WebApi.Models.Entities;

namespace _02_EFC_CodeFirst.Models.Entities;

public class ProductEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = null!;
    public string Tag { get; set; } = null!;
    public DateTime Created { get; set; }
    public string Category { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int StarRating { get; set; } = 3;
}