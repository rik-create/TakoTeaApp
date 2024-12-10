using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using TakoTea.Models;

namespace TakoTea.Repository
{
    public static class LogChangesRepository
    {
        public static DateTime? GetFirstRecordDate(string tableName, string dateColumnName)
        {
            using (Entities context = new Entities())
            {
                string sql = $"SELECT MIN([{dateColumnName}]) FROM [dbo].[Logs] WHERE TableName = @TableName";
                return context.Database.SqlQuery<DateTime?>(sql, new SqlParameter("@TableName", tableName)).FirstOrDefault();
            }
        }

        public static DateTime GetLastRecordDate(string tableName, string dateColumnName)
        {
            using (Entities context = new Entities())
            {
                // Construct the raw SQL query with parameterization
                string sql = $"SELECT MAX([{dateColumnName}]) FROM [dbo].[Logs] WHERE TableName = @TableName";

                // Execute the query with the parameter
                return context.Database.SqlQuery<DateTime>(sql, new SqlParameter("@TableName", tableName)).FirstOrDefault();
            }
        }
        public static List<Log> GetAllChangeLogs()
        {
            try
            {
                using (Entities context = new Entities()) // Replace "Entities" with your DbContext class
                {
                    return context.Logs.ToList();
                }
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately (e.g., log the error, show a message box)
                _ = MessageBox.Show($"Error fetching change logs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Log>(); // Return an empty list or handle the error as needed
            }
        }
        public static List<Log> GetProductVariantChangeLogs(int productVariantId)
        {
            using (Entities context = new Entities())
            {
                return context.Logs
                    .Where(log => log.TableName == "ProductVariants" && log.RecordID == productVariantId)
                    .OrderByDescending(log => log.Timestamp)
                    .ToList();
            }
        }
        public static List<Log> GetProductVariantChangeLogs()
        {
            using (Entities context = new Entities())
            {
                return context.Logs
                    .Where(log => log.TableName == "ProductVariants")
                    .OrderByDescending(log => log.Timestamp)
                    .ToList();
            }
        }
        public static void FillFilterLists(string tableName, CheckedListBox checkedListBoxAction, CheckedListBox chkListBoxColumnName)
        {
            // Fill checkedListBoxAction with distinct actions based on table name
            using (Entities context = new Entities())
            {
                List<string> actions = context.Logs
                    .Where(l => l.TableName == tableName)
                    .Select(l => l.Action)
                    .Distinct()
                    .ToList();
                foreach (string action in actions)
                {
                    if (!checkedListBoxAction.Items.Contains(action))
                    {
                        _ = checkedListBoxAction.Items.Add(action);
                    }
                }
            }

            // Fill chkListBoxColumnName with column names based on table name
            using (Entities context = new Entities())
            {
                List<string> columnNames = context.Logs
                    .Where(l => l.TableName == tableName)
                    .Select(l => l.ColumnName)
                    .Distinct()
                    .ToList();
                foreach (string columnName in columnNames)
                {
                    if (!chkListBoxColumnName.Items.Contains(columnName))
                    {
                        _ = chkListBoxColumnName.Items.Add(columnName);
                    }
                }
            }
        }
        public static List<Log> GetBatchChangeLogs()
        {
            using (Entities context = new Entities())
            {
                return context.Logs
                    .Where(log => log.TableName == "Batch")
                    .OrderByDescending(log => log.Timestamp)
                    .ToList();
            }
        }
        public static List<Log> GetIngredientChangeLogs()
        {
            using (Entities context = new Entities())
            {
                return context.Logs
                    .Where(log => log.TableName == "Ingredients")
                    .OrderByDescending(log => log.Timestamp)
                    .ToList();
            }
        }
        public static List<Log> GetBatchChangeLogs(int batchId)
        {
            using (Entities context = new Entities())
            {
                return context.Logs
                    .Where(log => log.TableName == "Batch" && log.RecordID == batchId)
                    .OrderByDescending(log => log.Timestamp)
                    .ToList();
            }
        }
        public static List<Log> GetIngredientChangeLogs(int ingredientId)
        {
            using (Entities context = new Entities())
            {
                return context.Logs
                    .Where(log => log.TableName == "Ingredients" && log.RecordID == ingredientId)
                    .OrderByDescending(log => log.Timestamp)
                    .ToList();
            }
        }
    }
}
