using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakoTea.Models;

namespace TakoTea.Helpers
{
    public static class LoggingHelper
    {

        public static void LogActivity(string activityType, string description)
        {
            var context = new Entities();
            var activityLog = new ActivityLog
            {
                ActivityType = activityType,
                Description = description,
                Timestamp = DateTime.Now,
                Username = AuthenticationHelper._loggedInUsername
            };
            context.ActivityLogs.Add(activityLog);
            context.SaveChanges();
        }

        public static void LogChange(string tableName, int recordId, string columnName, string oldValue, string newValue, string action)
        {
            var context = new Entities();
            var log = new Log
            {
                TableName = tableName,
                RecordID = recordId,
                ColumnName = columnName,
                OldValue = oldValue,
                NewValue = newValue,
                Action = action,
                Timestamp = DateTime.Now,
                Username = AuthenticationHelper._loggedInUsername
            };
            context.Logs.Add(log);

        }
    }
}