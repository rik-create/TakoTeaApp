using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.HELPERS;
using TakoTea.Interfaces;
using TakoTea.Model.ENTITY;
using TakoTea.PATTERNS;
using TakoTea.Services;

namespace TakoTea.View.Items.Item_Modals
{
    public partial class AddItemModal : MaterialForm
    {
        private readonly IInventoryService _inventoryService;

        // Constructor for default usage
        public AddItemModal() : this(new InventoryService())
        {
        }

        // Constructor with dependency injection for IInventoryService
        public AddItemModal(IInventoryService inventoryService)
        {
            InitializeComponent();

            _inventoryService = inventoryService ?? throw new ArgumentNullException(nameof(inventoryService));

            ThemeConfigurator.ApplyDarkTheme(this);
            ModalSettingsConfigurator.ApplyStandardModalSettings(this);
            PopulateAllergens(materialCheckedListBoxAllergens);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            MessageBox.Show("asdasdasdasd");            // Collect data from form controls
            var ingredient = new Ingredient
            {
                IngredientName = txtBoxName.Text,
                BrandName = txtBoxBrandName.Text,
                Description = txtBoxItemDescription.Text,
                MeasuringUnit = cmbBoxMeasuringUnit.SelectedItem?.ToString() ?? "",
                IngredientImage = pictureBoxImg.ImageLocation,  // Save the image path or a byte[] for image data
                IsAddOn = rdButtonIsAddOnYes.Checked,
                TypeOfIngredient = cmbTypeOfIngredient.SelectedItem?.ToString() ?? "",
                IsActive = true,  // Default to active when creating
                AllergyInformation = string.Join(", ", CheckedListBoxHelper.GetCheckedItemsFromIterator(materialCheckedListBoxAllergens))
            };

            var batch = new BatchIngredient
            {
                BatchNumber = txtBoxBatchNumber.Text,
                QuantityInStock = (decimal)numericUpDownCost.Value,
                ReorderLevel = (decimal)numericUpDownLowLevel.Value,
                ExpirationDate = dateTimePickerExpiration.Value,
                Supplier = txtBoxVendor.Text,
                StorageConditions = cmbboxStorageCondition.SelectedItem?.ToString() ?? "",
                BatchCost = (decimal)numericUpDownCost.Value,
                IsActive = true
            };

            // Get selected Product IDs for Ingredient-Product Links
            var linkedProductIds = new List<int>();
            var productIterator = new CheckedItemIterator(chkListBoxIngredientFunction);

            while (productIterator.HasNext())
            {
                if (int.TryParse(productIterator.Next(), out int productId))
                {
                    linkedProductIds.Add(productId);
                }
            }

            // Insert into the database
            try
            {
                _inventoryService.AddIngredient(ingredient, batch, linkedProductIds);
                MessageBox.Show("Ingredient and batch added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding item: " + ex.Message);
            }
        }

        public void PopulateAllergens(MaterialCheckedListBox materialCheckedListBoxAllergens)
        {
            var allergens = new List<string>
            {
                "Corn", "Sulfites", "Lupin", "Celery", "Mustard",
                "Gluten", "Sesame", "Soybeans", "Wheat", "Peanuts",
                "Tree Nuts", "Shellfish", "Fish", "Eggs", "Milk"
            };

            foreach (string allergen in allergens)
            {
                materialCheckedListBoxAllergens.Items.Add(allergen);
            }
        }
    }
}
