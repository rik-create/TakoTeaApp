using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakoTea.Models;

namespace TakoTea.Repository
{
    public static  class LogChangesRepository
    {

        public static List<Log> GetAllChangeLogs()
        {
            try
            {
                using (var context = new Entities()) // Replace "Entities" with your DbContext class
                {
                    return context.Logs.ToList();
                }
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately (e.g., log the error, show a message box)
                MessageBox.Show($"Error fetching change logs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Log>(); // Return an empty list or handle the error as needed
            }
        }
        public static List<Log> GetProductVariantChangeLogs(int productVariantId)
        {
            using (var context = new Entities())
            {
                return context.Logs
                    .Where(log => log.TableName == "ProductVariants" && log.RecordID == productVariantId)
                    .OrderByDescending(log => log.Timestamp)
                    .ToList();
            }
        }
        public static List<Log> GetProductVariantChangeLogs()
        {
            using (var context = new Entities())
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
            using (var context = new Entities())
            {
                var actions = context.Logs
                    .Where(l => l.TableName == tableName)
                    .Select(l => l.Action)
                    .Distinct()
                    .ToList();
                foreach (var action in actions)
                {
                    if (!checkedListBoxAction.Items.Contains(action))
                    {
                        checkedListBoxAction.Items.Add(action);
                    }
                }
            }

            // Fill chkListBoxColumnName with column names based on table name
            using (var context = new Entities())
            {
                var columnNames = context.Logs
                    .Where(l => l.TableName == tableName)
                    .Select(l => l.ColumnName)
                    .Distinct()
                    .ToList();
                foreach (var columnName in columnNames)
                {
                    if (!chkListBoxColumnName.Items.Contains(columnName))
                    {
                        chkListBoxColumnName.Items.Add(columnName);
                    }
                }
            }
        }
        public static List<Log> GetBatchChangeLogs()
        {
            using (var context = new Entities())
            {
                return context.Logs
                    .Where(log => log.TableName == "Batch")
                    .OrderByDescending(log => log.Timestamp)
                    .ToList();
            }
        }
        public static List<Log> GetIngredientChangeLogs()
        {
            using (var context = new Entities())
            {
                return context.Logs
                    .Where(log => log.TableName == "Ingredients")
                    .OrderByDescending(log => log.Timestamp)
                    .ToList();
            }
        }
        public static List<Log> GetBatchChangeLogs(int batchId)
        {
            using (var context = new Entities())
            {
                return context.Logs
                    .Where(log => log.TableName == "Batches" && log.RecordID == batchId)
                    .OrderByDescending(log => log.Timestamp)
                    .ToList();
            }
        }
        public static List<Log> GetIngredientChangeLogs(int ingredientId)
        {
            using (var context = new Entities())
            {
                return context.Logs
                    .Where(log => log.TableName == "Ingredients" && log.RecordID == ingredientId)
                    .OrderByDescending(log => log.Timestamp)
                    .ToList();
            }
        }
    }
}
