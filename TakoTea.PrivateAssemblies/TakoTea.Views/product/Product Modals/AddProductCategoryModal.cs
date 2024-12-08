using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using TakoTea.Helpers;
using TakoTea.Interfaces;
using TakoTea.Views.DataLoaders;
using TakoTea.Models;
using TakoTea.Services;
namespace TakoTea.View.Product.Product_Modals
{
    public partial class AddProductCategoryModal : MaterialForm
    {
        private readonly ProductCategoryService _productCategoryService;

        public AddProductCategoryModal(ProductCategoryService productCategoryService)
        {
            InitializeComponent();
            _productCategoryService = productCategoryService;
        }

        private void btnSaveProduct_Click(object sender, EventArgs e)
        {
            // Gather input
            string productName = txtBoxProductName.Text;
            string productCategory = cmbProductVategory.SelectedItem?.ToString();
            string productImage = pictureBoxProductImage.ImageLocation;

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

            if (string.IsNullOrEmpty(productImage))
            {
                DialogHelper.ShowError("Please provide an image for the product.");
                return;
            }

            // Create new ProductCategoryModel
            var newProductCategory = new ProductCategoryModel
            {
                Name = productName,
                Category = productCategory,
                Image = productImage
            };

            try
            {
                // Save product category
                _productCategoryService.Save(newProductCategory);
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

        private void btnBrowseImg_Click(object sender, EventArgs e)
        {
            // Open file dialog to select an image for the product category
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxProductImage.ImageLocation = openFileDialog.FileName;
                }
            }
        }

        private void btnSaveProduct_Click_1(object sender, EventArgs e)
        {

        }
    }


}
