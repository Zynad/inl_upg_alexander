using InlamningsUppgiftFixxo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginUserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                using var http = new HttpClient();

                var result = await http.PostAsJsonAsync("https://localhost:7052/api/authentication/login", viewModel);
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
}
