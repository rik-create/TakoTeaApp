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

namespace TakoTea.Views.Batch
{
    public partial class EditBatchModal : MaterialForm
    {
        private readonly IInventoryService _inventoryService;
        private readonly IngredientRepository _ingredientRepository;
        private readonly BatchRepository _batchRepository;
        private readonly DataAccessObject _dao;

        public int BatchID { get; }
        public int IngredientID { get; }
        public string BatchNumber { get; }
        public decimal Quantity { get; }

        public string MeasuringUnit { get; }

        public string IngredientName { get; }
        public decimal Cost { get; }
        public decimal LowLevel { get; }
        public DateTime Expiration { get; }
        public string ItemDescription { get; }
        public string IngredientType { get; }
        public string BrandName { get; }
        public string Vendor { get; }
        public string StorageCondition { get; }
        public string IngredientImage { get; }
        public List<string> IngredientFunctions { get; }
        public List<string> Allergens { get; }

        // Track original values
        private string originalIngredientType;
        private List<string> originalIngredientFunctions;
        private List<string> originalAllergens;

        public EditBatchModal(int batchId, int ingredientId, string batchNumber, decimal quantity, string measuringUnit,string ingredientName, decimal cost, decimal lowLevel, DateTime expiration, string itemDescription, string ingredientType, string brandName, string vendor, string storageCondition, string ingredientImage, List<string> ingredientFunctions, List<string> allergens)
        {
            InitializeComponent();
            _dao = new DataAccessObject();
            _inventoryService = new InventoryService();
            _ingredientRepository = new IngredientRepository();
            _batchRepository = new BatchRepository(_dao);

            BatchID = batchId;
            IngredientID = ingredientId;
            BatchNumber = batchNumber;
            Quantity = quantity;
            MeasuringUnit = measuringUnit;
            IngredientName = ingredientName;
            Cost = cost;
            LowLevel = lowLevel;
            Expiration = expiration;
            ItemDescription = itemDescription;
            IngredientType = ingredientType;
            BrandName = brandName;
            Vendor = vendor;
            StorageCondition = storageCondition;
            IngredientImage = ingredientImage;
            IngredientFunctions = ingredientFunctions;
            Allergens = allergens;
        }

        private void EditBatchModal_Load(object sender, EventArgs e)
        {
            txtBoxBatchNumber.Text = BatchNumber;
            txtBoxName.Text = IngredientName;
            numericUpDownQuantity.Value = Quantity;
            numericUpDownCost.Value = Cost;
            numericUpDownLowLevel.Value = LowLevel;
            dateTimePickerExpiration.Value = Expiration;
            txtBoxItemDescription.Text = ItemDescription;
            txtBoxBrandName.Text = BrandName;
            txtBoxVendor.Text = Vendor;
            cmbboxStorageCondition.SelectedItem = StorageCondition;
            pictureBoxImg.ImageLocation = IngredientImage;

            cmbTypeOfIngredient.SelectedItem = IngredientType;

            // Save original values
            originalIngredientType = IngredientType;
            originalIngredientFunctions = new List<string>(IngredientFunctions);
            originalAllergens = new List<string>(Allergens);

            // Load Ingredient Functions into CheckedListBox
            chkListBoxIngredientFunction.Items.Clear();
            foreach (var function in IngredientFunctions)
            {
                chkListBoxIngredientFunction.Items.Add(function);
            }

            // Load Allergens into CheckedListBox
            materialCheckedListBoxAllergens.Items.Clear();
            foreach (var allergen in Allergens)
            {
                materialCheckedListBoxAllergens.Items.Add(allergen);
            }
        }

        private void pbDescReset_Click(object sender, EventArgs e)
        {
            // Reset the Item Description to its original value
            txtBoxItemDescription.Text = ItemDescription;
        }

        private void pbQuantityReset_Click(object sender, EventArgs e)
        {
            // Reset the Quantity to its original value
            numericUpDownQuantity.Value = Quantity;
        }

        private void pbIngredientNameReset_Click(object sender, EventArgs e)
        {
            // Reset the Ingredient Name to its original value
            txtBoxName.Text = IngredientName;
        }

        private void pbBrandNameReset_Click(object sender, EventArgs e)
        {
            // Reset the Brand Name to its original value
            txtBoxName.Text = BrandName;
        }

