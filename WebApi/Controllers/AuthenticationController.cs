using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.DTO;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    [Route("Signup")]
    [HttpPost]
    public async Task<IActionResult> Signup(AuthenticationSignupModel model)
    {
        if (ModelState.IsValid)
        {
            return Created("", null);
        }
        return BadRequest();
    }
}
