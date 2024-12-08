using MaterialSkin.Controls;
using System;
using TakoTea.Configurations;
using TakoTea.Helpers;
using TakoTea.Interfaces;
using TakoTea.Models;
using TakoTea.Repository;
using TakoTea.Services;
using TakoTea.View.Product.Product_Modals;
namespace TakoTea.View.Product
{
    public partial class ProductCategoryForm : MaterialForm
    {

        ProductCategoryService service;
        DataAccessObject _dao;
        public ProductCategoryForm()
        {
            InitializeComponent();
            _dao = new DataAccessObject();
            service = new ProductCategoryService(_dao);

            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);
        }
        private void floatingActionButtonAddProduct_Click(object sender, EventArgs e)
        {
            AddProductCategoryModal addProductCategoryModal = new AddProductCategoryModal(service);
            _ = addProductCategoryModal.ShowDialog();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DataGridViewHelper.DeleteSelectedRows<TakoTea.Models.Product>(dataGridViewProductList, "ProductID");

        }
    }
}
