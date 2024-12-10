using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Helpers;
using TakoTea.Models;
using TakoTea.Services;


namespace TakoTea.View.Items.Item_Modals
{
    public partial class EditIngredientModal : MaterialForm
    {
        private readonly InventoryService _inventoryService;
        private readonly ProductsService productsService;
        private readonly Entities context;


        private void PopulateComboboxUseFor()
        {
            // Populate the cmbAddOnFor ComboBox
            List<Models.Product> products = productsService.GetAllProducts();  // This should return a list of products
            cmbAddOnFor.DataSource = products;  // Set the data source of the ComboBox
            cmbAddOnFor.DisplayMember = "ProductName";  // The name to display in the ComboBox
            cmbAddOnFor.ValueMember = "ProductID";
        }
        private readonly int _ingredientId;

        public EditIngredientModal(int ingredientId)
        {
            InitializeComponent();
            _ingredientId = ingredientId;
            LoadIngredientData();
            context = new Entities();
            _inventoryService = new InventoryService();
            ThemeConfigurator.ApplyDarkTheme(this);
            ModalSettingsConfigurator.ApplyStandardModalSettings(this);
            PopulateAllergens(materialCheckedListBoxAllergens);
            productsService = new ProductsService(context);
            PopulateComboboxUseFor();
            btnConfirmEdit.Click += btnConfirmEdit_Click;
            btnCancelEdit.Click += btnCancelEdit_Click;
        }




