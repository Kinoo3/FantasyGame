using FantasyGame.Database;

namespace FantasyGame.Models.Data.DataAcessLayer.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ITimeRepository _timeRepository { get; }
        ICampeonatoRepository _campeonatoRepository { get; }
        IPartidaRepository _partidaRepository { get; }
        void Save();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ITimeRepository _timeRepository { get; }
        public ICampeonatoRepository _campeonatoRepository { get; }
        public IPartidaRepository _partidaRepository { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _timeRepository = new TimeRepository(context);
            _campeonatoRepository = new CampeonatoRepository(context);
            _partidaRepository = new PartidaRepository(context);
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
