using MaterialSkin.Controls;
using System.Windows.Forms;



namespace TakoTea.Views.reports
{

    partial class ReportingForm

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
            this.panelReports = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btnGenerateReport = new MaterialSkin.Controls.MaterialButton();
            this.groupBoxDateRange = new System.Windows.Forms.GroupBox();
            this.lblSearchHint = new System.Windows.Forms.Label();
            this.lblFilterHint = new System.Windows.Forms.Label();
            this.chkLowStockOnly = new System.Windows.Forms.CheckBox();
            this.cboDateRange = new MaterialSkin.Controls.MaterialComboBox();
            this.cboFilter = new MaterialSkin.Controls.MaterialComboBox();
            this.txtFilter = new MaterialSkin.Controls.MaterialTextBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.groupBoxReportSelection = new System.Windows.Forms.GroupBox();
            this.lstReportTypes = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialCard1.SuspendLayout();
            this.panelReports.SuspendLayout();
            this.groupBoxDateRange.SuspendLayout();
            this.groupBoxReportSelection.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.panelReports);
            this.materialCard1.Controls.Add(this.btnGenerateReport);
            this.materialCard1.Controls.Add(this.groupBoxDateRange);
            this.materialCard1.Controls.Add(this.groupBoxReportSelection);
            this.materialCard1.Controls.Add(this.panel1);
            this.materialCard1.Depth = 0;
            this.materialCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(3, 21);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(12);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(12);
            this.materialCard1.Size = new System.Drawing.Size(954, 699);
            this.materialCard1.TabIndex = 0;
            // 
            // panelReports
            // 
            this.panelReports.Controls.Add(this.webBrowser1);
            this.panelReports.Location = new System.Drawing.Point(16, 248);
            this.panelReports.Name = "panelReports";
            this.panelReports.Size = new System.Drawing.Size(920, 392);
            this.panelReports.TabIndex = 105;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(920, 392);
            this.webBrowser1.TabIndex = 0;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGenerateReport.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnGenerateReport.Depth = 0;
            this.btnGenerateReport.HighEmphasis = true;
            this.btnGenerateReport.Icon = null;
            this.btnGenerateReport.Location = new System.Drawing.Point(792, 648);
            this.btnGenerateReport.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnGenerateReport.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnGenerateReport.Size = new System.Drawing.Size(154, 36);
            this.btnGenerateReport.TabIndex = 104;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnGenerateReport.UseAccentColor = false;
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // groupBoxDateRange
            // 
            this.groupBoxDateRange.Controls.Add(this.lblSearchHint);
            this.groupBoxDateRange.Controls.Add(this.lblFilterHint);
            this.groupBoxDateRange.Controls.Add(this.chkLowStockOnly);
            this.groupBoxDateRange.Controls.Add(this.cboDateRange);
            this.groupBoxDateRange.Controls.Add(this.cboFilter);
            this.groupBoxDateRange.Controls.Add(this.txtFilter);
            this.groupBoxDateRange.Controls.Add(this.dtpEndDate);
            this.groupBoxDateRange.Controls.Add(this.materialLabel3);
            this.groupBoxDateRange.Controls.Add(this.dtpStartDate);
            this.groupBoxDateRange.Controls.Add(this.materialLabel2);
            this.groupBoxDateRange.Location = new System.Drawing.Point(291, 69);
            this.groupBoxDateRange.Name = "groupBoxDateRange";
            this.groupBoxDateRange.Size = new System.Drawing.Size(643, 163);
            this.groupBoxDateRange.TabIndex = 103;
            this.groupBoxDateRange.TabStop = false;
            this.groupBoxDateRange.Text = "Date Range";
            // 
            // lblSearchHint
            // 
            this.lblSearchHint.Location = new System.Drawing.Point(16, 96);
            this.lblSearchHint.Name = "lblSearchHint";
            this.lblSearchHint.Size = new System.Drawing.Size(216, 16);
            this.lblSearchHint.TabIndex = 115;
            this.lblSearchHint.Text = "label1";
            this.lblSearchHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFilterHint
            // 
            this.lblFilterHint.Location = new System.Drawing.Point(256, 96);
            this.lblFilterHint.Name = "lblFilterHint";
            this.lblFilterHint.Size = new System.Drawing.Size(240, 16);
            this.lblFilterHint.TabIndex = 114;
            this.lblFilterHint.Text = "label1";
            this.lblFilterHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkLowStockOnly
            // 
            this.chkLowStockOnly.AutoSize = true;
            this.chkLowStockOnly.Location = new System.Drawing.Point(528, 128);
            this.chkLowStockOnly.Name = "chkLowStockOnly";
            this.chkLowStockOnly.Size = new System.Drawing.Size(82, 17);
            this.chkLowStockOnly.TabIndex = 112;
            this.chkLowStockOnly.Text = "Low Stocks";
            this.chkLowStockOnly.UseVisualStyleBackColor = true;
            this.chkLowStockOnly.Visible = false;
            // 
            // cboDateRange
            // 
            this.cboDateRange.AutoResize = false;
            this.cboDateRange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboDateRange.Depth = 0;
            this.cboDateRange.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboDateRange.DropDownHeight = 118;
            this.cboDateRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDateRange.DropDownWidth = 121;
            this.cboDateRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboDateRange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cboDateRange.FormattingEnabled = true;
            this.cboDateRange.IntegralHeight = false;
            this.cboDateRange.ItemHeight = 29;
            this.cboDateRange.Location = new System.Drawing.Point(190, 58);
            this.cboDateRange.MaxDropDownItems = 4;
            this.cboDateRange.MouseState = MaterialSkin.MouseState.OUT;
            this.cboDateRange.Name = "cboDateRange";
            this.cboDateRange.Size = new System.Drawing.Size(216, 35);
            this.cboDateRange.StartIndex = 0;
            this.cboDateRange.TabIndex = 113;
            this.cboDateRange.UseTallSize = false;
            this.cboDateRange.SelectedIndexChanged += new System.EventHandler(this.cboDateRange_SelectedIndexChanged);
            // 
            // cboFilter
            // 
            this.cboFilter.AutoResize = false;
            this.cboFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboFilter.Depth = 0;
            this.cboFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboFilter.DropDownHeight = 118;
            this.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilter.DropDownWidth = 121;
            this.cboFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cboFilter.FormattingEnabled = true;
            this.cboFilter.IntegralHeight = false;
            this.cboFilter.ItemHeight = 29;
            this.cboFilter.Location = new System.Drawing.Point(256, 120);
            this.cboFilter.MaxDropDownItems = 4;
            this.cboFilter.MouseState = MaterialSkin.MouseState.OUT;
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.Size = new System.Drawing.Size(240, 35);
            this.cboFilter.StartIndex = 0;
            this.cboFilter.TabIndex = 113;
            this.cboFilter.UseTallSize = false;
            // 
            // txtFilter
            // 
            this.txtFilter.AnimateReadOnly = false;
            this.txtFilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFilter.Depth = 0;
            this.txtFilter.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtFilter.LeadingIcon = null;
            this.txtFilter.Location = new System.Drawing.Point(16, 120);
            this.txtFilter.MaxLength = 50;
            this.txtFilter.MouseState = MaterialSkin.MouseState.OUT;
            this.txtFilter.Multiline = false;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(216, 36);
            this.txtFilter.TabIndex = 111;
            this.txtFilter.Text = "";
            this.txtFilter.TrailingIcon = null;
            this.txtFilter.UseTallSize = false;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Checked = false;
            this.dtpEndDate.Location = new System.Drawing.Point(317, 22);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.ShowCheckBox = true;
            this.dtpEndDate.Size = new System.Drawing.Size(301, 20);
            this.dtpEndDate.TabIndex = 3;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(317, 3);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(65, 19);
            this.materialLabel3.TabIndex = 2;
            this.materialLabel3.Text = "End Date";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Checked = false;
            this.dtpStartDate.Location = new System.Drawing.Point(9, 22);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.ShowCheckBox = true;
            this.dtpStartDate.Size = new System.Drawing.Size(301, 20);
            this.dtpStartDate.TabIndex = 1;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(9, 3);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(72, 19);
            this.materialLabel2.TabIndex = 0;
            this.materialLabel2.Text = "Start Date";
            // 
            // groupBoxReportSelection
            // 
            this.groupBoxReportSelection.Controls.Add(this.lstReportTypes);
            this.groupBoxReportSelection.Location = new System.Drawing.Point(17, 69);
            this.groupBoxReportSelection.Name = "groupBoxReportSelection";
            this.groupBoxReportSelection.Size = new System.Drawing.Size(257, 173);
            this.groupBoxReportSelection.TabIndex = 102;
            this.groupBoxReportSelection.TabStop = false;
            this.groupBoxReportSelection.Text = "Select Report";
            // 
            // lstReportTypes
            // 
            this.lstReportTypes.FormattingEnabled = true;
            this.lstReportTypes.Items.AddRange(new object[] {
            "Sales Summary",
            "Inventory Report",
            "Customer Orders"});
            this.lstReportTypes.Location = new System.Drawing.Point(17, 26);
            this.lstReportTypes.Name = "lstReportTypes";
            this.lstReportTypes.Size = new System.Drawing.Size(223, 134);
            this.lstReportTypes.TabIndex = 0;
            this.lstReportTypes.SelectedIndexChanged += new System.EventHandler(this.lstReportTypes_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.materialLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(930, 40);
            this.panel1.TabIndex = 101;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel1.Location = new System.Drawing.Point(411, 9);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(153, 24);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "TakoTea Reports";
            // 
            // ReportingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 723);
            this.Controls.Add(this.materialCard1);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.Name = "ReportingForm";
            this.Padding = new System.Windows.Forms.Padding(3, 21, 3, 3);
            this.Text = "ReportingForm";
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            this.panelReports.ResumeLayout(false);
            this.groupBoxDateRange.ResumeLayout(false);
            this.groupBoxDateRange.PerformLayout();
            this.groupBoxReportSelection.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }



        #endregion



        private MaterialCard materialCard1;

        private Panel panel1;

        private MaterialLabel materialLabel1;

        private GroupBox groupBoxReportSelection;

        private ListBox lstReportTypes;

        private GroupBox groupBoxDateRange;

        private DateTimePicker dtpEndDate;

        private MaterialLabel materialLabel3;

        private DateTimePicker dtpStartDate;

        private MaterialLabel materialLabel2;

        private MaterialButton btnGenerateReport;
        private CheckBox chkLowStockOnly;
        private MaterialComboBox cboFilter;
        private MaterialTextBox txtFilter;
        private Panel panelReports;
        private WebBrowser webBrowser1;
        private Label lblSearchHint;
        private Label lblFilterHint;
        private MaterialComboBox cboDateRange;
    }

}