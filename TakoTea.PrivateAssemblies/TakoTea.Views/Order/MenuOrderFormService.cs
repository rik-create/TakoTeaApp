using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakoTea.Controls;
using TakoTea.Interfaces;
using TakoTea.Models;
using TakoTea.View.Order;
using TakoTea.Views.Order.Order_Modals;

namespace TakoTea.Views.Order
{
    public class MenuOrderFormService : IMenuOrderForm
    {
        private readonly Entities _context;
        private readonly MenuOrderFormService _service;
        public MenuOrderFormService() { 

            _context = new Entities();
        }

        public void AddToOrderList(string productName, int quantity, decimal price)
        {
            throw new NotImplementedException();
        }

        public void AddToSalesHistory(int orderId, DateTime orderDate, decimal totalAmount, string paymentMethod, string customerName)
        {
            throw new NotImplementedException();
        }

        public void ApplyDiscount(decimal discountValue, bool isPercentage)
        {
            throw new NotImplementedException();
        }

        public void CancelOrder()
        {
            throw new NotImplementedException();
        }

        public void ClearOrderList()
        {
            throw new NotImplementedException();
        }

        public void ConfirmOrder()
        {
            throw new NotImplementedException();
        }

        public void DisplayConfirmationMessage(string message)
        {
            throw new NotImplementedException();
        }

        public void DisplayCustomerDetails(string customerName)
        {
            throw new NotImplementedException();
        }

        public int GenerateNewOrderId()
        {
            throw new NotImplementedException();
        }

        public void GenerateReceipt(int orderId)
        {
            throw new NotImplementedException();
        }

        public void HandlePayment(int orderId, decimal amountPaid, string paymentMethod)
        {
            throw new NotImplementedException();
        }

        public void HandleRefund(int orderId, string reason, decimal refundAmount)
        {
            throw new NotImplementedException();
        }

        public void LoadDraftOrder(int draftOrderId)
        {
            throw new NotImplementedException();
        }

        public void LoadMenuVariants(FlowLayoutPanel flPanelProductVariantsMenu, DataGridView dg)
        {
            if (flPanelProductVariantsMenu == null)
                throw new ArgumentNullException(nameof(flPanelProductVariantsMenu));

            if (_context == null)
                throw new ArgumentNullException(nameof(_context));

            // Clear existing controls from the FlowLayoutPanel
            flPanelProductVariantsMenu.Controls.Clear();

            // Fetch all ProductVariants from the database
            var productVariants = _context.ProductVariants.ToList();

            // Iterate through each ProductVariant and create a ProductWidget for it
            foreach (var productVariant in productVariants)
            {
                // Create a new ProductWidget instance
                var productWidget = new ProductWidget
                {
                    lblProductName = { Text = productVariant.VariantName },
                    lblProductPrice = { Text = $"₱{productVariant.Price:F2}" }
                };

                // Load the image into the PictureBox (ensure the path is valid and accessible)
                if (!string.IsNullOrEmpty(productVariant.ImagePath))
                {
                    try
                    {
                        if (File.Exists(productVariant.ImagePath))
                        {
                            productWidget.pictureBoxProduct.Image = Image.FromFile(productVariant.ImagePath);
                            productWidget.pictureBoxProduct.SizeMode = PictureBoxSizeMode.Zoom; // Adjust image size mode
                        }
                        else
                        {
                            productWidget.pictureBoxProduct.Image = Properties.Resources.multiply; // Replace with your default image
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to load image: {ex.Message}");
                    }
                }

                // Add click or event handlers for interaction
                productWidget.pictureBoxProduct.Click += (sender, e) =>
                {
                    // Create and show the OrderEntryModal
                    using (OrderEntryModal orderEntryModal = new OrderEntryModal(dg))
                    {
                        // Pass productVariant data to OrderEntryModal
                        orderEntryModal.SetProductData(productVariant); // Custom method to load data into the modal

                        // Show the modal
                        orderEntryModal.ShowDialog();
                    }
                };

                // Optional: Add a tooltip
                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(productWidget.pictureBoxProduct, productVariant.VariantName);

                // Add the ProductWidget to the FlowLayoutPanel
                flPanelProductVariantsMenu.Controls.Add(productWidget);
            }
        }




        public void LogActivity(string activityType, string description)
        {
            throw new NotImplementedException();
        }

        public void PrintOrderSummary(int orderId)
        {
            throw new NotImplementedException();
        }

        public void ResetForm()
        {
            throw new NotImplementedException();
        }

        public void SaveDraftOrder(int draftOrderId, List<OrderItem> items, decimal totalAmount, string customerName, string paymentMethod)
        {
            throw new NotImplementedException();
        }

        public void SendDigitalReceipt(int orderId, string customerContact)
        {
            throw new NotImplementedException();
        }

        public void UpdateStockLevels()
        {
            throw new NotImplementedException();
        }

        public void UpdateTotal()
        {
            throw new NotImplementedException();
        }

        public bool ValidateOrder()
        {
            throw new NotImplementedException();
        }
    }
}
