using System;
using System.Windows.Forms;

namespace TakoTea.Helpers
{
    public static class ErrorHelper
    {

        public static void HandleError(Exception ex, string userFriendlyMessage)
        {
            // Log the error (you can replace this with your logging mechanism)
            _ = MessageBox.Show($"Error: {ex.Message}\nStack Trace: {ex.StackTrace}");

            // Show a user-friendly message
            _ = MessageBox.Show(userFriendlyMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
