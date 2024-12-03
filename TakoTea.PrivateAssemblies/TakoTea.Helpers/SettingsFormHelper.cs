using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakoTea.Interfaces;
using TakoTea.Models;

namespace TakoTea.Helpers
{
    public static class SettingsFormHelper
    {
        // In your SettingsFormHelper class

        public static void PopulateUsersListView(MaterialListView listView, List<User> users)
        {
            listView.Items.Clear();
            foreach (var user in users)
            {
                var item = new ListViewItem(user.Username.ToString());
                item.SubItems.Add(user.Role);
                listView.Items.Add(item);
            }
        }

        public static void LoadUserRoles(MaterialComboBox comboBox)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add("Admin");
            comboBox.Items.Add("Staff");
            // Add other roles as needed
        }

        public static void LoadAlertThresholds(MaterialComboBox comboBox)
        {
            comboBox.Items.Clear();
            for (int i = 10; i <= 100; i += 10)
            {
                comboBox.Items.Add(i.ToString() + "%");
            }
        }

        public static void LoadAlertFrequencies(MaterialComboBox comboBox)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add("Daily");
            comboBox.Items.Add("Hourly");

            comboBox.Items.Add("Weekly");
            comboBox.Items.Add("Monthly");
        }

    
        public static void LoadBackupSchedules(MaterialComboBox comboBox)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add("Daily");
            comboBox.Items.Add("Hourly");

            comboBox.Items.Add("Weekly");
            comboBox.Items.Add("Monthly");
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
                checkedListBoxEmails.Items.Add(email);
            }
        }

        // In your SettingsService class

        public static string GetSavedEmails()
        {
            var context = new Entities();
            return context.Settings.FirstOrDefault()?.SavedEmails ?? string.Empty;
        }

        // ... other helper methods ...

        // ... other helper methods ...
    }
}
