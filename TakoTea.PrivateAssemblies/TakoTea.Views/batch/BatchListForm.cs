using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Helpers;
using TakoTea.Repository;
using TakoTea.Views.Items.Item_Modals;
using TakoTea.Views.Batch.Batch_Modals;
namespace TakoTea.View.Batch
{
    public partial class BatchListForm : MaterialForm
    {
        private readonly BatchRepository _batchRepo;
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
            AddItemModal newBatchForm = new AddItemModal();
             newBatchForm.ShowDialog();
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
            DataGridViewHelper.AddButtonToLastRow(dataGridViewBatch, "Edit", "Edit", HandleEditButtonClick, ThemeConfigurator.GetPrimaryColor(), ThemeConfigurator.GetTextColor());
            DataGridViewHelper.AddButtonToLastRow(dataGridViewBatch, "View More", "View More", HandleViewMoreButtonClick, ThemeConfigurator.GetAccentColor(), ThemeConfigurator.GetTextColor());

        }


        private void HandleEditButtonClick(int rowIndex)
        {

        }

        private void HandleViewMoreButtonClick(int rowIndex)
        {

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
    }
}
