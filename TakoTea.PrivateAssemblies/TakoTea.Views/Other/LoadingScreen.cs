using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace TakoTea.Views.Other
{
    public partial class LoadingScreen : Form
    {
        public LoadingScreen()
        {
            InitializeComponent();

            // Make the loading screen appear in the center of the parent form
            this.StartPosition = FormStartPosition.CenterParent;

            // Optionally, set a custom background color or image
            this.BackColor = Color.LightGray;

            // Add a label to display a loading message
            Label loadingLabel = new Label();
            loadingLabel.Text = "Loading...";
            loadingLabel.AutoSize = true;
            loadingLabel.Font = new Font(loadingLabel.Font.FontFamily, 12, FontStyle.Bold);
            loadingLabel.Location = new Point(
                (this.ClientSize.Width - loadingLabel.Width) / 2,
                (this.ClientSize.Height - loadingLabel.Height) / 2 - 50 // Adjusted position for the label
            );
            this.Controls.Add(loadingLabel);

            // Add a progress bar
            ProgressBar progressBar = new ProgressBar();
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.MarqueeAnimationSpeed = 30;
            progressBar.Size = new Size(200, 20);
            progressBar.Location = new Point(
                (this.ClientSize.Width - progressBar.Width) / 2,
                (this.ClientSize.Height - progressBar.Height) / 2 + 20 // Adjusted position for the progress bar
            );
            this.Controls.Add(progressBar);
        }
    }
}
