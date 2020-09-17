using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.Data.Models
{
    public class ResetPasswordModel
    {
        public string Token { get; set; }
        public int UserID { get; set; }
        public string NewPassword { get; set; }
    }
}
