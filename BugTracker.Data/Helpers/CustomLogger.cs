using BugTracker.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.Data.Helpers
{
    public class CustomLogger : ICustomLogger
    {
        private readonly IUnitOfWork _db;

        public CustomLogger(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;           
        }

        public void LogError(string exception)
        {
            Errorlog error = new Errorlog
            {
                ErrorDescription = exception
            };

            _db.ErrorLog.Add(error);
        }
    }

    public interface ICustomLogger
    {
        public void LogError(string exception);
    }
}
