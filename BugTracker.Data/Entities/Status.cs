using System;
using System.Collections.Generic;

namespace BugTracker.Data
{
    public partial class Status
    {
        public Status()
        {
            Bug = new HashSet<Bug>();
            Project = new HashSet<Project>();
            Task = new HashSet<Task>();
        }

        public int StatusId { get; set; }
        public string Description { get; set; }
        public int RelatedTableId { get; set; }

        public virtual Table RelatedTable { get; set; }
        public virtual ICollection<Bug> Bug { get; set; }
        public virtual ICollection<Project> Project { get; set; }
        public virtual ICollection<Task> Task { get; set; }
    }
}
