using FantasyGame.Models.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FantasyGame.Database.Seed
{
    public class TimeSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Time>().HasData(
                new { Id = 500, Nome = "Internacional" },
                new { Id = 501, Nome = "São paulo" },
                new { Id = 502, Nome = "Flamengo" },
                new { Id = 503, Nome = "Santos" }
                );
        }
    }
}
