using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TakoTea.Configurations
{
    public static class FormSettingsConfigurator
    {
        public static void ApplyStandardFormSettings(MaterialForm form)
        {
            form.StartPosition = FormStartPosition.CenterParent;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Sizable = false;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.ControlBox = false;

            form.DrawerAutoHide = false;
            form.DrawerAutoShow = false;
            form.DrawerHighlightWithAccent = false;
            form.DrawerWidth = 0;

            form.AutoScroll = true;
            form.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            form.AutoScaleMode = AutoScaleMode.None;

        }
    }
}
