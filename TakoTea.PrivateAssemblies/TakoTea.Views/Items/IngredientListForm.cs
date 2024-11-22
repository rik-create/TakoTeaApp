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
using TakoTea.Interfaces;
namespace TakoTea.Views.Items
{
    public partial class IngredientListForm : MaterialForm
    {
        private readonly BatchRepository _batchRepo;
        private readonly DataAccessObject _dao;
        private readonly IngredientRepository ingredientRepository;
        public IngredientListForm()
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);
            _dao = new DataAccessObject();
            _batchRepo = new BatchRepository(_dao);
            ingredientRepository = new IngredientRepository(_dao);
            DataGridViewHelper.ApplyDefaultStyles(dataGridViewIngredients);

        }
        private void LoadData()
        {


            try
            {
                // Get the stock data
                var ingredients = ingredientRepository.GetAllIngredients();
                if (ingredients == null)
                {
                    DialogHelper.ShowError("Failed to load ingredients data.");
                    return;
                }


                bindingSource1.DataSource = ingredients;
                dataGridViewIngredients.DataSource = bindingSource1;
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
            DataGridViewHelper.AddButtonToLastRow(dataGridViewIngredients, "Edit", "Edit", HandleEditButtonClick, ThemeConfigurator.GetPrimaryColor(), ThemeConfigurator.GetTextColor());
            DataGridViewHelper.AddButtonToLastRow(dataGridViewIngredients, "View More", "View More", HandleViewMoreButtonClick, ThemeConfigurator.GetAccentColor(), ThemeConfigurator.GetTextColor());

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
