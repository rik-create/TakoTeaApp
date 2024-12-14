namespace TakoTea.Views.MainForm
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
            this.tabPageProduct = new System.Windows.Forms.TabPage();
            this.menuStripProduct = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemVariants = new System.Windows.Forms.ToolStripMenuItem();
            this.comboMealsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.variantsChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelProduct = new System.Windows.Forms.Panel();
            this.tabPageSales = new System.Windows.Forms.TabPage();
            this.panelSales = new System.Windows.Forms.Panel();
            this.tabPageItem = new System.Windows.Forms.TabPage();
            this.panelItem = new System.Windows.Forms.Panel();
            this.menuStripItem = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.ingredientChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addOnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageStock = new System.Windows.Forms.TabPage();
            this.panelStock = new System.Windows.Forms.Panel();
            this.tabPageBatch = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.batchListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batchChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelBatch = new System.Windows.Forms.Panel();
            this.tabPageReports = new System.Windows.Forms.TabPage();
            this.panelReports = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miniToolStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripQuickAccess = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnNewOrder = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnAddIngredient = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnAddProduct = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.buttonQuickAccess = new MaterialSkin.Controls.MaterialButton();
            this.takoTeaLabel1 = new TakoTea.Controls.TakoTeaLabel();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.materialTabControl1.SuspendLayout();
            this.tabPageDashboard.SuspendLayout();
            this.tabPageProduct.SuspendLayout();
            this.menuStripProduct.SuspendLayout();
            this.tabPageSales.SuspendLayout();
            this.tabPageItem.SuspendLayout();
            this.menuStripItem.SuspendLayout();
            this.tabPageStock.SuspendLayout();
            this.tabPageBatch.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabPageReports.SuspendLayout();
            this.toolStripQuickAccess.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.materialTabControl1.Controls.Add(this.tabPageDashboard);
            this.materialTabControl1.Controls.Add(this.tabPageProduct);
            this.materialTabControl1.Controls.Add(this.tabPageSales);
            this.materialTabControl1.Controls.Add(this.tabPageItem);
            this.materialTabControl1.Controls.Add(this.tabPageStock);
            this.materialTabControl1.Controls.Add(this.tabPageBatch);
            this.materialTabControl1.Controls.Add(this.tabPageReports);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl1.ImageList = this.imageList1;
            this.materialTabControl1.Location = new System.Drawing.Point(3, 80);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(1156, 694);
            this.materialTabControl1.TabIndex = 0;
            this.materialTabControl1.SelectedIndexChanged += new System.EventHandler(this.materialTabControl1_SelectedIndexChanged);
            // 
            // tabPageDashboard
            // 
            this.tabPageDashboard.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPageDashboard.Controls.Add(this.panelDashboard);
            this.tabPageDashboard.ImageKey = "icons8-dashboard-24.png";
            this.tabPageDashboard.Location = new System.Drawing.Point(4, 42);
            this.tabPageDashboard.Name = "tabPageDashboard";
            this.tabPageDashboard.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDashboard.Size = new System.Drawing.Size(1148, 648);
            this.tabPageDashboard.TabIndex = 0;
            this.tabPageDashboard.Text = "Dashboard";
            // 
            // panelDashboard
            // 
            this.panelDashboard.AutoScroll = true;
            this.panelDashboard.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelDashboard.Location = new System.Drawing.Point(190, 30);
            this.panelDashboard.Margin = new System.Windows.Forms.Padding(0);
            this.panelDashboard.Name = "panelDashboard";
            this.panelDashboard.Size = new System.Drawing.Size(930, 694);
            this.panelDashboard.TabIndex = 3;
            // 
            // tabPageProduct
            // 
            this.tabPageProduct.AutoScroll = true;
            this.tabPageProduct.Controls.Add(this.menuStripProduct);
            this.tabPageProduct.Controls.Add(this.panelProduct);
            this.tabPageProduct.ImageKey = "takoyaki(1).png";
            this.tabPageProduct.Location = new System.Drawing.Point(4, 42);
            this.tabPageProduct.Name = "tabPageProduct";
            this.tabPageProduct.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProduct.Size = new System.Drawing.Size(1302, 648);
            this.tabPageProduct.TabIndex = 8;
            this.tabPageProduct.Text = "Product";
            this.tabPageProduct.UseVisualStyleBackColor = true;
            // 
            // menuStripProduct
            // 
            this.menuStripProduct.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStripProduct.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStripProduct.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemProducts,
            this.toolStripMenuItemVariants,
            this.comboMealsToolStripMenuItem,
            this.variantsChangesToolStripMenuItem});
            this.menuStripProduct.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStripProduct.Location = new System.Drawing.Point(3, 3);
            this.menuStripProduct.Name = "menuStripProduct";
            this.menuStripProduct.Size = new System.Drawing.Size(1279, 24);
            this.menuStripProduct.TabIndex = 5;
            this.menuStripProduct.Text = "Dashboard Sections";
            // 
            // toolStripMenuItemProducts
            // 
            this.toolStripMenuItemProducts.Name = "toolStripMenuItemProducts";
            this.toolStripMenuItemProducts.Size = new System.Drawing.Size(66, 20);
            this.toolStripMenuItemProducts.Text = "Products";
            this.toolStripMenuItemProducts.Click += new System.EventHandler(this.toolStripMenuItemProducts_Click_1);
            // 
            // toolStripMenuItemVariants
            // 
            this.toolStripMenuItemVariants.Name = "toolStripMenuItemVariants";
            this.toolStripMenuItemVariants.Size = new System.Drawing.Size(60, 20);
            this.toolStripMenuItemVariants.Text = "Variants";
            this.toolStripMenuItemVariants.Click += new System.EventHandler(this.toolStripMenuItemVariants_Click);
            // 
            // comboMealsToolStripMenuItem
            // 
            this.comboMealsToolStripMenuItem.Name = "comboMealsToolStripMenuItem";
            this.comboMealsToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.comboMealsToolStripMenuItem.Text = "Combo Meals";
            this.comboMealsToolStripMenuItem.Click += new System.EventHandler(this.comboMealsToolStripMenuItem_Click);
            // 
            // variantsChangesToolStripMenuItem
            // 
            this.variantsChangesToolStripMenuItem.Name = "variantsChangesToolStripMenuItem";
            this.variantsChangesToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.variantsChangesToolStripMenuItem.Text = "Variants Changes";
            this.variantsChangesToolStripMenuItem.Click += new System.EventHandler(this.variantsChangesToolStripMenuItem_Click);
            // 
            // panelProduct
            // 
            this.panelProduct.Location = new System.Drawing.Point(230, 40);
            this.panelProduct.Name = "panelProduct";
            this.panelProduct.Size = new System.Drawing.Size(820, 660);
            this.panelProduct.TabIndex = 4;
            // 
            // tabPageSales
            // 
            this.tabPageSales.AutoScroll = true;
            this.tabPageSales.Controls.Add(this.panelSales);
            this.tabPageSales.ImageKey = "increase.png";
            this.tabPageSales.Location = new System.Drawing.Point(4, 42);
            this.tabPageSales.Name = "tabPageSales";
            this.tabPageSales.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSales.Size = new System.Drawing.Size(1302, 648);
            this.tabPageSales.TabIndex = 1;
            this.tabPageSales.Text = "Sales Management";
            this.tabPageSales.UseVisualStyleBackColor = true;
            // 
            // panelSales
            // 
            this.panelSales.Location = new System.Drawing.Point(220, 20);
            this.panelSales.Name = "panelSales";
            this.panelSales.Size = new System.Drawing.Size(900, 550);
            this.panelSales.TabIndex = 1;
            // 
            // tabPageItem
            // 
            this.tabPageItem.AutoScroll = true;
            this.tabPageItem.Controls.Add(this.panelItem);
            this.tabPageItem.Controls.Add(this.menuStripItem);
            this.tabPageItem.ImageKey = "box.png";
            this.tabPageItem.Location = new System.Drawing.Point(4, 42);
            this.tabPageItem.Name = "tabPageItem";
            this.tabPageItem.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageItem.Size = new System.Drawing.Size(1302, 648);
            this.tabPageItem.TabIndex = 2;
            this.tabPageItem.Text = "Item Management";
            this.tabPageItem.UseVisualStyleBackColor = true;
            // 
            // panelItem
            // 
            this.panelItem.AutoScroll = true;
            this.panelItem.Location = new System.Drawing.Point(230, 30);
            this.panelItem.Margin = new System.Windows.Forms.Padding(0);
            this.panelItem.MaximumSize = new System.Drawing.Size(1200, 900);
            this.panelItem.Name = "panelItem";
            this.panelItem.Size = new System.Drawing.Size(780, 700);
            this.panelItem.TabIndex = 4;
            // 
            // menuStripItem
            // 
            this.menuStripItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStripItem.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStripItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemList,
            this.toolStripMenuItemCategory,
            this.ingredientChangesToolStripMenuItem,
            this.addOnsToolStripMenuItem});
            this.menuStripItem.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStripItem.Location = new System.Drawing.Point(3, 3);
            this.menuStripItem.Name = "menuStripItem";
            this.menuStripItem.Size = new System.Drawing.Size(1279, 24);
            this.menuStripItem.TabIndex = 3;
            this.menuStripItem.Text = "Dashboard Sections";
            // 
            // toolStripMenuItemList
            // 
            this.toolStripMenuItemList.Name = "toolStripMenuItemList";
            this.toolStripMenuItemList.Size = new System.Drawing.Size(64, 20);
            this.toolStripMenuItemList.Text = "Item List";
            // 
            // toolStripMenuItemCategory
            // 
            this.toolStripMenuItemCategory.Name = "toolStripMenuItemCategory";
            this.toolStripMenuItemCategory.Size = new System.Drawing.Size(94, 20);
            this.toolStripMenuItemCategory.Text = "Item Category";
            // 
            // ingredientChangesToolStripMenuItem
            // 
            this.ingredientChangesToolStripMenuItem.Name = "ingredientChangesToolStripMenuItem";
            this.ingredientChangesToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.ingredientChangesToolStripMenuItem.Text = "Ingredient Changes";
            this.ingredientChangesToolStripMenuItem.Click += new System.EventHandler(this.ingredientChangesToolStripMenuItem_Click);
            // 
            // addOnsToolStripMenuItem
            // 
            this.addOnsToolStripMenuItem.Name = "addOnsToolStripMenuItem";
            this.addOnsToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.addOnsToolStripMenuItem.Text = "AddOns";
            this.addOnsToolStripMenuItem.Click += new System.EventHandler(this.addOnsToolStripMenuItem_Click);
            // 
            // tabPageStock
            // 
            this.tabPageStock.AutoScroll = true;
            this.tabPageStock.Controls.Add(this.panelStock);
            this.tabPageStock.ImageKey = "inventory.png";
            this.tabPageStock.Location = new System.Drawing.Point(4, 42);
            this.tabPageStock.Name = "tabPageStock";
            this.tabPageStock.Size = new System.Drawing.Size(1302, 648);
            this.tabPageStock.TabIndex = 4;
            this.tabPageStock.Text = "Stock Control";
            this.tabPageStock.UseVisualStyleBackColor = true;
            this.tabPageStock.Click += new System.EventHandler(this.tabPageStock_Click);
            // 
            // panelStock
            // 
            this.panelStock.Location = new System.Drawing.Point(340, 30);
            this.panelStock.Name = "panelStock";
            this.panelStock.Size = new System.Drawing.Size(630, 456);
            this.panelStock.TabIndex = 8;
            // 
            // tabPageBatch
            // 
            this.tabPageBatch.AutoScroll = true;
            this.tabPageBatch.Controls.Add(this.menuStrip1);
            this.tabPageBatch.Controls.Add(this.panelBatch);
            this.tabPageBatch.ImageKey = "stacked-files.png";
            this.tabPageBatch.Location = new System.Drawing.Point(4, 42);
            this.tabPageBatch.Name = "tabPageBatch";
            this.tabPageBatch.Size = new System.Drawing.Size(1302, 648);
            this.tabPageBatch.TabIndex = 5;
            this.tabPageBatch.Text = "Batch Management";
            this.tabPageBatch.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.batchListToolStripMenuItem,
            this.batchChangesToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1302, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "Dashboard Sections";
            // 
            // batchListToolStripMenuItem
            // 
            this.batchListToolStripMenuItem.Name = "batchListToolStripMenuItem";
            this.batchListToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.batchListToolStripMenuItem.Text = "Batch List";
            this.batchListToolStripMenuItem.Click += new System.EventHandler(this.batchListToolStripMenuItem_Click);
            // 
            // batchChangesToolStripMenuItem
            // 
            this.batchChangesToolStripMenuItem.Name = "batchChangesToolStripMenuItem";
            this.batchChangesToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.batchChangesToolStripMenuItem.Text = "Batch Changes";
            this.batchChangesToolStripMenuItem.Click += new System.EventHandler(this.batchChangesToolStripMenuItem_Click);
            // 
            // panelBatch
            // 
            this.panelBatch.AutoScroll = true;
            this.panelBatch.Location = new System.Drawing.Point(130, 20);
            this.panelBatch.Name = "panelBatch";
            this.panelBatch.Size = new System.Drawing.Size(990, 490);
            this.panelBatch.TabIndex = 2;
            // 
            // tabPageReports
            // 
            this.tabPageReports.Controls.Add(this.panelReports);
            this.tabPageReports.ImageKey = "report.png";
            this.tabPageReports.Location = new System.Drawing.Point(4, 42);
            this.tabPageReports.Name = "tabPageReports";
            this.tabPageReports.Size = new System.Drawing.Size(1302, 648);
            this.tabPageReports.TabIndex = 6;
            this.tabPageReports.Text = "Logs";
            this.tabPageReports.UseVisualStyleBackColor = true;
            // 
            // panelReports
            // 
            this.panelReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReports.Location = new System.Drawing.Point(0, 0);
            this.panelReports.Name = "panelReports";
            this.panelReports.Size = new System.Drawing.Size(1302, 648);
            this.panelReports.TabIndex = 2;
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
            // toolStripQuickAccess
            // 
            this.toolStripQuickAccess.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStripQuickAccess.Enabled = false;
            this.toolStripQuickAccess.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnNewOrder,
            this.toolStripBtnAddIngredient,
            this.toolStripBtnAddProduct,
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStripQuickAccess.Location = new System.Drawing.Point(1159, 80);
            this.toolStripQuickAccess.Name = "toolStripQuickAccess";
            this.toolStripQuickAccess.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStripQuickAccess.Size = new System.Drawing.Size(154, 694);
            this.toolStripQuickAccess.TabIndex = 3;
            this.toolStripQuickAccess.Text = "toolStrip1";
            this.toolStripQuickAccess.Visible = false;
            // 
            // toolStripBtnNewOrder
            // 
            this.toolStripBtnNewOrder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripBtnNewOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnNewOrder.Name = "toolStripBtnNewOrder";
            this.toolStripBtnNewOrder.Size = new System.Drawing.Size(151, 25);
            this.toolStripBtnNewOrder.Text = "New Order";
            this.toolStripBtnNewOrder.ToolTipText = "New Order";
            this.toolStripBtnNewOrder.Click += new System.EventHandler(this.toolStripBtnNewOrder_Click);
            // 
            // toolStripBtnAddIngredient
            // 
            this.toolStripBtnAddIngredient.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripBtnAddIngredient.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnAddIngredient.Name = "toolStripBtnAddIngredient";
            this.toolStripBtnAddIngredient.Size = new System.Drawing.Size(151, 25);
            this.toolStripBtnAddIngredient.Text = "Add New Ingredient";
            this.toolStripBtnAddIngredient.Click += new System.EventHandler(this.toolStripBtnAddIngredient_Click);
            // 
            // toolStripBtnAddProduct
            // 
            this.toolStripBtnAddProduct.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBtnAddProduct.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripBtnAddProduct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnAddProduct.Name = "toolStripBtnAddProduct";
            this.toolStripBtnAddProduct.Size = new System.Drawing.Size(151, 25);
            this.toolStripBtnAddProduct.Text = "Add New Product";
            this.toolStripBtnAddProduct.Click += new System.EventHandler(this.toolStripBtnAddProduct_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(151, 25);
            this.toolStripButton1.Text = "Reports";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(151, 25);
            this.toolStripButton2.Text = "Settings";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // buttonQuickAccess
            // 
            this.buttonQuickAccess.AutoSize = false;
            this.buttonQuickAccess.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonQuickAccess.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Dense;
            this.buttonQuickAccess.Depth = 0;
            this.buttonQuickAccess.HighEmphasis = false;
            this.buttonQuickAccess.Icon = null;
            this.buttonQuickAccess.Location = new System.Drawing.Point(1176, 40);
            this.buttonQuickAccess.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonQuickAccess.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonQuickAccess.Name = "buttonQuickAccess";
            this.buttonQuickAccess.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonQuickAccess.Size = new System.Drawing.Size(123, 24);
            this.buttonQuickAccess.TabIndex = 7;
            this.buttonQuickAccess.Text = "Quick Access";
            this.buttonQuickAccess.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonQuickAccess.UseAccentColor = true;
            this.buttonQuickAccess.UseVisualStyleBackColor = true;
            this.buttonQuickAccess.Click += new System.EventHandler(this.button1_Click);
            // 
            // takoTeaLabel1
            // 
            this.takoTeaLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(32)))), ((int)(((byte)(35)))));
            this.takoTeaLabel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("takoTeaLabel1.BackgroundImage")));
            this.takoTeaLabel1.Location = new System.Drawing.Point(64, 32);
            this.takoTeaLabel1.Name = "takoTeaLabel1";
            this.takoTeaLabel1.Size = new System.Drawing.Size(149, 47);
            this.takoTeaLabel1.TabIndex = 9;
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSize = false;
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Dense;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = false;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(1088, 40);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(77, 24);
            this.materialButton1.TabIndex = 8;
            this.materialButton1.Text = "Reload";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = true;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // TakoTeaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1313, 774);
            this.Controls.Add(this.takoTeaLabel1);
            this.Controls.Add(this.materialButton1);
            this.Controls.Add(this.buttonQuickAccess);
            this.Controls.Add(this.materialTabControl1);
            this.Controls.Add(this.toolStripQuickAccess);
            this.DrawerHighlightWithAccent = false;
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.materialTabControl1;
            this.DrawerWidth = 250;
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_56;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TakoTeaForm";
            this.Padding = new System.Windows.Forms.Padding(3, 80, 0, 0);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.materialTabControl1.ResumeLayout(false);
            this.tabPageDashboard.ResumeLayout(false);
            this.tabPageProduct.ResumeLayout(false);
            this.tabPageProduct.PerformLayout();
            this.menuStripProduct.ResumeLayout(false);
            this.menuStripProduct.PerformLayout();
            this.tabPageSales.ResumeLayout(false);
            this.tabPageItem.ResumeLayout(false);
            this.tabPageItem.PerformLayout();
            this.menuStripItem.ResumeLayout(false);
            this.menuStripItem.PerformLayout();
            this.tabPageStock.ResumeLayout(false);
            this.tabPageBatch.ResumeLayout(false);
            this.tabPageBatch.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPageReports.ResumeLayout(false);
            this.toolStripQuickAccess.ResumeLayout(false);
            this.toolStripQuickAccess.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.TabPage tabPageSales;
        private System.Windows.Forms.TabPage tabPageItem;
        private System.Windows.Forms.TabPage tabPageStock;
        private System.Windows.Forms.TabPage tabPageBatch;
        private System.Windows.Forms.TabPage tabPageReports;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panelSales;
        private System.Windows.Forms.Panel panelBatch;
        private System.Windows.Forms.Panel panelReports;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStripItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemList;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCategory;
        private System.Windows.Forms.TabPage tabPageProduct;
        private System.Windows.Forms.Panel panelProduct;
        private System.Windows.Forms.MenuStrip miniToolStrip;
        private System.Windows.Forms.Panel panelStock;
        public MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.Panel panelItem;
        private System.Windows.Forms.ToolStrip toolStripQuickAccess;
        private System.Windows.Forms.ToolStripButton toolStripBtnNewOrder;
        private System.Windows.Forms.ToolStripButton toolStripBtnAddIngredient;
        private System.Windows.Forms.ToolStripButton toolStripBtnAddProduct;
        private MaterialSkin.Controls.MaterialButton buttonQuickAccess;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.MenuStrip menuStripProduct;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemVariants;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemProducts;
        private System.Windows.Forms.TabPage tabPageDashboard;
        private System.Windows.Forms.Panel panelDashboard;
        private Controls.TakoTeaLabel takoTeaLabel1;
        private System.Windows.Forms.ToolStripMenuItem variantsChangesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingredientChangesToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem batchListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem batchChangesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comboMealsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addOnsToolStripMenuItem;
        private MaterialSkin.Controls.MaterialButton materialButton1;
    }
}