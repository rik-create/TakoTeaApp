using System;
using System.Windows.Forms;
using TakoTea.Repository;
namespace TakoTea.Helpers
{
    public static class FilterPanelHelper
    {
        public static void ToggleFilterPanel(Panel panel, Button hideButton, PictureBox showPictureBox, bool isVisible)
        {
            if (panel == null || hideButton == null || showPictureBox == null)
            {
                throw new ArgumentNullException("Panel, Button, and PictureBox must not be null.");
            }
            panel.Visible = isVisible;
            panel.Enabled = isVisible;
            hideButton.Enabled = isVisible;
            showPictureBox.Enabled = !isVisible;
        }

        public static void ResetFilters(DateTimePicker startDatePicker, DateTimePicker endDatePicker, string tableName, string dateColumnName)
        {
            if (startDatePicker == null || endDatePicker == null || string.IsNullOrEmpty(tableName) || string.IsNullOrEmpty(dateColumnName))
            {
                throw new ArgumentNullException("DateTimePickers, tableName, and dateColumnName must not be null or empty.");
            }

            DateTime? firstRecordDate = LogChangesRepository.GetFirstRecordDate(tableName, dateColumnName);
            DateTime lastRecordDate = LogChangesRepository.GetLastRecordDate(tableName, dateColumnName);

            startDatePicker.Value = firstRecordDate ?? DateTime.Now;
            endDatePicker.Value = lastRecordDate;
        }
    }
}