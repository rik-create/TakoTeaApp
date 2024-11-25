using System.Windows.Forms;

namespace TakoTea.View.Orders

{

    partial class MenuOrderForm

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.panel2 = new System.Windows.Forms.Panel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.btnSearch = new MaterialSkin.Controls.MaterialButton();
            this.txtBoxSearchVariant = new MaterialSkin.Controls.MaterialTextBox2();
            this.flPanelProductVariantsMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelCategpries = new System.Windows.Forms.FlowLayoutPanel();
            this.panelCart = new System.Windows.Forms.Panel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.lblOrderId = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.btnClearOrderList = new MaterialSkin.Controls.MaterialButton();
            this.dataGridViewOrderList = new System.Windows.Forms.DataGridView();
            this.ColumnProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddOns = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxPayment = new System.Windows.Forms.GroupBox();
            this.cmbPaymentStatus = new MaterialSkin.Controls.MaterialComboBox();
            this.lblPaymentStatus = new MaterialSkin.Controls.MaterialLabel();
            this.cmbPaymentMethod = new MaterialSkin.Controls.MaterialComboBox();
            this.lblPaymentMethod = new MaterialSkin.Controls.MaterialLabel();
            this.lblTotalItems = new MaterialSkin.Controls.MaterialLabel();
            this.lblTotalItemInOrderList = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.lblTotalInOrderList = new MaterialSkin.Controls.MaterialLabel();
            this.btnSaveToDraft = new MaterialSkin.Controls.MaterialButton();
            this.btnConfirmOrder = new MaterialSkin.Controls.MaterialButton();
            this.panelSeparator = new System.Windows.Forms.Panel();
            this.materialCard1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.panelCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderList)).BeginInit();
            this.groupBoxPayment.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.panel2);
            this.materialCard1.Controls.Add(this.panelSearch);
            this.materialCard1.Controls.Add(this.flPanelProductVariantsMenu);
            this.materialCard1.Controls.Add(this.flowLayoutPanelCategpries);
            this.materialCard1.Controls.Add(this.panelCart);
            this.materialCard1.Depth = 0;
            this.materialCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(3, 24);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(1380, 759);
            this.materialCard1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.materialLabel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(214, 14);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(698, 46);
            this.panel2.TabIndex = 102;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel5.Location = new System.Drawing.Point(279, 10);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(134, 24);
            this.materialLabel5.TabIndex = 0;
            this.materialLabel5.Text = "Menu Ordering";
            // 
            // panelSearch
            // 
            this.panelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.panelSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Controls.Add(this.txtBoxSearchVariant);
            this.panelSearch.Location = new System.Drawing.Point(216, 60);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(698, 56);
            this.panelSearch.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSearch.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSearch.Depth = 0;
            this.btnSearch.HighEmphasis = true;
            this.btnSearch.Icon = null;
            this.btnSearch.Location = new System.Drawing.Point(350, 10);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSearch.Size = new System.Drawing.Size(78, 36);
            this.btnSearch.TabIndex = 97;
            this.btnSearch.Text = "Search";
            this.btnSearch.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSearch.UseAccentColor = false;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtBoxSearchVariant
            // 
            this.txtBoxSearchVariant.AnimateReadOnly = false;
            this.txtBoxSearchVariant.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtBoxSearchVariant.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBoxSearchVariant.Depth = 0;
            this.txtBoxSearchVariant.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtBoxSearchVariant.HideSelection = true;
            this.txtBoxSearchVariant.Hint = " Search for product name...";
            this.txtBoxSearchVariant.LeadingIcon = null;
            this.txtBoxSearchVariant.Location = new System.Drawing.Point(10, 4);
            this.txtBoxSearchVariant.MaxLength = 32767;
            this.txtBoxSearchVariant.MouseState = MaterialSkin.MouseState.OUT;
            this.txtBoxSearchVariant.Name = "txtBoxSearchVariant";
            this.txtBoxSearchVariant.PasswordChar = '\0';
            this.txtBoxSearchVariant.PrefixSuffixText = null;
            this.txtBoxSearchVariant.ReadOnly = false;
            this.txtBoxSearchVariant.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBoxSearchVariant.SelectedText = "";
            this.txtBoxSearchVariant.SelectionLength = 0;
            this.txtBoxSearchVariant.SelectionStart = 0;
            this.txtBoxSearchVariant.ShortcutsEnabled = true;
            this.txtBoxSearchVariant.Size = new System.Drawing.Size(328, 48);
            this.txtBoxSearchVariant.TabIndex = 96;
            this.txtBoxSearchVariant.TabStop = false;
            this.txtBoxSearchVariant.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBoxSearchVariant.TrailingIcon = null;
            this.txtBoxSearchVariant.UseSystemPasswordChar = false;
            // 
            // flPanelProductVariantsMenu
            // 
            this.flPanelProductVariantsMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flPanelProductVariantsMenu.AutoScroll = true;
            this.flPanelProductVariantsMenu.BackColor = System.Drawing.SystemColors.Control;
            this.flPanelProductVariantsMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flPanelProductVariantsMenu.Location = new System.Drawing.Point(216, 120);
            this.flPanelProductVariantsMenu.Name = "flPanelProductVariantsMenu";
            this.flPanelProductVariantsMenu.Padding = new System.Windows.Forms.Padding(10);
            this.flPanelProductVariantsMenu.Size = new System.Drawing.Size(696, 630);
            this.flPanelProductVariantsMenu.TabIndex = 4;
            this.flPanelProductVariantsMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.flPanelProductVariantsMenu_Paint);
            // 
            // flowLayoutPanelCategpries
            // 
            this.flowLayoutPanelCategpries.AutoScroll = true;
            this.flowLayoutPanelCategpries.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.flowLayoutPanelCategpries.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanelCategpries.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelCategpries.Location = new System.Drawing.Point(14, 14);
            this.flowLayoutPanelCategpries.Name = "flowLayoutPanelCategpries";
            this.flowLayoutPanelCategpries.Padding = new System.Windows.Forms.Padding(20, 15, 10, 10);
            this.flowLayoutPanelCategpries.Size = new System.Drawing.Size(200, 731);
            this.flowLayoutPanelCategpries.TabIndex = 3;
            // 
            // panelCart
            // 
            this.panelCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.panelCart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCart.Controls.Add(this.materialLabel1);
            this.panelCart.Controls.Add(this.lblOrderId);
            this.panelCart.Controls.Add(this.materialLabel2);
            this.panelCart.Controls.Add(this.btnClearOrderList);
            this.panelCart.Controls.Add(this.dataGridViewOrderList);
            this.panelCart.Controls.Add(this.groupBoxPayment);
            this.panelCart.Controls.Add(this.lblTotalItems);
            this.panelCart.Controls.Add(this.lblTotalItemInOrderList);
            this.panelCart.Controls.Add(this.materialLabel3);
            this.panelCart.Controls.Add(this.lblTotalInOrderList);
            this.panelCart.Controls.Add(this.btnSaveToDraft);
            this.panelCart.Controls.Add(this.btnConfirmOrder);
            this.panelCart.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelCart.Location = new System.Drawing.Point(912, 14);
            this.panelCart.Name = "panelCart";
            this.panelCart.Size = new System.Drawing.Size(454, 731);
            this.panelCart.TabIndex = 1;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel1.Location = new System.Drawing.Point(20, 20);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(89, 24);
            this.materialLabel1.TabIndex = 97;
            this.materialLabel1.Text = "Order List";
            // 
            // lblOrderId
            // 
            this.lblOrderId.AutoSize = true;
            this.lblOrderId.Depth = 0;
            this.lblOrderId.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblOrderId.Location = new System.Drawing.Point(384, 10);
            this.lblOrderId.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblOrderId.Name = "lblOrderId";
            this.lblOrderId.Size = new System.Drawing.Size(47, 19);
            this.lblOrderId.TabIndex = 101;
            this.lblOrderId.Text = "#1234";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(20, 50);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(177, 19);
            this.materialLabel2.TabIndex = 101;
            this.materialLabel2.Text = "Customer: Mark Gregorio";
            // 
            // btnClearOrderList
            // 
            this.btnClearOrderList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClearOrderList.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClearOrderList.Depth = 0;
            this.btnClearOrderList.HighEmphasis = true;
            this.btnClearOrderList.Icon = null;
            this.btnClearOrderList.Location = new System.Drawing.Point(364, 50);
            this.btnClearOrderList.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClearOrderList.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClearOrderList.Name = "btnClearOrderList";
            this.btnClearOrderList.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClearOrderList.Size = new System.Drawing.Size(66, 36);
            this.btnClearOrderList.TabIndex = 96;
            this.btnClearOrderList.Text = "Clear";
            this.btnClearOrderList.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClearOrderList.UseAccentColor = true;
            this.btnClearOrderList.UseVisualStyleBackColor = true;
            // 
            // dataGridViewOrderList
            // 
            this.dataGridViewOrderList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewOrderList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewOrderList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrderList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnProduct,
            this.Size,
            this.AddOns,
            this.ColumnQty,
            this.ColumnPrice});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewOrderList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewOrderList.EnableHeadersVisualStyles = false;
            this.dataGridViewOrderList.Location = new System.Drawing.Point(10, 100);
            this.dataGridViewOrderList.MultiSelect = false;
            this.dataGridViewOrderList.Name = "dataGridViewOrderList";
            this.dataGridViewOrderList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridViewOrderList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewOrderList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewOrderList.RowHeadersWidth = 25;
            this.dataGridViewOrderList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewOrderList.Size = new System.Drawing.Size(430, 332);
            this.dataGridViewOrderList.TabIndex = 100;
            // 
            // ColumnProduct
            // 
            this.ColumnProduct.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnProduct.HeaderText = "Product Name";
            this.ColumnProduct.Name = "ColumnProduct";
            // 
            // Size
            // 
            this.Size.HeaderText = "Size";
            this.Size.Name = "Size";
            this.Size.Width = 65;
            // 
            // AddOns
            // 
            this.AddOns.HeaderText = "AddOns";
            this.AddOns.Name = "AddOns";
            // 
            // ColumnQty
            // 
            this.ColumnQty.HeaderText = "Qty";
            this.ColumnQty.Name = "ColumnQty";
            this.ColumnQty.Width = 50;
            // 
            // ColumnPrice
            // 
            this.ColumnPrice.HeaderText = "Price";
            this.ColumnPrice.Name = "ColumnPrice";
            this.ColumnPrice.Width = 75;
            // 
            // groupBoxPayment
            // 
            this.groupBoxPayment.Controls.Add(this.cmbPaymentStatus);
            this.groupBoxPayment.Controls.Add(this.lblPaymentStatus);
            this.groupBoxPayment.Controls.Add(this.cmbPaymentMethod);
            this.groupBoxPayment.Controls.Add(this.lblPaymentMethod);
            this.groupBoxPayment.Location = new System.Drawing.Point(8, 456);
            this.groupBoxPayment.Name = "groupBoxPayment";
            this.groupBoxPayment.Size = new System.Drawing.Size(430, 140);
            this.groupBoxPayment.TabIndex = 103;
            this.groupBoxPayment.TabStop = false;
            this.groupBoxPayment.Text = "Payment";
            // 
            // cmbPaymentStatus
            // 
            this.cmbPaymentStatus.AutoResize = false;
            this.cmbPaymentStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbPaymentStatus.Depth = 0;
            this.cmbPaymentStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbPaymentStatus.DropDownHeight = 174;
            this.cmbPaymentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentStatus.DropDownWidth = 121;
            this.cmbPaymentStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbPaymentStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbPaymentStatus.FormattingEnabled = true;
            this.cmbPaymentStatus.Hint = "Choose payment status";
            this.cmbPaymentStatus.IntegralHeight = false;
            this.cmbPaymentStatus.ItemHeight = 43;
            this.cmbPaymentStatus.Items.AddRange(new object[] {
            "Pending",
            "Partial",
            "Paid"});
            this.cmbPaymentStatus.Location = new System.Drawing.Point(160, 80);
            this.cmbPaymentStatus.MaxDropDownItems = 4;
            this.cmbPaymentStatus.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbPaymentStatus.Name = "cmbPaymentStatus";
            this.cmbPaymentStatus.Size = new System.Drawing.Size(250, 49);
            this.cmbPaymentStatus.StartIndex = 0;
            this.cmbPaymentStatus.TabIndex = 105;
            // 
            // lblPaymentStatus
            // 
            this.lblPaymentStatus.AutoSize = true;
            this.lblPaymentStatus.Depth = 0;
            this.lblPaymentStatus.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPaymentStatus.Location = new System.Drawing.Point(20, 90);
            this.lblPaymentStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblPaymentStatus.Name = "lblPaymentStatus";
            this.lblPaymentStatus.Size = new System.Drawing.Size(114, 19);
            this.lblPaymentStatus.TabIndex = 104;
            this.lblPaymentStatus.Text = "Payment Status";
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.AutoResize = false;
            this.cmbPaymentMethod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbPaymentMethod.Depth = 0;
            this.cmbPaymentMethod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbPaymentMethod.DropDownHeight = 174;
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.DropDownWidth = 121;
            this.cmbPaymentMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbPaymentMethod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Hint = "Choose payment method";
            this.cmbPaymentMethod.IntegralHeight = false;
            this.cmbPaymentMethod.ItemHeight = 43;
            this.cmbPaymentMethod.Items.AddRange(new object[] {
            "Cash",
            "GCash",
            "Maya",
            "Card"});
            this.cmbPaymentMethod.Location = new System.Drawing.Point(160, 30);
            this.cmbPaymentMethod.MaxDropDownItems = 4;
            this.cmbPaymentMethod.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(250, 49);
            this.cmbPaymentMethod.StartIndex = 0;
            this.cmbPaymentMethod.TabIndex = 103;
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Depth = 0;
            this.lblPaymentMethod.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPaymentMethod.Location = new System.Drawing.Point(20, 40);
            this.lblPaymentMethod.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(122, 19);
            this.lblPaymentMethod.TabIndex = 102;
            this.lblPaymentMethod.Text = "Payment Method";
            // 
            // lblTotalItems
            // 
            this.lblTotalItems.AutoSize = true;
            this.lblTotalItems.Depth = 0;
            this.lblTotalItems.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTotalItems.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.lblTotalItems.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotalItems.Location = new System.Drawing.Point(16, 608);
            this.lblTotalItems.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTotalItems.Name = "lblTotalItems";
            this.lblTotalItems.Size = new System.Drawing.Size(123, 29);
            this.lblTotalItems.TabIndex = 102;
            this.lblTotalItems.Text = "Total Price:";
            // 
            // lblTotalItemInOrderList
            // 
            this.lblTotalItemInOrderList.Depth = 0;
            this.lblTotalItemInOrderList.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTotalItemInOrderList.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.lblTotalItemInOrderList.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotalItemInOrderList.Location = new System.Drawing.Point(144, 608);
            this.lblTotalItemInOrderList.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTotalItemInOrderList.Name = "lblTotalItemInOrderList";
            this.lblTotalItemInOrderList.Size = new System.Drawing.Size(293, 29);
            this.lblTotalItemInOrderList.TabIndex = 102;
            this.lblTotalItemInOrderList.Text = "P 100";
            this.lblTotalItemInOrderList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.materialLabel3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.materialLabel3.Location = new System.Drawing.Point(16, 640);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(123, 29);
            this.materialLabel3.TabIndex = 102;
            this.materialLabel3.Text = "Total Price:";
            // 
            // lblTotalInOrderList
            // 
            this.lblTotalInOrderList.Depth = 0;
            this.lblTotalInOrderList.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTotalInOrderList.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.lblTotalInOrderList.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotalInOrderList.Location = new System.Drawing.Point(144, 640);
            this.lblTotalInOrderList.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTotalInOrderList.Name = "lblTotalInOrderList";
            this.lblTotalInOrderList.Size = new System.Drawing.Size(293, 29);
            this.lblTotalInOrderList.TabIndex = 102;
            this.lblTotalInOrderList.Text = "P 100";
            this.lblTotalInOrderList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSaveToDraft
            // 
            this.btnSaveToDraft.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSaveToDraft.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSaveToDraft.Depth = 0;
            this.btnSaveToDraft.HighEmphasis = true;
            this.btnSaveToDraft.Icon = null;
            this.btnSaveToDraft.Location = new System.Drawing.Point(264, 680);
            this.btnSaveToDraft.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSaveToDraft.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSaveToDraft.Name = "btnSaveToDraft";
            this.btnSaveToDraft.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSaveToDraft.Size = new System.Drawing.Size(77, 36);
            this.btnSaveToDraft.TabIndex = 96;
            this.btnSaveToDraft.Text = "Cancel";
            this.btnSaveToDraft.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSaveToDraft.UseAccentColor = true;
            this.btnSaveToDraft.UseVisualStyleBackColor = true;
            // 
            // btnConfirmOrder
            // 
            this.btnConfirmOrder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnConfirmOrder.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnConfirmOrder.Depth = 0;
            this.btnConfirmOrder.HighEmphasis = true;
            this.btnConfirmOrder.Icon = null;
            this.btnConfirmOrder.Location = new System.Drawing.Point(354, 680);
            this.btnConfirmOrder.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnConfirmOrder.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnConfirmOrder.Name = "btnConfirmOrder";
            this.btnConfirmOrder.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnConfirmOrder.Size = new System.Drawing.Size(86, 36);
            this.btnConfirmOrder.TabIndex = 95;
            this.btnConfirmOrder.Text = "Confirm";
            this.btnConfirmOrder.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnConfirmOrder.UseAccentColor = false;
            this.btnConfirmOrder.UseVisualStyleBackColor = true;
            this.btnConfirmOrder.Click += new System.EventHandler(this.btnConfirmOrder_Click);
            // 
            // panelSeparator
            // 
            this.panelSeparator.BackColor = System.Drawing.Color.Gray;
            this.panelSeparator.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSeparator.Location = new System.Drawing.Point(200, 14);
            this.panelSeparator.Name = "panelSeparator";
            this.panelSeparator.Size = new System.Drawing.Size(1, 731);
            this.panelSeparator.TabIndex = 6;
            // 
            // MenuOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 786);
            this.Controls.Add(this.materialCard1);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.Name = "MenuOrderForm";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Ordering";
            this.materialCard1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panelCart.ResumeLayout(false);
            this.panelCart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderList)).EndInit();
            this.groupBoxPayment.ResumeLayout(false);
            this.groupBoxPayment.PerformLayout();
            this.ResumeLayout(false);

        }



        #endregion



        private MaterialSkin.Controls.MaterialCard materialCard1;

        private System.Windows.Forms.Panel panelCart;

        private MaterialSkin.Controls.MaterialLabel lblTotalInOrderList;

        private MaterialSkin.Controls.MaterialLabel lblOrderId;

        private MaterialSkin.Controls.MaterialLabel materialLabel2;

        private System.Windows.Forms.DataGridView dataGridViewOrderList;

        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProduct;

        private System.Windows.Forms.DataGridViewTextBoxColumn Size;

        private System.Windows.Forms.DataGridViewTextBoxColumn AddOns;

        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQty;

        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrice;

        private MaterialSkin.Controls.MaterialLabel materialLabel1;

        private MaterialSkin.Controls.MaterialButton btnClearOrderList;

        private MaterialSkin.Controls.MaterialButton btnSaveToDraft;

        private MaterialSkin.Controls.MaterialButton btnConfirmOrder;

        private System.Windows.Forms.Panel panelSearch;

        private MaterialSkin.Controls.MaterialButton btnSearch;

        private MaterialSkin.Controls.MaterialTextBox2 txtBoxSearchVariant;

        private System.Windows.Forms.FlowLayoutPanel flPanelProductVariantsMenu;

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCategpries;

        private System.Windows.Forms.Panel panel2;

        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private Panel panelSeparator;
        private GroupBox groupBoxPayment;

        // ... other controls ...

        private MaterialSkin.Controls.MaterialLabel lblPaymentMethod;
        private MaterialSkin.Controls.MaterialComboBox cmbPaymentMethod;
        private MaterialSkin.Controls.MaterialLabel lblPaymentStatus;
        private MaterialSkin.Controls.MaterialComboBox cmbPaymentStatus;
        private MaterialSkin.Controls.MaterialLabel lblTotalItems;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel lblTotalItemInOrderList;

        // ... other controls ...
    }

}