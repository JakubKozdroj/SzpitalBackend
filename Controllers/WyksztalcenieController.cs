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

        [HttpGet("{id}")]
        public ActionResult<Wyksztalcenie> GetById(int id)
        {
            var wyksztalcenie = _context.Wyksztalcenia.Find(id);
            if (wyksztalcenie == null)
                return NotFound();
            
            return Ok(wyksztalcenie);
        }

        [HttpPost]
        public ActionResult<Wyksztalcenie> Create(Wyksztalcenie wyksztalcenie)
        {
            _context.Wyksztalcenia.Add(wyksztalcenie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = wyksztalcenie.Id }, wyksztalcenie);
        }

        [HttpPut("{id}")]
        public ActionResult<Wyksztalcenie> Update(int id, Wyksztalcenie wyksztalcenie)
        {
            var existing = _context.Wyksztalcenia.Find(id);
            if (existing == null)
                return NotFound();

            existing.RodzajWyksztalcenia = wyksztalcenie.RodzajWyksztalcenia;
            existing.Kierunek = wyksztalcenie.Kierunek;
            existing.Uczelnia = wyksztalcenie.Uczelnia;
            existing.DataUkonczenia = wyksztalcenie.DataUkonczenia;
            existing.Dyplom = wyksztalcenie.Dyplom;

            _context.SaveChanges();
            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var wyksztalcenie = _context.Wyksztalcenia.Find(id);
            if (wyksztalcenie == null)
                return NotFound();

            _context.Wyksztalcenia.Remove(wyksztalcenie);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
