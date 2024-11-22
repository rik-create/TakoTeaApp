using System.Drawing;
using System.Windows.Forms;
namespace TakoTea.Views.Batches.Batch_Modals
{
    partial class NewBatchForm
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
            this.grpBatchInfo = new System.Windows.Forms.GroupBox();
            this.lblBatchNumber = new System.Windows.Forms.Label();
            this.txtBatchNumber = new System.Windows.Forms.TextBox();
            this.lblManufactureDate = new System.Windows.Forms.Label();
            this.dtpManufactureDate = new System.Windows.Forms.DateTimePicker();
            this.lblExpirationDate = new System.Windows.Forms.Label();
            this.dtpExpirationDate = new System.Windows.Forms.DateTimePicker();
            this.grpIngredients = new System.Windows.Forms.GroupBox();
            this.lstIngredients = new System.Windows.Forms.ListBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAddIngredient = new System.Windows.Forms.Button();
            this.btnSaveBatch = new System.Windows.Forms.Button();
            this.grpBatchInfo.SuspendLayout();
            this.grpIngredients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBatchInfo
            // 
            this.grpBatchInfo.Controls.Add(this.lblBatchNumber);
            this.grpBatchInfo.Controls.Add(this.txtBatchNumber);
            this.grpBatchInfo.Controls.Add(this.lblManufactureDate);
            this.grpBatchInfo.Controls.Add(this.dtpManufactureDate);
            this.grpBatchInfo.Controls.Add(this.lblExpirationDate);
            this.grpBatchInfo.Controls.Add(this.dtpExpirationDate);
            this.grpBatchInfo.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.grpBatchInfo.Location = new System.Drawing.Point(20, 20);
            this.grpBatchInfo.Name = "grpBatchInfo";
            this.grpBatchInfo.Size = new System.Drawing.Size(440, 140);
            this.grpBatchInfo.TabIndex = 0;
            this.grpBatchInfo.TabStop = false;
            this.grpBatchInfo.Text = "Batch Information";
            // 
            // lblBatchNumber
            // 
            this.lblBatchNumber.AutoSize = true;
            this.lblBatchNumber.Location = new System.Drawing.Point(15, 30);
            this.lblBatchNumber.Name = "lblBatchNumber";
            this.lblBatchNumber.Size = new System.Drawing.Size(110, 16);
            this.lblBatchNumber.TabIndex = 0;
            this.lblBatchNumber.Text = "Batch Number:";
            // 
            // txtBatchNumber
            // 
            this.txtBatchNumber.Location = new System.Drawing.Point(180, 30);
            this.txtBatchNumber.Name = "txtBatchNumber";
            this.txtBatchNumber.Size = new System.Drawing.Size(250, 23);
            this.txtBatchNumber.TabIndex = 1;
            // 
            // lblManufactureDate
            // 
            this.lblManufactureDate.AutoSize = true;
            this.lblManufactureDate.Location = new System.Drawing.Point(15, 70);
            this.lblManufactureDate.Name = "lblManufactureDate";
            this.lblManufactureDate.Size = new System.Drawing.Size(136, 16);
            this.lblManufactureDate.TabIndex = 2;
            this.lblManufactureDate.Text = "Manufacture Date:";
            // 
            // dtpManufactureDate
            // 
            this.dtpManufactureDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpManufactureDate.Location = new System.Drawing.Point(180, 70);
            this.dtpManufactureDate.Name = "dtpManufactureDate";
            this.dtpManufactureDate.Size = new System.Drawing.Size(250, 23);
            this.dtpManufactureDate.TabIndex = 3;
            // 
            // lblExpirationDate
            // 
            this.lblExpirationDate.AutoSize = true;
            this.lblExpirationDate.Location = new System.Drawing.Point(15, 110);
            this.lblExpirationDate.Name = "lblExpirationDate";
            this.lblExpirationDate.Size = new System.Drawing.Size(118, 16);
            this.lblExpirationDate.TabIndex = 4;
            this.lblExpirationDate.Text = "Expiration Date:";
            // 
            // dtpExpirationDate
            // 
            this.dtpExpirationDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpirationDate.Location = new System.Drawing.Point(180, 110);
            this.dtpExpirationDate.Name = "dtpExpirationDate";
            this.dtpExpirationDate.Size = new System.Drawing.Size(250, 23);
            this.dtpExpirationDate.TabIndex = 5;
            // 
            // grpIngredients
            // 
            this.grpIngredients.Controls.Add(this.lstIngredients);
            this.grpIngredients.Controls.Add(this.lblQuantity);
            this.grpIngredients.Controls.Add(this.numQuantity);
            this.grpIngredients.Controls.Add(this.btnAddIngredient);
            this.grpIngredients.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.grpIngredients.Location = new System.Drawing.Point(20, 170);
            this.grpIngredients.Name = "grpIngredients";
            this.grpIngredients.Size = new System.Drawing.Size(400, 150);
            this.grpIngredients.TabIndex = 1;
            this.grpIngredients.TabStop = false;
            this.grpIngredients.Text = "Ingredients and Quantities";
            // 
            // lstIngredients
            // 
            this.lstIngredients.ItemHeight = 16;
            this.lstIngredients.Items.AddRange(new object[] {
            "Flour",
            "Milk",
            "Sugar",
            "Tapioca Pearls"});
            this.lstIngredients.Location = new System.Drawing.Point(20, 30);
            this.lstIngredients.Name = "lstIngredients";
            this.lstIngredients.Size = new System.Drawing.Size(180, 100);
            this.lstIngredients.TabIndex = 0;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(210, 30);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(92, 16);
            this.lblQuantity.TabIndex = 1;
            this.lblQuantity.Text = "Quantity (g):";
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(210, 60);
            this.numQuantity.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(150, 23);
            this.numQuantity.TabIndex = 2;
            // 
            // btnAddIngredient
            // 
            this.btnAddIngredient.Location = new System.Drawing.Point(210, 100);
            this.btnAddIngredient.Name = "btnAddIngredient";
            this.btnAddIngredient.Size = new System.Drawing.Size(150, 30);
            this.btnAddIngredient.TabIndex = 3;
            this.btnAddIngredient.Text = "Add to Batch";
            // 
            // btnSaveBatch
            // 
            this.btnSaveBatch.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSaveBatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveBatch.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveBatch.ForeColor = System.Drawing.Color.White;
            this.btnSaveBatch.Location = new System.Drawing.Point(300, 330);
            this.btnSaveBatch.Name = "btnSaveBatch";
            this.btnSaveBatch.Size = new System.Drawing.Size(120, 40);
            this.btnSaveBatch.TabIndex = 2;
            this.btnSaveBatch.Text = "Save Batch";
            this.btnSaveBatch.UseVisualStyleBackColor = false;
            // 
            // NewBatchForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(459, 392);
            this.Controls.Add(this.grpBatchInfo);
            this.Controls.Add(this.grpIngredients);
            this.Controls.Add(this.btnSaveBatch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "NewBatchForm";
            this.Text = "Add New Batch";
            this.grpBatchInfo.ResumeLayout(false);
            this.grpBatchInfo.PerformLayout();
            this.grpIngredients.ResumeLayout(false);
            this.grpIngredients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion
        private GroupBox grpBatchInfo;
        private Label lblBatchNumber;
        private TextBox txtBatchNumber;
        private Label lblManufactureDate;
        private DateTimePicker dtpManufactureDate;
        private Label lblExpirationDate;
        private DateTimePicker dtpExpirationDate;
        private GroupBox grpIngredients;
        private ListBox lstIngredients;
        private Label lblQuantity;
        private NumericUpDown numQuantity;
        private Button btnAddIngredient;
        private Button btnSaveBatch;
    }
}