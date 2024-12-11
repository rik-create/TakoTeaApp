using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Helpers;
using TakoTea.Models;
using TakoTea.Repository;
using TakoTea.Views.Batches;
namespace TakoTea.View.Batches
{
    public partial class BatchListLogsForm : MaterialForm
    {
        private readonly BatchRepository _batchRepo;
        private readonly DataAccessObject _dao;
        public BatchListLogsForm()
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);
            _dao = new DataAccessObject();
            _batchRepo = new BatchRepository(_dao);
            LoadData();
            DataGridViewHelper.ApplyDataGridViewStyles(dataGridViewBatchLogs);
            DataGridViewHelper.HideColumn(dataGridViewBatchLogs, "LogID");
            DataGridViewHelper.HideColumn(dataGridViewBatchLogs, "CreatedBy");
            DataGridViewHelper.HideColumn(dataGridViewBatchLogs, "CreatedAt");
            DataGridViewHelper.HideColumn(dataGridViewBatchLogs, "UpdatedAt");
            DataGridViewHelper.HideColumn(dataGridViewBatchLogs, "UpdatedBy");
            DataGridViewHelper.FormatColumnHeaders(dataGridViewBatchLogs);

        }
        private void LoadData()
        {
            DataGridViewHelper.LoadData(
             dataRetrievalFunc: () => LogChangesRepository.GetBatchChangeLogs(),
             dataGridView: dataGridViewBatchLogs,
             bindingSource: bindingSource1,
             bindingNavigator: bindingNavigatorBatch,
             errorMessage: "Failed to load batch data."
         );
            LogChangesRepository.FillFilterLists("Batch", chkListBoxColumnName, checkedListBoxAction);
        }
        private void FilterBatchLogs()
        {
            try
            {
                string searchTerm = txtBoxSearchLogs.Text.ToLower().Trim(); // Assuming you have a TextBox named "txtBoxSearchLogs"
                List<string> selectedColumnNames = chkListBoxColumnName.CheckedItems.Cast<string>().ToList();
                List<string> selectedActions = checkedListBoxAction.CheckedItems.Cast<string>().ToList();
                DateTime startDate = dateTimePickerStart.Value.Date;
                DateTime endDate = dateTimePickerEnd.Value.Date.AddDays(1); // Include the end date
                IEnumerable<Log> filteredLogs = LogChangesRepository.GetProductVariantChangeLogs()
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
                DataGridViewHelper.UpdateGrid(dataGridViewBatchLogs, bindingSource1, filteredLogs.ToList());
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show("Error filtering product variant logs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnShowFilter_Click(object sender, EventArgs e)
        {
            panelFilteringComponents.Visible = true;
            panelFilteringComponents.Enabled = true;
        }
        private void floatingActionButtonAddBatch_Click_1(object sender, EventArgs e)
        {
            AddBatchModal newBatchForm = new AddBatchModal();
            _ = newBatchForm.ShowDialog();
            LoadData();
        }
        private void buttonEditBatch_Click(object sender, EventArgs e)
        {
        }
        private void BatchListForm_Load(object sender, EventArgs e)
        {
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadData();
        }
        private void panelFilteringComponents_Paint(object sender, PaintEventArgs e)
        {
        }
        private void pictureBoxExportPdf_Click(object sender, EventArgs e)
        {
        }
        private void btnHideFilters_Click(object sender, EventArgs e)
        {
            FilterPanelHelper.ToggleFilterPanel(panelFilteringComponents, btnHideFilters, pBoxShowFilter, false);
        }
        private void pBoxShowFilter_Click(object sender, EventArgs e)
        {
            FilterPanelHelper.ToggleFilterPanel(panelFilteringComponents, btnHideFilters, pBoxShowFilter, true);
        }
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DataGridViewHelper.DeleteSelectedRows<TakoTea.Models.Batch>(dataGridViewBatchLogs, "BatchID");
            LoadData();
        }
        private void dataGridViewBatch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Check if a valid row is double-clicked (not the header row)
            if (e.RowIndex >= 0)
            {
                try
                {
                    // 2. Get the BatchID from the selected row
                    int batchID = Convert.ToInt32(dataGridViewBatchLogs.Rows[e.RowIndex].Cells["BatchID"].Value); // Assuming you have a "BatchID" column
                    // 3. Retrieve the Batch object using your BatchService
                    Batch selectedBatch = _batchRepo.GetBatchByBatchId(batchID); // You'll need to implement this method
                    // 4. Open the EditBatchModal with the selected batch
                    if (selectedBatch != null)
                    {
                        using (EditBatchModal editBatchModal = new EditBatchModal(selectedBatch))
                        {
                            _ = editBatchModal.ShowDialog();
                            // 5. Refresh the DataGridView after editing (optional)
                            LoadData(); // Assuming you have a method to load batch data into the DataGridView
                        }
                    }
                    else
                    {
                        DialogHelper.ShowError("Batch not found.");
                    }
                }
                catch (Exception ex)
                {
                    DialogHelper.ShowError($"An error occurred: {ex.Message}");
                }
            }
        }
        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            DateHelper.ValidateDateRange(dateTimePickerStart, dateTimePickerEnd, "Start date must be before end date.", -1);
            FilterBatchLogs();
        }
        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            DateHelper.ValidateDateRange(dateTimePickerStart, dateTimePickerEnd, "Start date must be before end date.", 1);
            FilterBatchLogs();
        }
        private void chkListBoxColumnName_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterBatchLogs();
        }
        private void checkedListBoxAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterBatchLogs();
        }
        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            DateHelper.InitializeDateTimePickers(dateTimePickerStart, dateTimePickerEnd);
            FilterPanelHelper.ResetFilters(dateTimePickerStart, dateTimePickerEnd, "Batch", "Timestamp");
            CheckedListBoxHelper.ClearAllCheckedListBoxesInPanel(panelFilteringComponents);
            FilterBatchLogs();
        }
    }
}
