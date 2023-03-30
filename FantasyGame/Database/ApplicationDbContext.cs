using FantasyGame.Models.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FantasyGame.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Time> Times { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    }
}
