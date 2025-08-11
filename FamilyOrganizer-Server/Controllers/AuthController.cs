using Microsoft.AspNetCore.Mvc;
using FamilyOrganizer_Server.Models;
using System.Linq;

namespace FamilyOrganizer_Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpGet("ping")]
    public IActionResult Ping() => Ok(new { ok = true, time = DateTime.UtcNow });

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest req)
    {
        if (string.IsNullOrWhiteSpace(req.Email) || string.IsNullOrWhiteSpace(req.Password))
            return BadRequest(new AuthResponse { Success = false, Message = "Missing email or password." });

        var user = InMemoryDb.Users.FirstOrDefault(u =>
            u.Email.Equals(req.Email.Trim(), StringComparison.OrdinalIgnoreCase) &&
            u.Password == req.Password);

        if (user == null)
            return Unauthorized(new AuthResponse { Success = false, Message = "Incorrect email or password." });

        return Ok(new AuthResponse
        {
            Success = true,
            Message = "Login Successfu",
            Token = "fake-jwt-demo-token",
            Email = user.Email,
            FullName = user.FullName
        });
    }
}
