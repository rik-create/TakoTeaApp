using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Helpers;
using TakoTea.Models;
using TakoTea.Repository;
using TakoTea.Services;
using TakoTea.View.Product.Product_Modals;
namespace TakoTea.Product
{
    public partial class ProductListForm : MaterialForm
    {
        private readonly DataAccessObject _dataAccessObject;
        private readonly ProductsService _productService;
        private readonly Entities _context;
        public ProductListForm()
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);
            _context = new Entities();
            _dataAccessObject = new DataAccessObject();
            _productService = new ProductsService(_context);
            LoadData();
            DataGridViewHelper.ApplyDataGridViewStyles(dataGridViewProductVariantListLogs);
            DataGridViewHelper.HideColumn(dataGridViewProductVariantListLogs, "ProductVariantID");
            checkedListBoxStockLevel.SelectedIndexChanged += checkedListBoxStockLevel_SelectedIndexChanged;
            chkListBoxProducts.SelectedIndexChanged += chkListBoxProducts_SelectedIndexChanged;
            /*            DataGridViewHelper.AddButtonsToLastRow(dataGridViewProductVariantList, "IngredientsAndInstructions", "Ingredients & Instructions", handleIAndIButton);
            */

            DataGridViewHelper.FormatColumnHeaders(dataGridViewProductVariantListLogs);

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
                dataGridView: dataGridViewProductVariantListLogs,
                bindingSource: bindingSource,
                bindingNavigator: bindingNavigator1,
                errorMessage: "Failed to load product variants."
            );
            // Hide the ImagePath column
            // Add the Image column for image display (optional)
            dataGridViewProductVariantListLogs.Columns["Price"].DefaultCellStyle.Format = "₱#,##0.00";
            /*            DataGridViewHelper.HideColumn(dataGridViewProductVariantList, "ImagePath");
            */
            DataGridViewHelper.ResizeImageBytes(dataGridViewProductVariantListLogs, "ImagePath", "ImagePath", 64, 64);
        }
        private void PopulateProductCheckedListBox()
        {
            // Get all products from the database
            List<Models.Product> products = _productService.GetAllProducts();
            // Clear existing items from the CheckedListBox
            chkListBoxProducts.Items.Clear();
            // Add each product to the CheckedListBox
            foreach (Models.Product product in products)
            {
                _ = chkListBoxProducts.Items.Add(product.ProductName, false); // Assuming 'Name' is the product's name
            }
        }
        // Example usage in any form or class
        private void UpdateProductVariantsGrid(List<object> filteredVariants)
        {
            DataGridViewHelper.UpdateGrid(dataGridViewProductVariantListLogs, bindingSource, filteredVariants);
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
                List<string> selectedProductNames = chkListBoxProducts.CheckedItems.Cast<string>().ToList();
                IEnumerable<ProductVariantWithProductName> filteredVariants = _productService.GetProductVariantWithProductName()
                    .Where(variant =>
                        (string.IsNullOrWhiteSpace(searchTerm) || variant.VariantName.ToLower().Contains(searchTerm) ||
                         variant.Size.ToLower().Contains(searchTerm) || variant.ProductName.ToLower().Contains(searchTerm)) &&
                        (selectedProductNames.Count == 0 || selectedProductNames.Contains(variant.ProductName)));
                List<int> checkedStockLevels = checkedListBoxStockLevel.CheckedIndices.Cast<int>().ToList();
                if (checkedStockLevels.Count > 0)
                {
                    filteredVariants = filteredVariants.Where(variant =>
                        checkedStockLevels.Any(index =>
                            (index == 0 && variant.StockLevel > 0) || // In Stock
                            (index == 1 && variant.StockLevel < 30) || // Low Stock
                            (index == 2 && variant.StockLevel == 0)));  // Out of Stock
                }
                DataGridViewHelper.UpdateGrid(dataGridViewProductVariantListLogs, bindingSource, filteredVariants.ToList());
                DataGridViewHelper.ResizeImageBytes(dataGridViewProductVariantListLogs, "ImagePath", "ImagePath", 64, 64);
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show("Error filtering product variants: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dataGridViewProductVariantListLogs.Refresh();
            LoadData();
            PopulateProductCheckedListBox();
        }
        private void materialCard1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DataGridViewHelper.DeleteSelectedRows<ProductVariant>(dataGridViewProductVariantListLogs, "ProductVariantID");
            LoadData();
        }
        private void dataGridViewProductList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        // In your ProductVariantListForm class
        private void dataGridViewProductVariantList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if a valid row was double-clicked
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && !dataGridViewProductVariantListLogs.Rows[e.RowIndex].IsNewRow)
            {
                try
                {
                    // Get the ProductVariantID from the selected row
                    int productVariantId = Convert.ToInt32(dataGridViewProductVariantListLogs.Rows[e.RowIndex].Cells["ProductVariantID"].Value); // Assuming "ProductVariantID" is the column name
                    // Create and show the EditProductVariantModal
                    EditProductVariantModal editProductVariantModal = new EditProductVariantModal(productVariantId);
                    _ = editProductVariantModal.ShowDialog();
                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show("Error opening the edit modal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void materialFloatingActionButtonCopyInformation_Click(object sender, EventArgs e)
        {
            if (dataGridViewProductVariantListLogs.SelectedRows.Count == 0)
            {
                _ = MessageBox.Show("Please select at least one row to copy.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Create an instance of AddProductModal
            AddProductModal addProductModal = new AddProductModal();
            foreach (DataGridViewRow row in dataGridViewProductVariantListLogs.SelectedRows)
            {
                int productVariantId = Convert.ToInt32(row.Cells["ProductVariantID"].Value);
                // Fetch the complete ProductVariant data from the database
                ProductVariant productVariant = _context.ProductVariants.FirstOrDefault(pv => pv.ProductVariantID == productVariantId);
                if (productVariant != null)
                {
                    // Add a new row to the AddProductModal's DataGridView
                    int rowIndex = addProductModal.dgViewAddingMultipleProductVariants.Rows.Add();
                    DataGridViewRow newRow = addProductModal.dgViewAddingMultipleProductVariants.Rows[rowIndex];
                    // Populate the new row with data from the selected ProductVariant
                    newRow.Cells[addProductModal.VariantName.Index].Value = productVariant.VariantName;
                    newRow.Cells[addProductModal.ColumnProduct.Index].Value = new ProductsService(_context).GetProductNameById(productVariant.ProductID); // Assuming you have a Product navigation property
                    newRow.Cells[addProductModal.ColumnSize.Index].Value = productVariant.Size;
                    newRow.Cells[addProductModal.ColumnPrice.Index].Value = productVariant.Price;
                    newRow.Cells[addProductModal.ColumnIngredients.Index].Value = productVariant.Ingredients;
                    newRow.Cells[addProductModal.ColumnInstructions.Index].Value = productVariant.Instructions;
                    newRow.Cells["ImagePathColumn"].Value = productVariant.ImagePath;
                }
            }
            // Show the AddProductModal dialog
            _ = addProductModal.ShowDialog();
            // Optionally, show a message or update the UI to indicate success
        }
        private void txtBoxSearchForVariants_Click(object sender, EventArgs e)
        {
        }
        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
        }
        private void panelFilteringComponents_Paint(object sender, PaintEventArgs e)
        {
        }
        private void dataGridViewProductVariantList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }
        private void checkedListBoxStockLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterProductVariants();
        }
        private void dataGridViewProductVariantList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewHelper.SortDataGridView(dataGridViewProductVariantListLogs, e.ColumnIndex);
        }
        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            CheckedListBoxHelper.ClearAllCheckedListBoxesInPanel(panelFilteringComponents);
            FilterProductVariants();
        }
    }
}
