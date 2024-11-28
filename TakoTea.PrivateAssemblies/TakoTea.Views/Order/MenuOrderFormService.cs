using LiveCharts.Wpf;
using Microsoft.ReportingServices.ReportProcessing.OnDemandReportObjectModel;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using MailKit.Net.Smtp;
using MailKit.Security;
using System.Security.Policy;
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
        private readonly ProductsService productsService;
        public MenuOrderFormService()
        {

            _context = new Entities();
            productsService = new ProductsService();
        }
        public int GetLatestDraftOrderId()
        {
            int? maxDraftOrderId = _context.DraftOrders.Max(o => (int?)o.DraftOrderId);
            return (maxDraftOrderId ?? 0);
        }
        public int UpdateStockLevelsCallCount { get; private set; } // Add a counter

        public void AddToOrderList(string productName, int quantity, decimal price)
        {
            throw new NotImplementedException();
        }

        public void AddToSalesHistory(int orderId)
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

            var order = _context.OrderModels
                .Include(o => o.OrderItems)
                .FirstOrDefault(o => o.OrderId == orderId);

            if (order == null)
            {
                MessageBox.Show($"Order with ID {orderId} not found.");
                return;
            }

            var receiptContent = new StringBuilder();

            // Centered and styled header
            receiptContent.AppendLine("TakoTea".PadLeft(24) + "\n");
            receiptContent.AppendLine("=".PadRight(42, '='));
            receiptContent.AppendLine("Order Receipt".PadLeft(27));
            receiptContent.AppendLine("=".PadRight(42, '=') + "\n"); // Add extra newline for spacing

            receiptContent.AppendLine($"Order ID: {order.OrderId}");
            receiptContent.AppendLine($"Order Date: {order.OrderDate:yyyy-MM-dd HH:mm:ss}");

            if (!string.IsNullOrEmpty(order.CustomerName))
            {
                receiptContent.AppendLine($"Customer: {order.CustomerName}");
            }

            receiptContent.AppendLine($"Payment Method: {order.PaymentMethod}");
            receiptContent.AppendLine($"Payment Status: {order.PaymentStatus}");

            receiptContent.AppendLine("\nItems:");
            foreach (var item in order.OrderItems)
            {
                // Improved formatting for item details
                receiptContent.AppendLine($"- {item.ProductName,-15} {item.Quantity} x {item.Price,8:C} = {item.TotalPrice,9:C}");

                if (!string.IsNullOrEmpty(item.AddOns))
                {
                    receiptContent.AppendLine($"   Add-ons: {item.AddOns}"); // Consistent indentation
                }
            }

            receiptContent.AppendLine("=".PadRight(42, '='));
            receiptContent.AppendLine($"Total: {order.TotalAmount,35:C}"); 

            ReceiptForm receiptForm = new ReceiptForm(orderId);
            receiptForm.lblReceiptContent.Text = receiptContent.ToString();
            receiptForm.ShowDialog();
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
            if (flPanelProductVariantsMenu == null)
            {
                throw new ArgumentNullException(nameof(flPanelProductVariantsMenu));
            }

            if (_context == null)
            {
                throw new ArgumentNullException(nameof(_context));
            }

            var productVariants = _context.ProductVariants
                .Where(pv => pv.Product.ProductName == categoryName)
                .GroupBy(pv => pv.VariantName)
                .Select(g => g.FirstOrDefault())
                .ToList();

            flPanelProductVariantsMenu.Controls.Clear();

            if (productVariants.Count == 0)
            {
                Label noVariantsLabel = new Label(); // Declare and initialize the label first
                noVariantsLabel.Text = $"No variants available for {categoryName}.";
                noVariantsLabel.AutoSize = true;
                noVariantsLabel.Font = new Font(noVariantsLabel.Font.FontFamily, 14, FontStyle.Regular);

                // Now you can use noVariantsLabel.Width and noVariantsLabel.Height
                noVariantsLabel.Location = new Point(
                    (flPanelProductVariantsMenu.ClientSize.Width - noVariantsLabel.Width) / 2,
                    (flPanelProductVariantsMenu.ClientSize.Height - noVariantsLabel.Height) / 2
                );
                flPanelProductVariantsMenu.Controls.Add(noVariantsLabel);
            }
            else
            {
                foreach (var productVariant in productVariants)
                {
                    var productWidget = new ProductWidget
                    {
                        lblProductName = { Text = productVariant.VariantName },
                        lblProductCategory = { Text = productsService.GetProductNameById(productVariant.ProductID) }
                    };

                    if (productVariant.ImagePath?.Length > 0)
                    {
                        try
                        {
                            using (MemoryStream ms = new MemoryStream(productVariant.ImagePath))
                            {
                                productWidget.pictureBoxProduct.Image = Image.FromStream(ms);
                            }
                            productWidget.pictureBoxProduct.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Failed to load image: {ex.Message}");
                        }
                    }

                    productWidget.pictureBoxProduct.Click += (sender, e) =>
                    {
                         var orderEntryModal = new OrderEntryModal(dg);
                        orderEntryModal.SetProductData(productVariant);
                        orderEntryModal.ShowDialog();
                    };

                    ToolTip toolTip = new ToolTip();
                    toolTip.SetToolTip(productWidget.pictureBoxProduct, productVariant.VariantName);

                    flPanelProductVariantsMenu.Controls.Add(productWidget);
                }
            }
        }
        // In your productsService class

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

            flPanelProductVariantsMenu.Controls.Clear();

            var productVariants = _context.ProductVariants
                .GroupBy(pv => pv.VariantName)
                .Select(g => g.FirstOrDefault())
                .ToList();

            foreach (var variant in productVariants)
            {
                flPanelProductVariantsMenu.Controls.Add(CreateProductWidget(variant, dg));
            }

            var comboMeals = _context.ComboMeals.ToList();

            foreach (var comboMeal in comboMeals)
            {
                flPanelProductVariantsMenu.Controls.Add(CreateProductWidget(comboMeal, dg));
            }
        }
        // If using .NET Framework 4.8 or earlier, use this method instead:
        private bool IsBase64String(string base64String)
        {
            // Credit: https://stackoverflow.com/a/33557841
            if (string.IsNullOrEmpty(base64String) || base64String.Length % 4 != 0
               || base64String.Contains(" ") || base64String.Contains("\t") || base64String.Contains("\r") || base64String.Contains("\n"))
                return false;

            try
            {
                Convert.FromBase64String(base64String);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private ProductWidget CreateProductWidget(ProductVariant productVariant, DataGridView dg)
        {
            // Initialize the ProductWidget with product variant name and category
            var productWidget = new ProductWidget
            {
                lblProductName = { Text = productVariant.VariantName },
                lblProductCategory = { Text = productsService.GetProductNameById(productVariant.ProductID) }
            };

            // Check if the ImagePath is not empty
            if (productVariant.ImagePath?.Length > 0) // Check if ImagePath is not null and has data
            {
                try
                {
                    // Create an Image from the byte array in ImagePath
                    using (MemoryStream ms = new MemoryStream(productVariant.ImagePath))
                    {
                        productWidget.pictureBoxProduct.Image = Image.FromStream(ms);
                    }
                    productWidget.pictureBoxProduct.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load image: {ex.Message}");
                }
            }

            // Handle the click event of the product's picture box
            productWidget.pictureBoxProduct.Click += (sender, e) =>
            {
                using (var orderEntryModal = new OrderEntryModal(dg))
                {
                    orderEntryModal.SetProductData(productVariant);
                    orderEntryModal.ShowDialog();
                }
            };

            // Set the tooltip for the product's picture box
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(productWidget.pictureBoxProduct, productVariant.VariantName);

            return productWidget;
        }

        private ProductWidget CreateProductWidget(ComboMeal comboMeal, DataGridView dg)
        {
            var productWidget = new ProductWidget
            {
                lblProductName = { Text = comboMeal.ComboMealName },
                lblProductCategory = { Text = "ComboMeal" }
            };

            try
            {
                if (File.Exists(comboMeal.ImagePath))
                {
                    productWidget.pictureBoxProduct.Image = Image.FromFile(comboMeal.ImagePath);
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

            productWidget.pictureBoxProduct.Click += (sender, e) =>
            {
                using (var orderEntryModal = new OrderEntryModal(dg))
                {
                    orderEntryModal.SetComboMealData(comboMeal);
                    orderEntryModal.ShowDialog();
                }
                
            };

            // ... (Tooltip logic for combo meals, if needed) ...

            return productWidget;
        }


        public void FilterAndDisplayUniqueVariants(string searchText, FlowLayoutPanel flPanelProductVariantsMenu, DataGridView dg)
        {
            if (flPanelProductVariantsMenu == null)
            {
                throw new ArgumentNullException(nameof(flPanelProductVariantsMenu));
            }

            var filteredVariants = _context.ProductVariants
                .Where(pv => pv.VariantName.ToLower().Contains(searchText.Trim().ToLower()))
                .GroupBy(pv => pv.VariantName)
                .Select(g => g.FirstOrDefault())
                .ToList();

            flPanelProductVariantsMenu.Controls.Clear();

            foreach (var variant in filteredVariants)
            {
                var productWidget = new ProductWidget
                {
                    lblProductName = { Text = variant.VariantName },
                    lblProductCategory = { Text = productsService.GetProductNameById(variant.ProductID) }
                };

                if (variant.ImagePath?.Length > 0)
                {
                    try
                    {
                        using (MemoryStream ms = new MemoryStream(variant.ImagePath))
                        {
                            productWidget.pictureBoxProduct.Image = Image.FromStream(ms);
                        }
                        productWidget.pictureBoxProduct.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to load image: {ex.Message}");
                    }
                }

                productWidget.pictureBoxProduct.Click += (sender, e) =>
                {
                    var orderEntryModal = new OrderEntryModal(dg);
                    orderEntryModal.SetProductData(variant);
                    orderEntryModal.ShowDialog();
                };

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

        public void SaveDraftOrder(DataGridView dataGridViewOrderList, string totalAmount, string customerName, string paymentMethod)
        {
            using (var context = new Entities())
            {
                var draftOrder = new DraftOrder
                {
                    CreatedDate = DateTime.Now,
                    CustomerName = customerName,
                    TotalAmount = decimal.Parse(totalAmount)
                };


                if (draftOrder.DraftOrderId == 0)
                {
                    context.DraftOrders.Add(draftOrder);
                }

                context.DraftOrders.Add(draftOrder);
                context.SaveChanges();

                MenuOrderFormService menuOrderForm = new MenuOrderFormService();
                int draftOrderId = menuOrderForm.GetLatestDraftOrderId(); // Assuming you have a method to generate the next draft order ID

                context.DraftOrderItems.RemoveRange(context.DraftOrderItems.Where(i => i.DraftOrderId == draftOrderId));

                foreach (DataGridViewRow row in dataGridViewOrderList.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    string productName = row.Cells[0].Value.ToString();
                    string sizeId = row.Cells[1].Value?.ToString() ?? string.Empty;
                    string AddOns = row.Cells[2].Value.ToString();
                    int variantId = string.IsNullOrEmpty(sizeId)
                        ? _context.ComboMealVariants.FirstOrDefault(cmv => cmv.ComboMeal.ComboMealName == productName)?.ComboMealVariantID ?? 0
                        : productsService.GetProductVariantId(productName, sizeId);

                    var draftOrderItem = new DraftOrderItem
                    {
                        DraftOrderId = draftOrderId,
                        ProductName = productName,
                        ProductVariantId = variantId,
                        Quantity = Convert.ToInt32(row.Cells[3].Value),
                        Price = Convert.ToDecimal(row.Cells[4].Value),
                        CreatedBy = "System",
                        CreatedDate = DateTime.Now,
                        AddOns = AddOns

                    };

                    context.DraftOrderItems.Add(draftOrderItem);
                }

                context.SaveChanges();
            }
        }

        public void LoadDraftOrder(int draftOrderId, DataGridView dataGridViewOrderList, Label lblTotalInOrderList)
        {
            using (var context = new Entities())
            {
                var draftOrder = context.DraftOrders.Include(o => o.DraftOrderItems).FirstOrDefault(o => o.DraftOrderId == draftOrderId);

                if (draftOrder == null)
                {
                    return;
                }

                dataGridViewOrderList.Rows.Clear();

                foreach (var item in draftOrder.DraftOrderItems)
                {
                    dataGridViewOrderList.Rows.Add(
                        item.ProductName,
                        productsService.GetSizeByVariantId(item.ProductVariantId),
                        item.AddOns,
                        item.Quantity,
                        item.Price
                    );
                }

                lblTotalInOrderList.Text = $"₱{draftOrder.TotalAmount:F2}";
            }
        }
        private byte[] ImageToByteArray(Image image)
        {
            using (var ms = new MemoryStream())
            {
                // Specify the image format explicitly
                image.Save(ms, ImageFormat.Png); // Or another format like ImageFormat.Jpeg
                return ms.ToArray();
            }
        }

        private string GenerateReceiptContent(int orderId)
        {

            var order = _context.OrderModels
                .Include(o => o.OrderItems)
                .FirstOrDefault(o => o.OrderId == orderId);

            if (order == null)
            {
                return $"Order with ID {orderId} not found."; // Return an error message
            }

            var receiptContent = new StringBuilder();

            receiptContent.AppendLine("TakoTea".PadLeft(24) + "\n");
            receiptContent.AppendLine("=".PadRight(42, '='));
            receiptContent.AppendLine("Order Receipt".PadLeft(27));
            receiptContent.AppendLine("=".PadRight(42, '=') + "\n");

            receiptContent.AppendLine($"Order ID: {order.OrderId}");
            receiptContent.AppendLine($"Order Date: {order.OrderDate:yyyy-MM-dd HH:mm:ss}");

            if (!string.IsNullOrEmpty(order.CustomerName))
            {
                receiptContent.AppendLine($"Customer: {order.CustomerName}");
            }

            receiptContent.AppendLine($"Payment Method: {order.PaymentMethod}");
            receiptContent.AppendLine($"Payment Status: {order.PaymentStatus}");

            receiptContent.AppendLine("\nItems:");
            foreach (var item in order.OrderItems)
            {
                receiptContent.AppendLine($"- {item.ProductName,-15} {item.Quantity} x {item.Price,8:C} = {item.TotalPrice,9:C}");

                if (!string.IsNullOrEmpty(item.AddOns))
                {
                    receiptContent.AppendLine($"  Add-ons: {item.AddOns}");
                }
            }

            receiptContent.AppendLine("=".PadRight(42, '='));
            receiptContent.AppendLine($"Total: {order.TotalAmount,35:C}");

            return receiptContent.ToString();
        }


        public void SendDigitalReceipt(int orderId, string customerEmail)
        {

            string receiptContent = GenerateReceiptContent(orderId);    
            ReceiptForm receiptForm = new ReceiptForm(orderId); // Assuming ReceiptForm has a constructor that takes orderId
    receiptForm.lblReceiptContent.Text = receiptContent.ToString();

    // Capture the form as an image
    Bitmap bmp = new Bitmap(receiptForm.Width, receiptForm.Height);
    receiptForm.DrawToBitmap(bmp, new Rectangle(0, 0, receiptForm.Width, receiptForm.Height));


            var imageAttachment = new MimePart("image", "png")
            {   
                Content = new MimeContent(new MemoryStream(ImageToByteArray(bmp))),
                ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                ContentTransferEncoding = ContentEncoding.Base64,
                FileName
= "Receipt.png"
            };

            // Create the email message
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Tako Tea", "takotea9@gmail.com"));
            message.To.Add(new MailboxAddress("Recipient Name", customerEmail));
            message.Subject
     = "Email from MailKit with Gmail";
            message.Body = new TextPart("plain")
            {
                Text = "This email was sent using MailKit with Gmail."
            };

            var multipart = new Multipart("mixed");
            multipart.Add(message.Body); // Add the original text part
            multipart.Add(imageAttachment);
            message.Body = multipart;



            // Connect to the Gmail SMTP server
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);

                // Use your Gmail email address and app password
                client.Authenticate("takotea9@gmail.com", "rhdl vljl ztfn xzui");

                client.Send(message);
                client.Disconnect(true);
            }

            MessageBox.Show("Email sent successfully!");
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

        public void ConfirmOrder(DataGridView dataGridViewOrderList, Label lblTotalInOrderList, Label lblOrderId, ComboBox cmbPaymentMethod, ComboBox cmbPaymentStatus, ComboBox cmbOrderStatus)
        {
            using (var transaction = _context.Database.BeginTransaction()) // Using simplified syntax
            {

                try
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
                    string orderStatus = cmbOrderStatus.SelectedItem.ToString();

                    // 4. Save the order to the database
                    SaveOrderToDb(orderId, dataGridViewOrderList, lblTotalInOrderList, paymentMethod, paymentStatus, orderStatus);

                    // 5. Update stock levels
                    UpdateStockLevels(dataGridViewOrderList);
                    dataGridViewOrderList.Rows.Clear();
                    // 6. Commit transaction
                    transaction.Commit();

                    // 7. (Optional) Perform other actions like generating a receipt or printing an order summary
                }
                catch (Exception ex)
                {
                    // Rollback transaction if an error occurs
                    transaction.Rollback();

                    // Handle the exception appropriately, e.g., log the error or display a message to the user
                    MessageBox.Show($"An error occurred while confirming the order: {ex.Message}");
                }
            }
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
            UpdateStockLevelsCallCount++;

            InventoryService inventoryService = new InventoryService();
            StringBuilder sb = new StringBuilder();

            foreach (DataGridViewRow row in dataGridViewOrderList.Rows)
            {
                if (row.IsNewRow)
                    continue;


                string productName = row.Cells[0].Value.ToString();
                string size = row.Cells[1].Value.ToString();
                decimal quantity = Convert.ToDecimal(row.Cells[3].Value);

                if (string.IsNullOrEmpty(size)) // Combo meal
                {
                    var comboMeal = _context.ComboMeals.FirstOrDefault(cm => cm.ComboMealName == productName);

                    if (comboMeal != null)
                    {
                        // Get the ProductVariantIDs included in the combo meal
                        var productVariantIds = _context.ComboMealVariants
                            .Where(cmv => cmv.ComboMealID == comboMeal.ComboMealID)
                            .Select(cmv => cmv.ProductVariantID)
                            .ToList();

                        // Update stock levels for each ProductVariant in the combo meal
                        foreach (var variantId in productVariantIds)
                        {
                            var pviIds = productsService.GetProductVariantIngredientIds(((int)variantId));
                            // Loop through each ProductVariantIngredientID to get the IngredientID and QuantityPerVariant
                            foreach (var pviId in pviIds)
                            {
                                var (ingredientId, quantityPerVariant) = productsService.GetIngredientAndQuantity(pviId);

                                // Update the stock level for the ingredient
                                productsService.UpdateBatchStockLevel(ingredientId, quantityPerVariant * quantity, "Deduction");

                                // Log the stock update details
                                sb.AppendLine($"{productName} ({size}) - Ingredient {ingredientId}: {quantityPerVariant * quantity} units deducted");
                            }
                        }
                    }
                }
                else // Individual product variant
                {

                    // Update stock levels for add-ons
                    string addOnsString = row.Cells[2].Value.ToString();
                    if (!string.IsNullOrEmpty(addOnsString))
                    {
                        string[] addOnNames = addOnsString.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string addOnName in addOnNames)
                        {
                            // Get the AddOn details, including QuantityUsedPerProduct
                            var addOn = _context.AddOns.FirstOrDefault(a => a.AddOnName == addOnName);

                            if (addOn != null)
                            {
                                int addOnIngredientId = addOn.IngredientID ?? 0; // Handle potential null value
                                decimal quantityUsed = (decimal)(addOn.QuantityUsedPerProduct * quantity);

                                // Deduct the add-on quantity from the batch
                                productsService.UpdateBatchStockLevel(addOnIngredientId, quantityUsed, "Deduction");

                                // Log the stock update details for add-ons
                                sb.AppendLine($"{productName} ({size}) - Add-on {addOnName}: {quantityUsed} units deducted");
                            }
                        }
                    }

                    // Get the ProductVariantID
                    int productVariantId = productsService.GetProductVariantId(productName, size);

                    // Get the ProductVariantIngredientIDs for the current ProductVariant
                    var productVariantIngredientIds = productsService.GetProductVariantIngredientIds(productVariantId);

                    // Loop through each ProductVariantIngredientID to get the IngredientID and QuantityPerVariant
                    foreach (var pviId in productVariantIngredientIds)
                    {
                        var (ingredientId, quantityPerVariant) = productsService.GetIngredientAndQuantity(pviId);

                        // Update the stock level for the ingredient
                        productsService.UpdateBatchStockLevel(ingredientId, quantityPerVariant * quantity, "Deduction");

                        // Log the stock update details
                        sb.AppendLine($"{productName} ({size}) - Ingredient {ingredientId}: {quantityPerVariant * quantity} units deducted");
                    }
                }
            }


                // Get the ComboMeal details
     



            MessageBox.Show("Stock levels updated successfully!\n\nDetails:\n" + sb.ToString());
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
  
        public void SaveOrderToDb(int orderId, DataGridView dataGridViewOrderList, Label lblTotalInOrderList, string customerName, string paymentMethod, string orderStatus)
        {

            var order = new OrderModel
            {
                OrderId = orderId,
                OrderDate = DateTime.Now,
                OrderStatus = orderStatus,
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

                if (string.IsNullOrEmpty(sizeId))
                {       // Get the ComboMeal details
                    var comboMeal = _context.ComboMeals.FirstOrDefault(cm => cm.ComboMealName == productName);

                    if (comboMeal != null)
                    {
                        // Get the ProductVariantIDs included in the combo meal
                        var productVariantIds = _context.ComboMealVariants
                    .Where(cmv => cmv.ComboMealID == comboMeal.ComboMealID)
                    .ToList(); // Fetch the entire ComboMealVariant objects

                        foreach (var variant in productVariantIds)
                        {
                            _context.OrderItems.Add(new OrderItem
                            {
                                OrderId = orderId,
                                ProductName = productsService.GetProductVariantNameById((int)variant.ProductVariantID),
                                ProductVariantId = (int)variant.ProductVariantID,
                                Quantity = (int)variant.Quantity, // Access Quantity from ComboMealVariant
                                Price = (int)variant.Price, // Access Price from ComboMealVariant
                                TotalPrice = variant.Price * variant.Quantity, // Calculate TotalPrice
                                AddOns = row.Cells[2].Value.ToString(),
                                CreatedBy = "System",
                                Size = productsService.GetSizeByVariantId((int)variant.ProductVariantID)
                            });
                        }
                    }
                }
                else
                {
                    int variantId = productsService.GetProductVariantId(productName, sizeId); // Use productName and sizeId
                    _context.OrderItems.Add(new OrderItem
                    {
                        OrderId = orderId,

                        ProductName = row.Cells[0].Value.ToString(),
                        ProductVariantId = variantId,
                        Quantity = Convert.ToInt32(row.Cells[3].Value),
                        Price = Convert.ToDecimal(row.Cells[4].Value),
                        TotalPrice = Convert.ToDecimal(row.Cells[3].Value) * Convert.ToDecimal(row.Cells[4].Value), // Calculate TotalPrice
                        AddOns = row.Cells[2].Value.ToString(),
                        CreatedBy = "System",
                        Size = row.Cells[1].Value.ToString()

                    });
                }



           
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
