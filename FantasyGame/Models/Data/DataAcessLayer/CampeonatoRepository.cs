using FantasyGame.Database;
using FantasyGame.Models.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FantasyGame.Models.Data.DataAcessLayer
{
    public class CampeonatoRepository : GenericRepository<Campeonato>, ICampeonatoRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CampeonatoRepository(ApplicationDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<Campeonato?> GetMostRecent()
        {
            return await _dbContext.Set<Campeonato>().OrderByDescending(x => x.DataRealizacao)
                .Include(x => x.Partidas)
                .ThenInclude(p => p.Time1)
                .Include(x => x.Partidas)
                .ThenInclude(p => p.Time2)
                .FirstOrDefaultAsync();
        }

        public async Task<Campeonato?> GetByIdAsyncInclude(int id)
        {
            return await _dbContext.Set<Campeonato>().Where(c => c.Id == id)
                .Include(x => x.Partidas)
                .ThenInclude(p => p.Time1)
                .Include(x => x.Partidas)
                .ThenInclude(p => p.Time2)
                .FirstOrDefaultAsync();
        }
    }
}