using MaterialSkin.Controls;
using System.Windows.Forms;
namespace TakoTea.Views.Stock.Stock_Modal
{
    partial class EditStockModal
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grpIngredientDetails = new System.Windows.Forms.GroupBox();
            this.lblIngredient = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCurrentQuantity = new System.Windows.Forms.Label();
            this.txtBoxBatchNumber = new System.Windows.Forms.TextBox();
            this.txtBoxIngredientName = new System.Windows.Forms.TextBox();
            this.txtCurrentQuantity = new System.Windows.Forms.TextBox();
            this.grpStockAdjustment = new System.Windows.Forms.GroupBox();
            this.lblNewQuantity = new System.Windows.Forms.Label();
            this.numNewQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblAdjustmentType = new System.Windows.Forms.Label();
            this.cmbAdjustmentType = new System.Windows.Forms.ComboBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.grpIngredientDetails.SuspendLayout();
            this.grpStockAdjustment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNewQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // grpIngredientDetails
            // 
            this.grpIngredientDetails.Controls.Add(this.lblIngredient);
            this.grpIngredientDetails.Controls.Add(this.label1);
            this.grpIngredientDetails.Controls.Add(this.lblCurrentQuantity);
            this.grpIngredientDetails.Controls.Add(this.txtBoxBatchNumber);
            this.grpIngredientDetails.Controls.Add(this.txtBoxIngredientName);
            this.grpIngredientDetails.Controls.Add(this.txtCurrentQuantity);
            this.grpIngredientDetails.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.grpIngredientDetails.Location = new System.Drawing.Point(20, 20);
            this.grpIngredientDetails.Name = "grpIngredientDetails";
            this.grpIngredientDetails.Size = new System.Drawing.Size(360, 140);
            this.grpIngredientDetails.TabIndex = 0;
            this.grpIngredientDetails.TabStop = false;
            this.grpIngredientDetails.Text = "Batch Details";
            // 
            // lblIngredient
            // 
            this.lblIngredient.AutoSize = true;
            this.lblIngredient.Font = new System.Drawing.Font("Arial", 9F);
            this.lblIngredient.Location = new System.Drawing.Point(15, 30);
            this.lblIngredient.Name = "lblIngredient";
            this.lblIngredient.Size = new System.Drawing.Size(51, 15);
            this.lblIngredient.TabIndex = 0;
            this.lblIngredient.Text = "Batch #:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.Location = new System.Drawing.Point(16, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ingredient Name:";
            // 
            // lblCurrentQuantity
            // 
            this.lblCurrentQuantity.AutoSize = true;
            this.lblCurrentQuantity.Font = new System.Drawing.Font("Arial", 9F);
            this.lblCurrentQuantity.Location = new System.Drawing.Point(15, 96);
            this.lblCurrentQuantity.Name = "lblCurrentQuantity";
            this.lblCurrentQuantity.Size = new System.Drawing.Size(98, 15);
            this.lblCurrentQuantity.TabIndex = 2;
            this.lblCurrentQuantity.Text = "Current Quantity:";
            // 
            // txtBoxBatchNumber
            // 
            this.txtBoxBatchNumber.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxBatchNumber.Location = new System.Drawing.Point(80, 30);
            this.txtBoxBatchNumber.Name = "txtBoxBatchNumber";
            this.txtBoxBatchNumber.ReadOnly = true;
            this.txtBoxBatchNumber.Size = new System.Drawing.Size(240, 22);
            this.txtBoxBatchNumber.TabIndex = 3;
            // 
            // txtBoxIngredientName
            // 
            this.txtBoxIngredientName.Font = new System.Drawing.Font("Arial", 9F);
            this.txtBoxIngredientName.Location = new System.Drawing.Point(128, 64);
            this.txtBoxIngredientName.Name = "txtBoxIngredientName";
            this.txtBoxIngredientName.ReadOnly = true;
            this.txtBoxIngredientName.Size = new System.Drawing.Size(190, 21);
            this.txtBoxIngredientName.TabIndex = 3;
            // 
            // txtCurrentQuantity
            // 
            this.txtCurrentQuantity.Font = new System.Drawing.Font("Arial", 9F);
            this.txtCurrentQuantity.Location = new System.Drawing.Point(130, 96);
            this.txtCurrentQuantity.Name = "txtCurrentQuantity";
            this.txtCurrentQuantity.ReadOnly = true;
            this.txtCurrentQuantity.Size = new System.Drawing.Size(190, 21);
            this.txtCurrentQuantity.TabIndex = 3;
            this.toolTip.SetToolTip(this.txtCurrentQuantity, "Displays the current quantity in stock.");
            // 
            // grpStockAdjustment
            // 
            this.grpStockAdjustment.Controls.Add(this.lblNewQuantity);
            this.grpStockAdjustment.Controls.Add(this.numNewQuantity);
            this.grpStockAdjustment.Controls.Add(this.lblAdjustmentType);
            this.grpStockAdjustment.Controls.Add(this.cmbAdjustmentType);
            this.grpStockAdjustment.Controls.Add(this.lblReason);
            this.grpStockAdjustment.Controls.Add(this.txtReason);
            this.grpStockAdjustment.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.grpStockAdjustment.Location = new System.Drawing.Point(20, 176);
            this.grpStockAdjustment.Name = "grpStockAdjustment";
            this.grpStockAdjustment.Size = new System.Drawing.Size(360, 150);
            this.grpStockAdjustment.TabIndex = 1;
            this.grpStockAdjustment.TabStop = false;
            this.grpStockAdjustment.Text = "Stock Adjustment";
            // 
            // lblNewQuantity
            // 
            this.lblNewQuantity.AutoSize = true;
            this.lblNewQuantity.Font = new System.Drawing.Font("Arial", 9F);
            this.lblNewQuantity.Location = new System.Drawing.Point(15, 30);
            this.lblNewQuantity.Name = "lblNewQuantity";
            this.lblNewQuantity.Size = new System.Drawing.Size(82, 15);
            this.lblNewQuantity.TabIndex = 0;
            this.lblNewQuantity.Text = "New Quantity:";
            // 
            // numNewQuantity
            // 
            this.numNewQuantity.DecimalPlaces = 1;
            this.numNewQuantity.Font = new System.Drawing.Font("Arial", 9F);
            this.numNewQuantity.Location = new System.Drawing.Point(130, 30);
            this.numNewQuantity.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numNewQuantity.Name = "numNewQuantity";
            this.numNewQuantity.Size = new System.Drawing.Size(190, 21);
            this.numNewQuantity.TabIndex = 1;
            this.toolTip.SetToolTip(this.numNewQuantity, "Enter the new stock level for the selected ingredient.");
            // 
            // lblAdjustmentType
            // 
            this.lblAdjustmentType.AutoSize = true;
            this.lblAdjustmentType.Font = new System.Drawing.Font("Arial", 9F);
            this.lblAdjustmentType.Location = new System.Drawing.Point(15, 65);
            this.lblAdjustmentType.Name = "lblAdjustmentType";
            this.lblAdjustmentType.Size = new System.Drawing.Size(100, 15);
            this.lblAdjustmentType.TabIndex = 2;
            this.lblAdjustmentType.Text = "Adjustment Type:";
            // 
            // cmbAdjustmentType
            // 
            this.cmbAdjustmentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAdjustmentType.Font = new System.Drawing.Font("Arial", 9F);
            this.cmbAdjustmentType.Items.AddRange(new object[] {
            "Restock",
            "Correction",
            "Usage"});
            this.cmbAdjustmentType.Location = new System.Drawing.Point(130, 65);
            this.cmbAdjustmentType.Name = "cmbAdjustmentType";
            this.cmbAdjustmentType.Size = new System.Drawing.Size(190, 23);
            this.cmbAdjustmentType.TabIndex = 3;
            this.toolTip.SetToolTip(this.cmbAdjustmentType, "Choose the type of adjustment (e.g., Restock, Correction).");
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Arial", 9F);
            this.lblReason.Location = new System.Drawing.Point(15, 100);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(54, 15);
            this.lblReason.TabIndex = 4;
            this.lblReason.Text = "Reason:";
            // 
            // txtReason
            // 
            this.txtReason.Font = new System.Drawing.Font("Arial", 9F);
            this.txtReason.Location = new System.Drawing.Point(130, 100);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(190, 30);
            this.txtReason.TabIndex = 5;
            this.toolTip.SetToolTip(this.txtReason, "Provide a reason for the adjustment.");
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(140, 344);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 35);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.IndianRed;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(240, 344);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 35);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // EditStockModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(385, 404);
            this.Controls.Add(this.grpIngredientDetails);
            this.Controls.Add(this.grpStockAdjustment);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EditStockModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Stock Level";
            this.Load += new System.EventHandler(this.EditStockModal_Load);
            this.grpIngredientDetails.ResumeLayout(false);
            this.grpIngredientDetails.PerformLayout();
            this.grpStockAdjustment.ResumeLayout(false);
            this.grpStockAdjustment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNewQuantity)).EndInit();
            this.ResumeLayout(false);

        }
        public GroupBox grpIngredientDetails;
        public Label lblIngredient;
        public ToolTip toolTip;
        public Label lblCurrentQuantity;
        public TextBox txtCurrentQuantity;
        public GroupBox grpStockAdjustment;
        public Label lblNewQuantity;
        public NumericUpDown numNewQuantity;
        public Label lblAdjustmentType;
        public ComboBox cmbAdjustmentType;
        public Label lblReason;
        public TextBox txtReason;
        public Button btnSave;
        public Button btnCancel;
        public TextBox txtBoxBatchNumber;
        public Label label1;
        public TextBox txtBoxIngredientName;
    }
}