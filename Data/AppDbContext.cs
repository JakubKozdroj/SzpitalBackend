using Microsoft.EntityFrameworkCore;
using SzpitalnaKadra.Models;

namespace SzpitalnaKadra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Osoba> Osoby { get; set; }
        public DbSet<DbUser> DbUsers { get; set; }
    }
}
