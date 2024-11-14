using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TakoTea.HELPERS
{
    public static class FilterPanelHelper
    {
        public static void ToggleFilterPanel(Panel panel, Button hideButton, PictureBox showPictureBox, bool isVisible)
        {
            if (panel == null || hideButton == null || showPictureBox == null)
            {
                throw new ArgumentNullException("Panel, Button, and PictureBox must not be null.");
            }

            panel.Visible = isVisible;
            panel.Enabled = isVisible;
            hideButton.Enabled = isVisible;
            showPictureBox.Enabled = !isVisible;
        }
    }

}
