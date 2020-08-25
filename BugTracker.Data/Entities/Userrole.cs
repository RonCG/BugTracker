using System;
using System.Collections.Generic;

namespace BugTracker.Data
{
    public partial class Userrole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? EditDate { get; set; }
        public int? EditedBy { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
