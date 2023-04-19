using Mvc.Models.DTO;
using System.Net.Http.Headers;
using WebApp.Models.DTO;

namespace WebApp.Services;

public class AdminService
{
    private readonly IConfiguration _config;

    public AdminService(IConfiguration config)
    {
        _config = config;
    }

    public async Task<HttpResponseMessage> AddProductAsync(CreateProductDTO dto, string token)
    {
        using var http = new HttpClient();
        http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        return await http.PostAsJsonAsync($"https://localhost:7052/api/Products/Add?key={_config.GetValue<string>("ApiKey")}", dto);
    }
	public async Task<HttpResponseMessage> AddShowcaseAsync(CreateShowCaseDTO dto, string token)
	{
		using var http = new HttpClient();
		http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
		return await http.PostAsJsonAsync($"https://localhost:7052/api/ShowCase/Add?key={_config.GetValue<string>("ApiKey")}", dto);
	}
}
