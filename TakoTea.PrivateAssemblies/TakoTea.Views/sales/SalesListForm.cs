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
using TakoTea.View.Sales;
using TakoTea.Views.Order;
namespace TakoTea.Product
{
    public partial class SalesListForm : MaterialForm
    {
        DataAccessObject _dataAccessObject;
        ProductsService _productService;
        SalesService _salesService;
        MenuOrderFormService menuOrderFormService;
        Entities _context;
        public SalesListForm()
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);
            _context = new Entities();
            _dataAccessObject = new DataAccessObject();
            _productService = new ProductsService();
            _salesService = new SalesService(_context);
            DataGridViewHelper.ApplyDataGridViewStyles(dataGridViewSalesList);
            menuOrderFormService = new MenuOrderFormService();
            LoadData();
            DataGridViewHelper.HideColumn(dataGridViewSalesList, "OrderId");



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
                dataRetrievalFunc: () => _salesService.GetAllSales(),
                dataGridView: dataGridViewSalesList,
                bindingSource: bindingSource,
                bindingNavigator: bindingNavigator1,
                errorMessage: "Failed to load product variants."
            );

            // Hide the ImagePath column
            DataGridViewHelper.HideColumn(dataGridViewSalesList, "OrderId");

        }




        // Example usage in any form or class


        private void FilterSales()
        {
            try
            {
                string searchTerm = txtBoxSearchSales.Text.ToLower().Trim(); // Assuming you have a TextBox named txtBoxSearchSales

                var filteredSales = _salesService.GetAllSales()
                    .Where(sale =>
                        string.IsNullOrWhiteSpace(searchTerm) ||
                        sale.OrderId.ToString().Contains(searchTerm) ||
                        sale.CustomerName.ToLower().Contains(searchTerm) ||
                        sale.PaymentMethod.ToLower().Contains(searchTerm) ||
                        sale.OrderDate.ToString("yyyy-MM-dd HH:mm:ss").Contains(searchTerm)
                    );

                DataGridViewHelper.UpdateGrid(dataGridViewSalesList, bindingSource, filteredSales.ToList());
                // No need to add an image column for sales data
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering sales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FilterSales();
        }

        private void chkListBoxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterSales();
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
            dataGridViewSalesList.Refresh();
            LoadData();

        }



        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DataGridViewHelper.DeleteSelectedRows<OrderModel>(dataGridViewSalesList, "OrderId");
            LoadData();
        }


        // In your ProductVariantListForm class

        private void dataGridViewProductVariantList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if a valid row was double-clicked
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && !dataGridViewSalesList.Rows[e.RowIndex].IsNewRow)
            {
                try
                {
                    // Get the ProductVariantID from the selected row
                    int orderId = Convert.ToInt32(dataGridViewSalesList.Rows[e.RowIndex].Cells["OrderId"].Value); // Assuming "ProductVariantID" is the column name

                    // Create and show the EditProductVariantModal
                    menuOrderFormService.GenerateReceipt(orderId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening the edit modal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }


        }

        private void btnFilterByDateRange_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startDate = dateTimePickerStartDate.Value.Date;
                DateTime endDate = dateTimePickerEndDate.Value.Date.AddDays(1).AddTicks(-1); // End of the selected day

                var filteredSales = _salesService.GetAllSales()
                    .Where(sale => sale.OrderDate >= startDate && sale.OrderDate <= endDate)
                    .ToList();

                DataGridViewHelper.UpdateGrid(dataGridViewSalesList, bindingSource, filteredSales);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering sales by date range: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}