using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.Data.Repositories
{
    public class ErrorLogRepository : BaseRepository<Errorlog>, IErrorLogRepository
    {
        public ErrorLogRepository(BugTrackerDBContext context) : base(context) { }
    }

    public interface IErrorLogRepository : IBaseRepository<Errorlog>
    {

    }
}
