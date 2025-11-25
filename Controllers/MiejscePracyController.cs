using Microsoft.AspNetCore.Mvc;
using SzpitalnaKadra.Data;
using SzpitalnaKadra.Models;

namespace SzpitalnaKadra.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MiejscePracyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MiejscePracyController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("osoba/{osobaId}")]
        public IActionResult GetByOsobaId(int osobaId)
        {
            var miejscaPracy = _context.MiejscaPracy.Where(m => m.OsobaId == osobaId).ToList();
            return Ok(miejscaPracy);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var miejscePracy = _context.MiejscaPracy.FirstOrDefault(m => m.Id == id);
            if (miejscePracy == null)
                return NotFound();
            return Ok(miejscePracy);
        }

        [HttpPost]
        public IActionResult Add(MiejscePracy miejscePracy)
        {
            miejscePracy.CreatedAt = DateTime.Now;
            miejscePracy.UpdatedAt = DateTime.Now;
            _context.MiejscaPracy.Add(miejscePracy);
            _context.SaveChanges();
            return Ok(miejscePracy);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, MiejscePracy miejscePracy)
        {
            var existing = _context.MiejscaPracy.FirstOrDefault(m => m.Id == id);
            if (existing == null)
                return NotFound();

            existing.KodMiejscaUdzielaniaSwiadczen = miejscePracy.KodMiejscaUdzielaniaSwiadczen;
            existing.NazwaMiejscaUdzielaniaSwiadczen = miejscePracy.NazwaMiejscaUdzielaniaSwiadczen;
            existing.KodSpecjalnosci = miejscePracy.KodSpecjalnosci;
            existing.NazwaSpecjalnosci = miejscePracy.NazwaSpecjalnosci;
            existing.ZawodSpecjalnosc = miejscePracy.ZawodSpecjalnosc;
            existing.NazwaFunkcji = miejscePracy.NazwaFunkcji;
            existing.PracaOd = miejscePracy.PracaOd;
            existing.PracaDo = miejscePracy.PracaDo;
            existing.TypHarmonogramu = miejscePracy.TypHarmonogramu;
            existing.UpdatedAt = DateTime.Now;

            _context.SaveChanges();
            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var miejscePracy = _context.MiejscaPracy.FirstOrDefault(m => m.Id == id);
            if (miejscePracy == null)
                return NotFound();

            _context.MiejscaPracy.Remove(miejscePracy);
            _context.SaveChanges();
            return Ok(new { message = "Miejsce pracy zostało usunięte" });
        }
    }
}
