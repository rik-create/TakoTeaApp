using MaterialSkin.Controls;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Controller.Factory;
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
            DataTable stockData = _ingredientRepository.GetCurrentStockLevels();

            if (stockData == null)
            {
                MessageBox.Show("Failed to load stock data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _bindingSource.DataSource = stockData;
            dataGridViewStockLevels.DataSource = _bindingSource;
            bindingNavigatorStockLevels.BindingSource = _bindingSource;
        }


        private void HandleButtonClick(int rowIndex)
        {
            // Get the data from the selected row
            var selectedRow = dataGridViewStockLevels.Rows[rowIndex];
            string ingredientName = selectedRow.Cells["IngredientName"].Value.ToString();
            decimal quantityInStock = Convert.ToDecimal(selectedRow.Cells["QuantityInStock"].Value);
            string measuringUnit = selectedRow.Cells["MeasuringUnit"].Value.ToString();
            decimal reorderLevel = Convert.ToDecimal(selectedRow.Cells["ReorderLevel"].Value);

            // Open the EditStockModal with the selected data
            EditStockModal editStockModal = new EditStockModal(ingredientName, quantityInStock, measuringUnit, reorderLevel);
            editStockModal.ShowDialog();
        }


        private void InitializeGrid()
        {
          
        }

        private void ShowEditModal(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dataGridViewStockLevels.Rows.Count)
            {
                MessageBox.Show("Invalid row index.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Retrieve the stock level details and create a StockDetails object
            var stockLevel = _bindingSource[rowIndex] as StockDetails;
            if (stockLevel == null)
            {
                MessageBox.Show("Failed to retrieve stock level data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var stockDetails = new StockDetails
            {
                IngredientName = stockLevel.IngredientName,
                CurrentQuantity = stockLevel.CurrentQuantity,
                MeasuringUnit = stockLevel.MeasuringUnit,
                ReorderLevel = stockLevel.ReorderLevel
            };

            // Use ModalFactory to create the modal
            using (var editStockModal = ModalFactory.CreateEditStockModal(stockDetails))
            {
                editStockModal.ShowDialog();
                LoadData();
            }
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
            ShowEditModal(dataGridViewStockLevels.CurrentRow?.Index ?? -1);
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
