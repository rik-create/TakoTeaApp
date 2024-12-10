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
using TakoTea.Product;
using TakoTea.Repository;
using TakoTea.Services;
using TakoTea.View.Product.Product_Modals;
using TakoTea.Views.product;
namespace TakoTea.Product
{
    public partial class ProductForm : MaterialForm
    {
        DataAccessObject _dataAccessObject;
        ProductsService _productService;
        Entities _context;
        public ProductForm()
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);
             _context = new Entities();
            _dataAccessObject = new DataAccessObject();
            _productService = new ProductsService(_context);
            DataGridViewHelper.ApplyDataGridViewStyles(dataGridViewProductList);
            LoadData();
            DataGridViewHelper.HideColumn(dataGridViewProductList, "ProductCategoryID");

            DataGridViewHelper.HideColumn(dataGridViewProductList, "ProductImage");


            /*            DataGridViewHelper.AddButtonsToLastRow(dataGridViewProductVariantList, "IngredientsAndInstructions", "Ingredients & Instructions", handleIAndIButton);
            */
        }


        private void handleIAndIButton(int selectedRowIndex)
        {
            if (selectedRowIndex >= 0 && selectedRowIndex < dataGridViewProductList.Rows.Count)
            {
                int productVariantId = Convert.ToInt32(dataGridViewProductList.Rows[selectedRowIndex].Cells["ProductVariantID"].Value);
                var productVariant = _context.ProductVariants.FirstOrDefault(pv => pv.ProductVariantID == productVariantId);

                if (productVariant != null)
                {
                    string message = $"Ingredients: {productVariant.Ingredients}\n\nInstructions: {productVariant.Instructions}";

                    // Create a custom font with increased size
                    Font largerFont = new Font(dataGridViewProductList.Font.FontFamily, 12, FontStyle.Regular);

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
                dataRetrievalFunc: () => GetAllProducts(),
                dataGridView: dataGridViewProductList,
                bindingSource: bindingSource,
                bindingNavigator: bindingNavigator1,
                errorMessage: "Failed to load product variants."
            );

            // Hide the ImagePath column

            // Add the Image column for image display (optional)


        }


        private void PopulateProductCheckedListBox()
        {
            // Get all products from the database
            
        }

        // Example usage in any form or class
        private void UpdateProductVariantsGrid(List<object> filteredVariants)
        {
            DataGridViewHelper.UpdateGrid(dataGridViewProductList, bindingSource, filteredVariants);
        }





        private void materialButton1_Click(object sender, EventArgs e)
        {

        }
  

        private void floatingActionButtonAddProduct_Click(object sender, EventArgs e)
        {

        }

        private void btnAddComboMeal_Click(object sender, EventArgs e)
        {
            AddComboMealModal addComboMealModal = new AddComboMealModal();
            _ = addComboMealModal.ShowDialog();


        }
        private void FilterProductVariants()
        {
           
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
            dataGridViewProductList.Refresh();
            LoadData();
            PopulateProductCheckedListBox();
        }

        private void materialCard1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DataGridViewHelper.DeleteSelectedRows<TakoTea.Models.Product>(dataGridViewProductList, "ProductsID");
            LoadData();
        }

        private void dataGridViewProductList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // In your ProductVariantListForm class
/*
        private void dataGridViewProductVariantList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if a valid row was double-clicked
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && !dataGridViewProductList.Rows[e.RowIndex].IsNewRow)
            {
                try
                {
                    // Get the ProductVariantID from the selected row
                    int productVariantId = Convert.ToInt32(dataGridViewProductList.Rows[e.RowIndex].Cells["ProductVariantID"].Value); // Assuming "ProductVariantID" is the column name

                    // Create and show the EditProductVariantModal
                    EditProductVariantModal editProductVariantModal = new EditProductVariantModal(productVariantId);

                    editProductVariantModal.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening the edit modal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }*/


        private void materialFloatingActionButtonCopyInformation_Click(object sender, EventArgs e)
        {
            if (dataGridViewProductList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select at least one row to copy.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Create an instance of AddProductModal
            AddProductModal addProductModal = new AddProductModal();

            foreach (DataGridViewRow row in dataGridViewProductList.SelectedRows)
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
                    newRow.Cells[addProductModal.ColumnProduct.Index].Value = (new ProductsService(_context)).GetProductNameById(productVariant.ProductID); // Assuming you have a Product navigation property
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
        public List<ProductInfo> GetAllProducts()
        {
            using (var context = new Entities())
            {
                return context.Products
                              .Select(p => new ProductInfo
                              {
                                  ProductID = p.ProductID,
                                  ProductName = p.ProductName,
                              })
                              .ToList();
            }
        }

        public class ProductInfo
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public int? ProductCategoryID { get; set; }
            public string ProductImage { get; set; }
        }

        private void floatingActionButtonAddProduct_Click_1(object sender, EventArgs e)
        {
            AddProductCategoryModal addProductCategoryModal = new AddProductCategoryModal(new ProductCategoryService(new DataAccessObject()));
            _ = addProductCategoryModal.ShowDialog();

        }

        private void dataGridViewProductList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if a valid row is double-clicked
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && !dataGridViewProductList.Rows[e.RowIndex].IsNewRow)
            {
                try
                {
                    // Get the ProductID from the selected row
                    int productId = Convert.ToInt32(dataGridViewProductList.Rows[e.RowIndex].Cells["ProductID"].Value);

                    // Create and show the ProductDetailsForm
                    ProductDetailsForm productDetailsForm = new ProductDetailsForm(productId);
                    productDetailsForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening product details form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

}
