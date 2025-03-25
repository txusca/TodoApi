using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Domain.Entities;
using TodoApi.Dtos;
using TodoApi.Repository;
using TodoApi.Services;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserRepository _repository;
    private readonly IAuthService _authService;

    public AuthController(UserRepository repository, IAuthService authService)
    {
        _repository = repository;
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
    {
        var user = new User { UserName = request.UserName, Name = request.Name, Email = request.Email };
        var result = await _repository.CreateUser(user, request.Password);

        if (result.Succeeded) return Ok();

        return BadRequest(result.Errors);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
    {
        var user = await _repository.FindByEmail(request.Email);
        if (user == null) return Unauthorized("Email não encontrado");

        var isValidPassword = await _repository.CheckPassword(user, request.Password);
        if (!isValidPassword) return Unauthorized("Senha incorreta");

        var token = _authService.GenerateJwtToken(user);
        return Ok(new { Token = token });
    }
}
