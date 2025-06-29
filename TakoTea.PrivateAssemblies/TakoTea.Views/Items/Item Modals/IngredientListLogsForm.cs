﻿using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Helpers;
using TakoTea.Models;
using TakoTea.Repository;
using TakoTea.Services;
using TakoTea.View.Items.Item_Modals;
using TakoTea.Views.Batches;
namespace TakoTea.Views.Items
{
    public partial class IngredientListLogsForm : MaterialForm
    {
        private readonly BatchRepository _batchRepo;
        private readonly DataAccessObject _dao;
        private readonly IngredientRepository ingredientRepository;
        private readonly InventoryService _inventoryService;
        public IngredientListLogsForm()
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);
            _dao = new DataAccessObject();
            _batchRepo = new BatchRepository(_dao);
            ingredientRepository = new IngredientRepository(new Entities()); // Fix: Pass an instance of Entities
            DataGridViewHelper.ApplyDefaultStyles(dataGridViewIngredientsLogs);
            dataGridViewIngredientsLogs.CellClick += dataGridViewIngredients_CellClick;
            LoadData();
            DataGridViewHelper.ApplyDataGridViewStyles(dataGridViewIngredientsLogs);
            _inventoryService = new InventoryService();
            bindingNavigatorDeleteItem.Click += bindingNavigatorDeleteItem_Click;
            DataGridViewHelper.HideColumn(dataGridViewIngredientsLogs, "LogID");
            DataGridViewHelper.HideColumn(dataGridViewIngredientsLogs, "CreatedBy");
            DataGridViewHelper.HideColumn(dataGridViewIngredientsLogs, "CreatedAt");
            DataGridViewHelper.HideColumn(dataGridViewIngredientsLogs, "UpdatedAt");
            DataGridViewHelper.HideColumn(dataGridViewIngredientsLogs, "UpdatedBy");
            DataGridViewHelper.FormatColumnHeaders(dataGridViewIngredientsLogs);

        }
        private void FilterIngredientsLogs()
        {
            try
            {
                string searchTerm = txtBoxSearchLogs.Text.ToLower().Trim(); // Assuming you have a TextBox named "txtBoxSearchLogs"
                List<string> selectedColumnNames = chkListBoxColumnName.CheckedItems.Cast<string>().ToList();
                List<string> selectedActions = checkedListBoxAction.CheckedItems.Cast<string>().ToList();
                DateTime startDate = dateTimePickerStart.Value.Date;
                DateTime endDate = dateTimePickerEnd.Value.Date.AddDays(1); // Include the end date
                IEnumerable<Log> filteredLogs = LogChangesRepository.GetProductVariantChangeLogs()
                    .Where(log =>
                        log.Timestamp >= startDate && log.Timestamp < endDate &&
                        (string.IsNullOrWhiteSpace(searchTerm) ||
                         log.NewValue.ToLower().Contains(searchTerm) ||
                         log.OldValue.ToLower().Contains(searchTerm) ||
                         log.ColumnName.ToLower().Contains(searchTerm)) &&
                        (selectedColumnNames.Count == 0 || selectedColumnNames.Contains(log.ColumnName)) &&
                        (selectedActions.Count == 0 || selectedActions.Contains(log.Action))
                    );
                // Update the DataGridView (assuming you have one to display the logs)
                DataGridViewHelper.UpdateGrid(dataGridViewIngredientsLogs, bindingSource1, filteredLogs.ToList());
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show("Error filtering product variant logs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadData()
        {
            try
            {
                // Get the stock data
                List<Log> ingredients = LogChangesRepository.GetIngredientChangeLogs();
                if (ingredients == null)
                {
                    DialogHelper.ShowError("Failed to load ingredients data.");
                    return;
                }
                DataGridViewHelper.BindDataToGridView(dataGridViewIngredientsLogs, bindingSource1, ingredients);
                DataGridViewHelper.BindNavigatorToBindingSource(bindingNavigatorBatch, bindingSource1);
                /*                DataGridViewHelper.HideColumn(dataGridViewIngredients, "IngredientID");
                */
                LogChangesRepository.FillFilterLists("Ingredients", chkListBoxColumnName, checkedListBoxAction);
            }
            catch (Exception ex)
            {
                DialogHelper.ShowError("Error loading data: " + ex.Message);
            }
        }
        private void dataGridViewIngredients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewIngredientsLogs.Columns["CreateBatchButtonColumn"].Index && e.RowIndex >= 0)
            {
                // Get the IngredientID and IngredientName from the selected row
                int ingredientId = Convert.ToInt32(dataGridViewIngredientsLogs.Rows[e.RowIndex].Cells["IngredientID"].Value); // Assuming "IngredientID" is the column name
                string ingredientName = dataGridViewIngredientsLogs.Rows[e.RowIndex].Cells["IngredientName"].Value.ToString(); // Assuming "IngredientName" is the column name
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
            if (dataGridViewIngredientsLogs.SelectedRows.Count == 0)
            {
                _ = MessageBox.Show("Please select at least one row to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete the selected rows?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridViewIngredientsLogs.SelectedRows)
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
            DataGridViewHelper.AddButtonToLastRow(dataGridViewIngredientsLogs, "CreateBatchButtonColumn", "Create Batch", ThemeConfigurator.GetAccentColor(), ThemeConfigurator.GetTextColor());
        }
        private void HandleEditButtonClick(int rowIndex)
        {
            // Get the IngredientID from the selected row
            int ingredientId = Convert.ToInt32(dataGridViewIngredientsLogs.Rows[rowIndex].Cells["IngredientID"].Value);
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
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && !dataGridViewIngredientsLogs.Rows[e.RowIndex].IsNewRow)
            {
                try
                {
                    // Get the ProductVariantID from the selected row
                    int IngredientId = Convert.ToInt32(dataGridViewIngredientsLogs.Rows[e.RowIndex].Cells["IngredientID"].Value); // Assuming "ProductVariantID" is the column name
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
        private void dataGridViewIngredients_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewHelper.SortDataGridView(dataGridViewIngredientsLogs, e.ColumnIndex);
        }
        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            DateHelper.ValidateDateRange(dateTimePickerStart, dateTimePickerEnd, "Start date must be before end date.", -1);
            FilterIngredientsLogs();
        }
        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            DateHelper.ValidateDateRange(dateTimePickerStart, dateTimePickerEnd, "Start date must be before end date.", 1);
            FilterIngredientsLogs();
        }
        private void chkListBoxColumnName_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterIngredientsLogs();
        }
        private void checkedListBoxAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterIngredientsLogs();
        }
        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            DateHelper.InitializeDateTimePickers(dateTimePickerStart, dateTimePickerEnd);
            FilterPanelHelper.ResetFilters(dateTimePickerStart, dateTimePickerEnd, "Ingredients", "Timestamp");
            CheckedListBoxHelper.ClearAllCheckedListBoxesInPanel(panelFilteringComponents);
            FilterIngredientsLogs();
        }
    }
}
