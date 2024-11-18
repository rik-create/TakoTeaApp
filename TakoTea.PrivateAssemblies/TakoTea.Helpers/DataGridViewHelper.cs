using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace TakoTea.Helpers
{
    public static class DataGridViewHelper
    {
        public static void BindDataToGridView(DataGridView gridView, BindingSource bindingSource, DataTable dataTable)
        {
            bindingSource.DataSource = dataTable;
            if (gridView.InvokeRequired)
            {
                _ = gridView.Invoke(new Action(() =>
                {
                    gridView.DataSource = bindingSource;
                    gridView.Refresh();
                }));
            }
            else
            {
                gridView.DataSource = bindingSource;
                gridView.Refresh();
            }
        }
        public static void BindNavigatorToBindingSource(BindingNavigator bindingNavigator, BindingSource bindingSource)
        {
            if (bindingNavigator.InvokeRequired)
            {
                _ = bindingNavigator.Invoke(new Action(() =>
                {
                    bindingNavigator.BindingSource = bindingSource;
                }));
            }
            else
            {
                bindingNavigator.BindingSource = bindingSource;
            }
        }
        public static void AddButtonToLastRow(DataGridView dataGridView, string buttonColumnName, string buttonText, Action<int> onButtonClick)
        {
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
            {
                Name = buttonColumnName,
                HeaderText = "Action",
                Text = buttonText,
                UseColumnTextForButtonValue = true
            };
            if (!dataGridView.Columns.Contains(buttonColumnName))
            {
                _ = dataGridView.Columns.Add(buttonColumn);
            }
            dataGridView.CellContentClick += (sender, e) =>
            {
                if (e.ColumnIndex == dataGridView.Columns[buttonColumnName].Index)
                {
                    onButtonClick?.Invoke(e.RowIndex);
                }
            };
        }


        public static void AddButtonToLastRow(
            DataGridView dataGridView,
            string buttonColumnName,
            string buttonText,
            Action<int> onButtonClick,
            Color? backgroundColor = null,
            Color? foregroundColor = null)
        {
            // Create a button column
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
            {
                Name = buttonColumnName,
                HeaderText = "Action",
                Text = buttonText,
                UseColumnTextForButtonValue = true,
                    FlatStyle = FlatStyle.Flat // Use Flat style to enable background color customization
            };

            // Apply custom colors if provided
            if (backgroundColor.HasValue)
            {
                buttonColumn.DefaultCellStyle.BackColor = backgroundColor.Value;
            }
            if (foregroundColor.HasValue)
            {
                buttonColumn.DefaultCellStyle.ForeColor = foregroundColor.Value;
            }

            // Add the button column if it does not already exist
            if (!dataGridView.Columns.Contains(buttonColumnName))
            {
                _ = dataGridView.Columns.Add(buttonColumn);
            }

            // Handle the button click event
            dataGridView.CellContentClick += (sender, e) =>
            {
                if (e.ColumnIndex == dataGridView.Columns[buttonColumnName].Index)
                {
                    onButtonClick?.Invoke(e.RowIndex);
                }
            };
        }



        public static void AddButtonsToLastRow(
    DataGridView dataGridView,
    List<(string buttonColumnName, string buttonText, Action<int> onButtonClick)> buttons)
        {
            foreach (var (buttonColumnName, buttonText, onButtonClick) in buttons)
            {
                // Create the button column if it doesn't already exist
                if (!dataGridView.Columns.Contains(buttonColumnName))
                {
                    var buttonColumn = new DataGridViewButtonColumn
                    {
                        Name = buttonColumnName,
                        HeaderText = "Action",
                        Text = buttonText,
                        UseColumnTextForButtonValue = true
                    };
                    _ = dataGridView.Columns.Add(buttonColumn);
                }

                // Attach the click event for the button
                dataGridView.CellContentClick += (sender, e) =>
                {
                    if (e.ColumnIndex == dataGridView.Columns[buttonColumnName].Index)
                    {
                        onButtonClick?.Invoke(e.RowIndex);
                    }
                };
            }
        }

        public static void ApplyDefaultStyles(DataGridView dataGridView)
        {
            // Column Headers Style
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = Color.LightGray,
                Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0),
                ForeColor = SystemColors.WindowText,
                SelectionBackColor = SystemColors.Highlight,
                SelectionForeColor = SystemColors.HighlightText,
                WrapMode = DataGridViewTriState.True
            };
            dataGridView.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            // Default Cell Style
            DataGridViewCellStyle defaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0),
                ForeColor = Color.FromArgb(222, 0, 0, 0),
                SelectionBackColor = SystemColors.Highlight,
                SelectionForeColor = SystemColors.HighlightText,
                WrapMode = DataGridViewTriState.False
            };
            dataGridView.DefaultCellStyle = defaultCellStyle;
            // Row Headers Style
            DataGridViewCellStyle rowHeaderStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = SystemColors.Window,
                Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0),
                ForeColor = SystemColors.WindowText,
                SelectionBackColor = SystemColors.Highlight,
                SelectionForeColor = SystemColors.HighlightText,
                WrapMode = DataGridViewTriState.True
            };
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
