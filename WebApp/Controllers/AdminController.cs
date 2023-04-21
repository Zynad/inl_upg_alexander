using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net.Http.Headers;
using WebApp.Helpers;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class AdminController : Controller
{
    private readonly TokenValidation _tokenValidation;
    private readonly AdminService _adminService;
    private readonly ViewService _viewService;

    public AdminController(TokenValidation tokenValidation, AdminService adminService, ViewService viewService)
    {
        _tokenValidation = tokenValidation;
        _adminService = adminService;
        _viewService = viewService;
    }

    public  IActionResult Index()
    {
        string token = HttpContext.Request.Cookies["accessToken"]!;

        if(_tokenValidation.ValidateToken(token))
        {
            return View();
        }
        return RedirectToAction("UnauthorizedUser", "Home");
    }
    public IActionResult AddProduct()
    {
        string token = HttpContext.Request.Cookies["accessToken"]!;

        if (_tokenValidation.ValidateToken(token))
        {
            return View();
        }
        return RedirectToAction("UnauthorizedUser", "Home");
    }
	public IActionResult AddShowcase()
	{
		string token = HttpContext.Request.Cookies["accessToken"]!;

		if (_tokenValidation.ValidateToken(token))
		{
			return View();
		}
		return RedirectToAction("UnauthorizedUser", "Home");
	}
	[HttpPost]
    public async Task<IActionResult> AddProduct(RegisterProductViewModel model)
    {
        string token = HttpContext.Request.Cookies["accessToken"]!;

        if (_tokenValidation.ValidateToken(token))
        {
            if (ModelState.IsValid)
            {
                var result = await _adminService.AddProductAsync(model, token);
                if (result.IsSuccessStatusCode)
                {
                    ModelState.Clear();
                    model = new RegisterProductViewModel()
                    {
                        ConfirmationMessage = "The product has been added."
                    };

                    return View(model);
                }

                if (result.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    model.ConfirmationMessage = "You are not authorized for this action.";
                else
                    model.ConfirmationMessage = "Something went wrong, try again.";
            }

            return View(model);
        }

		return RedirectToAction("UnauthorizedUser", "Home");
	}
	[HttpPost]
	public async Task<IActionResult> AddShowcase(RegisterShowcaseViewModel model)
	{
		string token = HttpContext.Request.Cookies["accessToken"]!;

		if (_tokenValidation.ValidateToken(token))
		{
			if (ModelState.IsValid)
			{
				var result = await _adminService.AddShowcaseAsync(model, token);
				if (result.IsSuccessStatusCode)
				{
					ModelState.Clear();
					model = new RegisterShowcaseViewModel()
					{
						ConfirmationMessage = "The Showcase has been added."
					};

					return View(model);
				}

				if (result.StatusCode == System.Net.HttpStatusCode.Forbidden)
					model.ConfirmationMessage = "You are not authorized for this action.";
				else
					model.ConfirmationMessage = "Something went wrong, try again.";
			}

			return View(model);
		}

		return RedirectToAction("UnauthorizedUser", "Home");
	}
    public async Task<IActionResult> DeleteProduct()
    {
        string token = HttpContext.Request.Cookies["accessToken"]!;

        if (_tokenValidation.ValidateToken(token))
        {
            return View();
        }

        return RedirectToAction("UnauthorizedUser", "Home");
    }
    [HttpPost]
    public async Task<IActionResult> DeleteProduct(DeleteProductViewModel model)
    {
        string token = HttpContext.Request.Cookies["accessToken"]!;

        if (_tokenValidation.ValidateToken(token))
        {
            if (ModelState.IsValid)
            {
                var result = await _adminService.DeleteProductAsync(model.Id, token);
                if (result.IsSuccessStatusCode)
                {
                    ModelState.Clear();
                    model = new DeleteProductViewModel()
                    {
                        ConfirmationMessage = "The choosen product has been deleted"
                    };

                    return View(model);
                }

                if (result.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    model.ConfirmationMessage = "You are not authorized for this action.";
                else
                    model.ConfirmationMessage = "Something went wrong, try again.";
            }

            return View(model);
        }

        return RedirectToAction("UnauthorizedUser", "Home");
    }


}
