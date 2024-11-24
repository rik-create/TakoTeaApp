namespace TakoTea.Views.Batches
{
    partial class AddBatchModal
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
            this.materialTextBox21 = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtBoxBatchNumber = new MaterialSkin.Controls.MaterialTextBox2();
            this.numericUpDownLowLevel = new System.Windows.Forms.NumericUpDown();
            this.materialLabel14 = new MaterialSkin.Controls.MaterialLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
            this.cmbBoxMeasuringUnit = new MaterialSkin.Controls.MaterialComboBox();
            this.lblCost = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLowLevel)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(886, 531);
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
            this.materialCard1.Size = new System.Drawing.Size(886, 531);
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
            this.panel4.Size = new System.Drawing.Size(858, 394);
            this.panel4.TabIndex = 103;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dateTimePickerExpiration);
            this.groupBox3.Controls.Add(this.materialLabel9);
            this.groupBox3.Controls.Add(this.lblIngredientId);
            this.groupBox3.Controls.Add(this.materialLabel1);
            this.groupBox3.Controls.Add(this.materialLabel8);
            this.groupBox3.Controls.Add(this.materialTextBox21);
            this.groupBox3.Controls.Add(this.txtBoxBatchNumber);
            this.groupBox3.Controls.Add(this.numericUpDownLowLevel);
            this.groupBox3.Controls.Add(this.materialLabel14);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.materialLabel6);
            this.groupBox3.Controls.Add(this.numericUpDownQuantity);
            this.groupBox3.Controls.Add(this.cmbBoxMeasuringUnit);
            this.groupBox3.Controls.Add(this.lblCost);
            this.groupBox3.Controls.Add(this.materialLabel7);
            this.groupBox3.Controls.Add(this.numericUpDownCost);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox3.Location = new System.Drawing.Point(20, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(810, 414);
            this.groupBox3.TabIndex = 72;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Batch Information";
            // 
            // dateTimePickerExpiration
            // 
            this.dateTimePickerExpiration.Location = new System.Drawing.Point(440, 72);
            this.dateTimePickerExpiration.Name = "dateTimePickerExpiration";
            this.dateTimePickerExpiration.Size = new System.Drawing.Size(330, 26);
            this.dateTimePickerExpiration.TabIndex = 111;
            // 
            // materialLabel9
            // 
            this.materialLabel9.AutoSize = true;
            this.materialLabel9.Depth = 0;
            this.materialLabel9.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel9.Location = new System.Drawing.Point(440, 37);
            this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel9.Name = "materialLabel9";
            this.materialLabel9.Size = new System.Drawing.Size(109, 19);
            this.materialLabel9.TabIndex = 109;
            this.materialLabel9.Text = "Expiration Date";
            // 
            // lblIngredientId
            // 
            this.lblIngredientId.AutoSize = true;
            this.lblIngredientId.Depth = 0;
            this.lblIngredientId.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblIngredientId.Location = new System.Drawing.Point(96, 136);
            this.lblIngredientId.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblIngredientId.Name = "lblIngredientId";
            this.lblIngredientId.Size = new System.Drawing.Size(37, 19);
            this.lblIngredientId.TabIndex = 110;
            this.lblIngredientId.Text = "2001";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(16, 136);
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
            this.materialLabel8.Location = new System.Drawing.Point(16, 37);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(102, 19);
            this.materialLabel8.TabIndex = 110;
            this.materialLabel8.Text = "Batch Number";
            // 
            // materialTextBox21
            // 
            this.materialTextBox21.AnimateReadOnly = false;
            this.materialTextBox21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.materialTextBox21.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.materialTextBox21.Depth = 0;
            this.materialTextBox21.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBox21.HideSelection = true;
            this.materialTextBox21.Hint = "Ingredient Name";
            this.materialTextBox21.LeadingIcon = null;
            this.materialTextBox21.Location = new System.Drawing.Point(16, 171);
            this.materialTextBox21.MaxLength = 32767;
            this.materialTextBox21.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBox21.Name = "materialTextBox21";
            this.materialTextBox21.PasswordChar = '\0';
            this.materialTextBox21.PrefixSuffixText = null;
            this.materialTextBox21.ReadOnly = false;
            this.materialTextBox21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.materialTextBox21.SelectedText = "";
            this.materialTextBox21.SelectionLength = 0;
            this.materialTextBox21.SelectionStart = 0;
            this.materialTextBox21.ShortcutsEnabled = true;
            this.materialTextBox21.Size = new System.Drawing.Size(360, 48);
            this.materialTextBox21.TabIndex = 108;
            this.materialTextBox21.TabStop = false;
            this.materialTextBox21.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.materialTextBox21.TrailingIcon = null;
            this.materialTextBox21.UseSystemPasswordChar = false;
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
            this.txtBoxBatchNumber.Location = new System.Drawing.Point(16, 72);
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
            this.txtBoxBatchNumber.Size = new System.Drawing.Size(360, 48);
            this.txtBoxBatchNumber.TabIndex = 108;
            this.txtBoxBatchNumber.TabStop = false;
            this.txtBoxBatchNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBoxBatchNumber.TrailingIcon = null;
            this.txtBoxBatchNumber.UseSystemPasswordChar = false;
            // 
            // numericUpDownLowLevel
            // 
            this.numericUpDownLowLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownLowLevel.Location = new System.Drawing.Point(16, 352);
            this.numericUpDownLowLevel.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.numericUpDownLowLevel.Name = "numericUpDownLowLevel";
            this.numericUpDownLowLevel.Size = new System.Drawing.Size(360, 31);
            this.numericUpDownLowLevel.TabIndex = 106;
            this.toolTip1.SetToolTip(this.numericUpDownLowLevel, " A predefined threshold that triggers an automatic reorder or low stock notificat" +
        "ion.");
            // 
            // materialLabel14
            // 
            this.materialLabel14.AutoSize = true;
            this.materialLabel14.Depth = 0;
            this.materialLabel14.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel14.Location = new System.Drawing.Point(16, 320);
            this.materialLabel14.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel14.Name = "materialLabel14";
            this.materialLabel14.Size = new System.Drawing.Size(177, 19);
            this.materialLabel14.TabIndex = 105;
            this.materialLabel14.Text = "Stock Reorder/Low Level";
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
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel6.Location = new System.Drawing.Point(440, 214);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(61, 19);
            this.materialLabel6.TabIndex = 67;
            this.materialLabel6.Text = "Quantity";
            // 
            // numericUpDownQuantity
            // 
            this.numericUpDownQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownQuantity.Location = new System.Drawing.Point(440, 249);
            this.numericUpDownQuantity.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.numericUpDownQuantity.Name = "numericUpDownQuantity";
            this.numericUpDownQuantity.Size = new System.Drawing.Size(360, 31);
            this.numericUpDownQuantity.TabIndex = 66;
            // 
            // cmbBoxMeasuringUnit
            // 
            this.cmbBoxMeasuringUnit.AutoResize = false;
            this.cmbBoxMeasuringUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbBoxMeasuringUnit.Depth = 0;
            this.cmbBoxMeasuringUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbBoxMeasuringUnit.DropDownHeight = 174;
            this.cmbBoxMeasuringUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxMeasuringUnit.DropDownWidth = 121;
            this.cmbBoxMeasuringUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbBoxMeasuringUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbBoxMeasuringUnit.FormattingEnabled = true;
            this.cmbBoxMeasuringUnit.Hint = "Choose measuring unit";
            this.cmbBoxMeasuringUnit.IntegralHeight = false;
            this.cmbBoxMeasuringUnit.ItemHeight = 43;
            this.cmbBoxMeasuringUnit.Location = new System.Drawing.Point(440, 149);
            this.cmbBoxMeasuringUnit.MaxDropDownItems = 4;
            this.cmbBoxMeasuringUnit.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbBoxMeasuringUnit.Name = "cmbBoxMeasuringUnit";
            this.cmbBoxMeasuringUnit.Size = new System.Drawing.Size(360, 49);
            this.cmbBoxMeasuringUnit.StartIndex = 0;
            this.cmbBoxMeasuringUnit.TabIndex = 61;
            this.toolTip1.SetToolTip(this.cmbBoxMeasuringUnit, "The unit of measurement used for the ingredient (e.g., grams, kilograms, liters, " +
        "cups).");
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Depth = 0;
            this.lblCost.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblCost.Location = new System.Drawing.Point(16, 235);
            this.lblCost.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(33, 19);
            this.lblCost.TabIndex = 60;
            this.lblCost.Text = "Cost";
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel7.Location = new System.Drawing.Point(440, 114);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(108, 19);
            this.materialLabel7.TabIndex = 57;
            this.materialLabel7.Text = "Measuring Unit";
            // 
            // numericUpDownCost
            // 
            this.numericUpDownCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownCost.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownCost.Location = new System.Drawing.Point(16, 270);
            this.numericUpDownCost.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.numericUpDownCost.Name = "numericUpDownCost";
            this.numericUpDownCost.Size = new System.Drawing.Size(358, 31);
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
            this.panel3.Location = new System.Drawing.Point(14, 454);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(858, 63);
            this.panel3.TabIndex = 102;
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAdd.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAdd.Depth = 0;
            this.btnAdd.HighEmphasis = true;
            this.btnAdd.Icon = null;
            this.btnAdd.Location = new System.Drawing.Point(664, 10);
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
            this.btnCancel.Location = new System.Drawing.Point(760, 10);
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
            this.panel2.Size = new System.Drawing.Size(858, 46);
            this.panel2.TabIndex = 101;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel5.Location = new System.Drawing.Point(382, 10);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(93, 24);
            this.materialLabel5.TabIndex = 0;
            this.materialLabel5.Text = "Add Batch";
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
            // AddBatchModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 558);
            this.Controls.Add(this.panel1);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.Name = "AddBatchModal";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.Text = "AddItemModal";
            this.panel1.ResumeLayout(false);
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLowLevel)).EndInit();
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
        public MaterialSkin.Controls.MaterialLabel materialLabel6;
        public System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        public MaterialSkin.Controls.MaterialComboBox cmbBoxMeasuringUnit;
        public MaterialSkin.Controls.MaterialLabel lblCost;
        public MaterialSkin.Controls.MaterialLabel materialLabel7;
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
        public System.Windows.Forms.NumericUpDown numericUpDownLowLevel;
        public MaterialSkin.Controls.MaterialLabel materialLabel14;
        public MaterialSkin.Controls.MaterialLabel materialLabel1;
        public MaterialSkin.Controls.MaterialTextBox2 materialTextBox21;
        public MaterialSkin.Controls.MaterialLabel lblIngredientId;
    }
}