        private void LoadIngredientData()
        {
            Entities context = new Entities();
            Ingredient ingredient = context.Ingredients.FirstOrDefault(i => i.IngredientID == _ingredientId);

            if (ingredient == null)
            {
                return;
            }

            txtBoxName.Text = ingredient.IngredientName;
            txtBoxBrandName.Text = ingredient.BrandName;
            txtBoxItemDescription.Text = ingredient.Description;
            pictureBoxImg.Image = ImageHelper.ByteArrayToImage(ingredient.IngredientImage);
            cmbboxStorageCondition.SelectedItem = ingredient.StorageConditions;
            cmbTypeOfIngredient.SelectedItem = ingredient.TypeOfIngredient;
            numericUpDownLowStockThreshold.Value = ingredient.LowLevel.Value;
            materialCheckedListBoxAllergens.Items.Clear();
            chkIsAddOn.Checked = ingredient.IsAddOn ?? false;
            string[] allergens = ingredient.AllergyInformation.Split(new[] { '?' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string allergen in allergens)
            {
                _ = materialCheckedListBoxAllergens.Items.Add(allergen, true);
            }


            AddOn addOn = context.AddOns.FirstOrDefault(a => a.IngredientID == ingredient.IngredientID);
            if (addOn != null)
            {
                EnableAddOnControls();
                numericUpDownAddOnPrice.Value = addOn.AdditionalPrice;
                cmbAddOnFor.SelectedValue = addOn.UseForProductID;
                numericUpDownQuantityUsedPerProduct.Value = addOn.QuantityUsedPerProduct ?? 0;
            }
            else
            {
                DisableAddOnControls();
            }
        }

        private void EnableAddOnControls()
        {
            numericUpDownAddOnPrice.Enabled = true;
            lblAdditionalPrice.Enabled = true;
            cmbAddOnFor.Enabled = true;
            lblAddOnFor.Enabled = true;
            numericUpDownQuantityUsedPerProduct.Enabled = true;
            materialLabel3.Enabled = true;
        }

        private void DisableAddOnControls()
        {
            numericUpDownAddOnPrice.Enabled = false;
            lblAdditionalPrice.Enabled = false;
            cmbAddOnFor.Enabled = false;
            lblAddOnFor.Enabled = false;
            numericUpDownQuantityUsedPerProduct.Enabled = false;
            materialLabel3.Enabled = false;
        }

        private void btnConfirmEdit_Click(object sender, EventArgs e)
        {
            Ingredient ingredient = context.Ingredients.FirstOrDefault(i => i.IngredientID == _ingredientId);

            if (ingredient == null)
            {
                _ = MessageBox.Show("Ingredient not found.");
                return;
            }

            // Store original values for logging
            string originalIngredientName = ingredient.IngredientName;
            string originalBrandName = ingredient.BrandName;
            byte[] originalIngredientImage = ingredient.IngredientImage;  // Store the original image as byte array
            string originalDescription = ingredient.Description;
            string originalStorageConditions = ingredient.StorageConditions;
            string originalTypeOfIngredient = ingredient.TypeOfIngredient;

            ingredient.IngredientName = txtBoxName.Text;
            ingredient.BrandName = txtBoxBrandName.Text;
            ingredient.IngredientImage = ImageHelper.ImageToByteArray(pictureBoxImg.Image);
            ingredient.Description = txtBoxItemDescription.Text;
            ingredient.StorageConditions = cmbboxStorageCondition.SelectedItem.ToString();
            ingredient.TypeOfIngredient = cmbTypeOfIngredient.SelectedItem.ToString();
            string changeDescription = DialogHelper.ShowInputDialog(
                formTitle: "Enter Change Description",
                labelText: "Change Description:",
                validationMessage: "Description cannot be empty.",
                validateInput: input => !string.IsNullOrWhiteSpace(input)
            );
            AddOn addOn = context.AddOns.FirstOrDefault(a => a.IngredientID == ingredient.IngredientID);

            if (addOn != null)
            {

                string originalAddOnName = addOn.AddOnName;
                decimal originalAdditionalPrice = addOn.AdditionalPrice;
                int? originalUseForProductID = addOn.UseForProductID;
                decimal? originalQuantityUsedPerProduct = addOn.QuantityUsedPerProduct;

                // Update add-on details if it exists
                addOn.AddOnName = txtBoxName.Text;
                addOn.AdditionalPrice = numericUpDownAddOnPrice.Value;
                addOn.UseForProductID = (int?)cmbAddOnFor.SelectedValue;
                addOn.QuantityUsedPerProduct = numericUpDownQuantityUsedPerProduct.Value;

                // Log changes to add-on properties
                if (originalAddOnName != addOn.AddOnName)
                {
                    LoggingHelper.LogChange("AddOns", addOn.Id, "AddOnName", originalAddOnName, addOn.AddOnName, "Updated", $"AddOnName changed from '{originalAddOnName}' to '{addOn.AddOnName}' for ingredient '{ingredient.IngredientName}'", changeDescription);
                }
                if (originalAdditionalPrice != addOn.AdditionalPrice)
                {
                    LoggingHelper.LogChange("AddOns", addOn.Id, "AdditionalPrice", originalAdditionalPrice.ToString(), addOn.AdditionalPrice.ToString(), "Updated", $"AdditionalPrice changed from '{originalAdditionalPrice}' to '{addOn.AdditionalPrice}' for ingredient '{ingredient.IngredientName}'", changeDescription);
                }
                if (originalUseForProductID != addOn.UseForProductID)
                {
                    LoggingHelper.LogChange("AddOns", addOn.Id, "UseForProductID", originalUseForProductID.ToString(), addOn.UseForProductID.ToString(), "Updated", $"UseForProductID changed from '{originalUseForProductID}' to '{addOn.UseForProductID}' for ingredient '{ingredient.IngredientName}'", changeDescription);
                }
                if (originalQuantityUsedPerProduct != addOn.QuantityUsedPerProduct)
                {
                    LoggingHelper.LogChange("AddOns", addOn.Id, "QuantityUsedPerProduct", originalQuantityUsedPerProduct.ToString(), addOn.QuantityUsedPerProduct.ToString(), "Updated", $"QuantityUsedPerProduct changed from '{originalQuantityUsedPerProduct}' to '{addOn.QuantityUsedPerProduct}' for ingredient '{ingredient.IngredientName}'", changeDescription);
                }
            }

            try
            {
                _ = context.SaveChanges();
                _ = MessageBox.Show("Ingredient updated successfully.");
                if (originalIngredientName != ingredient.IngredientName)
                {
                    LoggingHelper.LogChange("Ingredients", ingredient.IngredientID, "IngredientName", originalIngredientName, ingredient.IngredientName, "Updated", $"IngredientName changed from '{originalIngredientName}' to '{ingredient.IngredientName}'", changeDescription);
                }
                if (originalBrandName != ingredient.BrandName)
                {
                    LoggingHelper.LogChange("Ingredients", ingredient.IngredientID, "BrandName", originalBrandName, ingredient.BrandName, "Updated", $"BrandName changed from '{originalBrandName}' to '{ingredient.BrandName}'", changeDescription);
                }
                if (!originalIngredientImage.SequenceEqual(ingredient.IngredientImage))
                {
                    LoggingHelper.LogChange("Ingredients", ingredient.IngredientID, "IngredientImage", null, null, "Updated", $"IngredientImage changed for '{ingredient.IngredientName}'", changeDescription); // No need to log the actual image data
                }
                if (originalDescription != ingredient.Description)
                {
                    LoggingHelper.LogChange("Ingredients", ingredient.IngredientID, "Description", originalDescription, ingredient.Description, "Updated", $"Description changed from '{originalDescription}' to '{ingredient.Description}'", changeDescription);
                }
                if (originalStorageConditions != ingredient.StorageConditions)
                {
                    LoggingHelper.LogChange("Ingredients", ingredient.IngredientID, "StorageConditions", originalStorageConditions, ingredient.StorageConditions, "Updated", $"StorageConditions changed from '{originalStorageConditions}' to '{ingredient.StorageConditions}'", changeDescription);
                }
                if (originalTypeOfIngredient != ingredient.TypeOfIngredient)
                {
                    LoggingHelper.LogChange("Ingredients", ingredient.IngredientID, "TypeOfIngredient", originalTypeOfIngredient, ingredient.TypeOfIngredient, "Updated", $"TypeOfIngredient changed from '{originalTypeOfIngredient}' to '{ingredient.TypeOfIngredient}'", changeDescription);
                }

                Close();
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show($"Error updating ingredient: {ex.Message}");
            }
        }


        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            LogIngredientChange("Cancel", _ingredientId, "Ingredient edit cancelled");
            Close();
        }

