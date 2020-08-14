using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BugTrackerDBContext _context;
        public IUserRepository Users { get; private set; }
        
        public UnitOfWork(BugTrackerDBContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        int Complete();
    }
}
