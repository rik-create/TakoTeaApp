using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Helpers;
using TakoTea.Models;
using TakoTea.Repository;
using TakoTea.Services;


namespace TakoTea.Views.settings
{
    public partial class SettingsForm : MaterialForm
    {
        private readonly Entities _context;

        public SettingsForm()
        {
            InitializeComponent();
            _context = new Entities();
            try
            {
                UserRepository.Initialize(_context);
                SettingsService.Initialize(_context);
                SettingsFormHelper.Initialize(_context);
                DataGridViewHelper.ApplyStylesToAllDataGridViews(this);
                DataGridViewHelper.FormatAllColumnHeaders(this);



            }
            catch (Exception ex)
            {
                _ = MessageBox.Show("Error initializing services: " + ex.Message);
                LoggingHelper.LogActivity("Initialization", "Error initializing services: " + ex.Message);
            }


            DrawerShowIconsWhenHidden = false;
            ThemeConfigurator.ApplyDarkTheme(this);

            try
            {
                // Load user roles
                SettingsFormHelper.LoadUserRoles(cmbRoleAssignment);
                SettingsFormHelper.LoadPaymentMethods(dgvPaymentMethods, bindingNavigatorPaymentMethods, bindingSourcePaymentMethods);
                SettingsFormHelper.LoadSavedEmails(dataGridViewEmails, bindingNavigatorEmails, bindingSourceEmails);

                // Load alert thresholds

                // Load alert frequencies
                SettingsFormHelper.LoadAlertFrequencies(cmbAlertFrequency);

                // Load backup destinations

                SettingsFormHelper.LoadBackUpPaths(dataGridViewBackupPaths, bindingNavigatorBackup, bindingSourceBackUpPaths, TakoTea.Views.Properties.Resources.multiply);

                // Load backup schedules
                SettingsFormHelper.LoadBackupSchedules(cmbBackupSchedule);

                SettingsFormHelper.PopulateUsersListView(materialListViewUsers, UserRepository.GetAllUsers());
                LoggingHelper.LogActivity("LoadSettings", "Settings loaded successfully.");
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show("Error loading settings: " + ex.Message);
                LoggingHelper.LogActivity("LoadSettings", "Error loading settings: " + ex.Message);
            }




  
            Load += SettingsForm_Load;
            btnAddUser.Click += btnAddUser_Click;
            btnRestoreBackup.Click += btnRestoreBackup_Click;
            btnCancelChanges.Click += btnCancelChanges_Click;

            bindingNavigatorDeleteBackupPaths.Click += bindingNavigatorDeleteBackupPaths_Click;


            btnSaveChanges.Hide();
            btnCancelChanges.Hide();
            btnCancelEditUser.Hide();

        }

        private void LoadBackupPaths()
        {
            SettingsFormHelper.LoadBackUpPaths(dataGridViewBackupPaths, bindingNavigatorBackup, bindingSourceBackUpPaths, TakoTea.Views.Properties.Resources.multiply);

        }