        private void LogIngredientChange(string action, int ingredientId, string description)
        {
            IngredientChangeLog logEntry = new IngredientChangeLog
            {
                IngredientID = ingredientId,
                Action = action,
                Description = description,
                Timestamp = DateTime.Now
            };
            _ = context.IngredientChangeLogs.Add(logEntry);
            _ = context.SaveChanges();
        }



        // Populate allergen list in the checked list box
        public void PopulateAllergens(CheckedListBox materialCheckedListBoxAllergens)
        {
            List<string> allergens = new List<string>
            {
                "Corn", "Sulfites", "Lupin", "Celery", "Mustard",
                "Gluten", "Sesame", "Soybeans", "Wheat", "Peanuts",
                "Tree Nuts", "Shellfish", "Fish", "Eggs", "Milk"
            };

            foreach (string allergen in allergens)
            {
                _ = materialCheckedListBoxAllergens.Items.Add(allergen);
            }
        }

        private void btnConfirmEdit_Click_1(object sender, EventArgs e)
        {

        }

        private void btnBrowseForIngredientImg_Click(object sender, EventArgs e)
        {
            _ = ImageHelper.BrowseAndLoadImage(pictureBoxImg);

        }

        private void btnResetIngredientImg_Click(object sender, EventArgs e)
        {
            ImageHelper.ResetImage(pictureBoxImg);
        }
    }
}
