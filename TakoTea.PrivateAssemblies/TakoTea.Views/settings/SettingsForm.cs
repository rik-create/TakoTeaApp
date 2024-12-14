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
                LoggingHelper.LogActivity("Initialization", "Services initialized successfully.");
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show("Error initializing services: " + ex.Message);
                LoggingHelper.LogActivity("Initialization", "Error initializing services: " + ex.Message);
            }

            DataGridViewHelper.ApplyStylesToAllDataGridViews(this);
            DataGridViewHelper.AddIconButtonColumn(dataGridViewEmails, "DeleteColumn", "Delete", TakoTea.Views.Properties.Resources.multiply);
            DataGridViewHelper.AddIconButtonColumn(dgvPaymentMethods, "DeleteColumn", "Delete", TakoTea.Views.Properties.Resources.multiply);

            DrawerShowIconsWhenHidden = false;
            ThemeConfigurator.ApplyDarkTheme(this);

            try
            {
                // Load user roles
                SettingsFormHelper.LoadUserRoles(cmbRoleAssignment);
                SettingsFormHelper.LoadPaymentMethods(dgvPaymentMethods);
                // Load alert thresholds

                // Load alert frequencies
                SettingsFormHelper.LoadAlertFrequencies(cmbAlertFrequency);

                // Load backup destinations

                SettingsFormHelper.LoadSavedEmails(dataGridViewEmails);
                SettingsFormHelper.LoadBackUpPaths(checkedListBoxBackUpDestinations);

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
            btnEditUser.Click += btnEditUser_Click;
            btnDeleteUser.Click += btnDeleteUser_Click;
            btnPerformBackup.Click += btnPerformBackup_Click;
            btnRestoreBackup.Click += btnRestoreBackup_Click;
            btnSaveChanges.Click += btnSaveChanges_Click;
            btnCancelChanges.Click += btnCancelChanges_Click;
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
                LoggingHelper.LogActivity("AddUser", "User added successfully.");
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

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the selected user from the ListView
                if (!(materialListViewUsers.SelectedItems[0].Tag is TakoTea.Models.User selectedUser))
                {
                    return;
                }

                // Update the user's properties with values from the input fields
                selectedUser.Name = txtBoxName.Text;
                // ... update other properties as needed ...

                // Edit the user
                UserRepository.UpdateUser(selectedUser);

                // Refresh the users list
                SettingsService.LoadSettings(this);
                LoggingHelper.LogActivity("EditUser", "User edited successfully.");
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show("Error editing user: " + ex.Message);
                LoggingHelper.LogActivity("EditUser", "Error editing user: " + ex.Message);
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the selected user from the ListView
                if (!(materialListViewUsers.SelectedItems[0].Tag is TakoTea.Models.User selectedUser))
                {
                    return;
                }

                // Delete the user
                UserRepository.DeleteUser(selectedUser.UserID);

                // Refresh the users list
                SettingsService.LoadSettings(this);
                LoggingHelper.LogActivity("DeleteUser", "User deleted successfully.");
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show("Error deleting user: " + ex.Message);
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

                SettingsFormHelper.LoadSavedEmails(dataGridViewEmails);
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
                    SettingsService.SaveSettings(this);
                    transaction.Commit();
                    _context.SaveChanges();

                    _ = MessageBox.Show("Settings saved successfully.");
                    LoggingHelper.LogActivity("SaveChanges", "Settings saved successfully.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _ = MessageBox.Show("Error saving settings: " + ex.Message);
                    LoggingHelper.LogActivity("SaveChanges", "Error saving settings: " + ex.Message);
                }
            }

            SettingsService.LoadSettings(this);
        }

     
        private void materialFloatingActionButtonAddBackUpDestination_Click(object sender, EventArgs e)
        {
            // Show a dialog to select a folder
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = folderBrowserDialog.SelectedPath;

                // Add the selected path to the CheckedListBox
                _ = checkedListBoxBackUpDestinations.Items.Add(selectedPath);
                LoggingHelper.LogActivity("AddBackupDestination", "Backup destination added: " + selectedPath);

                // Save the selected path to the database
               
            }
        }

        private void materialFloatingActionButtonDeleteBackupDestination_Click(object sender, EventArgs e)
        {
            if (checkedListBoxBackUpDestinations.CheckedItems.Count == 0)
            {
                _ = MessageBox.Show("Please select at least one backup destination to delete.");
                LoggingHelper.LogActivity("DeleteBackupDestination", "No backup destination selected for deletion.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete the selected backup destinations?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Remove the selected items from the CheckedListBox
                for (int i = checkedListBoxBackUpDestinations.CheckedItems.Count - 1; i >= 0; i--)
                {
                    string removedPath = checkedListBoxBackUpDestinations.CheckedItems[i].ToString();
                    checkedListBoxBackUpDestinations.Items.Remove(checkedListBoxBackUpDestinations.CheckedItems[i]);
                    LoggingHelper.LogActivity("DeleteBackupDestination", "Backup destination deleted: " + removedPath);
                }
            }
        }

     

        // Helper method to load payment methods into the CheckedListBox
        private void LoadPaymentMethods()
        {
            // Assuming 'dgvPaymentMethods' is your DataGridView
            dgvPaymentMethods.Rows.Clear();

            List<string> paymentMethods = PaymentMethodService.GetAllPaymentMethods();
            foreach (string method in paymentMethods)
            {
                dgvPaymentMethods.Rows.Add(method); // Add each payment method to a new row
            }
        }


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

                // Refresh the payment methods in the CheckedListBox
                LoadPaymentMethods();

                txtBoxAddPaymentMethod.Text = ""; // Clear the input field
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
        private void btnSaveChanges_Click_1(object sender, EventArgs e)
        {

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

        private void dgvPaymentMethods_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvPaymentMethods.Columns[e.ColumnIndex].Name == "DeleteColumn")
            {
                string paymentMethodToDelete = dgvPaymentMethods.Rows[e.RowIndex].Cells[0].Value.ToString();

                // Remove the payment method using your PaymentMethodService
                PaymentMethodService.DeletePaymentMethod(paymentMethodToDelete, _context);

                // Refresh the payment methods in the DataGridView
                LoadPaymentMethods();
            }
        }
    }
    
}
