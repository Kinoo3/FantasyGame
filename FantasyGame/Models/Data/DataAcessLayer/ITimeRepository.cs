using FantasyGame.Models.Data.Entities;

namespace FantasyGame.Models.Data.DataAcessLayer
{
    public interface ITimeRepository : IGenericRepository<Time>
    {
        bool NameAlreadyExists(string name);
    }
}
