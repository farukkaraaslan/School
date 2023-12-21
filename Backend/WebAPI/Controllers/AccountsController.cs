using Entity.Context;
using Entity.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly MyDbContext _context;

    public AccountsController(MyDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Login(UserLoginModel user)
    {
        var student = _context.Students.FirstOrDefault(s=>s.FirstName==user.UserName && s.Password == user.Password);

       if (student != null)
        {
            Claim[] claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, student.FirstName),
                new Claim(ClaimTypes.Email, student.Email),
                new Claim(ClaimTypes.MobilePhone, student.PhoneNumber),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("nemutlutürkümdiyenenemutlutürkümdiyene"));
            var cryptoCredential = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "jsga.edu.tr",
                audience: "client.jsga.edu.tr",
                claims: claims,
                signingCredentials: cryptoCredential,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(20)
                );

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            return Ok( jwtSecurityTokenHandler.WriteToken(token));
        }

        return BadRequest("User name or password wrong");
    }
}
