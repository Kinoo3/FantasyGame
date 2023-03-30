using FantasyGame.Database;

namespace FantasyGame.Models.Data.DataAcessLayer.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private readonly ApplicationDbContext _context;
        public readonly ITimeRepository _timeRepository;
        public UnitOfWork(ApplicationDbContext context) {
        _context = context;
        _timeRepository = new TimeRepository(context);

        }


        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing) 
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
