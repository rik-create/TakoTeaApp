using System;
using System.Collections.Generic;
using System.Data;


namespace TakoTea.HELPERS
{

    public static class DapperExtensions
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> items)
        {
            var dataTable = new DataTable();

            // Get the properties of the object (column names)
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                dataTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }

            // Add the rows to the DataTable
            foreach (var item in items)
            {
                var row = dataTable.NewRow();
                foreach (var property in properties)
                {
                    row[property.Name] = property.GetValue(item) ?? DBNull.Value;
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }

}
