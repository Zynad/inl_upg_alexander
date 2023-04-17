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

    public int CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = null!;
}