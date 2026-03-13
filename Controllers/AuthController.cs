using BlogMonolito.Models.DTOs;
using BlogMonolito.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogMonolito.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] AuthDto request)
    {
        var user = await _authService.RegisterAsync(request.Username, request.Password);
        
        if (user == null) 
            return BadRequest("Usuário já existe.");
            
        return Ok("Usuário registrado com sucesso.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AuthDto request)
    {
        var token = await _authService.LoginAsync(request.Username, request.Password);
        
        if (token == null) 
            return Unauthorized("Credenciais inválidas.");
            
        return Ok(new { Token = token });
    }
}