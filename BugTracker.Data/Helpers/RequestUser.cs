using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;

namespace BugTracker.Data.Helpers
{
    /// <summary>
    /// Manage request user info 
    /// </summary>
    public class RequestUser : IRequestUser
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }

        private readonly HttpContext _context;

        public RequestUser(IHttpContextAccessor context)
        {
            _context = context.HttpContext;

            var userId = _context.User.Claims.Where(x => x.Type == "userid").FirstOrDefault();
            if (userId != null)
                UserID = Convert.ToInt32(userId.Value);

            var firstName = _context.User.Claims.Where(x => x.Type == "firstname").FirstOrDefault();
            if (firstName != null)
                FirstName = firstName.Value;

            var lastName = _context.User.Claims.Where(x => x.Type == "lastname").FirstOrDefault();
            if (lastName != null)
                LastName = lastName.Value;

            var userName = _context.User.Claims.Where(x => x.Type == "username").FirstOrDefault();
            if (userName != null)
                UserName = userName.Value;

            var role = _context.User.Claims.Where(x => x.Type == ClaimTypes.Role).FirstOrDefault();
            if (role != null)
                Role = role.Value;
        }
    }



    /// <summary>
    /// Request User DI Interface
    /// </summary>
    public interface IRequestUser
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
    }
}
