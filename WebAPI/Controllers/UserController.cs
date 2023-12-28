using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Controllers;

[ApiController]
[Route("auth")]
public class UserController : Controller
{
    private UserRepository UserRepository { get; }
    
    public UserController(UserRepository userRepository)
    {
        UserRepository = userRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Auth([FromBody] User loginUser)
    {
        var user = await UserRepository.GetByLogin(loginUser.Login);
        if (user == null)
        {
            return Unauthorized(new { reason = "User not found" });
        }

        var validatePassword = BCrypt.Net.BCrypt.Verify(loginUser.Password, user.Password);

        if (!validatePassword)
        {
            return Unauthorized(new { reason = "Incorrect password" });
        }

        var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Login) };
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

        return Ok(new { access_token = new JwtSecurityTokenHandler().WriteToken(jwt) });
    }
}