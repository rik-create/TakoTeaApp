using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Models;
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


        public static void FormatListView(ListView listView)
        {
            // Set background color to white
            listView.BackColor = Color.White;

            // Set text color to the primary color (using your ThemeConfigurator)
            listView.ForeColor = ThemeConfigurator.GetPrimaryColor();

            // Set the accent color for selection and highlighting
   

            // Adjust column headers appearance
            foreach (ColumnHeader column in listView.Columns)
            {
                column.TextAlign = HorizontalAlignment.Center;  // Optional: Align text to the center
                column.Width = -2; // Resize columns to fit contents automatically
            }

            // Enable grid lines for clarity
            listView.GridLines = true;

            // Adjust font for clarity and simplicity
            listView.Font = new Font("Arial", 10, FontStyle.Regular);

            // Remove unnecessary borders or settings for a simple look
            listView.BorderStyle = BorderStyle.None;
        }

        /*   public static void FormatListView(ListView listView)
           {
               // Set background color to white
               listView.BackColor = Color.White;

               // Set text color to the primary color (using your ThemeConfigurator)
               listView.ForeColor = ThemeConfigurator.GetPrimaryColor();
               listView.SelectedIndexChanged += (sender, e) =>
               {
                   foreach (ListViewItem item in listView.Items)
                   {
                       if (item.Selected)
                       {
                           item.BackColor = ThemeConfigurator.Get(); // Set background for selected item
                       }
                       else
                       {
                           item.BackColor = Color.White; // Default background for unselected items
                       }
                   }
               };


               // Adjust column headers appearance
               foreach (ColumnHeader column in listView.Columns)
               {
                   column.Width = -2; // Resize columns to fit contents automatically
               }

               // Enable grid lines for clarity
               listView.GridLines = true;

               // Adjust font for clarity and simplicity
               listView.Font = new Font("Arial", 10, FontStyle.Regular);

               // Remove unnecessary borders or settings for a simple look
               listView.BorderStyle = BorderStyle.None;
           }*/
  






        public static void LoadData<T>(
    Func<List<T>> dataRetrievalFunc,
    DataGridView dataGridView,
    BindingSource bindingSource,
    BindingNavigator bindingNavigator,
    string errorMessage = "Failed to load data.")
        {
            try
            {
                // Retrieve data using the provided function
                var data = dataRetrievalFunc.Invoke();
                if (data == null)
                {
                    DialogHelper.ShowError(errorMessage);
                    return;
                }

                // Bind data to the DataGridView and refresh
                DataGridViewHelper.BindDataToGridView(dataGridView, bindingSource, data);
                DataGridViewHelper.BindNavigatorToBindingSource(bindingNavigator, bindingSource);
            }
            catch (Exception ex)
            {
                DialogHelper.ShowError("Error loading data: " + ex.Message);
            }
        }
        public static void BindDataToGridView<T>(DataGridView gridView, BindingSource bindingSource, List<T> dataList)
        {
            bindingSource.DataSource = dataList;

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

        public static void HideColumn(DataGridView dataGridView, string columnName)
        {
            try
            {
                if (dataGridView.Columns.Contains(columnName))
                {
                    dataGridView.Columns[columnName].Visible = false;
                }
                else
                {
                    throw new ArgumentException($"Column '{columnName}' does not exist in the DataGridView.");
                }
            }
            catch (Exception ex)
            {
            }
        }



        public static void AddButtonsToLastRow(DataGridView dataGridView, string buttonColumnName, string buttonText, Action<int> buttonClickAction)
        {
            // Check if the column already exists to avoid duplicates
            if (!dataGridView.Columns.Contains(buttonColumnName))
            {
                // Create a new DataGridViewButtonColumn
                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.HeaderText = "";
                buttonColumn.Name = buttonColumnName;
                buttonColumn.Text = buttonText;
                buttonColumn.UseColumnTextForButtonValue = true;
                buttonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // Auto size the button column

                // Add the button column to the DataGridView
                dataGridView.Columns.Add(buttonColumn);
            }

            // Handle the CellClick event of the DataGridView
            dataGridView.CellClick += (sender, e) =>
            {
                if (e.ColumnIndex == dataGridView.Columns[buttonColumnName].Index && e.RowIndex >= 0)
                {
                    buttonClickAction(e.RowIndex); // Pass the rowIndex to the action
                }
            };
        }
      
        public static void UpdateGrid<T>(DataGridView dataGridView, BindingSource bindingSource, List<T> data)
        {
            // Clear existing data in the BindingSource
            bindingSource.Clear();

            // Add the new data to the BindingSource
            foreach (var item in data)
            {
                bindingSource.Add(item);
            }

            // Optionally, refresh the DataGridView to reflect the new data
            dataGridView.Refresh();
        }

        public static void SetImageColumnProperties(DataGridView dataGridView, string imageColumnName, int width, int height)
        {
            try
            {
                // Set column width and height for the image column
                dataGridView.Columns[imageColumnName].Width = width; // Set the width of the image column
                dataGridView.RowTemplate.Height = height; // Set the height for the rows containing images

                // Loop through all rows to apply settings for each image cell
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (!row.IsNewRow) // Skip new empty row
                    {
                        var imageCell = row.Cells[imageColumnName] as DataGridViewImageCell;
                        if (imageCell != null)
                        {
                            // Set alignment and image layout for the image cell
                            imageCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // Center the image
                            imageCell.Style.WrapMode = DataGridViewTriState.True; // Enable wrapping
                            imageCell.ImageLayout = DataGridViewImageCellLayout.Zoom; // Stretch the image to fit the cell
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error setting image column properties: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void SetRowHeight(DataGridView dataGridView, int height)
        {
            try
            {
                // Set the height of all rows
                dataGridView.RowTemplate.Height = height; // Set row height for all rows in DataGridView

                // If you want to apply this for already populated rows as well, you can loop through them
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    row.Height = height; // Set height for each row individually
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error setting row height: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public static void AddImageColumnFromImagePath(DataGridView dataGridView, string imagePathColumnName, int imageWidth, int imageHeight)
        {
            try
            {
                const string columnName = "ImageColumn";
                if (!dataGridView.Columns.Contains(columnName))
                {
                    var imageColumn = new DataGridViewImageColumn
                    {
                        Name = columnName,
                        HeaderText = "Image",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    };
                    dataGridView.Columns.Add(imageColumn);
                }

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        // Assuming the 'imagePathColumnName' column holds the image data as a byte array
                        byte[] imageData = (byte[])row.Cells[imagePathColumnName].Value;

                        if (imageData != null && imageData.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                Image originalImage = Image.FromStream(ms);
                                Image resizedImage = new Bitmap(originalImage, new Size(imageWidth, imageHeight));
                                row.Cells[columnName].Value = resizedImage;
                            }
                        }
                        else
                        {
                            row.Cells[columnName].Value = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding image column: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void PopulateListView<T>(
    ListView listView,
    IEnumerable<T> data,
    List<string> columnHeaders, int headerWidth,
    Func<T, List<string>> rowGenerator
    )
        {
            // Validate input parameters
            if (listView == null || data == null || columnHeaders == null || rowGenerator == null)
                throw new ArgumentNullException("One or more arguments are null.");

            // Clear the ListView before adding new items
            listView.Items.Clear();

            // Clear and add columns to the ListView
            listView.Columns.Clear();
            foreach (var header in columnHeaders)
            {
                listView.Columns.Add(header, headerWidth); // Set a default width of 330
            }

            // Populate the ListView rows
            foreach (var item in data)
            {
                var rowValues = rowGenerator(item);
                if (rowValues != null && rowValues.Count > 0)
                {
                    ListViewItem row = new ListViewItem(rowValues[0]); // First value is the main item text
                    for (int i = 1; i < rowValues.Count; i++)
                    {
                        row.SubItems.Add(rowValues[i]); // Add the remaining values as subitems
                    }
                    listView.Items.Add(row);
                }
            }

      
        }
        public static void ApplyDataGridViewStylesWithWrite(DataGridView dataGridView)
        {
            // Disable default visual styles for more control over appearance
            dataGridView.EnableHeadersVisualStyles = false;

            // Set the base colors for the DataGridView
            dataGridView.BackgroundColor = Color.WhiteSmoke; // Softer background color
            dataGridView.DefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64); // Dark gray text for better contrast

            // Style the column headers
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = ThemeConfigurator.GetCustomAccentColor(); // Use your accent color
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Use a slightly smaller and a more readable font
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // Style selected rows for better visibility
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView.DefaultCellStyle.SelectionBackColor = ThemeConfigurator.GetPrimaryColor(); // Use your primary color

            // Add subtle grid lines (optional)
            dataGridView.GridColor = Color.LightGray;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            // Set the default font for the DataGridView
            dataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Regular); // More readable font

            // Remove the default border
            dataGridView.BorderStyle = BorderStyle.None;

            // Configure sizing and behavior
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.ReadOnly = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;



        }
        public static void DeleteSelectedRows<T>(DataGridView dataGridView, string idColumnName) where T : class
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select at least one row to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete the selected rows?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                 var context = new Entities();
                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    int id = Convert.ToInt32(row.Cells[idColumnName].Value);
                    var entity = context.Set<T>().Find(id);
                    if (entity != null)
                    {
                        context.Set<T>().Remove(entity);
                    }
                }
                context.SaveChanges();



                // Refresh the DataGridView (you might need to adjust this based on your actual refresh logic)
                // dataGridView.DataSource = context.Set<T>().ToList(); 
            }
        }
   
        public static void ApplyDataGridViewStyles(DataGridView dataGridView)
        {

            // Disable default visual styles for more control over appearance
            dataGridView.EnableHeadersVisualStyles = false;

            // Set the base colors for the DataGridView
            dataGridView.BackgroundColor = Color.WhiteSmoke; // Softer background color
            dataGridView.DefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64); // Dark gray text for better contrast

            // Style the column headers
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = ThemeConfigurator.GetCustomAccentColor(); // Use your accent color
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Use a slightly smaller and a more readable font
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // Style selected rows for better visibility
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView.DefaultCellStyle.SelectionBackColor = ThemeConfigurator.GetPrimaryColor(); // Use your primary color

            // Add subtle grid lines (optional)
            dataGridView.GridColor = Color.LightGray;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            // Set the default font for the DataGridView
            dataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Regular); // More readable font

            // Remove the default border
            dataGridView.BorderStyle = BorderStyle.None;

            // Configure sizing and behavior
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.ReadOnly = true;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


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
            dataGridView.ReadOnly = true;
        }
    }
}
