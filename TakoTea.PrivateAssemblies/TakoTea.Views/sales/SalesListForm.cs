using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Helpers;
using TakoTea.Models;
using TakoTea.Repository;
using TakoTea.Services;
using TakoTea.Views.Order;
namespace TakoTea.Product
{
    public partial class SalesListForm : MaterialForm
    {
        private readonly DataAccessObject _dataAccessObject;
        private readonly ProductsService _productService;
        private readonly SalesService _salesService;
        private readonly MenuOrderFormService menuOrderFormService;
        private readonly Entities _context;
        public SalesListForm()
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);
            _context = new Entities();
            _dataAccessObject = new DataAccessObject();
            _productService = new ProductsService(_context);
            _salesService = new SalesService(_context);
            menuOrderFormService = new MenuOrderFormService();
            DataGridViewHelper.ApplyDataGridViewStyles(dataGridViewSalesList);
            dateTimePickerStartDate.MinDate = new DateTime(2019, 1, 1);
            dateTimePickerEndDate.MaxDate = new DateTime(2400, 12, 31);

            LoadData();
            clearFilters();



            DataGridViewHelper.FormatColumnHeaders(dataGridViewSalesList);


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

            List<string> orderStatuses = _salesService.GetAllSales()
                                 .Select(s => s.OrderStatus)
                                 .Distinct()
                                 .ToList();
            chkListBoxOrderStatus.DataSource = orderStatuses;

            // Fill checkedListBoxPaymentMethod
            List<string> paymentMethods = _salesService.GetAllSales()
                                             .Select(s => s.PaymentMethod)
                                             .Distinct()
                                             .ToList();
            checkedListBoxPaymentMethod.DataSource = paymentMethods;

            // Fill checkedListBoxPaymentStatus
            List<string> paymentStatuses = _salesService.GetAllSales()
                                              .Select(s => s.PaymentStatus)
                                              .Distinct()
                                              .ToList();
            checkedListBoxPaymentStatus.DataSource = paymentStatuses;
            // Hide the ImagePath column

            // Format TotalAmount column as currency
            dataGridViewSalesList.Columns["TotalAmount"].DefaultCellStyle.Format = "₱#,##0.00";
            dataGridViewSalesList.Columns["GrossProfit"].DefaultCellStyle.Format = "₱#,##0.00";
            dataGridViewSalesList.Columns["PaymentAmount"].DefaultCellStyle.Format = "₱#,##0.00";

            foreach (DataGridViewColumn column in dataGridViewSalesList.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }

        }




        // Example usage in any form or class


        private void FilterSales()
        {
            try
            {
                string searchTerm = txtBoxSearchSales.Text.ToLower().Trim();

                List<string> selectedOrderStatuses = chkListBoxOrderStatus.CheckedItems.Cast<string>().ToList();
                List<string> selectedPaymentMethods = checkedListBoxPaymentMethod.CheckedItems.Cast<string>().ToList();
                List<string> selectedPaymentStatuses = checkedListBoxPaymentStatus.CheckedItems.Cast<string>().ToList();

                DateTime startDate = dateTimePickerStartDate.Value.Date;
                DateTime endDate = dateTimePickerEndDate.Value.Date.AddDays(1).AddTicks(-1); // End of the selected day

                IEnumerable<SalesData> filteredSales = _salesService.GetAllSales()
                    .Where(sale =>
                        (string.IsNullOrWhiteSpace(searchTerm) ||
                         sale.OrderId.ToString().Contains(searchTerm) ||
                         sale.CustomerName.ToLower().Contains(searchTerm) ||
                         sale.PaymentMethod.ToLower().Contains(searchTerm) ||
                         sale.OrderDate.ToString("yyyy-MM-dd HH:mm:ss").Contains(searchTerm)) &&
                        (selectedOrderStatuses.Count == 0 || selectedOrderStatuses.Contains(sale.OrderStatus)) &&
                        (selectedPaymentMethods.Count == 0 || selectedPaymentMethods.Contains(sale.PaymentMethod)) &&
                        (selectedPaymentStatuses.Count == 0 || selectedPaymentStatuses.Contains(sale.PaymentStatus)) &&
                        sale.OrderDate >= startDate && sale.OrderDate <= endDate
                    );

                DataGridViewHelper.UpdateGrid(dataGridViewSalesList, bindingSource, filteredSales.ToList());
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show("Error filtering sales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    _ = MessageBox.Show("Error opening the edit modal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }


        }

        private void btnFilterByDateRange_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startDate = dateTimePickerStartDate.Value.Date;
                DateTime endDate = dateTimePickerEndDate.Value.Date.AddDays(1).AddTicks(-1); // End of the selected day

                List<SalesData> filteredSales = _salesService.GetAllSales()
                    .Where(sale => sale.OrderDate >= startDate && sale.OrderDate <= endDate)
                    .ToList();

                DataGridViewHelper.UpdateGrid(dataGridViewSalesList, bindingSource, filteredSales);
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show("Error filtering sales by date range: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewSalesList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewHelper.SortDataGridView(dataGridViewSalesList, e.ColumnIndex);

        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            clearFilters();

        }

        private void clearFilters()
        {
            DateHelper.InitializeDateTimePickers(dateTimePickerStartDate, dateTimePickerEndDate);

            CheckedListBoxHelper.ClearAllCheckedListBoxesInPanel(panelFilteringComponents);
            FilterSales();
        }

        private void materialLabel21_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePickerEndDate_ValueChanged(object sender, EventArgs e)
        {
            DateHelper.ValidateDateRange(dateTimePickerStartDate, dateTimePickerEndDate, "End date must be after start date.", 1);

            FilterSales();
        }

        private void dateTimePickerStartDate_ValueChanged(object sender, EventArgs e)
        {
            DateHelper.ValidateDateRange(dateTimePickerStartDate, dateTimePickerEndDate, "Start date must be before end date.", -1);

            FilterSales();
        }

        private void checkedListBoxPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterSales();

        }

        private void checkedListBoxPaymentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterSales();

        }

        private async void txtBoxSearchSales_Click(object sender, EventArgs e)
        {
            await Task.Delay(300); // Add a delay of 1500 milliseconds
            FilterSales();
        }
    }
}