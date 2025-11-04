using Microsoft.AspNetCore.Mvc;
using SzpitalnaKadra.Data;
using SzpitalnaKadra.Models;
using SzpitalnaKadra.Helpers;
using System.Security.Cryptography;
using System.Text;

namespace SzpitalnaKadra.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var username = request.Username;
            var password = request.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return BadRequest("Nieprawidłowe dane logowania.");

            string hashed = "md5" + GetMd5Hash(password + username);

            var user = _context.DbUsers
                .FirstOrDefault(u => u.Usename == username && u.Password == hashed);

            if (user == null)
                return Unauthorized("Nieprawidłowy login lub hasło.");

            return Ok(new { user.Id, user.Usename, user.OsobaId });
        }

        private static string GetMd5Hash(string input)
        {
            using var md5 = MD5.Create();
            var inputBytes = Encoding.UTF8.GetBytes(input);
            var hashBytes = md5.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            foreach (var b in hashBytes)
                sb.Append(b.ToString("x2"));

            return sb.ToString();
        }
    }
}
