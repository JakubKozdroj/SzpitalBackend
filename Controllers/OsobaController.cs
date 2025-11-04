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

        [HttpPost]
        public IActionResult Add(Osoba osoba)
        {
            _context.Osoby.Add(osoba);
            _context.SaveChanges();
            return Ok(osoba);
        }
    }
}
