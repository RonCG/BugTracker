using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.Data.Models
{
    public class ResetPasswordModel
    {
        public string RequestID { get; set; }
        public string NewPassword { get; set; }
    }
}
