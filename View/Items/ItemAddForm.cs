using MaterialSkin.Controls;
using System;
using TakoTea.Configurations;

namespace TakoTea.Items
{
    public partial class ItemAddForm : MaterialForm
    {
        public ItemAddForm()
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
