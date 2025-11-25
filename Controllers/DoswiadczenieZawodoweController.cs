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

        [HttpGet("{id}")]
        public ActionResult<DoswiadczenieZawodowe> GetById(int id)
        {
            var doswiadczenie = _context.DoswiadczenieZawodowe.Find(id);
            if (doswiadczenie == null)
                return NotFound();
            
            return Ok(doswiadczenie);
        }

        [HttpPost]
        public ActionResult<DoswiadczenieZawodowe> Create(DoswiadczenieZawodowe doswiadczenie)
        {
            _context.DoswiadczenieZawodowe.Add(doswiadczenie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = doswiadczenie.Id }, doswiadczenie);
        }

        [HttpPut("{id}")]
        public ActionResult<DoswiadczenieZawodowe> Update(int id, DoswiadczenieZawodowe doswiadczenie)
        {
            var existing = _context.DoswiadczenieZawodowe.Find(id);
            if (existing == null)
                return NotFound();

            existing.Kod = doswiadczenie.Kod;
            existing.Nazwa = doswiadczenie.Nazwa;
            existing.Zaswiadczenie = doswiadczenie.Zaswiadczenie;

            _context.SaveChanges();
            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var doswiadczenie = _context.DoswiadczenieZawodowe.Find(id);
            if (doswiadczenie == null)
                return NotFound();

            _context.DoswiadczenieZawodowe.Remove(doswiadczenie);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
