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
using Helpers;
using System.util;
using System.Drawing.Imaging;
using System.Drawing;


namespace TakoTea.View.Items.Item_Modals
{
    public partial class AddItemModal : MaterialForm
    {
        private readonly InventoryService _inventoryService;
        private readonly ProductsService productsService;
        private readonly Entities _context;
        public AddItemModal()
        {
            InitializeComponent();
            _inventoryService = new InventoryService();
            ThemeConfigurator.ApplyDarkTheme(this);
            ModalSettingsConfigurator.ApplyStandardModalSettings(this);
            PopulateAllergens(materialCheckedListBoxAllergens);
            productsService = new ProductsService(_context);
            _context = new Entities();
            PopulateComboboxUseFor();
            numericUpDownAddOnPrice.Visible = true;
            lblAdditionalPrice.Visible = true;
            cmbAddOnFor.Visible = true;
            lblAddOnFor.Visible = true;
            numericUpDownAddOnPrice.Enabled = false;
            lblAdditionalPrice.Enabled = false;
            cmbAddOnFor.Enabled = false;
            lblAddOnFor.Enabled = false;
            numericUpDownQuantityUsedPerProduct.Enabled = false;
            materialLabel3.Enabled = false;
            materialCheckedListBoxAllergens.CheckOnClick = true;
            btnCancel.Click += btnCancel_Click;
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
        private void OpenAddBatchModal(Ingredient ingredient)
        {
            AddBatchModal addBatchModal = new AddBatchModal();
            addBatchModal.lblIngredientId.Text = ingredient.IngredientID.ToString();
            addBatchModal.txtBoxIngredientName.Text = ingredient.IngredientName;
            addBatchModal.lblQuantity.Text = ingredient.MeasuringUnit;
            addBatchModal.ShowDialog();
        }
        private void btnCancel_Click(object sender, EventArgs e)
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
            private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(txtBoxName.Text) ||
                string.IsNullOrWhiteSpace(txtBoxBrandName.Text) ||
                string.IsNullOrWhiteSpace(txtBoxItemDescription.Text) ||
                cmbboxStorageCondition.SelectedItem == null ||
                cmbTypeOfIngredient.SelectedItem == null ||
                cmbMeasuringUnit.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all required fields");
                return;
            }

            // Load the image into a byte array
            byte[] imageData;
            if (pictureBoxImg.Image != null)
            {
                using (var ms = new MemoryStream())
                {
                    pictureBoxImg.Image.Save(ms, pictureBoxImg.Image.RawFormat);
                    imageData = ms.ToArray();
                }
            }
            else
            {
                // Set default image if null 
                pictureBoxImg.Image = TakoTea.Views.Properties.Resources.restart1;
                imageData = TakoTea.Views.Properties.Resources.restart1.ToByteArray(System.Drawing.Imaging.ImageFormat.Png);


            }

            bool isAddOn = chkIsAddOn.Checked;

            using (var transaction = _context.Database.BeginTransaction())
            {

                string type = "Ingredient";
                try
                {
                    if (isAddOn)
                    {
                        var addOn = new AddOn
                        {
                            AddOnName = txtBoxName.Text,
                            AdditionalPrice = numericUpDownAddOnPrice.Value,
                            UseForProductID = (int)cmbAddOnFor.SelectedValue,
                            IngredientID = _inventoryService.GetNextIngredientId(),
                            QuantityUsedPerProduct = numericUpDownQuantityUsedPerProduct.Value
                        };
                        type = "AddOn";
                        _inventoryService.AddAddon(addOn);
                    }

                    var ingredient = new Ingredient
                    {
                        IngredientName = txtBoxName.Text,
                        BrandName = txtBoxBrandName.Text,
                        Description = txtBoxItemDescription.Text,
                        IngredientImage = imageData,
                        IsAddOn = isAddOn,
                        StorageConditions = cmbboxStorageCondition.SelectedItem?.ToString() ?? "",
                        TypeOfIngredient = cmbTypeOfIngredient.SelectedItem?.ToString() ?? "",
                        IsActive = true,
                        MeasuringUnit = cmbMeasuringUnit.SelectedItem?.ToString() ?? "",
                        AllergyInformation = string.Join(", ", CheckedListBoxHelper.GetCheckedItemsFromIterator(materialCheckedListBoxAllergens)),
                        LowLevel = numericUpDownLowStockThreshold.Value,
                        CreatedAt = DateTime.Now,
                        CreatedBy = AuthenticationHelper._loggedInUsername
                    };

                    _inventoryService.AddIngredient(ingredient);
                    transaction.Commit();

                    LoggingHelper.LogChange(
                        "Ingredients",                // Table name
                        ingredient.IngredientID,      // Record ID
                        "New Ingredient",             // Column name (or any descriptive text)
                        null,                         // Old value (null for new ingredient)
                        ingredient.ToString(),        // New value (you might need to override ToString() in your Ingredient class for a more descriptive log)
                        "Added",                      // Action
                        $"Ingredient '{ingredient.IngredientName}' added with ID '{ingredient.IngredientID}'", ""  // Description
                    );

                    _ = MessageBox.Show(type + " added successfully.");
                    OpenAddBatchModal(ingredient);
                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _ = MessageBox.Show("Error adding item: " + ex.Message);
                }
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
                numericUpDownAddOnPrice.Enabled = true;
                lblAdditionalPrice.Enabled = true;
                cmbAddOnFor.Enabled = true;
                lblAddOnFor.Enabled = true;
                numericUpDownQuantityUsedPerProduct.Enabled = true;
                materialLabel3.Enabled = true;
            }
            else
            {
                numericUpDownAddOnPrice.Enabled = false;
                lblAdditionalPrice.Enabled = false;
                cmbAddOnFor.Enabled = false;
                lblAddOnFor.Enabled = false;
                numericUpDownQuantityUsedPerProduct.Enabled = false;
                materialLabel3.Enabled = false;

            }
        }

        private void groupBoxOther_Enter(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {

        }

        private void btnResetIngredientImg_Click(object sender, EventArgs e)
        {
            if (pictureBoxImg != null)
            {
                pictureBoxImg.Image = null;
            }
        }
    }

    public static class ImageExtensions
    {
        public static byte[] ToByteArray(this Image image, ImageFormat format)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, format);
                return ms.ToArray();
            }
        }
    }
}
