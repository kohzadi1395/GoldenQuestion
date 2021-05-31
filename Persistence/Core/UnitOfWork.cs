using Application.Interfaces.General;

namespace Persistence.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApiContext _context;

        public UnitOfWork(ApiContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}