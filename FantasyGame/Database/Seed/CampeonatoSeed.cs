using FantasyGame.Models.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FantasyGame.Database.Seed
{
    public class CampeonatoSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            DateTime data = DateTime.Parse("2023-01-01 19:34:13.856069");

            modelBuilder.Entity<Campeonato>().HasData(
                new { Id = 1000, Nome = "Brasileirão", DataRealizacao = data}
                );
        }
    }
}
