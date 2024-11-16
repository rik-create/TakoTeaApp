using MaterialSkin.Controls;
using System;
using TakoTea.Configurations;

namespace TakoTea.View.Product.Product_Modals
{
    public partial class AddProductModal : MaterialForm
    {
        public AddProductModal()
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
