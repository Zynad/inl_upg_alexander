using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.DTO;
using WebApi.Services;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthenticationController(AuthService authService)
    {
        _authService = authService;
    }

    [Route("Signup")]
    [HttpPost]
    public async Task<IActionResult> Signup(AuthenticationSignupModel model)
    {
        if (ModelState.IsValid)
        {
            if (await _authService.RegisterAsync(model))
            {
                return Created("", null);
            }
        }
        return BadRequest();
    }

    [Route("Login")]
    [HttpPost]
    public async Task<IActionResult> Login(AuthenticationLoginModel model)
    {
        if (ModelState.IsValid)
        {
            var token = await _authService.LoginAsync(model);
            if (!string.IsNullOrEmpty(token))
                return Ok(token);
        }

        return BadRequest("Incorrect email or password");
    }
}
