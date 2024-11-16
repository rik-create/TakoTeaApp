using MaterialSkin.Controls;
using System;
using TakoTea.Configurations;
using TakoTea.View.Product.Product_Modals;

namespace TakoTea.View.Product
{

    public partial class ProductCategoryForm : MaterialForm
    {
        public ProductCategoryForm()
        {
            InitializeComponent();

            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);

        }

        private void floatingActionButtonAddProduct_Click(object sender, EventArgs e)
        {
            AddProductCategoryModal addProductCategoryModal = new AddProductCategoryModal();
            addProductCategoryModal.ShowDialog();
        }
    }
}
