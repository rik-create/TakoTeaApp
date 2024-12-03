using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Markup;
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
        ProductsService _productService;
        Entities _context;
        public ProductListForm()
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);
             _context = new Entities();
            _dataAccessObject = new DataAccessObject();
            _productService = new ProductsService();
            DataGridViewHelper.ApplyDataGridViewStyles(dataGridViewProductVariantList);
            LoadData();
            DataGridViewHelper.HideColumn(dataGridViewProductVariantList, "ProductVariantID");



/*            DataGridViewHelper.AddButtonsToLastRow(dataGridViewProductVariantList, "IngredientsAndInstructions", "Ingredients & Instructions", handleIAndIButton);
*/
        }


        private void handleIAndIButton(int selectedRowIndex)
        {
            if (selectedRowIndex >= 0 && selectedRowIndex < dataGridViewProductVariantList.Rows.Count)
            {
                int productVariantId = Convert.ToInt32(dataGridViewProductVariantList.Rows[selectedRowIndex].Cells["ProductVariantID"].Value);
                var productVariant = _context.ProductVariants.FirstOrDefault(pv => pv.ProductVariantID == productVariantId);

                if (productVariant != null)
                {
                    string message = $"Ingredients: {productVariant.Ingredients}\n\nInstructions: {productVariant.Instructions}";

                    // Create a custom font with increased size
                    Font largerFont = new Font(dataGridViewProductVariantList.Font.FontFamily, 12, FontStyle.Regular);

                    // Show the message box with the custom font and title
                    // Show the message box with the custom font and title
                    MessageBox.Show(
                        owner: this, // Assuming 'this' refers to your Form
                        text: message,
                        caption: $"{productVariant.VariantName} ({productVariant.Size}) - Ingredients & Instructions",
                        buttons: MessageBoxButtons.OK,
                        icon: MessageBoxIcon.Information,
                        defaultButton: MessageBoxDefaultButton.Button1,
                        options: 0
                    );
                }
                else
                {
                    MessageBox.Show("Product variant not found.");
                }
            }
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
     

            

            // Bind the data to the DataGridView
            DataGridViewHelper.LoadData(
                dataRetrievalFunc: () => _productService.GetProductVariantWithProductName(),
                dataGridView: dataGridViewProductVariantList,
                bindingSource: bindingSource,
                bindingNavigator: bindingNavigator1,
                errorMessage: "Failed to load product variants."
            );

            // Hide the ImagePath column
            DataGridViewHelper.HideColumn(dataGridViewProductVariantList, "ImagePath");

            // Add the Image column for image display (optional)
            DataGridViewHelper.AddImageColumnFromImagePath(dataGridViewProductVariantList, "ImagePath", 64, 64);
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
        private void UpdateProductVariantsGrid(List<object> filteredVariants)
        {
            DataGridViewHelper.UpdateGrid(dataGridViewProductVariantList, bindingSource, filteredVariants);
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
                string searchTerm = txtBoxSearchForVariants.Text.ToLower().Trim();
                var selectedProductNames = chkListBoxProducts.CheckedItems.Cast<string>().ToList();

                var filteredVariants = _productService.GetProductVariantWithProductName()
                    .Where(variant =>
                        (string.IsNullOrWhiteSpace(searchTerm) || variant.VariantName.ToLower().Contains(searchTerm) ||
                         variant.Size.ToLower().Contains(searchTerm) || variant.ProductName.ToLower().Contains(searchTerm)) &&
                        (selectedProductNames.Count == 0 || selectedProductNames.Contains(variant.ProductName)));

                DataGridViewHelper.UpdateGrid(dataGridViewProductVariantList, bindingSource, filteredVariants.ToList());
                DataGridViewHelper.AddImageColumnFromImagePath(dataGridViewProductVariantList, "ImagePath", 64, 64);
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
            dataGridViewProductVariantList.Refresh();
            LoadData();
            PopulateProductCheckedListBox();
        }

        private void materialCard1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DataGridViewHelper.DeleteSelectedRows<ProductVariant>(dataGridViewProductVariantList, "ProductVariantID");
            LoadData();
        }

        private void dataGridViewProductList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // In your ProductVariantListForm class

        private void dataGridViewProductVariantList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if a valid row was double-clicked
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && !dataGridViewProductVariantList.Rows[e.RowIndex].IsNewRow)
            {
                try
                {
                    // Get the ProductVariantID from the selected row
                    int productVariantId = Convert.ToInt32(dataGridViewProductVariantList.Rows[e.RowIndex].Cells["ProductVariantID"].Value); // Assuming "ProductVariantID" is the column name

                    // Create and show the EditProductVariantModal
                    EditProductVariantModal editProductVariantModal = new EditProductVariantModal(productVariantId);

                    editProductVariantModal.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening the edit modal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }


        private void materialFloatingActionButtonCopyInformation_Click(object sender, EventArgs e)
        {
            if (dataGridViewProductVariantList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select at least one row to copy.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Create an instance of AddProductModal
            AddProductModal addProductModal = new AddProductModal();

            foreach (DataGridViewRow row in dataGridViewProductVariantList.SelectedRows)
            {
                int productVariantId = Convert.ToInt32(row.Cells["ProductVariantID"].Value);

                // Fetch the complete ProductVariant data from the database
                var productVariant = _context.ProductVariants.FirstOrDefault(pv => pv.ProductVariantID == productVariantId);

                if (productVariant != null)
                {
                    // Add a new row to the AddProductModal's DataGridView
                    int rowIndex = addProductModal.dgViewAddingMultipleProductVariants.Rows.Add();
                    var newRow = addProductModal.dgViewAddingMultipleProductVariants.Rows[rowIndex];

                    // Populate the new row with data from the selected ProductVariant
                    newRow.Cells[addProductModal.VariantName.Index].Value = productVariant.VariantName;
                    newRow.Cells[addProductModal.ColumnProduct.Index].Value = (new ProductsService()).GetProductNameById(productVariant.ProductID); // Assuming you have a Product navigation property
                    newRow.Cells[addProductModal.ColumnSize.Index].Value = productVariant.Size;
                    newRow.Cells[addProductModal.ColumnPrice.Index].Value = productVariant.Price;
                    newRow.Cells[addProductModal.ColumnIngredients.Index].Value = productVariant.Ingredients;
                    newRow.Cells[addProductModal.ColumnInstructions.Index].Value = productVariant.Instructions;
                    newRow.Cells["ImagePathColumn"].Value = productVariant.ImagePath;
                }
            }

            // Show the AddProductModal dialog
            addProductModal.ShowDialog();

            // Optionally, show a message or update the UI to indicate success
        }

        private void txtBoxSearchForVariants_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }
    }

}
