using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Dashboard;
using TakoTea.View.Stock.Stock_Modal;
using TakoTea.MainForm;

namespace TakoTea.View.Stock
{
    public partial class CurrentStockForm : MaterialForm
    {
        private MaterialSkinManager materialSkinManager;

        public CurrentStockForm()
        {
            InitializeComponent();

            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);
            materialSkinManager = MaterialSkinManager.Instance;

            InitializeDataGridViewStockLevels();
            CustomizeDataGridView();


        }

        private void CustomizeDataGridView()
        {
            // Set the background color of the DataGridView to match the dark theme
            dataGridViewStockLevels.BackgroundColor = Color.FromArgb(80,80,80);

            // Set the grid color
            dataGridViewStockLevels.GridColor = materialSkinManager.ColorScheme.TextColor;

            // Set the header style
            dataGridViewStockLevels.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(80, 80, 80); // Set header color
            dataGridViewStockLevels.ColumnHeadersDefaultCellStyle.ForeColor = materialSkinManager.ColorScheme.TextColor; // Text color
            dataGridViewStockLevels.ColumnHeadersDefaultCellStyle.Font = new Font("Roboto", 12);

            // Set the cell style
            dataGridViewStockLevels.DefaultCellStyle.BackColor = Color.FromArgb(80, 80, 80);
            dataGridViewStockLevels.DefaultCellStyle.ForeColor = materialSkinManager.ColorScheme.TextColor;
            dataGridViewStockLevels.DefaultCellStyle.Font = new Font("Roboto", 10);

            // Set cell borders
            dataGridViewStockLevels.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Set alternating row colors for better visibility
            dataGridViewStockLevels.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(80, 80, 80);

            // Set row height for a better layout
            dataGridViewStockLevels.RowTemplate.Height = 40;

            // Set button appearance (for reorder and adjust buttons)
            dataGridViewStockLevels.Columns["ReorderButton"].DefaultCellStyle.BackColor = materialSkinManager.ColorScheme.TextColor;
            dataGridViewStockLevels.Columns["ReorderButton"].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewStockLevels.Columns["AdjustButton"].DefaultCellStyle.BackColor = materialSkinManager.ColorScheme.TextColor;
            dataGridViewStockLevels.Columns["AdjustButton"].DefaultCellStyle.ForeColor = Color.White;
        }

        private void InitializeDataGridViewStockLevels()
        {
            // Setting up the DataGridView properties
            dataGridViewStockLevels.AllowUserToAddRows = false; // Disable adding rows manually

            // Add Columns
            dataGridViewStockLevels.Columns.Add("Name", "Name");
            dataGridViewStockLevels.Columns.Add("Quantity", "Quantity");

            // Progress Bar Column (Level)
            DataGridViewProgressColumn levelColumn = new DataGridViewProgressColumn();
            levelColumn.Name = "Level";
            levelColumn.HeaderText = "Level";
            dataGridViewStockLevels.Columns.Add(levelColumn);

            // Button Column (Action: Reorder and Adjust)
            DataGridViewButtonColumn reorderButton = new DataGridViewButtonColumn();
            reorderButton.Name = "ReorderButton";
            reorderButton.HeaderText = "Reorder";
            reorderButton.Text = "Reorder";
            reorderButton.UseColumnTextForButtonValue = true;
            dataGridViewStockLevels.Columns.Add(reorderButton);

            DataGridViewButtonColumn adjustButton = new DataGridViewButtonColumn();
            adjustButton.Name = "AdjustButton";
            adjustButton.HeaderText = "Adjust";
            adjustButton.Text = "Adjust";
            adjustButton.UseColumnTextForButtonValue = true;
            dataGridViewStockLevels.Columns.Add(adjustButton);

            // Add Sample Data
            AddSampleData();
        }
        private void AddSampleData()
        {
            // Sample data
            dataGridViewStockLevels.Rows.Add("Takoyaki", 20, 50);      // Quantity: 20, Level: 50%
            dataGridViewStockLevels.Rows.Add("Milktea", 15, 75);       // Quantity: 15, Level: 75%
            dataGridViewStockLevels.Rows.Add("Boba", 30, 80);          // Quantity: 30, Level: 80%
            dataGridViewStockLevels.Rows.Add("Sushi", 10, 60);         // Quantity: 10, Level: 60%
            dataGridViewStockLevels.Rows.Add("Ramen", 25, 40);         // Quantity: 25, Level: 40%
            dataGridViewStockLevels.Rows.Add("Tempura", 5, 30);        // Quantity: 5, Level: 30%
            dataGridViewStockLevels.Rows.Add("Onigiri", 12, 70);       // Quantity: 12, Level: 70%
            dataGridViewStockLevels.Rows.Add("Matcha Cake", 8, 20);    // Quantity: 8, Level: 20%
            dataGridViewStockLevels.Rows.Add("Pudding", 18, 90);       // Quantity: 18, Level: 90%
            dataGridViewStockLevels.Rows.Add("Udon", 22, 55);          // Quantity: 22, Level: 55%
        }



        private void dataGridViewStockLevels_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewStockLevels.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                string itemName = dataGridViewStockLevels.Rows[e.RowIndex].Cells["Name"].Value.ToString();

                if (dataGridViewStockLevels.Columns[e.ColumnIndex].Name == "ReorderButton")
                {
                    MainForm.TakoTeaForm.Instance.Hide();
                    ReorderItemModal reorderItemModal = new ReorderItemModal();
                    reorderItemModal.ShowDialog();
                    MainForm.TakoTeaForm.Instance.Show();


                }
                else if (dataGridViewStockLevels.Columns[e.ColumnIndex].Name == "AdjustButton")
                {
                    MainForm.TakoTeaForm.Instance.Hide();

                    AdjustStockModal adjustStockModal = new AdjustStockModal();
                    adjustStockModal.ShowDialog();
                    MainForm.TakoTeaForm.Instance.Show();

                }
            }
        }

        private void materialLabel4_Click(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            panel3.Enabled = true;
            panel3.Visible = true;
        }

        private void materialLabel4_Click_1(object sender, EventArgs e)
        {

        }

        private void materialCheckedListBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialLabel6_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel2_Click(object sender, EventArgs e)
        {

        }

        private void materialSlider1_Click(object sender, EventArgs e)
        {

        }

        private void materialSlider2_Click(object sender, EventArgs e)
        {

        }
    }
    public class DataGridViewProgressColumn : DataGridViewColumn
    {
        public DataGridViewProgressColumn() : base(new DataGridViewProgressCell()) { }
    }

    public class DataGridViewProgressCell : DataGridViewTextBoxCell
    {
        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
                                      DataGridViewElementStates cellState, object value, object formattedValue,
                                      string errorText, DataGridViewCellStyle cellStyle,
                                      DataGridViewAdvancedBorderStyle advancedBorderStyle,
                                      DataGridViewPaintParts paintParts)
        {
            int progressVal = Convert.ToInt32(value);
            float percentage = progressVal / 100f;

            // Draw the progress bar background
            graphics.FillRectangle(Brushes.Gray, cellBounds);

            // Draw the progress bar
            graphics.FillRectangle(Brushes.Green, cellBounds.X, cellBounds.Y,
                                   Convert.ToInt32(cellBounds.Width * percentage), cellBounds.Height);

            // Draw text on top
            TextRenderer.DrawText(graphics, $"{progressVal}%", cellStyle.Font,
                                  cellBounds, Color.Black, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }




}
