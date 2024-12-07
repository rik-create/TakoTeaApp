namespace TakoTea.Views.Batches
{
    partial class EditBatchModal
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dateTimePickerExpiration = new System.Windows.Forms.DateTimePicker();
            this.materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            this.lblIngredientId = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.txtBoxIngredientName = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtBoxBatchNumber = new MaterialSkin.Controls.MaterialTextBox2();
            this.label1 = new System.Windows.Forms.Label();
            this.lblQuantity = new MaterialSkin.Controls.MaterialLabel();
            this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblCost = new MaterialSkin.Controls.MaterialLabel();
            this.numericUpDownCost = new System.Windows.Forms.NumericUpDown();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAdd = new MaterialSkin.Controls.MaterialButton();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialButton6 = new MaterialSkin.Controls.MaterialButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.materialCard1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCost)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.materialCard1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 438);
            this.panel1.TabIndex = 2;
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.panel4);
            this.materialCard1.Controls.Add(this.panel3);
            this.materialCard1.Controls.Add(this.panel2);
            this.materialCard1.Controls.Add(this.materialButton6);
            this.materialCard1.Depth = 0;
            this.materialCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(0, 0);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(700, 438);
            this.materialCard1.TabIndex = 18;
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.groupBox3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(14, 60);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(672, 311);
            this.panel4.TabIndex = 103;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dateTimePickerExpiration);
            this.groupBox3.Controls.Add(this.materialLabel9);
            this.groupBox3.Controls.Add(this.lblIngredientId);
            this.groupBox3.Controls.Add(this.materialLabel1);
            this.groupBox3.Controls.Add(this.materialLabel8);
            this.groupBox3.Controls.Add(this.txtBoxIngredientName);
            this.groupBox3.Controls.Add(this.txtBoxBatchNumber);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.lblQuantity);
            this.groupBox3.Controls.Add(this.numericUpDownQuantity);
            this.groupBox3.Controls.Add(this.lblCost);
            this.groupBox3.Controls.Add(this.numericUpDownCost);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox3.Location = new System.Drawing.Point(20, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(636, 278);
            this.groupBox3.TabIndex = 72;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Batch Information";
            // 
            // dateTimePickerExpiration
            // 
            this.dateTimePickerExpiration.Location = new System.Drawing.Point(328, 64);
            this.dateTimePickerExpiration.Name = "dateTimePickerExpiration";
            this.dateTimePickerExpiration.Size = new System.Drawing.Size(288, 26);
            this.dateTimePickerExpiration.TabIndex = 111;
            // 
            // materialLabel9
            // 
            this.materialLabel9.AutoSize = true;
            this.materialLabel9.Depth = 0;
            this.materialLabel9.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel9.Location = new System.Drawing.Point(328, 32);
            this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel9.Name = "materialLabel9";
            this.materialLabel9.Size = new System.Drawing.Size(109, 19);
            this.materialLabel9.TabIndex = 109;
            this.materialLabel9.Text = "Expiration Date";
            // 
            // lblIngredientId
            // 
            this.lblIngredientId.Depth = 0;
            this.lblIngredientId.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblIngredientId.Location = new System.Drawing.Point(96, 32);
            this.lblIngredientId.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblIngredientId.Name = "lblIngredientId";
            this.lblIngredientId.Size = new System.Drawing.Size(120, 19);
            this.lblIngredientId.TabIndex = 110;
            this.lblIngredientId.Text = "2001";
            this.lblIngredientId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(16, 32);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(75, 19);
            this.materialLabel1.TabIndex = 110;
            this.materialLabel1.Text = "Ingredient:";
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel8.Location = new System.Drawing.Point(24, 128);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(102, 19);
            this.materialLabel8.TabIndex = 110;
            this.materialLabel8.Text = "Batch Number";
            // 
            // txtBoxIngredientName
            // 
            this.txtBoxIngredientName.AnimateReadOnly = false;
            this.txtBoxIngredientName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtBoxIngredientName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBoxIngredientName.Depth = 0;
            this.txtBoxIngredientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtBoxIngredientName.HideSelection = true;
            this.txtBoxIngredientName.Hint = "Ingredient Name";
            this.txtBoxIngredientName.LeadingIcon = null;
            this.txtBoxIngredientName.Location = new System.Drawing.Point(16, 67);
            this.txtBoxIngredientName.MaxLength = 32767;
            this.txtBoxIngredientName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtBoxIngredientName.Name = "txtBoxIngredientName";
            this.txtBoxIngredientName.PasswordChar = '\0';
            this.txtBoxIngredientName.PrefixSuffixText = null;
            this.txtBoxIngredientName.ReadOnly = true;
            this.txtBoxIngredientName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBoxIngredientName.SelectedText = "";
            this.txtBoxIngredientName.SelectionLength = 0;
            this.txtBoxIngredientName.SelectionStart = 0;
            this.txtBoxIngredientName.ShortcutsEnabled = true;
            this.txtBoxIngredientName.Size = new System.Drawing.Size(288, 48);
            this.txtBoxIngredientName.TabIndex = 108;
            this.txtBoxIngredientName.TabStop = false;
            this.txtBoxIngredientName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBoxIngredientName.TrailingIcon = null;
            this.txtBoxIngredientName.UseSystemPasswordChar = false;
            // 
            // txtBoxBatchNumber
            // 
            this.txtBoxBatchNumber.AnimateReadOnly = false;
            this.txtBoxBatchNumber.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtBoxBatchNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBoxBatchNumber.Depth = 0;
            this.txtBoxBatchNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtBoxBatchNumber.HideSelection = true;
            this.txtBoxBatchNumber.Hint = "Enter Batch Number";
            this.txtBoxBatchNumber.LeadingIcon = null;
            this.txtBoxBatchNumber.Location = new System.Drawing.Point(24, 152);
            this.txtBoxBatchNumber.MaxLength = 32767;
            this.txtBoxBatchNumber.MouseState = MaterialSkin.MouseState.OUT;
            this.txtBoxBatchNumber.Name = "txtBoxBatchNumber";
            this.txtBoxBatchNumber.PasswordChar = '\0';
            this.txtBoxBatchNumber.PrefixSuffixText = null;
            this.txtBoxBatchNumber.ReadOnly = false;
            this.txtBoxBatchNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBoxBatchNumber.SelectedText = "";
            this.txtBoxBatchNumber.SelectionLength = 0;
            this.txtBoxBatchNumber.SelectionStart = 0;
            this.txtBoxBatchNumber.ShortcutsEnabled = true;
            this.txtBoxBatchNumber.Size = new System.Drawing.Size(288, 48);
            this.txtBoxBatchNumber.TabIndex = 108;
            this.txtBoxBatchNumber.TabStop = false;
            this.txtBoxBatchNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.toolTip1.SetToolTip(this.txtBoxBatchNumber, "e.g <ingredient>31-12-2024");
            this.txtBoxBatchNumber.TrailingIcon = null;
            this.txtBoxBatchNumber.UseSystemPasswordChar = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(640, 710);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 20);
            this.label1.TabIndex = 69;
            this.label1.Text = "Cost per unit: PHP 1";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Depth = 0;
            this.lblQuantity.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblQuantity.Location = new System.Drawing.Point(328, 101);
            this.lblQuantity.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(61, 19);
            this.lblQuantity.TabIndex = 67;
            this.lblQuantity.Text = "Quantity";
            // 
            // numericUpDownQuantity
            // 
            this.numericUpDownQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownQuantity.Location = new System.Drawing.Point(328, 128);
            this.numericUpDownQuantity.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.numericUpDownQuantity.Name = "numericUpDownQuantity";
            this.numericUpDownQuantity.Size = new System.Drawing.Size(288, 31);
            this.numericUpDownQuantity.TabIndex = 66;
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Depth = 0;
            this.lblCost.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblCost.Location = new System.Drawing.Point(24, 208);
            this.lblCost.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(33, 19);
            this.lblCost.TabIndex = 60;
            this.lblCost.Text = "Cost";
            // 
            // numericUpDownCost
            // 
            this.numericUpDownCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownCost.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownCost.Location = new System.Drawing.Point(24, 232);
            this.numericUpDownCost.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.numericUpDownCost.Name = "numericUpDownCost";
            this.numericUpDownCost.Size = new System.Drawing.Size(288, 31);
            this.numericUpDownCost.TabIndex = 56;
            this.toolTip1.SetToolTip(this.numericUpDownCost, "Overall Batch Cost");
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(14, 371);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(672, 53);
            this.panel3.TabIndex = 102;
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAdd.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAdd.Depth = 0;
            this.btnAdd.HighEmphasis = true;
            this.btnAdd.Icon = null;
            this.btnAdd.Location = new System.Drawing.Point(472, 8);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAdd.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAdd.Size = new System.Drawing.Size(86, 36);
            this.btnAdd.TabIndex = 53;
            this.btnAdd.Text = "Confirm";
            this.btnAdd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAdd.UseAccentColor = false;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnConfirmEdit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(568, 8);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(77, 36);
            this.btnCancel.TabIndex = 54;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancel.UseAccentColor = true;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancelEdit_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.materialLabel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(14, 14);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(672, 46);
            this.panel2.TabIndex = 101;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel5.Location = new System.Drawing.Point(289, 10);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(92, 24);
            this.materialLabel5.TabIndex = 0;
            this.materialLabel5.Text = "Edit Batch";
            // 
            // materialButton6
            // 
            this.materialButton6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton6.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton6.Depth = 0;
            this.materialButton6.HighEmphasis = true;
            this.materialButton6.Icon = null;
            this.materialButton6.Location = new System.Drawing.Point(695, -162);
            this.materialButton6.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton6.Name = "materialButton6";
            this.materialButton6.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton6.Size = new System.Drawing.Size(65, 36);
            this.materialButton6.TabIndex = 27;
            this.materialButton6.Text = "Reset";
            this.materialButton6.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton6.UseAccentColor = false;
            this.materialButton6.UseVisualStyleBackColor = true;
            // 
            // EditBatchModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 465);
            this.Controls.Add(this.panel1);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.Name = "EditBatchModal";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.Text = "AddItemModal";
            this.panel1.ResumeLayout(false);
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCost)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        public System.Windows.Forms.Panel panel1;
        public MaterialSkin.Controls.MaterialCard materialCard1;
        public MaterialSkin.Controls.MaterialButton materialButton6;
        public System.Windows.Forms.Panel panel2;
        public MaterialSkin.Controls.MaterialLabel materialLabel5;
        public System.Windows.Forms.Panel panel4;
        public MaterialSkin.Controls.MaterialLabel lblQuantity;
        public System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        public MaterialSkin.Controls.MaterialLabel lblCost;
        public System.Windows.Forms.NumericUpDown numericUpDownCost;
        public System.Windows.Forms.Panel panel3;
        public MaterialSkin.Controls.MaterialButton btnAdd;
        public MaterialSkin.Controls.MaterialButton btnCancel;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.DateTimePicker dateTimePickerExpiration;
        public MaterialSkin.Controls.MaterialLabel materialLabel9;
        public MaterialSkin.Controls.MaterialLabel materialLabel8;
        public MaterialSkin.Controls.MaterialTextBox2 txtBoxBatchNumber;
        public MaterialSkin.Controls.MaterialLabel materialLabel1;
        public MaterialSkin.Controls.MaterialTextBox2 txtBoxIngredientName;
        public MaterialSkin.Controls.MaterialLabel lblIngredientId;
    }
}