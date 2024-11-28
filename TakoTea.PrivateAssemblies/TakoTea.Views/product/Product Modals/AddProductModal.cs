using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Helpers;
using TakoTea.Interfaces;
using TakoTea.Models;
using TakoTea.Services;

namespace TakoTea.View.Product.Product_Modals
{
    public partial class AddProductModal : MaterialForm
    {

        private readonly IInventoryService _inventoryService;
        private int selectedRowIndex = -1;
        private readonly ProductsService _productsService;
        public AddProductModal()
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            ModalSettingsConfigurator.ApplyStandardModalSettings(this);
            _inventoryService = new InventoryService();
            _productsService = new ProductsService();

            DataGridViewHelper.FormatListView(listViewIngredients);
            DataGridViewHelper.ApplyDataGridViewStylesWithWrite(dgViewAddingMultipleProductVariants);

            DataGridViewHelper.AddButtonsToLastRow(dgViewAddingMultipleProductVariants, "ClearIngredients","Clear Ingredients", ClearIngredientsInSelectedRowIndex);
        }
    
        private void InitializeProductComboBoxColumn()
        {
            try
            {
                // Create an instance of ProductService (you can inject it if needed)

                // Retrieve product names
                var productNames = _productsService.GetProductNames();

                // Clear any existing items in the ComboBox column
                ColumnProduct.Items.Clear();

                // Add product names to the ComboBox column
                foreach (var productName in productNames)
                {
                    ColumnProduct.Items.Add(productName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing product combo box: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AddProductModal_Load(object sender, EventArgs e)
        {
            // Set up initial settings for the DataGridView
            dgViewAddingMultipleProductVariants.RowsAdded += DgViewAddingMultipleProductVariants_RowsAdded;
            dgViewAddingMultipleProductVariants.AllowUserToAddRows = false; // Prevent adding rows manually

            PopulateIngredientsList();
            InitializeProductComboBoxColumn();
            // Enable text wrapping for the "Ingredients" column
            dgViewAddingMultipleProductVariants.Columns["ColumnIngredients"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgViewAddingMultipleProductVariants.Columns["ColumnInstructions"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Optionally, adjust the row height to fit wrapped text
            DataGridViewHelper.SetRowHeight(dgViewAddingMultipleProductVariants, 100);


        }

        // Handle Add New Row button click
        private void btnAddNewRow_Click(object sender, EventArgs e)
        {
            // Check if the last row is a new, uncommitted row
            if (dgViewAddingMultipleProductVariants.Rows.Count > 0)
            {
                var lastRow = dgViewAddingMultipleProductVariants.Rows[dgViewAddingMultipleProductVariants.Rows.Count - 1];

                // Check if the first cell (column index 0) of the last row is empty
                if (lastRow.Cells[0].Value == null || string.IsNullOrWhiteSpace(lastRow.Cells[0].Value.ToString()) ||
                    lastRow.Cells[1].Value == null || string.IsNullOrWhiteSpace(lastRow.Cells[1].Value.ToString()) ||
                    lastRow.Cells[2].Value == null || string.IsNullOrWhiteSpace(lastRow.Cells[2].Value.ToString()) ||
                    lastRow.Cells[3].Value == null || string.IsNullOrWhiteSpace(lastRow.Cells[3].Value.ToString()) ||
                    lastRow.Cells[4].Value == null || string.IsNullOrWhiteSpace(lastRow.Cells[4].Value.ToString()) ||
                    lastRow.Cells[5].Value == null || string.IsNullOrWhiteSpace(lastRow.Cells[5].Value.ToString()))
                {
                    MessageBox.Show("Please fill the current row before adding a new one.");
                    return;
                }
                    MessageBox.Show("Please fill the current row before adding a new one.");
                    return;
                }

            // If there's no new row, add an empty row
            int rowIndex = dgViewAddingMultipleProductVariants.Rows.Add();
            dgViewAddingMultipleProductVariants.Rows[rowIndex].Height = 100;
        }

            
  


            

        // Handle Duplicate Row button click
        private void btnDuplicateRow_Click(object sender, EventArgs e)
        {
            if (dgViewAddingMultipleProductVariants.SelectedRows.Count > 0)
            {
                var selectedRow = dgViewAddingMultipleProductVariants.SelectedRows[0];
                var newRow = (DataGridViewRow)selectedRow.Clone();

                // Copy all cell values from the selected row to the new row
                for (int i = 0; i < selectedRow.Cells.Count; i++)
                {
                    newRow.Cells[i].Value = selectedRow.Cells[i].Value;
                }

                // Add the new row to the grid
                dgViewAddingMultipleProductVariants.Rows.Add(newRow);
            }
        }

        // Handle Delete Row button click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgViewAddingMultipleProductVariants.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow selectedRow in dgViewAddingMultipleProductVariants.SelectedRows)
                {
                    // Ensure the row isn't the last row (so we don't delete all rows)
                    if (!selectedRow.IsNewRow)
                    {
                        dgViewAddingMultipleProductVariants.Rows.RemoveAt(selectedRow.Index);
                    }
                }
            }
        }

        // Handle uploading an image to the selected row
        private void btnUploadImgToSelectedRow_Click(object sender, EventArgs e)
        {
            if (dgViewAddingMultipleProductVariants.CurrentCell == null)
            {
                MessageBox.Show("Please select a row first.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowIndex = dgViewAddingMultipleProductVariants.CurrentCell.RowIndex;
            var selectedRow = dgViewAddingMultipleProductVariants.Rows[rowIndex];

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;"
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                var imageStream = new MemoryStream();
                Image originalImage = Image.FromFile(openFileDialog.FileName);
                originalImage.Save(imageStream, originalImage.RawFormat); // Save image to memory stream
                byte[] imageBytes = imageStream.ToArray(); // Convert to byte array

                // Store the imageBytes in the ImagePathColumn (which should be a BLOB type in your database)
                selectedRow.Cells["ImagePathColumn"].Value = imageBytes;

                // Optionally, display a resized image in the DataGridView cell
                Image resizedImage = new Bitmap(originalImage, new Size(48, 48));
                selectedRow.Cells["ColumnImage"].Value = resizedImage;

                dgViewAddingMultipleProductVariants.Columns["ImagePathColumn"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error uploading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        // Event to handle Row Added event, to ensure consistent formatting or behavior
        private void DgViewAddingMultipleProductVariants_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // Set default values or behavior when a new row is added
   
        }

        // Cancel button to close the form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Save button to handle saving all variants
        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgViewAddingMultipleProductVariants.Rows)
            {
                if (row.IsNewRow) continue;

                string variantName = row.Cells[VariantName.Index].Value?.ToString();
                string size = row.Cells[ColumnSize.Index].Value?.ToString();
                decimal price = Convert.ToDecimal(row.Cells[ColumnPrice.Index].Value ?? 0);
                string ingredients = row.Cells[ColumnIngredients.Index].Value?.ToString();
                string instructions = row.Cells[ColumnInstructions.Index].Value?.ToString();
                Image image = row.Cells[ColumnImage.Index].Value as Image;


 
            }

            Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PopulateIngredientsList()
        {
            var ingredients = _inventoryService.GetAllIngredients()
                                               .Where(i => !i.IsAddOn.Value) // Filter out add-ons
                                               .ToList();

            var columnHeaders = new List<string> { "Ingredient", "ID", "Measuring Unit" };

            DataGridViewHelper.PopulateListView(
                listViewIngredients,
                ingredients,
                columnHeaders,
                330,
                ingredient => new List<string>
                {
            ingredient.IngredientName,
            ingredient.IngredientID.ToString(),
            ingredient.MeasuringUnit
                }
            );
        }



        private void flowLayoutPanelDgViews_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgViewAddingMultipleProductVariants_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Ensure the clicked cell and row are valid
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                {
                    // Check if the clicked cell is in the Action column
                    var actionColumn = dgViewAddingMultipleProductVariants.Columns["Action"];
                    if (actionColumn != null && e.ColumnIndex == actionColumn.Index)
                    {
                        // Get the clicked row
                        var clickedRow = dgViewAddingMultipleProductVariants.Rows[e.RowIndex];
                        if (clickedRow != null && clickedRow.Cells["VariantName"]?.Value != null)
                        {
                            // Retrieve the VariantName from the clicked row
                            string variantName = clickedRow.Cells["VariantName"].Value.ToString();

                            // Update the label header with the variant name
                            lblHeader.TextAlign = ContentAlignment.MiddleCenter; // Align the text to the center
                            lblHeader.Text = $"Adding Ingredients to row of {variantName}";

                            // Make the ingredient selection components visible
                            listViewIngredients.Visible = true;
                            textBoxSearchIngredients.Visible = true;
                            pbSearch.Visible = true;
                            btnUndoRecentlyAddedIngredients.Visible = true;

                            numericUpDownIngredientsQuantity.Visible = true;
                            btnAddIngredientsToDgView.Visible = true;
                            buttonCloseIngredientsList.Visible = true;
                            btnUploadImgToSelectedRow.Visible = false;
                            buttonAddNewRow.Visible = false;
                            btnDelete.Visible = false;
                            btnDuplicateRow.Visible = false;

                            // Optionally, store the selected row index
                            selectedRowIndex = e.RowIndex;

                            // Deselect any previously selected row
                            foreach (DataGridViewRow row in dgViewAddingMultipleProductVariants.Rows)
                            {
                                row.Selected = false;
                            }

                            // Select the clicked row
                            clickedRow.Selected = true;
                        }
                        else
                        {
                            MessageBox.Show("Variant name is missing or invalid in the selected row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message to the user
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string previousIngredients = ""; // Store the previous ingredients (for undo)

        private void btnAddIngredientsToDgView_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex >= 0)
            {
                // Get the selected ingredients from the ListView
                var selectedIngredients = listViewIngredients.SelectedItems.Cast<ListViewItem>().ToList();

                if (selectedIngredients.Any())
                {
                    // Get the current ingredients in the selected row of the DataGridView
                    string currentIngredients = dgViewAddingMultipleProductVariants.Rows[selectedRowIndex].Cells["ColumnIngredients"].Value?.ToString();

                    // Store the current ingredients before adding new ones (for undo purpose)
                    previousIngredients = currentIngredients;

                    // Initialize a list to store the added ingredients for the popup message
                    List<string> addedIngredients = new List<string>();

                    // Iterate through each selected ingredient and add to the current ingredients list
                    foreach (var selectedIngredient in selectedIngredients)
                    {
                        string ingredientName = selectedIngredient.SubItems[0].Text; // Ingredient name
                        string measuringUnit = selectedIngredient.SubItems[2].Text; // Measuring unit (e.g., grams, liters, etc.)
                        decimal quantity = numericUpDownIngredientsQuantity.Value;

                        // Format the ingredient with quantity and measuring unit
                        string ingredientWithQuantity = $"{ingredientName} {quantity} {measuringUnit}";

                        // Append or set the ingredients cell
                        if (!string.IsNullOrEmpty(currentIngredients))
                        {
                            currentIngredients += $", {ingredientWithQuantity}";
                        }
                        else
                        {
                            currentIngredients = ingredientWithQuantity;
                        }

                        // Add the ingredient to the list for the popup message
                        addedIngredients.Add(ingredientWithQuantity);
                    }

                    // Update the DataGridView cell with the new ingredients list
                    dgViewAddingMultipleProductVariants.Rows[selectedRowIndex].Cells["ColumnIngredients"].Value = currentIngredients;

                    // Clear the quantity input after adding the ingredients
                    numericUpDownIngredientsQuantity.Value = numericUpDownIngredientsQuantity.Minimum;

                    // Optionally, clear the ListView selection after adding
                    listViewIngredients.SelectedItems.Clear();

                    // Create a message to show in the popup including ingredient details
                    string addedIngredientsMessage = string.Join(Environment.NewLine, addedIngredients);

                    // Show a popup message to confirm the ingredients were added
                    MessageBox.Show($"Ingredients added successfully:\n\n{addedIngredientsMessage}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }




        private void textBoxSearchIngredients_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = textBoxSearchIngredients.Text.ToLower();

            // Filter ListView items based on search term
            listViewIngredients.Items.Clear();
            var filteredIngredients = _inventoryService.GetAllIngredients()
                                                       .Where(i => i.IngredientName.ToLower().Contains(searchTerm) && !i.IsAddOn.GetValueOrDefault())
                                                       .ToList();
            foreach (var ingredient in filteredIngredients)
            {
                ListViewItem item = new ListViewItem(ingredient.IngredientName); // The name of the ingredient
                item.SubItems.Add(ingredient.IngredientID.ToString()); // Add the ingredient ID (or any other details you need)
                item.SubItems.Add(ingredient.MeasuringUnit); // Add the measuring unit (e.g., g, ml, etc.)

                // Add the item to the ListView
                listViewIngredients.Items.Add(item);
            }
        }


        private void buttonCloseIngredientsList_Click(object sender, EventArgs e)
        {
            // Change the lblHeader text to "Add Product Variant"
            lblHeader.Text = "Add Product Variant";

            // Hide the ingredient selection components
            listViewIngredients.Visible = false;
            textBoxSearchIngredients.Visible = false;
            pbSearch.Visible = false;
            numericUpDownIngredientsQuantity.Visible = false;
            btnAddIngredientsToDgView.Visible = false;
            buttonCloseIngredientsList.Visible = false;

            // Show the button to upload an image again (or any other necessary UI components)
            btnUploadImgToSelectedRow.Visible = true;
            buttonAddNewRow.Visible = true;
            btnDelete.Visible = true;
            btnDuplicateRow.Visible = true;


            btnUndoRecentlyAddedIngredients.Visible = false;

        }


        private void PopulateTestData()
        {
            // Clear any existing rows
            dgViewAddingMultipleProductVariants.Rows.Clear();

            // Test Case 1: Valid Product Variants
            dgViewAddingMultipleProductVariants.Rows.Add("Vanilla Ice Cream", "Large", 4.99m, "Milk 1 liter, Sugar 0.5 kg", "Freeze for 2 hours", "C:\\Images\\vanilla.jpg");
            dgViewAddingMultipleProductVariants.Rows.Add("Chocolate Ice Cream", "Medium", 5.99m, "Milk 1 liter, Cocoa 0.3 kg, Sugar 0.5 kg", "Stir and freeze", "C:\\Images\\chocolate.jpg");

   /*         // Test Case 2: Missing Mandatory Fields
            dgViewAddingMultipleProductVariants.Rows.Add("", "Small", 3.99m, "Milk 1 liter, Sugar 0.3 kg", "Blend and freeze", "C:\\Images\\default.jpg"); // Missing Variant Name
            dgViewAddingMultipleProductVariants.Rows.Add("Strawberry Ice Cream", "", 5.49m, "Milk 1 liter, Strawberries 0.5 kg, Sugar 0.5 kg", "Mix and freeze", "C:\\Images\\strawberry.jpg"); // Missing Size

            // Test Case 3: Empty Rows
            dgViewAddingMultipleProductVariants.Rows.Add("", "", 0, "", "", ""); // Completely empty row

            // Test Case 4: Invalid Price Value
            dgViewAddingMultipleProductVariants.Rows.Add("Blueberry Ice Cream", "Large", "InvalidNumber", "Milk 1 liter, Blueberries 0.5 kg, Sugar 0.5 kg", "Churn and freeze", "C:\\Images\\blueberry.jpg");

            // Test Case 5: Ingredients Parsing Error
            dgViewAddingMultipleProductVariants.Rows.Add("Mango Sorbet", "Medium", 4.99m, "Mango 1 , Sugar , Water", "Blend and chill", "C:\\Images\\mango.jpg");

            // Test Case 6: Valid with Minimal Data
            dgViewAddingMultipleProductVariants.Rows.Add("Lemon Sorbet", "Small", 3.50m, "", "", ""); // No ingredients or instructions

            // Test Case 7: Image Path Errors
            dgViewAddingMultipleProductVariants.Rows.Add("Mint Ice Cream", "Medium", 5.25m, "Milk 1 liter, Mint 0.2 kg, Sugar 0.5 kg", "Mix and freeze", "InvalidPath\\mint.jpg");*/
        }


        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            List<ProductVariant> productVariantsToSave = new List<ProductVariant>();
            List<ProductVariantIngredient> productVariantIngredientsToSave = new List<ProductVariantIngredient>();

            foreach (DataGridViewRow row in dgViewAddingMultipleProductVariants.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string variantName = row.Cells[VariantName.Index].Value?.ToString();
                string size = row.Cells[ColumnSize.Index].Value?.ToString();
                decimal price = Convert.ToDecimal(row.Cells[ColumnPrice.Index].Value ?? 0);
                string ingredients = row.Cells[ColumnIngredients.Index].Value?.ToString();
                string instructions = row.Cells[ColumnInstructions.Index].Value?.ToString();
                string selectedProductName = row.Cells[ColumnProduct.Index].Value?.ToString();
                byte[] imageData = (byte[])row.Cells["ImagePathColumn"].Value;

                if (string.IsNullOrWhiteSpace(selectedProductName))
                {
                    MessageBox.Show("Please select a valid product.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int productId = _productsService.GetProductIdByName(selectedProductName);

                if (string.IsNullOrWhiteSpace(variantName) || string.IsNullOrWhiteSpace(size))
                {
                    MessageBox.Show("Please fill out all required fields (Variant Name, Size).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ProductVariant productVariant = new ProductVariant
                {
                    VariantName = variantName,
                    ProductID = productId,
                    Size = size,
                    Price = price,
                    Ingredients = ingredients,
                    Instructions = instructions,
                    ImagePath = imageData // Directly store the byte array
                };

                productVariantsToSave.Add(productVariant);

                if (!string.IsNullOrWhiteSpace(ingredients))
                {
                    var ingredientList = ingredients.Split(',');

                    foreach (var ingredient in ingredientList)
                    {
                        var ingredientTrimmed = ingredient.Trim();
                        var match = Regex.Match(ingredientTrimmed, @"^(.+?)\s+(\d+(\.\d+)?)\s+(\S+)$");

                        if (match.Success)
                        {
                            string ingredientName = match.Groups[1].Value;
                            decimal quantity = Convert.ToDecimal(match.Groups[2].Value);
                            string measuringUnit = match.Groups[4].Value;
                            int ingredientId = _inventoryService.GetIngredientIdByName(ingredientName);

                            ProductVariantIngredient productVariantIngredient = new ProductVariantIngredient
                            {
                                // Assuming GetNextProductVariantId returns the correct ID for the current variant
                                ProductVariantID = _productsService.GetNextProductVariantId(),
                                IngredientID = ingredientId,
                                QuantityPerVariant = quantity,
                                MeasuringUnit = measuringUnit
                            };

                            productVariantIngredientsToSave.Add(productVariantIngredient);
                        }
                        else
                        {
                            MessageBox.Show($"Invalid ingredient format: {ingredientTrimmed}. Expected format: 'IngredientName Quantity MeasuringUnit'.", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }

            try
            {
                _productsService.AddMultipleProductVariants(productVariantsToSave);

                foreach (var productVariant in productVariantsToSave)
                {
                    foreach (var ingredient in productVariantIngredientsToSave)
                    {
                        ingredient.ProductVariantID = productVariant.ProductVariantID;
                        _productsService.AddProductVariantIngredient(ingredient);
                    }
                }

                MessageBox.Show("All product variants have been saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving product variants: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnUndoRecentlyAddedIngredients_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex >= 0)
            {
                // Restore the previous ingredients value
                dgViewAddingMultipleProductVariants.Rows[selectedRowIndex].Cells["ColumnIngredients"].Value = previousIngredients;

                // Optionally, you can clear the previous ingredients value after undo
                previousIngredients = "";
            }
        }
        private void ClearIngredientsInSelectedRowIndex(int selectedRowIndex)
        {
            if (selectedRowIndex >= 0 && selectedRowIndex < dgViewAddingMultipleProductVariants.Rows.Count)
            {
                var selectedRow = dgViewAddingMultipleProductVariants.Rows[selectedRowIndex];
                selectedRow.Cells["ColumnIngredients"].Value = string.Empty;
            }
        }

    }
}
