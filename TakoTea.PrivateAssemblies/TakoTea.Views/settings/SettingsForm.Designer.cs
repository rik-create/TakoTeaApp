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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPageUserManagement = new System.Windows.Forms.TabPage();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.btnEditUser = new MaterialSkin.Controls.MaterialButton();
            this.btnDeleteUser = new MaterialSkin.Controls.MaterialButton();
            this.groupBoxUserInfo = new System.Windows.Forms.GroupBox();
            this.materialCard4 = new MaterialSkin.Controls.MaterialCard();
            this.txtBoxPassword = new MaterialSkin.Controls.MaterialTextBox2();
            this.btnCancelEditUser = new MaterialSkin.Controls.MaterialButton();
            this.btnAddUser = new MaterialSkin.Controls.MaterialButton();
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
            this.bindingNavigatorEmails = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItemEmails = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dataGridViewEmails = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxDeliveryMethod = new System.Windows.Forms.GroupBox();
            this.chkBoxEnableEmailNotifications = new MaterialSkin.Controls.MaterialCheckbox();
            this.cmbAlertFrequency = new MaterialSkin.Controls.MaterialComboBox();
            this.chkBoxInAppNotification = new MaterialSkin.Controls.MaterialCheckbox();
            this.tabPageDataBackup = new System.Windows.Forms.TabPage();
            this.materialCard3 = new MaterialSkin.Controls.MaterialCard();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewBackupPaths = new System.Windows.Forms.DataGridView();
            this.bindingNavigatorBackup = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem1 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem1 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorDeleteBackupPaths = new System.Windows.Forms.ToolStripButton();
            this.materialFloatingActionButtonAddBackUpDestination = new MaterialSkin.Controls.MaterialFloatingActionButton();
            this.cmbBackupSchedule = new MaterialSkin.Controls.MaterialComboBox();
            this.btnPerformBackup = new MaterialSkin.Controls.MaterialButton();
            this.lblLastBackupDate = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel11 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            this.btnRestoreBackup = new MaterialSkin.Controls.MaterialButton();
            this.tabPagePaymentMethod = new System.Windows.Forms.TabPage();
            this.materialCard5 = new MaterialSkin.Controls.MaterialCard();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bindingNavigatorPaymentMethods = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.bindingSourcePaymentMethods = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.deletePaymentMethods = new System.Windows.Forms.ToolStripButton();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.dgvPaymentMethods = new System.Windows.Forms.DataGridView();
            this.materialFloatingActionButtonAddPaymentMethod = new System.Windows.Forms.Button();
            this.txtBoxAddPaymentMethod = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.btnCancelChanges = new MaterialSkin.Controls.MaterialButton();
            this.btnSaveChanges = new MaterialSkin.Controls.MaterialButton();
            this.bindingSourceEmails = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceBackUpPaths = new System.Windows.Forms.BindingSource(this.components);
            this.materialTabControl1.SuspendLayout();
            this.tabPageUserManagement.SuspendLayout();
            this.materialCard1.SuspendLayout();
            this.groupBoxUserInfo.SuspendLayout();
            this.materialCard4.SuspendLayout();
            this.groupBoxUserList.SuspendLayout();
            this.tabPageNotificationSettings.SuspendLayout();
            this.materialCard2.SuspendLayout();
            this.groupBoxEmailSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorEmails)).BeginInit();
            this.bindingNavigatorEmails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmails)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBoxDeliveryMethod.SuspendLayout();
            this.tabPageDataBackup.SuspendLayout();
            this.materialCard3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBackupPaths)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorBackup)).BeginInit();
            this.bindingNavigatorBackup.SuspendLayout();
            this.tabPagePaymentMethod.SuspendLayout();
            this.materialCard5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorPaymentMethods)).BeginInit();
            this.bindingNavigatorPaymentMethods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePaymentMethods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentMethods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceEmails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBackUpPaths)).BeginInit();
            this.SuspendLayout();
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPageUserManagement);
            this.materialTabControl1.Controls.Add(this.tabPageNotificationSettings);
            this.materialTabControl1.Controls.Add(this.tabPageDataBackup);
            this.materialTabControl1.Controls.Add(this.tabPagePaymentMethod);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl1.Location = new System.Drawing.Point(3, 64);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(730, 466);
            this.materialTabControl1.TabIndex = 0;
            this.materialTabControl1.SelectedIndexChanged += new System.EventHandler(this.materialTabControl1_SelectedIndexChanged);
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
            this.materialCard1.Controls.Add(this.btnEditUser);
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
            // btnEditUser
            // 
            this.btnEditUser.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEditUser.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnEditUser.Depth = 0;
            this.btnEditUser.HighEmphasis = true;
            this.btnEditUser.Icon = null;
            this.btnEditUser.Location = new System.Drawing.Point(152, 384);
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
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
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
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // groupBoxUserInfo
            // 
            this.groupBoxUserInfo.Controls.Add(this.materialCard4);
            this.groupBoxUserInfo.Location = new System.Drawing.Point(382, 15);
            this.groupBoxUserInfo.Name = "groupBoxUserInfo";
            this.groupBoxUserInfo.Size = new System.Drawing.Size(322, 401);
            this.groupBoxUserInfo.TabIndex = 1;
            this.groupBoxUserInfo.TabStop = false;
            this.groupBoxUserInfo.Text = "User Information";
            // 
            // materialCard4
            // 
            this.materialCard4.AutoScroll = true;
            this.materialCard4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard4.Controls.Add(this.txtBoxPassword);
            this.materialCard4.Controls.Add(this.btnCancelEditUser);
            this.materialCard4.Controls.Add(this.btnAddUser);
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
            this.materialCard4.Size = new System.Drawing.Size(316, 382);
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
            // btnCancelEditUser
            // 
            this.btnCancelEditUser.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancelEditUser.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancelEditUser.Depth = 0;
            this.btnCancelEditUser.HighEmphasis = true;
            this.btnCancelEditUser.Icon = null;
            this.btnCancelEditUser.Location = new System.Drawing.Point(112, 398);
            this.btnCancelEditUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelEditUser.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancelEditUser.Name = "btnCancelEditUser";
            this.btnCancelEditUser.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancelEditUser.Size = new System.Drawing.Size(77, 36);
            this.btnCancelEditUser.TabIndex = 2;
            this.btnCancelEditUser.Text = "Cancel";
            this.btnCancelEditUser.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancelEditUser.UseAccentColor = false;
            this.btnCancelEditUser.UseVisualStyleBackColor = true;
            this.btnCancelEditUser.Click += new System.EventHandler(this.btnCancelEditUser_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddUser.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAddUser.Depth = 0;
            this.btnAddUser.HighEmphasis = true;
            this.btnAddUser.Icon = null;
            this.btnAddUser.Location = new System.Drawing.Point(192, 398);
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
            this.groupBoxEmailSelection.Controls.Add(this.bindingNavigatorEmails);
            this.groupBoxEmailSelection.Controls.Add(this.dataGridViewEmails);
            this.groupBoxEmailSelection.Location = new System.Drawing.Point(384, 24);
            this.groupBoxEmailSelection.Name = "groupBoxEmailSelection";
            this.groupBoxEmailSelection.Size = new System.Drawing.Size(312, 320);
            this.groupBoxEmailSelection.TabIndex = 6;
            this.groupBoxEmailSelection.TabStop = false;
            this.groupBoxEmailSelection.Text = "Select Email";
            // 
            // bindingNavigatorEmails
            // 
            this.bindingNavigatorEmails.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigatorEmails.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigatorEmails.DeleteItem = null;
            this.bindingNavigatorEmails.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItemEmails});
            this.bindingNavigatorEmails.Location = new System.Drawing.Point(3, 16);
            this.bindingNavigatorEmails.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigatorEmails.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigatorEmails.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigatorEmails.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigatorEmails.Name = "bindingNavigatorEmails";
            this.bindingNavigatorEmails.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigatorEmails.Size = new System.Drawing.Size(306, 25);
            this.bindingNavigatorEmails.TabIndex = 1;
            this.bindingNavigatorEmails.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItemEmails
            // 
            this.bindingNavigatorDeleteItemEmails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItemEmails.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItemEmails.Image")));
            this.bindingNavigatorDeleteItemEmails.Name = "bindingNavigatorDeleteItemEmails";
            this.bindingNavigatorDeleteItemEmails.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItemEmails.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItemEmails.Text = "Delete";
            this.bindingNavigatorDeleteItemEmails.Click += new System.EventHandler(this.bindingNavigatorDeleteItemEmails_Click);
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // dataGridViewEmails
            // 
            this.dataGridViewEmails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmails.Location = new System.Drawing.Point(0, 40);
            this.dataGridViewEmails.Name = "dataGridViewEmails";
            this.dataGridViewEmails.Size = new System.Drawing.Size(312, 272);
            this.dataGridViewEmails.TabIndex = 0;
            this.dataGridViewEmails.CellBorderStyleChanged += new System.EventHandler(this.dataGridViewEmails_CellBorderStyleChanged);
            this.dataGridViewEmails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEmails_CellClick);
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
            this.chkBoxInAppNotification.CheckedChanged += new System.EventHandler(this.chkBoxInAppNotification_CheckedChanged);
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
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.materialFloatingActionButtonAddBackUpDestination);
            this.groupBox2.Controls.Add(this.cmbBackupSchedule);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewBackupPaths);
            this.panel1.Controls.Add(this.bindingNavigatorBackup);
            this.panel1.Location = new System.Drawing.Point(8, 160);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(664, 200);
            this.panel1.TabIndex = 107;
            // 
            // dataGridViewBackupPaths
            // 
            this.dataGridViewBackupPaths.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBackupPaths.Location = new System.Drawing.Point(0, 24);
            this.dataGridViewBackupPaths.Name = "dataGridViewBackupPaths";
            this.dataGridViewBackupPaths.Size = new System.Drawing.Size(660, 176);
            this.dataGridViewBackupPaths.TabIndex = 107;
            this.dataGridViewBackupPaths.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBackupPaths_CellClick);
            // 
            // bindingNavigatorBackup
            // 
            this.bindingNavigatorBackup.AddNewItem = this.bindingNavigatorAddNewItem1;
            this.bindingNavigatorBackup.CountItem = this.bindingNavigatorCountItem1;
            this.bindingNavigatorBackup.DeleteItem = null;
            this.bindingNavigatorBackup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem1,
            this.bindingNavigatorMovePreviousItem1,
            this.bindingNavigatorSeparator3,
            this.bindingNavigatorPositionItem1,
            this.bindingNavigatorCountItem1,
            this.bindingNavigatorSeparator4,
            this.bindingNavigatorMoveNextItem1,
            this.bindingNavigatorMoveLastItem1,
            this.bindingNavigatorSeparator5,
            this.bindingNavigatorAddNewItem1,
            this.bindingNavigatorDeleteBackupPaths});
            this.bindingNavigatorBackup.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigatorBackup.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
            this.bindingNavigatorBackup.MoveLastItem = this.bindingNavigatorMoveLastItem1;
            this.bindingNavigatorBackup.MoveNextItem = this.bindingNavigatorMoveNextItem1;
            this.bindingNavigatorBackup.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
            this.bindingNavigatorBackup.Name = "bindingNavigatorBackup";
            this.bindingNavigatorBackup.PositionItem = this.bindingNavigatorPositionItem1;
            this.bindingNavigatorBackup.Size = new System.Drawing.Size(664, 25);
            this.bindingNavigatorBackup.TabIndex = 106;
            this.bindingNavigatorBackup.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem1
            // 
            this.bindingNavigatorAddNewItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem1.Image")));
            this.bindingNavigatorAddNewItem1.Name = "bindingNavigatorAddNewItem1";
            this.bindingNavigatorAddNewItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem1.Text = "Add new";
            // 
            // bindingNavigatorCountItem1
            // 
            this.bindingNavigatorCountItem1.Name = "bindingNavigatorCountItem1";
            this.bindingNavigatorCountItem1.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem1.Text = "of {0}";
            this.bindingNavigatorCountItem1.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem1
            // 
            this.bindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem1.Image")));
            this.bindingNavigatorMoveFirstItem1.Name = "bindingNavigatorMoveFirstItem1";
            this.bindingNavigatorMoveFirstItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem1.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem1
            // 
            this.bindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem1.Image")));
            this.bindingNavigatorMovePreviousItem1.Name = "bindingNavigatorMovePreviousItem1";
            this.bindingNavigatorMovePreviousItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem1.Text = "Move previous";
            // 
            // bindingNavigatorSeparator3
            // 
            this.bindingNavigatorSeparator3.Name = "bindingNavigatorSeparator3";
            this.bindingNavigatorSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem1
            // 
            this.bindingNavigatorPositionItem1.AccessibleName = "Position";
            this.bindingNavigatorPositionItem1.AutoSize = false;
            this.bindingNavigatorPositionItem1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem1.Name = "bindingNavigatorPositionItem1";
            this.bindingNavigatorPositionItem1.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem1.Text = "0";
            this.bindingNavigatorPositionItem1.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator4
            // 
            this.bindingNavigatorSeparator4.Name = "bindingNavigatorSeparator4";
            this.bindingNavigatorSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem1
            // 
            this.bindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem1.Image")));
            this.bindingNavigatorMoveNextItem1.Name = "bindingNavigatorMoveNextItem1";
            this.bindingNavigatorMoveNextItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem1.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem1
            // 
            this.bindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem1.Image")));
            this.bindingNavigatorMoveLastItem1.Name = "bindingNavigatorMoveLastItem1";
            this.bindingNavigatorMoveLastItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem1.Text = "Move last";
            // 
            // bindingNavigatorSeparator5
            // 
            this.bindingNavigatorSeparator5.Name = "bindingNavigatorSeparator5";
            this.bindingNavigatorSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorDeleteBackupPaths
            // 
            this.bindingNavigatorDeleteBackupPaths.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteBackupPaths.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteBackupPaths.Image")));
            this.bindingNavigatorDeleteBackupPaths.Name = "bindingNavigatorDeleteBackupPaths";
            this.bindingNavigatorDeleteBackupPaths.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteBackupPaths.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteBackupPaths.Text = "Delete";
            // 
            // materialFloatingActionButtonAddBackUpDestination
            // 
            this.materialFloatingActionButtonAddBackUpDestination.Depth = 0;
            this.materialFloatingActionButtonAddBackUpDestination.Icon = global::TakoTea.Views.Properties.Resources.plus_white1;
            this.materialFloatingActionButtonAddBackUpDestination.Image = global::TakoTea.Views.Properties.Resources.plus;
            this.materialFloatingActionButtonAddBackUpDestination.Location = new System.Drawing.Point(584, 120);
            this.materialFloatingActionButtonAddBackUpDestination.Mini = true;
            this.materialFloatingActionButtonAddBackUpDestination.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFloatingActionButtonAddBackUpDestination.Name = "materialFloatingActionButtonAddBackUpDestination";
            this.materialFloatingActionButtonAddBackUpDestination.Size = new System.Drawing.Size(40, 40);
            this.materialFloatingActionButtonAddBackUpDestination.TabIndex = 104;
            this.materialFloatingActionButtonAddBackUpDestination.UseVisualStyleBackColor = true;
            this.materialFloatingActionButtonAddBackUpDestination.Click += new System.EventHandler(this.materialFloatingActionButtonAddBackUpDestination_Click);
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
            this.btnPerformBackup.Click += new System.EventHandler(this.btnPerformBackup_Click);
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
            // tabPagePaymentMethod
            // 
            this.tabPagePaymentMethod.Controls.Add(this.materialCard5);
            this.tabPagePaymentMethod.Location = new System.Drawing.Point(4, 22);
            this.tabPagePaymentMethod.Name = "tabPagePaymentMethod";
            this.tabPagePaymentMethod.Size = new System.Drawing.Size(722, 440);
            this.tabPagePaymentMethod.TabIndex = 3;
            this.tabPagePaymentMethod.Text = "Payments";
            this.tabPagePaymentMethod.UseVisualStyleBackColor = true;
            // 
            // materialCard5
            // 
            this.materialCard5.AutoScroll = true;
            this.materialCard5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard5.Controls.Add(this.groupBox3);
            this.materialCard5.Depth = 0;
            this.materialCard5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCard5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard5.Location = new System.Drawing.Point(0, 0);
            this.materialCard5.Margin = new System.Windows.Forms.Padding(10);
            this.materialCard5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard5.Name = "materialCard5";
            this.materialCard5.Padding = new System.Windows.Forms.Padding(10);
            this.materialCard5.Size = new System.Drawing.Size(722, 440);
            this.materialCard5.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bindingNavigatorPaymentMethods);
            this.groupBox3.Controls.Add(this.dgvPaymentMethods);
            this.groupBox3.Controls.Add(this.materialFloatingActionButtonAddPaymentMethod);
            this.groupBox3.Controls.Add(this.txtBoxAddPaymentMethod);
            this.groupBox3.Location = new System.Drawing.Point(25, 40);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(319, 337);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Payment Methods";
            // 
            // bindingNavigatorPaymentMethods
            // 
            this.bindingNavigatorPaymentMethods.AddNewItem = this.toolStripButton1;
            this.bindingNavigatorPaymentMethods.BindingSource = this.bindingSourcePaymentMethods;
            this.bindingNavigatorPaymentMethods.CountItem = this.toolStripLabel1;
            this.bindingNavigatorPaymentMethods.DeleteItem = null;
            this.bindingNavigatorPaymentMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator1,
            this.toolStripTextBox1,
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripSeparator3,
            this.toolStripButton1,
            this.deletePaymentMethods,
            this.toolStripProgressBar1});
            this.bindingNavigatorPaymentMethods.Location = new System.Drawing.Point(3, 16);
            this.bindingNavigatorPaymentMethods.MoveFirstItem = this.toolStripButton3;
            this.bindingNavigatorPaymentMethods.MoveLastItem = this.toolStripButton6;
            this.bindingNavigatorPaymentMethods.MoveNextItem = this.toolStripButton5;
            this.bindingNavigatorPaymentMethods.MovePreviousItem = this.toolStripButton4;
            this.bindingNavigatorPaymentMethods.Name = "bindingNavigatorPaymentMethods";
            this.bindingNavigatorPaymentMethods.PositionItem = this.toolStripTextBox1;
            this.bindingNavigatorPaymentMethods.Size = new System.Drawing.Size(313, 25);
            this.bindingNavigatorPaymentMethods.TabIndex = 108;
            this.bindingNavigatorPaymentMethods.Text = "bindingNavigator1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.RightToLeftAutoMirrorImage = true;
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Add new";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(35, 22);
            this.toolStripLabel1.Text = "of {0}";
            this.toolStripLabel1.ToolTipText = "Total number of items";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.RightToLeftAutoMirrorImage = true;
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Move first";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.RightToLeftAutoMirrorImage = true;
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Move previous";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.AccessibleName = "Position";
            this.toolStripTextBox1.AutoSize = false;
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(50, 23);
            this.toolStripTextBox1.Text = "0";
            this.toolStripTextBox1.ToolTipText = "Current position";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.RightToLeftAutoMirrorImage = true;
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "Move next";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.RightToLeftAutoMirrorImage = true;
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "Move last";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // deletePaymentMethods
            // 
            this.deletePaymentMethods.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deletePaymentMethods.Image = ((System.Drawing.Image)(resources.GetObject("deletePaymentMethods.Image")));
            this.deletePaymentMethods.Name = "deletePaymentMethods";
            this.deletePaymentMethods.RightToLeftAutoMirrorImage = true;
            this.deletePaymentMethods.Size = new System.Drawing.Size(23, 22);
            this.deletePaymentMethods.Text = "Delete";
            this.deletePaymentMethods.Click += new System.EventHandler(this.deletePaymentMethods_Click);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 15);
            // 
            // dgvPaymentMethods
            // 
            this.dgvPaymentMethods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaymentMethods.Location = new System.Drawing.Point(8, 40);
            this.dgvPaymentMethods.Name = "dgvPaymentMethods";
            this.dgvPaymentMethods.Size = new System.Drawing.Size(304, 248);
            this.dgvPaymentMethods.TabIndex = 107;
            // 
            // materialFloatingActionButtonAddPaymentMethod
            // 
            this.materialFloatingActionButtonAddPaymentMethod.Location = new System.Drawing.Point(224, 296);
            this.materialFloatingActionButtonAddPaymentMethod.Name = "materialFloatingActionButtonAddPaymentMethod";
            this.materialFloatingActionButtonAddPaymentMethod.Size = new System.Drawing.Size(75, 23);
            this.materialFloatingActionButtonAddPaymentMethod.TabIndex = 106;
            this.materialFloatingActionButtonAddPaymentMethod.Text = "Add";
            this.materialFloatingActionButtonAddPaymentMethod.UseVisualStyleBackColor = true;
            this.materialFloatingActionButtonAddPaymentMethod.Click += new System.EventHandler(this.materialFloatingActionButtonAddPaymentMethod_Click_1);
            // 
            // txtBoxAddPaymentMethod
            // 
            this.txtBoxAddPaymentMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxAddPaymentMethod.Location = new System.Drawing.Point(16, 296);
            this.txtBoxAddPaymentMethod.Name = "txtBoxAddPaymentMethod";
            this.txtBoxAddPaymentMethod.Size = new System.Drawing.Size(200, 22);
            this.txtBoxAddPaymentMethod.TabIndex = 105;
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
            this.btnCancelChanges.Click += new System.EventHandler(this.btnCancelChanges_Click_1);
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
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.materialTabControl1.ResumeLayout(false);
            this.tabPageUserManagement.ResumeLayout(false);
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            this.groupBoxUserInfo.ResumeLayout(false);
            this.materialCard4.ResumeLayout(false);
            this.materialCard4.PerformLayout();
            this.groupBoxUserList.ResumeLayout(false);
            this.tabPageNotificationSettings.ResumeLayout(false);
            this.materialCard2.ResumeLayout(false);
            this.materialCard2.PerformLayout();
            this.groupBoxEmailSelection.ResumeLayout(false);
            this.groupBoxEmailSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorEmails)).EndInit();
            this.bindingNavigatorEmails.ResumeLayout(false);
            this.bindingNavigatorEmails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmails)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBoxDeliveryMethod.ResumeLayout(false);
            this.groupBoxDeliveryMethod.PerformLayout();
            this.tabPageDataBackup.ResumeLayout(false);
            this.materialCard3.ResumeLayout(false);
            this.materialCard3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBackupPaths)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorBackup)).EndInit();
            this.bindingNavigatorBackup.ResumeLayout(false);
            this.bindingNavigatorBackup.PerformLayout();
            this.tabPagePaymentMethod.ResumeLayout(false);
            this.materialCard5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorPaymentMethods)).EndInit();
            this.bindingNavigatorPaymentMethods.ResumeLayout(false);
            this.bindingNavigatorPaymentMethods.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePaymentMethods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentMethods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceEmails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBackUpPaths)).EndInit();
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
        private TextBox txtBoxAddEmail;
        private GroupBox groupBox1;
        public GroupBox groupBoxDeliveryMethod;
        public MaterialCheckbox chkBoxInAppNotification;
        public MaterialComboBox cmbAlertFrequency;
        private Button btnAddEmail;
        public MaterialCheckbox chkBoxEnableEmailNotifications;
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
        private TabPage tabPagePaymentMethod;
        public MaterialCard materialCard5;
        private GroupBox groupBox3;
        private Button materialFloatingActionButtonAddPaymentMethod;
        private TextBox txtBoxAddPaymentMethod;
        private DataGridView dataGridViewEmails;
        private DataGridView dgvPaymentMethods;
        private BindingNavigator bindingNavigatorEmails;
        private ToolStripButton bindingNavigatorAddNewItem;
        private ToolStripLabel bindingNavigatorCountItem;
        private ToolStripButton bindingNavigatorDeleteItemEmails;
        private ToolStripButton bindingNavigatorMoveFirstItem;
        private ToolStripButton bindingNavigatorMovePreviousItem;
        private ToolStripSeparator bindingNavigatorSeparator;
        private ToolStripTextBox bindingNavigatorPositionItem;
        private ToolStripSeparator bindingNavigatorSeparator1;
        private ToolStripButton bindingNavigatorMoveNextItem;
        private ToolStripButton bindingNavigatorMoveLastItem;
        private ToolStripSeparator bindingNavigatorSeparator2;
        private BindingNavigator bindingNavigatorPaymentMethods;
        private ToolStripButton toolStripButton1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripButton deletePaymentMethods;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripTextBox toolStripTextBox1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripButton5;
        private ToolStripButton toolStripButton6;
        private ToolStripSeparator toolStripSeparator3;
        private BindingSource bindingSourceEmails;
        private BindingSource bindingSourcePaymentMethods;
        public MaterialButton btnCancelEditUser;
        private ToolStripProgressBar toolStripProgressBar1;
        private BindingNavigator bindingNavigatorBackup;
        private ToolStripButton bindingNavigatorAddNewItem1;
        private ToolStripLabel bindingNavigatorCountItem1;
        private ToolStripButton bindingNavigatorDeleteBackupPaths;
        private ToolStripButton bindingNavigatorMoveFirstItem1;
        private ToolStripButton bindingNavigatorMovePreviousItem1;
        private ToolStripSeparator bindingNavigatorSeparator3;
        private ToolStripTextBox bindingNavigatorPositionItem1;
        private ToolStripSeparator bindingNavigatorSeparator4;
        private ToolStripButton bindingNavigatorMoveNextItem1;
        private ToolStripButton bindingNavigatorMoveLastItem1;
        private ToolStripSeparator bindingNavigatorSeparator5;
        private Panel panel1;
        private BindingSource bindingSourceBackUpPaths;
        public DataGridView dataGridViewBackupPaths;

        // ... other controls ...

    }
    #endregion
}