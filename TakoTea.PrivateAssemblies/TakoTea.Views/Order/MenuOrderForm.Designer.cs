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
            this.btnViewDraftOrders = new MaterialSkin.Controls.MaterialButton();
            this.btnGoToOrderQueue = new MaterialSkin.Controls.MaterialButton();
            this.txtBoxSearchVariant = new MaterialSkin.Controls.MaterialTextBox2();
            this.flPanelProductVariantsMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelCategpries = new System.Windows.Forms.FlowLayoutPanel();
            this.panelCart = new System.Windows.Forms.Panel();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.lblChange = new MaterialSkin.Controls.MaterialLabel();
            this.buttonNow = new System.Windows.Forms.Button();
            this.dateTimePickerOrderDate = new System.Windows.Forms.DateTimePicker();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.lblOrderId = new MaterialSkin.Controls.MaterialLabel();
            this.lblCustomerlbl = new MaterialSkin.Controls.MaterialLabel();
            this.btnClearOrderList = new MaterialSkin.Controls.MaterialButton();
            this.dataGridViewOrderList = new System.Windows.Forms.DataGridView();
            this.ColumnProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddOns = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxPayment = new System.Windows.Forms.GroupBox();
            this.numericUpDownPaymenAmount = new System.Windows.Forms.NumericUpDown();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.cmbOrderStatus = new MaterialSkin.Controls.MaterialComboBox();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
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
            this.dgvDraftOrders = new System.Windows.Forms.DataGridView();
            this.panelSeparator = new System.Windows.Forms.Panel();
            this.materialCard1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.panelCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderList)).BeginInit();
            this.groupBoxPayment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPaymenAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDraftOrders)).BeginInit();
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
            this.materialCard1.Controls.Add(this.dgvDraftOrders);
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
            this.panelSearch.Controls.Add(this.btnViewDraftOrders);
            this.panelSearch.Controls.Add(this.btnGoToOrderQueue);
            this.panelSearch.Controls.Add(this.txtBoxSearchVariant);
            this.panelSearch.Location = new System.Drawing.Point(216, 60);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(698, 56);
            this.panelSearch.TabIndex = 5;
            // 
            // btnViewDraftOrders
            // 
            this.btnViewDraftOrders.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnViewDraftOrders.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnViewDraftOrders.Depth = 0;
            this.btnViewDraftOrders.HighEmphasis = true;
            this.btnViewDraftOrders.Icon = null;
            this.btnViewDraftOrders.Location = new System.Drawing.Point(376, 8);
            this.btnViewDraftOrders.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnViewDraftOrders.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnViewDraftOrders.Name = "btnViewDraftOrders";
            this.btnViewDraftOrders.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnViewDraftOrders.Size = new System.Drawing.Size(165, 36);
            this.btnViewDraftOrders.TabIndex = 98;
            this.btnViewDraftOrders.Text = "View Draft Orders";
            this.btnViewDraftOrders.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnViewDraftOrders.UseAccentColor = true;
            this.btnViewDraftOrders.UseVisualStyleBackColor = true;
            this.btnViewDraftOrders.Click += new System.EventHandler(this.btnViewDraftOrders_Click);
            // 
            // btnGoToOrderQueue
            // 
            this.btnGoToOrderQueue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGoToOrderQueue.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnGoToOrderQueue.Depth = 0;
            this.btnGoToOrderQueue.HighEmphasis = true;
            this.btnGoToOrderQueue.Icon = null;
            this.btnGoToOrderQueue.Location = new System.Drawing.Point(560, 8);
            this.btnGoToOrderQueue.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnGoToOrderQueue.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGoToOrderQueue.Name = "btnGoToOrderQueue";
            this.btnGoToOrderQueue.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnGoToOrderQueue.Size = new System.Drawing.Size(118, 36);
            this.btnGoToOrderQueue.TabIndex = 97;
            this.btnGoToOrderQueue.Text = "Order Queue";
            this.btnGoToOrderQueue.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnGoToOrderQueue.UseAccentColor = false;
            this.btnGoToOrderQueue.UseVisualStyleBackColor = true;
            this.btnGoToOrderQueue.Click += new System.EventHandler(this.btnGoToOrderQueue_Click);
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
            this.panelCart.Controls.Add(this.txtCustomer);
            this.panelCart.Controls.Add(this.materialLabel6);
            this.panelCart.Controls.Add(this.lblChange);
            this.panelCart.Controls.Add(this.buttonNow);
            this.panelCart.Controls.Add(this.dateTimePickerOrderDate);
            this.panelCart.Controls.Add(this.materialLabel1);
            this.panelCart.Controls.Add(this.lblOrderId);
            this.panelCart.Controls.Add(this.lblCustomerlbl);
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
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(96, 40);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(136, 20);
            this.txtCustomer.TabIndex = 108;
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel6.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.materialLabel6.Location = new System.Drawing.Point(16, 648);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(74, 24);
            this.materialLabel6.TabIndex = 106;
            this.materialLabel6.Text = "Change:";
            // 
            // lblChange
            // 
            this.lblChange.Depth = 0;
            this.lblChange.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblChange.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.lblChange.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblChange.Location = new System.Drawing.Point(144, 648);
            this.lblChange.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(293, 29);
            this.lblChange.TabIndex = 107;
            this.lblChange.Text = "P 100";
            this.lblChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonNow
            // 
            this.buttonNow.Location = new System.Drawing.Point(224, 72);
            this.buttonNow.Name = "buttonNow";
            this.buttonNow.Size = new System.Drawing.Size(75, 24);
            this.buttonNow.TabIndex = 105;
            this.buttonNow.Text = "Now";
            this.buttonNow.UseVisualStyleBackColor = true;
            this.buttonNow.Click += new System.EventHandler(this.buttonNow_Click);
            // 
            // dateTimePickerOrderDate
            // 
            this.dateTimePickerOrderDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerOrderDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimePickerOrderDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerOrderDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateTimePickerOrderDate.Location = new System.Drawing.Point(16, 72);
            this.dateTimePickerOrderDate.Name = "dateTimePickerOrderDate";
            this.dateTimePickerOrderDate.ShowUpDown = true;
            this.dateTimePickerOrderDate.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerOrderDate.TabIndex = 104;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel1.Location = new System.Drawing.Point(20, 8);
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
            this.lblOrderId.Location = new System.Drawing.Point(384, 8);
            this.lblOrderId.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblOrderId.Name = "lblOrderId";
            this.lblOrderId.Size = new System.Drawing.Size(47, 19);
            this.lblOrderId.TabIndex = 101;
            this.lblOrderId.Text = "#1234";
            // 
            // lblCustomerlbl
            // 
            this.lblCustomerlbl.AutoSize = true;
            this.lblCustomerlbl.Depth = 0;
            this.lblCustomerlbl.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblCustomerlbl.Location = new System.Drawing.Point(20, 40);
            this.lblCustomerlbl.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCustomerlbl.Name = "lblCustomerlbl";
            this.lblCustomerlbl.Size = new System.Drawing.Size(73, 19);
            this.lblCustomerlbl.TabIndex = 101;
            this.lblCustomerlbl.Text = "Customer:";
            // 
            // btnClearOrderList
            // 
            this.btnClearOrderList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClearOrderList.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClearOrderList.Depth = 0;
            this.btnClearOrderList.HighEmphasis = true;
            this.btnClearOrderList.Icon = null;
            this.btnClearOrderList.Location = new System.Drawing.Point(364, 32);
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
            this.dataGridViewOrderList.Location = new System.Drawing.Point(10, 104);
            this.dataGridViewOrderList.MultiSelect = false;
            this.dataGridViewOrderList.Name = "dataGridViewOrderList";
            this.dataGridViewOrderList.ReadOnly = true;
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
            this.dataGridViewOrderList.Size = new System.Drawing.Size(430, 264);
            this.dataGridViewOrderList.TabIndex = 100;
            // 
            // ColumnProduct
            // 
            this.ColumnProduct.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnProduct.HeaderText = "Product Name";
            this.ColumnProduct.Name = "ColumnProduct";
            this.ColumnProduct.ReadOnly = true;
            // 
            // Size
            // 
            this.Size.HeaderText = "Size";
            this.Size.Name = "Size";
            this.Size.ReadOnly = true;
            this.Size.Width = 65;
            // 
            // AddOns
            // 
            this.AddOns.HeaderText = "AddOns";
            this.AddOns.Name = "AddOns";
            this.AddOns.ReadOnly = true;
            // 
            // ColumnQty
            // 
            this.ColumnQty.HeaderText = "Qty";
            this.ColumnQty.Name = "ColumnQty";
            this.ColumnQty.ReadOnly = true;
            this.ColumnQty.Width = 50;
            // 
            // ColumnPrice
            // 
            this.ColumnPrice.HeaderText = "Price";
            this.ColumnPrice.Name = "ColumnPrice";
            this.ColumnPrice.ReadOnly = true;
            this.ColumnPrice.Width = 75;
            // 
            // groupBoxPayment
            // 
            this.groupBoxPayment.Controls.Add(this.numericUpDownPaymenAmount);
            this.groupBoxPayment.Controls.Add(this.materialLabel2);
            this.groupBoxPayment.Controls.Add(this.cmbOrderStatus);
            this.groupBoxPayment.Controls.Add(this.materialLabel4);
            this.groupBoxPayment.Controls.Add(this.cmbPaymentStatus);
            this.groupBoxPayment.Controls.Add(this.lblPaymentStatus);
            this.groupBoxPayment.Controls.Add(this.cmbPaymentMethod);
            this.groupBoxPayment.Controls.Add(this.lblPaymentMethod);
            this.groupBoxPayment.Location = new System.Drawing.Point(8, 368);
            this.groupBoxPayment.Name = "groupBoxPayment";
            this.groupBoxPayment.Size = new System.Drawing.Size(430, 211);
            this.groupBoxPayment.TabIndex = 103;
            this.groupBoxPayment.TabStop = false;
            this.groupBoxPayment.Text = "Payment";
            // 
            // numericUpDownPaymenAmount
            // 
            this.numericUpDownPaymenAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownPaymenAmount.Location = new System.Drawing.Point(162, 166);
            this.numericUpDownPaymenAmount.Name = "numericUpDownPaymenAmount";
            this.numericUpDownPaymenAmount.Size = new System.Drawing.Size(250, 31);
            this.numericUpDownPaymenAmount.TabIndex = 109;
            this.numericUpDownPaymenAmount.ValueChanged += new System.EventHandler(this.numericUpDownPaymenAmount_ValueChanged);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(22, 166);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(123, 19);
            this.materialLabel2.TabIndex = 108;
            this.materialLabel2.Text = "Payment amount";
            // 
            // cmbOrderStatus
            // 
            this.cmbOrderStatus.AutoResize = false;
            this.cmbOrderStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbOrderStatus.Depth = 0;
            this.cmbOrderStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbOrderStatus.DropDownHeight = 174;
            this.cmbOrderStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrderStatus.DropDownWidth = 121;
            this.cmbOrderStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbOrderStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbOrderStatus.FormattingEnabled = true;
            this.cmbOrderStatus.Hint = "Choose order status";
            this.cmbOrderStatus.IntegralHeight = false;
            this.cmbOrderStatus.ItemHeight = 43;
            this.cmbOrderStatus.Items.AddRange(new object[] {
            "New",
            "Processing",
            "Completed",
            "Cancelled"});
            this.cmbOrderStatus.Location = new System.Drawing.Point(162, 114);
            this.cmbOrderStatus.MaxDropDownItems = 4;
            this.cmbOrderStatus.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbOrderStatus.Name = "cmbOrderStatus";
            this.cmbOrderStatus.Size = new System.Drawing.Size(250, 49);
            this.cmbOrderStatus.StartIndex = 0;
            this.cmbOrderStatus.TabIndex = 107;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.Location = new System.Drawing.Point(22, 124);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(89, 19);
            this.materialLabel4.TabIndex = 106;
            this.materialLabel4.Text = "Order Status";
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
            this.cmbPaymentStatus.Location = new System.Drawing.Point(162, 66);
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
            this.lblPaymentStatus.Location = new System.Drawing.Point(22, 76);
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
            this.cmbPaymentMethod.Location = new System.Drawing.Point(162, 16);
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
            this.lblPaymentMethod.Location = new System.Drawing.Point(22, 26);
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
            this.lblTotalItems.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTotalItems.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.lblTotalItems.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotalItems.Location = new System.Drawing.Point(16, 584);
            this.lblTotalItems.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTotalItems.Name = "lblTotalItems";
            this.lblTotalItems.Size = new System.Drawing.Size(108, 24);
            this.lblTotalItems.TabIndex = 102;
            this.lblTotalItems.Text = "Total Items:";
            // 
            // lblTotalItemInOrderList
            // 
            this.lblTotalItemInOrderList.Depth = 0;
            this.lblTotalItemInOrderList.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTotalItemInOrderList.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.lblTotalItemInOrderList.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotalItemInOrderList.Location = new System.Drawing.Point(144, 584);
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
            this.materialLabel3.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.materialLabel3.Location = new System.Drawing.Point(16, 616);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(103, 24);
            this.materialLabel3.TabIndex = 102;
            this.materialLabel3.Text = "Total Price:";
            // 
            // lblTotalInOrderList
            // 
            this.lblTotalInOrderList.Depth = 0;
            this.lblTotalInOrderList.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTotalInOrderList.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.lblTotalInOrderList.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotalInOrderList.Location = new System.Drawing.Point(144, 616);
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
            this.btnSaveToDraft.Location = new System.Drawing.Point(256, 688);
            this.btnSaveToDraft.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSaveToDraft.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSaveToDraft.Name = "btnSaveToDraft";
            this.btnSaveToDraft.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSaveToDraft.Size = new System.Drawing.Size(90, 36);
            this.btnSaveToDraft.TabIndex = 96;
            this.btnSaveToDraft.Text = "To Draft";
            this.btnSaveToDraft.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSaveToDraft.UseAccentColor = true;
            this.btnSaveToDraft.UseVisualStyleBackColor = true;
            this.btnSaveToDraft.Click += new System.EventHandler(this.btnSaveDraft_Click);
            // 
            // btnConfirmOrder
            // 
            this.btnConfirmOrder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnConfirmOrder.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnConfirmOrder.Depth = 0;
            this.btnConfirmOrder.HighEmphasis = true;
            this.btnConfirmOrder.Icon = null;
            this.btnConfirmOrder.Location = new System.Drawing.Point(354, 688);
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
            // dgvDraftOrders
            // 
            this.dgvDraftOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDraftOrders.Location = new System.Drawing.Point(224, 128);
            this.dgvDraftOrders.Name = "dgvDraftOrders";
            this.dgvDraftOrders.Size = new System.Drawing.Size(680, 616);
            this.dgvDraftOrders.TabIndex = 0;
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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPaymenAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDraftOrders)).EndInit();
            this.ResumeLayout(false);

            }



            #endregion



            private MaterialSkin.Controls.MaterialCard materialCard1;

            private System.Windows.Forms.Panel panelCart;

            private MaterialSkin.Controls.MaterialLabel lblTotalInOrderList;

            private MaterialSkin.Controls.MaterialLabel lblOrderId;

            private MaterialSkin.Controls.MaterialLabel lblCustomerlbl;

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
            private MaterialSkin.Controls.MaterialComboBox cmbOrderStatus;
            private MaterialSkin.Controls.MaterialLabel materialLabel4;
            private MaterialSkin.Controls.MaterialButton btnGoToOrderQueue;
        private MaterialSkin.Controls.MaterialButton btnViewDraftOrders;
        private DataGridView dgvDraftOrders;
        private Button buttonNow;
        private DateTimePicker dateTimePickerOrderDate;
        private NumericUpDown numericUpDownPaymenAmount;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel lblChange;
        private TextBox txtCustomer;


        // ... other controls ...
    }

    }