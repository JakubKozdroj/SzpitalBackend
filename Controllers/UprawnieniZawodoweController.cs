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

        [HttpGet("{id}")]
        public ActionResult<UprawnieniZawodowe> GetById(int id)
        {
            var uprawnienie = _context.UprawnieniZawodowe.Find(id);
            if (uprawnienie == null)
                return NotFound();
            
            return Ok(uprawnienie);
        }

        [HttpPost]
        public ActionResult<UprawnieniZawodowe> Create(UprawnieniZawodowe uprawnienie)
        {
            _context.UprawnieniZawodowe.Add(uprawnienie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = uprawnienie.Id }, uprawnienie);
        }

        [HttpPut("{id}")]
        public ActionResult<UprawnieniZawodowe> Update(int id, UprawnieniZawodowe uprawnienie)
        {
            var existing = _context.UprawnieniZawodowe.Find(id);
            if (existing == null)
                return NotFound();

            existing.Rodzaj = uprawnienie.Rodzaj;
            existing.NpwzIdRizh = uprawnienie.NpwzIdRizh;
            existing.OrganRejestrujacy = uprawnienie.OrganRejestrujacy;
            existing.DataUzyciaUprawnienia = uprawnienie.DataUzyciaUprawnienia;

            _context.SaveChanges();
            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var uprawnienie = _context.UprawnieniZawodowe.Find(id);
            if (uprawnienie == null)
                return NotFound();

            _context.UprawnieniZawodowe.Remove(uprawnienie);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
