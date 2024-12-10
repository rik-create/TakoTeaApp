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
        // In your SettingsFormHelper class
        // In your SettingsFormHelper class

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
        public static void LoadPaymentMethods(CheckedListBox checkedListBoxPaymentMethods)
        {
            Entities context = new Entities(); // Assuming you have an Entity Framework context

            // Retrieve the payment methods from the database
            List<string> paymentMethods = context.PaymentMethods
                .Where(p => p.IsActive) // Filter for active payment methods
                .Select(p => p.MethodName)
                .ToList();

            // Clear existing items in the CheckedListBox
            checkedListBoxPaymentMethods.Items.Clear();

            // Add the payment methods to the CheckedListBox
            checkedListBoxPaymentMethods.Items.AddRange(paymentMethods.ToArray());
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

        public static void LoadSavedEmails(CheckedListBox checkedListBoxEmails)
        {
            // Get the saved emails from the Settings table
            string savedEmailsString = GetSavedEmails();

            // Split the emails string using the "?" delimiter
            string[] savedEmails = savedEmailsString.Split(new[] { '?' }, StringSplitOptions.RemoveEmptyEntries);

            // Clear existing items in the CheckedListBox
            checkedListBoxEmails.Items.Clear();

            // Add the saved emails to the CheckedListBox
            foreach (string email in savedEmails)
            {
                _ = checkedListBoxEmails.Items.Add(email);
            }
        }

        // In your SettingsService class

        public static string GetSavedEmails()
        {
            Entities context = new Entities();
            return context.Settings.FirstOrDefault()?.SavedEmails ?? string.Empty;
        }

        // ... other helper methods ...

        // ... other helper methods ...
    }
}
