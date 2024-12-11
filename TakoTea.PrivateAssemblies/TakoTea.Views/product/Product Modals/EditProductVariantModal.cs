using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TakoTea.Helpers;
using TakoTea.Models;

namespace TakoTea.View.Product.Product_Modals
{
    public partial class EditProductVariantModal : MaterialForm
    {
        // In your EditProductVariantModal class

        private readonly ProductVariant _originalProductVariant; // Store the original state
        private readonly Entities _context;
        private readonly List<ProductVariant> _modifiedVariants = new List<ProductVariant>(); // To store modified variants

        public EditProductVariantModal(int productVariantId)
        {
            _context = new Entities();
            InitializeComponent();
            numericUpDownPriceChanges.Minimum = 0.1M;
            _originalProductVariant = _context.ProductVariants.Find(productVariantId);
            LoadProductVariantData();
            txtBoxCurrentPrice.ReadOnly = true;
        }

        private void LoadProductVariantData()
        {
            if (_originalProductVariant == null)
            {
                _ = MessageBox.Show("Product variant not found.");
                Close();
                return;
            }

            List<string> sizes = _context.ProductVariants
                .Where(pv => pv.VariantName == _originalProductVariant.VariantName)
                .Select(pv => pv.Size)
                .Distinct()
                .ToList();
            cmbSizes.DataSource = sizes;

            txtBoxVariantName.Text = _originalProductVariant.VariantName;
            cmbSizes.SelectedItem = _originalProductVariant.Size;
            txtBoxCurrentPrice.Text = _originalProductVariant.Price.ToString("F2");
            txtBoxCurrentPrice.Hint = _originalProductVariant.Price.ToString("F2");
            txtBoxInstructions.Text = _originalProductVariant.Instructions;
            pictureBoxProductImage.Image = ImageHelper.ByteArrayToImage(_originalProductVariant.ImagePath);



            // Assuming 'Ingredients' is a comma-separated string in your ProductVariants table
            string[] ingredientsArray = _originalProductVariant.Ingredients.Split(',');

            List<string> ingredientStrings = new List<string>();
            foreach (string ingredient in ingredientsArray)
            {
                ingredientStrings.Add(ingredient.Trim()); // Just trim whitespace
            }

            listBoxIngredients.DataSource = ingredientStrings;
        }



        // ... (Similar click handlers for other buttons) ...

