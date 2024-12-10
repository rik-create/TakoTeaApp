using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using TakoTea.Helpers;
using TakoTea.Interfaces;
using TakoTea.Views.DataLoaders;
using TakoTea.Models;
using TakoTea.Services;
using Helpers;
namespace TakoTea.View.Product.Product_Modals
{
    public partial class AddProductCategoryModal : MaterialForm
    {
        private readonly ProductCategoryService _productCategoryService;
        private readonly ProductsService _productsService;

        public AddProductCategoryModal(ProductCategoryService productCategoryService)
        {
            InitializeComponent();
            _productCategoryService = productCategoryService;
            _productsService = new ProductsService(new Entities());
            btnCancel.Click += btnCancel_Click;
        }
        private void btnSaveProduct_Click(object sender, EventArgs e)
        {
     
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

            try
            {
                // Create Product object
                TakoTea.Models.Product newProduct = new TakoTea.Models.Product
                {
                    ProductName = productName,
/*                    CategoryName = productCategory // Assuming you have a method to get category ID
*/                };

                // Save product using ProductService
                _productsService.AddProduct(newProduct);

                DialogHelper.ShowSuccess("Product added successfully!");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                DialogHelper.ShowError($"Failed to add Product. Error: {ex.Message}");
            }
        }
    }


}
