using BugTracker.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.Data.Repositories
{
    public class PasswordRequestRepository : BaseRepository<Passwordrequest>, IPasswordRequestRepository
    {
        public PasswordRequestRepository(BugTrackerDBContext context, IRequestUser requestUser) : base(context, requestUser) { }

    }

    public interface IPasswordRequestRepository : IBaseRepository<Passwordrequest>
    {

    }
}
