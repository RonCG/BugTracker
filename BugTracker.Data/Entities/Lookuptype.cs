using System;
using System.Collections.Generic;

namespace BugTracker.Data
{
    public partial class Lookuptype
    {
        public Lookuptype()
        {
            Lookup = new HashSet<Lookup>();
        }

        public int LookUpTypeId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Lookup> Lookup { get; set; }
    }
}
