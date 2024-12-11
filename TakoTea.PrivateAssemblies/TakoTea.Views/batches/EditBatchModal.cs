using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using TakoTea.Helpers;
using TakoTea.Interfaces;
using TakoTea.Models;
using TakoTea.Repository;
using TakoTea.Services;

namespace TakoTea.Views.Batches
{
    public partial class EditBatchModal : MaterialForm
    {
        private readonly IInventoryService _inventoryService;
        private readonly IngredientRepository _ingredientRepository;
        private readonly BatchService batchService;
        private readonly DataAccessObject _dao;
        private readonly Batch _existingBatch; // To hold the batch being edited

        public EditBatchModal(Batch batch)
        {
            InitializeComponent();
            _dao = new DataAccessObject();
            batchService = new BatchService();
            SetDecimalPlacesForAllNumericUpDowns(this, 1);

            _existingBatch = batch; // Assign the batch to be edited

            // Populate the form fields with the batch details
            txtBoxBatchNumber.Text = _existingBatch.BatchNumber;
            lblIngredientId.Text = _existingBatch.IngredientID.ToString();
            dateTimePickerExpiration.Value = _existingBatch.ExpirationDate ?? DateTime.Now;
            numericUpDownQuantity.Value = _existingBatch.StockLevel;
            numericUpDownCost.Value = _existingBatch.BatchCost;
        }

        private void SetDecimalPlacesForAllNumericUpDowns(Control parent, int decimalPlaces)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is NumericUpDown numericUpDown)
                {
                    numericUpDown.DecimalPlaces = decimalPlaces;
                    numericUpDown.Increment = 0.1m;
                }

                if (control.Controls.Count > 0)
                {
                    SetDecimalPlacesForAllNumericUpDowns(control, decimalPlaces);
                }
            }
        }

        private void btnConfirmEdit_Click(object sender, EventArgs e)
        {
            try
            {
                // Update the existing batch object with the new values
                _existingBatch.BatchNumber = txtBoxBatchNumber.Text;
                _existingBatch.IngredientID = string.IsNullOrEmpty(lblIngredientId.Text)
                                              ? (int?)null
                                              : Convert.ToInt32(lblIngredientId.Text);
                _existingBatch.UpdatedAt = DateTime.Now;
                _existingBatch.StockLevel = numericUpDownQuantity.Value;
                _existingBatch.ExpirationDate = string.IsNullOrEmpty(dateTimePickerExpiration.Text)
                                                 ? (DateTime?)null
                                                 : dateTimePickerExpiration.Value;
                _existingBatch.BatchCost = numericUpDownCost.Value;


                string changeDescription = DialogHelper.ShowInputDialog(
                                formTitle: "Enter Change Description",
                                labelText: "Change Description:",
                                validationMessage: "Description cannot be empty.",
                                validateInput: input => !string.IsNullOrWhiteSpace(input)
                            );
                if (txtBoxBatchNumber.Text != _existingBatch.BatchNumber)
                {
                    LoggingHelper.LogChange(
                        "Batch",
                        _existingBatch.BatchID,
                        "BatchNumber",
                        _existingBatch.BatchNumber,
                        txtBoxBatchNumber.Text,
                        "Updated",
                        $"Batch number changed from '{_existingBatch.BatchNumber}' to '{txtBoxBatchNumber.Text}'", changeDescription
                    );
                }
                if (lblIngredientId.Text != _existingBatch.IngredientID.ToString())
                {
                    LoggingHelper.LogChange(
                        "Batch",
                        _existingBatch.BatchID,
                        "IngredientID",
                        _existingBatch.IngredientID.ToString(),
                        lblIngredientId.Text,
                        "Updated",
                        $"Ingredient ID changed from '{_existingBatch.IngredientID}' to '{lblIngredientId.Text}'", changeDescription
                    );
                }
                if (numericUpDownQuantity.Value != _existingBatch.StockLevel)
                {
                    LoggingHelper.LogChange(
                        "Batch",
                        _existingBatch.BatchID,
                        "StockLevel",
                        _existingBatch.StockLevel.ToString(),
                        numericUpDownQuantity.Value.ToString(),
                        "Updated",
                        $"Stock level changed from '{_existingBatch.StockLevel}' to '{numericUpDownQuantity.Value}'", changeDescription
                    );
                }
                if (dateTimePickerExpiration.Value != _existingBatch.ExpirationDate)
                {
                    LoggingHelper.LogChange(
                        "Batch",
                        _existingBatch.BatchID,
                        "ExpirationDate",
                        _existingBatch.ExpirationDate.ToString(),
                        dateTimePickerExpiration.Value.ToString(),
                        "Updated",
                        $"Expiration date changed from '{_existingBatch.ExpirationDate}' to '{dateTimePickerExpiration.Value}'", changeDescription
                    );
                }
                if (numericUpDownCost.Value != _existingBatch.BatchCost)
                {
                    LoggingHelper.LogChange(
                        "Batch",
                        _existingBatch.BatchID,
                        "BatchCost",
                        _existingBatch.BatchCost.ToString(),
                        numericUpDownCost.Value.ToString(),
                        "Updated",
                        $"Batch cost changed from '{_existingBatch.BatchCost}' to '{numericUpDownCost.Value}'", changeDescription
                    );
                }

                batchService.Update(_existingBatch); // Assuming you have an UpdateBatch method
                DialogHelper.ShowSuccess("Batch updated successfully.");


                (new ProductsService(new Entities())).UpdateAllProductVariantStockLevels();

                this.Close();
            }
            catch (Exception ex)
            {
                DialogHelper.ShowError($"Failed to update the batch. Error: {ex.Message}");
            }
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(
                  "Are you sure you want to cancel? Any unsaved changes will be lost.",
                  "Confirm Cancel",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Warning
              );

            if (dialogResult == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}