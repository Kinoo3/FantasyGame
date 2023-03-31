using FantasyGame.Database;
using FantasyGame.Models.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FantasyGame.Models.Data.DataAcessLayer
{
    public class PartidaRepository : GenericRepository<Partida>, IPartidaRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PartidaRepository(ApplicationDbContext context) : base(context)
        {
            this._dbContext = context;
        }

        public async Task<bool> TimeHavePlayed(int id)
        {
            return await _dbContext.Set<Partida>().AnyAsync(x => x.Time1.Id == id ||  x.Time2.Id == id);
        }
    }
}
