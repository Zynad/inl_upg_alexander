using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class LoginController : Controller
{
    private readonly IConfiguration _config;
    private readonly TokenValidation _tokenValidation;

    public LoginController(IConfiguration config, TokenValidation tokenValidation)
    {
        _config = config;
        _tokenValidation = tokenValidation;
    }

    public IActionResult Index()
    {
        string token = HttpContext.Request.Cookies["accessToken"]!;

        if (_tokenValidation.ValidateToken(token))
        {
            return RedirectToAction("Index", "Admin");
        }
        
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(LoginUserViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            using var http = new HttpClient();

            var result = await http.PostAsJsonAsync($"https://localhost:7052/api/authentication/login?key={_config.GetValue<string>("ApiKey")}", viewModel);
            if (result.IsSuccessStatusCode)
            {
                var token = await result.Content.ReadAsStringAsync();

                HttpContext.Response.Cookies.Append("accessToken", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    Expires = DateTime.Now.AddDays(1)
                });

                
                return RedirectToAction("Index", "Admin");
                
                
            }
            
        }

        ModelState.AddModelError("", "Incorrect email or password");

        return View(viewModel);
    }
}
