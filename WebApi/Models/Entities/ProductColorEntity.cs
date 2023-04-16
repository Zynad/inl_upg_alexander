using _02_EFC_CodeFirst.Models.Entities;

namespace WebApi.Models.Entities;

public class ProductColorEntity
{
    public int Id { get; set; }
    public string ColorName { get; set; } = null!;

    public ICollection<ProductEntity> Products { get; set; } = new HashSet<ProductEntity>();
}
