using MaterialSkin.Controls;
using System;
using System.Data;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.HELPERS;
using TakoTea.REPOSITORY;
using TakoTea.Views.Batch.Batch_Modals;

namespace TakoTea.View.Batch
{
    public partial class BatchListForm : MaterialForm
    {

        BatchRepository _batchRepo;
        public BatchListForm()
        {
            InitializeComponent();

            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);
            _batchRepo = new BatchRepository(new DataAccessObject());

            DataGridViewHelper.ApplyDefaultStyles(dataGridViewBatch);

        }

        private void LoadData()
        {
            try
            {
                // Get the stock data
                DataTable batchData = _batchRepo.GetAllActiveBatches();

                if (batchData == null)
                {
                    DialogHelper.ShowError("Failed to load batch data.");
                    return;
                }

                // Use the BindDataToGridView helper to bind data to DataGridView and refresh it
                DataGridViewHelper.BindDataToGridView(dataGridViewBatch, bindingSource1, batchData);
                DataGridViewHelper.BindNavigatorToBindingSource(bindingNavigatorBatch, bindingSource1);

            }
            catch (Exception ex)
            {
                DialogHelper.ShowError("Error loading data: " + ex.Message);
            }
        }




        private void btnShowFilter_Click(object sender, EventArgs e)
        {
            panelFilteringComponents.Visible = true;
            panelFilteringComponents.Enabled = true;
        }

        private void floatingActionButtonAddBatch_Click_1(object sender, EventArgs e)
        {
            NewBatchForm newBatchForm = new NewBatchForm();
            newBatchForm.ShowDialog();
        }

        private void buttonEditBatch_Click(object sender, EventArgs e)
        {
            EditBatchForm edit = new EditBatchForm("10023");
            edit.ShowDialog();
        }

        private void BatchListForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
