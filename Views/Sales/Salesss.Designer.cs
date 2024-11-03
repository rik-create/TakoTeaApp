using System.Drawing;

namespace Sales
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.DataGridView salesGridView;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ImageList imageList;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();

            // Form properties
            this.Text = "TakoTea Sales Management";
            this.Size = new System.Drawing.Size(1200, 700); // Increased size for better visibility
            this.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // ToolTip
            this.toolTip = new System.Windows.Forms.ToolTip();
            this.toolTip.BackColor = System.Drawing.Color.LightYellow;

            // ImageList for icons
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.imageList.Images.Add("sales", SystemIcons.Application); // Placeholder icon
            this.imageList.Images.Add("entry", SystemIcons.Asterisk); // Placeholder icon
            this.imageList.Images.Add("analysis", SystemIcons.Question); // Placeholder icon
            this.imageList.Images.Add("customer", SystemIcons.Information); // Placeholder icon
            this.imageList.Images.Add("logout", SystemIcons.Shield); // Placeholder icon

            // Header panel
            this.headerPanel = new System.Windows.Forms.Panel
            {
                Size = new System.Drawing.Size(this.Width, 80),
                Dock = System.Windows.Forms.DockStyle.Top,
                BackColor = System.Drawing.Color.FromArgb(180, 0, 0)
            };
            this.Controls.Add(headerPanel);

            // Title label
            this.lblTitle = new System.Windows.Forms.Label
            {
                Text = "TakoTea Sales Management",
                Font = new System.Drawing.Font("Segoe UI", 20, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(20, 25),
                AutoSize = true
            };
            headerPanel.Controls.Add(lblTitle);

            // Search label
            this.lblSearch = new System.Windows.Forms.Label
            {
                Text = "Search:",
                ForeColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(800, 30),
                AutoSize = true
            };
            headerPanel.Controls.Add(lblSearch);

            // Search textbox
            this.txtSearch = new System.Windows.Forms.TextBox
            {
                Size = new System.Drawing.Size(200, 30),
                Location = new System.Drawing.Point(860, 25),
                ForeColor = System.Drawing.Color.Black,
                BackColor = System.Drawing.Color.White,
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                Font = new System.Drawing.Font("Segoe UI", 12)
            };
            headerPanel.Controls.Add(txtSearch);
            toolTip.SetToolTip(txtSearch, "Search for a product...");

            // Navigation buttons in header
            var btnSalesList = new System.Windows.Forms.Button
            {
                Text = "Sales List",
                Size = new System.Drawing.Size(120, 40),
                Location = new System.Drawing.Point(1060, 25),
                BackColor = System.Drawing.Color.FromArgb(100, 100, 100),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                ImageList = imageList,
                ImageAlign = System.Drawing.ContentAlignment.MiddleLeft,
                TextAlign = System.Drawing.ContentAlignment.MiddleRight,
                ImageIndex = 0,
                Font = new System.Drawing.Font("Segoe UI", 12)
            };
            headerPanel.Controls.Add(btnSalesList);

            var btnSalesEntry = new System.Windows.Forms.Button
            {
                Text = "Sales Entry",
                Size = new System.Drawing.Size(120, 40),
                Location = new System.Drawing.Point(1190, 25),
                BackColor = System.Drawing.Color.FromArgb(100, 100, 100),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                ImageList = imageList,
                ImageAlign = System.Drawing.ContentAlignment.MiddleLeft,
                TextAlign = System.Drawing.ContentAlignment.MiddleRight,
                ImageIndex = 1,
                Font = new System.Drawing.Font("Segoe UI", 12)
            };
            headerPanel.Controls.Add(btnSalesEntry);

            var btnSalesAnalysis = new System.Windows.Forms.Button
            {
                Text = "Sales Analysis",
                Size = new System.Drawing.Size(140, 40),
                Location = new System.Drawing.Point(1310, 25),
                BackColor = System.Drawing.Color.FromArgb(100, 100, 100),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                ImageList = imageList,
                ImageAlign = System.Drawing.ContentAlignment.MiddleLeft,
                TextAlign = System.Drawing.ContentAlignment.MiddleRight,
                ImageIndex = 2,
                Font = new System.Drawing.Font("Segoe UI", 12)
            };
            headerPanel.Controls.Add(btnSalesAnalysis);

            var btnCustomerManagement = new System.Windows.Forms.Button
            {
                Text = "Customer Management",
                Size = new System.Drawing.Size(180, 40),
                Location = new System.Drawing.Point(1450, 25),
                BackColor = System.Drawing.Color.FromArgb(100, 100, 100),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                ImageList = imageList,
                ImageAlign = System.Drawing.ContentAlignment.MiddleLeft,
                TextAlign = System.Drawing.ContentAlignment.MiddleRight,
                ImageIndex = 3,
                Font = new System.Drawing.Font("Segoe UI", 12)
            };
            headerPanel.Controls.Add(btnCustomerManagement);

            var btnLogout = new System.Windows.Forms.Button
            {
                Text = "Log Out",
                Size = new System.Drawing.Size(100, 40),
                Location = new System.Drawing.Point(1630, 25),
                BackColor = System.Drawing.Color.FromArgb(200, 50, 50),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                ImageList = imageList,
                ImageAlign = System.Drawing.ContentAlignment.MiddleLeft,
                TextAlign = System.Drawing.ContentAlignment.MiddleRight,
                ImageIndex = 4,
                Font = new System.Drawing.Font("Segoe UI", 12)
            };
            headerPanel.Controls.Add(btnLogout);

            // Description label
            this.lblDescription = new System.Windows.Forms.Label
            {
                Text = "List of recent sales transactions. You can edit or delete records.",
                ForeColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(20, 85),
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Italic)
            };
            this.Controls.Add(lblDescription);

            // DataGridView for sales list
            this.salesGridView = new System.Windows.Forms.DataGridView
            {
                Location = new System.Drawing.Point(20, 110),
                Size = new System.Drawing.Size(1160, 480), // Adjusted size for better visibility
                BackgroundColor = System.Drawing.Color.FromArgb(35, 35, 35),
                GridColor = System.Drawing.Color.DimGray,
                ColumnHeadersDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle
                {
                    BackColor = System.Drawing.Color.FromArgb(25, 25, 25),
                    ForeColor = System.Drawing.Color.White,
                    Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
                    Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                },
                DefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle
                {
                    BackColor = System.Drawing.Color.FromArgb(40, 40, 40),
                    ForeColor = System.Drawing.Color.LightGray,
                    SelectionBackColor = System.Drawing.Color.FromArgb(70, 70, 70),
                    SelectionForeColor = System.Drawing.Color.White,
                    Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
                },
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                EnableHeadersVisualStyles = false,
                ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            };
            this.Controls.Add(salesGridView);

            // Add columns to DataGridView
            salesGridView.Columns.Add("Product", "Product");
            salesGridView.Columns.Add("Quantity", "Quantity");
            salesGridView.Columns.Add("Total Price", "Total Price");
            salesGridView.Columns.Add("Date", "Date");
            salesGridView.Columns.Add("Time", "Time");

            // Button columns
            var editButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn
            {
                Text = "Edit",
                UseColumnTextForButtonValue = true,
                Name = "Edit",
                HeaderText = "Actions",
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                DefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle
                {
                    BackColor = System.Drawing.Color.FromArgb(200, 150, 0),
                    ForeColor = System.Drawing.Color.White
                }
            };

            var deleteButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn
            {
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                Name = "Delete",
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                DefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle
                {
                    BackColor = System.Drawing.Color.FromArgb(200, 50, 50),
                    ForeColor = System.Drawing.Color.White
                }
            };

            salesGridView.Columns.Add(editButtonColumn);
            salesGridView.Columns.Add(deleteButtonColumn);

            // Add some sample (decoy) data to DataGridView
            salesGridView.Rows.Add("Takoyaki", "10", "₱50.00", "2024-10-25", "14:30");
            salesGridView.Rows.Add("Milk Tea", "5", "₱25.00", "2024-10-25", "15:00");
            salesGridView.Rows.Add("Fries", "8", "₱20.00", "2024-10-26", "12:15");
            salesGridView.Rows.Add("Pizza Slice", "3", "₱15.00", "2024-10-26", "13:45");
            salesGridView.Rows.Add("Burger", "6", "₱30.00", "2024-10-27", "18:00");

            // Pagination buttons
            this.btnPrevious = new System.Windows.Forms.Button
            {
                Text = "Previous",
                Size = new System.Drawing.Size(100, 40),
                Location = new System.Drawing.Point(20, 600),
                BackColor = System.Drawing.Color.FromArgb(60, 60, 60),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                Font = new System.Drawing.Font("Segoe UI", 12)
            };
            this.Controls.Add(btnPrevious);
            toolTip.SetToolTip(btnPrevious, "Go to previous page");

            this.btnNext = new System.Windows.Forms.Button
            {
                Text = "Next",
                Size = new System.Drawing.Size(100, 40),
                Location = new System.Drawing.Point(130, 600),
                BackColor = System.Drawing.Color.FromArgb(60, 60, 60),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                Font = new System.Drawing.Font("Segoe UI", 12)
            };
            this.Controls.Add(btnNext);
            toolTip.SetToolTip(btnNext, "Go to next page");

            // Status bar
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel
            {
                Text = "Ready",
                ForeColor = System.Drawing.Color.White
            };
            this.statusBar.Items.Add(statusLabel);
            this.statusBar.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.Controls.Add(statusBar);

            this.ResumeLayout(false);
        }

        #endregion
    }
}
