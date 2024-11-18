using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Helpers;
using TakoTea.Interfaces;
using TakoTea.Models;
using TakoTea.Services;
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
            _ = MessageBox.Show("asdasdasdasd"); Ingredient ingredient = new Ingredient
            {
                IngredientName = txtBoxName.Text,
                BrandName = txtBoxBrandName.Text,
                Description = txtBoxItemDescription.Text,
                MeasuringUnit = cmbBoxMeasuringUnit.SelectedItem?.ToString() ?? "",
                IngredientImage = pictureBoxImg.ImageLocation,
                IsAddOn = rdButtonIsAddOnYes.Checked,
                TypeOfIngredient = cmbTypeOfIngredient.SelectedItem?.ToString() ?? "",
                IsActive = true,
                AllergyInformation = string.Join(", ", CheckedListBoxHelper.GetCheckedItemsFromIterator(materialCheckedListBoxAllergens))
            };
            BatchIngredient batch = new BatchIngredient
            {
                BatchNumber = txtBoxBatchNumber.Text,
                QuantityInStock = numericUpDownCost.Value,
                ReorderLevel = numericUpDownLowLevel.Value,
                ExpirationDate = dateTimePickerExpiration.Value,
                Supplier = txtBoxVendor.Text,
                StorageConditions = cmbboxStorageCondition.SelectedItem?.ToString() ?? "",
                BatchCost = numericUpDownCost.Value,
                IsActive = true
            };
            List<int> linkedProductIds = new List<int>();
            CheckedItemIterator productIterator = new CheckedItemIterator(chkListBoxIngredientFunction);
            while (productIterator.HasNext())
            {
                if (int.TryParse(productIterator.Next(), out int productId))
                {
                    linkedProductIds.Add(productId);
                }
            }
            try
            {
                _inventoryService.AddIngredient(ingredient, batch, linkedProductIds);
                _ = MessageBox.Show("Ingredient and batch added successfully.");
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show("Error adding item: " + ex.Message);
            }
        }
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
