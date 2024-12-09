using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
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
namespace TakoTea.Product
{
    public partial class ProductListLogsForm : MaterialForm
    {
        DataAccessObject _dataAccessObject;
        ProductsService _productService;
        Entities _context;
        public ProductListLogsForm()
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);
             _context = new Entities();
            _dataAccessObject = new DataAccessObject();
            _productService = new ProductsService(_context);
            LoadData();
            DataGridViewHelper.ApplyDataGridViewStyles(dataGridViewProductVariantList);

            DataGridViewHelper.HideColumn(dataGridViewProductVariantList, "LogID");
            DataGridViewHelper.HideColumn(dataGridViewProductVariantList, "CreatedBy");
            DataGridViewHelper.HideColumn(dataGridViewProductVariantList, "CreatedAt");
            DataGridViewHelper.HideColumn(dataGridViewProductVariantList, "UpdatedAt");


            DataGridViewHelper.HideColumn(dataGridViewProductVariantList, "UpdatedBy");
            btnClearFilters.Enabled = true;

            /*            DataGridViewHelper.AddButtonsToLastRow(dataGridViewProductVariantList, "IngredientsAndInstructions", "Ingredients & Instructions", handleIAndIButton);
            */
        }



        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadData();
        }

 

        private void LoadData()
        {

            // Retrieve both Product and ProductVariant data
     

            

            // Bind the data to the DataGridView
            DataGridViewHelper.LoadData(
                dataRetrievalFunc: () => LogChangesRepository.GetProductVariantChangeLogs(),
                dataGridView: dataGridViewProductVariantList,
                bindingSource: bindingSource,
                bindingNavigator: bindingNavigator1,
                errorMessage: "Failed to load product variants."
            );

            // Hide the ImagePath column

            // Add the Image column for image display (optional)
/*            DataGridViewHelper.HideColumn(dataGridViewProductVariantList, "ImagePath");
*/
            DataGridViewHelper.FormatColumnHeaders(dataGridViewProductVariantList);
            LogChangesRepository.FillFilterLists("ProductVariants", checkedListBoxAction, chkListBoxColumnName);
        }




        private void FilterProductVariantsLogs()
        {
            try
            {
                string searchTerm = txtBoxSearchLogs.Text.ToLower().Trim(); // Assuming you have a TextBox named "txtBoxSearchLogs"
                var selectedColumnNames = chkListBoxColumnName.CheckedItems.Cast<string>().ToList();
                var selectedActions = checkedListBoxAction.CheckedItems.Cast<string>().ToList();

                DateTime startDate = dateTimePickerStart.Value.Date;
                DateTime endDate = dateTimePickerEnd.Value.Date.AddDays(1); // Include the end date

                var filteredLogs = LogChangesRepository.GetProductVariantChangeLogs()
                    .Where(log =>
                        log.Timestamp >= startDate && log.Timestamp < endDate &&
                        (string.IsNullOrWhiteSpace(searchTerm) ||
                         log.NewValue.ToLower().Contains(searchTerm) ||
                         log.OldValue.ToLower().Contains(searchTerm) ||
                         log.ColumnName.ToLower().Contains(searchTerm)) &&
                        (selectedColumnNames.Count == 0 || selectedColumnNames.Contains(log.ColumnName)) &&
                        (selectedActions.Count == 0 || selectedActions.Contains(log.Action))
                    );

                // Update the DataGridView (assuming you have one to display the logs)
                DataGridViewHelper.UpdateGrid(dataGridViewProductVariantList, bindingSource, filteredLogs.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering product variant logs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FilterProductVariantsLogs();        
        }

        private void chkListBoxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterProductVariantsLogs();

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


        private void panelFilteringComponents_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewProductVariantList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }


        private void checkedListBoxStockLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterProductVariantsLogs();

        }

        private void dataGridViewProductVariantList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewHelper.SortDataGridView(dataGridViewProductVariantList, e.ColumnIndex);
            FilterProductVariantsLogs();

        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            DateHelper.ValidateDateRange(dateTimePickerStart, dateTimePickerEnd, "Start date must be before end date.", -1);

        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            DateHelper.ValidateDateRange(dateTimePickerStart, dateTimePickerEnd, "Start date must be before end date.",1);
            FilterProductVariantsLogs();


        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            FilterPanelHelper.ResetFilters(dateTimePickerStart, dateTimePickerEnd, "ProductVariants", "Timestamp");
            CheckedListBoxHelper.ClearAllCheckedListBoxesInPanel(panelFilteringComponents);

        }
    }

}
