using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace TakoTea.Helpers
{
 
    public static class LoadingScreenHelper
    {
        public static ProgressBar CreateProgressBar()
        {
            ProgressBar progressBar = new ProgressBar();
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.MarqueeAnimationSpeed = 30;
            progressBar.Size = new Size(200, 20);

            return progressBar;
        }
    }
}
