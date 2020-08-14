using System;
using System.Collections.Generic;

namespace BugTracker.Data
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public int Author { get; set; }
        public int RelatedTableId { get; set; }
        public int RelatedId { get; set; }
        public bool Active { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime EditDate { get; set; }
        public int EditedBy { get; set; }

        public virtual Table RelatedTable { get; set; }
    }
}
