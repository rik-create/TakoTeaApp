using System;
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

        public static string ShowInputDialog(string formTitle, string labelText, string validationMessage, Func<string, bool> validateInput)
        {
            using (var form = new Form())
            {
                form.Text = formTitle;
                form.StartPosition = FormStartPosition.CenterParent;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.MaximizeBox = false;
                form.MinimizeBox = false;
                form.ShowIcon = false;
                form.Width = 300;
                form.Height = 150;

                var label = new Label
                {
                    Text = labelText,
                    Left = 12,
                    Top = 12,
                    AutoSize = true
                };

                var textBox = new TextBox
                {
                    Left = 12,
                    Top = 35,
                    Width = 260,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
                };

                var buttonOk = new Button
                {
                    Text = "OK",
                    Left = 114,
                    Top = 70,
                    Width = 75,
                    DialogResult = DialogResult.OK,
                    Anchor = AnchorStyles.Bottom | AnchorStyles.Right
                };

                buttonOk.Click += (s, a) =>
                {
                    string input = textBox.Text.Trim();
                    if (!validateInput(input))
                    {
                        MessageBox.Show(validationMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox.Focus();
                        form.DialogResult = DialogResult.None; // Prevent dialog from closing
                    }
                };

                form.Controls.Add(label);
                form.Controls.Add(textBox);
                form.Controls.Add(buttonOk);
                form.AcceptButton = buttonOk;
                form.TopMost = true;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    return textBox.Text.Trim();
                }
                else
                {
                    MessageBox.Show("Dialog closed. Changes not saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }
            }
        }
    }
}
