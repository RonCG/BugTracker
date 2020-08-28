﻿using System;
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }

        public static explicit operator UserModel(User v)
        {
            return new UserModel
            {
                UserId = v.UserId,
                FirstName = v.FirstName,
                LastName = v.LastName,
                UserName = v.UserName,
                Email = v.Email                
            };
        }
    }
}