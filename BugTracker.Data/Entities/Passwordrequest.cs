using System;
using System.Collections.Generic;

namespace BugTracker.Data
{
    public partial class Passwordrequest
    {
        public int PasswordRequestId { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }
        public bool Active { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime EditDate { get; set; }
        public int EditedBy { get; set; }

        public virtual User User { get; set; }
    }
}
