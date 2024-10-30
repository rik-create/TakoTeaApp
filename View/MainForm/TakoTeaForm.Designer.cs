namespace TakoTea.MainForm
{
    partial class TakoTeaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TakoTeaForm));
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPageDashboard = new System.Windows.Forms.TabPage();
            this.panelDashboard = new System.Windows.Forms.Panel();
            this.menuStripDashboardSections = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemMainOverview = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemStockAlerts = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOrderQueue = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemUserActivities = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageProduct = new System.Windows.Forms.TabPage();
            this.panelProduct = new System.Windows.Forms.Panel();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageSales = new System.Windows.Forms.TabPage();
            this.panelSales = new System.Windows.Forms.Panel();
            this.tabPageItem = new System.Windows.Forms.TabPage();
            this.menuStripItem = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.panelItem = new System.Windows.Forms.Panel();
            this.tabPageOrder = new System.Windows.Forms.TabPage();
            this.panelOrder = new System.Windows.Forms.Panel();
            this.tabPageStock = new System.Windows.Forms.TabPage();
            this.panelStock = new System.Windows.Forms.Panel();
            this.menuStripStocks = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemStockLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAdjustStock = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLowStockAlerts = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageBatch = new System.Windows.Forms.TabPage();
            this.panelBatch = new System.Windows.Forms.Panel();
            this.tabPageReports = new System.Windows.Forms.TabPage();
            this.panelReports = new System.Windows.Forms.Panel();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miniToolStrip = new System.Windows.Forms.MenuStrip();
            this.materialTabControl1.SuspendLayout();
            this.tabPageDashboard.SuspendLayout();
            this.menuStripDashboardSections.SuspendLayout();
            this.tabPageProduct.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.tabPageSales.SuspendLayout();
            this.tabPageItem.SuspendLayout();
            this.menuStripItem.SuspendLayout();
            this.tabPageOrder.SuspendLayout();
            this.tabPageStock.SuspendLayout();
            this.menuStripStocks.SuspendLayout();
            this.tabPageBatch.SuspendLayout();
            this.tabPageReports.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPageDashboard);
            this.materialTabControl1.Controls.Add(this.tabPageProduct);
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
            this.materialTabControl1.Size = new System.Drawing.Size(1126, 682);
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
            this.tabPageDashboard.Size = new System.Drawing.Size(1118, 639);
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
            this.panelDashboard.Size = new System.Drawing.Size(1112, 609);
            this.panelDashboard.TabIndex = 1;
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
            this.menuStripDashboardSections.Size = new System.Drawing.Size(1112, 24);
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
            // tabPageProduct
            // 
            this.tabPageProduct.Controls.Add(this.panelProduct);
            this.tabPageProduct.Controls.Add(this.menuStrip2);
            this.tabPageProduct.ImageKey = "takoyaki(1).png";
            this.tabPageProduct.Location = new System.Drawing.Point(4, 39);
            this.tabPageProduct.Name = "tabPageProduct";
            this.tabPageProduct.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProduct.Size = new System.Drawing.Size(1118, 639);
            this.tabPageProduct.TabIndex = 8;
            this.tabPageProduct.Text = "Product";
            this.tabPageProduct.UseVisualStyleBackColor = true;
            // 
            // panelProduct
            // 
            this.panelProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProduct.Location = new System.Drawing.Point(3, 27);
            this.panelProduct.Name = "panelProduct";
            this.panelProduct.Size = new System.Drawing.Size(1112, 609);
            this.panelProduct.TabIndex = 4;
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8});
            this.menuStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip2.Location = new System.Drawing.Point(3, 3);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1112, 24);
            this.menuStrip2.TabIndex = 3;
            this.menuStrip2.Text = "Dashboard Sections";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(98, 20);
            this.toolStripMenuItem5.Text = "Main Overview";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(81, 20);
            this.toolStripMenuItem6.Text = "Stock Alerts";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(87, 20);
            this.toolStripMenuItem7.Text = "Order Queue";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(93, 20);
            this.toolStripMenuItem8.Text = "User Activities";
            // 
            // tabPageSales
            // 
            this.tabPageSales.Controls.Add(this.panelSales);
            this.tabPageSales.ImageKey = "increase.png";
            this.tabPageSales.Location = new System.Drawing.Point(4, 39);
            this.tabPageSales.Name = "tabPageSales";
            this.tabPageSales.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSales.Size = new System.Drawing.Size(1118, 639);
            this.tabPageSales.TabIndex = 1;
            this.tabPageSales.Text = "Sales Management";
            this.tabPageSales.UseVisualStyleBackColor = true;
            // 
            // panelSales
            // 
            this.panelSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSales.Location = new System.Drawing.Point(3, 3);
            this.panelSales.Name = "panelSales";
            this.panelSales.Size = new System.Drawing.Size(1112, 633);
            this.panelSales.TabIndex = 1;
            // 
            // tabPageItem
            // 
            this.tabPageItem.Controls.Add(this.menuStripItem);
            this.tabPageItem.Controls.Add(this.panelItem);
            this.tabPageItem.ImageKey = "box.png";
            this.tabPageItem.Location = new System.Drawing.Point(4, 39);
            this.tabPageItem.Name = "tabPageItem";
            this.tabPageItem.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageItem.Size = new System.Drawing.Size(1118, 639);
            this.tabPageItem.TabIndex = 2;
            this.tabPageItem.Text = "Item Management";
            this.tabPageItem.UseVisualStyleBackColor = true;
            // 
            // menuStripItem
            // 
            this.menuStripItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStripItem.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStripItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemList,
            this.toolStripMenuItemAdd,
            this.toolStripMenuItemEdit,
            this.toolStripMenuItemCategory});
            this.menuStripItem.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStripItem.Location = new System.Drawing.Point(3, 3);
            this.menuStripItem.Name = "menuStripItem";
            this.menuStripItem.Size = new System.Drawing.Size(1112, 24);
            this.menuStripItem.TabIndex = 3;
            this.menuStripItem.Text = "Dashboard Sections";
            this.menuStripItem.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStripItem_ItemClicked);
            // 
            // toolStripMenuItemList
            // 
            this.toolStripMenuItemList.Name = "toolStripMenuItemList";
            this.toolStripMenuItemList.Size = new System.Drawing.Size(64, 20);
            this.toolStripMenuItemList.Text = "Item List";
            // 
            // toolStripMenuItemAdd
            // 
            this.toolStripMenuItemAdd.Name = "toolStripMenuItemAdd";
            this.toolStripMenuItemAdd.Size = new System.Drawing.Size(95, 20);
            this.toolStripMenuItemAdd.Text = "Add New Item";
            // 
            // toolStripMenuItemEdit
            // 
            this.toolStripMenuItemEdit.Name = "toolStripMenuItemEdit";
            this.toolStripMenuItemEdit.Size = new System.Drawing.Size(66, 20);
            this.toolStripMenuItemEdit.Text = "Edit Item";
            // 
            // toolStripMenuItemCategory
            // 
            this.toolStripMenuItemCategory.Name = "toolStripMenuItemCategory";
            this.toolStripMenuItemCategory.Size = new System.Drawing.Size(94, 20);
            this.toolStripMenuItemCategory.Text = "Item Category";
            // 
            // panelItem
            // 
            this.panelItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelItem.Location = new System.Drawing.Point(3, 3);
            this.panelItem.Name = "panelItem";
            this.panelItem.Size = new System.Drawing.Size(1112, 633);
            this.panelItem.TabIndex = 2;
            // 
            // tabPageOrder
            // 
            this.tabPageOrder.Controls.Add(this.panelOrder);
            this.tabPageOrder.ImageKey = "passengers.png";
            this.tabPageOrder.Location = new System.Drawing.Point(4, 39);
            this.tabPageOrder.Name = "tabPageOrder";
            this.tabPageOrder.Size = new System.Drawing.Size(1118, 639);
            this.tabPageOrder.TabIndex = 3;
            this.tabPageOrder.Text = "Order";
            this.tabPageOrder.UseVisualStyleBackColor = true;
            // 
            // panelOrder
            // 
            this.panelOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOrder.Location = new System.Drawing.Point(0, 0);
            this.panelOrder.Name = "panelOrder";
            this.panelOrder.Size = new System.Drawing.Size(1118, 639);
            this.panelOrder.TabIndex = 2;
            // 
            // tabPageStock
            // 
            this.tabPageStock.Controls.Add(this.panelStock);
            this.tabPageStock.Controls.Add(this.menuStripStocks);
            this.tabPageStock.ImageKey = "inventory.png";
            this.tabPageStock.Location = new System.Drawing.Point(4, 39);
            this.tabPageStock.Name = "tabPageStock";
            this.tabPageStock.Size = new System.Drawing.Size(1118, 639);
            this.tabPageStock.TabIndex = 4;
            this.tabPageStock.Text = "Stock Control";
            this.tabPageStock.UseVisualStyleBackColor = true;
            // 
            // panelStock
            // 
            this.panelStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStock.Location = new System.Drawing.Point(0, 24);
            this.panelStock.Name = "panelStock";
            this.panelStock.Size = new System.Drawing.Size(1118, 615);
            this.panelStock.TabIndex = 8;
            // 
            // menuStripStocks
            // 
            this.menuStripStocks.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStripStocks.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStripStocks.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemStockLevel,
            this.toolStripMenuItemAdjustStock,
            this.toolStripMenuItemLowStockAlerts});
            this.menuStripStocks.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStripStocks.Location = new System.Drawing.Point(0, 0);
            this.menuStripStocks.Name = "menuStripStocks";
            this.menuStripStocks.Size = new System.Drawing.Size(1118, 24);
            this.menuStripStocks.TabIndex = 6;
            this.menuStripStocks.Text = "Dashboard Sections";
            this.menuStripStocks.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStripStocks_ItemClicked);
            // 
            // toolStripMenuItemStockLevel
            // 
            this.toolStripMenuItemStockLevel.Name = "toolStripMenuItemStockLevel";
            this.toolStripMenuItemStockLevel.Size = new System.Drawing.Size(78, 20);
            this.toolStripMenuItemStockLevel.Text = "Stock Level";
            // 
            // toolStripMenuItemAdjustStock
            // 
            this.toolStripMenuItemAdjustStock.Name = "toolStripMenuItemAdjustStock";
            this.toolStripMenuItemAdjustStock.Size = new System.Drawing.Size(85, 20);
            this.toolStripMenuItemAdjustStock.Text = "Adjust Stock";
            // 
            // toolStripMenuItemLowStockAlerts
            // 
            this.toolStripMenuItemLowStockAlerts.Name = "toolStripMenuItemLowStockAlerts";
            this.toolStripMenuItemLowStockAlerts.Size = new System.Drawing.Size(81, 20);
            this.toolStripMenuItemLowStockAlerts.Text = "Stock Alerts";
            // 
            // tabPageBatch
            // 
            this.tabPageBatch.Controls.Add(this.panelBatch);
            this.tabPageBatch.ImageKey = "stacked-files.png";
            this.tabPageBatch.Location = new System.Drawing.Point(4, 39);
            this.tabPageBatch.Name = "tabPageBatch";
            this.tabPageBatch.Size = new System.Drawing.Size(1118, 639);
            this.tabPageBatch.TabIndex = 5;
            this.tabPageBatch.Text = "Batch Management";
            this.tabPageBatch.UseVisualStyleBackColor = true;
            // 
            // panelBatch
            // 
            this.panelBatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBatch.Location = new System.Drawing.Point(0, 0);
            this.panelBatch.Name = "panelBatch";
            this.panelBatch.Size = new System.Drawing.Size(1118, 639);
            this.panelBatch.TabIndex = 2;
            // 
            // tabPageReports
            // 
            this.tabPageReports.Controls.Add(this.panelReports);
            this.tabPageReports.ImageKey = "report.png";
            this.tabPageReports.Location = new System.Drawing.Point(4, 39);
            this.tabPageReports.Name = "tabPageReports";
            this.tabPageReports.Size = new System.Drawing.Size(1118, 639);
            this.tabPageReports.TabIndex = 6;
            this.tabPageReports.Text = "Reports";
            this.tabPageReports.UseVisualStyleBackColor = true;
            // 
            // panelReports
            // 
            this.panelReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReports.Location = new System.Drawing.Point(0, 0);
            this.panelReports.Name = "panelReports";
            this.panelReports.Size = new System.Drawing.Size(1118, 639);
            this.panelReports.TabIndex = 2;
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.panelSettings);
            this.tabPageSettings.ImageKey = "settings.png";
            this.tabPageSettings.Location = new System.Drawing.Point(4, 39);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Size = new System.Drawing.Size(1118, 639);
            this.tabPageSettings.TabIndex = 7;
            this.tabPageSettings.Text = "Settings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // panelSettings
            // 
            this.panelSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSettings.Location = new System.Drawing.Point(0, 0);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(1118, 639);
            this.panelSettings.TabIndex = 2;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-dashboard-24.png");
            this.imageList1.Images.SetKeyName(1, "settings.png");
            this.imageList1.Images.SetKeyName(2, "report.png");
            this.imageList1.Images.SetKeyName(3, "passengers.png");
            this.imageList1.Images.SetKeyName(4, "inventory.png");
            this.imageList1.Images.SetKeyName(5, "stacked-files.png");
            this.imageList1.Images.SetKeyName(6, "box.png");
            this.imageList1.Images.SetKeyName(7, "increase.png");
            this.imageList1.Images.SetKeyName(8, "takoyaki(1).png");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AccessibleName = "New item selection";
            this.miniToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.BackColor = System.Drawing.Color.WhiteSmoke;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.miniToolStrip.Location = new System.Drawing.Point(254, 2);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(930, 24);
            this.miniToolStrip.TabIndex = 5;
            // 
            // TakoTeaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 746);
            this.Controls.Add(this.materialTabControl1);
            this.DrawerAutoShow = true;
            this.DrawerHighlightWithAccent = false;
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.materialTabControl1;
            this.Name = "TakoTeaForm";
            this.Padding = new System.Windows.Forms.Padding(0, 64, 0, 0);
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TakoTea";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.materialTabControl1.ResumeLayout(false);
            this.tabPageDashboard.ResumeLayout(false);
            this.tabPageDashboard.PerformLayout();
            this.menuStripDashboardSections.ResumeLayout(false);
            this.menuStripDashboardSections.PerformLayout();
            this.tabPageProduct.ResumeLayout(false);
            this.tabPageProduct.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.tabPageSales.ResumeLayout(false);
            this.tabPageItem.ResumeLayout(false);
            this.tabPageItem.PerformLayout();
            this.menuStripItem.ResumeLayout(false);
            this.menuStripItem.PerformLayout();
            this.tabPageOrder.ResumeLayout(false);
            this.tabPageStock.ResumeLayout(false);
            this.tabPageStock.PerformLayout();
            this.menuStripStocks.ResumeLayout(false);
            this.menuStripStocks.PerformLayout();
            this.tabPageBatch.ResumeLayout(false);
            this.tabPageReports.ResumeLayout(false);
            this.tabPageSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
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
        private System.Windows.Forms.Panel panelBatch;
        private System.Windows.Forms.Panel panelReports;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TabPage tabPageDashboard;
        private System.Windows.Forms.Panel panelDashboard;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMainOverview;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemStockAlerts;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOrderQueue;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUserActivities;
        private System.Windows.Forms.MenuStrip menuStripItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemList;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdd;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCategory;
        private System.Windows.Forms.TabPage tabPageProduct;
        private System.Windows.Forms.Panel panelProduct;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.MenuStrip menuStripStocks;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemStockLevel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdjustStock;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLowStockAlerts;
        private System.Windows.Forms.MenuStrip miniToolStrip;
        private System.Windows.Forms.Panel panelStock;
        public MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        public System.Windows.Forms.MenuStrip menuStripDashboardSections;
    }
}