        private void btnCancelChanges_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var entry in _context.ChangeTracker.Entries())
                {
                    entry.State = EntityState.Detached;
                }
                SettingsService.LoadSettings(this);
                LoggingHelper.LogActivity("CancelChanges", "Settings reloaded successfully.");
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show("Error loading settings: " + ex.Message);
                LoggingHelper.LogActivity("CancelChanges", "Error loading settings: " + ex.Message);
            }
        }

        private void materialTabSelector1_Click(object sender, EventArgs e)
        {

        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            try
            {
                SettingsService.LoadSettings(this);
                LoggingHelper.LogActivity("FormLoad", "Settings loaded successfully on form load.");
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show("Error loading settings: " + ex.Message);
                LoggingHelper.LogActivity("FormLoad", "Error loading settings on form load: " + ex.Message);
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input fields
                if (string.IsNullOrWhiteSpace(txtBoxName.Text) ||
                    string.IsNullOrWhiteSpace(txtBoxUsername.Text) ||
                    string.IsNullOrWhiteSpace(txtBoxPassword.Text) ||
                    cmbRoleAssignment.SelectedItem == null)
                {
                    MessageBox.Show("All fields must have a value.");
                    return;
                }

                // Hash the password
                string hashedPassword = HashPassword(txtBoxPassword.Text);

                // Create a new User object
                Models.User user = new TakoTea.Models.User
                {
                    Name = txtBoxName.Text,
                    Username = txtBoxUsername.Text,
                    Password = hashedPassword, // Store the hashed password
                    Role = cmbRoleAssignment.SelectedItem.ToString()
                };

                // Add the user
                UserRepository.AddUser(user);

                SettingsFormHelper.PopulateUsersListView(materialListViewUsers, UserRepository.GetAllUsers());

                SettingsFormHelper.LogUserChanges(materialListViewUsers);
                LoggingHelper.LogActivity("AddUser", "User added successfully.");
                txtBoxName.Clear();
                txtBoxUsername.Clear();
                txtBoxPassword.Clear();
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show("Error adding user: " + ex.Message);
                LoggingHelper.LogActivity("AddUser", "Error adding user: " + ex.Message);
            }
        }

        private string HashPassword(string password)
        {
            try
            {
                string salt = BCrypt.Net.BCrypt.GenerateSalt();
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
                LoggingHelper.LogActivity("HashPassword", "Password hashed successfully.");
                return hashedPassword;
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show("Error hashing password: " + ex.Message);
                LoggingHelper.LogActivity("HashPassword", "Error hashing password: " + ex.Message);
                return null;
            }
        }

        private bool isEditingUser = false;
        private User originalUser;

        // ... other methods ...


        private void btnEditUser_Click(object sender, EventArgs e)
        {

            try
            {

                if (materialListViewUsers.SelectedItems.Count > 0)
                {
                    var selectedItem = materialListViewUsers.SelectedItems[0];

                    // Get the username from the first column of the selected item
                    string username = selectedItem.SubItems[0].Text;

                    // Get the user from the context based on the username
                    User userFromContext = _context.Users.FirstOrDefault(u => u.Username == username);


                    if (userFromContext != null)
                    {
                        // Store original details from the context
                        originalUser = new User
                        {
                            UserID = userFromContext.UserID,
                            Name = userFromContext.Name,
                            Username = userFromContext.Username,
                            Role = userFromContext.Role
                            // ... (include other properties) ...
                        };

                        // Load details into controls for editing
                        txtBoxName.Text = originalUser.Name; // Use originalUser
                        txtBoxUsername.Text = originalUser.Username; // Use originalUser
                        cmbRoleAssignment.SelectedItem = originalUser.Role; // Use originalUser
                                                                            // ... (load other properties) ...

                        // Change button text and functionality
                        btnAddUser.Text = "Save Changes";
                        btnAddUser.Click -= btnAddUser_Click;
                        btnAddUser.Click += btnSaveUser_Click;
                        btnAddUser.Location = new System.Drawing.Point(0, 0);
                        btnAddUser.Location = new System.Drawing.Point(165, 398);
                        btnCancelEditUser.Show();
                        btnCancelEditUser.Location = new System.Drawing.Point(0, 0);
                        btnCancelEditUser.Location = new System.Drawing.Point(85, 398);

                        isEditingUser = true;
                        btnEditUser.Hide();
                        btnDeleteUser.Hide();

                    }
                    else
                    {
                        MessageBox.Show("User not found in the database.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error editing user: " + ex.Message);
                LoggingHelper.LogActivity("EditUser", "Error editing user: " + ex.Message);
            }
        }
        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(txtBoxName.Text) ||
        string.IsNullOrWhiteSpace(txtBoxUsername.Text) 
        ||
        cmbRoleAssignment.SelectedItem == null)
                {
                    MessageBox.Show("All fields must have a value.");
                    return;
                }

                // Get the selected item from the ListView
                var selectedItem = materialListViewUsers.SelectedItems[0];

                // Get the username from the first column of the selected item
                string username = selectedItem.SubItems[0].Text;

                // Get the user from the context based on the username
                User userFromContext = _context.Users.FirstOrDefault(u => u.Username == username);


                if (userFromContext != null)
                {
                    // Store original details for comparison
                    User originalUser = new User
                    {
                        Name = userFromContext.Name,
                        Username = userFromContext.Username,
                        Password = userFromContext.Password,
                        Role = userFromContext.Role
                        // ... (include other properties) ...
                    };

                    string hashedPassword = HashPassword(txtBoxPassword.Text);

                    // Update the userFromContext properties with values from the controls
                    userFromContext.Name = txtBoxName.Text;
                    userFromContext.Username = txtBoxUsername.Text;
                    userFromContext.Role = cmbRoleAssignment.SelectedItem.ToString();
                    userFromContext.Password = hashedPassword;
                    // ... (update other properties) ...
                    // Only update password if it's not empty
                    if (!string.IsNullOrEmpty(txtBoxPassword.Text))
                    {
                        userFromContext.Password = hashedPassword;
                    }
                    // Check for changes
                    List<string> changedProperties = GetChangedProperties(originalUser, userFromContext);


                    // Reset button text and functionality
                    btnAddUser.Text = "Add User";
                    btnAddUser.Click -= btnSaveUser_Click;
                    btnAddUser.Click += btnAddUser_Click;

                    btnCancelEditUser.Hide();



                    isEditingUser = false;
                    btnEditUser.Show();
                    btnDeleteUser.Show();



                    // Clear input fields
                    txtBoxName.Clear();
                    txtBoxUsername.Clear();
                    txtBoxPassword.Clear();

                    if (changedProperties.Count > 0)
                    {
                        // Update the user in the repository

                        UserRepository.UpdateUser(userFromContext);

                        // Log the changes

                        // Refresh the users list
                        SettingsFormHelper.PopulateUsersListView(materialListViewUsers, UserRepository.GetAllUsers());
                        SettingsFormHelper.LogUserChanges(originalUser, userFromContext);
                        if (!BCrypt.Net.BCrypt.Verify(txtBoxPassword.Text, originalUser.Password))
                        {
                            LoggingHelper.LogChange(
                                "Users",
                                userFromContext.UserID,
                                "Password",
                                "*****", // Mask the original password
                                "*****", // Mask the new password
                                "Updated",
                                "User password updated",
                                $"User '{userFromContext.Username}' password changed"
                            );
                        }

                        LoggingHelper.LogActivity("EditUser", "User edited successfully.");

                        // Show a message box with the changed properties
                        string changesMessage = "The following properties have been changed:\n\n" + string.Join("\n", changedProperties);
                        MessageBox.Show(changesMessage, "Changes Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No changes were made.", "No Changes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;

                    }
                }
                else
                {
                    MessageBox.Show("User not found in the database.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving user: " + ex.Message);
                LoggingHelper.LogActivity("SaveUser", "Error saving user: " + ex.Message);
            }
        }


        // Add this helper method to your SettingsForm class
        private List<string> GetChangedProperties(User originalUser, User updatedUser)
        {
            List<string> changedProperties = new List<string>();

            if (originalUser.Name != updatedUser.Name)
                changedProperties.Add("Name");

            if (originalUser.Username != updatedUser.Username)
                changedProperties.Add("Username");

            if (originalUser.Role != updatedUser.Role)
                changedProperties.Add("Role");


            // ... (add checks for other properties) ...

            return changedProperties;
        }
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (materialListViewUsers.SelectedItems.Count > 0)
                {
                    var selectedItem = materialListViewUsers.SelectedItems[0];

                    // Get the username from the first column of the selected item
                    string username = selectedItem.SubItems[0].Text;

                    // Get the user from the context based on the username
                    User userFromContext = _context.Users.FirstOrDefault(u => u.Username == username);

                    if (userFromContext != null)
                    {
                        // Delete the user
                        UserRepository.DeleteUser(userFromContext.UserID);

                        // Log the deletion
                        LoggingHelper.LogChange(
                            "Users",
                            userFromContext.UserID,
                            "User",
                            userFromContext.Username,
                            null,
                            "Deleted",
                            "User deleted",
                            $"User '{userFromContext.Username}' deleted"
                        );
                        SettingsFormHelper.LogUserChanges(materialListViewUsers);

                        // Refresh the users list
                        SettingsFormHelper.PopulateUsersListView(materialListViewUsers, UserRepository.GetAllUsers());

                        LoggingHelper.LogActivity("DeleteUser", "User deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("User not found in the database.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select user to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting user: " + ex.Message);
                LoggingHelper.LogActivity("DeleteUser", "Error deleting user: " + ex.Message);
            }
        }

        private void btnPerformBackup_Click(object sender, EventArgs e)
        {
            try
            {
                SettingsService.PerformBackup(this);
                LoggingHelper.LogActivity("Backup", "Backup performed successfully.");

                // Save last backup date to settings
                Entities context = new Entities();
                Setting settings = context.Settings.FirstOrDefault();
                if (settings != null)
                {
                    settings.LastBackUpDate = DateTime.Now;
                }

            }
            catch (Exception ex)
            {
                _ = MessageBox.Show("Error performing backup: " + ex.Message);
                LoggingHelper.LogActivity("Backup", "Backup failed: " + ex.Message);
            }
        }

        private void btnRestoreBackup_Click(object sender, EventArgs e)
        {
            try
            {
                SettingsService.RestoreBackup();
                LoggingHelper.LogActivity("RestoreBackup", "Backup restored successfully.");
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show("Error restoring backup: " + ex.Message);
                LoggingHelper.LogActivity("RestoreBackup", "Error restoring backup: " + ex.Message);
            }
        }

        private void cmbAlertFrequency_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxAddEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddEmail_Click(object sender, EventArgs e)
        {
            try
            {
                string newEmail = txtBoxAddEmail.Text.Trim();

                // Validate email format
                if (!IsValidEmail(newEmail))
                {
                    _ = MessageBox.Show("Invalid email format.");
                    LoggingHelper.LogActivity("AddEmail", "Invalid email format.");
                    return;
                }

                Setting settings = _context.Settings.FirstOrDefault();

                if (settings == null)
                {
                    // Handle case where settings are not found (e.g., create new settings)
                    return;
                }

                // Check if the email already exists in SavedEmails
                string[] savedEmails = settings.SavedEmails?.Split(new[] { '?' }, StringSplitOptions.RemoveEmptyEntries) ?? new string[0];
                if (savedEmails.Contains(newEmail))
                {
                    _ = MessageBox.Show("Email already exists.");
                    LoggingHelper.LogActivity("AddEmail", "Email already exists.");
                    return;
                }

                // Add the new email to SavedEmails
                settings.SavedEmails = settings.SavedEmails + "?" + newEmail;

                // Add the new email to the CheckedListBox

                _ = MessageBox.Show("Email added successfully.");
                txtBoxAddEmail.Text = ""; // Clear the input field

                SettingsFormHelper.LoadSavedEmails(dataGridViewEmails, bindingNavigatorEmails, bindingSourceEmails);
                LoggingHelper.LogActivity("AddEmail", "Email added successfully.");
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show("Error adding email: " + ex.Message);
                LoggingHelper.LogActivity("AddEmail", "Error adding email: " + ex.Message);
            }
        }

        private bool IsValidEmail(string email)
        {
            // You can use a more robust email validation method if needed
            return !string.IsNullOrEmpty(email) && email.Contains("@");
        }



        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            using (System.Data.Entity.DbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // Get the original settings before saving changes
                    Setting originalSettings = _context.Settings.FirstOrDefault();

                    SettingsService.SaveSettings(this);
                    transaction.Commit();
                    _context.SaveChanges();

                    // Get the updated settings after saving changes
                    Setting updatedSettings = _context.Settings.FirstOrDefault();

                    // Log the changes for each setting property
                    LogSettingChanges(originalSettings, updatedSettings);


                    MessageBox.Show("Settings saved successfully.");
                    LoggingHelper.LogActivity("SaveChanges", "Settings saved successfully.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error saving settings: " + ex.Message);
                    LoggingHelper.LogActivity("SaveChanges", "Error saving settings: " + ex.Message);
                }
            }

            SettingsService.LoadSettings(this);
        }

        private void LogSettingChanges(Setting originalSettings, Setting updatedSettings)
        {

            // Log changes for Users
            SettingsFormHelper.LogUserChanges(materialListViewUsers);
            if (originalSettings == null || updatedSettings == null)
                return;

            // Log changes for the 'SavedEmails' property
            if (originalSettings.SavedEmails != updatedSettings.SavedEmails)
            {
                LoggingHelper.LogChange(
                    "Settings",
                    updatedSettings.SettingsID,
                    "SavedEmails",
                    originalSettings.SavedEmails,
                    updatedSettings.SavedEmails,
                    "Updated",
                    "Saved emails updated",
                    "Emails modified in settings"
                );
            }

       


            // ... (add similar blocks for other properties like BackupDestination, BackupSchedule, etc.) 
        }
        private void materialFloatingActionButtonAddBackUpDestination_Click(object sender, EventArgs e)
        {
            try
            {
                // Show a dialog to select a folder
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderBrowserDialog.SelectedPath;

                    
                    LoggingHelper.LogActivity("AddBackupDestination", "Backup destination added: " + selectedPath);

                    // Update the BackupDestination in your settings
                    using (var context = new Entities())
                    {
                        Setting settings = context.Settings.FirstOrDefault();
                        if (settings != null)
                        {
                            if (string.IsNullOrEmpty(settings.BackupDestination))
                            {
                                settings.BackupDestination = selectedPath;
                            }
                            else
                            {
                                settings.BackupDestination += "|" + selectedPath;
                            }
                            context.SaveChanges();
                            LoadBackupPaths();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding backup destination: " + ex.Message);
                LoggingHelper.LogActivity("AddBackupDestination", "Error adding backup destination: " + ex.Message);
            }
        }

        // Helper method to load payment methods into the CheckedListBox



        private void materialFloatingActionButtonAddPaymentMethod_Click_1(object sender, EventArgs e)
        {
            try
            {
                string newPaymentMethod = txtBoxAddPaymentMethod.Text.Trim();

                // Basic validation (you might want to add more robust validation)
                if (string.IsNullOrWhiteSpace(newPaymentMethod))
                {
                    _ = MessageBox.Show("Please enter a payment method.");
                    return;
                }

                // Add the new payment method using your PaymentMethodService
                PaymentMethodService.AddPaymentMethod(newPaymentMethod, _context);


                txtBoxAddPaymentMethod.Text = ""; // Clear the input field
                SettingsFormHelper.LogPaymentMethodChanges(dgvPaymentMethods);
                SettingsFormHelper.LoadPaymentMethods(dgvPaymentMethods, bindingNavigatorPaymentMethods, bindingSourcePaymentMethods);


            }
            catch (Exception ex)
            {
                _ = MessageBox.Show("Error adding payment method: " + ex.Message);
            }
        }

        private void dataGridViewEmails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dataGridViewEmails.Columns[e.ColumnIndex].Name == "DeleteColumn")
            {
                DataGridViewRow clickedRow = dataGridViewEmails.Rows[e.RowIndex];
                string emailToDelete = clickedRow.Cells[0].Value.ToString();
                dataGridViewEmails.Rows.Remove(clickedRow);

                Setting settings = _context.Settings.FirstOrDefault();
                if (settings != null)
                {
                    string[] savedEmails = settings.SavedEmails.Split(new[] { '?' }, StringSplitOptions.RemoveEmptyEntries);
                    settings.SavedEmails = string.Join("?", savedEmails.Where(email => email != emailToDelete));
                }
            }
        }
      
        private void btnCancelChanges_Click_1(object sender, EventArgs e)
        {

        }

        private void btnDeleteUser_Click_1(object sender, EventArgs e)
        {

        }

        private void chkBoxInAppNotification_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewEmails_CellBorderStyleChanged(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorDeleteItemEmails_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewEmails.SelectedRows.Count > 0)
                {
                    // Ask for confirmation
                    DialogResult result = MessageBox.Show($"Are you sure you want to delete {dataGridViewEmails.SelectedRows.Count} email(s)?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        // Create a list to store the emails to delete
                        List<string> emailsToDelete = new List<string>();

                        // Get the selected rows
                        foreach (DataGridViewRow row in dataGridViewEmails.SelectedRows)
                        {
                            string emailToDelete = row.Cells[0].Value.ToString();
                            emailsToDelete.Add(emailToDelete);
                        }


                        foreach (DataGridViewRow row in dataGridViewEmails.SelectedRows)
                        {
                            if (row.Cells[0].Value != null)
                            {
                                string emailToDelete = row.Cells[0].Value.ToString();

                                // Remove the email from the saved emails in your settings
                                Setting settings = _context.Settings.FirstOrDefault();
                                if (settings != null)
                                {
                                    string[] savedEmails = settings.SavedEmails.Split(new[] { '?' }, StringSplitOptions.RemoveEmptyEntries);
                                    settings.SavedEmails = string.Join("?", savedEmails.Where(email => email != emailToDelete));
                                }
                            }
                        }

                        // Remove the selected rows from the DataGridView
                        foreach (DataGridViewRow row in dataGridViewEmails.SelectedRows)
                        {
                            dataGridViewEmails.Rows.Remove(row);
                        }

                        // Save changes to the database
                        _context.SaveChanges();
                    }
                }
                else
                {
                    MessageBox.Show("Please select at least one email to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting email(s): " + ex.Message);
                LoggingHelper.LogActivity("DeleteEmail", "Error deleting email(s): " + ex.Message);
            }
        }
        private void deletePaymentMethods_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the selected rows
                var selectedRows = dgvPaymentMethods.SelectedRows;

                // Ask for confirmation if there are any selected rows
                if (selectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show($"Are you sure you want to delete {selectedRows.Count} payment method(s)?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        // Iterate through the selected rows and delete the payment methods
                        foreach (DataGridViewRow row in selectedRows)
                        {
                            string paymentMethodToDelete = row.Cells[0].Value.ToString();
                            PaymentMethodService.DeletePaymentMethod(paymentMethodToDelete, _context);
                        }

                        // Refresh the DataGridView
                        dgvPaymentMethods.DataSource = null;
                        dgvPaymentMethods.DataSource = bindingSourcePaymentMethods;
                        SettingsFormHelper.LoadPaymentMethods(dgvPaymentMethods, bindingNavigatorPaymentMethods, bindingSourcePaymentMethods);
                        SettingsFormHelper.LogPaymentMethodChanges(dgvPaymentMethods);

                    }
                }
                else
                {
                    MessageBox.Show("Please select at least one payment method to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting payment method(s): " + ex.Message);
                LoggingHelper.LogActivity("DeletePaymentMethod", "Error deleting payment method(s): " + ex.Message);
            }
        }
        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (materialTabControl1.SelectedIndex == 2)
            {
                btnSaveChanges.Show();
                btnCancelChanges.Show();
         
            }
            else
            {
                btnSaveChanges.Hide();
                btnCancelChanges.Hide();
            }
        }

        private void btnCancelEditUser_Click(object sender, EventArgs e)
        {
            // Reset button text and functionality
            btnAddUser.Text = "Add User";
            btnAddUser.Click -= btnSaveUser_Click;
            btnAddUser.Click += btnAddUser_Click;

            // Hide the Cancel button
            btnCancelEditUser.Hide();

            isEditingUser = false;

            // Clear input fields
            txtBoxName.Clear();
            txtBoxUsername.Clear();
            txtBoxPassword.Clear();
            btnEditUser.Show();
            btnDeleteUser.Show();



            btnAddUser.Location = new System.Drawing.Point(0, 0);
            btnAddUser.Location = new System.Drawing.Point(183, 398);
            // ... (clear other input fields) ...
        }

        private void dataGridViewBackupPaths_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void bindingNavigatorDeleteBackupPaths_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = dataGridViewBackupPaths.SelectedRows;

            if (selectedRows.Count > 0)
            {
                // Call the DeleteBackupPath method with the selected rows
                SettingsFormHelper.DeleteBackupPath(selectedRows);
            }
            else
            {
                // Show a message box if no rows are selected
                MessageBox.Show("Please select at least one backup path to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
    
}
