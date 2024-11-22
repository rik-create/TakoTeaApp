using MaterialSkin.Controls;
using System;
using System.Data;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Helpers;
using TakoTea.Repository;
using TakoTea.View.Stock.Stock_Modal;
using TakoTea.Views.Stock.Stock_Modal;
namespace TakoTea.Views.Stock
{
    public partial class CurrentStockLevelForm : MaterialForm
    {
        private readonly IngredientRepository _ingredientRepository;
        private readonly BindingSource _bindingSource;

        private readonly DataAccessObject _dao;

        public CurrentStockLevelForm(IngredientRepository ingredientRepository = null)
        {
            InitializeComponent();
            _dao = new DataAccessObject();

            _ingredientRepository = ingredientRepository ?? new IngredientRepository(_dao);
            _bindingSource = new BindingSource();
            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadData();
            DataGridViewHelper.AddButtonToLastRow(dataGridViewStockLevels, "ActionButton", "Edit", HandleButtonClick);
        }
        private void LoadData()
        {
            try
            {
                // Get the stock data
                DataTable stockData = _ingredientRepository.GetCurrentStockLevels();
                if (stockData == null)
                {
                    DialogHelper.ShowError("Failed to load stock data.");
                    return;
                }
                // Use the BindDataToGridView helper to bind data to DataGridView and refresh it
                DataGridViewHelper.BindDataToGridView(dataGridViewStockLevels, _bindingSource, stockData);
                DataGridViewHelper.BindNavigatorToBindingSource(bindingNavigatorStockLevels, _bindingSource);
            }
            catch (Exception ex)
            {
                DialogHelper.ShowError("Error loading data: " + ex.Message);
            }
        }
        private void HandleButtonClick(int rowIndex)
        {
            // Get the data from the selected row
            DataGridViewRow selectedRow = dataGridViewStockLevels.Rows[rowIndex];
            int batchID = Convert.ToInt32(selectedRow.Cells["BatchID"].Value); // Retrieve the hidden IngredientID

            // Open the EditStockModal with the selected data
            EditStockModal editStockModal = new EditStockModal(batchID, _dao);
            _ = editStockModal.ShowDialog();
            LoadData();
        }
        private void btnHideFilters_Click(object sender, EventArgs e)
        {
            FilterPanelHelper.ToggleFilterPanel(panelFilteringComponents, btnHideFilters, pBoxShowFilter, false);
        }
        private void pBoxShowFilter_Click(object sender, EventArgs e)
        {
            FilterPanelHelper.ToggleFilterPanel(panelFilteringComponents, btnHideFilters, pBoxShowFilter, true);
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }
    }

}