        private void UpdatePrice(string variantName, string size, decimal priceChange, bool isIncrease)
        {
            ProductVariant variantToUpdate = _context.ProductVariants.FirstOrDefault(pv => pv.VariantName == variantName && pv.Size == size);
            if (variantToUpdate != null)
            {
                string originalPrice = variantToUpdate.Price.ToString();
                decimal oldPrice = variantToUpdate.Price;

                // Store the original price before making changes
                decimal originalVariantPrice = variantToUpdate.Price;

                variantToUpdate.Price = isIncrease
                    ? variantToUpdate.Price + priceChange
                    : variantToUpdate.Price - priceChange;

                decimal newPrice = variantToUpdate.Price;

                string changeDescription = DialogHelper.ShowInputDialog(
                    formTitle: "Enter Change Description",
                    labelText: "Change Description:",
                    validationMessage: "Description cannot be empty.",
                    validateInput: input => !string.IsNullOrWhiteSpace(input)
                );

                if (changeDescription != null) // Check if the dialog was closed
                {
                    // Update the displayed price
                    txtBoxCurrentPrice.Text = variantToUpdate.Price.ToString("F2");

                    LoggingHelper.LogChange("ProductVariants",
                        variantToUpdate.ProductVariantID,
                        "Price",
                        originalPrice,
                        variantToUpdate.Price.ToString(),
                        "Updated",
                        $"Price changed from '{oldPrice}' to '{newPrice}' for variant '{variantToUpdate.VariantName}'",
                        changeDescription);

                    _ = _context.SaveChanges();

                    _ = MessageBox.Show($"Price updated successfully from {oldPrice:F2} to {newPrice:F2}",
                        "Price Update",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    // Revert the price change
                    variantToUpdate.Price = originalVariantPrice;
                }
            }
            numericUpDownPriceChanges.Value = numericUpDownPriceChanges.Minimum;
        }

        private void UpdatePriceAll(string variantName, decimal priceChange, bool isIncrease)
        {
            List<ProductVariant> variantsToUpdate = _context.ProductVariants.Where(pv => pv.VariantName == variantName).ToList();

            // Store original prices for all variants
            Dictionary<int, decimal> originalPrices = variantsToUpdate.ToDictionary(v => v.ProductVariantID, v => v.Price);

            string changeDescription = DialogHelper.ShowInputDialog(
                formTitle: "Enter Change Description",
                labelText: "Change Description:",
                validationMessage: "Description cannot be empty.",
                validateInput: input => !string.IsNullOrWhiteSpace(input)
            );

            if (changeDescription != null) // Check if the dialog was closed
            {
                foreach (ProductVariant variant in variantsToUpdate)
                {
                    string originalPrice = variant.Price.ToString();

                    variant.Price = isIncrease ? variant.Price + priceChange : variant.Price - priceChange;

                    LoggingHelper.LogChange("ProductVariants",
                                            variant.ProductVariantID,
                                            "Price",
                                            originalPrice,
                                            variant.Price.ToString(),
                                            "Updated",
                                            $"Price changed from '{originalPrice}' to '{variant.Price}' for variant '{variant.VariantName}'",
                                            changeDescription);
                }

                // Update the displayed price (assuming you want to show the first variant's price)
                txtBoxCurrentPrice.Text = variantsToUpdate.FirstOrDefault()?.Price.ToString("F2") ?? "0.00";

                // Show message box
                _ = MessageBox.Show($"Prices updated successfully for all variants of '{variantName}'",
                                "Price Update",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                _ = _context.SaveChanges(); // Save changes after updating all variants
            }
            else
            {
                // Revert the price changes for all variants
                foreach (ProductVariant variant in variantsToUpdate)
                {
                    variant.Price = originalPrices[variant.ProductVariantID];
                }
            }
            numericUpDownPriceChanges.Value = numericUpDownPriceChanges.Minimum;

        }

        private void btnIncreasePrice_Click(object sender, EventArgs e)
        {
            decimal priceChange = numericUpDownPriceChanges.Value;
            UpdatePrice(_originalProductVariant.VariantName, _originalProductVariant.Size, priceChange, true);
        }

        private void btnReducePrice_Click(object sender, EventArgs e)
        {
            decimal priceChange = numericUpDownPriceChanges.Value;
            UpdatePrice(_originalProductVariant.VariantName, _originalProductVariant.Size, priceChange, false);
        }

        private void btnIncreasePriceToAll_Click(object sender, EventArgs e)
        {
            decimal priceChange = numericUpDownPriceChanges.Value;
            UpdatePriceAll(_originalProductVariant.VariantName, priceChange, true); // Increase
        }

        private void btnReducePriceToAll_Click(object sender, EventArgs e)
        {
            decimal priceChange = numericUpDownPriceChanges.Value;
            UpdatePriceAll(_originalProductVariant.VariantName, priceChange, false); // Decrease
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            System.Data.Entity.DbContextTransaction transaction = _context.Database.BeginTransaction();
            try
            {
                string variantName = txtBoxVariantName.Text;
                string size = cmbSizes.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(variantName) || string.IsNullOrEmpty(size))
                {
                    _ = MessageBox.Show("Invalid variant name or size.");
                    return;
                }

                ProductVariant productVariant = _context.ProductVariants.FirstOrDefault(pv => pv.VariantName == variantName && pv.Size == size);
                if (productVariant == null)
                {
                    _ = MessageBox.Show("Product variant not found.");
                    return;
                }

                decimal originalPrice = productVariant.Price;
                string originalInstructions = productVariant.Instructions;
                byte[] originalImagePath = productVariant.ImagePath;

                productVariant.Price = decimal.Parse(txtBoxCurrentPrice.Text);
                productVariant.Instructions = txtBoxInstructions.Text;

                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBoxProductImage.Image.Save(ms, pictureBoxProductImage.Image.RawFormat);
                    productVariant.ImagePath = ms.ToArray();
                }
                string changeDescription = DialogHelper.ShowInputDialog(
                    formTitle: "Enter Change Description",
                    labelText: "Change Description:",
                    validationMessage: "Description cannot be empty.",
                    validateInput: input => !string.IsNullOrWhiteSpace(input)
                );


                if (originalPrice != productVariant.Price)
                {
                    LoggingHelper.LogChange("ProductVariants", productVariant.ProductVariantID, "Price", originalPrice.ToString(), productVariant.Price.ToString(), "Updated", $"Price changed from '{originalPrice}' to '{productVariant.Price}' for variant '{productVariant.VariantName}'", changeDescription);
                }
                if (originalInstructions != productVariant.Instructions)
                {
                    LoggingHelper.LogChange("ProductVariants", productVariant.ProductVariantID, "Instructions", originalInstructions, productVariant.Instructions, "Updated", $"Instructions changed from '{originalInstructions}' to '{productVariant.Instructions}' for variant '{productVariant.VariantName}'", changeDescription);
                }
                if (!originalImagePath.SequenceEqual(productVariant.ImagePath))
                {
                    LoggingHelper.LogChange("ProductVariants", productVariant.ProductVariantID, "ImagePath", null, null, "Updated", $"ImagePath changed for '{productVariant.VariantName}'", changeDescription); // Image data not logged
                }
                _ = _context.SaveChanges();
                transaction.Commit();
                _ = MessageBox.Show("Updated successfully.");
                Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                _ = MessageBox.Show("An error occurred while updating the product variant: " + ex.Message);
            }
        }


        private void btnBrowseForIngredientImg_Click(object sender, EventArgs e)
        {
            _ = ImageHelper.BrowseAndLoadImage(pictureBoxProductImage);
        }

        private void btnResetIngredientImg_Click(object sender, EventArgs e)
        {
            ImageHelper.ResetImage(pictureBoxProductImage);
        }

        private void cmbSizes_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Reload the original data to rollback changes
            LoadProductVariantData();
            Close();
        }

        private void cmbSizes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selectedSize = cmbSizes.SelectedItem.ToString();

            int productVariantId = _context.ProductVariants
                .FirstOrDefault(pv => pv.VariantName == _originalProductVariant.VariantName && pv.Size == selectedSize)
                ?.ProductVariantID ?? 0;

            EditProductVariantModal newModal = new EditProductVariantModal(productVariantId);
            newModal.Show();

            Close();
        }
    }
}

