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
        public RequestUser(IHttpContextAccessor context)
        {
            _context = context.HttpContext;
        }

        public int UserID => Convert.ToInt32(_context?.User?.Claims?.Where(x => x.Type == "userid").FirstOrDefault()?.Value);
        public string UserName => _context?.User?.Claims?.Where(x => x.Type == "username").FirstOrDefault()?.Value;
        public List<string> Roles => _context?.User?.Claims?.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToList();

    }



    /// <summary>
    /// Request User DI Interface
    /// </summary>
    public interface IRequestUser
    {
        public int UserID { get; }
        public string UserName { get; }
        public List<string> Roles { get; }
    }
}
