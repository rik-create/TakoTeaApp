using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace TakoTea.HELPERS
{
    public static class DataGridViewHelper
    {

        public static void BindDataToGridView(DataGridView gridView, BindingSource bindingSource, DataTable dataTable)
        {
            // Update the data source of the BindingSource
            bindingSource.DataSource = dataTable;

            // Check if the gridView needs to be updated on a different thread
            if (gridView.InvokeRequired)
            {
                gridView.Invoke(new Action(() =>
                {
                    gridView.DataSource = bindingSource;
                    gridView.Refresh();  // Explicitly refresh the DataGridView
                }));
            }
            else
            {
                gridView.DataSource = bindingSource;
                gridView.Refresh();  // Explicitly refresh the DataGridView
            }
        }


        public static void BindNavigatorToBindingSource(BindingNavigator bindingNavigator, BindingSource bindingSource)
        {
            // Ensure the BindingNavigator is properly bound to the BindingSource
            if (bindingNavigator.InvokeRequired)
            {
                bindingNavigator.Invoke(new Action(() =>
                {
                    bindingNavigator.BindingSource = bindingSource;
                }));
            }
            else
            {
                bindingNavigator.BindingSource = bindingSource;
            }
        }


        // Reusable method for adding a button to a DataGridView with custom behavior
        public static void AddButtonToLastRow(DataGridView dataGridView, string buttonColumnName, string buttonText, Action<int> onButtonClick)
        {
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
            {
                Name = buttonColumnName,
                HeaderText = "Action",  // You can customize this header if needed
                Text = buttonText,     // Set the text of the button
                UseColumnTextForButtonValue = true
            };

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


        public static void ApplyDefaultStyles(DataGridView dataGridView)
        {
            // Column Headers Style
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            columnHeaderStyle.BackColor = Color.LightGray;
            columnHeaderStyle.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            columnHeaderStyle.ForeColor = SystemColors.WindowText;
            columnHeaderStyle.SelectionBackColor = SystemColors.Highlight;
            columnHeaderStyle.SelectionForeColor = SystemColors.HighlightText;
            columnHeaderStyle.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // Default Cell Style
            DataGridViewCellStyle defaultCellStyle = new DataGridViewCellStyle();
            defaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            defaultCellStyle.BackColor = Color.White;
            defaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            defaultCellStyle.ForeColor = Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            defaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            defaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
            defaultCellStyle.WrapMode = DataGridViewTriState.False;
            dataGridView.DefaultCellStyle = defaultCellStyle;

            // Row Headers Style
            DataGridViewCellStyle rowHeaderStyle = new DataGridViewCellStyle();
            rowHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            rowHeaderStyle.BackColor = SystemColors.Window;
            rowHeaderStyle.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            rowHeaderStyle.ForeColor = SystemColors.WindowText;
            rowHeaderStyle.SelectionBackColor = SystemColors.Highlight;
            rowHeaderStyle.SelectionForeColor = SystemColors.HighlightText;
            rowHeaderStyle.WrapMode = DataGridViewTriState.True;
            dataGridView.RowHeadersDefaultCellStyle = rowHeaderStyle;

            // Additional DataGridView Properties
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.Dock = DockStyle.Bottom;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.GridColor = SystemColors.ControlDarkDark;
            dataGridView.Location = new Point(0, 30);
            dataGridView.Size = new Size(1125, 489);


                    dataGridView.ReadOnly = true;

        }
    }


  
}
