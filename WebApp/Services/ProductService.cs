using WebApp.Models.DTO;

namespace WebApp.Services;

public class ProductService
{
    private readonly IConfiguration _config;

    public ProductService(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
    {
        using var http = new HttpClient();
        var result = await http.GetFromJsonAsync<IEnumerable<ProductDTO>>($"https://localhost:7052/api/Products/All?key={_config.GetValue<string>("ApiKey")}");
        return result!;
    }

    public async Task<ProductDTO> GetProductAsync(int id)
    {
        using var http = new HttpClient();
        var result = await http.GetFromJsonAsync<ProductDTO>($"https://localhost:7052/api/Products/Get?id={id}&key={_config.GetValue<string>("ApiKey")}");
        return result!;
    }

    public async Task<IEnumerable<ProductDTO>> GetByTagAsync(string tag)
    {
        using var http = new HttpClient();
        var result = await http.GetFromJsonAsync<IEnumerable<ProductDTO>>($"https://localhost:7052/api/Products/Tag?tag={tag}&key={_config.GetValue<string>("ApiKey")}");
        return result!;
    }

}
