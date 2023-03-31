using FantasyGame.Models.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FantasyGame.Database.Seed
{
    public class PartidaSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            DateTime data = DateTime.Parse("2023-01-01 19:34:13.856069");

            modelBuilder.Entity<Partida>().HasData(
                new { Id = 500, Time1Id = 500, Time1Gols = 3, Time2Id = 501, Time2Gols = 2, CampeonatoId = 1000, Data = data },
                new { Id = 501, Time1Id = 500, Time1Gols = 2, Time2Id = 502, Time2Gols = 3, CampeonatoId = 1000, Data = data },
                new { Id = 502, Time1Id = 500, Time1Gols = 1, Time2Id = 503, Time2Gols = 1, CampeonatoId = 1000, Data = data },
                new { Id = 503, Time1Id = 501, Time1Gols = 5, Time2Id = 502, Time2Gols = 4, CampeonatoId = 1000, Data = data },
                new { Id = 504, Time1Id = 501, Time1Gols = 4, Time2Id = 503, Time2Gols = 2, CampeonatoId = 1000, Data = data },
                new { Id = 505, Time1Id = 502, Time1Gols = 3, Time2Id = 503, Time2Gols = 1, CampeonatoId = 1000, Data = data }
                );
        }
    }
}
