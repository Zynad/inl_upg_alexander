using WebApp.Models.DTO;

namespace WebApp.Services;

public class CommentService
{
    private readonly IConfiguration _config;

    public CommentService(IConfiguration config)
    {
        _config = config;
    }

    public async Task<HttpResponseMessage> PostCommentAsync(CommentDTO dto)
    {
        using var http = new HttpClient();
        var result = await http.PostAsJsonAsync($"https://localhost:7052/api/Comments/Post?key={_config.GetValue<string>("ApiKey")}", dto);
        return result!;
    }
}
