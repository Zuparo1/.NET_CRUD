using Microsoft.EntityFrameworkCore;

namespace API_Bibliotek.Models
{
    public class BibliotekContextContext : DbContext
    {
        public BibliotekContextContext(DbContextOptions<BibliotekContextContext> options) : base(options) { }
        public DbSet<Bok> Bøker { get; set; }
    }
}
