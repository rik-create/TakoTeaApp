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
using System.Drawing.Printing;
using TakoTea.Helpers;
using Helpers;

namespace TakoTea.Views.Order
{
    public class MenuOrderFormService
    {
        private readonly Entities _context;
        private readonly ProductsService productsService;
        private readonly SalesService salesService;
        InventoryService inventoryService;

        public MenuOrderFormService()
        {

            _context = new Entities();
            productsService = new ProductsService(_context);
            salesService = new SalesService(_context);
            inventoryService = new InventoryService();
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
            try
            {
                var order = _context.OrderModels
                    .Include(o => o.OrderItems)
                    .FirstOrDefault(o => o.OrderId == orderId);

                if (order == null)
                {
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
                    receiptContent.AppendLine($"- {item.ProductName,-15} {item.Quantity} x {item.Price,8:₱#,##0.00} = {item.TotalPrice,9:₱#,##0.00}");
                    if (!string.IsNullOrEmpty(item.AddOns))
                    {
                        receiptContent.AppendLine($"   Add-ons: {item.AddOns}"); // Consistent indentation
                    }
                }

                receiptContent.AppendLine("=".PadRight(42, '='));
                receiptContent.AppendLine($"Total: {order.TotalAmount,35:₱#,##0.00}");

                // Add Paid Amount and Change
                if (order.PaymentAmount.HasValue)
                {
                    receiptContent.AppendLine($"Paid Amount: {order.PaymentAmount.Value,30:₱#,##0.00}");
                }
                if (order.ChangeAmount.HasValue)
                {
                    receiptContent.AppendLine($"Change: {order.ChangeAmount.Value,37:₱#,##0.00}");
                }

                ReceiptForm receiptForm = new ReceiptForm(orderId);
                receiptForm.lblReceiptContent.Text = receiptContent.ToString();
                receiptForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while generating the receipt: {ex.Message}");
            }
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

                var outOfStockButton = new CategoryButtonOrdering();
                outOfStockButton.buttonCategory.Text = "Out of Stock";
                outOfStockButton.buttonCategory.Click += (sender, e) =>
                {
                    LoadMenuVariants(flPanelProductVariantsMenu, dataGridViewOrderList, true); // Show out-of-stock items
                };
                flowLayoutPanelCategories.Controls.Add(outOfStockButton);

            }
        }

