using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using TakoTea.Helpers;
using TakoTea.Interfaces;
using TakoTea.Models;
using TakoTea.Services;
namespace TakoTea.View.Product.Product_Modals
{
    public partial class AddProductCategoryModal : MaterialForm
    {
        private readonly ProductCategoryService _productCategoryService;
        private readonly ProductsService productsService;


        public AddProductCategoryModal(ProductCategoryService productCategoryService)
        {
            InitializeComponent();
            productsService = new ProductsService(new Entities());
            _productCategoryService = productCategoryService;
        }

        private void btnSaveProduct_Click(object sender, EventArgs e)
        {
            // Gather input
            string productName = txtBoxProductName.Text;
            string productCategory = cmbProductVategory.SelectedItem?.ToString();

            // Validate inputs
            if (string.IsNullOrEmpty(productName))
            {
                DialogHelper.ShowError("Product Name is required.");
                return;
            }

            if (string.IsNullOrEmpty(productCategory))
            {
                DialogHelper.ShowError("Please select a Product Category.");
                return;
            }


            // Create new ProductCategoryModel
            TakoTea.Models.Product newProduct = new TakoTea.Models.Product
            {
                ProductName = productName,
                ProductCategoryName = productCategory,
            };

            try
            {
                // Save product category
                productsService.AddProduct(newProduct);
                DialogHelper.ShowSuccess("Product Category added successfully!");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                DialogHelper.ShowError($"Failed to add Product Category. Error: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Confirm cancel action
            DialogResult dialogResult = MessageBox.Show(
                "Are you sure you want to cancel? Any unsaved changes will be lost.",
                "Confirm Cancel",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (dialogResult == DialogResult.Yes)
            {
                Close();
            }
        }


        private void btnSaveProduct_Click_1(object sender, EventArgs e)
        {

        }
    }


}
