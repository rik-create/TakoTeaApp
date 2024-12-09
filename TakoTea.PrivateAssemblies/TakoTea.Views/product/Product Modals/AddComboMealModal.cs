using Helpers;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Helpers;
using TakoTea.Interfaces;
using TakoTea.Models;
using TakoTea.Services;

namespace TakoTea.View.Product.Product_Modals
{
    public partial class AddComboMealModal : MaterialForm
    {


        ProductsService productsService;
        private Entities context;
        public AddComboMealModal()
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            ModalSettingsConfigurator.ApplyStandardModalSettings(this);
            context = new Entities();
            DataGridViewHelper.FormatListView(listViewProductVariants);
            DataGridViewHelper.ApplyDataGridViewStyles(dgViewAddComboMeal);
            productsService = new ProductsService(context);

            btnSaveCombomeal.BackColor = ThemeConfigurator.GetCustomAccentColor();
        }

        private void AddComboMealModal_Load(object sender, EventArgs e)
        {
            // Set all columns as read-only except for Quantity column
            foreach (DataGridViewColumn column in dgViewAddComboMeal.Columns)
            {
                column.ReadOnly = true; // Make all columns read-only
            }
            dgViewAddComboMeal.Columns["Quantity"].ReadOnly = false; // Make Quantity column editable

            PopulateVariantList();

        }

        private void PopulateVariantList()
        {
            // Get the list of ingredients from the productsService
            var variants = productsService.GetAllProductVariants();

            // Define column headers for the ListView
            var columnHeaders = new List<string> { "Variant", "ID", "Size", "Price" };

            // Use the reusable helper method
            DataGridViewHelper.PopulateListView(
                listViewProductVariants,
                variants,
                columnHeaders, 209,
                ingredient => new List<string>
                {
            ingredient.VariantName,
            ingredient.ProductVariantID.ToString(),
            ingredient.Size,
            ingredient.Price.ToString()
                }
            );
        }



        // Button click to open SelectVariantModal and add selected variants
        private void btnAddNewVariant_Click(object sender, EventArgs e)
        {
            using (SelectVariantModal selectVariantModal = new SelectVariantModal())
            {
                // Open the SelectVariantModal as a dialog and check if variants were selected
                if (selectVariantModal.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected variants from the modal
                    var selectedVariants = selectVariantModal.SelectedVariants;

                    // Add each selected variant to the DataGridView
                    foreach (var variant in selectedVariants)
                    {
                        int rowIndex = dgViewAddComboMeal.Rows.Add();
                        var row = dgViewAddComboMeal.Rows[rowIndex];

                        // Populate the row with the variant's details
                        row.Cells["ColumnVarName"].Value = variant.VariantName;
                        row.Cells["ColumnSize"].Value = variant.Size;
                        row.Cells["ColumnPrice"].Value = variant.Price;
                        row.Cells["Quantity"].Value = 1; // Default Quantity is 1
                    }
                }
            }
        }

        // Event to handle the Duplicate Row functionality
        private void btnDuplicateRow_Click(object sender, EventArgs e)
        {
            if (dgViewAddComboMeal.SelectedRows.Count > 0)
            {
                var selectedRow = dgViewAddComboMeal.SelectedRows[0];
                var newRow = (DataGridViewRow)selectedRow.Clone();

                // Copy all cell values from the selected row to the new row
                for (int i = 0; i < selectedRow.Cells.Count; i++)
                {
                    newRow.Cells[i].Value = selectedRow.Cells[i].Value;
                }

                // Add the new row to the DataGridView
                dgViewAddComboMeal.Rows.Add(newRow);
            }
        }

