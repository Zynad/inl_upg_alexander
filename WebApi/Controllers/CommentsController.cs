using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;
using WebApi.Models.DTO;
using WebApi.Repositories;

namespace WebApi.Controllers;

[UseApiKey]
[Route("api/[controller]")]
[ApiController]
public class CommentsController : ControllerBase
{
    private readonly CommentRepo _commentRepo;

    public CommentsController(CommentRepo commentRepo)
    {
        _commentRepo = commentRepo;
    }
    [Route("Post")]
    [HttpPost]
    public async Task <IActionResult> PostCommentAsync(CommentDTO dto)
    {
        if(ModelState.IsValid)
        {
            var result = await _commentRepo.AddAsync(dto);
            if (result != null) 
            {
                return Created("", null);            
            }
        }
        return BadRequest();
    }
}
