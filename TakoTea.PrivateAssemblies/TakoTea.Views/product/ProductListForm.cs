using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Helpers;
using TakoTea.Interfaces;
using TakoTea.Models;
using TakoTea.Product.Product_Modals;
using TakoTea.Repository;
using TakoTea.Services;
using TakoTea.View.Product.Product_Modals;
namespace TakoTea.Product
{
    public partial class ProductListForm : MaterialForm
    {
        DataAccessObject _dataAccessObject;
        IProductsService _productService;

        public ProductListForm()
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);

            _dataAccessObject = new DataAccessObject();
            _productService = new ProductsService();
            DataGridViewHelper.ApplyDataGridViewStyles(dataGridViewProductList);
            LoadData();
            DataGridViewHelper.HideColumn(dataGridViewProductList, "ProductVariantID");
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadData();
            PopulateProductCheckedListBox();
        }




        private void LoadData()
        {
            // Retrieve both Product and ProductVariant data
            var productVariantsWithProductName = _productService.GetAllProductVariants()
                .Join(_productService.GetAllProducts(),
                    pv => pv.ProductID,        // Key from ProductVariant
                    p => p.ProductID,          // Key from Product
                    (pv, p) => new
                    {
                        pv.ProductVariantID,
                        p.ProductName,         // Product name from Product table
                        pv.VariantName,
                        pv.Size,
                        pv.Price,
                        pv.StockLevel,
                        pv.ImagePath
                    })
                .ToList();  // Execute and retrieve the data



           

            // Bind the data to the DataGridView
            DataGridViewHelper.LoadData(
                dataRetrievalFunc: () => productVariantsWithProductName,
                dataGridView: dataGridViewProductList,
                bindingSource: bindingSource,
                bindingNavigator: bindingNavigator1,
                errorMessage: "Failed to load product variants."
            );

            // Hide the ImagePath column
            DataGridViewHelper.HideColumn(dataGridViewProductList, "ImagePath");

            // Add the Image column for image display (optional)
            DataGridViewHelper.AddImageColumnFromImagePath(dataGridViewProductList, "ImagePath", 64, 64);
        }


        private void PopulateProductCheckedListBox()
        {
            // Get all products from the database
            var products = _productService.GetAllProducts();

            // Clear existing items from the CheckedListBox
            chkListBoxProducts.Items.Clear();

            // Add each product to the CheckedListBox
            foreach (var product in products)
            {
                chkListBoxProducts.Items.Add(product.ProductName, false); // Assuming 'Name' is the product's name
            }
        }

        // Example usage in any form or class
        private void UpdateProductVariantsGrid(List<ProductVariant> filteredVariants)
        {
            DataGridViewHelper.UpdateGrid(dataGridViewProductList, bindingSource, filteredVariants);
        }





        private void materialButton1_Click(object sender, EventArgs e)
        {

        }

        private void floatingActionButtonAddProduct_Click(object sender, EventArgs e)
        {
            AddProductModal addProductModal = new AddProductModal();
            _ = addProductModal.ShowDialog();
            ThemeConfigurator.ApplyDarkTheme(this);
            LoadData();
        }

        private void btnAddComboMeal_Click(object sender, EventArgs e)
        {
            AddComboMealModal addComboMealModal = new AddComboMealModal();
            _ = addComboMealModal.ShowDialog();


        }
        private void FilterProductVariants()
        {
            try
            {
                // Get the search term from the text box and trim any extra spaces
                string searchTerm = txtBoxSearchForVariants.Text.ToLower().Trim();

                // Get the selected product names from the CheckedListBox
                var selectedProductNames = chkListBoxProducts.CheckedItems.Cast<string>().ToList();

                // Start with all product variants
                var filteredVariants = _productService.GetAllProductVariants()
                    .Join(_productService.GetAllProducts(),
                        pv => pv.ProductID,          // Key from ProductVariant
                        p => p.ProductID,            // Key from Product
                        (pv, p) => new
                        {
                            p.ProductName,           // Product name from Product table
                            pv.VariantName,
                            pv.Size,
                            pv.Price,
                            pv.StockLevel,
                            pv.ImagePath
                        });

                // If search term is not empty, filter by search term
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    filteredVariants = filteredVariants
                        .Where(variant => variant.VariantName.ToLower().Contains(searchTerm) ||
                                         variant.Size.ToLower().Contains(searchTerm) ||
                                         variant.ProductName.ToLower().Contains(searchTerm));
                }

                // If no product is selected, filter based on the checked products
                if (selectedProductNames.Count > 0)
                {
                    filteredVariants = filteredVariants
                        .Where(pv => selectedProductNames.Contains(pv.ProductName)); // Filter based on ProductName
                }

                // Convert to list and update DataGridView with filtered variants
                var finalFilteredVariants = filteredVariants.ToList();

                // Update the DataGridView using the helper method
                DataGridViewHelper.UpdateGrid(dataGridViewProductList, bindingSource, finalFilteredVariants);
                DataGridViewHelper.AddImageColumnFromImagePath(dataGridViewProductList, "ImagePath", 64, 64);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering product variants: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FilterProductVariants();
        }

        private void chkListBoxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterProductVariants();
        }

        private void btnHideFilters_Click(object sender, EventArgs e)
        {
            FilterPanelHelper.ToggleFilterPanel(panelFilteringComponents, btnHideFilters, pBoxShowFilter, false);
        }
        private void pBoxShowFilter_Click(object sender, EventArgs e)
        {
            FilterPanelHelper.ToggleFilterPanel(panelFilteringComponents, btnHideFilters, pBoxShowFilter, true);
        }

        private void pbReloadForm_Click(object sender, EventArgs e)
        {
            LoadData();
            PopulateProductCheckedListBox();
        }

        private void materialCard1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DataGridViewHelper.DeleteSelectedRows<ProductVariant>(dataGridViewProductList, "ProductVariantID");
            LoadData();
        }

        private void dataGridViewProductList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
