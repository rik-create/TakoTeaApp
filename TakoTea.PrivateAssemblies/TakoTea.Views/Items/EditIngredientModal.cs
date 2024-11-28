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
using System.IO;
using TakoTea.Views.Batches;


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
            var products = productsService.GetAllProducts();  // This should return a list of products
            cmbAddOnFor.DataSource = products;  // Set the data source of the ComboBox
            cmbAddOnFor.DisplayMember = "ProductName";  // The name to display in the ComboBox
            cmbAddOnFor.ValueMember = "ProductID";
            cmbAddOnFor.Visible = false;
        }
        private int _ingredientId;

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
            productsService = new ProductsService();
            PopulateComboboxUseFor();
            btnConfirmEdit.Click += btnConfirmEdit_Click;
            btnCancelEdit.Click += btnCancelEdit_Click;
        }


  

        private void LoadIngredientData()
        {
            var context = new Entities();
            var ingredient = context.Ingredients.FirstOrDefault(i => i.IngredientID == _ingredientId);

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
            var allergens = ingredient.AllergyInformation.Split(new[] { '?' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var allergen in allergens)
            {
                materialCheckedListBoxAllergens.Items.Add(allergen, true);
            }


            var addOn = context.AddOns.FirstOrDefault(a => a.IngredientID == ingredient.IngredientID);
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
            var ingredient = context.Ingredients.FirstOrDefault(i => i.IngredientID == _ingredientId);

            if (ingredient == null)
            {
                MessageBox.Show("Ingredient not found.");
                return;
            }

            ingredient.IngredientName = txtBoxName.Text;
            ingredient.BrandName = txtBoxBrandName.Text;
            ingredient.IngredientImage = ImageHelper.ImageToByteArray(pictureBoxImg.Image);
            ingredient.Description = txtBoxItemDescription.Text;
            ingredient.StorageConditions = cmbboxStorageCondition.SelectedItem.ToString();
            ingredient.TypeOfIngredient = cmbTypeOfIngredient.SelectedItem.ToString();

            var addOn = context.AddOns.FirstOrDefault(a => a.IngredientID == ingredient.IngredientID);

            addOn.AddOnName = txtBoxName.Text;
            addOn.AdditionalPrice = numericUpDownAddOnPrice.Value;
            addOn.UseForProductID = (int?)cmbAddOnFor.SelectedValue;
            addOn.QuantityUsedPerProduct = numericUpDownQuantityUsedPerProduct.Value;

            try
            {
                context.SaveChanges();
                MessageBox.Show("Ingredient updated successfully.");
                LogIngredientChange("Edit", ingredient.IngredientID, "Ingredient updated");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating ingredient: {ex.Message}");
            }
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            LogIngredientChange("Cancel", _ingredientId, "Ingredient edit cancelled");
            Close();
        }

        private void LogIngredientChange(string action, int ingredientId, string description)
        {
            var logEntry = new IngredientChangeLog
            {
                IngredientID = ingredientId,
                Action = action,
                Description = description,
                Timestamp = DateTime.Now
            };
            context.IngredientChangeLogs.Add(logEntry);
            context.SaveChanges();
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

        private void btnConfirmEdit_Click_1(object sender, EventArgs e)
        {

        }

        private void btnBrowseForIngredientImg_Click(object sender, EventArgs e)
        {
            ImageHelper.BrowseAndLoadImage(pictureBoxImg);

        }

        private void btnResetIngredientImg_Click(object sender, EventArgs e)
        {
            ImageHelper.ResetImage(pictureBoxImg);
        }
    }
}
