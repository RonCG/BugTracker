using System;
using System.Collections.Generic;

namespace BugTracker.Data
{
    public partial class Errorlog
    {
        public int ErrorLogId { get; set; }
        public string ErrorDescription { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
    }
}
