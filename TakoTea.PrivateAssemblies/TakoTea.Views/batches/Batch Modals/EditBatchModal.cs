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
    public partial class EditBatchModal : MaterialForm
    {
        private readonly IInventoryService _inventoryService;
        private readonly IngredientRepository _ingredientRepository;
        private readonly BatchRepository _batchRepository;
        private readonly DataAccessObject _dao;

        private readonly int _batchId;

        public EditBatchModal(int batchId)
        {
            InitializeComponent();
            _dao = new DataAccessObject();
            _ingredientRepository = new IngredientRepository(new Entities()); // Fix: Pass an instance of Entities

            _batchId = batchId;
        }



        private void EditBatchModal_Load(object sender, EventArgs e)
        {
            var dataLoader = ModalDataLoaderFactory.GetDataLoader(this, _batchId);
            dataLoader.LoadData(this);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            var dataLoader = ModalDataLoaderFactory.GetDataLoader(this, _batchId);
            dataLoader.ResetData(this); // Reset the form to original values
        }




        private void btnConfirmEdit_Click(object sender, EventArgs e)
        {
            // Collect updated values from form controls
            int IngredientID = _ingredientRepository.GetIngredientIdUsingBatch(_batchId);
            string IngredientName = _ingredientRepository.GetIngredientName(IngredientID);
            string newBatchNumber = txtBoxBatchNumber.Text;
            
            decimal newQuantity = numericUpDownQuantity.Value;
            string newMeasuringUnit = cmbBoxMeasuringUnit.SelectedItem.ToString();
            decimal newCost = numericUpDownCost.Value;
            decimal newLowLevel = numericUpDownLowLevel.Value;
            DateTime newExpiration = dateTimePickerExpiration.Value;

            bool newIsActive = true;


            // Collect IngredientModel Functions and Allergens
   

            // Validate form input
            if (string.IsNullOrEmpty(newBatchNumber) || newCost <= 0 || newLowLevel <= 0)
            {
                DialogHelper.ShowError("Please fill in all required fields.");
                return;
            }

            if (!DialogHelper.ShowConfirmation("Are you sure you want to save the batch?"))
            {
                return;
            }

            // Create the updated BatchModel
            BatchModel newBatch = new BatchModel(
                _batchId, IngredientID, newBatchNumber,
                newQuantity, newMeasuringUnit,
                newCost,
                newLowLevel,
                newExpiration,
                newIsActive

            );

            try
            {
                _batchRepository.SaveBatch(newBatch);
                DialogHelper.ShowSuccess("Batch saved successfully!");
                DialogResult = DialogResult.OK;
                Close();    
            }
            catch (Exception ex)
            {
                DialogHelper.ShowError($"Failed to save the batch. Error: {ex.Message}");
            }
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            // Confirm cancel action
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
