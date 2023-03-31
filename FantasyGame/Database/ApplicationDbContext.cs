using FantasyGame.Models.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FantasyGame.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Time> Times { get; set; }
        public DbSet<Partida> Partidas { get; set; }
        public DbSet<Campeonato> campeonatos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Partida>()
                .HasOne(t => t.Time1)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Partida>()
                .HasOne(t => t.Time2)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
