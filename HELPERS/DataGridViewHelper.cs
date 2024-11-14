using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TakoTea.HELPERS
{
    public static class DataGridViewHelper
    {
        // Reusable method for adding a button to a DataGridView with custom behavior
        public static void AddButtonToLastRow(DataGridView dataGridView, string buttonColumnName, string buttonText, Action<int> onButtonClick)
        {
            // Create the button column
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
            {
                Name = buttonColumnName,
                HeaderText = "Action",  // You can customize this header if needed
                Text = buttonText,     // Set the text of the button
                UseColumnTextForButtonValue = true
            };

            // Add the button column if it doesn't exist
            if (!dataGridView.Columns.Contains(buttonColumnName))
            {
                dataGridView.Columns.Add(buttonColumn);
            }

            // Handle button clicks
            dataGridView.CellContentClick += (sender, e) =>
            {
                if (e.ColumnIndex == dataGridView.Columns[buttonColumnName].Index)
                {
                    // Call the custom callback with the clicked row index
                    onButtonClick?.Invoke(e.RowIndex);
                }
            };
        }
    }

}
