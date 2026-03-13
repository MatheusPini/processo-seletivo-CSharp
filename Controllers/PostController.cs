using System.Security.Claims;
using BlogMonolito.Models.DTOs;
using BlogMonolito.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogMonolito.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet] 
    public async Task<IActionResult> GetAll()
    {
        var posts = await _postService.GetAllAsync();
        
        var response = posts.Select(p => new { p.Id, p.Title, p.Content, p.CreatedAt, Author = p.User?.Username });
        return Ok(response);
    }

    [HttpPost]
    [Authorize] 
    public async Task<IActionResult> Create([FromBody] PostDto request)
    {
        
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        var post = await _postService.CreateAsync(request.Title, request.Content, userId);
        return Ok(post);
    }

    [HttpPut("{id}")]
    [Authorize] 
    public async Task<IActionResult> Update(int id, [FromBody] PostDto request)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var post = await _postService.UpdateAsync(id, request.Title, request.Content, userId);
        
        if (post == null) return StatusCode(StatusCodes.Status403Forbidden, new { message = "Você não tem permissão para editar esta postagem ou ela não existe." });
        return Ok(post);
    }

    [HttpDelete("{id}")]
    [Authorize] 
    public async Task<IActionResult> Delete(int id)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var success = await _postService.DeleteAsync(id, userId);
        
        if (!success) return StatusCode(StatusCodes.Status403Forbidden, new { message = "Você não tem permissão para excluir esta postagem ou ela não existe." });
        return NoContent(); 
    }
}