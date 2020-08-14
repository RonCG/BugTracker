using System;
using System.Collections.Generic;

namespace BugTracker.Data
{
    public partial class Table
    {
        public Table()
        {
            Attachment = new HashSet<Attachment>();
            Comment = new HashSet<Comment>();
            Status = new HashSet<Status>();
        }

        public int TableId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Attachment> Attachment { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Status> Status { get; set; }
    }
}
