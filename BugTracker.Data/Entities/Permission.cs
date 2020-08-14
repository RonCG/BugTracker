using System;
using System.Collections.Generic;

namespace BugTracker.Data
{
    public partial class Permission
    {
        public int PermissionId { get; set; }
        public int RoleId { get; set; }
        public int ElementId { get; set; }
        public bool Create { get; set; }
        public bool Read { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
        public bool Active { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime EditDate { get; set; }
        public int EditedBy { get; set; }

        public virtual Element Element { get; set; }
        public virtual Role Role { get; set; }
    }
}
