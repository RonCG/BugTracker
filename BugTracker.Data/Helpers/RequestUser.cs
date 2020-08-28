using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace BugTracker.Data.Helpers
{
    /// <summary>
    /// Manage request user info 
    /// </summary>
    public class RequestUser : IRequestUser
    {
        private readonly HttpContext _context;

        public int UserID { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }

        public RequestUser(IHttpContextAccessor context)
        {
            _context = context.HttpContext;

            var userId = _context.User.Claims.Where(x => x.Type == "userid").FirstOrDefault();
            if (userId != null)
                UserID = Convert.ToInt32(userId.Value);

            var userName = _context.User.Claims.Where(x => x.Type == "username").FirstOrDefault();
            if (userName != null)
                UserName = userName.Value;

            var roles = _context.User.Claims.Where(x => x.Type == ClaimTypes.Role).ToList();
            if (roles != null)
                Roles = roles.Select(x => x.Value).ToList();
        }
    }



    /// <summary>
    /// Request User DI Interface
    /// </summary>
    public interface IRequestUser
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }
}
