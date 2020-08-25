using System;
using System.Collections.Generic;

namespace BugTracker.Data
{
    public partial class Role
    {
        public Role()
        {
            Permission = new HashSet<Permission>();
            Userrole = new HashSet<Userrole>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateDby { get; set; }
        public DateTime EditDate { get; set; }
        public int EditedBy { get; set; }

        public virtual ICollection<Permission> Permission { get; set; }
        public virtual ICollection<Userrole> Userrole { get; set; }
    }
}
