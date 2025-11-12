using Microsoft.AspNetCore.Mvc;
using SzpitalnaKadra.Data;
using SzpitalnaKadra.Models;

namespace SzpitalnaKadra.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZatrudnienieController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ZatrudnienieController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("osoba/{osobaId}")]
        public IActionResult GetByOsobaId(int osobaId)
        {
            var zatrudnienie = _context.Zatrudnienia.FirstOrDefault(z => z.OsobaId == osobaId);
            if (zatrudnienie == null)
                return NotFound();
            return Ok(zatrudnienie);
        }
    }
}
