using FantasyGame.Database;
using FantasyGame.Models.Data.Entities;

namespace FantasyGame.Models.Data.DataAcessLayer
{
    public class TimeRepository : GenericRepository<Time>, ITimeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TimeRepository (ApplicationDbContext context) : base (context) 
        {
            this._dbContext = context;
        }

        public bool NameAlreadyExists(string name)
        {
            return _dbContext.Times.Any(time => time.Nome.Equals(name));
        }
    }
}
