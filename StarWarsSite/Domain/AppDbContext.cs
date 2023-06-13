using Microsoft.EntityFrameworkCore;
using StarWarsSite.Models;

namespace StarWarsSite.Domain
{
    public class AppDbContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
