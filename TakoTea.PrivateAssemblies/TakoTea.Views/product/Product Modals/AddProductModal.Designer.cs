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
            this.panel1 = new System.Windows.Forms.Panel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.btnDuplicateRow = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddNewRow = new System.Windows.Forms.Button();
            this.dgViewAddingMultipleProductVariants = new System.Windows.Forms.DataGridView();
            this.ColumnVarName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIngredients = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInstructions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtBoxProductName = new MaterialSkin.Controls.MaterialComboBox();
            this.cmbProductCategory = new MaterialSkin.Controls.MaterialComboBox();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.btnUploadImgToSelectedRow = new MaterialSkin.Controls.MaterialButton();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.btnSaveAll = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialCard1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewAddingMultipleProductVariants)).BeginInit();
            this.SuspendLayout();
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.panel1);
            this.materialCard1.Controls.Add(this.btnDuplicateRow);
            this.materialCard1.Controls.Add(this.btnDelete);
            this.materialCard1.Controls.Add(this.btnAddNewRow);
            this.materialCard1.Controls.Add(this.dgViewAddingMultipleProductVariants);
            this.materialCard1.Controls.Add(this.txtBoxProductName);
            this.materialCard1.Controls.Add(this.cmbProductCategory);
            this.materialCard1.Controls.Add(this.materialLabel5);
            this.materialCard1.Controls.Add(this.btnUploadImgToSelectedRow);
            this.materialCard1.Controls.Add(this.btnCancel);
            this.materialCard1.Controls.Add(this.btnSaveAll);
            this.materialCard1.Controls.Add(this.materialLabel2);
            this.materialCard1.Depth = 0;
            this.materialCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(3, 24);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(813, 674);
            this.materialCard1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.materialLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(14, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(785, 46);
            this.panel1.TabIndex = 100;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel1.Location = new System.Drawing.Point(302, 10);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(181, 24);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Add Product Variant";
            // 
            // btnDuplicateRow
            // 
            this.btnDuplicateRow.Location = new System.Drawing.Point(26, 590);
            this.btnDuplicateRow.Name = "btnDuplicateRow";
            this.btnDuplicateRow.Size = new System.Drawing.Size(75, 23);
            this.btnDuplicateRow.TabIndex = 98;
            this.btnDuplicateRow.Text = "Duplicate";
            this.btnDuplicateRow.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(706, 590);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 99;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAddNewRow
            // 
            this.btnAddNewRow.Location = new System.Drawing.Point(626, 590);
            this.btnAddNewRow.Name = "btnAddNewRow";
            this.btnAddNewRow.Size = new System.Drawing.Size(75, 23);
            this.btnAddNewRow.TabIndex = 97;
            this.btnAddNewRow.Text = "Add New";
            this.btnAddNewRow.UseVisualStyleBackColor = true;
            // 
            // dgViewAddingMultipleProductVariants
            // 
            this.dgViewAddingMultipleProductVariants.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgViewAddingMultipleProductVariants.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgViewAddingMultipleProductVariants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewAddingMultipleProductVariants.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnVarName,
            this.ColumnSize,
            this.ColumnPrice,
            this.ColumnIngredients,
            this.ColumnInstructions,
            this.ColumnImage});
            this.dgViewAddingMultipleProductVariants.Location = new System.Drawing.Point(26, 210);
            this.dgViewAddingMultipleProductVariants.Name = "dgViewAddingMultipleProductVariants";
            this.dgViewAddingMultipleProductVariants.Size = new System.Drawing.Size(760, 370);
            this.dgViewAddingMultipleProductVariants.TabIndex = 95;
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
            // ColumnIngredients
            // 
            this.ColumnIngredients.HeaderText = "Ingredients";
            this.ColumnIngredients.Name = "ColumnIngredients";
            // 
            // ColumnInstructions
            // 
            this.ColumnInstructions.HeaderText = "Instructions";
            this.ColumnInstructions.Name = "ColumnInstructions";
            // 
            // ColumnImage
            // 
            this.ColumnImage.HeaderText = "Image";
            this.ColumnImage.Name = "ColumnImage";
            // 
            // txtBoxProductName
            // 
            this.txtBoxProductName.AutoResize = false;
            this.txtBoxProductName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtBoxProductName.Depth = 0;
            this.txtBoxProductName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.txtBoxProductName.DropDownHeight = 174;
            this.txtBoxProductName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtBoxProductName.DropDownWidth = 121;
            this.txtBoxProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtBoxProductName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtBoxProductName.FormattingEnabled = true;
            this.txtBoxProductName.Hint = "Name";
            this.txtBoxProductName.IntegralHeight = false;
            this.txtBoxProductName.ItemHeight = 43;
            this.txtBoxProductName.Location = new System.Drawing.Point(436, 110);
            this.txtBoxProductName.MaxDropDownItems = 4;
            this.txtBoxProductName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtBoxProductName.Name = "txtBoxProductName";
            this.txtBoxProductName.Size = new System.Drawing.Size(350, 49);
            this.txtBoxProductName.StartIndex = 0;
            this.txtBoxProductName.TabIndex = 93;
            // 
            // cmbProductCategory
            // 
            this.cmbProductCategory.AutoResize = false;
            this.cmbProductCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbProductCategory.Depth = 0;
            this.cmbProductCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbProductCategory.DropDownHeight = 174;
            this.cmbProductCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductCategory.DropDownWidth = 121;
            this.cmbProductCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbProductCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbProductCategory.FormattingEnabled = true;
            this.cmbProductCategory.Hint = "Category";
            this.cmbProductCategory.IntegralHeight = false;
            this.cmbProductCategory.ItemHeight = 43;
            this.cmbProductCategory.Location = new System.Drawing.Point(26, 110);
            this.cmbProductCategory.MaxDropDownItems = 4;
            this.cmbProductCategory.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbProductCategory.Name = "cmbProductCategory";
            this.cmbProductCategory.Size = new System.Drawing.Size(350, 49);
            this.cmbProductCategory.StartIndex = 0;
            this.cmbProductCategory.TabIndex = 94;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.Location = new System.Drawing.Point(436, 80);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(102, 19);
            this.materialLabel5.TabIndex = 91;
            this.materialLabel5.Text = "Product Name";
            // 
            // btnUploadImgToSelectedRow
            // 
            this.btnUploadImgToSelectedRow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUploadImgToSelectedRow.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnUploadImgToSelectedRow.Depth = 0;
            this.btnUploadImgToSelectedRow.HighEmphasis = true;
            this.btnUploadImgToSelectedRow.Icon = null;
            this.btnUploadImgToSelectedRow.Location = new System.Drawing.Point(640, 166);
            this.btnUploadImgToSelectedRow.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnUploadImgToSelectedRow.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnUploadImgToSelectedRow.Name = "btnUploadImgToSelectedRow";
            this.btnUploadImgToSelectedRow.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnUploadImgToSelectedRow.Size = new System.Drawing.Size(139, 36);
            this.btnUploadImgToSelectedRow.TabIndex = 89;
            this.btnUploadImgToSelectedRow.Text = "Upload image...";
            this.btnUploadImgToSelectedRow.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnUploadImgToSelectedRow.UseAccentColor = true;
            this.btnUploadImgToSelectedRow.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(536, 624);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(77, 36);
            this.btnCancel.TabIndex = 89;
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
            this.btnSaveAll.Location = new System.Drawing.Point(626, 624);
            this.btnSaveAll.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSaveAll.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSaveAll.Size = new System.Drawing.Size(161, 36);
            this.btnSaveAll.TabIndex = 88;
            this.btnSaveAll.Text = "Save all variants";
            this.btnSaveAll.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSaveAll.UseAccentColor = false;
            this.btnSaveAll.UseVisualStyleBackColor = true;
            this.btnSaveAll.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(26, 80);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(123, 19);
            this.materialLabel2.TabIndex = 90;
            this.materialLabel2.Text = "Product Category";
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
            // AddProductModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 701);
            this.Controls.Add(this.materialCard1);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.Name = "AddProductModal";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.Text = "Add Product";
            this.Load += new System.EventHandler(this.AddProductModal_Load);
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewAddingMultipleProductVariants)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private System.Windows.Forms.Button btnDuplicateRow;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddNewRow;
        private System.Windows.Forms.DataGridView dgViewAddingMultipleProductVariants;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnVarName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIngredients;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInstructions;
        private System.Windows.Forms.DataGridViewImageColumn ColumnImage;
        private MaterialSkin.Controls.MaterialComboBox txtBoxProductName;
        private MaterialSkin.Controls.MaterialComboBox cmbProductCategory;
        protected MaterialSkin.Controls.MaterialLabel materialLabel5;
        protected MaterialSkin.Controls.MaterialButton btnCancel;
        protected MaterialSkin.Controls.MaterialButton btnSaveAll;
        protected MaterialSkin.Controls.MaterialLabel materialLabel2;
        protected MaterialSkin.Controls.MaterialButton btnUploadImgToSelectedRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}