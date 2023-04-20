using WebApp.Models.DTO;

namespace WebApp.ViewModels;

public class HomeViewModel
{
	public ShowCaseDTO ShowCase { get; set; } = null!;
	public IEnumerable<ProductDTO> Featured { get; set; } = new List<ProductDTO>();
	public IEnumerable<ProductDTO> Popular { get; set; } = new List<ProductDTO>();
    public IEnumerable<ProductDTO> New { get; set; } = new List<ProductDTO>();
}
