using System.Windows.Forms;

namespace TakoTea.View.Items.Item_Modals { 
    partial class EditIngredientModal
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
            this.groupBoxOther = new System.Windows.Forms.GroupBox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.numericUpDownLowStockThreshold = new System.Windows.Forms.NumericUpDown();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.numericUpDownQuantityUsedPerProduct = new System.Windows.Forms.NumericUpDown();
            this.materialLabel12 = new MaterialSkin.Controls.MaterialLabel();
            this.lblAdditionalPrice = new MaterialSkin.Controls.MaterialLabel();
            this.lblAddOnFor = new MaterialSkin.Controls.MaterialLabel();
            this.materialCheckedListBoxAllergens = new System.Windows.Forms.CheckedListBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.cmbMeasuringUnit = new MaterialSkin.Controls.MaterialComboBox();
            this.numericUpDownAddOnPrice = new System.Windows.Forms.NumericUpDown();
            this.cmbAddOnFor = new System.Windows.Forms.ComboBox();
            this.chkIsAddOn = new MaterialSkin.Controls.MaterialCheckbox();
            this.groupBoxImage = new System.Windows.Forms.GroupBox();
            this.btnResetIngredientImg = new MaterialSkin.Controls.MaterialButton();
            this.btnBrowseForIngredientImg = new MaterialSkin.Controls.MaterialButton();
            this.pictureBoxImg = new System.Windows.Forms.PictureBox();
            this.groupBoxBasicInfo = new System.Windows.Forms.GroupBox();
            this.materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
            this.cmbboxStorageCondition = new MaterialSkin.Controls.MaterialComboBox();
            this.cmbTypeOfIngredient = new MaterialSkin.Controls.MaterialComboBox();
            this.materialLabel11 = new MaterialSkin.Controls.MaterialLabel();
            this.txtBoxItemDescription = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.txtBoxBrandName = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.txtBoxName = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel13 = new MaterialSkin.Controls.MaterialLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnConfirmEdit = new MaterialSkin.Controls.MaterialButton();
            this.btnCancelEdit = new MaterialSkin.Controls.MaterialButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.materialCard1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBoxOther.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLowStockThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantityUsedPerProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAddOnPrice)).BeginInit();
            this.groupBoxImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImg)).BeginInit();
            this.groupBoxBasicInfo.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(886, 824);
            this.panel1.TabIndex = 2;
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.panel4);
            this.materialCard1.Controls.Add(this.panel3);
            this.materialCard1.Controls.Add(this.panel2);
            this.materialCard1.Depth = 0;
            this.materialCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(0, 0);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(886, 824);
            this.materialCard1.TabIndex = 18;
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.groupBoxOther);
            this.panel4.Controls.Add(this.groupBoxImage);
            this.panel4.Controls.Add(this.groupBoxBasicInfo);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(14, 60);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(858, 692);
            this.panel4.TabIndex = 103;
            // 
            // groupBoxOther
            // 
            this.groupBoxOther.Controls.Add(this.materialLabel3);
            this.groupBoxOther.Controls.Add(this.numericUpDownLowStockThreshold);
            this.groupBoxOther.Controls.Add(this.materialLabel6);
            this.groupBoxOther.Controls.Add(this.numericUpDownQuantityUsedPerProduct);
            this.groupBoxOther.Controls.Add(this.materialLabel12);
            this.groupBoxOther.Controls.Add(this.lblAdditionalPrice);
            this.groupBoxOther.Controls.Add(this.lblAddOnFor);
            this.groupBoxOther.Controls.Add(this.materialCheckedListBoxAllergens);
            this.groupBoxOther.Controls.Add(this.materialLabel1);
            this.groupBoxOther.Controls.Add(this.cmbMeasuringUnit);
            this.groupBoxOther.Controls.Add(this.numericUpDownAddOnPrice);
            this.groupBoxOther.Controls.Add(this.cmbAddOnFor);
            this.groupBoxOther.Controls.Add(this.chkIsAddOn);
            this.groupBoxOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBoxOther.Location = new System.Drawing.Point(416, 360);
            this.groupBoxOther.Name = "groupBoxOther";
            this.groupBoxOther.Size = new System.Drawing.Size(420, 324);
            this.groupBoxOther.TabIndex = 74;
            this.groupBoxOther.TabStop = false;
            this.groupBoxOther.Text = "Other";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(160, 248);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(178, 19);
            this.materialLabel3.TabIndex = 100;
            this.materialLabel3.Text = "QuantityUsedPerProduct ";
            // 
            // numericUpDownLowStockThreshold
            // 
            this.numericUpDownLowStockThreshold.Location = new System.Drawing.Point(176, 136);
            this.numericUpDownLowStockThreshold.Name = "numericUpDownLowStockThreshold";
            this.numericUpDownLowStockThreshold.Size = new System.Drawing.Size(120, 26);
            this.numericUpDownLowStockThreshold.TabIndex = 102;
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel6.Location = new System.Drawing.Point(176, 113);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(150, 19);
            this.materialLabel6.TabIndex = 101;
            this.materialLabel6.Text = "Low Stock Threshold";
            // 
            // numericUpDownQuantityUsedPerProduct
            // 
            this.numericUpDownQuantityUsedPerProduct.DecimalPlaces = 2;
            this.numericUpDownQuantityUsedPerProduct.Location = new System.Drawing.Point(160, 280);
            this.numericUpDownQuantityUsedPerProduct.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownQuantityUsedPerProduct.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownQuantityUsedPerProduct.Name = "numericUpDownQuantityUsedPerProduct";
            this.numericUpDownQuantityUsedPerProduct.Size = new System.Drawing.Size(120, 26);
            this.numericUpDownQuantityUsedPerProduct.TabIndex = 100;
            this.numericUpDownQuantityUsedPerProduct.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // materialLabel12
            // 
            this.materialLabel12.AutoSize = true;
            this.materialLabel12.Depth = 0;
            this.materialLabel12.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel12.Location = new System.Drawing.Point(17, 26);
            this.materialLabel12.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel12.Name = "materialLabel12";
            this.materialLabel12.Size = new System.Drawing.Size(123, 19);
            this.materialLabel12.TabIndex = 92;
            this.materialLabel12.Text = "Ingredient Allergy";
            // 
            // lblAdditionalPrice
            // 
            this.lblAdditionalPrice.AutoSize = true;
            this.lblAdditionalPrice.Depth = 0;
            this.lblAdditionalPrice.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAdditionalPrice.Location = new System.Drawing.Point(160, 175);
            this.lblAdditionalPrice.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblAdditionalPrice.Name = "lblAdditionalPrice";
            this.lblAdditionalPrice.Size = new System.Drawing.Size(112, 19);
            this.lblAdditionalPrice.TabIndex = 91;
            this.lblAdditionalPrice.Text = "Additional Price";
            // 
            // lblAddOnFor
            // 
            this.lblAddOnFor.AutoSize = true;
            this.lblAddOnFor.Depth = 0;
            this.lblAddOnFor.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAddOnFor.Location = new System.Drawing.Point(289, 175);
            this.lblAddOnFor.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblAddOnFor.Name = "lblAddOnFor";
            this.lblAddOnFor.Size = new System.Drawing.Size(76, 19);
            this.lblAddOnFor.TabIndex = 91;
            this.lblAddOnFor.Text = "AddOn For";
            // 
            // materialCheckedListBoxAllergens
            // 
            this.materialCheckedListBoxAllergens.FormattingEnabled = true;
            this.materialCheckedListBoxAllergens.Location = new System.Drawing.Point(17, 49);
            this.materialCheckedListBoxAllergens.Name = "materialCheckedListBoxAllergens";
            this.materialCheckedListBoxAllergens.Size = new System.Drawing.Size(140, 109);
            this.materialCheckedListBoxAllergens.TabIndex = 95;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(168, 32);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(108, 19);
            this.materialLabel1.TabIndex = 96;
            this.materialLabel1.Text = "Measuring Unit";
            // 
            // cmbMeasuringUnit
            // 
            this.cmbMeasuringUnit.AutoResize = false;
            this.cmbMeasuringUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbMeasuringUnit.Depth = 0;
            this.cmbMeasuringUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbMeasuringUnit.DropDownHeight = 174;
            this.cmbMeasuringUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMeasuringUnit.DropDownWidth = 121;
            this.cmbMeasuringUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbMeasuringUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbMeasuringUnit.FormattingEnabled = true;
            this.cmbMeasuringUnit.Hint = "Choose measuring unit";
            this.cmbMeasuringUnit.IntegralHeight = false;
            this.cmbMeasuringUnit.ItemHeight = 43;
            this.cmbMeasuringUnit.Items.AddRange(new object[] {
            "g",
            "ml"});
            this.cmbMeasuringUnit.Location = new System.Drawing.Point(168, 56);
            this.cmbMeasuringUnit.MaxDropDownItems = 4;
            this.cmbMeasuringUnit.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbMeasuringUnit.Name = "cmbMeasuringUnit";
            this.cmbMeasuringUnit.Size = new System.Drawing.Size(247, 49);
            this.cmbMeasuringUnit.StartIndex = 0;
            this.cmbMeasuringUnit.TabIndex = 97;
            this.toolTip1.SetToolTip(this.cmbMeasuringUnit, "The unit of measurement used for the ingredient (e.g., grams, kilograms, liters, " +
        "cups).");
            // 
            // numericUpDownAddOnPrice
            // 
            this.numericUpDownAddOnPrice.DecimalPlaces = 2;
            this.numericUpDownAddOnPrice.Location = new System.Drawing.Point(160, 207);
            this.numericUpDownAddOnPrice.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownAddOnPrice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownAddOnPrice.Name = "numericUpDownAddOnPrice";
            this.numericUpDownAddOnPrice.Size = new System.Drawing.Size(120, 26);
            this.numericUpDownAddOnPrice.TabIndex = 98;
            this.numericUpDownAddOnPrice.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // cmbAddOnFor
            // 
            this.cmbAddOnFor.FormattingEnabled = true;
            this.cmbAddOnFor.Location = new System.Drawing.Point(289, 208);
            this.cmbAddOnFor.Name = "cmbAddOnFor";
            this.cmbAddOnFor.Size = new System.Drawing.Size(121, 28);
            this.cmbAddOnFor.TabIndex = 99;
            // 
            // chkIsAddOn
            // 
            this.chkIsAddOn.AutoSize = true;
            this.chkIsAddOn.Depth = 0;
            this.chkIsAddOn.Location = new System.Drawing.Point(40, 200);
            this.chkIsAddOn.Margin = new System.Windows.Forms.Padding(0);
            this.chkIsAddOn.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkIsAddOn.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkIsAddOn.Name = "chkIsAddOn";
            this.chkIsAddOn.ReadOnly = false;
            this.chkIsAddOn.Ripple = true;
            this.chkIsAddOn.Size = new System.Drawing.Size(85, 37);
            this.chkIsAddOn.TabIndex = 0;
            this.chkIsAddOn.Text = "Add-on";
            this.toolTip1.SetToolTip(this.chkIsAddOn, " flag to indicate whether the ingredient is considered an add-on (e.g., toppings " +
        "or extras like boba, ice cream) or a core ingredient.");
            this.chkIsAddOn.UseVisualStyleBackColor = true;
            // 
            // groupBoxImage
            // 
            this.groupBoxImage.Controls.Add(this.btnResetIngredientImg);
            this.groupBoxImage.Controls.Add(this.btnBrowseForIngredientImg);
            this.groupBoxImage.Controls.Add(this.pictureBoxImg);
            this.groupBoxImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBoxImage.Location = new System.Drawing.Point(20, 376);
            this.groupBoxImage.Name = "groupBoxImage";
            this.groupBoxImage.Size = new System.Drawing.Size(384, 324);
            this.groupBoxImage.TabIndex = 73;
            this.groupBoxImage.TabStop = false;
            this.groupBoxImage.Text = "Image";
            // 
            // btnResetIngredientImg
            // 
            this.btnResetIngredientImg.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnResetIngredientImg.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnResetIngredientImg.Depth = 0;
            this.btnResetIngredientImg.HighEmphasis = true;
            this.btnResetIngredientImg.Icon = null;
            this.btnResetIngredientImg.Location = new System.Drawing.Point(210, 207);
            this.btnResetIngredientImg.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnResetIngredientImg.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnResetIngredientImg.Name = "btnResetIngredientImg";
            this.btnResetIngredientImg.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnResetIngredientImg.Size = new System.Drawing.Size(65, 36);
            this.btnResetIngredientImg.TabIndex = 5;
            this.btnResetIngredientImg.Text = "Reset";
            this.btnResetIngredientImg.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnResetIngredientImg.UseAccentColor = false;
            this.btnResetIngredientImg.UseVisualStyleBackColor = true;
            this.btnResetIngredientImg.Click += new System.EventHandler(this.btnResetIngredientImg_Click);
            // 
            // btnBrowseForIngredientImg
            // 
            this.btnBrowseForIngredientImg.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBrowseForIngredientImg.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnBrowseForIngredientImg.Depth = 0;
            this.btnBrowseForIngredientImg.HighEmphasis = true;
            this.btnBrowseForIngredientImg.Icon = null;
            this.btnBrowseForIngredientImg.Location = new System.Drawing.Point(114, 207);
            this.btnBrowseForIngredientImg.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBrowseForIngredientImg.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBrowseForIngredientImg.Name = "btnBrowseForIngredientImg";
            this.btnBrowseForIngredientImg.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnBrowseForIngredientImg.Size = new System.Drawing.Size(88, 36);
            this.btnBrowseForIngredientImg.TabIndex = 4;
            this.btnBrowseForIngredientImg.Text = "Browse..";
            this.btnBrowseForIngredientImg.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnBrowseForIngredientImg.UseAccentColor = false;
            this.btnBrowseForIngredientImg.UseVisualStyleBackColor = true;
            this.btnBrowseForIngredientImg.Click += new System.EventHandler(this.btnBrowseForIngredientImg_Click);
            // 
            // pictureBoxImg
            // 
            this.pictureBoxImg.Image = global::TakoTea.Views.Properties.Resources.restart1;
            this.pictureBoxImg.Location = new System.Drawing.Point(77, 33);
            this.pictureBoxImg.Name = "pictureBoxImg";
            this.pictureBoxImg.Size = new System.Drawing.Size(246, 166);
            this.pictureBoxImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImg.TabIndex = 3;
            this.pictureBoxImg.TabStop = false;
            // 
            // groupBoxBasicInfo
            // 
            this.groupBoxBasicInfo.Controls.Add(this.materialLabel10);
            this.groupBoxBasicInfo.Controls.Add(this.cmbboxStorageCondition);
            this.groupBoxBasicInfo.Controls.Add(this.cmbTypeOfIngredient);
            this.groupBoxBasicInfo.Controls.Add(this.materialLabel11);
            this.groupBoxBasicInfo.Controls.Add(this.txtBoxItemDescription);
            this.groupBoxBasicInfo.Controls.Add(this.materialLabel4);
            this.groupBoxBasicInfo.Controls.Add(this.txtBoxBrandName);
            this.groupBoxBasicInfo.Controls.Add(this.materialLabel2);
            this.groupBoxBasicInfo.Controls.Add(this.txtBoxName);
            this.groupBoxBasicInfo.Controls.Add(this.materialLabel13);
            this.groupBoxBasicInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBoxBasicInfo.Location = new System.Drawing.Point(20, 10);
            this.groupBoxBasicInfo.Name = "groupBoxBasicInfo";
            this.groupBoxBasicInfo.Size = new System.Drawing.Size(810, 334);
            this.groupBoxBasicInfo.TabIndex = 72;
            this.groupBoxBasicInfo.TabStop = false;
            this.groupBoxBasicInfo.Text = "Basic Ingredient Information:";
            // 
            // materialLabel10
            // 
            this.materialLabel10.AutoSize = true;
            this.materialLabel10.Depth = 0;
            this.materialLabel10.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel10.Location = new System.Drawing.Point(400, 229);
            this.materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel10.Name = "materialLabel10";
            this.materialLabel10.Size = new System.Drawing.Size(136, 19);
            this.materialLabel10.TabIndex = 61;
            this.materialLabel10.Text = "Storage Conditions";
            // 
            // cmbboxStorageCondition
            // 
            this.cmbboxStorageCondition.AutoResize = false;
            this.cmbboxStorageCondition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbboxStorageCondition.Depth = 0;
            this.cmbboxStorageCondition.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbboxStorageCondition.DropDownHeight = 174;
            this.cmbboxStorageCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbboxStorageCondition.DropDownWidth = 121;
            this.cmbboxStorageCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbboxStorageCondition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbboxStorageCondition.FormattingEnabled = true;
            this.cmbboxStorageCondition.Hint = "Select storage condition";
            this.cmbboxStorageCondition.IntegralHeight = false;
            this.cmbboxStorageCondition.ItemHeight = 43;
            this.cmbboxStorageCondition.Items.AddRange(new object[] {
            "Store in a cool, dry place",
            "Refrigerate after opening",
            "Keep frozen"});
            this.cmbboxStorageCondition.Location = new System.Drawing.Point(400, 264);
            this.cmbboxStorageCondition.MaxDropDownItems = 4;
            this.cmbboxStorageCondition.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbboxStorageCondition.Name = "cmbboxStorageCondition";
            this.cmbboxStorageCondition.Size = new System.Drawing.Size(330, 49);
            this.cmbboxStorageCondition.StartIndex = 0;
            this.cmbboxStorageCondition.TabIndex = 62;
            // 
            // cmbTypeOfIngredient
            // 
            this.cmbTypeOfIngredient.AutoResize = false;
            this.cmbTypeOfIngredient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbTypeOfIngredient.Depth = 0;
            this.cmbTypeOfIngredient.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbTypeOfIngredient.DropDownHeight = 174;
            this.cmbTypeOfIngredient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeOfIngredient.DropDownWidth = 121;
            this.cmbTypeOfIngredient.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbTypeOfIngredient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbTypeOfIngredient.FormattingEnabled = true;
            this.cmbTypeOfIngredient.Hint = "Choose ingredient type";
            this.cmbTypeOfIngredient.IntegralHeight = false;
            this.cmbTypeOfIngredient.ItemHeight = 43;
            this.cmbTypeOfIngredient.Items.AddRange(new object[] {
            "Base Ingredient",
            "Add-on",
            "Flavoring",
            "Topping"});
            this.cmbTypeOfIngredient.Location = new System.Drawing.Point(16, 264);
            this.cmbTypeOfIngredient.MaxDropDownItems = 4;
            this.cmbTypeOfIngredient.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbTypeOfIngredient.Name = "cmbTypeOfIngredient";
            this.cmbTypeOfIngredient.Size = new System.Drawing.Size(360, 49);
            this.cmbTypeOfIngredient.StartIndex = 0;
            this.cmbTypeOfIngredient.TabIndex = 74;
            this.toolTip1.SetToolTip(this.cmbTypeOfIngredient, "The type of ingredient (e.g., Dairy, Fruit, Grain).");
            // 
            // materialLabel11
            // 
            this.materialLabel11.AutoSize = true;
            this.materialLabel11.Depth = 0;
            this.materialLabel11.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel11.Location = new System.Drawing.Point(16, 229);
            this.materialLabel11.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel11.Name = "materialLabel11";
            this.materialLabel11.Size = new System.Drawing.Size(131, 19);
            this.materialLabel11.TabIndex = 73;
            this.materialLabel11.Text = "Type Of Ingredient";
            // 
            // txtBoxItemDescription
            // 
            this.txtBoxItemDescription.AnimateReadOnly = false;
            this.txtBoxItemDescription.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtBoxItemDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBoxItemDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBoxItemDescription.Depth = 0;
            this.txtBoxItemDescription.HideSelection = true;
            this.txtBoxItemDescription.Hint = "Edit Descriptions...";
            this.txtBoxItemDescription.Location = new System.Drawing.Point(399, 66);
            this.txtBoxItemDescription.MaxLength = 32767;
            this.txtBoxItemDescription.MouseState = MaterialSkin.MouseState.OUT;
            this.txtBoxItemDescription.Name = "txtBoxItemDescription";
            this.txtBoxItemDescription.PasswordChar = '\0';
            this.txtBoxItemDescription.ReadOnly = false;
            this.txtBoxItemDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBoxItemDescription.SelectedText = "";
            this.txtBoxItemDescription.SelectionLength = 0;
            this.txtBoxItemDescription.SelectionStart = 0;
            this.txtBoxItemDescription.ShortcutsEnabled = true;
            this.txtBoxItemDescription.Size = new System.Drawing.Size(405, 140);
            this.txtBoxItemDescription.TabIndex = 65;
            this.txtBoxItemDescription.TabStop = false;
            this.txtBoxItemDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBoxItemDescription.UseSystemPasswordChar = false;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.Location = new System.Drawing.Point(399, 31);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(81, 19);
            this.materialLabel4.TabIndex = 58;
            this.materialLabel4.Text = "Description";
            // 
            // txtBoxBrandName
            // 
            this.txtBoxBrandName.AnimateReadOnly = false;
            this.txtBoxBrandName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtBoxBrandName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBoxBrandName.Depth = 0;
            this.txtBoxBrandName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtBoxBrandName.HideSelection = true;
            this.txtBoxBrandName.Hint = "e.g., \"Bear Brand\", \"inJoy\"";
            this.txtBoxBrandName.LeadingIcon = null;
            this.txtBoxBrandName.Location = new System.Drawing.Point(16, 66);
            this.txtBoxBrandName.MaxLength = 32767;
            this.txtBoxBrandName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtBoxBrandName.Name = "txtBoxBrandName";
            this.txtBoxBrandName.PasswordChar = '\0';
            this.txtBoxBrandName.PrefixSuffixText = null;
            this.txtBoxBrandName.ReadOnly = false;
            this.txtBoxBrandName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBoxBrandName.SelectedText = "";
            this.txtBoxBrandName.SelectionLength = 0;
            this.txtBoxBrandName.SelectionStart = 0;
            this.txtBoxBrandName.ShortcutsEnabled = true;
            this.txtBoxBrandName.Size = new System.Drawing.Size(359, 48);
            this.txtBoxBrandName.TabIndex = 55;
            this.txtBoxBrandName.TabStop = false;
            this.txtBoxBrandName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBoxBrandName.TrailingIcon = null;
            this.txtBoxBrandName.UseSystemPasswordChar = false;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(16, 31);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(89, 19);
            this.materialLabel2.TabIndex = 59;
            this.materialLabel2.Text = "Brand Name";
            // 
            // txtBoxName
            // 
            this.txtBoxName.AnimateReadOnly = false;
            this.txtBoxName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtBoxName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBoxName.Depth = 0;
            this.txtBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtBoxName.HideSelection = true;
            this.txtBoxName.Hint = "e.g., \"Flour\", \"Sugar\", \"Milk\"";
            this.txtBoxName.LeadingIcon = null;
            this.txtBoxName.Location = new System.Drawing.Point(16, 165);
            this.txtBoxName.MaxLength = 32767;
            this.txtBoxName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.PasswordChar = '\0';
            this.txtBoxName.PrefixSuffixText = null;
            this.txtBoxName.ReadOnly = false;
            this.txtBoxName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBoxName.SelectedText = "";
            this.txtBoxName.SelectionLength = 0;
            this.txtBoxName.SelectionStart = 0;
            this.txtBoxName.ShortcutsEnabled = true;
            this.txtBoxName.Size = new System.Drawing.Size(359, 48);
            this.txtBoxName.TabIndex = 70;
            this.txtBoxName.TabStop = false;
            this.txtBoxName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBoxName.TrailingIcon = null;
            this.txtBoxName.UseSystemPasswordChar = false;
            // 
            // materialLabel13
            // 
            this.materialLabel13.AutoSize = true;
            this.materialLabel13.Depth = 0;
            this.materialLabel13.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel13.Location = new System.Drawing.Point(16, 130);
            this.materialLabel13.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel13.Name = "materialLabel13";
            this.materialLabel13.Size = new System.Drawing.Size(162, 19);
            this.materialLabel13.TabIndex = 71;
            this.materialLabel13.Text = "Name of the ingredient";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnConfirmEdit);
            this.panel3.Controls.Add(this.btnCancelEdit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(14, 752);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(858, 58);
            this.panel3.TabIndex = 102;
            // 
            // btnConfirmEdit
            // 
            this.btnConfirmEdit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnConfirmEdit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnConfirmEdit.Depth = 0;
            this.btnConfirmEdit.HighEmphasis = true;
            this.btnConfirmEdit.Icon = null;
            this.btnConfirmEdit.Location = new System.Drawing.Point(688, 8);
            this.btnConfirmEdit.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnConfirmEdit.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnConfirmEdit.Name = "btnConfirmEdit";
            this.btnConfirmEdit.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnConfirmEdit.Size = new System.Drawing.Size(64, 36);
            this.btnConfirmEdit.TabIndex = 53;
            this.btnConfirmEdit.Text = "Add";
            this.btnConfirmEdit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnConfirmEdit.UseAccentColor = false;
            this.btnConfirmEdit.UseVisualStyleBackColor = true;
            this.btnConfirmEdit.Click += new System.EventHandler(this.btnConfirmEdit_Click_1);
            // 
            // btnCancelEdit
            // 
            this.btnCancelEdit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancelEdit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancelEdit.Depth = 0;
            this.btnCancelEdit.HighEmphasis = true;
            this.btnCancelEdit.Icon = null;
            this.btnCancelEdit.Location = new System.Drawing.Point(760, 8);
            this.btnCancelEdit.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancelEdit.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancelEdit.Name = "btnCancelEdit";
            this.btnCancelEdit.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancelEdit.Size = new System.Drawing.Size(77, 36);
            this.btnCancelEdit.TabIndex = 54;
            this.btnCancelEdit.Text = "Cancel";
            this.btnCancelEdit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancelEdit.UseAccentColor = true;
            this.btnCancelEdit.UseVisualStyleBackColor = true;
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
            this.materialLabel5.Location = new System.Drawing.Point(359, 10);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(131, 24);
            this.materialLabel5.TabIndex = 0;
            this.materialLabel5.Text = "Edit Ingredient";
            // 
            // EditIngredientModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 851);
            this.Controls.Add(this.panel1);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.Name = "EditIngredientModal";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.Text = "AddItemModal";
            this.panel1.ResumeLayout(false);
            this.materialCard1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBoxOther.ResumeLayout(false);
            this.groupBoxOther.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLowStockThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantityUsedPerProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAddOnPrice)).EndInit();
            this.groupBoxImage.ResumeLayout(false);
            this.groupBoxImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImg)).EndInit();
            this.groupBoxBasicInfo.ResumeLayout(false);
            this.groupBoxBasicInfo.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private System.Windows.Forms.Panel panel4;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 txtBoxItemDescription;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialTextBox2 txtBoxBrandName;
        private System.Windows.Forms.Panel panel3;
        private MaterialSkin.Controls.MaterialButton btnConfirmEdit;
        private MaterialSkin.Controls.MaterialButton btnCancelEdit;
        private MaterialSkin.Controls.MaterialLabel materialLabel10;
        private MaterialSkin.Controls.MaterialComboBox cmbboxStorageCondition;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBoxBasicInfo;
        private MaterialSkin.Controls.MaterialTextBox2 txtBoxName;
        private MaterialSkin.Controls.MaterialLabel materialLabel13;
        private MaterialSkin.Controls.MaterialComboBox cmbTypeOfIngredient;
        private MaterialSkin.Controls.MaterialLabel materialLabel11;
        private System.Windows.Forms.GroupBox groupBoxOther;
        private MaterialSkin.Controls.MaterialCheckbox chkIsAddOn;
        private System.Windows.Forms.ComboBox cmbAddOnFor;
        private System.Windows.Forms.NumericUpDown numericUpDownAddOnPrice;
        private MaterialSkin.Controls.MaterialComboBox cmbMeasuringUnit;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.CheckedListBox materialCheckedListBoxAllergens;
        private MaterialSkin.Controls.MaterialLabel lblAddOnFor;
        private MaterialSkin.Controls.MaterialLabel lblAdditionalPrice;
        private MaterialSkin.Controls.MaterialLabel materialLabel12;
        private System.Windows.Forms.GroupBox groupBoxImage;
        private MaterialSkin.Controls.MaterialButton btnResetIngredientImg;
        private MaterialSkin.Controls.MaterialButton btnBrowseForIngredientImg;
        private System.Windows.Forms.PictureBox pictureBoxImg;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantityUsedPerProduct;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private System.Windows.Forms.NumericUpDown numericUpDownLowStockThreshold;
    }
}
