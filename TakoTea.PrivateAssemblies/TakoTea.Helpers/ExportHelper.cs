using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TakoTea.Models;

namespace TakoTea.Helpers
{
    public static class ExportHelper
    {



        public static void ExportSpecificIngredientsToCsvUsingId(DataGridView dataGridView, string fileName)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                _ = MessageBox.Show("Please select at least one row to export.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            StringBuilder csvContent = new StringBuilder();
            _ = csvContent.AppendLine("IngredientID,IngredientName,BrandName,StockLevel,LowLevel,IsAddOn,TypeOfIngredient,MeasuringUnit");

            Entities context = new Entities();

            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                int ingredientId = Convert.ToInt32(row.Cells["IngredientID"].Value);
                Ingredient ingredient = context.Ingredients.FirstOrDefault(i => i.IngredientID == ingredientId);

                if (ingredient != null)
                {
                    _ = csvContent.AppendLine($"{ingredient.IngredientID},{ingredient.IngredientName},{ingredient.BrandName},{ingredient.StockLevel},{ingredient.LowLevel},{ingredient.IsAddOn},{ingredient.TypeOfIngredient},{ingredient.MeasuringUnit}");
                }
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV Files|*.csv",
                FileName = fileName
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, csvContent.ToString());
                _ = MessageBox.Show("Selected ingredients exported to CSV successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private static string GenerateExportFileName(string baseName, DateTime timestamp)
        {
            // Format the timestamp as "yyyyMMdd_HHmmss"
            string formattedTimestamp = timestamp.ToString("yyyyMMdd_HHmmss");

            // Combine the base name, timestamp, and ".csv" extension
            return $"{baseName}_{formattedTimestamp}.csv";
        }
        public static void ExportToCsv<T>() where T : class
        {
            Entities context = new Entities();
            List<T> data = context.Set<T>().ToList();

            StringBuilder csvContent = new StringBuilder();

            if (typeof(T) == typeof(Ingredient))
            {
                ExportIngredientsToCsv(context, data.Cast<object>().ToList(), csvContent);
            }
            else
            {
                // For other entities, use the original logic
                IEnumerable<System.Reflection.PropertyInfo> properties = typeof(T).GetProperties().Skip(1)
                    .Where(p => p.PropertyType == typeof(byte[]) ||
                               !typeof(System.Collections.IEnumerable).IsAssignableFrom(p.PropertyType) || p.PropertyType == typeof(string));

                _ = csvContent.AppendLine(string.Join(",", properties.Select(p => p.Name)));

                foreach (T item in data)
                {
                    IEnumerable<string> values = properties.Select(p =>
                    {
                        object value = p.GetValue(item);
                        return value is byte[] bytes ? Convert.ToBase64String(bytes) : value?.ToString().Replace(",", "?") ?? "";
                    });
                    _ = csvContent.AppendLine(string.Join(",", values));
                }
            }

            string fileName = GenerateExportFileName(typeof(T).Name, DateTime.Now);

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV Files|*.csv",
                FileName = fileName
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, csvContent.ToString());
                string directory = Path.GetDirectoryName(saveFileDialog.FileName);
                _ = MessageBox.Show($"Data exported to {fileName} in {directory}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
            }
        }

        private static void ExportIngredientsToCsv(Entities context, List<object> data, StringBuilder csvContent)
        {
            IEnumerable<Ingredient> ingredients = data.Cast<Ingredient>();

            // Get properties, skipping the first and excluding collections (except string)
            IEnumerable<System.Reflection.PropertyInfo> ingredientProperties = typeof(Ingredient).GetProperties().Skip(1)
                .Where(p => !typeof(System.Collections.IEnumerable).IsAssignableFrom(p.PropertyType) || p.PropertyType == typeof(string));

            // Get AddOn properties, skipping the first two and excluding collections (except string)
            IEnumerable<System.Reflection.PropertyInfo> addOnProperties = typeof(AddOn).GetProperties().Skip(2)
                .Where(p => !typeof(System.Collections.IEnumerable).IsAssignableFrom(p.PropertyType) || p.PropertyType == typeof(string));

            // Combine property names for the header
            _ = csvContent.AppendLine(string.Join(",", ingredientProperties.Select(p => p.Name).Concat(addOnProperties.Select(p => p.Name))));

            foreach (Ingredient ingredient in ingredients)
            {
                AddOn addOn = context.AddOns.FirstOrDefault(a => a.AddOnName == ingredient.IngredientName);

                // Get the values from Ingredient
                IEnumerable<string> ingredientValues = ingredientProperties.Select(p =>
                {
                    object value = p.GetValue(ingredient);
                    return value is byte[] bytes ? Convert.ToBase64String(bytes) : value?.ToString().Replace(",", "?") ?? "";
                });

                // Get the values from AddOn (if it exists)
                IEnumerable<string> addOnValues = addOn != null
                    ? addOnProperties.Select(p => p.GetValue(addOn)?.ToString().Replace(",", "?") ?? "")
                    : addOnProperties.Select(p => ""); // Empty strings if no AddOn

                // Combine the values and add to the CSV content
                _ = csvContent.AppendLine(string.Join(",", ingredientValues.Concat(addOnValues)));
            }
        }

        public static void ExportSelectedRowsToCsv(DataGridView dataGridView, string fileName)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                _ = MessageBox.Show("Please select at least one row to export.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            StringBuilder csvContent = new StringBuilder();

            // Add header row (assuming all columns should be exported)
            _ = csvContent.AppendLine(string.Join(",", dataGridView.Columns.Cast<DataGridViewColumn>().Select(c => c.HeaderText)));

            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                // Replace commas in cell values with question marks
                IEnumerable<string> values = row.Cells.Cast<DataGridViewCell>().Select(c => c.Value?.ToString().Replace(",", "?") ?? "");
                _ = csvContent.AppendLine(string.Join(",", values));
            }


            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV Files|*.csv",
                FileName = fileName
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, csvContent.ToString());
                _ = MessageBox.Show("Selected rows exported to CSV successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
