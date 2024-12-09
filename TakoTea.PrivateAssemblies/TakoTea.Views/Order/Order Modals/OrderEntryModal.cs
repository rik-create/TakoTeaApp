using MaterialSkin.Controls;
using System.Windows.Forms;
using System;
using TakoTea.Configurations;
using TakoTea.Models;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using TakoTea.Controls;
using TakoTea.View.Orders;
using TakoTea.Services;
namespace TakoTea.Views.Order.Order_Modals
{
    public partial class OrderEntryModal : MaterialForm
    {

        public bool AddToDgViewOrderListClicked { get; set; } = false;

        private readonly Entities _context;
        //TODO : handle addons feautures and determine the price base on selected size and selected addons
        private DataGridView parentDataGridView;
        string initialPrice = "0";

        public OrderEntryModal(DataGridView dataGridView)
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            ModalSettingsConfigurator.ApplyStandardModalSettings(this);
            parentDataGridView = dataGridView;
            _context = new Entities();
            // In your OrderEntryModal constructor or InitializeComponent method:

            // ... other initialization code ...

            cmbSizes.SelectedIndexChanged += cmbSizes_SelectedIndexChanged;
            chckListBoxAddOns.ItemCheck += chckListBoxAddOns_ItemCheck;

            chckListBoxAddOns.CheckOnClick = true;
            numericUpDownQuantity.Minimum = 0;
            // ... rest of the code ...

        }
        // ... (other code) ...