        // Event to handle the Delete Row functionality
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {

    

            // Update the base price label

            // Update the discounted price based on the new base price
            if (dgViewAddComboMeal.SelectedRows.Count > 0)
            {
         

                foreach (DataGridViewRow selectedRow in dgViewAddComboMeal.SelectedRows)
                {
                    // Ensure the row isn't the last row (so we don't delete all rows)
                    if (!selectedRow.IsNewRow)
                    {
                        
                        dgViewAddComboMeal.Rows.RemoveAt(selectedRow.Index);
                    }
                }

                decimal basePrice = 0;

                // Loop through each row in the DataGridView to calculate the base price
                foreach (DataGridViewRow row in dgViewAddComboMeal.Rows)
                {
                    if (row.Cells["ColumnPrice"].Value != null && row.Cells["Quantity"].Value != null)
                    {
                        decimal price = Convert.ToDecimal(row.Cells["ColumnPrice"].Value);
                        decimal quantity = Convert.ToDecimal(row.Cells["Quantity"].Value);

                        // Add the price * quantity to the base price
                        basePrice += price * quantity;
                    }
                }
                // Subtract the deleted rows' total price from the base price

                lblBasePrice.Text = $"Base Price: {basePrice:C}";  // Format as currency

                UpdateDiscountedPrice(basePrice); // Update discounted price based on new base price
                UpdateTotalVariantsLabel(); // Update the total variants label
            }
        }

        private void btnChooseProductVariant_Click(object sender, EventArgs e)
        {
            listViewProductVariants.Visible = true;
            textBoxSearchVariants.Visible = true;
            btnAddVariantToDgView.Visible = true;
            buttonCloseIngredientsList.Visible = true;
            btnChooseProductVariant.Visible = false;
            numericUpDownVariantQuantity.Visible = true;
            btnUndo.Visible = true;


        }

