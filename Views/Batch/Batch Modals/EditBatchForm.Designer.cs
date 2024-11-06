using System.Drawing;
using System.Windows.Forms;

namespace TakoTea.Views.Batch.Batch_Modals
{
    partial class EditBatchForm
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
            this.dgvIngredients = new System.Windows.Forms.DataGridView();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpBatchInfo.SuspendLayout();
            this.grpIngredients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).BeginInit();
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
            this.txtBatchNumber.ReadOnly = true;
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
            this.grpIngredients.Controls.Add(this.dgvIngredients);
            this.grpIngredients.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.grpIngredients.Location = new System.Drawing.Point(20, 170);
            this.grpIngredients.Name = "grpIngredients";
            this.grpIngredients.Size = new System.Drawing.Size(440, 150);
            this.grpIngredients.TabIndex = 1;
            this.grpIngredients.TabStop = false;
            this.grpIngredients.Text = "Ingredients and Quantities";
            // 
            // dgvIngredients
            // 
            this.dgvIngredients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIngredients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvIngredients.Location = new System.Drawing.Point(15, 30);
            this.dgvIngredients.Name = "dgvIngredients";
            this.dgvIngredients.Size = new System.Drawing.Size(415, 100);
            this.dgvIngredients.TabIndex = 0;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSaveChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveChanges.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveChanges.ForeColor = System.Drawing.Color.White;
            this.btnSaveChanges.Location = new System.Drawing.Point(190, 330);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(120, 40);
            this.btnSaveChanges.TabIndex = 2;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(330, 330);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 40);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Ingredient";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Quantity (g)";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // EditBatchForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(492, 395);
            this.Controls.Add(this.grpBatchInfo);
            this.Controls.Add(this.grpIngredients);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EditBatchForm";
            this.Text = "Edit Batch";
            this.grpBatchInfo.ResumeLayout(false);
            this.grpBatchInfo.PerformLayout();
            this.grpIngredients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).EndInit();
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
        private DataGridView dgvIngredients;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private Button btnSaveChanges;
        private Button btnCancel;
    }
}