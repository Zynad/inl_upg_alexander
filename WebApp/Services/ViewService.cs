using Microsoft.IdentityModel.Tokens;
using WebApp.Models.DTO;
using WebApp.ViewModels;

namespace WebApp.Services;

public class ViewService
{
    private readonly IConfiguration _config;
    private readonly ProductService _productService;

    public ViewService(IConfiguration config, ProductService productService)
    {
        _config = config;
        _productService = productService;
    }

    public async Task<HomeViewModel> CreateHomeViewModelAsync()
    {
        ShowCaseDTO showcase = await GetRandomShowcase();
        IEnumerable<ProductDTO> featuredProducts = await GetFeaturedProducts();
        IEnumerable<ProductDTO> newProducts = await GetNewProducts();
        IEnumerable<ProductDTO> popularProducts = await GetPopularProducts();


        return new HomeViewModel
        {
            ShowCase = showcase,
            Featured = featuredProducts.Take(8),
            New = newProducts.Take(6),
            Popular = popularProducts.Take(6)
        };
    }

    public async Task<ShowCaseDTO> GetRandomShowcase()
    {
        Random random = new Random();
        ShowCaseDTO showCase = new ShowCaseDTO();
        using var http = new HttpClient();
        var allShowcase = await http.GetFromJsonAsync<IEnumerable<ShowCaseDTO>>($"https://localhost:7052/api/Showcase/all?key={_config.GetValue<string>("ApiKey")}");
        if (allShowcase != null && allShowcase.Any())
        {
            var randomIndex = random.Next(0, allShowcase.Count());

            showCase = allShowcase.ElementAt(randomIndex);
        }
        return showCase;
    }
    public async Task<IEnumerable<ProductDTO>> GetFeaturedProducts()
    {
        var allFeaturedProducts = await _productService.GetByTagAsync("featured");
        var sortedList = allFeaturedProducts.OrderBy(x => x.Price);
        return sortedList;
    }
    public async Task<IEnumerable<ProductDTO>> GetNewProducts()
    {
        var allFeaturedProducts = await _productService.GetByTagAsync("new");
        var sortedList = allFeaturedProducts.OrderByDescending(x => x.Created);
        return sortedList;
    }
    public async Task<IEnumerable<ProductDTO>> GetPopularProducts()
    {
        var allFeaturedProducts = await _productService.GetByTagAsync("Popular");
        var sortedList = allFeaturedProducts.OrderByDescending(x => x.StarRating);
        return sortedList;
    }
}
