using MaterialSkin.Controls;
using System;
using TakoTea.Configurations;

namespace TakoTea.Views.AddOns
{
    public partial class AddAddOnsModal : MaterialForm
    {
        public AddAddOnsModal()
        {
            InitializeComponent();

            ThemeConfigurator.ApplyDarkTheme(this);
            ModalSettingsConfigurator.ApplyStandardModalSettings(this);


            ModalSettingsConfigurator.ApplyStandardModalSettings(this);

        }

        private void AddProductModal_Load(object sender, EventArgs e)
        {

        }
    }
}
