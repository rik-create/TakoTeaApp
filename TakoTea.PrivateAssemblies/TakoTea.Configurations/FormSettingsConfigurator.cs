﻿using MaterialSkin.Controls;
using System.Windows.Forms;
namespace TakoTea.Configurations
{
    public static class FormSettingsConfigurator
    {
        public static void ApplyStandardFormSettings(MaterialForm form)
        {
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Sizable = false;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.DrawerAutoHide = false;
            form.DrawerAutoShow = false;
            form.DrawerHighlightWithAccent = false;
            form.DrawerWidth = 0;
            form.AutoScroll = true;
            form.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            form.AutoScaleMode = AutoScaleMode.None;
            form.Padding = new Padding(0);
        }

        public static void ApplyStandardModalSettings(MaterialForm form)
        {
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormBorderStyle = FormBorderStyle.Sizable;
            form.Sizable = true;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.DrawerAutoHide = false;
            form.DrawerAutoShow = false;
            form.DrawerHighlightWithAccent = false;
            form.DrawerWidth = 0;
            form.AutoScroll = true;
            form.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            form.AutoScaleMode = AutoScaleMode.None;
            form.Padding = new Padding(0);
        }
    }
}
