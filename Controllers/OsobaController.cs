using Microsoft.AspNetCore.Mvc;
using SzpitalnaKadra.Data;
using SzpitalnaKadra.Models;

namespace SzpitalnaKadra.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OsobaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OsobaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Osoby.ToList());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var osoba = _context.Osoby.FirstOrDefault(o => o.Id == id);
            if (osoba == null)
                return NotFound();
            return Ok(osoba);
        }

        [HttpPost]
        public IActionResult Add(Osoba osoba)
        {
            _context.Osoby.Add(osoba);
            _context.SaveChanges();
            return Ok(osoba);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Osoba osoba)
        {
            var existing = _context.Osoby.FirstOrDefault(o => o.Id == id);
            if (existing == null)
                return NotFound();

            existing.Imie = osoba.Imie;
            existing.Imie2 = osoba.Imie2;
            existing.Nazwisko = osoba.Nazwisko;
            existing.Pesel = osoba.Pesel;
            existing.DataUrodzenia = osoba.DataUrodzenia;
            existing.NrPwz = osoba.NrPwz;
            existing.NumerTelefonu = osoba.NumerTelefonu;
            existing.PlecId = osoba.PlecId;
            existing.TypPersoneluId = osoba.TypPersoneluId;

            _context.SaveChanges();
            return Ok(existing);
        }
    }
}
