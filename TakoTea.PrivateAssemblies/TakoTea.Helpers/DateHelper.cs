using System;
using System.Windows.Forms;

namespace TakoTea.Helpers
{
    public static class DateHelper
    {
        public static bool IsStartDateBeforeEndDate(DateTime startDate, DateTime endDate)
        {
            return startDate < endDate;
        }
        public  static void ValidateDateRange(DateTimePicker startDatePicker, DateTimePicker endDatePicker, string errorMessage, int adjustmentDays)
        {
            if (!IsStartDateBeforeEndDate(startDatePicker.Value, endDatePicker.Value))
            {
                MessageBox.Show(errorMessage, "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                startDatePicker.Value = endDatePicker.Value.AddDays(adjustmentDays);
            }
        }
    }
}
