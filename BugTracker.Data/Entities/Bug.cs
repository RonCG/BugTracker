using System;
using System.Collections.Generic;

namespace BugTracker.Data
{
    public partial class Bug
    {
        public int BugId { get; set; }
        public int TaskId { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public DateTime IdentifiedDate { get; set; }
        public int ReportedBy { get; set; }
        public int? Responsible { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public bool Active { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime EditDate { get; set; }
        public int EditedBy { get; set; }

        public virtual Status StatusNavigation { get; set; }
        public virtual Task Task { get; set; }
    }
}
