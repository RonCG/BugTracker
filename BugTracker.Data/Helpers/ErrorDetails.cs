using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace BugTracker.Data.Helpers
{
    public class ErrorDetails
    {
        public static string SetError(int statusCode, string message)
        {
            return JsonConvert.SerializeObject(new { statusCode, message } );
        }
    }
}
