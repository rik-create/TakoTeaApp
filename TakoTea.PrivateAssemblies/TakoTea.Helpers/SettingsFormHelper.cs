using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TakoTea.Models;

namespace TakoTea.Helpers
{
    public static class SettingsFormHelper
    {
        private static Entities _context;

        public static void Initialize(Entities context)
        {
            _context = context;
        }




        public static void LoadBackUpPaths(CheckedListBox chk)
        {
            using (var context = new Entities()) // Use using statement for proper disposal
            {
                chk.Items.Clear();

                var settings = context.Settings.FirstOrDefault();
                if (settings != null && !string.IsNullOrEmpty(settings.BackupDestination))
                {
                    // Split the comma-separated string to get the selected destinations
                    string[] selectedDestinations = settings.BackupDestination.Split('|');

                    // Add the selected destinations to the CheckedListBox
                    foreach (var destination in selectedDestinations)
                    {
                        chk.Items.Add(destination);
                    }
                }
            }
        }
        public static void LoadPaymentMethods(DataGridView dgvPaymentMethods)
        {

            // Retrieve the payment methods from the database
            List<string> paymentMethods = _context.PaymentMethods
                .Where(p => p.IsActive)
                .Select(p => p.MethodName)
                .ToList();

            // Clear existing rows in the DataGridView
            dgvPaymentMethods.Rows.Clear();

            // Add the payment methods to the DataGridView
            foreach (string method in paymentMethods)
            {
                dgvPaymentMethods.Rows.Add(method);
            }
        }
        public static void PopulateUsersListView(MaterialListView listView, List<User> users)
        {
            listView.Items.Clear();
            foreach (User user in users)
            {
                ListViewItem item = new ListViewItem(user.Username.ToString());
                _ = item.SubItems.Add(user.Role);
                _ = listView.Items.Add(item);
            }
        }

        public static void LoadUserRoles(MaterialComboBox comboBox)
        {
            comboBox.Items.Clear();
            _ = comboBox.Items.Add("Admin");
            _ = comboBox.Items.Add("Staff");
            // Add other roles as needed
        }

        public static void LoadAlertThresholds(MaterialComboBox comboBox)
        {
            comboBox.Items.Clear();
            for (int i = 10; i <= 100; i += 10)
            {
                _ = comboBox.Items.Add(i.ToString() + "%");
            }
        }

        public static void LoadAlertFrequencies(MaterialComboBox comboBox)
        {
            comboBox.Items.Clear();
            _ = comboBox.Items.Add("Daily");
            _ = comboBox.Items.Add("Hourly");

            _ = comboBox.Items.Add("Weekly");
            _ = comboBox.Items.Add("Monthly");
        }


        public static void LoadBackupSchedules(MaterialComboBox comboBox)
        {
            comboBox.Items.Clear();
            _ = comboBox.Items.Add("Daily");
            _ = comboBox.Items.Add("Hourly");

            _ = comboBox.Items.Add("Weekly");
            _ = comboBox.Items.Add("Monthly");
        }

        public static void LoadSavedEmails(DataGridView dataGridViewEmails)
        {
            string savedEmailsString = GetSavedEmails();
            string[] savedEmails = savedEmailsString.Split(new[] { '?' }, StringSplitOptions.RemoveEmptyEntries);

            // Clear existing rows in the DataGridView
            dataGridViewEmails.Rows.Clear();

            // Add the saved emails to the DataGridView
            foreach (string email in savedEmails)
            {
                dataGridViewEmails.Rows.Add(email, "X"); // Add a "Delete" button or icon in the second column
            }
        }

        // In your SettingsService class

        public static string GetSavedEmails()
        {
            return _context.Settings.FirstOrDefault()?.SavedEmails ?? string.Empty;
        }

        // ... other helper methods ...

        // ... other helper methods ...
    }
}
