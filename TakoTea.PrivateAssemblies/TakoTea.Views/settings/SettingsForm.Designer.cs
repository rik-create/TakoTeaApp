using MaterialSkin.Controls;
using System.Windows.Forms;

namespace TakoTea.Views.settings
{
    partial class SettingsForm
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
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPageUserManagement = new System.Windows.Forms.TabPage();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.btnDeleteUser = new MaterialSkin.Controls.MaterialButton();
            this.groupBoxUserInfo = new System.Windows.Forms.GroupBox();
            this.btnEditUser = new MaterialSkin.Controls.MaterialButton();
            this.btnAddUser = new MaterialSkin.Controls.MaterialButton();
            this.materialCard4 = new MaterialSkin.Controls.MaterialCard();
            this.txtBoxPassword = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.txtBoxUsername = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.txtBoxName = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.cmbRoleAssignment = new MaterialSkin.Controls.MaterialComboBox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.groupBoxUserList = new System.Windows.Forms.GroupBox();
            this.materialListViewUsers = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageNotificationSettings = new System.Windows.Forms.TabPage();
            this.materialCard2 = new MaterialSkin.Controls.MaterialCard();
            this.btnAddEmail = new System.Windows.Forms.Button();
            this.txtBoxAddEmail = new System.Windows.Forms.TextBox();
            this.groupBoxEmailSelection = new System.Windows.Forms.GroupBox();
            this.floatingActionButtonDeleteEmail = new MaterialSkin.Controls.MaterialFloatingActionButton();
            this.checkedListBoxEmails = new System.Windows.Forms.CheckedListBox();
            this.checkBoxSelectAllEmails = new MaterialSkin.Controls.MaterialCheckbox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxDeliveryMethod = new System.Windows.Forms.GroupBox();
            this.chkBoxEnableEmailNotifications = new MaterialSkin.Controls.MaterialCheckbox();
            this.cmbAlertFrequency = new MaterialSkin.Controls.MaterialComboBox();
            this.chkBoxInAppNotification = new MaterialSkin.Controls.MaterialCheckbox();
            this.tabPageDataBackup = new System.Windows.Forms.TabPage();
            this.materialCard3 = new MaterialSkin.Controls.MaterialCard();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.materialFloatingActionButtonAddBackUpDestination = new MaterialSkin.Controls.MaterialFloatingActionButton();
            this.materialFloatingActionButtonDeleteBackupDestination = new MaterialSkin.Controls.MaterialFloatingActionButton();
            this.cmbBackupSchedule = new MaterialSkin.Controls.MaterialComboBox();
            this.checkedListBoxBackUpDestinations = new System.Windows.Forms.CheckedListBox();
            this.btnPerformBackup = new MaterialSkin.Controls.MaterialButton();
            this.lblLastBackupDate = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel11 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            this.btnRestoreBackup = new MaterialSkin.Controls.MaterialButton();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.btnCancelChanges = new MaterialSkin.Controls.MaterialButton();
            this.btnSaveChanges = new MaterialSkin.Controls.MaterialButton();
            this.materialTabControl1.SuspendLayout();
            this.tabPageUserManagement.SuspendLayout();
            this.materialCard1.SuspendLayout();
            this.groupBoxUserInfo.SuspendLayout();
            this.materialCard4.SuspendLayout();
            this.groupBoxUserList.SuspendLayout();
            this.tabPageNotificationSettings.SuspendLayout();
            this.materialCard2.SuspendLayout();
            this.groupBoxEmailSelection.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxDeliveryMethod.SuspendLayout();
            this.tabPageDataBackup.SuspendLayout();
            this.materialCard3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPageUserManagement);
            this.materialTabControl1.Controls.Add(this.tabPageNotificationSettings);
            this.materialTabControl1.Controls.Add(this.tabPageDataBackup);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl1.Location = new System.Drawing.Point(3, 64);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(730, 466);
            this.materialTabControl1.TabIndex = 0;
            // 
            // tabPageUserManagement
            // 
            this.tabPageUserManagement.BackColor = System.Drawing.Color.White;
            this.tabPageUserManagement.Controls.Add(this.materialCard1);
            this.tabPageUserManagement.Location = new System.Drawing.Point(4, 22);
            this.tabPageUserManagement.Name = "tabPageUserManagement";
            this.tabPageUserManagement.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUserManagement.Size = new System.Drawing.Size(722, 440);
            this.tabPageUserManagement.TabIndex = 0;
            this.tabPageUserManagement.Text = "User Management";
            // 
            // materialCard1
            // 
            this.materialCard1.AutoScroll = true;
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.btnDeleteUser);
            this.materialCard1.Controls.Add(this.groupBoxUserInfo);
            this.materialCard1.Controls.Add(this.groupBoxUserList);
            this.materialCard1.Depth = 0;
            this.materialCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(3, 3);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(10);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(10);
            this.materialCard1.Size = new System.Drawing.Size(716, 434);
            this.materialCard1.TabIndex = 0;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeleteUser.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnDeleteUser.Depth = 0;
            this.btnDeleteUser.HighEmphasis = true;
            this.btnDeleteUser.Icon = null;
            this.btnDeleteUser.Location = new System.Drawing.Point(248, 384);
            this.btnDeleteUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDeleteUser.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnDeleteUser.Size = new System.Drawing.Size(113, 36);
            this.btnDeleteUser.TabIndex = 1;
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnDeleteUser.UseAccentColor = false;
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            // 
            // groupBoxUserInfo
            // 
            this.groupBoxUserInfo.Controls.Add(this.btnEditUser);
            this.groupBoxUserInfo.Controls.Add(this.btnAddUser);
            this.groupBoxUserInfo.Controls.Add(this.materialCard4);
            this.groupBoxUserInfo.Location = new System.Drawing.Point(382, 15);
            this.groupBoxUserInfo.Name = "groupBoxUserInfo";
            this.groupBoxUserInfo.Size = new System.Drawing.Size(322, 353);
            this.groupBoxUserInfo.TabIndex = 1;
            this.groupBoxUserInfo.TabStop = false;
            this.groupBoxUserInfo.Text = "User Information";
            // 
            // btnEditUser
            // 
            this.btnEditUser.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEditUser.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnEditUser.Depth = 0;
            this.btnEditUser.HighEmphasis = true;
            this.btnEditUser.Icon = null;
            this.btnEditUser.Location = new System.Drawing.Point(192, 416);
            this.btnEditUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEditUser.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnEditUser.Size = new System.Drawing.Size(92, 36);
            this.btnEditUser.TabIndex = 3;
            this.btnEditUser.Text = "Edit User";
            this.btnEditUser.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnEditUser.UseAccentColor = false;
            this.btnEditUser.UseVisualStyleBackColor = true;
            // 
            // btnAddUser
            // 
            this.btnAddUser.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddUser.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAddUser.Depth = 0;
            this.btnAddUser.HighEmphasis = true;
            this.btnAddUser.Icon = null;
            this.btnAddUser.Location = new System.Drawing.Point(96, 416);
            this.btnAddUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddUser.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAddUser.Size = new System.Drawing.Size(90, 36);
            this.btnAddUser.TabIndex = 2;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAddUser.UseAccentColor = false;
            this.btnAddUser.UseVisualStyleBackColor = true;
            // 
            // materialCard4
            // 
            this.materialCard4.AutoScroll = true;
            this.materialCard4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard4.Controls.Add(this.txtBoxPassword);
            this.materialCard4.Controls.Add(this.materialLabel8);
            this.materialCard4.Controls.Add(this.txtBoxUsername);
            this.materialCard4.Controls.Add(this.materialLabel7);
            this.materialCard4.Controls.Add(this.txtBoxName);
            this.materialCard4.Controls.Add(this.materialLabel6);
            this.materialCard4.Controls.Add(this.cmbRoleAssignment);
            this.materialCard4.Controls.Add(this.materialLabel3);
            this.materialCard4.Depth = 0;
            this.materialCard4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCard4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard4.Location = new System.Drawing.Point(3, 16);
            this.materialCard4.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard4.Name = "materialCard4";
            this.materialCard4.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard4.Size = new System.Drawing.Size(316, 334);
            this.materialCard4.TabIndex = 12;
            // 
            // txtBoxPassword
            // 
            this.txtBoxPassword.AnimateReadOnly = false;
            this.txtBoxPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtBoxPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBoxPassword.Depth = 0;
            this.txtBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtBoxPassword.HideSelection = true;
            this.txtBoxPassword.Hint = "Password";
            this.txtBoxPassword.LeadingIcon = null;
            this.txtBoxPassword.Location = new System.Drawing.Point(16, 232);
            this.txtBoxPassword.MaxLength = 32767;
            this.txtBoxPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.txtBoxPassword.Name = "txtBoxPassword";
            this.txtBoxPassword.PasswordChar = '●';
            this.txtBoxPassword.PrefixSuffixText = null;
            this.txtBoxPassword.ReadOnly = false;
            this.txtBoxPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBoxPassword.SelectedText = "";
            this.txtBoxPassword.SelectionLength = 0;
            this.txtBoxPassword.SelectionStart = 0;
            this.txtBoxPassword.ShortcutsEnabled = true;
            this.txtBoxPassword.Size = new System.Drawing.Size(265, 48);
            this.txtBoxPassword.TabIndex = 19;
            this.txtBoxPassword.TabStop = false;
            this.txtBoxPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBoxPassword.TrailingIcon = null;
            this.txtBoxPassword.UseSystemPasswordChar = true;
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel8.Location = new System.Drawing.Point(16, 200);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(71, 19);
            this.materialLabel8.TabIndex = 18;
            this.materialLabel8.Text = "Password";
            // 
            // txtBoxUsername
            // 
            this.txtBoxUsername.AnimateReadOnly = false;
            this.txtBoxUsername.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtBoxUsername.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBoxUsername.Depth = 0;
            this.txtBoxUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtBoxUsername.HideSelection = true;
            this.txtBoxUsername.Hint = "Username";
            this.txtBoxUsername.LeadingIcon = null;
            this.txtBoxUsername.Location = new System.Drawing.Point(16, 141);
            this.txtBoxUsername.MaxLength = 32767;
            this.txtBoxUsername.MouseState = MaterialSkin.MouseState.OUT;
            this.txtBoxUsername.Name = "txtBoxUsername";
            this.txtBoxUsername.PasswordChar = '\0';
            this.txtBoxUsername.PrefixSuffixText = null;
            this.txtBoxUsername.ReadOnly = false;
            this.txtBoxUsername.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBoxUsername.SelectedText = "";
            this.txtBoxUsername.SelectionLength = 0;
            this.txtBoxUsername.SelectionStart = 0;
            this.txtBoxUsername.ShortcutsEnabled = true;
            this.txtBoxUsername.Size = new System.Drawing.Size(265, 48);
            this.txtBoxUsername.TabIndex = 17;
            this.txtBoxUsername.TabStop = false;
            this.txtBoxUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBoxUsername.TrailingIcon = null;
            this.txtBoxUsername.UseSystemPasswordChar = false;
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel7.Location = new System.Drawing.Point(16, 106);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(72, 19);
            this.materialLabel7.TabIndex = 16;
            this.materialLabel7.Text = "Username";
            // 
            // txtBoxName
            // 
            this.txtBoxName.AnimateReadOnly = false;
            this.txtBoxName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtBoxName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBoxName.Depth = 0;
            this.txtBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtBoxName.HideSelection = true;
            this.txtBoxName.Hint = "Name";
            this.txtBoxName.LeadingIcon = null;
            this.txtBoxName.Location = new System.Drawing.Point(16, 42);
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
            this.txtBoxName.Size = new System.Drawing.Size(265, 48);
            this.txtBoxName.TabIndex = 15;
            this.txtBoxName.TabStop = false;
            this.txtBoxName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBoxName.TrailingIcon = null;
            this.txtBoxName.UseSystemPasswordChar = false;
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel6.Location = new System.Drawing.Point(16, 7);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(43, 19);
            this.materialLabel6.TabIndex = 14;
            this.materialLabel6.Text = "Name";
            // 
            // cmbRoleAssignment
            // 
            this.cmbRoleAssignment.AutoResize = false;
            this.cmbRoleAssignment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbRoleAssignment.Depth = 0;
            this.cmbRoleAssignment.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbRoleAssignment.DropDownHeight = 174;
            this.cmbRoleAssignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoleAssignment.DropDownWidth = 121;
            this.cmbRoleAssignment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbRoleAssignment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbRoleAssignment.FormattingEnabled = true;
            this.cmbRoleAssignment.Hint = "Select Role";
            this.cmbRoleAssignment.IntegralHeight = false;
            this.cmbRoleAssignment.ItemHeight = 43;
            this.cmbRoleAssignment.Items.AddRange(new object[] {
            "Admin",
            "Manager",
            "Staff"});
            this.cmbRoleAssignment.Location = new System.Drawing.Point(16, 339);
            this.cmbRoleAssignment.MaxDropDownItems = 4;
            this.cmbRoleAssignment.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbRoleAssignment.Name = "cmbRoleAssignment";
            this.cmbRoleAssignment.Size = new System.Drawing.Size(261, 49);
            this.cmbRoleAssignment.StartIndex = 0;
            this.cmbRoleAssignment.TabIndex = 13;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(16, 304);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(120, 19);
            this.materialLabel3.TabIndex = 12;
            this.materialLabel3.Text = "Role Assignment";
            // 
            // groupBoxUserList
            // 
            this.groupBoxUserList.Controls.Add(this.materialListViewUsers);
            this.groupBoxUserList.Location = new System.Drawing.Point(15, 15);
            this.groupBoxUserList.Name = "groupBoxUserList";
            this.groupBoxUserList.Size = new System.Drawing.Size(352, 353);
            this.groupBoxUserList.TabIndex = 0;
            this.groupBoxUserList.TabStop = false;
            this.groupBoxUserList.Text = "User List";
            // 
            // materialListViewUsers
            // 
            this.materialListViewUsers.AutoSizeTable = false;
            this.materialListViewUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialListViewUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialListViewUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.materialListViewUsers.Depth = 0;
            this.materialListViewUsers.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.materialListViewUsers.FullRowSelect = true;
            this.materialListViewUsers.HideSelection = false;
            this.materialListViewUsers.Location = new System.Drawing.Point(15, 23);
            this.materialListViewUsers.MinimumSize = new System.Drawing.Size(147, 75);
            this.materialListViewUsers.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialListViewUsers.MouseState = MaterialSkin.MouseState.OUT;
            this.materialListViewUsers.Name = "materialListViewUsers";
            this.materialListViewUsers.OwnerDraw = true;
            this.materialListViewUsers.Size = new System.Drawing.Size(329, 329);
            this.materialListViewUsers.TabIndex = 0;
            this.materialListViewUsers.UseCompatibleStateImageBehavior = false;
            this.materialListViewUsers.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Username";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Role";
            this.columnHeader2.Width = 150;
            // 
            // tabPageNotificationSettings
            // 
            this.tabPageNotificationSettings.BackColor = System.Drawing.Color.White;
            this.tabPageNotificationSettings.Controls.Add(this.materialCard2);
            this.tabPageNotificationSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageNotificationSettings.Name = "tabPageNotificationSettings";
            this.tabPageNotificationSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNotificationSettings.Size = new System.Drawing.Size(722, 440);
            this.tabPageNotificationSettings.TabIndex = 1;
            this.tabPageNotificationSettings.Text = "Notification Settings";
            // 
            // materialCard2
            // 
            this.materialCard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard2.Controls.Add(this.btnAddEmail);
            this.materialCard2.Controls.Add(this.txtBoxAddEmail);
            this.materialCard2.Controls.Add(this.groupBoxEmailSelection);
            this.materialCard2.Controls.Add(this.groupBox1);
            this.materialCard2.Depth = 0;
            this.materialCard2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCard2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard2.Location = new System.Drawing.Point(3, 3);
            this.materialCard2.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard2.Name = "materialCard2";
            this.materialCard2.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard2.Size = new System.Drawing.Size(716, 434);
            this.materialCard2.TabIndex = 0;
            // 
            // btnAddEmail
            // 
            this.btnAddEmail.Location = new System.Drawing.Point(616, 352);
            this.btnAddEmail.Name = "btnAddEmail";
            this.btnAddEmail.Size = new System.Drawing.Size(75, 23);
            this.btnAddEmail.TabIndex = 9;
            this.btnAddEmail.Text = "Add";
            this.btnAddEmail.UseVisualStyleBackColor = true;
            this.btnAddEmail.Click += new System.EventHandler(this.btnAddEmail_Click);
            // 
            // txtBoxAddEmail
            // 
            this.txtBoxAddEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxAddEmail.Location = new System.Drawing.Point(408, 352);
            this.txtBoxAddEmail.Name = "txtBoxAddEmail";
            this.txtBoxAddEmail.Size = new System.Drawing.Size(200, 22);
            this.txtBoxAddEmail.TabIndex = 8;
            this.txtBoxAddEmail.TextChanged += new System.EventHandler(this.txtBoxAddEmail_TextChanged);
            // 
            // groupBoxEmailSelection
            // 
            this.groupBoxEmailSelection.Controls.Add(this.floatingActionButtonDeleteEmail);
            this.groupBoxEmailSelection.Controls.Add(this.checkedListBoxEmails);
            this.groupBoxEmailSelection.Controls.Add(this.checkBoxSelectAllEmails);
            this.groupBoxEmailSelection.Location = new System.Drawing.Point(384, 24);
            this.groupBoxEmailSelection.Name = "groupBoxEmailSelection";
            this.groupBoxEmailSelection.Size = new System.Drawing.Size(312, 320);
            this.groupBoxEmailSelection.TabIndex = 6;
            this.groupBoxEmailSelection.TabStop = false;
            this.groupBoxEmailSelection.Text = "Select Email";
            // 
            // floatingActionButtonDeleteEmail
            // 
            this.floatingActionButtonDeleteEmail.Depth = 0;
            this.floatingActionButtonDeleteEmail.Icon = global::TakoTea.Views.Properties.Resources.delete;
            this.floatingActionButtonDeleteEmail.Image = global::TakoTea.Views.Properties.Resources.plus;
            this.floatingActionButtonDeleteEmail.Location = new System.Drawing.Point(248, 16);
            this.floatingActionButtonDeleteEmail.Mini = true;
            this.floatingActionButtonDeleteEmail.MouseState = MaterialSkin.MouseState.HOVER;
            this.floatingActionButtonDeleteEmail.Name = "floatingActionButtonDeleteEmail";
            this.floatingActionButtonDeleteEmail.Size = new System.Drawing.Size(40, 40);
            this.floatingActionButtonDeleteEmail.TabIndex = 103;
            this.floatingActionButtonDeleteEmail.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxEmails
            // 
            this.checkedListBoxEmails.BackColor = System.Drawing.SystemColors.Control;
            this.checkedListBoxEmails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBoxEmails.CheckOnClick = true;
            this.checkedListBoxEmails.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.checkedListBoxEmails.FormattingEnabled = true;
            this.checkedListBoxEmails.Location = new System.Drawing.Point(20, 70);
            this.checkedListBoxEmails.Name = "checkedListBoxEmails";
            this.checkedListBoxEmails.Size = new System.Drawing.Size(284, 222);
            this.checkedListBoxEmails.TabIndex = 1;
            // 
            // checkBoxSelectAllEmails
            // 
            this.checkBoxSelectAllEmails.AutoSize = true;
            this.checkBoxSelectAllEmails.Depth = 0;
            this.checkBoxSelectAllEmails.Location = new System.Drawing.Point(20, 30);
            this.checkBoxSelectAllEmails.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxSelectAllEmails.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkBoxSelectAllEmails.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkBoxSelectAllEmails.Name = "checkBoxSelectAllEmails";
            this.checkBoxSelectAllEmails.ReadOnly = false;
            this.checkBoxSelectAllEmails.Ripple = true;
            this.checkBoxSelectAllEmails.Size = new System.Drawing.Size(100, 37);
            this.checkBoxSelectAllEmails.TabIndex = 0;
            this.checkBoxSelectAllEmails.Text = "Select All";
            this.checkBoxSelectAllEmails.UseVisualStyleBackColor = true;
            this.checkBoxSelectAllEmails.CheckedChanged += new System.EventHandler(this.checkBoxSelectAllEmails_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBoxDeliveryMethod);
            this.groupBox1.Location = new System.Drawing.Point(16, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 344);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stock Alert Threshold";
            // 
            // groupBoxDeliveryMethod
            // 
            this.groupBoxDeliveryMethod.Controls.Add(this.chkBoxEnableEmailNotifications);
            this.groupBoxDeliveryMethod.Controls.Add(this.cmbAlertFrequency);
            this.groupBoxDeliveryMethod.Controls.Add(this.chkBoxInAppNotification);
            this.groupBoxDeliveryMethod.Location = new System.Drawing.Point(8, 32);
            this.groupBoxDeliveryMethod.Name = "groupBoxDeliveryMethod";
            this.groupBoxDeliveryMethod.Size = new System.Drawing.Size(338, 186);
            this.groupBoxDeliveryMethod.TabIndex = 9;
            this.groupBoxDeliveryMethod.TabStop = false;
            this.groupBoxDeliveryMethod.Text = "Delivery Method";
            // 
            // chkBoxEnableEmailNotifications
            // 
            this.chkBoxEnableEmailNotifications.AutoSize = true;
            this.chkBoxEnableEmailNotifications.Depth = 0;
            this.chkBoxEnableEmailNotifications.Location = new System.Drawing.Point(8, 72);
            this.chkBoxEnableEmailNotifications.Margin = new System.Windows.Forms.Padding(0);
            this.chkBoxEnableEmailNotifications.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkBoxEnableEmailNotifications.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkBoxEnableEmailNotifications.Name = "chkBoxEnableEmailNotifications";
            this.chkBoxEnableEmailNotifications.ReadOnly = false;
            this.chkBoxEnableEmailNotifications.Ripple = true;
            this.chkBoxEnableEmailNotifications.Size = new System.Drawing.Size(222, 37);
            this.chkBoxEnableEmailNotifications.TabIndex = 2;
            this.chkBoxEnableEmailNotifications.Text = "Enable Email Notifications";
            this.chkBoxEnableEmailNotifications.UseVisualStyleBackColor = true;
            // 
            // cmbAlertFrequency
            // 
            this.cmbAlertFrequency.AutoResize = false;
            this.cmbAlertFrequency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbAlertFrequency.Depth = 0;
            this.cmbAlertFrequency.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbAlertFrequency.DropDownHeight = 174;
            this.cmbAlertFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlertFrequency.DropDownWidth = 121;
            this.cmbAlertFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbAlertFrequency.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbAlertFrequency.FormattingEnabled = true;
            this.cmbAlertFrequency.Hint = "Alert Frequency";
            this.cmbAlertFrequency.IntegralHeight = false;
            this.cmbAlertFrequency.ItemHeight = 43;
            this.cmbAlertFrequency.Items.AddRange(new object[] {
            "Hourly",
            "Daily",
            "Weekly"});
            this.cmbAlertFrequency.Location = new System.Drawing.Point(8, 120);
            this.cmbAlertFrequency.MaxDropDownItems = 4;
            this.cmbAlertFrequency.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbAlertFrequency.Name = "cmbAlertFrequency";
            this.cmbAlertFrequency.Size = new System.Drawing.Size(320, 49);
            this.cmbAlertFrequency.StartIndex = 0;
            this.cmbAlertFrequency.TabIndex = 7;
            this.cmbAlertFrequency.SelectedIndexChanged += new System.EventHandler(this.cmbAlertFrequency_SelectedIndexChanged);
            // 
            // chkBoxInAppNotification
            // 
            this.chkBoxInAppNotification.AutoSize = true;
            this.chkBoxInAppNotification.Depth = 0;
            this.chkBoxInAppNotification.Location = new System.Drawing.Point(8, 24);
            this.chkBoxInAppNotification.Margin = new System.Windows.Forms.Padding(0);
            this.chkBoxInAppNotification.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkBoxInAppNotification.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkBoxInAppNotification.Name = "chkBoxInAppNotification";
            this.chkBoxInAppNotification.ReadOnly = false;
            this.chkBoxInAppNotification.Ripple = true;
            this.chkBoxInAppNotification.Size = new System.Drawing.Size(167, 37);
            this.chkBoxInAppNotification.TabIndex = 1;
            this.chkBoxInAppNotification.Text = "In-App Notification";
            this.chkBoxInAppNotification.UseVisualStyleBackColor = true;
            // 
            // tabPageDataBackup
            // 
            this.tabPageDataBackup.Controls.Add(this.materialCard3);
            this.tabPageDataBackup.Location = new System.Drawing.Point(4, 22);
            this.tabPageDataBackup.Name = "tabPageDataBackup";
            this.tabPageDataBackup.Size = new System.Drawing.Size(722, 440);
            this.tabPageDataBackup.TabIndex = 2;
            this.tabPageDataBackup.Text = "Data Backup & Recovery";
            this.tabPageDataBackup.UseVisualStyleBackColor = true;
            // 
            // materialCard3
            // 
            this.materialCard3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard3.Controls.Add(this.groupBox2);
            this.materialCard3.Controls.Add(this.btnRestoreBackup);
            this.materialCard3.Depth = 0;
            this.materialCard3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCard3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard3.Location = new System.Drawing.Point(0, 0);
            this.materialCard3.Margin = new System.Windows.Forms.Padding(12);
            this.materialCard3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard3.Name = "materialCard3";
            this.materialCard3.Padding = new System.Windows.Forms.Padding(12);
            this.materialCard3.Size = new System.Drawing.Size(722, 440);
            this.materialCard3.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.materialFloatingActionButtonAddBackUpDestination);
            this.groupBox2.Controls.Add(this.materialFloatingActionButtonDeleteBackupDestination);
            this.groupBox2.Controls.Add(this.cmbBackupSchedule);
            this.groupBox2.Controls.Add(this.checkedListBoxBackUpDestinations);
            this.groupBox2.Controls.Add(this.btnPerformBackup);
            this.groupBox2.Controls.Add(this.lblLastBackupDate);
            this.groupBox2.Controls.Add(this.materialLabel11);
            this.groupBox2.Controls.Add(this.materialLabel1);
            this.groupBox2.Controls.Add(this.materialLabel10);
            this.groupBox2.Controls.Add(this.materialLabel9);
            this.groupBox2.Location = new System.Drawing.Point(24, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(672, 360);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Backup";
            // 
            // materialFloatingActionButtonAddBackUpDestination
            // 
            this.materialFloatingActionButtonAddBackUpDestination.Depth = 0;
            this.materialFloatingActionButtonAddBackUpDestination.Icon = global::TakoTea.Views.Properties.Resources.plus_white1;
            this.materialFloatingActionButtonAddBackUpDestination.Image = global::TakoTea.Views.Properties.Resources.plus;
            this.materialFloatingActionButtonAddBackUpDestination.Location = new System.Drawing.Point(552, 168);
            this.materialFloatingActionButtonAddBackUpDestination.Mini = true;
            this.materialFloatingActionButtonAddBackUpDestination.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFloatingActionButtonAddBackUpDestination.Name = "materialFloatingActionButtonAddBackUpDestination";
            this.materialFloatingActionButtonAddBackUpDestination.Size = new System.Drawing.Size(40, 40);
            this.materialFloatingActionButtonAddBackUpDestination.TabIndex = 104;
            this.materialFloatingActionButtonAddBackUpDestination.UseVisualStyleBackColor = true;
            this.materialFloatingActionButtonAddBackUpDestination.Click += new System.EventHandler(this.materialFloatingActionButtonAddBackUpDestination_Click);
            // 
            // materialFloatingActionButtonDeleteBackupDestination
            // 
            this.materialFloatingActionButtonDeleteBackupDestination.Depth = 0;
            this.materialFloatingActionButtonDeleteBackupDestination.Icon = global::TakoTea.Views.Properties.Resources.delete;
            this.materialFloatingActionButtonDeleteBackupDestination.Image = global::TakoTea.Views.Properties.Resources.plus;
            this.materialFloatingActionButtonDeleteBackupDestination.Location = new System.Drawing.Point(600, 168);
            this.materialFloatingActionButtonDeleteBackupDestination.Mini = true;
            this.materialFloatingActionButtonDeleteBackupDestination.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFloatingActionButtonDeleteBackupDestination.Name = "materialFloatingActionButtonDeleteBackupDestination";
            this.materialFloatingActionButtonDeleteBackupDestination.Size = new System.Drawing.Size(40, 40);
            this.materialFloatingActionButtonDeleteBackupDestination.TabIndex = 104;
            this.materialFloatingActionButtonDeleteBackupDestination.UseVisualStyleBackColor = true;
            this.materialFloatingActionButtonDeleteBackupDestination.Click += new System.EventHandler(this.materialFloatingActionButtonDeleteBackupDestination_Click);
            // 
            // cmbBackupSchedule
            // 
            this.cmbBackupSchedule.AutoResize = false;
            this.cmbBackupSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbBackupSchedule.Depth = 0;
            this.cmbBackupSchedule.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbBackupSchedule.DropDownHeight = 174;
            this.cmbBackupSchedule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBackupSchedule.DropDownWidth = 121;
            this.cmbBackupSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbBackupSchedule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbBackupSchedule.FormattingEnabled = true;
            this.cmbBackupSchedule.Hint = "Backup Schedule";
            this.cmbBackupSchedule.IntegralHeight = false;
            this.cmbBackupSchedule.ItemHeight = 43;
            this.cmbBackupSchedule.Items.AddRange(new object[] {
            "Hourly",
            "Daily",
            "Weekly",
            "Monthly"});
            this.cmbBackupSchedule.Location = new System.Drawing.Point(16, 64);
            this.cmbBackupSchedule.MaxDropDownItems = 4;
            this.cmbBackupSchedule.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbBackupSchedule.Name = "cmbBackupSchedule";
            this.cmbBackupSchedule.Size = new System.Drawing.Size(336, 49);
            this.cmbBackupSchedule.StartIndex = 0;
            this.cmbBackupSchedule.TabIndex = 1;
            // 
            // checkedListBoxBackUpDestinations
            // 
            this.checkedListBoxBackUpDestinations.BackColor = System.Drawing.SystemColors.Control;
            this.checkedListBoxBackUpDestinations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBoxBackUpDestinations.CheckOnClick = true;
            this.checkedListBoxBackUpDestinations.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.checkedListBoxBackUpDestinations.FormattingEnabled = true;
            this.checkedListBoxBackUpDestinations.Location = new System.Drawing.Point(8, 160);
            this.checkedListBoxBackUpDestinations.Name = "checkedListBoxBackUpDestinations";
            this.checkedListBoxBackUpDestinations.Size = new System.Drawing.Size(648, 200);
            this.checkedListBoxBackUpDestinations.TabIndex = 8;
            // 
            // btnPerformBackup
            // 
            this.btnPerformBackup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPerformBackup.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnPerformBackup.Depth = 0;
            this.btnPerformBackup.HighEmphasis = true;
            this.btnPerformBackup.Icon = null;
            this.btnPerformBackup.Location = new System.Drawing.Point(400, 104);
            this.btnPerformBackup.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnPerformBackup.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPerformBackup.Name = "btnPerformBackup";
            this.btnPerformBackup.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnPerformBackup.Size = new System.Drawing.Size(149, 36);
            this.btnPerformBackup.TabIndex = 6;
            this.btnPerformBackup.Text = "Perform Backup";
            this.btnPerformBackup.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPerformBackup.UseAccentColor = false;
            this.btnPerformBackup.UseVisualStyleBackColor = true;
            this.btnPerformBackup.Click += new System.EventHandler(this.btnPerformBackup_Click_1);
            // 
            // lblLastBackupDate
            // 
            this.lblLastBackupDate.AutoSize = true;
            this.lblLastBackupDate.Depth = 0;
            this.lblLastBackupDate.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.lblLastBackupDate.FontType = MaterialSkin.MaterialSkinManager.fontType.SubtleEmphasis;
            this.lblLastBackupDate.Location = new System.Drawing.Point(400, 48);
            this.lblLastBackupDate.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblLastBackupDate.Name = "lblLastBackupDate";
            this.lblLastBackupDate.Size = new System.Drawing.Size(170, 14);
            this.lblLastBackupDate.TabIndex = 5;
            this.lblLastBackupDate.Text = "November 28, 2024 (10:00 AM)";
            // 
            // materialLabel11
            // 
            this.materialLabel11.AutoSize = true;
            this.materialLabel11.Depth = 0;
            this.materialLabel11.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel11.Location = new System.Drawing.Point(16, 24);
            this.materialLabel11.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel11.Name = "materialLabel11";
            this.materialLabel11.Size = new System.Drawing.Size(123, 19);
            this.materialLabel11.TabIndex = 0;
            this.materialLabel11.Text = "Backup Schedule";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(400, 80);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(116, 19);
            this.materialLabel1.TabIndex = 4;
            this.materialLabel1.Text = "Manual Backup:";
            // 
            // materialLabel10
            // 
            this.materialLabel10.AutoSize = true;
            this.materialLabel10.Depth = 0;
            this.materialLabel10.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel10.Location = new System.Drawing.Point(16, 128);
            this.materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel10.Name = "materialLabel10";
            this.materialLabel10.Size = new System.Drawing.Size(139, 19);
            this.materialLabel10.TabIndex = 2;
            this.materialLabel10.Text = "Backup Destination";
            // 
            // materialLabel9
            // 
            this.materialLabel9.AutoSize = true;
            this.materialLabel9.Depth = 0;
            this.materialLabel9.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel9.Location = new System.Drawing.Point(400, 24);
            this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel9.Name = "materialLabel9";
            this.materialLabel9.Size = new System.Drawing.Size(97, 19);
            this.materialLabel9.TabIndex = 4;
            this.materialLabel9.Text = "Last Backup :";
            // 
            // btnRestoreBackup
            // 
            this.btnRestoreBackup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRestoreBackup.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRestoreBackup.Depth = 0;
            this.btnRestoreBackup.HighEmphasis = true;
            this.btnRestoreBackup.Icon = null;
            this.btnRestoreBackup.Location = new System.Drawing.Point(40, 384);
            this.btnRestoreBackup.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnRestoreBackup.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRestoreBackup.Name = "btnRestoreBackup";
            this.btnRestoreBackup.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRestoreBackup.Size = new System.Drawing.Size(145, 36);
            this.btnRestoreBackup.TabIndex = 7;
            this.btnRestoreBackup.Text = "Restore Backup";
            this.btnRestoreBackup.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRestoreBackup.UseAccentColor = false;
            this.btnRestoreBackup.UseVisualStyleBackColor = true;
            this.btnRestoreBackup.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(864, 487);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.CharacterCasing = MaterialSkin.Controls.MaterialTabSelector.CustomCharacterCasing.Normal;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialTabSelector1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTabSelector1.Location = new System.Drawing.Point(3, 21);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(730, 43);
            this.materialTabSelector1.TabIndex = 1;
            this.materialTabSelector1.Text = "materialTabSelector1";
            this.materialTabSelector1.Click += new System.EventHandler(this.materialTabSelector1_Click);
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // btnCancelChanges
            // 
            this.btnCancelChanges.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancelChanges.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancelChanges.Depth = 0;
            this.btnCancelChanges.HighEmphasis = true;
            this.btnCancelChanges.Icon = null;
            this.btnCancelChanges.Location = new System.Drawing.Point(624, 472);
            this.btnCancelChanges.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancelChanges.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancelChanges.Name = "btnCancelChanges";
            this.btnCancelChanges.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancelChanges.Size = new System.Drawing.Size(77, 36);
            this.btnCancelChanges.TabIndex = 4;
            this.btnCancelChanges.Text = "cancel";
            this.btnCancelChanges.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancelChanges.UseAccentColor = false;
            this.btnCancelChanges.UseVisualStyleBackColor = true;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSaveChanges.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSaveChanges.Depth = 0;
            this.btnSaveChanges.HighEmphasis = true;
            this.btnSaveChanges.Icon = null;
            this.btnSaveChanges.Location = new System.Drawing.Point(480, 472);
            this.btnSaveChanges.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSaveChanges.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSaveChanges.Size = new System.Drawing.Size(129, 36);
            this.btnSaveChanges.TabIndex = 5;
            this.btnSaveChanges.Text = "Save changes";
            this.btnSaveChanges.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSaveChanges.UseAccentColor = true;
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 533);
            this.Controls.Add(this.btnCancelChanges);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.materialTabControl1);
            this.Controls.Add(this.materialTabSelector1);
            this.Name = "SettingsForm";
            this.Padding = new System.Windows.Forms.Padding(3, 21, 3, 3);
            this.Text = "Settings";
            this.materialTabControl1.ResumeLayout(false);
            this.tabPageUserManagement.ResumeLayout(false);
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            this.groupBoxUserInfo.ResumeLayout(false);
            this.groupBoxUserInfo.PerformLayout();
            this.materialCard4.ResumeLayout(false);
            this.materialCard4.PerformLayout();
            this.groupBoxUserList.ResumeLayout(false);
            this.tabPageNotificationSettings.ResumeLayout(false);
            this.materialCard2.ResumeLayout(false);
            this.materialCard2.PerformLayout();
            this.groupBoxEmailSelection.ResumeLayout(false);
            this.groupBoxEmailSelection.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBoxDeliveryMethod.ResumeLayout(false);
            this.groupBoxDeliveryMethod.PerformLayout();
            this.tabPageDataBackup.ResumeLayout(false);
            this.materialCard3.ResumeLayout(false);
            this.materialCard3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public MaterialTabControl materialTabControl1;
        public TabPage tabPageUserManagement;
        public MaterialCard materialCard1;
        public TabPage tabPageNotificationSettings;
        public MaterialCard materialCard2;
        public TabPage tabPage1;
        public MaterialTabSelector materialTabSelector1;
        public GroupBox groupBoxUserInfo;
        public GroupBox groupBoxUserList;
        public MaterialListView materialListViewUsers;
        public ColumnHeader columnHeader1;
        public ColumnHeader columnHeader2;
        public MaterialButton btnDeleteUser;
        // In your SettingsForm.cs

        public TabPage tabPageDataBackup;
        public MaterialSkin.Controls.MaterialCard materialCard3;
        public MaterialSkin.Controls.MaterialButton btnRestoreBackup;
        public MaterialSkin.Controls.MaterialButton btnPerformBackup;
        public MaterialSkin.Controls.MaterialLabel lblLastBackupDate;
        public MaterialSkin.Controls.MaterialLabel materialLabel9;
        public MaterialSkin.Controls.MaterialLabel materialLabel10;
        public MaterialSkin.Controls.MaterialComboBox cmbBackupSchedule;
        public MaterialSkin.Controls.MaterialLabel materialLabel11;
        public System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;

        private GroupBox groupBoxEmailSelection;
        private MaterialCheckbox checkBoxSelectAllEmails;
        private TextBox txtBoxAddEmail;
        private GroupBox groupBox1;
        public GroupBox groupBoxDeliveryMethod;
        public MaterialCheckbox chkBoxInAppNotification;
        public MaterialComboBox cmbAlertFrequency;
        private Button btnAddEmail;
        public MaterialCheckbox chkBoxEnableEmailNotifications;
        private MaterialFloatingActionButton floatingActionButtonDeleteEmail;
        public MaterialButton btnEditUser;
        public MaterialButton btnAddUser;
        private MaterialCard materialCard4;
        public MaterialTextBox2 txtBoxPassword;
        public MaterialLabel materialLabel8;
        public MaterialTextBox2 txtBoxUsername;
        public MaterialLabel materialLabel7;
        public MaterialTextBox2 txtBoxName;
        public MaterialLabel materialLabel6;
        public MaterialComboBox cmbRoleAssignment;
        public MaterialLabel materialLabel3;
        public MaterialLabel materialLabel1;
        private MaterialButton btnCancelChanges;
        private MaterialButton btnSaveChanges;
        private GroupBox groupBox2;
        private MaterialFloatingActionButton materialFloatingActionButtonAddBackUpDestination;
        private MaterialFloatingActionButton materialFloatingActionButtonDeleteBackupDestination;
        public CheckedListBox checkedListBoxEmails;
        public CheckedListBox checkedListBoxBackUpDestinations;

        // ... other controls ...

    }
    #endregion
}