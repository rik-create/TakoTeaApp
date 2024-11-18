using MaterialSkin.Controls;
using System;
using TakoTea.Configurations;
namespace TakoTea.View.Items.Item_Modals
{
    public partial class EditItemModal : MaterialForm
    {
        public EditItemModal()
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            ModalSettingsConfigurator.ApplyStandardModalSettings(this);
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
        }
        private void materialLabel6_Click(object sender, EventArgs e)
        {
        }
    }
}
