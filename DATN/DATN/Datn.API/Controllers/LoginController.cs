using Datn.Application.DataTransferObj;
using Datn.Domain.Database.Entities;
using Datn.Infrastructure.Database.AppDbContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Datn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly AppDbContexts contexts;
        public LoginController(IConfiguration configuration, AppDbContexts contexts)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.contexts = contexts ?? throw new ArgumentNullException(nameof(contexts));
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserDto model)
        {
            var user = await contexts.Users.FirstOrDefaultAsync(x => x.UserName == model.UserName && x.PassWord == model.PassWord);
            if (user == null)
            {
                return Unauthorized(new LoginResponse { Successful = false, Error = "Invalid username or password." });
            }

            var jwtKey = configuration["Jwt:Key"];
            if (string.IsNullOrEmpty(jwtKey))
            {
                throw new ApplicationException("JWT Key is missing or empty in appsettings.json");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(Convert.ToInt32(configuration["Jwt:ExpiryInDays"]));

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, model.UserName),
                new Claim("UserId", user.Id.ToString())
            };

            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: expiry,
                signingCredentials: creds
            );

            return Ok(new LoginResponse { Successful = true, Token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
}
