using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SugdAgro.Data;
using SugdAgro.Services;
using System.Security.Cryptography;
using System.Text;
using SugdAgro.API.Models;

namespace SugdAgro.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtService _jwt;

        public AuthController(ApplicationDbContext context, JwtService jwt)
        {
            _context = context;
            _jwt = jwt;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AuthRequest request)
        {
            if (await _context.Users.AnyAsync(x => x.Email == request.Email))
                return BadRequest("Этот адрес электронной почты уже существует");

            var user = new User
            {
                Email = request.Email,
                PasswordHash = HashPassword(request.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("Registration is successful");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthRequest request)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Email == request.Email);

            if (user == null)
                return Unauthorized("Неверный адрес электронной почты или пароль");

            if (user.PasswordHash != HashPassword(request.Password))
                return Unauthorized("Неверный адрес электронной почты или пароль");

            var token = _jwt.GenerateToken(user.Email);

            return Ok(new { token });
        }

        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