        private void buttonCloseIngredientsList_Click(object sender, EventArgs e)
        {

            // Hide the ingredient selection components
            listViewProductVariants.Visible = false;
            textBoxSearchVariants.Visible = false;
            btnAddVariantToDgView.Visible = false;
            buttonCloseIngredientsList.Visible = false;
            numericUpDownVariantQuantity.Visible = false;
            btnUndo.Visible = false;

            // Show the button to upload an image again (or any other necessary UI components)
            btnChooseProductVariant.Visible = true;
        }

    

  
        private void pbSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgViewAddComboMeal.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow selectedRow in dgViewAddComboMeal.SelectedRows)
                {
                    // Ensure the row isn't the last row (so we don't delete all rows)
                    if (!selectedRow.IsNewRow)
                    {
                        dgViewAddComboMeal.Rows.RemoveAt(selectedRow.Index);
                    }
                }
            }
        }



        // Call this function when needed, for example when a button is clicked
        private void btnAddSelectedVariants_Click(object sender, EventArgs e)
        {
            AddSelectedVariantsToDataGridView();
           
        }

        // Method to clear the form
        private void ClearForm()
        {
            // Clear the TextBox for the combo meal name
            txtBoxComboMealName.Clear();

            // Clear the image from the PictureBox and reset its Tag property
            pbComboMealImage.Image = null;
            pbComboMealImage.Tag = null;

            // Reset the numeric up/down controls
            numericUpDownDiscountPercent.Value = numericUpDownDiscountPercent.Minimum; // Reset to minimum value
            numericUpDownVariantQuantity.Value = numericUpDownVariantQuantity.Minimum; // Reset to minimum value

            // Clear the DataGridView for selected variants
            dgViewAddComboMeal.Rows.Clear();

            // Deselect all items in the ListView
            foreach (ListViewItem item in listViewProductVariants.Items)
            {
                item.Selected = false;
            }

            // Reset labels for total variants, base price, and discounted price
            lblTotalVariantsInDg.Text = $"Total Variants: {0}"; // Default text or value
            lblBasePrice.Text = "0.00";      // Default base price
            lblDiscountedPrice.Text = "0.00"; // Default discounted price

            // Optionally show a message to confirm the form was cleared
            MessageBox.Show("Form has been cleared.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private async void textBoxSearchVariants_TextChanged(object sender, EventArgs e)
        {
            await Task.Delay(1100); // Add a delay of 500 milliseconds

            string searchTerm = textBoxSearchVariants.Text.ToLower();

            // Clear existing items in the ListView
            listViewProductVariants.Items.Clear();

            // Get the filtered list of product variants
            var filteredVariants = productsService.GetAllProductVariants()
                .Where(variant => variant.VariantName.ToLower().Contains(searchTerm) ||
                                  variant.Size.ToLower().Contains(searchTerm) ||
                                  variant.Price.ToString().Contains(searchTerm)) // You can extend this to other fields
                .ToList();

            // Add the filtered variants to the ListView
            foreach (var variant in filteredVariants)
            {
                ListViewItem item = new ListViewItem(variant.VariantName); // The name of the variant
                item.SubItems.Add(variant.ProductVariantID.ToString()); // Add the variant ID (or any other details)
                item.SubItems.Add(variant.Size); // Add the size
                item.SubItems.Add(variant.Price.ToString()); // Add the price

                // Add the item to the ListView
                listViewProductVariants.Items.Add(item);
            }
        }

        // Stack to store the recently added variants for undo functionality
        private Stack<(string VariantName, decimal Quantity)> recentlyAddedVariants = new Stack<(string, decimal)>();

        private void AddSelectedVariantsToDataGridView()
        {
            decimal totalPrice = 0; // Initialize total price to 0
            List<string> addedVariants = new List<string>();
            decimal quantity = numericUpDownVariantQuantity.Value;

            // Get the current base price (if any)
            decimal currentBasePrice = 0;
            if (decimal.TryParse(lblBasePrice.Text.Replace("Base Price: ", "").Replace("₱", "").Trim(), out decimal parsedPrice))
            {
                currentBasePrice = parsedPrice;
            }

            foreach (ListViewItem selectedItem in listViewProductVariants.SelectedItems)
            {
                string variantName = selectedItem.SubItems[0].Text;
                string variantId = selectedItem.SubItems[1].Text;
                string size = selectedItem.SubItems[2].Text;
                string priceString = selectedItem.SubItems[3].Text;
                decimal price = decimal.Parse(priceString);

                // Check if the variant ID already exists in the DataGridView
                bool variantExists = false;
                foreach (DataGridViewRow row in dgViewAddComboMeal.Rows)
                {
                    if (row.Cells[0].Value?.ToString() == variantId) // Assuming VariantID is in the 1st column (index 0)
                    {
                        // Update the quantity in the existing row
                        int currentQuantity = int.Parse(row.Cells[4].Value.ToString()); // Assuming Quantity is in the 5th column (index 4)
                        row.Cells[4].Value = currentQuantity + quantity;

                        totalPrice += price * quantity; // Add the price for the additional quantity
                        addedVariants.Add($"{variantName} (Quantity: +{quantity})"); // Indicate quantity increase in the message
                        variantExists = true;
                        break;
                    }
                }

                if (!variantExists)
                {
                    // If the variant doesn't exist, add a new row
                    AddVariantToComboMealGrid(variantName, variantId, size, priceString, quantity);
                    addedVariants.Add($"{variantName} (Quantity: {quantity})");
                    recentlyAddedVariants.Push((variantName, quantity));
                    totalPrice += price * quantity;
                }
            }

            totalPrice += currentBasePrice;
            lblBasePrice.Text = $"Base Price: {totalPrice:C}";
            UpdateDiscountedPrice(totalPrice);
            UpdateTotalVariantsLabel();

        }
        private void UpdateDiscountedPrice(decimal basePrice)
        {
            // Get the discount percentage from numericUpDownDiscountPercent
            decimal discountPercent = numericUpDownDiscountPercent.Value;

            // Calculate the discounted price
            decimal discountedPrice = basePrice - (basePrice * (discountPercent / 100));

            // Update the discounted price label
            lblDiscountedPrice.Text = $"Discounted Price: {discountedPrice:C}";  // Format as currency
        }


        private void UpdateTotalVariantsLabel()
        {
            int totalVariants = dgViewAddComboMeal.Rows.Count - 1;
            lblTotalVariantsInDg.Text = $"Total Variants: {totalVariants}";
        }

        // Method to add a single variant to the Combo Meal DataGridView
        private void AddVariantToComboMealGrid(string variantName, string variantId, string size, string price, decimal quantity)
        {
            // Add a new row to the DataGridView
            int rowIndex = dgViewAddComboMeal.Rows.Add();

            // Fill the row with the variant data
            dgViewAddComboMeal.Rows[rowIndex].Cells["ColumnVarName"].Value = variantName;
            dgViewAddComboMeal.Rows[rowIndex].Cells["ColumnSize"].Value = size;
            dgViewAddComboMeal.Rows[rowIndex].Cells["ColumnPrice"].Value = price;
            dgViewAddComboMeal.Rows[rowIndex].Cells["VariantID"].Value = variantId;


            // Optionally, you can set default values like Quantity here
            dgViewAddComboMeal.Rows[rowIndex].Cells["Quantity"].Value = quantity; // Default quantity
        }

        // Undo functionality to remove the most recently added variant
        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (recentlyAddedVariants.Any())
            {
                // Pop the last added variant from the stack
                var lastAdded = recentlyAddedVariants.Pop();

                // Find the row corresponding to the removed variant
                foreach (DataGridViewRow row in dgViewAddComboMeal.Rows)
                {
                    // Check if the variant name matches
                    if (row.Cells["ColumnVarName"].Value?.ToString() == lastAdded.VariantName)
                    {
                        // Remove the row from the DataGridView
                        dgViewAddComboMeal.Rows.RemoveAt(row.Index);
                        break;
                    }
                }


                decimal basePrice = 0;

                // Loop through each row in the DataGridView to calculate the base price
                foreach (DataGridViewRow row in dgViewAddComboMeal.Rows)
                {
                    if (row.Cells["ColumnPrice"].Value != null && row.Cells["Quantity"].Value != null)
                    {
                        decimal price = Convert.ToDecimal(row.Cells["ColumnPrice"].Value);
                        decimal quantity = Convert.ToDecimal(row.Cells["Quantity"].Value);

                        // Add the price * quantity to the base price
                        basePrice += price * quantity;
                    }
                }
                // Subtract the deleted rows' total price from the base price

                lblBasePrice.Text = $"Base Price: {basePrice:C}";  // Format as currency

                UpdateDiscountedPrice(basePrice); // Update discounted price based on new base price
                UpdateTotalVariantsLabel(); // Update the total variants label
                // Optional: Notify the user about the undo operation
                MessageBox.Show($"Variant {lastAdded.VariantName} (Quantity: {lastAdded.Quantity}) removed.", "Undo Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No variants to undo.", "Undo Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

 

        private void numericUpDownDiscountPercent_ValueChanged_1(object sender, EventArgs e)
        {
            decimal basePrice = 0;

            // Loop through each row in the DataGridView to calculate the base price
            foreach (DataGridViewRow row in dgViewAddComboMeal.Rows)
            {
                if (row.Cells["ColumnPrice"].Value != null && row.Cells["Quantity"].Value != null)
                {
                    decimal price = Convert.ToDecimal(row.Cells["ColumnPrice"].Value);
                    decimal quantity = Convert.ToDecimal(row.Cells["Quantity"].Value);

                    // Add the price * quantity to the base price
                    basePrice += price * quantity;
                }
            }

            // Update the base price label
            lblBasePrice.Text = $"Base Price: {basePrice:C}";  // Format as currency

            // Update the discounted price based on the new base price
            UpdateDiscountedPrice(basePrice);
        }
        private void btnSaveCombomeal_Click(object sender, EventArgs e)
        {
            try
            {
                // Extract values from the form controls
                string comboMealName = txtBoxComboMealName.Text.Trim();
                decimal discountPercent = numericUpDownDiscountPercent.Value;

                // Validate inputs
                if (string.IsNullOrEmpty(comboMealName))
                {
                    MessageBox.Show("Combo meal name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (pbComboMealImage.Tag == null || string.IsNullOrEmpty(pbComboMealImage.Tag.ToString()))
                {
                    MessageBox.Show("Please add an image for the combo meal.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string imagePath = pbComboMealImage.Tag.ToString();

                // Calculate the base price (sum of all variant prices)
                decimal basePrice = 0;
                List<(int VariantID, string VariantName, decimal Price, int Quantity)> variantDetails = new List<(int, string, decimal, int)>();

                foreach (DataGridViewRow row in dgViewAddComboMeal.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        int variantID = Convert.ToInt32(row.Cells["VariantID"].Value);
                        string variantName = row.Cells["ColumnVarName"].Value.ToString();
                        decimal variantPrice = Convert.ToDecimal(row.Cells["ColumnPrice"].Value);
                        int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);

                        basePrice += variantPrice * quantity; // Multiply price by quantity for total
                        variantDetails.Add((variantID, variantName, variantPrice, quantity));
                    }
                }

                if (variantDetails.Count == 0)
                {
                    MessageBox.Show("No variants added to the combo meal.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal discountedPrice = basePrice - (basePrice * (discountPercent / 100));

                // Create a new ComboMeal object
                ComboMeal newComboMeal = new ComboMeal
                {
                    ComboMealName = comboMealName,
                    DiscountPercent = discountPercent,
                    DiscountedPrice = discountedPrice,
                    ImagePath = ImageHelper.ImageToByteArray(pbComboMealImage.Image), // Assuming you have the image in a PictureBox
                    CreatedAt = DateTime.Now,
                    CreatedBy = AuthenticationHelper._loggedInUsername
                };

                productsService.AddComboMeal(newComboMeal);

                // Save the combo meal
                int newComboMealID = productsService.GetNewComboMealID(newComboMeal.ComboMealName);

                // Save the variants related to this combo meal
                foreach (var (VariantID, VariantName, Price, Quantity) in variantDetails)
                {
                    ComboMealVariant newComboMealVariant = new ComboMealVariant
                    {
                        ComboMealID = newComboMealID,
                        VariantName = VariantName,
                        Price = Price,
                        Quantity = Quantity,
                        ProductVariantID = VariantID
                    };

                    productsService.AddComboMealVariant(newComboMealVariant);

                   
                }
                // Log the change
                LoggingHelper.LogChange(
                    "ComboMeal",                // Table name
                    newComboMeal.ComboMealID, // Record ID
                    "New Combo Meal",           // Column name
                    null,                               // Old value
                    "",     // New value
                    "Added",                            // Action
                    $"Combo meal '{newComboMeal.ComboMealName}", ""  // Description
                );
                // Success message
                MessageBox.Show("Combo meal saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the form after saving
                ClearForm();
            }
            catch (Exception ex)
            {
                // Handle any errors
                MessageBox.Show($"Error saving combo meal: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAddImage_Click(object sender, EventArgs e)
        {
            // Create an OpenFileDialog to allow the user to select an image file
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Set filter to allow image files only
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

                // Show the dialog and check if the user selected a file
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected file's path
                    string imagePath = openFileDialog.FileName;

                    // Set the image to the PictureBox control
                    pbComboMealImage.Image = Image.FromFile(imagePath);

                    // Store the image path in the Tag property of the PictureBox
                    pbComboMealImage.Tag = imagePath;
                }
            }
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            // Check if there is an image to remove
            if (pbComboMealImage.Image != null)
            {
                // Clear the image from the PictureBox
                pbComboMealImage.Image = null;

                // Reset the Tag property (image path) to null
                pbComboMealImage.Tag = null;
            }
            else
            {
                // Notify the user if no image is set
                MessageBox.Show("No image to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtBoxComboMealName_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTotalVariantsInDg_Click(object sender, EventArgs e)
        {

        }
    }
}
