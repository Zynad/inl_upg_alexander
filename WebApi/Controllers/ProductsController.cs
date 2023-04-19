using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;
using WebApi.Models.DTO;
using WebApi.Services;

namespace WebApi.Controllers
{
    [UseApiKey]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [Route("All")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.GetAllAsync());
        }

        [Route("Tag")]
        [HttpGet]
        public async Task<IActionResult> GetByTag(string tag)
        {
            return Ok(await _productService.GetByTagAsync(tag));
        }

        [Route("Get")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _productService.GetByIdAsync(id));
        }

        [Authorize(Roles = "admin, productChief")]
        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductDTO dto)
        {
            if (await _productService.CreateAsync(dto))
                return Created("", null);

            return BadRequest();
        }

        [Authorize(Roles = "admin, productChief")]
        [Route("Delete")]
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (await _productService.DeleteAsync(id))
                return Ok();

            return BadRequest();
        }
    }
}
