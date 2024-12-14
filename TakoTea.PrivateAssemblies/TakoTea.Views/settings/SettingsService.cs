using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TakoTea.Database;
using TakoTea.Interfaces;
using TakoTea.Models;

namespace TakoTea.Views.settings
{

    public static class SettingsService
    {
        private static Entities _context;
        private static readonly ISettingsFormHelper _helper;

        public static void Initialize(Entities context)
        {
            _context = context;
        }

        public static void LoadSettings(SettingsForm settingsForm)
        {
            try
            {
                Setting settings = _context.Settings.FirstOrDefault();

                if (settings != null)
                {
                    settingsForm.cmbAlertFrequency.SelectedItem = settings.LowStockFrequency;
                    settingsForm.chkBoxEnableEmailNotifications.Checked = settings.EnableEmailNotifications.Value;
                    settingsForm.chkBoxInAppNotification.Checked = settings.EnableInAppNotifications.Value;
                    settingsForm.lblLastBackupDate.Text = settings.LastBackUpDate?.ToString("MMMM dd, yyyy (hh:mm tt)") ?? "N/A";
            
                    settingsForm.cmbBackupSchedule.SelectedItem = settings.BackupSchedule;
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show($"Error loading settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void SaveSettings(SettingsForm settingsForm)
        {
            try
            {
                Setting settings = _context.Settings.FirstOrDefault() ?? new TakoTea.Models.Setting();

                settings.LowStockFrequency = settingsForm.cmbAlertFrequency.SelectedItem?.ToString();
                settings.EnableEmailNotifications = settingsForm.chkBoxEnableEmailNotifications.Checked;
                settings.EnableInAppNotifications = settingsForm.chkBoxInAppNotification.Checked;
                settings.BackupSchedule = settingsForm.cmbBackupSchedule.SelectedItem?.ToString();
                // ... retrieve other settings from UI ...

                ValidateSettings();

                if (_context.Entry(settings).State == EntityState.Detached)
                {
                    _ = _context.Settings.Add(settings);
                }

                _ = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show($"Error saving settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ResetSettingsToDefault(SettingsForm settingsForm)
        {
            try
            {
                settingsForm.cmbAlertFrequency.SelectedIndex = 0;
                settingsForm.chkBoxEnableEmailNotifications.Checked = false;
                settingsForm.cmbBackupSchedule.SelectedIndex = 0;
                // ... reset other settings ...

                SaveSettings(settingsForm); // Save the default settings
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show($"Error resetting settings to default: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ValidateSettings()
        {
            // Validate the settings entered by the user
            // ... and display error messages if any
        }

        public static void PerformBackup(SettingsForm settingsForm)
        {
            try
            {
                // Get all backup paths from the DataGridView
                List<string> backupDestinations = new List<string>();
                foreach (DataGridViewRow row in settingsForm.dataGridViewBackupPaths.Rows)
                {
                    backupDestinations.Add(row.Cells[0].Value.ToString());
                }

                string backupSchedule = settingsForm.cmbBackupSchedule.SelectedItem?.ToString();

                // Validate backup settings
                if (backupDestinations.Count == 0 || string.IsNullOrEmpty(backupSchedule))
                {
                    MessageBox.Show("Please select at least one backup destination and a backup schedule.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (string backupDestination in backupDestinations)
                {
                    string backupFilePath = GenerateBackupFilePath(backupDestination, backupSchedule);
                    BackupDatabase(backupFilePath, "TakoTea");
                }

                UpdateLastBackupDate(settingsForm);
                MessageBox.Show("Backup performed and date saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error performing backup: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void UpdateLastBackupDate(SettingsForm settingsForm) // Update the method to accept the SettingsForm
        {
            settingsForm.lblLastBackupDate.Text = DateTime.Now.ToString(); // Access the Label from the SettingsForm
        }

        public static void RestoreBackup()
        {
            try
            {
                // 1. Get backup file path
                string backupFilePath = SelectBackupFile();

                // 2. Validate backup file path (optional)
                if (!ValidateBackupFilePath(backupFilePath))
                {
                    _ = MessageBox.Show("Invalid backup file path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Or handle the error appropriately
                }

                // 3. Perform the restore (using your preferred method)
                RestoreDatabase(backupFilePath, "TakoTea");

                // 4. (Optional) Display a success message or update the UI
                _ = MessageBox.Show("Database restored successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show($"Error restoring backup: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string GenerateBackupFilePath(string backupDestination, string backupSchedule)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string fileName = $"TakoTea_Backup_{timestamp}.bak";

            // No need for a switch case since you're getting the full path from the CheckedListBox
            return Path.Combine(backupDestination, fileName);
        }

        private static string SelectBackupFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Backup Files|*.bak"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }
            else
            {
                return null; // Or handle the cancellation appropriately
            }
        }

        private static void BackupDatabase(string backupFilePath, string databaseName)
        {
            try
            {
                // Extract the directory from the backupFilePath
                string backupDirectory = Path.GetDirectoryName(backupFilePath);

                if (!Directory.Exists(backupDirectory))
                {
                    MessageBox.Show("The specified backup directory does not exist. \n Directory Path: " + backupDirectory, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(DatabaseConnection.GetConnectionString()))
                {
                    connection.Open();
                    string backupScript = $"BACKUP DATABASE [{databaseName}] TO DISK = '{backupFilePath}'";
                    SqlCommand command = new SqlCommand(backupScript, connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error backing up database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private static void RestoreDatabase(string backupFilePath, string databaseName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConnection.GetConnectionString()))
                {
                    connection.Open();
                    string restoreScript = $@"
                        ALTER DATABASE [{databaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                        RESTORE DATABASE [{databaseName}] FROM DISK = '{backupFilePath}' WITH REPLACE;
                        ALTER DATABASE [{databaseName}] SET MULTI_USER;";
                    SqlCommand command = new SqlCommand(restoreScript, connection);
                    _ = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show($"Error restoring database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool ValidateBackupSettings(string backupDestination, string backupSchedule)
        {
            // Add your validation logic here
            // For example, check if the backup destination and schedule are not null or empty
            return !string.IsNullOrEmpty(backupDestination) && !string.IsNullOrEmpty(backupSchedule);
        }

        private static bool ValidateBackupFilePath(string backupFilePath)
        {
            // Add your validation logic here
            // For example, check if the backup file path is not null or empty and if the file exists
            return !string.IsNullOrEmpty(backupFilePath) && File.Exists(backupFilePath);
        }
    }
}