        private void cmbSizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();
            CheckIfProductExistsInOrderList();
        }

        private void chckListBoxAddOns_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // BeginInvoke is used to execute UpdateTotalPrice after the ItemCheck event is finished
            this.BeginInvoke(new Action(() => UpdateTotalPrice()));
        }

        // ... (rest of the code) ...


        private void PopulateAddOns(string productName)
        {
            // Fetch add-ons from the database that have matching batches with StockLevel > 0 and match the product name
            var addOns = _context.AddOns
                .Where(a => a.IngredientID != null &&
                            _context.Batches.Any(b => b.IngredientID == a.IngredientID && b.StockLevel > 0) &&
                            a.Product.ProductName == productName)
                .ToList();

            // Clear existing items in the CheckedListBox
            chckListBoxAddOns.Items.Clear();

            // Add each eligible add-on to the CheckedListBox
            foreach (var addOn in addOns)
            {
                string displayText = $"{addOn.AddOnName} - {addOn.AdditionalPrice:F2}";
                chckListBoxAddOns.Items.Add(displayText);
            }
        }

        public static List<(string Size, decimal Price)> GetSizesAndPricesByVariantName(string variantName)
        {
            using (var dbContext = new Entities()) // Replace with your actual DbContext
            {
                // Find all product variants with the matching name
                var productVariants = dbContext.ProductVariants
                    .Where(pv => pv.VariantName == variantName)
                    .Select(pv => new { pv.Size, pv.Price }) // Select only the required fields
                    .ToList();

                // Map the results to a list of tuples
                var results = productVariants
                    .Select(pv => (pv.Size, pv.Price))
                    .ToList();

                return results;
            }
        }

        public void SetComboMealData(ComboMeal comboMeal)
        {
            if (comboMeal != null)
            {
                productCard.titleLabel.Text = comboMeal.ComboMealName;
                numericUpDownQuantity.Value = 1;

                // ... (Image loading for comboMeal, if needed) ...

                // Hide size and add-on controls
                cmbSizes.Visible = false;
                chckListBoxAddOns.Visible = false;
                lblAddons.Visible = false;
                lvlSizes.Visible = false;

                // Set the total price to the combo meal's discounted price
                lblTotalPrice.Text = $"₱{comboMeal.DiscountedPrice:F2}";
                initialPrice = comboMeal.DiscountedPrice.ToString();
            }
        }
        public void SetProductData(ProductVariant productVariant)
        {
            if (productVariant != null)
            {
                // Set product details
                productCard.titleLabel.Text = productVariant.VariantName;
                numericUpDownQuantity.Value = 1;

                // Set product image (handling blob data)
                if (productVariant.ImagePath?.Length > 0)
                {
                    try
                    {
                         MemoryStream ms = new MemoryStream(productVariant.ImagePath);
                        productCard.pictureBoxProductIcon.Image = Image.FromStream(ms);
                        productCard.pictureBoxProductIcon.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to load image: {ex.Message}");
                        // Consider setting a default image or handling the error appropriately
                    }
                }
                else
                {
                    productCard.pictureBoxProductIcon.Image = Properties.Resources.multiply;
                }

                // Fetch and populate sizes
                var sizesAndPrices = GetSizesAndPricesByVariantName(productVariant.VariantName);
                cmbSizes.Items.Clear();
                foreach (var sizePrice in sizesAndPrices)
                {
                    cmbSizes.Items.Add($"{sizePrice.Size} - ₱{sizePrice.Price:F2}");
                }

                if (cmbSizes.Items.Count > 0)
                {
                    cmbSizes.SelectedIndex = 0;
                }
                string productName = (new ProductsService(_context)).GetProductNameById(productVariant.ProductID);
                // Populate add-ons
                PopulateAddOns(productName);

                // Update total price
                UpdateTotalPrice();
            }
        }



        private void UpdateTotalPrice()

        {

            decimal price = 0;



            // Get price from selected size


            if (!cmbSizes.Visible)
            {
                price = decimal.Parse(initialPrice);
            }

            if (cmbSizes.SelectedItem != null)

            {
                price = 0;
                string selectedSizeWithPrice = cmbSizes.SelectedItem.ToString();

                string[] parts = selectedSizeWithPrice.Split(new[] { " - ₱" }, StringSplitOptions.None);

                if (parts.Length == 2 && decimal.TryParse(parts[1], out decimal sizePrice))

                {

                    price += sizePrice;

                }

            }



            // Add prices from selected add-ons

            foreach (var item in chckListBoxAddOns.CheckedItems)

            {

                string addOnWithPrice = item.ToString();

                string[] parts = addOnWithPrice.Split(new[] { " - " }, StringSplitOptions.None);

                if (parts.Length == 2 && decimal.TryParse(parts[1], out decimal addOnPrice))

                {

                    price += addOnPrice;

                }

            }



            // Calculate total price including quantity

            lblTotalPrice.Text = $"₱{(price * numericUpDownQuantity.Value):F2}";

        }

        // Handle quantity change event if needed
        private void numericUpDownQuantity_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice(); // Recalculate total price when quantity changes
        }
        //Todo: adding combo meal to dgOrderList

        private void CheckIfProductExistsInOrderList()
        {
            // Get the selected product name, size, and add-ons
            string productName = productCard.titleLabel.Text; // Assuming this holds the product name
            string selectedSize = cmbSizes.SelectedItem?.ToString() ?? string.Empty;

            // Remove " - ₱" and anything after it
            if (selectedSize.Contains(" - ₱"))
            {
                selectedSize = selectedSize.Substring(0, selectedSize.IndexOf(" - ₱"));
            }
            string selectedAddOns = string.Join(", ", chckListBoxAddOns.CheckedItems.Cast<string>()); // Combine selected add-ons into a string

            // Loop through rows in the DataGridView
            foreach (DataGridViewRow row in parentDataGridView.Rows)
            {
                string rowProductName = row.Cells["ColumnProduct"].Value?.ToString() ?? string.Empty; // Replace with actual column name
                string rowSize = row.Cells["Size"].Value?.ToString() ?? string.Empty; // Replace with actual column name
                string rowAddOns = row.Cells["AddOns"].Value?.ToString() ?? string.Empty; // Replace with actual column name

                // Check if product name, size, and add-ons match
                if (rowProductName == productName && rowSize == selectedSize && rowAddOns == selectedAddOns)
                {
                    // Update the quantity in numericUpDownQuantity
                    int quantity = Convert.ToInt32(row.Cells["ColumnQty"].Value); // Replace with actual column name
                    numericUpDownQuantity.Value = quantity;
                    return; // Exit the method if a match is found
                }
            }

        }


        private void btnAddToDgViewOrderList_Click(object sender, EventArgs e)
        {


            if (parentDataGridView != null)
            {
                string productName = productCard.titleLabel.Text;
                string selectedSize = cmbSizes.Visible ? cmbSizes.SelectedItem?.ToString().Split(new[] { " - ₱" }, StringSplitOptions.None)[0] ?? "" : "";
                string selectedAddOns = chckListBoxAddOns.Visible ? string.Join(", ", chckListBoxAddOns.CheckedItems.Cast<object>().Select(item => item.ToString().Split(new[] { " - " }, StringSplitOptions.None)[0])) : "";

                int quantity = (int)numericUpDownQuantity.Value;
                decimal price = Convert.ToDecimal(lblTotalPrice.Text.Substring(1));

                bool found = false;
                foreach (DataGridViewRow row in parentDataGridView.Rows)
                {
                    string rowProductName = row.Cells[0].Value?.ToString();
                    string rowSize = row.Cells[1].Value?.ToString();
                    string rowAddOns = row.Cells[2].Value?.ToString();

                    if (rowProductName == productName && rowSize == selectedSize && rowAddOns == selectedAddOns)
                    {
                

                        row.Cells[3].Value = quantity;
                        row.Cells[4].Value = price;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    // Add a new row if no matching row was found
                    parentDataGridView.Rows.Add(productName, selectedSize, selectedAddOns, quantity, price);
                }

                        this.Close();

                AddToDgViewOrderListClicked = true; // Set the flag to true

            }
            else
            {
                MessageBox.Show("DataGridView not found!");
            }

            this.Close();
        }

        private void lblTotalPrice_Click(object sender, EventArgs e)
        {

        }

        private void chckListBoxAddOns_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckIfProductExistsInOrderList();
        }

        private void OrderEntryModal_Load(object sender, EventArgs e)
        {
            CheckIfProductExistsInOrderList();

        }
    }
    }
