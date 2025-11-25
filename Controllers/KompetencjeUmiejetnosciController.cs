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

        [HttpGet("{id}")]
        public ActionResult<KompetencjeUmiejetnosci> GetById(int id)
        {
            var kompetencja = _context.KompetencjeUmiejetnosci.Find(id);
            if (kompetencja == null)
                return NotFound();
            
            return Ok(kompetencja);
        }

        [HttpPost]
        public ActionResult<KompetencjeUmiejetnosci> Create(KompetencjeUmiejetnosci kompetencja)
        {
            _context.KompetencjeUmiejetnosci.Add(kompetencja);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = kompetencja.Id }, kompetencja);
        }

        [HttpPut("{id}")]
        public ActionResult<KompetencjeUmiejetnosci> Update(int id, KompetencjeUmiejetnosci kompetencja)
        {
            var existing = _context.KompetencjeUmiejetnosci.Find(id);
            if (existing == null)
                return NotFound();

            existing.Kod = kompetencja.Kod;
            existing.Nazwa = kompetencja.Nazwa;
            existing.Poziom = kompetencja.Poziom;
            existing.Zaswiadczenie = kompetencja.Zaswiadczenie;

            _context.SaveChanges();
            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var kompetencja = _context.KompetencjeUmiejetnosci.Find(id);
            if (kompetencja == null)
                return NotFound();

            _context.KompetencjeUmiejetnosci.Remove(kompetencja);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
