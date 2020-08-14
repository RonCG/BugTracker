using System;
using System.Collections.Generic;

namespace BugTracker.Data
{
    public partial class Element
    {
        public Element()
        {
            Permission = new HashSet<Permission>();
        }

        public int ElementId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Permission> Permission { get; set; }
    }
}
