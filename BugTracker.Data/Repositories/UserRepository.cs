using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(BugTrackerDBContext context) : base(context) { }

    }

    public interface IUserRepository : IBaseRepository<User>
    {

    }
}
