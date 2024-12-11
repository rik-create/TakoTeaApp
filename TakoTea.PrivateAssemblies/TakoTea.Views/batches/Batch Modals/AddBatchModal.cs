using Helpers;
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
    public partial class AddBatchModal : MaterialForm
    {
        private readonly IInventoryService _inventoryService;
        private readonly IngredientRepository _ingredientRepository;
        private readonly BatchService batchService;
        private readonly DataAccessObject _dao;
        private readonly Entities context;

        public AddBatchModal()
        {
            InitializeComponent();
            _dao = new DataAccessObject();
            context = new Entities();
            _ingredientRepository = new IngredientRepository(context);
            batchService = new BatchService();
            SetDecimalPlacesForAllNumericUpDowns(this, 1);
            StartPosition = FormStartPosition.CenterParent;


        }


        private void SetDecimalPlacesForAllNumericUpDowns(Control parent, int decimalPlaces)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is NumericUpDown numericUpDown)
                {
                    numericUpDown.DecimalPlaces = decimalPlaces;  // Set DecimalPlaces
                    numericUpDown.Increment = 0.1m;                // Set increment to 0.1 (decimal)
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
                // Validate inputs
                if (string.IsNullOrEmpty(txtBoxBatchNumber.Text))
                {
                    DialogHelper.ShowError("Batch number cannot be empty.");
                    return;
                }

                if (string.IsNullOrEmpty(lblIngredientId.Text) || !int.TryParse(lblIngredientId.Text, out int ingredientId))
                {
                    DialogHelper.ShowError("Invalid ingredient ID.");
                    return;
                }

                if (numericUpDownQuantity.Value <= 0)
                {
                    DialogHelper.ShowError("Quantity must be greater than zero.");
                    return;
                }

                if (numericUpDownCost.Value <= 0)
                {
                    DialogHelper.ShowError("Cost must be greater than zero.");
                    return;
                }

                if (string.IsNullOrEmpty(dateTimePickerExpiration.Text))
                {
                    DialogHelper.ShowError("Expiration date cannot be empty.");
                    return;
                }

                // Set expiration date to 6 months from now if not set
                dateTimePickerExpiration.Value = DateTime.Now.AddMonths(6);

                Batch batch = new Batch
                {
                    BatchNumber = txtBoxBatchNumber.Text,
                    IngredientID = string.IsNullOrEmpty(lblIngredientId.Text)
                                  ? (int?)null
                                  : Convert.ToInt32(lblIngredientId.Text),
                    CreatedAt = DateTime.Now,
                    CreatedBy = AuthenticationHelper._loggedInUsername,
                    UpdatedAt = DateTime.Now,
                    StockLevel = numericUpDownQuantity.Value,
                    ExpirationDate = string.IsNullOrEmpty(dateTimePickerExpiration.Text)
                                     ? (DateTime?)null
                                     : dateTimePickerExpiration.Value,
                    IsActive = true,
                    BatchCost = numericUpDownCost.Value,
                    InitialStockLevel = numericUpDownQuantity.Value
                };

                batchService.AddBatch(batch);

                LoggingHelper.LogChange(
                    "Batch",                // Table name
                    batch.BatchID,            // Record ID (assuming BatchID is auto-generated)
                    "New Batch",              // Column name (or any descriptive text)
                    null,                     // Old value (null for new batch)
                    numericUpDownQuantity.Value.ToString(),         // New value (you might need to override ToString() in your Batch class for a more descriptive log)
                    "Added",                  // Action
                    $"Batch '{batch.BatchNumber}' added for ingredient '{batch.IngredientID}'", "" // Description
                );

                DialogHelper.ShowSuccess("Batch saved successfully.");
                Close();
            }
            catch (Exception ex)
            {
                DialogHelper.ShowError($"Failed to save the batch. Error: {ex.Message}");
            }
            Close();
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
