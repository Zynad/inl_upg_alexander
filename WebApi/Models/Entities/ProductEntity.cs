using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities;

public class ProductEntity
{
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string Title { get; set; } = null!;
    [Range(0,double.MaxValue)]
    [DataType(DataType.Currency)]
    public double Price { get; set; }
    public string ImageUrl { get; set; } = null!;
    public int TagId { get; set; }
    public TagEntity Tag { get; set; } = null!;
    public DateTime Created { get; set; }
    public int CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = null!;
    public string Description { get; set; } = null!;
    [Range(1,5)]
    public int StarRating { get; set; }
    public string SKU { get; set; } = null!;
    public string Brand { get; set; } = null!;
}