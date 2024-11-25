using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using TakoTea.Controls;
using TakoTea.Interfaces;
using TakoTea.Models;
using TakoTea.Services;
using TakoTea.View.Orders;
using TakoTea.Views.Order.Order_Modals;

namespace TakoTea.Views.Order
{
    public class MenuOrderFormService
    {
        private readonly Entities _context;
        private readonly MenuOrderFormService _service;
        private readonly ProductsService service;
        public MenuOrderFormService()
        {

            _context = new Entities();
            service = new ProductsService();
        }

        public int UpdateStockLevelsCallCount { get; private set; } // Add a counter

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




        public void DisplayCustomerDetails(string customerName)
        {
            throw new NotImplementedException();
        }

        public int GenerateNewOrderId()
        {
            using (var context = new Entities())
            {
                // Find the maximum existing OrderId
                int? maxOrderId = context.OrderModels.Max(o => (int?)o.OrderId);

                // Generate the next OrderId
                int newOrderId = (maxOrderId ?? 0) + 1;

                return newOrderId;
            }
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

        public void PopulateCategories(FlowLayoutPanel flowLayoutPanelCategories, DataGridView dataGridViewOrderList, FlowLayoutPanel flPanelProductVariantsMenu)
        {

            flowLayoutPanelCategories.Controls.Clear();

            if (flowLayoutPanelCategories == null)
                throw new ArgumentNullException(nameof(flowLayoutPanelCategories));
            var allCategoryButton = new CategoryButtonOrdering();
            allCategoryButton.buttonCategory.Text = "All Category";
            allCategoryButton.buttonCategory.Click += (sender, e) =>
            {
                // Load all menu variants when "All Category" is clicked
                LoadMenuVariants(flPanelProductVariantsMenu, dataGridViewOrderList);
            };
            flowLayoutPanelCategories.Controls.Add(allCategoryButton); // Add the button to the FlowLa
            using (var dbContext = new Entities()) // Replace with your actual DbContext
            {
                // Step 1: Fetch distinct categories from the Products table
                var categories = dbContext.Products
                    .Select(p => p.ProductName) // Replace 'Category' with your actual column name
                    .Distinct()
                    .ToList();

                // Step 2: Clear the existing controls

                // Step 3: Create a CategoryButtonOrdering for each category
                foreach (var category in categories)
                {
                    if (!string.IsNullOrEmpty(category))
                    {
                        var categoryButton = new CategoryButtonOrdering();
                        categoryButton.buttonCategory.Text = category;
                        categoryButton.buttonCategory.Click += (sender, e) =>
                        {
                            LoadMenuVariantsByCategory(category, flPanelProductVariantsMenu, dataGridViewOrderList);
                        };
                        flowLayoutPanelCategories.Controls.Add(categoryButton);
                    }
                }
            }
        }

        public void LoadMenuVariantsByCategory(string categoryName, FlowLayoutPanel flPanelProductVariantsMenu, DataGridView dg)
        {
            // ... (Null checks and clearing the FlowLayoutPanel - same as before) ...

            var productVariants = _context.ProductVariants
                .Where(pv => pv.Product.ProductName == categoryName) // Filter by category
                .GroupBy(pv => pv.VariantName)
                .Select(g => g.FirstOrDefault())
                .ToList();

            flPanelProductVariantsMenu.Controls.Clear();
            if (productVariants.Count == 0)
            {
                Label noVariantsLabel = new Label();
                noVariantsLabel.Text = $"No variants available for {categoryName}.";
                noVariantsLabel.AutoSize = true;

                // Center the label within the panel
                noVariantsLabel.Location = new Point(
                    (flPanelProductVariantsMenu.ClientSize.Width - noVariantsLabel.Width) / 2,
                    (flPanelProductVariantsMenu.ClientSize.Height - noVariantsLabel.Height) / 2
                );

                // Increase the font size
                noVariantsLabel.Font = new Font(noVariantsLabel.Font.FontFamily, 14, FontStyle.Regular);

                flPanelProductVariantsMenu.Controls.Add(noVariantsLabel);
            }
            else
            {
                foreach (var productVariant in productVariants)
                {
                    var productWidget = new ProductWidget
                    {
                        lblProductName = { Text = productVariant.VariantName },
                        lblProductCategory = { Text = service.GetProductNameById(productVariant.ProductID) }
                    };

                    if (!string.IsNullOrEmpty(productVariant.ImagePath))
                    {
                        try
                        {
                            if (File.Exists(productVariant.ImagePath))
                            {
                                productWidget.pictureBoxProduct.Image = Image.FromFile(productVariant.ImagePath);
                                productWidget.pictureBoxProduct.SizeMode = PictureBoxSizeMode.Zoom;
                            }
                            else
                            {
                                productWidget.pictureBoxProduct.Image = Properties.Resources.multiply;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Failed to load image: {ex.Message}");
                        }
                    }

                    productWidget.pictureBoxProduct.Click += (sender, e) =>
                    {
                        using (OrderEntryModal orderEntryModal = new OrderEntryModal(dg))
                        {
                            orderEntryModal.SetProductData(productVariant);
                            orderEntryModal.ShowDialog();
                        }
                    };

                    ToolTip toolTip = new ToolTip();
                    toolTip.SetToolTip(productWidget.pictureBoxProduct, productVariant.VariantName);

                    flPanelProductVariantsMenu.Controls.Add(productWidget);
                }
            }

        }
        // In your service class

        // ... (other methods) ...

        public void UpdateTotalInOrderList(DataGridView dataGridViewOrderList, Label lblTotalInOrderList)
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dataGridViewOrderList.Rows)
            {
                if (row.Cells[4].Value != null && decimal.TryParse(row.Cells[4].Value.ToString(), out decimal rowTotal))
                {
                    total += rowTotal;
                }
            }
            lblTotalInOrderList.Text = $"₱{total:F2}";
        }

