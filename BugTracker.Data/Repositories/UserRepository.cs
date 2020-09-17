using BugTracker.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(BugTrackerDBContext context, IRequestUser requestUser) : base(context, requestUser) { }

    }

    public interface IUserRepository : IBaseRepository<User>
    {

    }
}
