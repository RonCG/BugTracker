using System;
using System.Collections.Generic;

namespace BugTracker.Data
{
    public partial class Project
    {
        public Project()
        {
            Task = new HashSet<Task>();
            Userproject = new HashSet<Userproject>();
        }

        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public bool Active { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime EditDate { get; set; }
        public int EditedBy { get; set; }

        public virtual Status Status { get; set; }
        public virtual ICollection<Task> Task { get; set; }
        public virtual ICollection<Userproject> Userproject { get; set; }
    }
}
