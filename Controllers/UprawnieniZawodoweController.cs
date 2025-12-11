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
            if (uprawnienie.DataUzyciaUprawnienia.HasValue)
            {
                uprawnienie.DataUzyciaUprawnienia = DateTime.SpecifyKind(uprawnienie.DataUzyciaUprawnienia.Value, DateTimeKind.Utc);
            }
            
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
            
            if (uprawnienie.DataUzyciaUprawnienia.HasValue)
            {
                existing.DataUzyciaUprawnienia = DateTime.SpecifyKind(uprawnienie.DataUzyciaUprawnienia.Value, DateTimeKind.Utc);
            }
            else
            {
                existing.DataUzyciaUprawnienia = null;
            }

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

        [HttpGet("options/rodzaj")]
        public ActionResult<IEnumerable<string>> GetRodzajeOptions()
        {
            var rodzaje = _context.UprawnieniZawodowe
                .Where(u => !string.IsNullOrEmpty(u.Rodzaj))
                .Select(u => u.Rodzaj)
                .Distinct()
                .OrderBy(r => r)
                .ToList();
            return Ok(rodzaje);
        }

        [HttpGet("options/organ")]
        public ActionResult<IEnumerable<string>> GetOrganyOptions()
        {
            var organy = _context.UprawnieniZawodowe
                .Where(u => !string.IsNullOrEmpty(u.OrganRejestrujacy))
                .Select(u => u.OrganRejestrujacy)
                .Distinct()
                .OrderBy(o => o)
                .ToList();
            return Ok(organy);
        }
    }
}
