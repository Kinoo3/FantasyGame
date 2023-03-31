namespace FantasyGame.Models.Data.DataAcessLayer
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(int id);
        Task<IList<TEntity>> GetPaginated(int skip, int take);
        Task<IList<TEntity>> GetAll();
        Task<int> CountTotalRecords();
        Task AddAsync(TEntity entity);
        void Delete(TEntity entity);
    }
}
