﻿using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Helpers;
using TakoTea.Models;
using TakoTea.Repository;
using TakoTea.Services;
using TakoTea.View.Items.Item_Modals;
using TakoTea.Views.Batches;
using static TakoTea.Repository.IngredientRepository;
namespace TakoTea.Views.Items
{
    public partial class IngredientListForm : MaterialForm
    {
        private readonly BatchRepository _batchRepo;
        private readonly DataAccessObject _dao;
        private readonly IngredientRepository ingredientRepository;
        private readonly InventoryService _inventoryService;
        public IngredientListForm()
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);
            _dao = new DataAccessObject();
            _batchRepo = new BatchRepository(_dao);
            ingredientRepository = new IngredientRepository(new Entities()); // Fix: Pass an instance of Entities
            dataGridViewIngredients.CellClick += dataGridViewIngredients_CellClick;
            _inventoryService = new InventoryService();
            bindingNavigatorDeleteItem.Click += bindingNavigatorDeleteItem_Click;
            InitializeDgs();
        }
        private void InitializeDgs()
        {
            DataGridViewHelper.ApplyDefaultStyles(dataGridViewIngredients);
            LoadData();
            DataGridViewHelper.ApplyDataGridViewStyles(dataGridViewIngredients);
            DataGridViewHelper.FormatColumnHeaders(dataGridViewIngredients);
            Image processIcon = imageListButton.Images["reorder.png"]; // Access image by   
            DataGridViewHelper.AddIconButtonColumn(dataGridViewIngredients, "CreateBatchButtonColumn", "Create Batch", processIcon);
        }
        private void FilterIngredients()
        {
            try
            {
                string searchTerm = textBoxSearchIngredients.Text.ToLower().Trim(); // Assuming you have a TextBox named "txtBoxSearchForIngredient"
                bool isAddOnChecked = checkBoxIsAddOn.Checked; // Assuming you have a CheckBox named "checkBoxIsAddOn"
                IEnumerable<IngredientDto> filteredIngredients = ingredientRepository.GetAllIngredient()
                    .Where(ingredient =>
                        string.IsNullOrWhiteSpace(searchTerm) ||
                         ((dynamic)ingredient).IngredientName.ToLower().Contains(searchTerm) ||
                         ((dynamic)ingredient).BrandName.ToLower().Contains(searchTerm));
                List<int> checkedStockLevels = checkedListBoxStockLevel.CheckedIndices.Cast<int>().ToList();
                if (checkedStockLevels.Count > 0)
                {
                    filteredIngredients = filteredIngredients.Where(ingredient =>
                        checkedStockLevels.Any(index =>
                            (index == 0 && ingredient.StockLevel > 0) || // In Stock
                            (index == 1 && ingredient.StockLevel < ingredient.LowLevel) || // Low Stock
                            (index == 2 && ingredient.StockLevel == 0)));  // Out of Stock
                }
                filteredIngredients = filteredIngredients.Where(ingredient =>
                    !isAddOnChecked || // If not checked, include all ingredients
                    ((dynamic)ingredient).AddOn == "Yes" == isAddOnChecked);
                // Assuming you have a DataGridView named "dataGridViewIngredients" and a BindingSource named "bindingSourceIngredients"
                DataGridViewHelper.UpdateGrid(dataGridViewIngredients, bindingSource1, filteredIngredients.ToList());
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show("Error filtering ingredients: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadData()
        {
            try
            {
                // Get the stock data
                List<IngredientDto> ingredients = ingredientRepository.GetAllIngredient();
                if (ingredients == null)
                {
                    DialogHelper.ShowError("Failed to load ingredients data.");
                    return;
                }
                DataGridViewHelper.BindDataToGridView(dataGridViewIngredients, bindingSource1, ingredients);
                DataGridViewHelper.BindNavigatorToBindingSource(bindingNavigatorBatch, bindingSource1);
                /*                DataGridViewHelper.HideColumn(dataGridViewIngredients, "IngredientID");
                */
            }
            catch (Exception ex)
            {
                DialogHelper.ShowError("Error loading data: " + ex.Message);
            }
        }
        private void dataGridViewIngredients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewIngredients.Columns["CreateBatchButtonColumn"].Index && e.RowIndex >= 0)
            {
                // Get the IngredientID and IngredientName from the selected row
                int ingredientId = Convert.ToInt32(dataGridViewIngredients.Rows[e.RowIndex].Cells["IngredientID"].Value); // Assuming "IngredientID" is the column name
                string ingredientName = dataGridViewIngredients.Rows[e.RowIndex].Cells["IngredientName"].Value.ToString(); // Assuming "IngredientName" is the column name
                string measuringUnit = ingredientRepository.GetAllIngredients().Find(x => x.IngredientID == ingredientId).MeasuringUnit;
                // Create and show the AddBatchModal
                AddBatchModal addBatchModal = new AddBatchModal();
                addBatchModal.lblIngredientId.Text = ingredientId.ToString();
                addBatchModal.txtBoxIngredientName.Text = ingredientName;
                addBatchModal.lblQuantity.Text = $"Quantity in {measuringUnit}"; // Set the label text
                _ = addBatchModal.ShowDialog();
                LoadData();
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
            _ = newBatchForm.ShowDialog();
            LoadData();
        }
        private void buttonEditBatch_Click(object sender, EventArgs e)
        {
        }
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewIngredients.SelectedRows.Count == 0)
            {
                _ = MessageBox.Show("Please select at least one row to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete the selected rows?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridViewIngredients.SelectedRows)
                {
                    int ingredientId = Convert.ToInt32(row.Cells["IngredientID"].Value);
                    // Delete the ingredient from the database
                    _inventoryService.DeleteIngredient(ingredientId);
                }
                // Refresh the DataGridView
                LoadData();
            }
        }
        private void BatchListForm_Load(object sender, EventArgs e)
        {
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadData();
        }
        private void HandleEditButtonClick(int rowIndex)
        {
            // Get the IngredientID from the selected row
            int ingredientId = Convert.ToInt32(dataGridViewIngredients.Rows[rowIndex].Cells["IngredientID"].Value);
            // Create and show the EditIngredientModal
            EditIngredientModal editIngredientModal = new EditIngredientModal(ingredientId); // Assuming EditIngredientModal has a constructor that takes the IngredientID
            _ = editIngredientModal.ShowDialog();
            LoadData();
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
        private void pbImportIngredients_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV Files|*.csv"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _inventoryService.ImportIngredientsFromCsv(openFileDialog.FileName);
                    _ = MessageBox.Show("Ingredients imported successfully.");
                    LoadData();
                    // Refresh the DataGridView or other UI elements as needed
                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show($"Error importing ingredients: {ex.Message}");
                }
            }
        }
        private void pictureBoxExportCsvIngredients_Click(object sender, EventArgs e)
        {
        }
        private void pictureBoxExportAll_Click(object sender, EventArgs e)
        {
            ExportHelper.ExportToCsv<Ingredient>();
        }
        private void btnExportSelectedItems_Click(object sender, EventArgs e)
        {
        }
        private void dataGridViewIngredients_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void dataGridViewIngredients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && !dataGridViewIngredients.Rows[e.RowIndex].IsNewRow)
            {
                try
                {
                    // Get the ProductVariantID from the selected row
                    int IngredientId = Convert.ToInt32(dataGridViewIngredients.Rows[e.RowIndex].Cells["IngredientID"].Value); // Assuming "ProductVariantID" is the column name
                    // Create and show the EditProductVariantModal
                    EditIngredientModal editIngredientModal = new EditIngredientModal(IngredientId);
                    _ = editIngredientModal.ShowDialog();
                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show("Error opening the edit modal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void materialRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void checkedListBoxStockLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterIngredients();
        }
        private void dataGridViewIngredients_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewHelper.SortDataGridView(dataGridViewIngredients, e.ColumnIndex);
        }
        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            CheckedListBoxHelper.ClearAllCheckedListBoxesInPanel(panelFilteringComponents);
            FilterIngredients();
        }
        private void checkBoxIsAddOn_CheckedChanged(object sender, EventArgs e)
        {
            FilterIngredients();
        }
        private void materialLabel2_Click(object sender, EventArgs e)
        {
        }
        private async void textBoxSearchIngredients_Click(object sender, EventArgs e)
        {
            await Task.Delay(300);
            FilterIngredients();
        }
    }
}
