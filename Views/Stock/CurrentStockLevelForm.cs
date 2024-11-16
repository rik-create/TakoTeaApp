using MaterialSkin.Controls;
using System;
using System.Data;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.HELPERS;
using TakoTea.Repository;
using TakoTea.View.Stock.Stock_Modal;

namespace TakoTea.View.Stock
{
    public partial class CurrentStockLevelForm : MaterialForm
    {
        private readonly IngredientRepository _ingredientRepository;
        private readonly BindingSource _bindingSource;

        public CurrentStockLevelForm(IngredientRepository ingredientRepository = null)
        {
            InitializeComponent();
            _ingredientRepository = ingredientRepository ?? new IngredientRepository();
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
            var selectedRow = dataGridViewStockLevels.Rows[rowIndex];
            int ingredientId = Convert.ToInt32(selectedRow.Cells["IngredientID"].Value); // Retrieve the hidden IngredientID
            string ingredientName = selectedRow.Cells["IngredientName"].Value.ToString();
            decimal quantityInStock = Convert.ToDecimal(selectedRow.Cells["QuantityInStock"].Value);
            string measuringUnit = selectedRow.Cells["MeasuringUnit"].Value.ToString();
            decimal reorderLevel = Convert.ToDecimal(selectedRow.Cells["ReorderLevel"].Value);

            // Open the EditStockModal with the selected data
            EditStockModal editStockModal = new EditStockModal(ingredientId, ingredientName, quantityInStock, measuringUnit, reorderLevel);
            editStockModal.ShowDialog();

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


    public class StockDetails
    {
        public string IngredientName { get; set; }
        public decimal CurrentQuantity { get; set; }
        public string MeasuringUnit { get; set; }
        public decimal ReorderLevel { get; set; }
    }

    public class StockLevelDto
    {
        public string IngredientName { get; set; }
        public decimal QuantityInStock { get; set; }
        public string MeasuringUnit { get; set; }
        public decimal ReorderLevel { get; set; }
    }





}
