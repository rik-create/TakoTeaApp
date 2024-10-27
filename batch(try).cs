using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TakoTea
{
    public partial class batch_try_ : Form
    {
        public batch_try_()
        {
            InitializeComponent();
            SetupHeader();
            SetupBatchListSection();


        }
        private void SetupBatchListSection()
        {
            // Panel for Batch List Section
            Panel batchListPanel = new Panel
            {
                Size = new Size(800, 600),
                Location = new Point(20, 120),
                BackColor = Color.FromArgb(55, 55, 55), // Dark gray background
                BorderStyle = BorderStyle.FixedSingle,
            };
            this.Controls.Add(batchListPanel);

            // Title Label
            Label titleLabel = new Label
            {
                Text = "Batch List",
                Font = new Font("Arial", 18, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 20),
                AutoSize = true,
            };
            batchListPanel.Controls.Add(titleLabel);

            // Search Input
            TextBox searchTextBox = new TextBox
            {
                Size = new Size(200, 30),
                Location = new Point(20, 60),
                BackColor = Color.FromArgb(75, 75, 75),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
            };
            batchListPanel.Controls.Add(searchTextBox);

            // Search Button
            Button searchButton = new Button
            {
                Text = "Search",
                Size = new Size(80, 30),
                Location = new Point(230, 60),
                BackColor = Color.Red,
                ForeColor = Color.White,
            };
            batchListPanel.Controls.Add(searchButton);

            // Date Range Filters
            DateTimePicker startDatePicker = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Size = new Size(120, 30),
                Location = new Point(20, 100),
                BackColor = Color.FromArgb(75, 75, 75),
                ForeColor = Color.White,
            };
            batchListPanel.Controls.Add(startDatePicker);

            DateTimePicker endDatePicker = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Size = new Size(120, 30),
                Location = new Point(150, 100),
                BackColor = Color.FromArgb(75, 75, 75),
                ForeColor = Color.White,
            };
            batchListPanel.Controls.Add(endDatePicker);

            // Filter by Date Range Button
            Button filterButton = new Button
            {
                Text = "Filter by Date Range",
                Size = new Size(140, 30),
                Location = new Point(280, 100),
                BackColor = Color.Gray,
                ForeColor = Color.White,
            };
            batchListPanel.Controls.Add(filterButton);

            // DataGridView for Batch List Table
            DataGridView batchGridView = new DataGridView
            {
                Size = new Size(760, 300),
                Location = new Point(20, 140),
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                BackgroundColor = Color.FromArgb(45, 45, 45),
                ForeColor = Color.White,
                EnableHeadersVisualStyles = false,
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(65, 65, 65),
                    ForeColor = Color.LightGray,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                },
            };
            batchListPanel.Controls.Add(batchGridView);

            // Define Columns
            batchGridView.Columns.Add("BatchNumber", "Batch Number");
            batchGridView.Columns.Add("ExpirationDate", "Expiration Date");
            batchGridView.Columns.Add("AssociatedItem", "Associated Item");

            // Add Action Button Column
            DataGridViewButtonColumn actionColumn = new DataGridViewButtonColumn
            {
                Text = "Edit Batch",
                UseColumnTextForButtonValue = true,
                HeaderText = "Actions",
                FlatStyle = FlatStyle.Flat,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.Green,
                    ForeColor = Color.White,
                },
            };
            batchGridView.Columns.Add(actionColumn);

            // Information Labels
            Label totalBatchesLabel = new Label
            {
                Text = "Total Batches: 5",
                ForeColor = Color.LightGray,
                Location = new Point(20, 460),
                AutoSize = true,
            };
            batchListPanel.Controls.Add(totalBatchesLabel);

            Label totalNearExpirationLabel = new Label
            {
                Text = "Total Nearing Expiration: 2",
                ForeColor = Color.LightGray,
                Location = new Point(20, 480),
                AutoSize = true,
            };
            batchListPanel.Controls.Add(totalNearExpirationLabel);

            // Add New Batch Button
            Button addBatchButton = new Button
            {
                Text = "Add New Batch",
                Size = new Size(120, 30),
                Location = new Point(20, 520),
                BackColor = Color.Blue,
                ForeColor = Color.White,
            };
            batchListPanel.Controls.Add(addBatchButton);

            // Pagination Controls
            Label paginationLabel = new Label
            {
                Text = "Showing 1 to 10 of 50 entries",
                ForeColor = Color.LightGray,
                Location = new Point(400, 530),
                AutoSize = true,
            };
            batchListPanel.Controls.Add(paginationLabel);

            Button previousPageButton = new Button
            {
                Text = "Previous",
                Size = new Size(80, 30),
                Location = new Point(600, 530),
                BackColor = Color.Gray,
                ForeColor = Color.White,
            };
            batchListPanel.Controls.Add(previousPageButton);

            Button nextPageButton = new Button
            {
                Text = "Next",
                Size = new Size(80, 30),
                Location = new Point(690, 530),
                BackColor = Color.Gray,
                ForeColor = Color.White,
            };
            batchListPanel.Controls.Add(nextPageButton);
        }

        private void SetupHeader()
        {
            // Panel for Header Background
            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.FromArgb(128, Color.Red), // Gradient effect is tricky; solid color used instead
            };
            this.Controls.Add(headerPanel);

            // Title Icon (Label as an icon placeholder)
            Label iconLabel = new Label
            {
                Text = "📈", // Use a Unicode icon or a PictureBox for an actual image
                Font = new Font("Arial", 24, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 20),
                AutoSize = true,
            };
            headerPanel.Controls.Add(iconLabel);

            // Title Text
            Label titleLabel = new Label
            {
                Text = "TakoTea Batch Management",
                Font = new Font("Arial", 18, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(60, 25),
                AutoSize = true,
            };
            headerPanel.Controls.Add(titleLabel);

            // Search Box
            TextBox searchTextBox = new TextBox
            {
                Font = new Font("Arial", 10),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(55, 55, 55),
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(150, 30),
                Location = new Point(headerPanel.Width - 250, 25),
            };
            searchTextBox.GotFocus += (s, e) => searchTextBox.BackColor = Color.DarkGray; // Focus effect
            headerPanel.Controls.Add(searchTextBox);

            // Notifications Button
            Button bellButton = new Button
            {
                Text = "🔔", // Icon as text or use an image in Image property
                Font = new Font("Arial", 18),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(40, 40),
                Location = new Point(headerPanel.Width - 90, 20),
                BackColor = Color.Transparent,
            };
            bellButton.FlatAppearance.BorderSize = 0;
            headerPanel.Controls.Add(bellButton);

            // User Profile Button
            Button userButton = new Button
            {
                Text = "👤", // Icon as text or use an image
                Font = new Font("Arial", 18),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(40, 40),
                Location = new Point(headerPanel.Width - 140, 20),
                BackColor = Color.Transparent,
            };
            userButton.FlatAppearance.BorderSize = 0;
            headerPanel.Controls.Add(userButton);
        }
    }
}
