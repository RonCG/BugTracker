using System;
using System.Collections.Generic;

namespace BugTracker.Data
{
    public partial class Attachment
    {
        public int AttachmentId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
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
