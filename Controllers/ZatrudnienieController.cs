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

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var zatrudnienie = _context.Zatrudnienia.FirstOrDefault(z => z.Id == id);
            if (zatrudnienie == null)
                return NotFound();
            return Ok(zatrudnienie);
        }

        [HttpPost]
        public IActionResult Add(Zatrudnienie zatrudnienie)
        {
            zatrudnienie.CreatedAt = DateTime.Now;
            zatrudnienie.UpdatedAt = DateTime.Now;
            _context.Zatrudnienia.Add(zatrudnienie);
            _context.SaveChanges();
            return Ok(zatrudnienie);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Zatrudnienie zatrudnienie)
        {
            var existing = _context.Zatrudnienia.FirstOrDefault(z => z.Id == id);
            if (existing == null)
                return NotFound();

            existing.ZatrudnienieDeklaracja = zatrudnienie.ZatrudnienieDeklaracja;
            existing.ZatrudnionyOd = zatrudnienie.ZatrudnionyOd;
            existing.ZatrudnionyDo = zatrudnienie.ZatrudnionyDo;
            existing.SrednioczasowyCzasPracy = zatrudnienie.SrednioczasowyCzasPracy;
            existing.UpdatedAt = DateTime.Now;

            _context.SaveChanges();
            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var zatrudnienie = _context.Zatrudnienia.FirstOrDefault(z => z.Id == id);
            if (zatrudnienie == null)
                return NotFound();

            _context.Zatrudnienia.Remove(zatrudnienie);
            _context.SaveChanges();
            return Ok(new { message = "Zatrudnienie zostało usunięte" });
        }
    }
}