        // ... (other methods) ...

        public void LoadMenuVariants(FlowLayoutPanel flPanelProductVariantsMenu, DataGridView dg)
        {

            if (flPanelProductVariantsMenu == null)
                throw new ArgumentNullException(nameof(flPanelProductVariantsMenu));

            if (_context == null)
                throw new ArgumentNullException(nameof(_context));

            // Clear existing controls from the FlowLayoutPanel
            flPanelProductVariantsMenu.Controls.Clear();

            // Fetch all ProductVariants from the database and group by VariantName
            var productVariants = _context.ProductVariants
                .GroupBy(pv => pv.VariantName)
                .Select(g => g.FirstOrDefault()) // Take only the first occurrence of each VariantName
                .ToList();

            // Iterate through each unique ProductVariant and create a ProductWidget for it
            foreach (var productVariant in productVariants)
            {
                // Create a new ProductWidget instance (without price)
                var productWidget = new ProductWidget
                {
                    lblProductName = { Text = productVariant.VariantName },
                    lblProductCategory = { Text = service.GetProductNameById(productVariant.ProductID) }
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
                        orderEntryModal.SetProductData(productVariant);

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



        public void FilterAndDisplayUniqueVariants(string searchText, FlowLayoutPanel flPanelProductVariantsMenu, DataGridView dg)
        {
            if (flPanelProductVariantsMenu == null)
                throw new ArgumentNullException(nameof(flPanelProductVariantsMenu));


            // Filter product variants by search text and group by VariantName to ensure uniqueness
            var filteredVariants = _context.ProductVariants
                  .Where(pv => pv.VariantName.ToLower().Contains(searchText.Trim().ToLower()))
                  .GroupBy(pv => pv.VariantName)  // Group by VariantName to remove duplicates
                  .Select(g => g.FirstOrDefault()) // Take only the first variant in each group
                  .ToList();



            flPanelProductVariantsMenu.Controls.Clear();

            foreach (var variant in filteredVariants)
            {
                // Create and configure ProductWidgets for each unique variant
                var productWidget = new ProductWidget
                {
                    lblProductName = { Text = variant.VariantName },
                    lblProductCategory = { Text = service.GetProductNameById(variant.ProductID) }
                };

                // Load the image into the PictureBox 
                if (!string.IsNullOrEmpty(variant.ImagePath))
                {
                    try
                    {
                        if (File.Exists(variant.ImagePath))
                        {
                            productWidget.pictureBoxProduct.Image = Image.FromFile(variant.ImagePath);
                            productWidget.pictureBoxProduct.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                        else
                        {
                            productWidget.pictureBoxProduct.Image = Properties.Resources.multiply;
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
                        orderEntryModal.SetProductData(variant);

                        // Show the modal
                        orderEntryModal.ShowDialog();
                    }
                };

                // Optional: Add a tooltip
                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(productWidget.pictureBoxProduct, variant.VariantName);

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



        public void UpdateTotal()
        {
            throw new NotImplementedException();
        }

        public bool ValidateOrder()
        {
            throw new NotImplementedException();
        }

        //TODO: TEST THIS

        public void ConfirmOrder(DataGridView dataGridViewOrderList, Label lblTotalInOrderList, Label lblOrderId , ComboBox cmbPaymentMethod, ComboBox cmbPaymentStatus)
        {
            // 1. Validate the order
            if (!ValidateOrder(dataGridViewOrderList))
            {
                return; // Don't proceed if the order is invalid
            }

            // 2. Display confirmation message
            DialogResult result = DisplayConfirmationMessage("Are you sure you want to confirm this order?");
            if (result != DialogResult.Yes)
            {
                return; // Don't proceed if the user cancels
            }

            // 3. Gather necessary data
            int orderId = int.Parse(lblOrderId.Text);
            string paymentMethod = cmbPaymentMethod.SelectedItem.ToString();
            string paymentStatus = cmbPaymentStatus.SelectedItem.ToString();

            // 4. Save the order to the database
            SaveOrderToDb(orderId, dataGridViewOrderList, lblTotalInOrderList, paymentMethod, paymentStatus);

            // 5. Update stock levels
            UpdateStockLevels(dataGridViewOrderList);

            // 6. (Optional) Perform other actions like generating a receipt or printing an order summary
        }

        public bool ValidateOrder(DataGridView dataGridViewOrderList)
        {
            // Check if there are any items in the order list
            if (dataGridViewOrderList.Rows.Count == 0)
            {
                MessageBox.Show("Order list is empty. Please add items to the order.");
                return false;
            }

            // You can add more validation checks here if needed, e.g.,
            // - Check if any required fields are missing
            // - Check if quantities are valid
            // - etc.

            return true;
        }

        public DialogResult DisplayConfirmationMessage(string message)
        {
            return MessageBox.Show(message, "Confirm Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        //TODO: TEST THIS



        //TODO: PRODUCTVARIANTINGREDIENT LINK
        public void UpdateStockLevels(DataGridView dataGridViewOrderList)
        {
            UpdateStockLevelsCallCount++; // Increment the counter when the method is called

            foreach (DataGridViewRow row in dataGridViewOrderList.Rows)
            {
                if (row.IsNewRow)
                    continue;
                string productName = row.Cells[0].Value.ToString();
                string size = row.Cells[1].Value.ToString();
                int quantity = Convert.ToInt32(row.Cells[3].Value);

                // Get the ingredients and their quantities for this product variant
                var ingredients = GetIngredientsForProductVariant(productName, size);

                foreach (var ingredient in ingredients)
                {
                    // Update the stock level for each ingredient in the batch
                    UpdateBatchStockLevel(ingredient.IngredientID, ingredient.QuantityPerVariant * quantity);
                }
            }
        }

        // Helper method to get ingredients for a product variant
        private List<IngredientQuantity> GetIngredientsForProductVariant(string productName, string size)
        {
            using (var context = new Entities())
            {
                // Query the database to retrieve the ingredient IDs and quantities for the specified product variant
                return context.ProductVariants
                    .Where(pv => pv.VariantName == productName && pv.Size == size)
                    .SelectMany(pv => pv.ProductVariantIngredients)
                    .Select(pvi => new IngredientQuantity
                    {
                        IngredientID = pvi.IngredientID,
                        QuantityPerVariant = pvi.QuantityPerVariant
                    })
                    .ToList();
            }
        }
        //TODO: TEST THIS
        // Helper method to update the stock level in the batch
        private void UpdateBatchStockLevel(int ingredientId, decimal quantityUsed)
        {
            using (var context = new Entities())
            {
                var batch = context.Batches.FirstOrDefault(b => b.IngredientID == ingredientId);
                if (batch != null)
                {
                    batch.StockLevel -= quantityUsed;
                    context.SaveChanges();
                }
            }
        }
        public void SaveOrderToDb(int orderId, DataGridView dataGridViewOrderList, Label lblTotalInOrderList, string customerName, string paymentMethod)
        {

            var order = new OrderModel
            {
                OrderId = orderId,
                CustomerName = customerName,
                PaymentMethod = paymentMethod,
                PaymentStatus = "Pending", // Or another appropriate initial status
                TotalAmount = decimal.Parse(lblTotalInOrderList.Text.Substring(1)),
                CreatedBy = "System", // Or the actual creator's name
                // ModifiedBy and ModifiedDate can be set later if needed
            };

            _context.OrderModels.Add(order);

            foreach (DataGridViewRow row in dataGridViewOrderList.Rows)
            {
                if (row.IsNewRow)
                    continue;
                string productName = row.Cells[0].Value.ToString();

                string sizeId = (row.Cells[1].Value.ToString());
                int variantId = service.GetProductVariantId(productName, sizeId); // Use productName and sizeId

                _context.OrderItems.Add(new OrderItem
                {
                    OrderId = orderId,
                  
                    ProductName = row.Cells[0].Value.ToString(),
                    ProductVariantId = variantId,
                    Quantity = Convert.ToInt32(row.Cells[3].Value),
                    Price = Convert.ToDecimal(row.Cells[4].Value),
                    TotalPrice = Convert.ToDecimal(row.Cells[3].Value) * Convert.ToDecimal(row.Cells[4].Value), // Calculate TotalPrice
                    AddOns = row.Cells[2].Value.ToString(),
                    CreatedBy = "System", // Or the actual creator's name                    
                    
                });
            }

            _context.SaveChanges();
        }

        public class IngredientQuantity
        {
            public int IngredientID { get; set; }
            public decimal QuantityPerVariant { get; set; }
        }
    }
}
