using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TakoTea.Helpers;
using TakoTea.Helpers.Validators;
using TakoTea.Repository;
using TakoTea.Services;
using TakoTea.Models;
using MaterialSkin.Controls;
using TakoTea.Interfaces;
using TakoTea.Views.DataLoaders.Modals;
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
                dateTimePickerExpiration.Value = DateTime.Now.AddMonths(6);
                
                
                var batch = new Batch
                {
                    BatchNumber = txtBoxBatchNumber.Text,
                    IngredientID = string.IsNullOrEmpty(lblIngredientId.Text)
                                  ? (int?)null
                                  : Convert.ToInt32(lblIngredientId.Text),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    StockLevel = numericUpDownQuantity.Value,
                    ExpirationDate = string.IsNullOrEmpty(dateTimePickerExpiration.Text)
                                     ? (DateTime?)null
                                     : dateTimePickerExpiration.Value,
                    IsActive = true,
                    BatchCost = numericUpDownCost.Value
                };
                batchService.AddBatch(batch);
                DialogHelper.ShowSuccess("Batch saved successfully.");
            }
            catch (Exception ex)
            {
                DialogHelper.ShowError($"Failed to save the batch. Error: {ex.Message}");
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
