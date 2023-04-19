namespace Mvc.Models.DTO
{
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
    }
}
