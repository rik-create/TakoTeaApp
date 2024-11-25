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
using System.Net.Security;


namespace TakoTea.View.Items.Item_Modals
{
    public partial class AddItemModal : MaterialForm
    {
        private readonly IInventoryService _inventoryService;
        private readonly ProductsService productsService;

        public AddItemModal()
        {
            InitializeComponent();
            _inventoryService = new InventoryService();
            ThemeConfigurator.ApplyDarkTheme(this);
            ModalSettingsConfigurator.ApplyStandardModalSettings(this);
            PopulateAllergens(materialCheckedListBoxAllergens);
            productsService = new ProductsService();
            PopulateComboboxUseFor();


        }// The value to bind (ProductID)
         //
         //
         // }

        private void PopulateComboboxUseFor()
        {
            // Populate the cmbAddOnFor ComboBox
            var products = productsService.GetAllProducts();  // This should return a list of products
            cmbAddOnFor.DataSource = products;  // Set the data source of the ComboBox
            cmbAddOnFor.DisplayMember = "ProductName";  // The name to display in the ComboBox
            cmbAddOnFor.ValueMember = "ProductID";
            cmbAddOnFor.Visible = false;
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Temporary message, replace with actual processing
            _ = MessageBox.Show("Processing...");

            // Simulating form data
            txtBoxName.Text = "Test Ingredient";
            txtBoxBrandName.Text = "Test Brand";
            txtBoxItemDescription.Text = "A description of the test ingredient for testing purposes.";
            pictureBoxImg.ImageLocation = @"C:\path\to\image.jpg"; // Path to a test image
            cmbboxStorageCondition.SelectedItem = "Cool & Dry"; // Assuming this is one of the options
            cmbTypeOfIngredient.SelectedItem = "Spice"; // Assuming "Spice" is one of the ingredient types
            cmbMeasuringUnit.SelectedItem = "Grams";

            // Determine if the item is an "Add On"
            bool isAddOn = chkIsAddOn.Checked; // Use the CheckBox 

            // If it's an add-on, create the AddOn object and add it
            if (isAddOn)
            {
                var addOn = new AddOn
                {
                    AddOnName = txtBoxName.Text,
                    AdditionalPrice = numericUpDownAddOnPrice.Value,
            UseForProductID = (int)cmbAddOnFor.SelectedValue // Get the ProductID from the ComboBox
                };

                // Add the add-on to the inventory
                try
                {
                    _inventoryService.AddAddon(addOn); // Modify the service as needed for EF
                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show("Error adding add-on: " + ex.Message);
                }
            }

            // Create the ingredient entity
            var ingredient = new Ingredient
            {
                IngredientName = txtBoxName.Text,
                BrandName = txtBoxBrandName.Text,
                Description = txtBoxItemDescription.Text,
                IngredientImage = pictureBoxImg.ImageLocation,
                IsAddOn = isAddOn, // Use the value from the radio button check
                StorageConditions = cmbboxStorageCondition.SelectedItem?.ToString() ?? "",
                TypeOfIngredient = cmbTypeOfIngredient.SelectedItem?.ToString() ?? "",
                IsActive = true,
                MeasuringUnit = cmbMeasuringUnit.SelectedItem?.ToString() ?? "",
                AllergyInformation = string.Join(", ", CheckedListBoxHelper.GetCheckedItemsFromIterator(materialCheckedListBoxAllergens)),
            };

            // Try to add the ingredient to the inventory
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


        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chkIsAddOn_CheckedChanged(object sender, EventArgs e)
        {
            // Check if the CheckBox is checked
            if (chkIsAddOn.Checked)
            {
                numericUpDownAddOnPrice.Visible = true;
                lblAdditionalPrice.Visible = true;
                cmbAddOnFor.Visible = true;
                lblAddOnFor.Visible = true;
            }
            else
            {
                numericUpDownAddOnPrice.Visible = false;
                lblAdditionalPrice.Visible = false;
                cmbAddOnFor.Visible = false;
                lblAddOnFor.Visible = false;
            }
        }
    }
}
