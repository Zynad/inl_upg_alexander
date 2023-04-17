using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net.Http.Headers;

namespace WebApp.Controllers;
//[Authorize]
public class AdminController : Controller
{
    
    public  IActionResult Index()
    {        

        return View();
    }
}
