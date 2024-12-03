using Helpers;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Views.MainForm;

namespace TakoTea.Views.mainform
{
    public partial class LoginForm : Form
    {


        public static LoginForm Instance;
        public LoginForm()
        {

            InitializeComponent();

            // Set TabIndex for controls
            txtBoxUserName.TabIndex = 0;
            txtBoxPassword.TabIndex = 1;
            btnLogin.TabIndex = 2;

            // Set AcceptButton to trigger btnLogin when Enter is pressed
            this.AcceptButton = btnLogin;
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
            ProgressBar loadingBar = new ProgressBar();
            loadingBar.Style = ProgressBarStyle.Marquee;
            loadingBar.MarqueeAnimationSpeed = 30;
            loadingBar.Size = new Size(200, 30);
            int centerX = (this.Size.Width - loadingBar.Width) / 2;
            int centerY = (this.Size.Height - loadingBar.Height) / 2;
            loadingBar.Location = new Point(centerX, centerY);
            this.Controls.Add(loadingBar);
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
                this.Controls.Remove(loadingBar);
                this.Hide();

                mainForm.ShowDialog();

                mainForm.Owner = this;


            }
            else
            {
                loadingBar.Hide();
                this.Controls.Remove(loadingBar);
                MessageBox.Show("Invalid username or password.");
            }
        }
     

        private void TakoTea_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to exit ? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)

                {
                    MessageBox.Show("You have successfully logged out.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Hide the TakoTeaForm instead of closing it
                    this.Show();
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