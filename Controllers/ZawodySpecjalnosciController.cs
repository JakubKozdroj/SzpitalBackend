using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SzpitalnaKadra.Data;
using SzpitalnaKadra.Models;

namespace SzpitalnaKadra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZawodySpecjalnosciController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ZawodySpecjalnosciController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("osoba/{osobaId}")]
        public ActionResult<IEnumerable<ZawodySpecjalnosci>> GetByOsobaId(int osobaId)
        {
            var zawody = _context.ZawodySpecjalnosci
                .Where(z => z.OsobaId == osobaId)
                .ToList();

            return Ok(zawody);
        }
    }
}
