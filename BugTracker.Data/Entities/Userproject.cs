using System;
using System.Collections.Generic;

namespace BugTracker.Data
{
    public partial class Userproject
    {
        public int Projectid { get; set; }
        public int UserId { get; set; }
        public bool Active { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedDy { get; set; }
        public DateTime EditDate { get; set; }
        public int EditedBy { get; set; }

        public virtual Project Project { get; set; }
        public virtual User User { get; set; }
    }
}
