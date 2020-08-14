using System;
using System.Collections.Generic;

namespace BugTracker.Data
{
    public partial class Task
    {
        public Task()
        {
            Bug = new HashSet<Bug>();
        }

        public int TaskId { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public int? Responsible { get; set; }
        public int? Estimation { get; set; }
        public int Status { get; set; }
        public bool Active { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime EditDate { get; set; }
        public int EditedBy { get; set; }

        public virtual Project Project { get; set; }
        public virtual Status StatusNavigation { get; set; }
        public virtual ICollection<Bug> Bug { get; set; }
    }
}
