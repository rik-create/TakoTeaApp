using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
namespace TakoTea.Views.Logs2
{
    public partial class LogsForm : MaterialForm
    {
        DataAccessObject _dataAccessObject;
        ProductsService _productService;
        LogsRepository _logsRepository;
        MenuOrderFormService menuOrderFormService;
        Entities context;
        public LogsForm()
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);
            context = new Entities();
            _dataAccessObject = new DataAccessObject();
            _productService = new ProductsService();
            _logsRepository = new LogsRepository(context);
            DataGridViewHelper.ApplyDataGridViewStyles(dataGridViewLogs);
            menuOrderFormService = new MenuOrderFormService();
            LoadData();
            DataGridViewHelper.HideColumn(dataGridViewLogs, "LogID");



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
                dataRetrievalFunc: () => _logsRepository.GetAllLogs(),
                dataGridView: dataGridViewLogs,
                bindingSource: bindingSource,
                bindingNavigator: bindingNavigator1,
                errorMessage: "Failed to load logs."
            );

            // Hide the ImagePath column
            DataGridViewHelper.HideColumn(dataGridViewLogs, "LogID");
            FillFilterControls();
        }

        // Assuming you have these controls on your Form:
        // - checkedListBoxTableNames
        // - comboBoxActions

        private void FillFilterControls()
        {
            try
            {
                // Fill checkedListBoxTableNames with distinct table names from the Logs table
                var tableNames = context.Logs.Select(l => l.TableName).Distinct().ToList();
                chkListBoxTableNames.Items.AddRange(tableNames.ToArray());

                // Fill comboBoxActions with distinct actions from the Logs table
                var actions = context.Logs.Select(l => l.Action).Distinct().ToList();
                cmbActions.Items.AddRange(actions.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading filter controls: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Example usage in any form or class


        private void FilterLogs()
        {
            try
            {
                string searchTerm = txtBoxSearchLogs.Text.ToLower().Trim(); // Assuming you have a TextBox named txtBoxSearchLogs
                var selectedTableNames = chkListBoxTableNames.CheckedItems.Cast<string>().ToList();
                string selectedAction = cmbActions.SelectedItem?.ToString();

                var filteredLogs = _logsRepository.GetAllLogs()
                    .Where(log =>
                        (string.IsNullOrWhiteSpace(searchTerm) ||
                         log.TableName.ToLower().Contains(searchTerm) ||
                         log.RecordID.ToString().Contains(searchTerm) ||
                         log.ColumnName.ToLower().Contains(searchTerm) ||
                         log.Action.ToLower().Contains(searchTerm) ||
                         log.Username.ToLower().Contains(searchTerm)) &&
                        (selectedTableNames.Count == 0 || selectedTableNames.Contains(log.TableName)) &&
                        (string.IsNullOrEmpty(selectedAction) || log.Action == selectedAction)
                    );

                DataGridViewHelper.UpdateGrid(dataGridViewLogs, bindingSource, filteredLogs.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering logs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FilterLogs();
        }

        private void chkListBoxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterLogs();
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
            dataGridViewLogs.Refresh();
            LoadData();

        }



        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DataGridViewHelper.DeleteSelectedRows<TakoTea.Models.Log>(dataGridViewLogs, "LogID");
            LoadData();
        }


        // In your ProductVariantListForm class

        private void dataGridViewProductVariantList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if a valid row was double-clicked
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && !dataGridViewLogs.Rows[e.RowIndex].IsNewRow)
            {
                try
                {
                    // Get the ProductVariantID from the selected row
                    int orderId = Convert.ToInt32(dataGridViewLogs.Rows[e.RowIndex].Cells["OrderId"].Value); // Assuming "ProductVariantID" is the column name

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

                var filteredLogs = _logsRepository.GetAllLogs()
                    .Where(log => log.Timestamp >= startDate && log.Timestamp <= endDate)
                    .ToList();

                DataGridViewHelper.UpdateGrid(dataGridViewLogs, bindingSource, filteredLogs);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering logs by date range: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}