using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SzpitalnaKadra.Data;
using SzpitalnaKadra.Models;

namespace SzpitalnaKadra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoswiadczenieZawodoweController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DoswiadczenieZawodoweController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("osoba/{osobaId}")]
        public ActionResult<IEnumerable<DoswiadczenieZawodowe>> GetByOsobaId(int osobaId)
        {
            var doswiadczenie = _context.DoswiadczenieZawodowe
                .Where(d => d.OsobaId == osobaId)
                .ToList();

            return Ok(doswiadczenie);
        }
    }
}
