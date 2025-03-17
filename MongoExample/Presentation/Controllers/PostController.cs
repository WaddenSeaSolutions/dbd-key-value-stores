using Microsoft.AspNetCore.Mvc;
using MongoExample.Application.Services;
using MongoExample.Core.Models;

namespace MongoExample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private readonly PostService _postService;

    public PostController(PostService postService)
    {
        _postService = postService;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPostByIdAsync(string id)
    {
        Post? post = await _postService.GetPostByIdAsync(id);
        if(post is null)
            return NotFound();
        return Ok(post);
    }
}