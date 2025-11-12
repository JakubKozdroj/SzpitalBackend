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
    }
}
