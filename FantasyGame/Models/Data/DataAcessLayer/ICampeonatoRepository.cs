using FantasyGame.Models.Data.Entities;

namespace FantasyGame.Models.Data.DataAcessLayer
{
    public interface ICampeonatoRepository : IGenericRepository<Campeonato>
    {
        Task<Campeonato?> GetMostRecent();
        Task<Campeonato?> GetByIdAsyncInclude(int id);
    }
}
