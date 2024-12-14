using MaterialSkin.Controls;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TakoTea.Models;
using TakoTea.Repository;

namespace TakoTea.Helpers
{
    public static class SettingsFormHelper
    {
        private static Entities _context;
        public static List<User> originalUsers; // Add this line

        private static List<string> originalPaymentMethods;
        public static void Initialize(Entities context)
        {

            _context = context;
            OriginalData();
            originalUsers = UserRepository.GetAllUsers();

        }
        public static void DeleteBackupPath(DataGridViewSelectedRowCollection selectedRows)
        {
            try
            {
                if (selectedRows.Count > 0)
                {
                    // Ask for confirmation
                    DialogResult result = MessageBox.Show($"Are you sure you want to delete {selectedRows.Count} backup path(s)?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in selectedRows)
                        {
                            string pathToDelete = row.Cells[0].Value.ToString();

                            // Remove the row from the DataGridView
                            row.DataGridView.Rows.Remove(row);

                            // Update the BackupDestination in your settings
                            using (var context = new Entities())
                            {
                                Setting settings = context.Settings.FirstOrDefault();
                                if (settings != null)
                                {
                                    string[] backupPaths = settings.BackupDestination.Split('|');
                                    settings.BackupDestination = string.Join("|", backupPaths.Where(p => p != pathToDelete));
                                    context.SaveChanges();
                                }
                            }
                        }

                        // Show a message box indicating successful deletion
                        MessageBox.Show($"{selectedRows.Count} backup path(s) deleted successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting backup path(s): {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void LoadBackUpPaths(DataGridView dataGridView, BindingNavigator bindingNavigator, BindingSource bindingSource, Image icon)
        {
            try
            {
                using (var context = new Entities())
                {
                    var settings = context.Settings.FirstOrDefault();
                    if (settings != null && !string.IsNullOrEmpty(settings.BackupDestination))
                    {
                        // Split the backup destinations
                        string[] selectedDestinations = settings.BackupDestination.Split('|');

                        // Create a DataTable to hold the backup paths
                        DataTable dtBackUpPaths = new DataTable();
                        dtBackUpPaths.Columns.Add("BackupPath", typeof(string));

                        // Add the paths to the DataTable
                        foreach (var destination in selectedDestinations)
                        {
                            dtBackUpPaths.Rows.Add(destination);
                        }

                        // Set the DataSource for the BindingSource
                        bindingSource.DataSource = dtBackUpPaths;

                        // Set the DataSource for the DataGridView and BindingNavigator
                        dataGridView.DataSource = bindingSource;
                        bindingNavigator.BindingSource = bindingSource;
                    }

/*                    DataGridViewHelper.AddIconButtonColumn(dataGridView, "DeletePathColumn", "Delete", icon);
*/
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading backup paths: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void LoadSavedEmails(DataGridView dataGridViewEmails, BindingNavigator bindingNavigatorEmails, BindingSource bindingSourceEmails)
        {
            try
            {
                string savedEmailsString = GetSavedEmails();
                string[] savedEmails = savedEmailsString.Split(new[] { '?' }, StringSplitOptions.RemoveEmptyEntries);

                // Create a DataTable to hold the emails
                DataTable dtEmails = new DataTable();
                dtEmails.Columns.Add("Email", typeof(string));

                // Add the emails to the DataTable
                foreach (string email in savedEmails)
                {
                    dtEmails.Rows.Add(email);
                }

                // Create a BindingSource and set its DataSource
                bindingSourceEmails.DataSource = dtEmails;

                // Set the BindingSource for both the DataGridView and BindingNavigator
                dataGridViewEmails.DataSource = bindingSourceEmails;
                bindingNavigatorEmails.BindingSource = bindingSourceEmails;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading saved emails: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void LoadPaymentMethods(DataGridView dgvPaymentMethods, BindingNavigator bindingNavigatorPaymentMethods, BindingSource bindingSourcePaymentMethods)
        {
            try
            {
                // Retrieve the payment methods from the database
                List<string> paymentMethods = _context.PaymentMethods
                    .Where(p => p.IsActive)
                    .Select(p => p.MethodName)
                    .ToList();

                // Create a DataTable to hold the payment methods
                DataTable dtPaymentMethods = new DataTable();
                dtPaymentMethods.Columns.Add("PaymentMethod", typeof(string));

                // Add the payment methods to the DataTable
                foreach (string method in paymentMethods)
                {
                    dtPaymentMethods.Rows.Add(method);
                }

                // Create a BindingSource and set its DataSource
                bindingSourcePaymentMethods.DataSource = dtPaymentMethods;

                // Set the BindingSource for both the DataGridView and BindingNavigator
                dgvPaymentMethods.DataSource = bindingSourcePaymentMethods;
                bindingNavigatorPaymentMethods.BindingSource = bindingSourcePaymentMethods;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading payment methods: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void PopulateUsersListView(MaterialListView listView, List<User> users)
        {
            try
            {
                listView.Items.Clear();
                foreach (User user in users)
                {
                    ListViewItem item = new ListViewItem(user.Username.ToString());
                    _ = item.SubItems.Add(user.Role);
                    _ = listView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error populating users list view: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void LoadUserRoles(MaterialComboBox comboBox)
        {
            try
            {
                comboBox.Items.Clear();
                _ = comboBox.Items.Add("Admin");
                _ = comboBox.Items.Add("Staff");
                // Add other roles as needed
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user roles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void LoadAlertThresholds(MaterialComboBox comboBox)
        {
            try
            {
                comboBox.Items.Clear();
                for (int i = 10; i <= 100; i += 10)
                {
                    _ = comboBox.Items.Add(i.ToString() + "%");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading alert thresholds: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void LoadAlertFrequencies(MaterialComboBox comboBox)
        {
            try
            {
                comboBox.Items.Clear();
                _ = comboBox.Items.Add("Daily");
                _ = comboBox.Items.Add("Hourly");
                _ = comboBox.Items.Add("Weekly");
                _ = comboBox.Items.Add("Monthly");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading alert frequencies: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void LoadBackupSchedules(MaterialComboBox comboBox)
        {
            try
            {
                comboBox.Items.Clear();
                _ = comboBox.Items.Add("Daily");
                _ = comboBox.Items.Add("Hourly");
                _ = comboBox.Items.Add("Weekly");
                _ = comboBox.Items.Add("Monthly");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading backup schedules: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public static string GetSavedEmails()
        {
            try
            {
                return _context.Settings.FirstOrDefault()?.SavedEmails ?? string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting saved emails: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        private static void OriginalData()
        {
            originalPaymentMethods = _context.PaymentMethods
              .Where(p => p.IsActive)
              .Select(p => p.MethodName)
              .ToList();

            originalUsers = UserRepository.GetAllUsers();




        }
        public static void LogPaymentMethodChanges(DataGridView dgvPaymentMethods)
        {
            // Get the current list of payment methods from the DataGridView
            List<string> currentPaymentMethods = new List<string>();
            foreach (DataGridViewRow row in dgvPaymentMethods.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    currentPaymentMethods.Add(row.Cells[0].Value.ToString());
                }
            }

            // Compare the lists and log the changes
            foreach (string method in originalPaymentMethods.Except(currentPaymentMethods))
            {
                LoggingHelper.LogChange(
                    "PaymentMethods",
                    0, // You might need to adjust the RecordID if you have a primary key for payment methods
                    "MethodName",
                    method,
                    null, // New value is null since it was deleted
                    "Deleted",
                    "Payment method deleted",
                    $"Payment method '{method}' deleted"
                );
            }

            foreach (string method in currentPaymentMethods.Except(originalPaymentMethods))
            {
                LoggingHelper.LogChange(
                    "PaymentMethods",
                    0, // You might need to adjust the RecordID
                    "MethodName",
                    null, // Old value is null since it was added
                    method,
                    "Added",
                    "Payment method added",
                    $"Payment method '{method}' added"
                );
            }

            // Update the originalPaymentMethods with the current data
            originalPaymentMethods = currentPaymentMethods;
        }
  

        // Implement a UserComparer class to compare users based on their ID
        public class UserComparer : IEqualityComparer<User>
        {
            public bool Equals(User x, User y)
            {
                return x.UserID == y.UserID;
            }

            public int GetHashCode(User obj)
            {
                return obj.UserID.GetHashCode();
            }
        }
        public static List<User> GetUsersFromListView(MaterialListView listView)
        {
            List<User> users = new List<User>();
            foreach (ListViewItem item in listView.Items)
            {
                // Assuming the first column of the ListView displays the Username
                string username = item.SubItems[0].Text;

                // Get the user from the database based on the Username
                User user = _context.Users.FirstOrDefault(u => u.Username == username);

                if (user != null)
                {
                    users.Add(user);
                }
            }
            return users;
        }


        public static void LogUserChanges(User originalUser, User updatedUser)
        {
            if (originalUser.Name != updatedUser.Name)
            {
                LoggingHelper.LogChange(
                    "Users",
                    updatedUser.UserID,
                    "Name",
                    originalUser.Name,
                    updatedUser.Name,
                    "Updated",
                    "User name updated",
                    $"User '{updatedUser.Username}' name changed from '{originalUser.Name}' to '{updatedUser.Name}'"
                );
            }

            if (originalUser.Username != updatedUser.Username)
            {
                LoggingHelper.LogChange(
                    "Users",
                    updatedUser.UserID,
                    "Username",
                    originalUser.Username,
                    updatedUser.Username,
                    "Updated",
                    "User username updated",
                    $"User ID '{updatedUser.UserID}' username changed from '{originalUser.Username}' to '{updatedUser.Username}'"
                );
            }

            if (originalUser.Role != updatedUser.Role)
            {
                LoggingHelper.LogChange(
                    "Users",
                    updatedUser.UserID,
                    "Role",
                    originalUser.Role,
                    updatedUser.Role,
                    "Updated",
                    "User role updated",
                    $"User '{updatedUser.Username}' role changed from '{originalUser.Role}' to '{updatedUser.Role}'"
                );
            }



            // ... (repeat for other properties) ...
        }
        public static void LogUserChanges(MaterialListView materialListViewUsers)
        {
            List<User> currentUsers = GetUsersFromListView(materialListViewUsers);



            // 3. Find and log modified users
            var modifiedUsers = originalUsers.Join(currentUsers,
                                                  original => original.UserID,
                                                  current => current.UserID,
                                                  (original, current) => new { Original = original, Current = current })
                                             .Where(pair => !pair.Original.Equals(pair.Current));

            foreach (var modifiedUser in modifiedUsers)
            {
                // Log changes for each property
                if (modifiedUser.Original.Name != modifiedUser.Current.Name)
                {
                    LoggingHelper.LogChange(
                        "Users",
                        modifiedUser.Current.UserID,
                        "Name",
                        modifiedUser.Original.Name,
                        modifiedUser.Current.Name,
                        "Updated",
                        "User name updated",
                        $"User '{modifiedUser.Current.Username}' name changed from '{modifiedUser.Original.Name}' to '{modifiedUser.Current.Name}'"
                    );
                }

                if (modifiedUser.Original.Username != modifiedUser.Current.Username)
                {
                    LoggingHelper.LogChange(
                        "Users",
                        modifiedUser.Current.UserID,
                        "Username",
                        modifiedUser.Original.Username,
                        modifiedUser.Current.Username,
                        "Updated",
                        "User username updated",
                        $"User ID '{modifiedUser.Current.UserID}' username changed from '{modifiedUser.Original.Username}' to '{modifiedUser.Current.Username}'"
                    );
                }

                if (modifiedUser.Original.Role != modifiedUser.Current.Role)
                {
                    LoggingHelper.LogChange(
                        "Users",
                        modifiedUser.Current.UserID,
                        "Role",
                        modifiedUser.Original.Role,
                        modifiedUser.Current.Role,
                        "Updated",
                        "User role updated",
                        $"User '{modifiedUser.Current.Username}' role changed from '{modifiedUser.Original.Role}' to '{modifiedUser.Current.Role}'"
                    );
                }

                if (modifiedUser.Original.Password != modifiedUser.Current.Password)
                {
                    LoggingHelper.LogChange(
                        "Users",
                        modifiedUser.Current.UserID,
                        "Password",
                        "*****", // Mask the original password
                        "*****", // Mask the new password
                        "Updated",
                        "User password updated",
                        $"User '{modifiedUser.Current.Username}' password changed"
                    );
                }

                // ... (repeat for other properties) ...
            }

            // 1. Find and log deleted users
            var deletedUsers = originalUsers.Except(currentUsers, new UserComparer());
            foreach (User deletedUser in deletedUsers)
            {
                LoggingHelper.LogChange(
                    "Users",
                    deletedUser.UserID,
                    "User",
                    deletedUser.Username,
                    null,
                    "Deleted",
                    "User deleted",
                    $"User '{deletedUser.Username}' deleted"
                );
            }

            // 2. Find and log added users
            var addedUsers = currentUsers.Except(originalUsers, new UserComparer());
            foreach (User addedUser in addedUsers)
            {
                LoggingHelper.LogChange(
                    "Users",
                    addedUser.UserID,
                    "User",
                    null,
                    addedUser.Username,
                    "Added",
                    "User added",
                    $"User '{addedUser.Username}' added"
                );
            }

            // Update originalUsers with the current data
            originalUsers = currentUsers;
        }




    }
}
