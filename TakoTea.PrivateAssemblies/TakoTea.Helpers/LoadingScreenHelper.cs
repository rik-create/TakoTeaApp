using System.Drawing;
using System.Windows.Forms;


namespace TakoTea.Helpers
{

    public static class LoadingScreenHelper
    {
        public static ProgressBar CreateProgressBar()
        {
            ProgressBar progressBar = new ProgressBar
            {
                Style = ProgressBarStyle.Marquee,
                MarqueeAnimationSpeed = 30,
                Size = new Size(200, 20)
            };

            return progressBar;
        }
    }
}
