using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.Data.Models
{
    /// <summary>
    /// User model
    /// </summary>
    public class UserModel
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public static explicit operator UserModel(User v)
        {
            return new UserModel
            {
                UserId = v.UserId,
                RoleId = v.RoleId,
                RoleName = v.Role.Name,
                FirstName = v.FirstName,
                LastName = v.LastName,
                UserName = v.UserName,
                Email = v.Email
            };
        }
    }
}
