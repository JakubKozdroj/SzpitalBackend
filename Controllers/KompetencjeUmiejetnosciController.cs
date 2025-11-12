using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SzpitalnaKadra.Data;
using SzpitalnaKadra.Models;

namespace SzpitalnaKadra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KompetencjeUmiejetnosciController : ControllerBase
    {
        private readonly AppDbContext _context;

        public KompetencjeUmiejetnosciController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("osoba/{osobaId}")]
        public ActionResult<IEnumerable<KompetencjeUmiejetnosci>> GetByOsobaId(int osobaId)
        {
            var kompetencje = _context.KompetencjeUmiejetnosci
                .Where(k => k.OsobaId == osobaId)
                .ToList();

            return Ok(kompetencje);
        }
    }
}
