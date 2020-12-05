using BugTracker.Data.Helpers;
using BugTracker.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LinqToDB;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(BugTrackerDBContext context, IRequestUser requestUser) : base(context, requestUser) 
        {
        }


        public UserModel GetUserDetail(int userID)
        {
            var userDetail = _db.User.Where(x => x.UserId == userID).Include(x => x.Userrole).ThenInclude(x => x.Role).Select(x => (UserModel)x).FirstOrDefault();
            
            return userDetail;
            
        }



        public UserModel GetUserByUsername(string username)
        {
            return _db.User.Where(x => x.UserName == username && x.StatusId == UserStatus.Active).Select(x => (UserModel)x).FirstOrDefault();
        }



        /// <summary>
        /// Returns the roles of the given user
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<RoleModel> GetUserRoles(int userID)
        {
            var query = from u in _db.User
                        from ur in _db.Userrole.InnerJoin(ur => ur.UserId == u.UserId)
                        from r in _db.Role.InnerJoin(r => r.RoleId == ur.RoleId)
                        where u.UserId == userID
                        select new RoleModel
                        {
                            RoleId = r.RoleId,
                            Name = r.Name,
                            Description = r.Description
                        };

            return query.ToList();
        }


    }

    public interface IUserRepository : IBaseRepository<User>
    {
        UserModel GetUserDetail(int userID);
        UserModel GetUserByUsername(string username);
        List<RoleModel> GetUserRoles(int userID);

    }
}
