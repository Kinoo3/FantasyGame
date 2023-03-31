using FantasyGame.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace FantasyGame.Models.Data.DataAcessLayer
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _dbContext;
        public GenericRepository(ApplicationDbContext context)
        {
            this._dbContext = context;
        }

        public virtual async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<IList<TEntity>> GetPaginated(int skip, int take)
        {
             return await _dbContext.Set<TEntity>().Skip(skip).Take(take).ToListAsync();
        }

        public async Task<IList<TEntity>> GetAll()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<int> CountTotalRecords()
        {
            return await _dbContext.Set<TEntity>().CountAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }
    }
}
