using System;
using System.Collections.Generic;

namespace BugTracker.Data
{
    public partial class Lookup
    {
        public int LookUpId { get; set; }
        public int LookUpTypeId { get; set; }
        public string Description { get; set; }

        public virtual Lookuptype LookUpType { get; set; }
    }
}
