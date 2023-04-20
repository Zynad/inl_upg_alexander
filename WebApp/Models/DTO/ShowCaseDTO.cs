namespace WebApp.Models.DTO;

public class ShowCaseDTO
{
	public int Id { get; set; }
	public string Title { get; set; } = null!;
	public string Ingress { get; set; } = null!;
	public string DeliveryText { get; set; } = null!;
	public string ButtonText { get; set; } = null!;
	public string ImageUrl { get; set; } = null!;
}
