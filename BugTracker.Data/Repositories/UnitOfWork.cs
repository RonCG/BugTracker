using BugTracker.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.Data.Repositories
{
    /// <summary>
    /// Unit of work design pattern. Used as an additional layer between the db and the logic.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BugTrackerDBContext _context;
        protected readonly IRequestUser _requestUser;

        public IUserRepository Users { get; private set; }
        public IErrorLogRepository ErrorLog { get; private set; }
        public IPasswordRequestRepository PasswordRequest { get; private set; }
        
        public UnitOfWork(BugTrackerDBContext context, IRequestUser requestUser)
        {
            _context = context;
            _requestUser = requestUser;
            Users = new UserRepository(_context, _requestUser);
            ErrorLog = new ErrorLogRepository(_context, _requestUser);
            PasswordRequest = new PasswordRequestRepository(_context, _requestUser);
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



    /// <summary>
    /// IUnitOfWork DI Interface
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IErrorLogRepository ErrorLog { get; }
        IPasswordRequestRepository PasswordRequest { get; }

        int Complete();
    }
}
