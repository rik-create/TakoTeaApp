namespace TakoTea.View.Product.Product_Modals
{
    partial class AddComboMealModal
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
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRemoveImage = new System.Windows.Forms.Button();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.pbComboMealImage = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanelDgViews = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTopButtons = new System.Windows.Forms.Panel();
            this.textBoxSearchVariants = new System.Windows.Forms.TextBox();
            this.pbSearch = new System.Windows.Forms.PictureBox();
            this.numericUpDownVariantQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnChooseProductVariant = new MaterialSkin.Controls.MaterialButton();
            this.buttonCloseIngredientsList = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnAddVariantToDgView = new System.Windows.Forms.Button();
            this.listViewProductVariants = new System.Windows.Forms.ListView();
            this.dgViewAddComboMeal = new System.Windows.Forms.DataGridView();
            this.VariantID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnVarName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDiscountedPrice = new MaterialSkin.Controls.MaterialLabel();
            this.lblBasePrice = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.numericUpDownDiscountPercent = new System.Windows.Forms.NumericUpDown();
            this.txtBoxComboMealName = new MaterialSkin.Controls.MaterialTextBox2();
            this.btnDuplicateRow = new System.Windows.Forms.Button();
            this.btnDeleteRow = new System.Windows.Forms.Button();
            this.btnAddNewVariant = new System.Windows.Forms.Button();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.materialButton5 = new MaterialSkin.Controls.MaterialButton();
            this.lblTotalVariantsInDg = new MaterialSkin.Controls.MaterialLabel();
            this.btnSaveCombomeal = new MaterialSkin.Controls.MaterialButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHeader = new MaterialSkin.Controls.MaterialLabel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialCard1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbComboMealImage)).BeginInit();
            this.flowLayoutPanelDgViews.SuspendLayout();
            this.pnlTopButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVariantQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewAddComboMeal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDiscountPercent)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.panel3);
            this.materialCard1.Controls.Add(this.panel2);
            this.materialCard1.Controls.Add(this.panel1);
            this.materialCard1.Depth = 0;
            this.materialCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(3, 24);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(922, 761);
            this.materialCard1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnRemoveImage);
            this.panel3.Controls.Add(this.btnAddImage);
            this.panel3.Controls.Add(this.pbComboMealImage);
            this.panel3.Controls.Add(this.flowLayoutPanelDgViews);
            this.panel3.Controls.Add(this.lblDiscountedPrice);
            this.panel3.Controls.Add(this.lblBasePrice);
            this.panel3.Controls.Add(this.materialLabel7);
            this.panel3.Controls.Add(this.numericUpDownDiscountPercent);
            this.panel3.Controls.Add(this.txtBoxComboMealName);
            this.panel3.Controls.Add(this.btnDuplicateRow);
            this.panel3.Controls.Add(this.btnDeleteRow);
            this.panel3.Controls.Add(this.btnAddNewVariant);
            this.panel3.Controls.Add(this.materialLabel1);
            this.panel3.Controls.Add(this.materialLabel3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(14, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(894, 639);
            this.panel3.TabIndex = 109;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // btnRemoveImage
            // 
            this.btnRemoveImage.Location = new System.Drawing.Point(344, 600);
            this.btnRemoveImage.Name = "btnRemoveImage";
            this.btnRemoveImage.Size = new System.Drawing.Size(40, 23);
            this.btnRemoveImage.TabIndex = 128;
            this.btnRemoveImage.Text = "X";
            this.btnRemoveImage.UseVisualStyleBackColor = true;
            this.btnRemoveImage.Click += new System.EventHandler(this.btnRemoveImage_Click);
            // 
            // btnAddImage
            // 
            this.btnAddImage.Location = new System.Drawing.Point(296, 600);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(48, 23);
            this.btnAddImage.TabIndex = 127;
            this.btnAddImage.Text = "Add";
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // pbComboMealImage
            // 
            this.pbComboMealImage.Image = global::TakoTea.Views.Properties.Resources.takoyaki;
            this.pbComboMealImage.Location = new System.Drawing.Point(296, 520);
            this.pbComboMealImage.Name = "pbComboMealImage";
            this.pbComboMealImage.Size = new System.Drawing.Size(88, 80);
            this.pbComboMealImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbComboMealImage.TabIndex = 126;
            this.pbComboMealImage.TabStop = false;
            // 
            // flowLayoutPanelDgViews
            // 
            this.flowLayoutPanelDgViews.AutoScroll = true;
            this.flowLayoutPanelDgViews.Controls.Add(this.pnlTopButtons);
            this.flowLayoutPanelDgViews.Controls.Add(this.listViewProductVariants);
            this.flowLayoutPanelDgViews.Controls.Add(this.dgViewAddComboMeal);
            this.flowLayoutPanelDgViews.Location = new System.Drawing.Point(8, 8);
            this.flowLayoutPanelDgViews.Name = "flowLayoutPanelDgViews";
            this.flowLayoutPanelDgViews.Size = new System.Drawing.Size(872, 445);
            this.flowLayoutPanelDgViews.TabIndex = 125;
            // 
            // pnlTopButtons
            // 
            this.pnlTopButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTopButtons.Controls.Add(this.textBoxSearchVariants);
            this.pnlTopButtons.Controls.Add(this.pbSearch);
            this.pnlTopButtons.Controls.Add(this.numericUpDownVariantQuantity);
            this.pnlTopButtons.Controls.Add(this.btnChooseProductVariant);
            this.pnlTopButtons.Controls.Add(this.buttonCloseIngredientsList);
            this.pnlTopButtons.Controls.Add(this.btnUndo);
            this.pnlTopButtons.Controls.Add(this.btnAddVariantToDgView);
            this.pnlTopButtons.Location = new System.Drawing.Point(3, 3);
            this.pnlTopButtons.Name = "pnlTopButtons";
            this.pnlTopButtons.Size = new System.Drawing.Size(845, 55);
            this.pnlTopButtons.TabIndex = 0;
            // 
            // textBoxSearchVariants
            // 
            this.textBoxSearchVariants.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearchVariants.Location = new System.Drawing.Point(16, 16);
            this.textBoxSearchVariants.Name = "textBoxSearchVariants";
            this.textBoxSearchVariants.Size = new System.Drawing.Size(100, 22);
            this.textBoxSearchVariants.TabIndex = 105;
            this.textBoxSearchVariants.Visible = false;
            this.textBoxSearchVariants.TextChanged += new System.EventHandler(this.textBoxSearchVariants_TextChanged);
            // 
            // pbSearch
            // 
            this.pbSearch.Image = global::TakoTea.Views.Properties.Resources.search;
            this.pbSearch.Location = new System.Drawing.Point(120, 16);
            this.pbSearch.Name = "pbSearch";
            this.pbSearch.Size = new System.Drawing.Size(24, 24);
            this.pbSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSearch.TabIndex = 104;
            this.pbSearch.TabStop = false;
            this.pbSearch.Visible = false;
            this.pbSearch.Click += new System.EventHandler(this.pbSearch_Click);
            // 
            // numericUpDownVariantQuantity
            // 
            this.numericUpDownVariantQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownVariantQuantity.Location = new System.Drawing.Point(384, 16);
            this.numericUpDownVariantQuantity.Maximum = new decimal(new int[] {
            5000000,
            0,
            0,
            0});
            this.numericUpDownVariantQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownVariantQuantity.Name = "numericUpDownVariantQuantity";
            this.numericUpDownVariantQuantity.Size = new System.Drawing.Size(120, 26);
            this.numericUpDownVariantQuantity.TabIndex = 91;
            this.numericUpDownVariantQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownVariantQuantity.Visible = false;
            // 
            // btnChooseProductVariant
            // 
            this.btnChooseProductVariant.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnChooseProductVariant.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnChooseProductVariant.Depth = 0;
            this.btnChooseProductVariant.HighEmphasis = true;
            this.btnChooseProductVariant.Icon = null;
            this.btnChooseProductVariant.Location = new System.Drawing.Point(688, 8);
            this.btnChooseProductVariant.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnChooseProductVariant.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnChooseProductVariant.Name = "btnChooseProductVariant";
            this.btnChooseProductVariant.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnChooseProductVariant.Size = new System.Drawing.Size(144, 36);
            this.btnChooseProductVariant.TabIndex = 90;
            this.btnChooseProductVariant.Text = "Choose Variant";
            this.btnChooseProductVariant.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnChooseProductVariant.UseAccentColor = true;
            this.btnChooseProductVariant.UseVisualStyleBackColor = true;
            this.btnChooseProductVariant.Click += new System.EventHandler(this.btnChooseProductVariant_Click);
            // 
            // buttonCloseIngredientsList
            // 
            this.buttonCloseIngredientsList.Location = new System.Drawing.Point(752, 16);
            this.buttonCloseIngredientsList.Name = "buttonCloseIngredientsList";
            this.buttonCloseIngredientsList.Size = new System.Drawing.Size(75, 23);
            this.buttonCloseIngredientsList.TabIndex = 102;
            this.buttonCloseIngredientsList.Text = "Close";
            this.buttonCloseIngredientsList.UseVisualStyleBackColor = true;
            this.buttonCloseIngredientsList.Visible = false;
            this.buttonCloseIngredientsList.Click += new System.EventHandler(this.buttonCloseIngredientsList_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Location = new System.Drawing.Point(592, 16);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(75, 23);
            this.btnUndo.TabIndex = 102;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Visible = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnAddVariantToDgView
            // 
            this.btnAddVariantToDgView.Location = new System.Drawing.Point(512, 16);
            this.btnAddVariantToDgView.Name = "btnAddVariantToDgView";
            this.btnAddVariantToDgView.Size = new System.Drawing.Size(75, 23);
            this.btnAddVariantToDgView.TabIndex = 102;
            this.btnAddVariantToDgView.Text = "Add";
            this.btnAddVariantToDgView.UseVisualStyleBackColor = true;
            this.btnAddVariantToDgView.Visible = false;
            this.btnAddVariantToDgView.Click += new System.EventHandler(this.btnAddSelectedVariants_Click);
            // 
            // listViewProductVariants
            // 
            this.listViewProductVariants.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewProductVariants.FullRowSelect = true;
            this.listViewProductVariants.GridLines = true;
            this.listViewProductVariants.HideSelection = false;
            this.listViewProductVariants.Location = new System.Drawing.Point(3, 64);
            this.listViewProductVariants.Name = "listViewProductVariants";
            this.listViewProductVariants.Size = new System.Drawing.Size(845, 346);
            this.listViewProductVariants.TabIndex = 1;
            this.listViewProductVariants.UseCompatibleStateImageBehavior = false;
            this.listViewProductVariants.View = System.Windows.Forms.View.Details;
            this.listViewProductVariants.Visible = false;
            // 
            // dgViewAddComboMeal
            // 
            this.dgViewAddComboMeal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgViewAddComboMeal.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgViewAddComboMeal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgViewAddComboMeal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewAddComboMeal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VariantID,
            this.ColumnVarName,
            this.ColumnSize,
            this.ColumnPrice,
            this.Quantity});
            this.dgViewAddComboMeal.EnableHeadersVisualStyles = false;
            this.dgViewAddComboMeal.Location = new System.Drawing.Point(3, 416);
            this.dgViewAddComboMeal.Name = "dgViewAddComboMeal";
            this.dgViewAddComboMeal.Size = new System.Drawing.Size(845, 517);
            this.dgViewAddComboMeal.TabIndex = 114;
            // 
            // VariantID
            // 
            this.VariantID.HeaderText = "ID";
            this.VariantID.Name = "VariantID";
            this.VariantID.Visible = false;
            // 
            // ColumnVarName
            // 
            this.ColumnVarName.HeaderText = "Variant Name";
            this.ColumnVarName.Name = "ColumnVarName";
            // 
            // ColumnSize
            // 
            this.ColumnSize.FillWeight = 70F;
            this.ColumnSize.HeaderText = "Size";
            this.ColumnSize.Name = "ColumnSize";
            // 
            // ColumnPrice
            // 
            this.ColumnPrice.FillWeight = 70F;
            this.ColumnPrice.HeaderText = "Price";
            this.ColumnPrice.Name = "ColumnPrice";
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            // 
            // lblDiscountedPrice
            // 
            this.lblDiscountedPrice.AutoSize = true;
            this.lblDiscountedPrice.Depth = 0;
            this.lblDiscountedPrice.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblDiscountedPrice.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.lblDiscountedPrice.Location = new System.Drawing.Point(464, 592);
            this.lblDiscountedPrice.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDiscountedPrice.Name = "lblDiscountedPrice";
            this.lblDiscountedPrice.Size = new System.Drawing.Size(162, 24);
            this.lblDiscountedPrice.TabIndex = 124;
            this.lblDiscountedPrice.Text = "Discounted Price: ";
            this.lblDiscountedPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBasePrice
            // 
            this.lblBasePrice.AutoSize = true;
            this.lblBasePrice.Depth = 0;
            this.lblBasePrice.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblBasePrice.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.lblBasePrice.Location = new System.Drawing.Point(464, 560);
            this.lblBasePrice.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblBasePrice.Name = "lblBasePrice";
            this.lblBasePrice.Size = new System.Drawing.Size(107, 24);
            this.lblBasePrice.TabIndex = 124;
            this.lblBasePrice.Text = "Base Price: ";
            this.lblBasePrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel7.Location = new System.Drawing.Point(464, 496);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(91, 19);
            this.materialLabel7.TabIndex = 120;
            this.materialLabel7.Text = "Discount (%)";
            // 
            // numericUpDownDiscountPercent
            // 
            this.numericUpDownDiscountPercent.DecimalPlaces = 1;
            this.numericUpDownDiscountPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownDiscountPercent.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownDiscountPercent.Location = new System.Drawing.Point(464, 520);
            this.numericUpDownDiscountPercent.Name = "numericUpDownDiscountPercent";
            this.numericUpDownDiscountPercent.Size = new System.Drawing.Size(120, 29);
            this.numericUpDownDiscountPercent.TabIndex = 119;
            this.numericUpDownDiscountPercent.ValueChanged += new System.EventHandler(this.numericUpDownDiscountPercent_ValueChanged_1);
            // 
            // txtBoxComboMealName
            // 
            this.txtBoxComboMealName.AnimateReadOnly = false;
            this.txtBoxComboMealName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtBoxComboMealName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBoxComboMealName.Depth = 0;
            this.txtBoxComboMealName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtBoxComboMealName.HideSelection = true;
            this.txtBoxComboMealName.Hint = "Enter Combo Meal Name";
            this.txtBoxComboMealName.LeadingIcon = null;
            this.txtBoxComboMealName.Location = new System.Drawing.Point(16, 520);
            this.txtBoxComboMealName.MaxLength = 32767;
            this.txtBoxComboMealName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtBoxComboMealName.Name = "txtBoxComboMealName";
            this.txtBoxComboMealName.PasswordChar = '\0';
            this.txtBoxComboMealName.PrefixSuffixText = null;
            this.txtBoxComboMealName.ReadOnly = false;
            this.txtBoxComboMealName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBoxComboMealName.SelectedText = "";
            this.txtBoxComboMealName.SelectionLength = 0;
            this.txtBoxComboMealName.SelectionStart = 0;
            this.txtBoxComboMealName.ShortcutsEnabled = true;
            this.txtBoxComboMealName.Size = new System.Drawing.Size(250, 48);
            this.txtBoxComboMealName.TabIndex = 118;
            this.txtBoxComboMealName.TabStop = false;
            this.txtBoxComboMealName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBoxComboMealName.TrailingIcon = null;
            this.txtBoxComboMealName.UseSystemPasswordChar = false;
            this.txtBoxComboMealName.Click += new System.EventHandler(this.txtBoxComboMealName_Click);
            // 
            // btnDuplicateRow
            // 
            this.btnDuplicateRow.Location = new System.Drawing.Point(568, 120);
            this.btnDuplicateRow.Name = "btnDuplicateRow";
            this.btnDuplicateRow.Size = new System.Drawing.Size(75, 23);
            this.btnDuplicateRow.TabIndex = 116;
            this.btnDuplicateRow.Text = "Duplicate";
            this.btnDuplicateRow.UseVisualStyleBackColor = true;
            this.btnDuplicateRow.Click += new System.EventHandler(this.btnDuplicateRow_Click);
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.Location = new System.Drawing.Point(784, 496);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteRow.TabIndex = 117;
            this.btnDeleteRow.Text = "Delete";
            this.btnDeleteRow.UseVisualStyleBackColor = true;
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            // 
            // btnAddNewVariant
            // 
            this.btnAddNewVariant.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.btnAddNewVariant.Location = new System.Drawing.Point(656, 119);
            this.btnAddNewVariant.Name = "btnAddNewVariant";
            this.btnAddNewVariant.Size = new System.Drawing.Size(75, 23);
            this.btnAddNewVariant.TabIndex = 115;
            this.btnAddNewVariant.Text = "Add New";
            this.btnAddNewVariant.UseVisualStyleBackColor = true;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(288, 496);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(139, 19);
            this.materialLabel1.TabIndex = 109;
            this.materialLabel1.Text = "Combo Meal Image";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(16, 498);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(137, 19);
            this.materialLabel3.TabIndex = 109;
            this.materialLabel3.Text = "Combo Meal Name";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.materialButton5);
            this.panel2.Controls.Add(this.lblTotalVariantsInDg);
            this.panel2.Controls.Add(this.btnSaveCombomeal);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(14, 699);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(894, 48);
            this.panel2.TabIndex = 108;
            // 
            // materialButton5
            // 
            this.materialButton5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton5.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton5.Depth = 0;
            this.materialButton5.HighEmphasis = true;
            this.materialButton5.Icon = null;
            this.materialButton5.Location = new System.Drawing.Point(632, 8);
            this.materialButton5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton5.Name = "materialButton5";
            this.materialButton5.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton5.Size = new System.Drawing.Size(77, 36);
            this.materialButton5.TabIndex = 91;
            this.materialButton5.Text = "Cancel";
            this.materialButton5.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton5.UseAccentColor = false;
            this.materialButton5.UseVisualStyleBackColor = true;
            // 
            // lblTotalVariantsInDg
            // 
            this.lblTotalVariantsInDg.AutoSize = true;
            this.lblTotalVariantsInDg.Depth = 0;
            this.lblTotalVariantsInDg.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTotalVariantsInDg.FontType = MaterialSkin.MaterialSkinManager.fontType.Button;
            this.lblTotalVariantsInDg.Location = new System.Drawing.Point(16, 16);
            this.lblTotalVariantsInDg.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTotalVariantsInDg.Name = "lblTotalVariantsInDg";
            this.lblTotalVariantsInDg.Size = new System.Drawing.Size(107, 17);
            this.lblTotalVariantsInDg.TabIndex = 123;
            this.lblTotalVariantsInDg.Text = "Total Variants: 5";
            // 
            // btnSaveCombomeal
            // 
            this.btnSaveCombomeal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSaveCombomeal.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSaveCombomeal.Depth = 0;
            this.btnSaveCombomeal.HighEmphasis = true;
            this.btnSaveCombomeal.Icon = null;
            this.btnSaveCombomeal.Location = new System.Drawing.Point(720, 8);
            this.btnSaveCombomeal.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSaveCombomeal.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSaveCombomeal.Name = "btnSaveCombomeal";
            this.btnSaveCombomeal.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSaveCombomeal.Size = new System.Drawing.Size(156, 36);
            this.btnSaveCombomeal.TabIndex = 90;
            this.btnSaveCombomeal.Text = "Save Combo Meal";
            this.btnSaveCombomeal.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSaveCombomeal.UseAccentColor = false;
            this.btnSaveCombomeal.UseVisualStyleBackColor = true;
            this.btnSaveCombomeal.Click += new System.EventHandler(this.btnSaveCombomeal_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(14, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(894, 46);
            this.panel1.TabIndex = 100;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Depth = 0;
            this.lblHeader.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblHeader.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.lblHeader.Location = new System.Drawing.Point(369, 10);
            this.lblHeader.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(154, 24);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Add Combo Meal";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Variant Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 133;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 70F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Size";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 93;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.FillWeight = 70F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Price";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 93;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Ingredients";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 132;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Instructions";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 133;
            // 
            // AddComboMealModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 788);
            this.Controls.Add(this.materialCard1);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.Name = "AddComboMealModal";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.Text = "Add Product";
            this.Load += new System.EventHandler(this.AddComboMealModal_Load);
            this.materialCard1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbComboMealImage)).EndInit();
            this.flowLayoutPanelDgViews.ResumeLayout(false);
            this.pnlTopButtons.ResumeLayout(false);
            this.pnlTopButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVariantQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewAddComboMeal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDiscountPercent)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialLabel lblHeader;
        protected MaterialSkin.Controls.MaterialButton materialButton5;
        protected MaterialSkin.Controls.MaterialButton btnSaveCombomeal;
        private System.Windows.Forms.Panel panel3;
        protected MaterialSkin.Controls.MaterialLabel materialLabel7;
        private System.Windows.Forms.NumericUpDown numericUpDownDiscountPercent;
        private MaterialSkin.Controls.MaterialTextBox2 txtBoxComboMealName;
        private System.Windows.Forms.Button btnDuplicateRow;
        private System.Windows.Forms.Button btnDeleteRow;
        private System.Windows.Forms.Button btnAddNewVariant;
        private System.Windows.Forms.DataGridView dgViewAddComboMeal;
        protected MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel lblDiscountedPrice;
        private MaterialSkin.Controls.MaterialLabel lblBasePrice;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelDgViews;
        private System.Windows.Forms.Panel pnlTopButtons;
        private System.Windows.Forms.TextBox textBoxSearchVariants;
        private System.Windows.Forms.PictureBox pbSearch;
        protected MaterialSkin.Controls.MaterialButton btnChooseProductVariant;
        private System.Windows.Forms.Button buttonCloseIngredientsList;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnAddVariantToDgView;
        private System.Windows.Forms.ListView listViewProductVariants;
        private System.Windows.Forms.NumericUpDown numericUpDownVariantQuantity;
        private MaterialSkin.Controls.MaterialLabel lblTotalVariantsInDg;
        private System.Windows.Forms.PictureBox pbComboMealImage;
        protected MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRemoveImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn VariantID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnVarName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
    }
}