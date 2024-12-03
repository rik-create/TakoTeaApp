using MaterialSkin.Controls;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Helpers;
using TakoTea.Models;
using TakoTea.Repository;
using TakoTea.Services;
using Microsoft.SqlServer.Management.Smo;


namespace TakoTea.Views.settings
{
    public partial class SettingsForm : MaterialForm
    {
        private Entities _context = new Entities();

        public SettingsForm()
        {
            InitializeComponent();

            try
            {
                UserRepository.Initialize(new Entities());
                SettingsService.Initialize(new Entities());
                LoggingHelper.LogActivity("Initialization", "Services initialized successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing services: " + ex.Message);
                LoggingHelper.LogActivity("Initialization", "Error initializing services: " + ex.Message);
            }

            this.DrawerShowIconsWhenHidden = false;
            ThemeConfigurator.ApplyDarkTheme(this);

            try
            {
                // Load user roles
                SettingsFormHelper.LoadUserRoles(cmbRoleAssignment);

                // Load alert thresholds

                // Load alert frequencies
                SettingsFormHelper.LoadAlertFrequencies(cmbAlertFrequency);

                // Load backup destinations

                SettingsFormHelper.LoadSavedEmails(checkedListBoxEmails);

                // Load backup schedules
                SettingsFormHelper.LoadBackupSchedules(cmbBackupSchedule);

                SettingsFormHelper.PopulateUsersListView(materialListViewUsers, UserRepository.GetAllUsers());
                LoggingHelper.LogActivity("LoadSettings", "Settings loaded successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading settings: " + ex.Message);
                LoggingHelper.LogActivity("LoadSettings", "Error loading settings: " + ex.Message);
            }

            this.Load += SettingsForm_Load;
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
                SettingsService.LoadSettings(this);
                LoggingHelper.LogActivity("CancelChanges", "Settings reloaded successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading settings: " + ex.Message);
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
                MessageBox.Show("Error loading settings: " + ex.Message);
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
                var user = new TakoTea.Models.User
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
                MessageBox.Show("Error adding user: " + ex.Message);
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
                MessageBox.Show("Error hashing password: " + ex.Message);
                LoggingHelper.LogActivity("HashPassword", "Error hashing password: " + ex.Message);
                return null;
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the selected user from the ListView
                var selectedUser = materialListViewUsers.SelectedItems[0].Tag as TakoTea.Models.User;
                if (selectedUser == null) return;

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
                MessageBox.Show("Error editing user: " + ex.Message);
                LoggingHelper.LogActivity("EditUser", "Error editing user: " + ex.Message);
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the selected user from the ListView
                var selectedUser = materialListViewUsers.SelectedItems[0].Tag as TakoTea.Models.User;
                if (selectedUser == null) return;

                // Delete the user
                UserRepository.DeleteUser(selectedUser.UserID);

                // Refresh the users list
                SettingsService.LoadSettings(this);
                LoggingHelper.LogActivity("DeleteUser", "User deleted successfully.");
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
                 var context = new Entities();
                var settings = context.Settings.FirstOrDefault();
                if (settings != null)
                {
                    settings.LastBackUpDate = DateTime.Now;
                    context.SaveChanges();
                }

                MessageBox.Show("Backup performed and date saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error performing backup: " + ex.Message);
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
                MessageBox.Show("Error restoring backup: " + ex.Message);
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
                    MessageBox.Show("Invalid email format.");
                    LoggingHelper.LogActivity("AddEmail", "Invalid email format.");
                    return;
                }

                var context = new Entities();
                var settings = context.Settings.FirstOrDefault();

                if (settings == null)
                {
                    // Handle case where settings are not found (e.g., create new settings)
                    return;
                }

                // Check if the email already exists in SavedEmails
                var savedEmails = settings.SavedEmails?.Split(new[] { '?' }, StringSplitOptions.RemoveEmptyEntries) ?? new string[0];
                if (savedEmails.Contains(newEmail))
                {
                    MessageBox.Show("Email already exists.");
                    LoggingHelper.LogActivity("AddEmail", "Email already exists.");
                    return;
                }

                // Add the new email to SavedEmails
                settings.SavedEmails = settings.SavedEmails + "?" + newEmail;
                context.SaveChanges();

                // Add the new email to the CheckedListBox

                MessageBox.Show("Email added successfully.");
                txtBoxAddEmail.Text = ""; // Clear the input field

                SettingsFormHelper.LoadSavedEmails(checkedListBoxEmails);
                LoggingHelper.LogActivity("AddEmail", "Email added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding email: " + ex.Message);
                LoggingHelper.LogActivity("AddEmail", "Error adding email: " + ex.Message);
            }
        }

        private bool IsValidEmail(string email)
        {
            // You can use a more robust email validation method if needed
            return !string.IsNullOrEmpty(email) && email.Contains("@");
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SettingsService.LoadSettings(this);
                LoggingHelper.LogActivity("ReloadSettings", "Settings reloaded successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading settings: " + ex.Message);
                LoggingHelper.LogActivity("ReloadSettings", "Error loading settings: " + ex.Message);
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    SettingsService.SaveSettings(this);
                    transaction.Commit();
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

        private void checkBoxSelectAllEmails_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                bool isChecked = checkBoxSelectAllEmails.Checked;

                for (int i = 0; i < checkedListBoxEmails.Items.Count; i++)
                {
                    checkedListBoxEmails.SetItemChecked(i, isChecked);
                }
                LoggingHelper.LogActivity("SelectAllEmails", "All emails selected/deselected.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting all emails: " + ex.Message);
                LoggingHelper.LogActivity("SelectAllEmails", "Error selecting all emails: " + ex.Message);
            }
        }

        private void materialFloatingActionButtonAddBackUpDestination_Click(object sender, EventArgs e)
        {
            // Show a dialog to select a folder
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = folderBrowserDialog.SelectedPath;

                // Add the selected path to the CheckedListBox
                checkedListBoxBackUpDestinations.Items.Add(selectedPath);
                LoggingHelper.LogActivity("AddBackupDestination", "Backup destination added: " + selectedPath);
            }
        }

        private void materialFloatingActionButtonDeleteBackupDestination_Click(object sender, EventArgs e)
        {
            if (checkedListBoxBackUpDestinations.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one backup destination to delete.");
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

        private void btnPerformBackup_Click_1(object sender, EventArgs e)
        {

        }
    }
}
