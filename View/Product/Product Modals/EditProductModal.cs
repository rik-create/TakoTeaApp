using MaterialSkin.Controls;
using System;
using TakoTea.Configurations;

namespace TakoTea.Product.Product_Modals
{

    public partial class EditProductModal : MaterialForm
    {

        public EditProductModal()
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
