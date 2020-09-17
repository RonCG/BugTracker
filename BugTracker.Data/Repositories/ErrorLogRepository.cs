using BugTracker.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.Data.Repositories
{
    public class ErrorLogRepository : BaseRepository<Errorlog>, IErrorLogRepository
    {
        public ErrorLogRepository(BugTrackerDBContext context, IRequestUser requestUser) : base(context, requestUser) { }
    }

    public interface IErrorLogRepository : IBaseRepository<Errorlog>
    {

    }
}
