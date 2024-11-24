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
using TakoTea.Views.Batches.Batch_Modals;
using TakoTea.Views.Batches;
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
            DataGridViewHelper.ApplyDefaultStyles(dataGridViewBatch);

        }
        private void LoadData()
        {


            DataGridViewHelper.LoadData(
             dataRetrievalFunc: () => _batchRepo.GetAllBatches(),
             dataGridView: dataGridViewBatch,
             bindingSource: bindingSource1,
             bindingNavigator: bindingNavigatorBatch,
             errorMessage: "Failed to load batch data."
         );
        }
        private void btnShowFilter_Click(object sender, EventArgs e)
        {
            panelFilteringComponents.Visible = true;
            panelFilteringComponents.Enabled = true;
        }
        private void floatingActionButtonAddBatch_Click_1(object sender, EventArgs e)
        {
            AddBatchModal newBatchForm = new AddBatchModal();
             newBatchForm.ShowDialog();
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
