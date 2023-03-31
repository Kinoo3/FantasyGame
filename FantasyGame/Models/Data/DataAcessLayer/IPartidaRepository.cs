using FantasyGame.Models.Data.Entities;

namespace FantasyGame.Models.Data.DataAcessLayer
{
    public interface IPartidaRepository : IGenericRepository<Partida>
    {
        Task<bool> TimeHavePlayed(int id);
    }
}
