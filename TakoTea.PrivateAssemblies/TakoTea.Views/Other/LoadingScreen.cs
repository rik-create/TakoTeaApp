using System.Drawing;
using System.Windows.Forms;



namespace TakoTea.Views.Other
{
    public partial class LoadingScreen : Form
    {
        public LoadingScreen()
        {
            InitializeComponent();

            // Make the loading screen appear in the center of the parent form
            StartPosition = FormStartPosition.CenterParent;

            // Optionally, set a custom background color or image
            BackColor = Color.LightGray;

            // Add a label to display a loading message
            Label loadingLabel = new Label
            {
                Text = "Loading...",
                AutoSize = true
            };
            loadingLabel.Font = new Font(loadingLabel.Font.FontFamily, 12, FontStyle.Bold);
            loadingLabel.Location = new Point(
                (ClientSize.Width - loadingLabel.Width) / 2,
                ((ClientSize.Height - loadingLabel.Height) / 2) - 50 // Adjusted position for the label
            );
            Controls.Add(loadingLabel);

            // Add a progress bar
            ProgressBar progressBar = new ProgressBar
            {
                Style = ProgressBarStyle.Marquee,
                MarqueeAnimationSpeed = 30,
                Size = new Size(200, 20)
            };
            progressBar.Location = new Point(
                (ClientSize.Width - progressBar.Width) / 2,
                ((ClientSize.Height - progressBar.Height) / 2) + 20 // Adjusted position for the progress bar
            );
            Controls.Add(progressBar);
        }
    }
}
