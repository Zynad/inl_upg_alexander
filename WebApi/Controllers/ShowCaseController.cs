using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;
using WebApi.Models.DTO;
using WebApi.Repositories;
using WebApi.Services;

namespace WebApi.Controllers
{
    [UseApiKey]
    [Route("api/[controller]")]
    [ApiController]
    public class ShowCaseController : ControllerBase
    {
        private readonly ShowCaseService _ShowCaseService;

        public ShowCaseController(ShowCaseService showCaseService)
        {
            _ShowCaseService = showCaseService;
        }

        [Authorize(Roles = "admin, productChief")]
        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> AddShowcase(CreateShowCaseDTO dto)
        {
            if (ModelState.IsValid)
            {
                if(await _ShowCaseService.RegisterAsync(dto))
                {
                    return Created("", null);
                }
                
            }
            return BadRequest();
        }
        [Route("Get")]
        [HttpGet]
        public async Task<IActionResult> GetLatestShowcase()
        {
            return Ok(await _ShowCaseService.GetLatestShowCaseAsync());
        }
        [Route("All")]
        [HttpGet]
        public async Task<IActionResult> GetAllShowcases()
        {
            return Ok(await _ShowCaseService.GetAllShowCasesAsync());
        }
    }
}
