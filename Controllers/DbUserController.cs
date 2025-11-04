using Microsoft.AspNetCore.Mvc;
using SzpitalnaKadra.Data;
using SzpitalnaKadra.Models;

namespace SzpitalnaKadra.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DbUserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DbUserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.DbUsers.ToList());

        [HttpPost]
        public IActionResult Add(DbUser user)
        {
            // Wymuszenie UTC na DateTime – wymagane przez PostgreSQL
            user.LastPassChange = DateTime.SpecifyKind(user.LastPassChange, DateTimeKind.Utc);
            user.LastActivity = DateTime.SpecifyKind(user.LastActivity, DateTimeKind.Utc);

            _context.DbUsers.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }
    }
}
