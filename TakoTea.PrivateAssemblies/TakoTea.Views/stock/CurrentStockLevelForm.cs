using MaterialSkin.Controls;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Helpers;
using TakoTea.Models;
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

            _ingredientRepository = ingredientRepository ?? new IngredientRepository(new Models.Entities());
            _bindingSource = new BindingSource();
            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);
            DataGridViewHelper.ApplyDataGridViewStyles(dataGridViewStockLevels);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadData();
            DataGridViewHelper.AddButtonToLastRow(dataGridViewStockLevels, "ActionButton", "Edit", HandleButtonClick);
        }
        private void LoadData()
        {
            // Retrieve both Product and ProductVariant data
            var productVariantsWithProductName = _ingredientRepository.GetAllIngredients()
                .Join(_ingredientRepository.GetAllBatch(),
                    i => i.IngredientID,        // Key from ProductVariant
                    b => b.IngredientID,          // Key from Product
                    (i, b) => new
                    {
                        b.BatchID,
                        i.IngredientName,         // Product name from Product table
                        i.StockLevel,
                        i.LowLevel
                      
                    })
                .ToList();  // Execute and retrieve the data

            // Bind the data to the DataGridView
            DataGridViewHelper.LoadData(
                dataRetrievalFunc: () => productVariantsWithProductName,
                dataGridView: dataGridViewStockLevels,
                bindingSource: _bindingSource,
                bindingNavigator: bindingNavigatorStockLevels,
                errorMessage: "Failed to load product variants."
            );

            DataGridViewHelper.HideColumn(dataGridViewStockLevels, "BatchID");

        
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

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DataGridViewHelper.DeleteSelectedRows<Ingredient>(dataGridViewStockLevels, "IngredientID");

        }
    }

}
