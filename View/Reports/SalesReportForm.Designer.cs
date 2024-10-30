namespace TakoTea.View.Reports
{
    partial class SalesReportForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelSalesReports = new System.Windows.Forms.Label();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.buttonGenerateReport = new System.Windows.Forms.Button();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.panelSummaryBox = new System.Windows.Forms.Panel();
            this.labelSummaryText = new System.Windows.Forms.Label();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialRadioButton1 = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialRadioButton2 = new MaterialSkin.Controls.MaterialRadioButton();
            this.panel1.SuspendLayout();
            this.panelSummaryBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.materialRadioButton2);
            this.panel1.Controls.Add(this.materialRadioButton1);
            this.panel1.Controls.Add(this.materialLabel1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labelSalesReports);
            this.panel1.Controls.Add(this.comboBoxCategory);
            this.panel1.Controls.Add(this.dateTimePickerFrom);
            this.panel1.Controls.Add(this.dateTimePickerTo);
            this.panel1.Controls.Add(this.buttonGenerateReport);
            this.panel1.Controls.Add(this.buttonDownload);
            this.panel1.Controls.Add(this.panelSummaryBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(908, 600);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(20, 236);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(868, 145);
            this.panel2.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(298, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "To:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(20, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "From:";
            // 
            // labelSalesReports
            // 
            this.labelSalesReports.AutoSize = true;
            this.labelSalesReports.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.labelSalesReports.ForeColor = System.Drawing.Color.White;
            this.labelSalesReports.Location = new System.Drawing.Point(17, 12);
            this.labelSalesReports.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSalesReports.Name = "labelSalesReports";
            this.labelSalesReports.Size = new System.Drawing.Size(0, 22);
            this.labelSalesReports.TabIndex = 24;
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategory.ForeColor = System.Drawing.SystemColors.MenuText;
            this.comboBoxCategory.Location = new System.Drawing.Point(21, 51);
            this.comboBoxCategory.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(114, 21);
            this.comboBoxCategory.TabIndex = 25;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(17, 103);
            this.dateTimePickerFrom.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(270, 20);
            this.dateTimePickerFrom.TabIndex = 28;
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTo.Location = new System.Drawing.Point(291, 103);
            this.dateTimePickerTo.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(270, 20);
            this.dateTimePickerTo.TabIndex = 29;
            // 
            // buttonGenerateReport
            // 
            this.buttonGenerateReport.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonGenerateReport.ForeColor = System.Drawing.Color.White;
            this.buttonGenerateReport.Location = new System.Drawing.Point(692, 89);
            this.buttonGenerateReport.Margin = new System.Windows.Forms.Padding(2);
            this.buttonGenerateReport.Name = "buttonGenerateReport";
            this.buttonGenerateReport.Size = new System.Drawing.Size(112, 48);
            this.buttonGenerateReport.TabIndex = 30;
            this.buttonGenerateReport.Text = "Generate Report";
            this.buttonGenerateReport.UseVisualStyleBackColor = false;
            // 
            // buttonDownload
            // 
            this.buttonDownload.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonDownload.ForeColor = System.Drawing.Color.White;
            this.buttonDownload.Location = new System.Drawing.Point(813, 89);
            this.buttonDownload.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(75, 48);
            this.buttonDownload.TabIndex = 31;
            this.buttonDownload.Text = "Download";
            this.buttonDownload.UseVisualStyleBackColor = false;
            // 
            // panelSummaryBox
            // 
            this.panelSummaryBox.BackColor = System.Drawing.Color.Transparent;
            this.panelSummaryBox.Controls.Add(this.labelSummaryText);
            this.panelSummaryBox.Location = new System.Drawing.Point(17, 141);
            this.panelSummaryBox.Margin = new System.Windows.Forms.Padding(2);
            this.panelSummaryBox.Name = "panelSummaryBox";
            this.panelSummaryBox.Size = new System.Drawing.Size(871, 65);
            this.panelSummaryBox.TabIndex = 32;
            // 
            // labelSummaryText
            // 
            this.labelSummaryText.ForeColor = System.Drawing.Color.White;
            this.labelSummaryText.Location = new System.Drawing.Point(8, 6);
            this.labelSummaryText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSummaryText.Name = "labelSummaryText";
            this.labelSummaryText.Size = new System.Drawing.Size(75, 15);
            this.labelSummaryText.TabIndex = 0;
            this.labelSummaryText.Text = "Summary Box\nTotal Sales: ₱25,000\nAverage Order Value: ₱125\nNumber of Transactions" +
    ": 200\nTotal Refunds: ₱1,500";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.materialLabel1.Location = new System.Drawing.Point(20, 12);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(148, 29);
            this.materialLabel1.TabIndex = 36;
            this.materialLabel1.Text = "Sales Reports";
            // 
            // materialRadioButton1
            // 
            this.materialRadioButton1.AutoSize = true;
            this.materialRadioButton1.Depth = 0;
            this.materialRadioButton1.Location = new System.Drawing.Point(361, 51);
            this.materialRadioButton1.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton1.Name = "materialRadioButton1";
            this.materialRadioButton1.Ripple = true;
            this.materialRadioButton1.Size = new System.Drawing.Size(178, 37);
            this.materialRadioButton1.TabIndex = 37;
            this.materialRadioButton1.TabStop = true;
            this.materialRadioButton1.Text = "Average Order Value";
            this.materialRadioButton1.UseVisualStyleBackColor = true;
            // 
            // materialRadioButton2
            // 
            this.materialRadioButton2.AutoSize = true;
            this.materialRadioButton2.Depth = 0;
            this.materialRadioButton2.Location = new System.Drawing.Point(206, 51);
            this.materialRadioButton2.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton2.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton2.Name = "materialRadioButton2";
            this.materialRadioButton2.Ripple = true;
            this.materialRadioButton2.Size = new System.Drawing.Size(115, 37);
            this.materialRadioButton2.TabIndex = 38;
            this.materialRadioButton2.TabStop = true;
            this.materialRadioButton2.Text = "Total Sales";
            this.materialRadioButton2.UseVisualStyleBackColor = true;
            // 
            // SalesReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 603);
            this.Controls.Add(this.panel1);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Name = "SalesReportForm";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.Text = "SalesReportForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelSummaryBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelSalesReports;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Button buttonGenerateReport;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.Panel panelSummaryBox;
        private System.Windows.Forms.Label labelSummaryText;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton2;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton1;
    }
}