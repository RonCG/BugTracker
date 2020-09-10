using System;
using System.Collections.Generic;

namespace BugTracker.Data
{
    public partial class User
    {
        public User()
        {
            Userproject = new HashSet<Userproject>();
            Userrole = new HashSet<Userrole>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int StatusId { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime EditDate { get; set; }
        public int EditedBy { get; set; }

        public virtual Status Status { get; set; }
        public virtual ICollection<Userproject> Userproject { get; set; }
        public virtual ICollection<Userrole> Userrole { get; set; }
    }
}
