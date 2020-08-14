﻿using System;
using System.Collections.Generic;

namespace BugTracker.Data
{
    public partial class User
    {
        public User()
        {
            Userproject = new HashSet<Userproject>();
        }

        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime EditDate { get; set; }
        public int EditedBy { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Userproject> Userproject { get; set; }
    }
}
