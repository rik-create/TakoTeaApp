namespace Audit_Trail
{
    partial class Form1
    {
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
        private void InitializeComponent()
        {
            this.auditTrailsGroup = new System.Windows.Forms.GroupBox();
            this.actionTypeComboBox = new System.Windows.Forms.ComboBox();
            this.userListBox = new System.Windows.Forms.ListBox();
            this.fromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.toDatePicker = new System.Windows.Forms.DateTimePicker();
            this.exportLogButton = new System.Windows.Forms.Button();
            this.viewDetailsButton = new System.Windows.Forms.Button();
            this.auditLogDetailsGroup = new System.Windows.Forms.GroupBox();
            this.auditLogDataGridView = new System.Windows.Forms.DataGridView();
            this.dateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detailsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paginationPanel = new System.Windows.Forms.Panel();
            this.previousButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.userActivityLogsGroup = new System.Windows.Forms.GroupBox();
            this.activityTypeComboBox = new System.Windows.Forms.ComboBox();
            this.activityFromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.activityToDatePicker = new System.Windows.Forms.DateTimePicker();
            this.multipleFailedLoginsCheckbox = new System.Windows.Forms.CheckBox();
            this.downloadLogButton = new System.Windows.Forms.Button();
            this.viewMoreButton = new System.Windows.Forms.Button();
            this.auditTrailsGroup.SuspendLayout();
            this.auditLogDetailsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.auditLogDataGridView)).BeginInit();
            this.paginationPanel.SuspendLayout();
            this.userActivityLogsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // auditTrailsGroup
            // 
            this.auditTrailsGroup.Controls.Add(this.actionTypeComboBox);
            this.auditTrailsGroup.Controls.Add(this.userListBox);
            this.auditTrailsGroup.Controls.Add(this.fromDatePicker);
            this.auditTrailsGroup.Controls.Add(this.toDatePicker);
            this.auditTrailsGroup.Controls.Add(this.exportLogButton);
            this.auditTrailsGroup.Controls.Add(this.viewDetailsButton);
            this.auditTrailsGroup.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.auditTrailsGroup.ForeColor = System.Drawing.Color.White;
            this.auditTrailsGroup.Location = new System.Drawing.Point(10, 10);
            this.auditTrailsGroup.Name = "auditTrailsGroup";
            this.auditTrailsGroup.Size = new System.Drawing.Size(309, 173);
            this.auditTrailsGroup.TabIndex = 0;
            this.auditTrailsGroup.TabStop = false;
            this.auditTrailsGroup.Text = "Audit Trails";
            // 
            // actionTypeComboBox
            // 
            this.actionTypeComboBox.FormattingEnabled = true;
            this.actionTypeComboBox.Location = new System.Drawing.Point(17, 26);
            this.actionTypeComboBox.Name = "actionTypeComboBox";
            this.actionTypeComboBox.Size = new System.Drawing.Size(129, 23);
            this.actionTypeComboBox.TabIndex = 1;
            this.actionTypeComboBox.Text = "Select Action Type";
            // 
            // userListBox
            // 
            this.userListBox.FormattingEnabled = true;
            this.userListBox.ItemHeight = 15;
            this.userListBox.Items.AddRange(new object[] {
            "Admin",
            "Manager"});
            this.userListBox.Location = new System.Drawing.Point(154, 26);
            this.userListBox.Name = "userListBox";
            this.userListBox.Size = new System.Drawing.Size(129, 34);
            this.userListBox.TabIndex = 2;
            // 
            // fromDatePicker
            // 
            this.fromDatePicker.CustomFormat = "dd/MM/yyyy";
            this.fromDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fromDatePicker.Location = new System.Drawing.Point(17, 69);
            this.fromDatePicker.Name = "fromDatePicker";
            this.fromDatePicker.Size = new System.Drawing.Size(129, 23);
            this.fromDatePicker.TabIndex = 3;
            // 
            // toDatePicker
            // 
            this.toDatePicker.CustomFormat = "dd/MM/yyyy";
            this.toDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.toDatePicker.Location = new System.Drawing.Point(154, 69);
            this.toDatePicker.Name = "toDatePicker";
            this.toDatePicker.Size = new System.Drawing.Size(129, 23);
            this.toDatePicker.TabIndex = 4;
            // 
            // exportLogButton
            // 
            this.exportLogButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.exportLogButton.ForeColor = System.Drawing.Color.White;
            this.exportLogButton.Location = new System.Drawing.Point(17, 104);
            this.exportLogButton.Name = "exportLogButton";
            this.exportLogButton.Size = new System.Drawing.Size(129, 26);
            this.exportLogButton.TabIndex = 5;
            this.exportLogButton.Text = "Export Log";
            this.exportLogButton.UseVisualStyleBackColor = false;
            // 
            // viewDetailsButton
            // 
            this.viewDetailsButton.BackColor = System.Drawing.Color.Gray;
            this.viewDetailsButton.ForeColor = System.Drawing.Color.White;
            this.viewDetailsButton.Location = new System.Drawing.Point(154, 104);
            this.viewDetailsButton.Name = "viewDetailsButton";
            this.viewDetailsButton.Size = new System.Drawing.Size(129, 26);
            this.viewDetailsButton.TabIndex = 6;
            this.viewDetailsButton.Text = "View Details";
            this.viewDetailsButton.UseVisualStyleBackColor = false;
            // 
            // auditLogDetailsGroup
            // 
            this.auditLogDetailsGroup.Controls.Add(this.auditLogDataGridView);
            this.auditLogDetailsGroup.Controls.Add(this.paginationPanel);
            this.auditLogDetailsGroup.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.auditLogDetailsGroup.ForeColor = System.Drawing.Color.White;
            this.auditLogDetailsGroup.Location = new System.Drawing.Point(10, 191);
            this.auditLogDetailsGroup.Name = "auditLogDetailsGroup";
            this.auditLogDetailsGroup.Size = new System.Drawing.Size(429, 217);
            this.auditLogDetailsGroup.TabIndex = 1;
            this.auditLogDetailsGroup.TabStop = false;
            this.auditLogDetailsGroup.Text = "Audit Log Details";
            // 
            // auditLogDataGridView
            // 
            this.auditLogDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.auditLogDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateColumn,
            this.actionColumn,
            this.userColumn,
            this.detailsColumn});
            this.auditLogDataGridView.Location = new System.Drawing.Point(17, 26);
            this.auditLogDataGridView.Name = "auditLogDataGridView";
            this.auditLogDataGridView.Size = new System.Drawing.Size(394, 156);
            this.auditLogDataGridView.TabIndex = 0;
            // 
            // dateColumn
            // 
            this.dateColumn.HeaderText = "Date";
            this.dateColumn.Name = "dateColumn";
            // 
            // actionColumn
            // 
            this.actionColumn.HeaderText = "Action";
            this.actionColumn.Name = "actionColumn";
            // 
            // userColumn
            // 
            this.userColumn.HeaderText = "User";
            this.userColumn.Name = "userColumn";
            // 
            // detailsColumn
            // 
            this.detailsColumn.HeaderText = "Details";
            this.detailsColumn.Name = "detailsColumn";
            this.detailsColumn.Width = 160;
            // 
            // paginationPanel
            // 
            this.paginationPanel.Controls.Add(this.previousButton);
            this.paginationPanel.Controls.Add(this.nextButton);
            this.paginationPanel.Location = new System.Drawing.Point(17, 182);
            this.paginationPanel.Name = "paginationPanel";
            this.paginationPanel.Size = new System.Drawing.Size(394, 26);
            this.paginationPanel.TabIndex = 1;
            // 
            // previousButton
            // 
            this.previousButton.Location = new System.Drawing.Point(266, 0);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(60, 26);
            this.previousButton.TabIndex = 0;
            this.previousButton.Text = "Previous";
            this.previousButton.UseVisualStyleBackColor = true;
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(334, 0);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(60, 26);
            this.nextButton.TabIndex = 1;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            // 
            // userActivityLogsGroup
            // 
            this.userActivityLogsGroup.Controls.Add(this.activityTypeComboBox);
            this.userActivityLogsGroup.Controls.Add(this.activityFromDatePicker);
            this.userActivityLogsGroup.Controls.Add(this.activityToDatePicker);
            this.userActivityLogsGroup.Controls.Add(this.multipleFailedLoginsCheckbox);
            this.userActivityLogsGroup.Controls.Add(this.downloadLogButton);
            this.userActivityLogsGroup.Controls.Add(this.viewMoreButton);
            this.userActivityLogsGroup.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.userActivityLogsGroup.ForeColor = System.Drawing.Color.White;
            this.userActivityLogsGroup.Location = new System.Drawing.Point(10, 416);
            this.userActivityLogsGroup.Name = "userActivityLogsGroup";
            this.userActivityLogsGroup.Size = new System.Drawing.Size(309, 156);
            this.userActivityLogsGroup.TabIndex = 2;
            this.userActivityLogsGroup.TabStop = false;
            this.userActivityLogsGroup.Text = "User Activity Logs";
            // 
            // activityTypeComboBox
            // 
            this.activityTypeComboBox.FormattingEnabled = true;
            this.activityTypeComboBox.Location = new System.Drawing.Point(17, 26);
            this.activityTypeComboBox.Name = "activityTypeComboBox";
            this.activityTypeComboBox.Size = new System.Drawing.Size(129, 23);
            this.activityTypeComboBox.TabIndex = 0;
            this.activityTypeComboBox.Text = "Select Activity Type";
            // 
            // activityFromDatePicker
            // 
            this.activityFromDatePicker.CustomFormat = "dd/MM/yyyy";
            this.activityFromDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.activityFromDatePicker.Location = new System.Drawing.Point(17, 61);
            this.activityFromDatePicker.Name = "activityFromDatePicker";
            this.activityFromDatePicker.Size = new System.Drawing.Size(129, 23);
            this.activityFromDatePicker.TabIndex = 1;
            // 
            // activityToDatePicker
            // 
            this.activityToDatePicker.CustomFormat = "dd/MM/yyyy";
            this.activityToDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.activityToDatePicker.Location = new System.Drawing.Point(154, 61);
            this.activityToDatePicker.Name = "activityToDatePicker";
            this.activityToDatePicker.Size = new System.Drawing.Size(129, 23);
            this.activityToDatePicker.TabIndex = 2;
            // 
            // multipleFailedLoginsCheckbox
            // 
            this.multipleFailedLoginsCheckbox.AutoSize = true;
            this.multipleFailedLoginsCheckbox.Location = new System.Drawing.Point(17, 95);
            this.multipleFailedLoginsCheckbox.Name = "multipleFailedLoginsCheckbox";
            this.multipleFailedLoginsCheckbox.Size = new System.Drawing.Size(142, 19);
            this.multipleFailedLoginsCheckbox.TabIndex = 3;
            this.multipleFailedLoginsCheckbox.Text = "Multiple Failed Logins";
            this.multipleFailedLoginsCheckbox.UseVisualStyleBackColor = true;
            // 
            // downloadLogButton
            // 
            this.downloadLogButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.downloadLogButton.ForeColor = System.Drawing.Color.White;
            this.downloadLogButton.Location = new System.Drawing.Point(17, 121);
            this.downloadLogButton.Name = "downloadLogButton";
            this.downloadLogButton.Size = new System.Drawing.Size(129, 26);
            this.downloadLogButton.TabIndex = 4;
            this.downloadLogButton.Text = "Download Log";
            this.downloadLogButton.UseVisualStyleBackColor = false;
            // 
            // viewMoreButton
            // 
            this.viewMoreButton.BackColor = System.Drawing.Color.Gray;
            this.viewMoreButton.ForeColor = System.Drawing.Color.White;
            this.viewMoreButton.Location = new System.Drawing.Point(154, 121);
            this.viewMoreButton.Name = "viewMoreButton";
            this.viewMoreButton.Size = new System.Drawing.Size(129, 26);
            this.viewMoreButton.TabIndex = 5;
            this.viewMoreButton.Text = "View More";
            this.viewMoreButton.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(445, 590);
            this.Controls.Add(this.userActivityLogsGroup);
            this.Controls.Add(this.auditLogDetailsGroup);
            this.Controls.Add(this.auditTrailsGroup);
            this.Name = "Form1";
            this.Text = "Audit Trails";
            this.auditTrailsGroup.ResumeLayout(false);
            this.auditLogDetailsGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.auditLogDataGridView)).EndInit();
            this.paginationPanel.ResumeLayout(false);
            this.userActivityLogsGroup.ResumeLayout(false);
            this.userActivityLogsGroup.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.GroupBox auditTrailsGroup;
        private System.Windows.Forms.ComboBox actionTypeComboBox;
        private System.Windows.Forms.ListBox userListBox;
        private System.Windows.Forms.DateTimePicker fromDatePicker;
        private System.Windows.Forms.DateTimePicker toDatePicker;
        private System.Windows.Forms.Button exportLogButton;
        private System.Windows.Forms.Button viewDetailsButton;
        private System.Windows.Forms.GroupBox auditLogDetailsGroup;
        private System.Windows.Forms.DataGridView auditLogDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn actionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn detailsColumn;
        private System.Windows.Forms.Panel paginationPanel;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.GroupBox userActivityLogsGroup;
        private System.Windows.Forms.ComboBox activityTypeComboBox;
        private System.Windows.Forms.DateTimePicker activityFromDatePicker;
        private System.Windows.Forms.DateTimePicker activityToDatePicker;
        private System.Windows.Forms.CheckBox multipleFailedLoginsCheckbox;
        private System.Windows.Forms.Button downloadLogButton;
        private System.Windows.Forms.Button viewMoreButton;
    }
}
