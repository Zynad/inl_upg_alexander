using WebApi.Models.Entities;

namespace WebApi.Models.DTO;

public class CreateProductDTO
{
    public string Title { get; set; } = null!;
    public double Price { get; set; }
    public string ImageUrl { get; set; } = null!;
    public string Tag { get; set; } = null!;
    public string Category { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int StarRating { get; set; }
    public string SKU { get; set; } = null!;
    public string Brand { get; set; } = null!;

    public static implicit operator ProductEntity(CreateProductDTO dto)
    {
        return new ProductEntity
        {
            Title = dto.Title,
            Price = dto.Price,
            ImageUrl = dto.ImageUrl,
            Description = dto.Description,
            StarRating = dto.StarRating,
            SKU = dto.SKU,
            Brand = dto.Brand,
        };
    }
}
