using System;
using System.Collections.Generic;

namespace BugTracker.Data
{
    public partial class Tasklog
    {
        public int TaskLogId { get; set; }
        public int TaskRecordId { get; set; }
        public string ColumnName { get; set; }
        public string PreviousValue { get; set; }
        public string NewValue { get; set; }
        public DateTime EditDate { get; set; }
        public int EditedBy { get; set; }
    }
}
