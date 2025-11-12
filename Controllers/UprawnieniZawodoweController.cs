using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SzpitalnaKadra.Data;
using SzpitalnaKadra.Models;

namespace SzpitalnaKadra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UprawnieniZawodoweController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UprawnieniZawodoweController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("osoba/{osobaId}")]
        public ActionResult<IEnumerable<UprawnieniZawodowe>> GetByOsobaId(int osobaId)
        {
            var uprawnienia = _context.UprawnieniZawodowe
                .Where(u => u.OsobaId == osobaId)
                .ToList();

            return Ok(uprawnienia);
        }
    }
}
