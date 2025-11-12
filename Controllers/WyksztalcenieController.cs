using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SzpitalnaKadra.Data;
using SzpitalnaKadra.Models;

namespace SzpitalnaKadra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WyksztalcenieController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WyksztalcenieController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("osoba/{osobaId}")]
        public ActionResult<IEnumerable<Wyksztalcenie>> GetByOsobaId(int osobaId)
        {
            var wyksztalcenia = _context.Wyksztalcenia
                .Where(w => w.OsobaId == osobaId)
                .ToList();

            return Ok(wyksztalcenia);
        }
    }
}
