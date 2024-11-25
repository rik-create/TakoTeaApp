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
namespace TakoTea.Views.Order.Order_Modals
{
    public partial class OrderEntryModal : MaterialForm
    {


        private readonly Entities _context;
        //TODO : handle addons feautures and determine the price base on selected size and selected addons
        private DataGridView parentDataGridView;

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
            numericUpDownQuantity.Minimum = 1;

            // ... rest of the code ...

        }
        // ... (other code) ...

        private void cmbSizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();
        }

        private void chckListBoxAddOns_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // BeginInvoke is used to execute UpdateTotalPrice after the ItemCheck event is finished
            this.BeginInvoke(new Action(() => UpdateTotalPrice()));
        }

        // ... (rest of the code) ...


        private void PopulateAddOns()
        {
            // 1. Fetch add-ons from the database
            List<AddOn> addOns = _context.AddOns.ToList();

            // 2. Clear existing items in the CheckedListBox
            chckListBoxAddOns.Items.Clear();

            // 3. Add each add-on to the CheckedListBox with the desired format
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


        public void SetProductData(ProductVariant productVariant)
        {
            if (productVariant != null)
            {
                // Set the product details in the modal controls
                productCard.titleLabel.Text = productVariant.VariantName;
                numericUpDownQuantity.Value = 1; // Default quantity to 1

                // Set the image in a control
                if (!string.IsNullOrEmpty(productVariant.ImagePath) && File.Exists(productVariant.ImagePath))
                {
                    productCard.pictureBoxProductIcon.Image = Image.FromFile(productVariant.ImagePath);
                    productCard.pictureBoxProductIcon.SizeMode = PictureBoxSizeMode.Zoom; // Adjust image size mode
                }
                else
                {
                    productCard.pictureBoxProductIcon.Image = Properties.Resources.multiply; // Default image
                }

                // Fetch all sizes related to the product variant name
                var sizesAndPrices = GetSizesAndPricesByVariantName(productVariant.VariantName);

                // Clear and populate the size combo box
                cmbSizes.Items.Clear();
                foreach (var sizePrice in sizesAndPrices)
                {
                    cmbSizes.Items.Add($"{sizePrice.Size} - ₱{sizePrice.Price:F2}");
                }

                // Set default selection
                if (cmbSizes.Items.Count > 0)
                {
                    cmbSizes.SelectedIndex = 0; // Select the first size by default
                }

                // Populate add-ons in the checked list box
                PopulateAddOns();

                // Update total price based on size and quantity
                UpdateTotalPrice();
            }
        }



        private void UpdateTotalPrice()
        {
            decimal price = 0;

            // Get price from selected size
            if (cmbSizes.SelectedItem != null)
            {
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


        private void btnAddToDgViewOrderList_Click(object sender, EventArgs e)
        {


            if (parentDataGridView != null)
            {
                // Get the product name and format it
                string productName = productCard.titleLabel.Text;
                string selectedSize = cmbSizes.SelectedItem?.ToString().Split(new[] { " - ₱" }, StringSplitOptions.None)[0] ?? ""; string selectedAddOns = string.Join(", ", chckListBoxAddOns.CheckedItems.Cast<object>().Select(item => item.ToString().Split(new[] { " - " }, StringSplitOptions.None)[0]));


                int quantity = (int)numericUpDownQuantity.Value;
                decimal price = Convert.ToDecimal(lblTotalPrice.Text.Substring(1));
                decimal totalPrice = price * quantity;

                bool found = false;
                foreach (DataGridViewRow row in parentDataGridView.Rows)
                {
                    string rowProductName = row.Cells[0].Value?.ToString();
                    string rowSize = row.Cells[1].Value?.ToString();
                    string rowAddOns = row.Cells[2].Value?.ToString();

                    if (rowProductName == productName && rowSize == selectedSize && rowAddOns == selectedAddOns)
                    {
                        // Update the existing row's quantity and total price
                        int existingQuantity = Convert.ToInt32(row.Cells[3].Value);
                        int newQuantity = existingQuantity + quantity;
                        decimal newTotalPrice = newQuantity * price;

                        row.Cells[3].Value = newQuantity;
                        row.Cells[4].Value = newTotalPrice;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    // Add a new row if no matching row was found
                    parentDataGridView.Rows.Add(productName, selectedSize, selectedAddOns, quantity, totalPrice);
                }

                        this.Close();


            }
            else
            {
                MessageBox.Show("DataGridView not found!");
            }

            this.Close();
        }
    }
    }
