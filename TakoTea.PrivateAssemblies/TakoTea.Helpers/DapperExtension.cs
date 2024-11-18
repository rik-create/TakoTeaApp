using System;
using System.Collections.Generic;
using System.Data;
namespace TakoTea.Helpers
{
    public static class DapperExtensions
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> items)
        {
            DataTable dataTable = new DataTable();
            // Get the properties of the object (column names)
            System.Reflection.PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (System.Reflection.PropertyInfo property in properties)
            {
                _ = dataTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }
            // Add the rows to the DataTable
            foreach (T item in items)
            {
                DataRow row = dataTable.NewRow();
                foreach (System.Reflection.PropertyInfo property in properties)
                {
                    row[property.Name] = property.GetValue(item) ?? DBNull.Value;
                }
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }
    }
}
