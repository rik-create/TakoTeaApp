using Helpers;
using System;
using TakoTea.Models;

namespace TakoTea.Helpers
{
    public static class LoggingHelper
    {

        public static void LogActivity(string activityType, string description)
        {
            Entities context = new Entities();
            ActivityLog activityLog = new ActivityLog
            {
                ActivityType = activityType,
                Description = description,
                Timestamp = DateTime.Now,
                Username = AuthenticationHelper._loggedInUsername
            };
            _ = context.ActivityLogs.Add(activityLog);
            _ = context.SaveChanges();
        }

        public static void LogChange(string tableName, int recordId, string columnName, string oldValue, string newValue, string action, string description, string changeDescription)
        {
            Entities context = new Entities();
            Log log = new Log
            {
                TableName = tableName,
                RecordID = recordId,
                ColumnName = columnName,
                OldValue = oldValue,
                NewValue = newValue,
                Action = action,
                Timestamp = DateTime.Now,
                Username = AuthenticationHelper._loggedInUsername,
                ChangeDescription_ = changeDescription,
                Description = description


            };
            _ = context.Logs.Add(log);
            _ = context.SaveChanges();

        }
    }
}