using WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterUserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                using var http = new HttpClient();

                var result = await http.PostAsJsonAsync("https://localhost:7052/api/authentication/signup", viewModel);
                var token = await result.Content.ReadAsStringAsync();

                if(token != null) 
                {
                    return RedirectToAction("Index", "login");
                }

                
            }

            ModelState.AddModelError("", "Incorrect email or password");

            return View(viewModel);
        }
    }
}
