using MaterialSkin.Controls;
using System.Windows.Forms;
using System;
using TakoTea.Configurations;
using TakoTea.Models;
using System.IO;
using System.Linq;
using System.Drawing;
namespace TakoTea.Views.Order.Order_Modals
{
    public partial class OrderEntryModal : MaterialForm
    {



        //TODO : handle addons feautures and determine the price base on selected size and selected addons
        private DataGridView parentDataGridView;

        public OrderEntryModal(DataGridView dataGridView)
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            ModalSettingsConfigurator.ApplyStandardModalSettings(this);
            parentDataGridView = dataGridView;

        }
        public void SetProductData(ProductVariant productVariant)
        {
            if (productVariant != null)
            {
                // Set the product details in the modal controls
                productCard.titleLabel.Text = productVariant.VariantName;
                productCard.priceLabel.Text = $"₱{productVariant.Price:F2}";
                numericUpDownQuantity.Value = 1; // Default quantity to 1

                // Optionally, set the image in a control, if there's an image
                if (!string.IsNullOrEmpty(productVariant.ImagePath) && File.Exists(productVariant.ImagePath))
                {
                    productCard.pictureBoxProductIcon.Image = Image.FromFile(productVariant.ImagePath);
                    productCard.pictureBoxProductIcon.SizeMode = PictureBoxSizeMode.Zoom; // Adjust image size mode
                }
                else
                {
                    productCard.pictureBoxProductIcon.Image = Properties.Resources.multiply; // Default image if no image path exists
                }

                // Set other data like sizes, addons, etc., if required
                // Example for sizes dropdown:
                cmbSizes.Items.Clear();
                cmbSizes.Items.AddRange(productVariant.Size.Select(size => size.ToString()).ToArray());

                // Optionally, update the total price if needed
                UpdateTotalPrice();
            }
        }

        private void UpdateTotalPrice()
        {
            // This method updates the total price based on quantity and selected product
            decimal price = Convert.ToDecimal(productCard.priceLabel.Text.Substring(1)); // Remove ₱ sign and get price
            lblTotalPrice.Text = $"₱{(price * numericUpDownQuantity.Value):F2}"; // Update total price
        }

        // Handle quantity change event if needed
        private void numericUpDownQuantity_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice(); // Recalculate total price when quantity changes
        }

        private void btnAddToDgViewOrderList_Click(object sender, EventArgs e)
        {
            // Get the product name, quantity, and total price from the modal
            string productName = productCard.titleLabel.Text;
            int quantity = (int)numericUpDownQuantity.Value;
            decimal price = Convert.ToDecimal(productCard.priceLabel.Text.Substring(1)); // Remove ₱ symbol and parse price
            decimal totalPrice = price * quantity; // Calculate total price for the selected quantity

            // Check if a DataGridView exists (this could be a parameter passed from the parent form or a static reference)
            if (parentDataGridView != null) // You can pass a reference of DataGridView from parent form
            {
                // Add the product details to the DataGridView (add a new row)
                parentDataGridView.Rows.Add(productName, quantity, totalPrice);
            }
            else
            {
                MessageBox.Show("DataGridView not found!");
            }

            // Optionally, close the OrderEntryModal after adding the product
            this.Close();
        }

    }
}
