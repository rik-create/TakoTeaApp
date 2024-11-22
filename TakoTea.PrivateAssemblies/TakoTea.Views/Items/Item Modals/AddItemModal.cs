using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Helpers;
using TakoTea.Interfaces;
using TakoTea.Services;
using TakoTea.Models;

namespace TakoTea.Views.Items.Item_Modals
{
    public partial class AddItemModal : MaterialForm
    {
        private readonly IInventoryService _inventoryService;

        public AddItemModal()
        {
            InitializeComponent();
            _inventoryService = new InventoryService();
            ThemeConfigurator.ApplyDarkTheme(this);
            ModalSettingsConfigurator.ApplyStandardModalSettings(this);
            PopulateAllergens(materialCheckedListBoxAllergens);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Temporary message, replace with actual processing
            _ = MessageBox.Show("Processing...");
            txtBoxName.Text = "Test Ingredient";
            txtBoxBrandName.Text = "Test Brand";
            txtBoxItemDescription.Text = "A description of the test ingredient for testing purposes.";
            pictureBoxImg.ImageLocation = @"C:\path\to\image.jpg"; // Path to a test image
            rdButtonIsAddOnYes.Checked = true; // Simulating that "Is Add On" is selected
            cmbboxStorageCondition.SelectedItem = "Cool & Dry"; // Assuming this is one of the options
            cmbTypeOfIngredient.SelectedItem = "Spice"; // Assuming "Spice" is one of the ingredient types
            materialCheckedListBoxAllergens.SetItemChecked(materialCheckedListBoxAllergens.Items.IndexOf("Gluten"), true); // Example allergen


            // Create the ingredient entity
            var ingredient = new Ingredient
            {
                IngredientName = txtBoxName.Text,
                BrandName = txtBoxBrandName.Text,
                Description = txtBoxItemDescription.Text,
                IngredientImage = pictureBoxImg.ImageLocation,
                IsAddOn = rdButtonIsAddOnYes.Checked,
                StorageConditions = cmbboxStorageCondition.SelectedItem?.ToString() ?? "",
                TypeOfIngredient = cmbTypeOfIngredient.SelectedItem?.ToString() ?? "",
                IsActive = true,
                AllergyInformation = string.Join(", ", CheckedListBoxHelper.GetCheckedItemsFromIterator(materialCheckedListBoxAllergens))
            };
 


            try
            {
                _inventoryService.AddIngredient(ingredient); // Modify the service as needed for EF
                _ = MessageBox.Show("Ingredient and batch added successfully.");
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show("Error adding item: " + ex.Message);
            }
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
                materialCheckedListBoxAllergens.Items.Add(allergen);
            }
        }
    }
}
