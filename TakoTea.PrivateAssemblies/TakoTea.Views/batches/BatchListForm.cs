using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Helpers;
using TakoTea.Models;
using TakoTea.Repository;
using TakoTea.Views.Batches;
using static TakoTea.Repository.BatchRepository;
namespace TakoTea.View.Batches
{
    public partial class BatchListForm : MaterialForm
    {
        private readonly BatchRepository _batchRepo;
        private readonly DataAccessObject _dao;
        public BatchListForm()
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);
            _dao = new DataAccessObject();
            _batchRepo = new BatchRepository(_dao);
            LoadData();
            DataGridViewHelper.ApplyDataGridViewStyles(dataGridViewBatch);
            DataGridViewHelper.HideColumn(dataGridViewBatch, "BatchID");
            DataGridViewHelper.HideColumn(dataGridViewBatch, "Active");
            DateHelper.InitializeDateTimePickers(dateTimePickerStartDate, dateTimePickerEndDate);

            btnClearFilters.Click += btnClearFilters_Click;

            DataGridViewHelper.FormatColumnHeaders(dataGridViewBatch);



            materialTextBox21.TextChanged += txtSearch_TextChanged;



        }
        private void LoadData()
        {


            DataGridViewHelper.LoadData(
             dataRetrievalFunc: () => _batchRepo.GetAllBatch(),
             dataGridView: dataGridViewBatch,
             bindingSource: bindingSource1,
             bindingNavigator: bindingNavigatorBatch,
             errorMessage: "Failed to load batch data."

         );

        }


        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            await Task.Delay(300);
            FilterBatch();
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

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            DateHelper.InitializeDateTimePickers(dateTimePickerStartDate, dateTimePickerEndDate);
/*            FilterPanelHelper.ResetFilters(dateTimePickerStartDate, dateTimePickerEndDate, "Ingredients", "Timestamp");
*/            CheckedListBoxHelper.ClearAllCheckedListBoxesInPanel(panelFilteringComponents);
            FilterBatch();
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
            DataGridViewHelper.DeleteSelectedRows<TakoTea.Models.Batch>(dataGridViewBatch, "BatchID");
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
                    int batchID = Convert.ToInt32(dataGridViewBatch.Rows[e.RowIndex].Cells["BatchID"].Value); // Assuming you have a "BatchID" column

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

        private void dataGridViewBatch_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewHelper.SortDataGridView(dataGridViewBatch, e.ColumnIndex);
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {

        }
        private void FilterBatch()
        {
            try
            {
                DateTime startDate = dateTimePickerStartDate.Value.Date;
                DateTime endDate = dateTimePickerEndDate.Value.Date.AddDays(1).AddTicks(-1); // End of the selected day
                string searchTerm = materialTextBox21.Text.Trim().ToLower(); // Get the search term

                List<BatchDTO> filteredBatches = _batchRepo.GetAllBatch()
                    .Where(batch =>
                        batch.ExpirationDate >= startDate &&
                        batch.ExpirationDate <= endDate &&
                        (
                            batch.BatchNumber.ToLower().Contains(searchTerm) ||
                            batch.IngredientName.ToLower().Contains(searchTerm)
                        )
                    )
                    .ToList();

                // Assuming you have a DataGridView named dataGridViewBatch and a BindingSource named bindingSource1
                DataGridViewHelper.UpdateGrid(dataGridViewBatch, bindingSource1, filteredBatches);
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show("Error filtering batches: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dateTimePickerEndDate_ValueChanged(object sender, EventArgs e)
        {
            DateHelper.ValidateDateRange(dateTimePickerStartDate, dateTimePickerEndDate, "End date must be after start date.", 1);

            FilterBatch();
        }

        private void dateTimePickerStartDate_ValueChanged(object sender, EventArgs e)
        {
            DateHelper.ValidateDateRange(dateTimePickerStartDate, dateTimePickerEndDate, "Start date must be before end date.", -1);

            FilterBatch();
        }

    }
}
