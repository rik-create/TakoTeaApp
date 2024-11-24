namespace TakoTea.View.Product.Product_Modals
{
    partial class AddProductModal
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
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonAddNewRow = new System.Windows.Forms.Button();
            this.btnDuplicateRow = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.btnSaveAll = new MaterialSkin.Controls.MaterialButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHeader = new MaterialSkin.Controls.MaterialLabel();
            this.flowLayoutPanelDgViews = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTopButtons = new System.Windows.Forms.Panel();
            this.textBoxSearchIngredients = new System.Windows.Forms.TextBox();
            this.numericUpDownIngredientsQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnUploadImgToSelectedRow = new MaterialSkin.Controls.MaterialButton();
            this.buttonCloseIngredientsList = new System.Windows.Forms.Button();
            this.btnUndoRecentlyAddedIngredients = new System.Windows.Forms.Button();
            this.btnAddIngredientsToDgView = new System.Windows.Forms.Button();
            this.listViewIngredients = new System.Windows.Forms.ListView();
            this.dgViewAddingMultipleProductVariants = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pbSearch = new System.Windows.Forms.PictureBox();
            this.VariantName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProduct = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIngredients = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInstructions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImagePathColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.Action = new System.Windows.Forms.DataGridViewButtonColumn();
            this.materialCard1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanelDgViews.SuspendLayout();
            this.pnlTopButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIngredientsQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewAddingMultipleProductVariants)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.panel2);
            this.materialCard1.Controls.Add(this.panel1);
            this.materialCard1.Controls.Add(this.flowLayoutPanelDgViews);
            this.materialCard1.Depth = 0;
            this.materialCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(3, 24);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(1054, 752);
            this.materialCard1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnSaveAll);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(14, 674);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1026, 64);
            this.panel2.TabIndex = 101;
            // 
            // buttonAddNewRow
            // 
            this.buttonAddNewRow.Location = new System.Drawing.Point(200, 16);
            this.buttonAddNewRow.Name = "buttonAddNewRow";
            this.buttonAddNewRow.Size = new System.Drawing.Size(75, 23);
            this.buttonAddNewRow.TabIndex = 105;
            this.buttonAddNewRow.Text = "Add New";
            this.buttonAddNewRow.UseVisualStyleBackColor = true;
            this.buttonAddNewRow.Click += new System.EventHandler(this.btnAddNewRow_Click);
            // 
            // btnDuplicateRow
            // 
            this.btnDuplicateRow.Location = new System.Drawing.Point(40, 16);
            this.btnDuplicateRow.Name = "btnDuplicateRow";
            this.btnDuplicateRow.Size = new System.Drawing.Size(75, 23);
            this.btnDuplicateRow.TabIndex = 103;
            this.btnDuplicateRow.Text = "Duplicate";
            this.btnDuplicateRow.UseVisualStyleBackColor = true;
            this.btnDuplicateRow.Click += new System.EventHandler(this.btnDuplicateRow_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(120, 16);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 104;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(760, 16);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(77, 36);
            this.btnCancel.TabIndex = 101;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancel.UseAccentColor = false;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSaveAll.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSaveAll.Depth = 0;
            this.btnSaveAll.HighEmphasis = true;
            this.btnSaveAll.Icon = null;
            this.btnSaveAll.Location = new System.Drawing.Point(856, 16);
            this.btnSaveAll.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSaveAll.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSaveAll.Size = new System.Drawing.Size(161, 36);
            this.btnSaveAll.TabIndex = 100;
            this.btnSaveAll.Text = "Save all variants";
            this.btnSaveAll.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSaveAll.UseAccentColor = false;
            this.btnSaveAll.UseVisualStyleBackColor = true;
            this.btnSaveAll.Click += new System.EventHandler(this.btnSaveAll_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(14, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1026, 46);
            this.panel1.TabIndex = 100;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblHeader
            // 
            this.lblHeader.Depth = 0;
            this.lblHeader.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblHeader.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.lblHeader.Location = new System.Drawing.Point(0, 10);
            this.lblHeader.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1024, 24);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Add Product Variant";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // flowLayoutPanelDgViews
            // 
            this.flowLayoutPanelDgViews.AutoScroll = true;
            this.flowLayoutPanelDgViews.Controls.Add(this.pnlTopButtons);
            this.flowLayoutPanelDgViews.Controls.Add(this.listViewIngredients);
            this.flowLayoutPanelDgViews.Controls.Add(this.dgViewAddingMultipleProductVariants);
            this.flowLayoutPanelDgViews.Location = new System.Drawing.Point(16, 64);
            this.flowLayoutPanelDgViews.Name = "flowLayoutPanelDgViews";
            this.flowLayoutPanelDgViews.Size = new System.Drawing.Size(1024, 608);
            this.flowLayoutPanelDgViews.TabIndex = 102;
            this.flowLayoutPanelDgViews.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelDgViews_Paint);
            // 
            // pnlTopButtons
            // 
            this.pnlTopButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTopButtons.Controls.Add(this.buttonAddNewRow);
            this.pnlTopButtons.Controls.Add(this.textBoxSearchIngredients);
            this.pnlTopButtons.Controls.Add(this.btnDuplicateRow);
            this.pnlTopButtons.Controls.Add(this.btnDelete);
            this.pnlTopButtons.Controls.Add(this.pbSearch);
            this.pnlTopButtons.Controls.Add(this.numericUpDownIngredientsQuantity);
            this.pnlTopButtons.Controls.Add(this.btnUploadImgToSelectedRow);
            this.pnlTopButtons.Controls.Add(this.buttonCloseIngredientsList);
            this.pnlTopButtons.Controls.Add(this.btnUndoRecentlyAddedIngredients);
            this.pnlTopButtons.Controls.Add(this.btnAddIngredientsToDgView);
            this.pnlTopButtons.Location = new System.Drawing.Point(3, 3);
            this.pnlTopButtons.Name = "pnlTopButtons";
            this.pnlTopButtons.Size = new System.Drawing.Size(997, 53);
            this.pnlTopButtons.TabIndex = 0;
            // 
            // textBoxSearchIngredients
            // 
            this.textBoxSearchIngredients.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearchIngredients.Location = new System.Drawing.Point(16, 16);
            this.textBoxSearchIngredients.Name = "textBoxSearchIngredients";
            this.textBoxSearchIngredients.Size = new System.Drawing.Size(100, 22);
            this.textBoxSearchIngredients.TabIndex = 105;
            this.textBoxSearchIngredients.Visible = false;
            this.textBoxSearchIngredients.TextChanged += new System.EventHandler(this.textBoxSearchIngredients_TextChanged);
            // 
            // numericUpDownIngredientsQuantity
            // 
            this.numericUpDownIngredientsQuantity.DecimalPlaces = 1;
            this.numericUpDownIngredientsQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownIngredientsQuantity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownIngredientsQuantity.Location = new System.Drawing.Point(384, 16);
            this.numericUpDownIngredientsQuantity.Maximum = new decimal(new int[] {
            5000000,
            0,
            0,
            0});
            this.numericUpDownIngredientsQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownIngredientsQuantity.Name = "numericUpDownIngredientsQuantity";
            this.numericUpDownIngredientsQuantity.Size = new System.Drawing.Size(120, 26);
            this.numericUpDownIngredientsQuantity.TabIndex = 91;
            this.numericUpDownIngredientsQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownIngredientsQuantity.Visible = false;
            // 
            // btnUploadImgToSelectedRow
            // 
            this.btnUploadImgToSelectedRow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUploadImgToSelectedRow.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnUploadImgToSelectedRow.Depth = 0;
            this.btnUploadImgToSelectedRow.HighEmphasis = true;
            this.btnUploadImgToSelectedRow.Icon = null;
            this.btnUploadImgToSelectedRow.Location = new System.Drawing.Point(848, 8);
            this.btnUploadImgToSelectedRow.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnUploadImgToSelectedRow.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnUploadImgToSelectedRow.Name = "btnUploadImgToSelectedRow";
            this.btnUploadImgToSelectedRow.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnUploadImgToSelectedRow.Size = new System.Drawing.Size(139, 36);
            this.btnUploadImgToSelectedRow.TabIndex = 90;
            this.btnUploadImgToSelectedRow.Text = "Upload image...";
            this.btnUploadImgToSelectedRow.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnUploadImgToSelectedRow.UseAccentColor = true;
            this.btnUploadImgToSelectedRow.UseVisualStyleBackColor = true;
            this.btnUploadImgToSelectedRow.Click += new System.EventHandler(this.btnUploadImgToSelectedRow_Click);
            // 
            // buttonCloseIngredientsList
            // 
            this.buttonCloseIngredientsList.Location = new System.Drawing.Point(912, 16);
            this.buttonCloseIngredientsList.Name = "buttonCloseIngredientsList";
            this.buttonCloseIngredientsList.Size = new System.Drawing.Size(75, 23);
            this.buttonCloseIngredientsList.TabIndex = 102;
            this.buttonCloseIngredientsList.Text = "Close";
            this.buttonCloseIngredientsList.UseVisualStyleBackColor = true;
            this.buttonCloseIngredientsList.Visible = false;
            this.buttonCloseIngredientsList.Click += new System.EventHandler(this.buttonCloseIngredientsList_Click);
            // 
            // btnUndoRecentlyAddedIngredients
            // 
            this.btnUndoRecentlyAddedIngredients.Location = new System.Drawing.Point(592, 16);
            this.btnUndoRecentlyAddedIngredients.Name = "btnUndoRecentlyAddedIngredients";
            this.btnUndoRecentlyAddedIngredients.Size = new System.Drawing.Size(75, 23);
            this.btnUndoRecentlyAddedIngredients.TabIndex = 102;
            this.btnUndoRecentlyAddedIngredients.Text = "Undo";
            this.btnUndoRecentlyAddedIngredients.UseVisualStyleBackColor = true;
            this.btnUndoRecentlyAddedIngredients.Visible = false;
            this.btnUndoRecentlyAddedIngredients.Click += new System.EventHandler(this.btnUndoRecentlyAddedIngredients_Click);
            // 
            // btnAddIngredientsToDgView
            // 
            this.btnAddIngredientsToDgView.Location = new System.Drawing.Point(512, 16);
            this.btnAddIngredientsToDgView.Name = "btnAddIngredientsToDgView";
            this.btnAddIngredientsToDgView.Size = new System.Drawing.Size(75, 23);
            this.btnAddIngredientsToDgView.TabIndex = 102;
            this.btnAddIngredientsToDgView.Text = "Add";
            this.btnAddIngredientsToDgView.UseVisualStyleBackColor = true;
            this.btnAddIngredientsToDgView.Visible = false;
            this.btnAddIngredientsToDgView.Click += new System.EventHandler(this.btnAddIngredientsToDgView_Click);
            // 
            // listViewIngredients
            // 
            this.listViewIngredients.FullRowSelect = true;
            this.listViewIngredients.HideSelection = false;
            this.listViewIngredients.Location = new System.Drawing.Point(3, 62);
            this.listViewIngredients.Name = "listViewIngredients";
            this.listViewIngredients.Size = new System.Drawing.Size(997, 330);
            this.listViewIngredients.TabIndex = 1;
            this.listViewIngredients.UseCompatibleStateImageBehavior = false;
            this.listViewIngredients.View = System.Windows.Forms.View.Details;
            this.listViewIngredients.Visible = false;
            // 
            // dgViewAddingMultipleProductVariants
            // 
            this.dgViewAddingMultipleProductVariants.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgViewAddingMultipleProductVariants.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgViewAddingMultipleProductVariants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewAddingMultipleProductVariants.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VariantName,
            this.ColumnProduct,
            this.ColumnSize,
            this.ColumnPrice,
            this.ColumnIngredients,
            this.ColumnInstructions,
            this.ImagePathColumn,
            this.ColumnImage,
            this.Action});
            this.dgViewAddingMultipleProductVariants.EnableHeadersVisualStyles = false;
            this.dgViewAddingMultipleProductVariants.Location = new System.Drawing.Point(3, 398);
            this.dgViewAddingMultipleProductVariants.Name = "dgViewAddingMultipleProductVariants";
            this.dgViewAddingMultipleProductVariants.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgViewAddingMultipleProductVariants.Size = new System.Drawing.Size(997, 589);
            this.dgViewAddingMultipleProductVariants.TabIndex = 96;
            this.dgViewAddingMultipleProductVariants.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgViewAddingMultipleProductVariants_CellContentClick);
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
            // 
            // VariantName
            // 
            this.VariantName.FillWeight = 22.63434F;
            this.VariantName.HeaderText = "Variant Name";
            this.VariantName.Name = "VariantName";
            // 
            // ColumnProduct
            // 
            this.ColumnProduct.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnProduct.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.ColumnProduct.FillWeight = 29.62403F;
            this.ColumnProduct.HeaderText = "Category";
            this.ColumnProduct.Name = "ColumnProduct";
            // 
            // ColumnSize
            // 
            this.ColumnSize.FillWeight = 15.84404F;
            this.ColumnSize.HeaderText = "Size";
            this.ColumnSize.Name = "ColumnSize";
            // 
            // ColumnPrice
            // 
            this.ColumnPrice.FillWeight = 15.84404F;
            this.ColumnPrice.HeaderText = "Price";
            this.ColumnPrice.Name = "ColumnPrice";
            // 
            // ColumnIngredients
            // 
            this.ColumnIngredients.FillWeight = 22.63434F;
            this.ColumnIngredients.HeaderText = "Ingredients";
            this.ColumnIngredients.Name = "ColumnIngredients";
            // 
            // ColumnInstructions
            // 
            this.ColumnInstructions.FillWeight = 22.63434F;
            this.ColumnInstructions.HeaderText = "Instructions";
            this.ColumnInstructions.Name = "ColumnInstructions";
            // 
            // ImagePathColumn
            // 
            this.ImagePathColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ImagePathColumn.FillWeight = 50F;
            this.ImagePathColumn.HeaderText = "Image Path";
            this.ImagePathColumn.Name = "ImagePathColumn";
            this.ImagePathColumn.Visible = false;
            this.ImagePathColumn.Width = 50;
            // 
            // ColumnImage
            // 
            this.ColumnImage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnImage.FillWeight = 91.741F;
            this.ColumnImage.HeaderText = "Image";
            this.ColumnImage.MinimumWidth = 60;
            this.ColumnImage.Name = "ColumnImage";
            this.ColumnImage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Action
            // 
            this.Action.FillWeight = 20.73682F;
            this.Action.HeaderText = "Add Ingredients";
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            this.Action.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Action.Text = "Add";
            this.Action.ToolTipText = "Add";
            this.Action.UseColumnTextForButtonValue = true;
            // 
            // AddProductModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 779);
            this.Controls.Add(this.materialCard1);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.Name = "AddProductModal";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.Text = "Add Product";
            this.Load += new System.EventHandler(this.AddProductModal_Load);
            this.materialCard1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanelDgViews.ResumeLayout(false);
            this.pnlTopButtons.ResumeLayout(false);
            this.pnlTopButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIngredientsQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewAddingMultipleProductVariants)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDuplicateRow;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddIngredientsToDgView;
        protected MaterialSkin.Controls.MaterialButton btnCancel;
        protected MaterialSkin.Controls.MaterialButton btnSaveAll;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelDgViews;
        private System.Windows.Forms.Panel pnlTopButtons;
        protected MaterialSkin.Controls.MaterialButton btnUploadImgToSelectedRow;
        private System.Windows.Forms.DataGridView dgViewAddingMultipleProductVariants;
        private System.Windows.Forms.NumericUpDown numericUpDownIngredientsQuantity;
        private System.Windows.Forms.TextBox textBoxSearchIngredients;
        private System.Windows.Forms.PictureBox pbSearch;
        private System.Windows.Forms.ListView listViewIngredients;
        private System.Windows.Forms.Button buttonCloseIngredientsList;
        private System.Windows.Forms.Button buttonAddNewRow;
        private System.Windows.Forms.Button btnUndoRecentlyAddedIngredients;
        private System.Windows.Forms.DataGridViewTextBoxColumn VariantName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIngredients;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInstructions;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImagePathColumn;
        private System.Windows.Forms.DataGridViewImageColumn ColumnImage;
        private System.Windows.Forms.DataGridViewButtonColumn Action;
    }
}