        private void pbTypeReset_Click(object sender, EventArgs e)
        {
            // Reset the Ingredient Type to its original value
            cmbTypeOfIngredient.SelectedItem = originalIngredientType;
        }


        private void pbCostReset_Click(object sender, EventArgs e)
        {
            // Reset the Cost to its original value
            numericUpDownCost.Value = Cost;
        }

        private void pbMUnitReset_Click(object sender, EventArgs e)
        {
            // Reset the Measuring Unit to its original value
            cmbBoxMeasuringUnit.SelectedItem = MeasuringUnit;
        }

        private void pbImgReset_Click(object sender, EventArgs e)
        {
            // Reset the Image to its original value
        }

        private void pbIsAddOnReset_Click(object sender, EventArgs e)
        {
            // Reset the Is AddOn to its original value
/*            rdButtonIsAddOnYes.Checked = originalIsAddOn;
*/        }



        private void pbReorderLevelReset_Click(object sender, EventArgs e)
        {
            // Reset the Reorder Level to its original value
            numericUpDownLowLevel.Value = LowLevel;
        }

        private void pbExpirationReset_Click(object sender, EventArgs e)
        {
            // Reset the Expiration to its original value
            dateTimePickerExpiration.Value = Expiration;
        }

        private void pbBatchNumberReset_Click(object sender, EventArgs e)
        {
            // Reset the Batch Number to its original value
            txtBoxBatchNumber.Text = BatchNumber;
        }

        private void pbStorageConditionReset_Click(object sender, EventArgs e)
        {
            // Reset the Storage Condition to its original value
            cmbboxStorageCondition.SelectedItem = StorageCondition;
        }

        private void pbSupplierReset_Click(object sender, EventArgs e)
        {
            // Reset the Supplier to its original value
            txtBoxVendor.Text = Vendor;
        }


        // Reset Ingredient Type to its original value
        private void pbIngredientTypeReset_Click(object sender, EventArgs e)
        {
            cmbTypeOfIngredient.SelectedItem = originalIngredientType;
        }

        // Reset Ingredient Functions to its original selected values
        private void pbIngredientFunctionReset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chkListBoxIngredientFunction.Items.Count; i++)
            {
                chkListBoxIngredientFunction.SetItemChecked(i, originalIngredientFunctions.Contains(chkListBoxIngredientFunction.Items[i].ToString()));
            }
        }

        // Reset Allergens to its original selected values
        private void pbAllergiesReset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < materialCheckedListBoxAllergens.Items.Count; i++)
            {
                materialCheckedListBoxAllergens.SetItemChecked(i, originalAllergens.Contains(materialCheckedListBoxAllergens.Items[i].ToString()));
            }
        }

        private void btnConfirmEdit_Click(object sender, EventArgs e)
        {
            // Collect updated values from form controls
            string newBatchNumber = txtBoxBatchNumber.Text;
            decimal newQuantity = numericUpDownQuantity.Value;
            string newMeasuringUnit = cmbBoxMeasuringUnit.SelectedItem.ToString();
            decimal newCost = numericUpDownCost.Value;
            decimal newLowLevel = numericUpDownLowLevel.Value;
            DateTime newExpiration = dateTimePickerExpiration.Value;
            string newItemDescription = txtBoxItemDescription.Text;
            string newBrandName = txtBoxBrandName.Text;
            string newVendor = txtBoxVendor.Text;
            string newStorageCondition = cmbboxStorageCondition.SelectedItem.ToString();
            string newIngredientImage = pictureBoxImg.ImageLocation;

            // Collect Ingredient Functions and Allergens
            List<string> newIngredientFunctions = new List<string>();
            foreach (var item in CheckedListBoxHelper.GetCheckedItemsFromIterator(chkListBoxIngredientFunction))
            {
                newIngredientFunctions.Add(item.ToString());
            }

            List<string> newAllergens = new List<string>();
            foreach (var item in CheckedListBoxHelper.GetCheckedItemsFromIterator(materialCheckedListBoxAllergens))
            {
                newAllergens.Add(item.ToString());
            }

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
                BatchID, IngredientID, newBatchNumber,
                newQuantity, newMeasuringUnit,
                IngredientName, newCost,
                newLowLevel,
                newExpiration,
                newItemDescription,
                IngredientType, newBrandName,
                newVendor,
                newStorageCondition,
                newIngredientImage,
                newIngredientFunctions,
                newAllergens
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
