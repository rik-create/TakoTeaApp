using System.Windows.Forms;
namespace TakoTea.Helpers
{
    public static class DialogHelper
    {
        /// <summary>
        /// Displays a confirmation dialog with a custom message and title.
        /// </summary>
        /// <param name="message">The confirmation message to display.</param>
        /// <param name="title">The title of the confirmation dialog.</param>
        /// <returns>True if the user confirms, false otherwise.</returns>
        public static bool ShowConfirmation(string message, string title = "Confirmation")
        {
            DialogResult result = MessageBox.Show(
                message,
                title,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            return result == DialogResult.Yes;
        }
        /// <summary>
        /// Displays an error message dialog with a custom message and title.
        /// </summary>
        /// <param name="message">The error message to display.</param>
        /// <param name="title">The title of the error dialog.</param>
        public static void ShowError(string message, string title = "Error")
        {
            _ = MessageBox.Show(
                message,
                title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
        /// <summary>
        /// Displays a success message dialog with a custom message and title.
        /// </summary>
        /// <param name="message">The success message to display.</param>
        /// <param name="title">The title of the success dialog.</param>
        public static void ShowSuccess(string message, string title = "Success")
        {
            _ = MessageBox.Show(
                message,
                title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
