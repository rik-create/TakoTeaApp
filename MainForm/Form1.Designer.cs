namespace TakoTea.Dashboard
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPageDashboard = new System.Windows.Forms.TabPage();
            this.panelDashboard = new System.Windows.Forms.Panel();
            this.tabPageSales = new System.Windows.Forms.TabPage();
            this.panelSales = new System.Windows.Forms.Panel();
            this.tabPageItem = new System.Windows.Forms.TabPage();
            this.panelItem = new System.Windows.Forms.Panel();
            this.tabPageOrder = new System.Windows.Forms.TabPage();
            this.panelOrder = new System.Windows.Forms.Panel();
            this.tabPageStock = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelStock = new System.Windows.Forms.Panel();
            this.tabPageBatch = new System.Windows.Forms.TabPage();
            this.panelBatch = new System.Windows.Forms.Panel();
            this.tabPageReports = new System.Windows.Forms.TabPage();
            this.panelReports = new System.Windows.Forms.Panel();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.materialProgressBar1 = new MaterialSkin.Controls.MaterialProgressBar();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.menuStripDashboardSections = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemMainOverview = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemStockAlerts = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOrderQueue = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemUserActivities = new System.Windows.Forms.ToolStripMenuItem();
            this.materialTabControl1.SuspendLayout();
            this.tabPageDashboard.SuspendLayout();
            this.tabPageSales.SuspendLayout();
            this.tabPageItem.SuspendLayout();
            this.tabPageOrder.SuspendLayout();
            this.tabPageStock.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPageBatch.SuspendLayout();
            this.tabPageReports.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.menuStripDashboardSections.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPageDashboard);
            this.materialTabControl1.Controls.Add(this.tabPageSales);
            this.materialTabControl1.Controls.Add(this.tabPageItem);
            this.materialTabControl1.Controls.Add(this.tabPageOrder);
            this.materialTabControl1.Controls.Add(this.tabPageStock);
            this.materialTabControl1.Controls.Add(this.tabPageBatch);
            this.materialTabControl1.Controls.Add(this.tabPageReports);
            this.materialTabControl1.Controls.Add(this.tabPageSettings);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl1.ImageList = this.imageList1;
            this.materialTabControl1.Location = new System.Drawing.Point(0, 64);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(938, 685);
            this.materialTabControl1.TabIndex = 0;
            this.materialTabControl1.SelectedIndexChanged += new System.EventHandler(this.materialTabControl1_SelectedIndexChanged);
            // 
            // tabPageDashboard
            // 
            this.tabPageDashboard.AutoScroll = true;
            this.tabPageDashboard.Controls.Add(this.panelDashboard);
            this.tabPageDashboard.Controls.Add(this.menuStripDashboardSections);
            this.tabPageDashboard.ImageKey = "icons8-dashboard-24.png";
            this.tabPageDashboard.Location = new System.Drawing.Point(4, 39);
            this.tabPageDashboard.Name = "tabPageDashboard";
            this.tabPageDashboard.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDashboard.Size = new System.Drawing.Size(930, 642);
            this.tabPageDashboard.TabIndex = 0;
            this.tabPageDashboard.Text = "Dashboard";
            this.tabPageDashboard.UseVisualStyleBackColor = true;
            this.tabPageDashboard.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // panelDashboard
            // 
            this.panelDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDashboard.Location = new System.Drawing.Point(3, 27);
            this.panelDashboard.Name = "panelDashboard";
            this.panelDashboard.Size = new System.Drawing.Size(924, 612);
            this.panelDashboard.TabIndex = 1;
            // 
            // tabPageSales
            // 
            this.tabPageSales.Controls.Add(this.panelSales);
            this.tabPageSales.Location = new System.Drawing.Point(4, 39);
            this.tabPageSales.Name = "tabPageSales";
            this.tabPageSales.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSales.Size = new System.Drawing.Size(930, 642);
            this.tabPageSales.TabIndex = 1;
            this.tabPageSales.Text = "Sales Management";
            this.tabPageSales.UseVisualStyleBackColor = true;
            // 
            // panelSales
            // 
            this.panelSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSales.Location = new System.Drawing.Point(3, 3);
            this.panelSales.Name = "panelSales";
            this.panelSales.Size = new System.Drawing.Size(924, 636);
            this.panelSales.TabIndex = 1;
            // 
            // tabPageItem
            // 
            this.tabPageItem.Controls.Add(this.panelItem);
            this.tabPageItem.Location = new System.Drawing.Point(4, 39);
            this.tabPageItem.Name = "tabPageItem";
            this.tabPageItem.Size = new System.Drawing.Size(930, 642);
            this.tabPageItem.TabIndex = 2;
            this.tabPageItem.Text = "Item Management";
            this.tabPageItem.UseVisualStyleBackColor = true;
            // 
            // panelItem
            // 
            this.panelItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelItem.Location = new System.Drawing.Point(0, 0);
            this.panelItem.Name = "panelItem";
            this.panelItem.Size = new System.Drawing.Size(930, 642);
            this.panelItem.TabIndex = 2;
            // 
            // tabPageOrder
            // 
            this.tabPageOrder.Controls.Add(this.panelOrder);
            this.tabPageOrder.Location = new System.Drawing.Point(4, 39);
            this.tabPageOrder.Name = "tabPageOrder";
            this.tabPageOrder.Size = new System.Drawing.Size(930, 642);
            this.tabPageOrder.TabIndex = 3;
            this.tabPageOrder.Text = "Order";
            this.tabPageOrder.UseVisualStyleBackColor = true;
            // 
            // panelOrder
            // 
            this.panelOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOrder.Location = new System.Drawing.Point(0, 0);
            this.panelOrder.Name = "panelOrder";
            this.panelOrder.Size = new System.Drawing.Size(930, 642);
            this.panelOrder.TabIndex = 2;
            // 
            // tabPageStock
            // 
            this.tabPageStock.Controls.Add(this.panel2);
            this.tabPageStock.Location = new System.Drawing.Point(4, 39);
            this.tabPageStock.Name = "tabPageStock";
            this.tabPageStock.Size = new System.Drawing.Size(930, 642);
            this.tabPageStock.TabIndex = 4;
            this.tabPageStock.Text = "Stock Control";
            this.tabPageStock.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(930, 642);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panelStock);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(930, 642);
            this.panel3.TabIndex = 2;
            // 
            // panelStock
            // 
            this.panelStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStock.Location = new System.Drawing.Point(0, 0);
            this.panelStock.Name = "panelStock";
            this.panelStock.Size = new System.Drawing.Size(930, 642);
            this.panelStock.TabIndex = 2;
            // 
            // tabPageBatch
            // 
            this.tabPageBatch.Controls.Add(this.panelBatch);
            this.tabPageBatch.Location = new System.Drawing.Point(4, 39);
            this.tabPageBatch.Name = "tabPageBatch";
            this.tabPageBatch.Size = new System.Drawing.Size(930, 642);
            this.tabPageBatch.TabIndex = 5;
            this.tabPageBatch.Text = "Batch Management";
            this.tabPageBatch.UseVisualStyleBackColor = true;
            // 
            // panelBatch
            // 
            this.panelBatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBatch.Location = new System.Drawing.Point(0, 0);
            this.panelBatch.Name = "panelBatch";
            this.panelBatch.Size = new System.Drawing.Size(930, 642);
            this.panelBatch.TabIndex = 2;
            // 
            // tabPageReports
            // 
            this.tabPageReports.Controls.Add(this.panelReports);
            this.tabPageReports.Location = new System.Drawing.Point(4, 39);
            this.tabPageReports.Name = "tabPageReports";
            this.tabPageReports.Size = new System.Drawing.Size(930, 642);
            this.tabPageReports.TabIndex = 6;
            this.tabPageReports.Text = "Reports";
            this.tabPageReports.UseVisualStyleBackColor = true;
            // 
            // panelReports
            // 
            this.panelReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReports.Location = new System.Drawing.Point(0, 0);
            this.panelReports.Name = "panelReports";
            this.panelReports.Size = new System.Drawing.Size(930, 642);
            this.panelReports.TabIndex = 2;
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.panelSettings);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 39);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Size = new System.Drawing.Size(930, 642);
            this.tabPageSettings.TabIndex = 7;
            this.tabPageSettings.Text = "Settings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // panelSettings
            // 
            this.panelSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSettings.Location = new System.Drawing.Point(0, 0);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(930, 642);
            this.panelSettings.TabIndex = 2;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-dashboard-24.png");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // materialProgressBar1
            // 
            this.materialProgressBar1.Depth = 0;
            this.materialProgressBar1.Location = new System.Drawing.Point(870, 45);
            this.materialProgressBar1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialProgressBar1.Name = "materialProgressBar1";
            this.materialProgressBar1.Size = new System.Drawing.Size(67, 5);
            this.materialProgressBar1.TabIndex = 2;
            // 
            // iconButton1
            // 
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(334, 29);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(196, 29);
            this.iconButton1.TabIndex = 3;
            this.iconButton1.Text = "iconButton1";
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // menuStripDashboardSections
            // 
            this.menuStripDashboardSections.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStripDashboardSections.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStripDashboardSections.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemMainOverview,
            this.toolStripMenuItemStockAlerts,
            this.toolStripMenuItemOrderQueue,
            this.toolStripMenuItemUserActivities});
            this.menuStripDashboardSections.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStripDashboardSections.Location = new System.Drawing.Point(3, 3);
            this.menuStripDashboardSections.Name = "menuStripDashboardSections";
            this.menuStripDashboardSections.Size = new System.Drawing.Size(924, 24);
            this.menuStripDashboardSections.TabIndex = 2;
            this.menuStripDashboardSections.Text = "Dashboard Sections";
            this.menuStripDashboardSections.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStripDashboardSections_ItemClicked);
            // 
            // toolStripMenuItemMainOverview
            // 
            this.toolStripMenuItemMainOverview.Name = "toolStripMenuItemMainOverview";
            this.toolStripMenuItemMainOverview.Size = new System.Drawing.Size(98, 20);
            this.toolStripMenuItemMainOverview.Text = "Main Overview";
            // 
            // toolStripMenuItemStockAlerts
            // 
            this.toolStripMenuItemStockAlerts.Name = "toolStripMenuItemStockAlerts";
            this.toolStripMenuItemStockAlerts.Size = new System.Drawing.Size(81, 20);
            this.toolStripMenuItemStockAlerts.Text = "Stock Alerts";
            // 
            // toolStripMenuItemOrderQueue
            // 
            this.toolStripMenuItemOrderQueue.Name = "toolStripMenuItemOrderQueue";
            this.toolStripMenuItemOrderQueue.Size = new System.Drawing.Size(87, 20);
            this.toolStripMenuItemOrderQueue.Text = "Order Queue";
            // 
            // toolStripMenuItemUserActivities
            // 
            this.toolStripMenuItemUserActivities.Name = "toolStripMenuItemUserActivities";
            this.toolStripMenuItemUserActivities.Size = new System.Drawing.Size(93, 20);
            this.toolStripMenuItemUserActivities.Text = "User Activities";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 749);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.materialProgressBar1);
            this.Controls.Add(this.materialTabControl1);
            this.DrawerAutoShow = true;
            this.DrawerHighlightWithAccent = false;
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.materialTabControl1;
            this.DrawerWidth = 170;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(0, 64, 0, 0);
            this.Sizable = false;
            this.Text = "TakoTea";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.materialTabControl1.ResumeLayout(false);
            this.tabPageDashboard.ResumeLayout(false);
            this.tabPageDashboard.PerformLayout();
            this.tabPageSales.ResumeLayout(false);
            this.tabPageItem.ResumeLayout(false);
            this.tabPageOrder.ResumeLayout(false);
            this.tabPageStock.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabPageBatch.ResumeLayout(false);
            this.tabPageReports.ResumeLayout(false);
            this.tabPageSettings.ResumeLayout(false);
            this.menuStripDashboardSections.ResumeLayout(false);
            this.menuStripDashboardSections.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabPageSales;
        private System.Windows.Forms.TabPage tabPageItem;
        private System.Windows.Forms.TabPage tabPageOrder;
        private System.Windows.Forms.TabPage tabPageStock;
        private System.Windows.Forms.TabPage tabPageBatch;
        private System.Windows.Forms.TabPage tabPageReports;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panelSales;
        private System.Windows.Forms.Panel panelItem;
        private System.Windows.Forms.Panel panelOrder;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelStock;
        private System.Windows.Forms.Panel panelBatch;
        private System.Windows.Forms.Panel panelReports;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TabPage tabPageDashboard;
        private MaterialSkin.Controls.MaterialProgressBar materialProgressBar1;
        private System.Windows.Forms.Panel panelDashboard;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.MenuStrip menuStripDashboardSections;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMainOverview;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemStockAlerts;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOrderQueue;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUserActivities;
    }
}