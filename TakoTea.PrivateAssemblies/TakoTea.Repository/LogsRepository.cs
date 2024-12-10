using System;
using System.Collections.Generic;
using System.Linq;
using TakoTea.Models;

namespace TakoTea.Repository
{
    public class LogsRepository
    {
        private readonly Entities context;
        public LogsRepository(Entities context)
        {
            this.context = context;
        }

        public List<LogData> GetAllLogs()
        {
            return context.Logs.Select(l => new LogData
            {
                LogID = l.LogID,
                TableName = l.TableName,
                RecordID = l.RecordID,
                ColumnName = l.ColumnName,
                OldValue = l.OldValue,
                NewValue = l.NewValue,
                Action = l.Action,
                Timestamp = l.Timestamp,
                Username = l.Username
            }).ToList();
        }
    }

    public class LogData
    {
        public int LogID { get; set; }
        public string TableName { get; set; }
        public int RecordID { get; set; }
        public string ColumnName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string Action { get; set; }
        public DateTime Timestamp { get; set; }
        public string Username { get; set; }
    }
}
