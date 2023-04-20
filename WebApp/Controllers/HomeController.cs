using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ViewService _viewService;

    public HomeController(ViewService viewService)
    {
        _viewService = viewService;
    }

    public async Task<IActionResult> Index()
    {
        HomeViewModel model = await _viewService.CreateHomeViewModelAsync();
        return View(model);
    }


    public IActionResult UnauthorizedUser()
    {
        return View();
    }
}
