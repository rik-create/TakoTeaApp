using Helpers;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakoTea.Views.MainForm;

namespace TakoTea.Views.mainform
{
    public partial class LoginForm : Form
    {


        public static LoginForm Instance;

        public static string Username = "";
        public LoginForm()
        {

            InitializeComponent();

            // Set TabIndex for controls
            txtBoxUserName.TabIndex = 0;
            txtBoxPassword.TabIndex = 1;
            btnLogin.TabIndex = 2;

            // Set AcceptButton to trigger btnLogin when Enter is pressed
            AcceptButton = btnLogin;
            Instance = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtBoxUserName.Text;
            string password = txtBoxPassword.Text;

            // Show loading bar
            ProgressBar loadingBar = new ProgressBar
            {
                Style = ProgressBarStyle.Marquee,
                MarqueeAnimationSpeed = 30,
                Size = new Size(200, 30)
            };
            int centerX = (Size.Width - loadingBar.Width) / 2;
            int centerY = (Size.Height - loadingBar.Height) / 2;
            loadingBar.Location = new Point(centerX, centerY);
            Controls.Add(loadingBar);
            loadingBar.BringToFront();
            loadingBar.Show();

            // Perform authentication asynchronously
            bool isAuthenticated = await Task.Run(() => AuthenticationHelper.AuthenticateUser(username, password));

            if (isAuthenticated)
            {
                AuthenticationHelper._loggedInUsername = username;
                TakoTeaForm mainForm = new TakoTeaForm();

                // Subscribe to the FormClosed event of the main form
                mainForm.FormClosing += TakoTea_FormClosing;

                txtBoxUserName.Clear();
                txtBoxPassword.Clear();
                loadingBar.Hide();
                Controls.Remove(loadingBar);
                Hide();

                _ = mainForm.ShowDialog();

                mainForm.Owner = this;



            }
            else
            {
                loadingBar.Hide();
                Controls.Remove(loadingBar);
                _ = MessageBox.Show("Invalid username or password.");
            }
        }


        private void TakoTea_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to exit ? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)

                {
                    _ = MessageBox.Show("You have successfully logged out.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Hide the TakoTeaForm instead of closing it
                    Show();
                    // The LoginForm (owner) will remain open
                }
                else
                {
                    e.Cancel = true; // Prevent form from closing if "No" is selected
                }
            }
        }
    }
}