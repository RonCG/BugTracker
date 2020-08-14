using System;
using System.Collections.Generic;

namespace BugTracker.Data
{
    public partial class Buglog
    {
        public int BugLogId { get; set; }
        public int BugId { get; set; }
        public string ColumnName { get; set; }
        public string PreviousValue { get; set; }
        public string NewValue { get; set; }
        public DateTime EditDate { get; set; }
        public int EditedBy { get; set; }
    }
}
