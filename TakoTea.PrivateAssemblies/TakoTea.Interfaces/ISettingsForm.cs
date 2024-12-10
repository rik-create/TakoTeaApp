using MaterialSkin.Controls;
using System.Collections.Generic;
using TakoTea.Models;

namespace TakoTea.Interfaces
{
    public interface ISettingsForm
    {
        void LoadSettings();
        void SaveSettings();
        void ResetSettingsToDefault();
        void ValidateSettings();
        /*        void ApplyTheme(Theme theme);
        */
        void PerformBackup();
        void RestoreBackup();
    }

    // Interface for helper methods (assuming you have a helper class)
    public interface ISettingsFormHelper
    {
        void PopulateUsersListView(MaterialListView listView, List<User> users);
        void LoadUserRoles(MaterialComboBox comboBox);
        void LoadAlertThresholds(MaterialComboBox comboBox);
        void LoadAlertFrequencies(MaterialComboBox comboBox);
        void LoadBackupDestinations(MaterialComboBox comboBox);
        void LoadBackupSchedules(MaterialComboBox comboBox);
        // ... other helper methods as needed ...
    }

    public interface IPaymentMethodForm
    {
        void LoadPaymentMethods();
        void AddPaymentMethod(PaymentMethod paymentMethod);
        void EditPaymentMethod(PaymentMethod paymentMethod);
        void DeletePaymentMethod(int paymentMethodId);
        void ValidatePaymentMethod(PaymentMethod paymentMethod);
    }
}
