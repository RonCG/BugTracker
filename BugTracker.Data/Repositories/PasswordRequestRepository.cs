using BugTracker.Data.Helpers;
using BugTracker.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugTracker.Data.Repositories
{
    public class PasswordRequestRepository : BaseRepository<Passwordrequest>, IPasswordRequestRepository
    {
        public PasswordRequestRepository(BugTrackerDBContext context, IRequestUser requestUser) : base(context, requestUser) { }


        public Passwordrequest GetPasswordRequest(ResetPasswordModel data)
        {
            return base.Find(x => x.Token == data.Token && x.UserId == data.UserID && x.Active == true).FirstOrDefault();
        }

    }

    public interface IPasswordRequestRepository : IBaseRepository<Passwordrequest>
    {
        Passwordrequest GetPasswordRequest(ResetPasswordModel data);
    }
}
