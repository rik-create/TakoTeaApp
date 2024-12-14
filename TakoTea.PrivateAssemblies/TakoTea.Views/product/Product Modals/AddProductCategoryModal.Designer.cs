namespace TakoTea.View.Product.Product_Modals
{
    partial class AddProductCategoryModal
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
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.cmbProductVategory = new MaterialSkin.Controls.MaterialComboBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.txtBoxProductName = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.btnSaveProduct = new MaterialSkin.Controls.MaterialButton();
            this.materialCard1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.materialLabel1);
            this.materialCard1.Controls.Add(this.cmbProductVategory);
            this.materialCard1.Controls.Add(this.materialLabel2);
            this.materialCard1.Controls.Add(this.txtBoxProductName);
            this.materialCard1.Controls.Add(this.materialLabel5);
            this.materialCard1.Controls.Add(this.btnCancel);
            this.materialCard1.Controls.Add(this.btnSaveProduct);
            this.materialCard1.Depth = 0;
            this.materialCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(3, 24);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(353, 323);
            this.materialCard1.TabIndex = 88;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(8, 164);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(64, 19);
            this.materialLabel1.TabIndex = 95;
            this.materialLabel1.Text = "Category";
            // 
            // cmbProductVategory
            // 
            this.cmbProductVategory.AutoResize = false;
            this.cmbProductVategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbProductVategory.Depth = 0;
            this.cmbProductVategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbProductVategory.DropDownHeight = 174;
            this.cmbProductVategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductVategory.DropDownWidth = 121;
            this.cmbProductVategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbProductVategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbProductVategory.FormattingEnabled = true;
            this.cmbProductVategory.Hint = "Category";
            this.cmbProductVategory.IntegralHeight = false;
            this.cmbProductVategory.ItemHeight = 43;
            this.cmbProductVategory.Items.AddRange(new object[] {
            "Food",
            "Drink"});
            this.cmbProductVategory.Location = new System.Drawing.Point(17, 194);
            this.cmbProductVategory.MaxDropDownItems = 4;
            this.cmbProductVategory.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbProductVategory.Name = "cmbProductVategory";
            this.cmbProductVategory.Size = new System.Drawing.Size(300, 49);
            this.cmbProductVategory.StartIndex = 0;
            this.cmbProductVategory.TabIndex = 94;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(8, 74);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(102, 19);
            this.materialLabel2.TabIndex = 93;
            this.materialLabel2.Text = "Product Name";
            // 
            // txtBoxProductName
            // 
            this.txtBoxProductName.AnimateReadOnly = false;
            this.txtBoxProductName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtBoxProductName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBoxProductName.Depth = 0;
            this.txtBoxProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtBoxProductName.HideSelection = true;
            this.txtBoxProductName.Hint = "Enter Product Name";
            this.txtBoxProductName.LeadingIcon = null;
            this.txtBoxProductName.Location = new System.Drawing.Point(17, 104);
            this.txtBoxProductName.MaxLength = 32767;
            this.txtBoxProductName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtBoxProductName.Name = "txtBoxProductName";
            this.txtBoxProductName.PasswordChar = '\0';
            this.txtBoxProductName.PrefixSuffixText = null;
            this.txtBoxProductName.ReadOnly = false;
            this.txtBoxProductName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBoxProductName.SelectedText = "";
            this.txtBoxProductName.SelectionLength = 0;
            this.txtBoxProductName.SelectionStart = 0;
            this.txtBoxProductName.ShortcutsEnabled = true;
            this.txtBoxProductName.Size = new System.Drawing.Size(300, 48);
            this.txtBoxProductName.TabIndex = 91;
            this.txtBoxProductName.TabStop = false;
            this.txtBoxProductName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBoxProductName.TrailingIcon = null;
            this.txtBoxProductName.UseSystemPasswordChar = false;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.materialLabel5.Location = new System.Drawing.Point(113, 20);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(136, 29);
            this.materialLabel5.TabIndex = 90;
            this.materialLabel5.Text = "Add Product";
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(168, 264);
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
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveProduct
            // 
            this.btnSaveProduct.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSaveProduct.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSaveProduct.Depth = 0;
            this.btnSaveProduct.HighEmphasis = true;
            this.btnSaveProduct.Icon = null;
            this.btnSaveProduct.Location = new System.Drawing.Point(250, 264);
            this.btnSaveProduct.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSaveProduct.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSaveProduct.Name = "btnSaveProduct";
            this.btnSaveProduct.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSaveProduct.Size = new System.Drawing.Size(75, 36);
            this.btnSaveProduct.TabIndex = 88;
            this.btnSaveProduct.Text = "Submit";
            this.btnSaveProduct.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSaveProduct.UseAccentColor = false;
            this.btnSaveProduct.UseVisualStyleBackColor = true;
            this.btnSaveProduct.Click += new System.EventHandler(this.btnSaveProduct_Click_1);
            // 
            // AddProductCategoryModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 350);
            this.Controls.Add(this.materialCard1);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.Name = "AddProductCategoryModal";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Product";
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private MaterialSkin.Controls.MaterialCard materialCard1;
        protected MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialComboBox cmbProductVategory;
        protected MaterialSkin.Controls.MaterialLabel materialLabel2;
        protected MaterialSkin.Controls.MaterialTextBox2 txtBoxProductName;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        protected MaterialSkin.Controls.MaterialButton btnCancel;
        protected MaterialSkin.Controls.MaterialButton btnSaveProduct;
    }
}