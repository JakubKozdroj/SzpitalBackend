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

        [HttpGet("{id}")]
        public ActionResult<ZawodySpecjalnosci> GetById(int id)
        {
            var zawod = _context.ZawodySpecjalnosci.Find(id);
            if (zawod == null)
                return NotFound();
            
            return Ok(zawod);
        }

        [HttpPost]
        public ActionResult<ZawodySpecjalnosci> Create(ZawodySpecjalnosci zawod)
        {
            if (zawod.DataOtwarciaSpecjalizacji.HasValue)
            {
                zawod.DataOtwarciaSpecjalizacji = DateTime.SpecifyKind(zawod.DataOtwarciaSpecjalizacji.Value, DateTimeKind.Utc);
            }
            
            _context.ZawodySpecjalnosci.Add(zawod);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = zawod.Id }, zawod);
        }

        [HttpPut("{id}")]
        public ActionResult<ZawodySpecjalnosci> Update(int id, ZawodySpecjalnosci zawod)
        {
            var existing = _context.ZawodySpecjalnosci.Find(id);
            if (existing == null)
                return NotFound();

            existing.Kod = zawod.Kod;
            existing.Nazwa = zawod.Nazwa;
            existing.StopienSpecjalizacji = zawod.StopienSpecjalizacji;
            
            if (zawod.DataOtwarciaSpecjalizacji.HasValue)
            {
                existing.DataOtwarciaSpecjalizacji = DateTime.SpecifyKind(zawod.DataOtwarciaSpecjalizacji.Value, DateTimeKind.Utc);
            }
            else
            {
                existing.DataOtwarciaSpecjalizacji = null;
            }
            
            existing.Dyplom = zawod.Dyplom;

            _context.SaveChanges();
            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var zawod = _context.ZawodySpecjalnosci.Find(id);
            if (zawod == null)
                return NotFound();

            _context.ZawodySpecjalnosci.Remove(zawod);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("options/nazwa")]
        public ActionResult<IEnumerable<string>> GetNazwyOptions()
        {
            var nazwy = _context.ZawodySpecjalnosci
                .Where(z => !string.IsNullOrEmpty(z.Nazwa))
                .Select(z => z.Nazwa)
                .Distinct()
                .OrderBy(n => n)
                .ToList();
            return Ok(nazwy);
        }

        [HttpGet("options/stopien")]
        public ActionResult<IEnumerable<string>> GetStopnieOptions()
        {
            var stopnie = _context.ZawodySpecjalnosci
                .Where(z => !string.IsNullOrEmpty(z.StopienSpecjalizacji))
                .Select(z => z.StopienSpecjalizacji)
                .Distinct()
                .OrderBy(s => s)
                .ToList();
            return Ok(stopnie);
        }

        [HttpGet("options/dyplom")]
        public ActionResult<IEnumerable<string>> GetDyplomyOptions()
        {
            var dyplomy = _context.ZawodySpecjalnosci
                .Where(z => !string.IsNullOrEmpty(z.Dyplom))
                .Select(z => z.Dyplom)
                .Distinct()
                .OrderBy(d => d)
                .ToList();
            return Ok(dyplomy);
        }
    }
}