        public void LoadMenuVariantsByCategory(string categoryName, FlowLayoutPanel flPanelProductVariantsMenu, DataGridView dg, bool showOutOfStock = false)
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
        .Where(pv => showOutOfStock ? pv.StockLevel <= 0 : pv.StockLevel > 0) // Filter based on showOutOfStock

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
                    if (productVariant.StockLevel <= 0)
                    {
                        productWidget.lblOutOfStock.Visible = true;
                        productWidget.pictureBoxProduct.Visible = false;
                        productWidget.panelProductContainer.Enabled = false;

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
        public void LoadMenuVariants(FlowLayoutPanel flPanelProductVariantsMenu, DataGridView dg, bool showOutOfStock = false)
        {
            if (flPanelProductVariantsMenu == null)
            {
                throw new ArgumentNullException(nameof(flPanelProductVariantsMenu));
            }

            if (_context == null)
            {
                throw new ArgumentNullException(nameof(_context));
            }

            flPanelProductVariantsMenu.Controls.Clear();

            var productVariants = _context.ProductVariants
                .GroupBy(pv => pv.VariantName)
                .Select(g => g.FirstOrDefault())
        .Where(pv => showOutOfStock ? pv.StockLevel <= 0 : pv.StockLevel > 0) // Filter based on showOutOfStock

                .ToList();

            foreach (var variant in productVariants)
            {
                flPanelProductVariantsMenu.Controls.Add(CreateProductWidget(variant, dg, showOutOfStock));
            }


            var comboMeals = _context.ComboMeals.ToList();

            foreach (var comboMeal in comboMeals)
            {
                // Check if any variant in the combo meal is out of stock
                bool isOutOfStock = _context.ComboMealVariants
                    .Where(cmv => cmv.ComboMealID == comboMeal.ComboMealID)
                    .Any(cmv => _context.ProductVariants.Any(pv => pv.ProductVariantID == cmv.ProductVariantID && pv.StockLevel <= 0));

                // Add the combo meal widget, passing the out-of-stock status
                flPanelProductVariantsMenu.Controls.Add(CreateProductWidget(comboMeal, dg, isOutOfStock, showOutOfStock));
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
        private ProductWidget CreateProductWidget(ProductVariant productVariant, DataGridView dg, bool showOutOfStock = false)
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

            if (productVariant.StockLevel <= 0)
            {
                productWidget.lblOutOfStock.Visible = true;
                productWidget.pictureBoxProduct.Visible = false;
                productWidget.panelProductContainer.Enabled = false;
               
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

        private ProductWidget CreateProductWidget(ComboMeal comboMeal, DataGridView dg, bool isOutOfStock, bool showOutOfStock = false)
        {
            var productWidget = new ProductWidget
            {
                lblProductName = { Text = comboMeal.ComboMealName },
                lblProductCategory = { Text = "ComboMeal" }
            };

            try
            {
                productWidget.pictureBoxProduct.Image = ImageHelper.ByteArrayToImage(comboMeal.ImagePath);

            }
            catch (Exception ex)
            {
                                productWidget.pictureBoxProduct.Image = Properties.Resources.multiply;

                MessageBox.Show($"Failed to load image: {ex.Message}");
            }

            if (isOutOfStock)
            {
                productWidget.lblOutOfStock.Visible = true;
                if (!showOutOfStock)
                {
                    productWidget.Enabled = false;
                }
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

                if (variant.StockLevel <= 0)
                {
                    productWidget.lblOutOfStock.Visible = true;
                    productWidget.pictureBoxProduct.Visible = false;
                    productWidget.panelProductContainer.Enabled = false;

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
            try
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
                            CreatedBy = AuthenticationHelper._loggedInUsername,
                            CreatedDate = DateTime.Now,
                            AddOns = AddOns
                        };

                        context.DraftOrderItems.Add(draftOrderItem);
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the draft order: {ex.Message}");
            }
        }

        public void LoadDraftOrder(int draftOrderId, DataGridView dataGridViewOrderList, Label lblTotalInOrderList)
        {
            try
            {
                using (var context = new Entities())
                {
                    var draftOrder = context.DraftOrders.Include(o => o.DraftOrderItems).FirstOrDefault(o => o.DraftOrderId == draftOrderId);

                    if (draftOrder == null)
                    {
                        MessageBox.Show($"Draft order with ID {draftOrderId} not found.");
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
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the draft order: {ex.Message}");
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
                receiptContent.AppendLine($"- {item.ProductName,-15} {item.Quantity} x {item.Price,8:₱#,##0.00} = {item.TotalPrice,9:₱#,##0.00}");
                if (!string.IsNullOrEmpty(item.AddOns))
                {
                    receiptContent.AppendLine($"  Add-ons: {item.AddOns}");
                }
            }

            receiptContent.AppendLine("=".PadRight(42, '='));
            receiptContent.AppendLine($"Total: {order.TotalAmount,35:₱#,##0.00}");

            return receiptContent.ToString();
        }

        // Helper method to print the receipt form
        public void PrintReceiptForm(ReceiptForm receiptForm)
        {
            // 1. Hide the form's border and buttons
            receiptForm.FormBorderStyle = FormBorderStyle.None;
            foreach (Control control in receiptForm.Controls)
            {
                if (control is Button)
                {
                    control.Visible = false;
                }
            }
            receiptForm.buttonSendToEmail.Visible = false;
            receiptForm.buttonPrint.Visible = false;

            // 2. Create a PrintDocument and set its properties
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += (s, pe) =>
            {
                Bitmap bmp = new Bitmap(receiptForm.Width, receiptForm.Height);
                receiptForm.DrawToBitmap(bmp, new Rectangle(0, 0, receiptForm.Width, receiptForm.Height));
                pe.Graphics.DrawImage(bmp, 0, 0);
            };

            // 3. Calculate paper size based on panelReports
            var paperSize = new PaperSize("Custom", receiptForm.Width, receiptForm.Height);
            printDocument.DefaultPageSettings.PaperSize = paperSize;

            // 4. Show print dialog and print
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    printDocument.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred during printing: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // 5. Restore the form's border and buttons
            receiptForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            foreach (Control control in receiptForm.Controls)
            {
                if (control is Button)
                {
                    control.Visible = true;
                }
            }
            receiptForm.buttonSendToEmail.Visible = true;
            receiptForm.buttonPrint.Visible = true;
        }


        public void SendDigitalReceipt(int orderId, string customerEmail, ReceiptForm receiptForm)
        {
            string receiptContent = GenerateReceiptContent(orderId);
            receiptForm.lblReceiptContent.Text = receiptContent.ToString();

            // Hide the form's border
            receiptForm.FormBorderStyle = FormBorderStyle.None;

            receiptForm.buttonSendToEmail.Visible = false;
            receiptForm.buttonPrint.Visible = false;
            // Hide all buttons on the form
            foreach (Control control in receiptForm.Controls)
            {
                if (control is Button)
                {
                    control.Visible = false;
                }
            }

            // Capture the form as an image 
            Bitmap bmp = new Bitmap(receiptForm.Width, receiptForm.Height);
            receiptForm.DrawToBitmap(bmp, new Rectangle(0, 0, receiptForm.Width, receiptForm.Height));

            // Show the form's border again (optional, if you need it later)
            receiptForm.FormBorderStyle = FormBorderStyle.FixedSingle;

     
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
            receiptForm.buttonSendToEmail.Visible = true;
            receiptForm.buttonPrint.Visible = true;
        }


        public void UpdateTotal()
        {
            throw new NotImplementedException();
        }

        public bool ValidateOrder()
        {
            throw new NotImplementedException();
        }


        public void ConfirmOrder(DataGridView dataGridViewOrderList, Label lblTotalInOrderList, Label lblOrderId, ComboBox cmbPaymentMethod, ComboBox cmbPaymentStatus, ComboBox cmbOrderStatus, DateTimePicker orderDate, string customerName, decimal paymentAmount)
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
                    DateTime dateTime = orderDate.Value;

                    // 4. Save the order to the database
                    SaveOrderToDb(dataGridViewOrderList, lblTotalInOrderList, customerName, paymentMethod, orderStatus, dateTime, paymentStatus, paymentAmount);

                    // 5. Update stock levels
                    UpdateStockLevels(dataGridViewOrderList);
                    dataGridViewOrderList.Rows.Clear();

                    // 6. Commit transaction
                    transaction.Commit();

                    // 7. Log the change
                    LoggingHelper.LogChange(
                        "Orders",                // Table name
                        orderId,                 // Record ID
                        "Order Confirmation",    // Column name
                        null,                    // Old value
                        $"Order {orderId} confirmed", // New value
                        "Inserted",             // Action
                        $"Order '{orderId}' confirmed with payment method '{paymentMethod}' and status '{orderStatus}'", ""  // Description
                    );

                    // 8. (Optional) Perform other actions like generating a receipt or printing an order summary
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



        public void UpdateStockLevels(DataGridView dataGridViewOrderList)
        {
            UpdateStockLevelsCallCount++;

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
                                sb.AppendLine($"{productName} - Ingredient {ingredientId}: {quantityPerVariant * quantity} units deducted");
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
        // Helper method to update the stock level in the batch
 
  
        public void SaveOrderToDb(DataGridView dataGridViewOrderList, Label lblTotalInOrderList, string customerName, string paymentMethod, string orderStatus, DateTime orderDate, string paymentStatus, decimal paymentAmount)
        {
            var context = new Entities();

            var order = new OrderModel
            {
                OrderDate = orderDate,
                OrderStatus = orderStatus,
                CustomerName = customerName,
                PaymentMethod = paymentMethod,
                PaymentStatus = paymentStatus,
                TotalAmount = decimal.Parse(lblTotalInOrderList.Text.Substring(1)),
                CreatedBy = AuthenticationHelper._loggedInUsername,
                GrossProfit = 0,
                PaymentAmount = paymentAmount,
                ChangeAmount = paymentAmount - decimal.Parse(lblTotalInOrderList.Text.Substring(1))
            };

            context.OrderModels.Add(order);
            context.SaveChanges();

            int orderId = order.OrderId;

            decimal totalGrossProfit = 0; // To accumulate gross profit for the order

            foreach (DataGridViewRow row in dataGridViewOrderList.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string productName = row.Cells[0].Value.ToString();
                string sizeId = row.Cells[1].Value.ToString();
                int quantity = Convert.ToInt32(row.Cells[3].Value);
                decimal totalPrice = Convert.ToDecimal(row.Cells[4].Value);
                decimal price = totalPrice / quantity; // Calculate individual price

                if (string.IsNullOrEmpty(sizeId)) // Combo meal
                {
                    var comboMeal = _context.ComboMeals.FirstOrDefault(cm => cm.ComboMealName == productName);

                    if (comboMeal != null)
                    {
                        var productVariantIds = _context.ComboMealVariants
                            .Where(cmv => cmv.ComboMealID == comboMeal.ComboMealID)
                            .ToList();

                        foreach (var variant in productVariantIds)
                        {
                            decimal grossProfit = salesService.CalculateGrossProfit((int)variant.ProductVariantID, (int)variant.Quantity, variant.Price.Value);
                            totalGrossProfit += grossProfit; // Add to the total gross profit for the order

                            _context.OrderItems.Add(new OrderItem
                            {
                                OrderId = orderId,
                                ProductName = productsService.GetProductVariantNameById((int)variant.ProductVariantID),
                                ProductVariantId = (int)variant.ProductVariantID,
                                Quantity = (int)variant.Quantity,
                                Price = (decimal)variant.Price,
                                TotalPrice = variant.Price * variant.Quantity,
                                AddOns = row.Cells[2].Value.ToString(),
                                CreatedBy = AuthenticationHelper._loggedInUsername,
                                Size = productsService.GetSizeByVariantId((int)variant.ProductVariantID),
                                GrossProfit = grossProfit,
                                CreatedDate = DateTime.Now
                            });
                        }
                    }
                }
                else // Individual product variant
                {
                    int variantId = productsService.GetProductVariantId(productName, sizeId);

                    decimal grossProfit = salesService.CalculateGrossProfit(variantId, quantity, price);


                    // Calculate gross profit for the individual product variant
                    totalGrossProfit += grossProfit; // Add to the total gross profit for the order

                    _context.OrderItems.Add(new OrderItem
                    {
                        OrderId = orderId,
                        ProductName = row.Cells[0].Value.ToString(),
                        ProductVariantId = variantId,
                        Quantity = Convert.ToInt32(row.Cells[3].Value),
                        Price = price,
                        TotalPrice = totalPrice,
                        AddOns = row.Cells[2].Value.ToString(),
                        CreatedBy = AuthenticationHelper._loggedInUsername,
                        Size = row.Cells[1].Value.ToString(),
                        GrossProfit = grossProfit,
                        CreatedDate = DateTime.Now

                    });
                }
            }

            // Update the GrossProfit in the OrderModel
            var latestOrder = _context.OrderModels.OrderByDescending(o => o.OrderId).FirstOrDefault();
            if (latestOrder != null)
            {
                latestOrder.GrossProfit = totalGrossProfit;
                _context.SaveChanges();
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
