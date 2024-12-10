using MaterialSkin.Controls;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Helpers;
using TakoTea.Models;
using TakoTea.Services;
using TakoTea.Views.Order;
namespace TakoTea.View.Orders
{
    public partial class OrdersQueueForm : MaterialForm
    {
        private readonly Entities context;
        private readonly ProductsService productsService;
        private readonly SalesService salesService;
        private MenuOrderFormService menuOrderFormService;

        public OrdersQueueForm(Entities context)
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            pbCompleted.Click += pbCompleted_Click;
            pbCancelled.Click += pbCancelled_Click;
            btnProcessOrder.Click += btnProcessOrder_Click;
            this.context = context;
            productsService = new ProductsService(context);
            DataGridViewHelper.ApplyDataGridViewStyles(dgViewOrderQueue);
            salesService = new SalesService(context);
            LoadData();
            DataGridViewHelper.FormatColumnHeaders(dgViewOrderQueue);
            DataGridViewHelper.HideColumn(dgViewOrderQueue, "GrossProfit");

            menuOrderFormService = new MenuOrderFormService();

            dgViewOrderQueue.CellDoubleClick += dataGridViewProductVariantList_CellDoubleClick;
        }

        private void dataGridViewProductVariantList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if a valid row was double-clicked
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && !dgViewOrderQueue.Rows[e.RowIndex].IsNewRow)
            {
                try
                {
                    // Get the ProductVariantID from the selected row
                    int orderId = Convert.ToInt32(dgViewOrderQueue.Rows[e.RowIndex].Cells["OrderId"].Value); // Assuming "ProductVariantID" is the column name

                    // Create and show the EditProductVariantModal
                    menuOrderFormService.GenerateReceipt(orderId);
                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show("Error opening the edit modal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }


        }
        private void materialLabel4_Click(object sender, EventArgs e)
        {
        }
        // Assuming your OrderModel class has properties like OrderId, OrderStatus, etc.
        private void LoadData()
        {
            // Retrieve both Product and ProductVariant data
            // Bind the data to the DataGridView
            DataGridViewHelper.LoadData(
                dataRetrievalFunc: () => salesService.GetOrderQueue(),
                dataGridView: dgViewOrderQueue,
                bindingSource: bindingSource1,
                bindingNavigator: bindingNavigator1,
                errorMessage: "Failed to load product variants."
            );
            // Hide the ImagePath column
            // Count the number of new orders
            int newOrdersCount = salesService.GetOrderQueue().Count(o => o.OrderStatus == "New");
            labelNewOrdersCount.Text = $"Total new orders: {newOrdersCount}";
            // Count the number of processing orders
            int processingOrdersCount = salesService.GetOrderQueue().Count(o => o.OrderStatus == "Processing");
            labelProcessingOrdersCount.Text = $"Total processing orders: {processingOrdersCount}";
            /*      dgViewOrderQueue.Columns["TotalAmount"].DefaultCellStyle.Format = "₱#,##0.00";
                  dgViewOrderQueue.Columns["PaymentAmount"].DefaultCellStyle.Format = "₱#,##0.00";
                  dgViewOrderQueue.Columns["ChangeAmount"].DefaultCellStyle.Format = "₱#,##0.00";*/
        }
        private void pbCompleted_Click(object sender, EventArgs e)
        {
            UpdateOrderStatusForSelectedRows("Completed");
        }
        private void pbCancelled_Click(object sender, EventArgs e)
        {
            // Get the selected rows from the DataGridView
            DataGridViewSelectedRowCollection selectedRows = dgViewOrderQueue.SelectedRows;
            // Loop through the selected rows and extract the order information
            foreach (DataGridViewRow row in selectedRows)
            {
                int orderId = Convert.ToInt32(row.Cells["OrderId"].Value); // Assuming "OrderId" is the column name
                // Retrieve the order details from the database
                OrderModel order = context.OrderModels.Include(o => o.OrderItems).FirstOrDefault(o => o.OrderId == orderId);
                if (order != null)
                {
                    // Return the batch levels to their original state
                    ReturnBatchLevels(order);
                    // Update the order status to "Cancelled"
                    order.OrderStatus = "Cancelled";
                    // Log the change
                    LoggingHelper.LogChange(
                        "OrderModels",                // Table name
                        order.OrderId,                // Record ID
                        "OrderStatus",                // Column name
                        null,                         // Old value (null for new batch)
                        "Cancelled",                  // New value
                        "Updated",                    // Action
                        $"Order '{order.OrderId}' status updated to 'Cancelled'", ""  // Description
                    );
                }
            }
            // Save the changes to the database and refresh the DataGridView
            _ = context.SaveChanges();
            LoadData();
        }
        private void ReturnBatchLevels(OrderModel order)
        {
            foreach (OrderItem orderItem in order.OrderItems)
            {
                if (context.ComboMeals.Any(cm => cm.ComboMealName == orderItem.ProductName)) // Check if it's a combo meal
                {
                    ComboMeal comboMeal = context.ComboMeals.FirstOrDefault(cm => cm.ComboMealName == orderItem.ProductName);
                    if (comboMeal != null)
                    {
                        System.Collections.Generic.List<int?> productVariantIds = context.ComboMealVariants
                            .Where(cmv => cmv.ComboMealID == comboMeal.ComboMealID)
                            .Select(cmv => cmv.ProductVariantID)
                            .ToList();
                        foreach (int? variantId in productVariantIds)
                        {
                            System.Collections.Generic.List<int> pviIds = productsService.GetProductVariantIngredientIds((int)variantId);
                            foreach (int pviId in pviIds)
                            {
                                (int ingredientId, decimal quantityPerVariant) = productsService.GetIngredientAndQuantity(pviId);
                                productsService.UpdateBatchStockLevel(ingredientId, -quantityPerVariant * orderItem.Quantity, "ReAdd"); // Negative quantity to increase
                            }
                        }
                    }
                }
                else
                {
                    int productVariantId = productsService.GetProductVariantId(orderItem.ProductName, orderItem.Size);
                    // Get the ProductVariantIngredientIDs for the current ProductVariant
                    System.Collections.Generic.List<int> productVariantIngredientIds = productsService.GetProductVariantIngredientIds(productVariantId);
                    // Loop through each ProductVariantIngredientID to get the IngredientID and QuantityPerVariant
                    foreach (int pviId in productVariantIngredientIds)
                    {
                        (int ingredientId, decimal quantityPerVariant) = productsService.GetIngredientAndQuantity(pviId);
                        // Return the batch level for the ingredient
                        productsService.UpdateBatchStockLevel(ingredientId, -quantityPerVariant * orderItem.Quantity, "Addition"); // Negative quantity to increase stock
                    }
                    // Return batch levels for add-ons
                    if (!string.IsNullOrEmpty(orderItem.AddOns))
                    {
                        string[] addOnNames = orderItem.AddOns.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string addOnName in addOnNames)
                        {
                            AddOn addOn = context.AddOns.FirstOrDefault(a => a.AddOnName == addOnName);
                            if (addOn != null)
                            {
                                int addOnIngredientId = addOn.IngredientID ?? 0;
                                decimal quantityUsed = (decimal)(addOn.QuantityUsedPerProduct * orderItem.Quantity);
                                // Return the batch level for the add-on
                                productsService.UpdateBatchStockLevel(addOnIngredientId, -quantityUsed, "Addition"); // Negative quantity to increase stock
                            }
                        }
                    }
                }
                // Get the ProductVariantID
            }
        }
        private void btnProcessOrder_Click(object sender, EventArgs e)
        {
            ;
        }
        private void UpdateOrderStatusForSelectedRows(string newStatus)
        {
            int updatedCount = 0; // Counter for updated orders

            foreach (DataGridViewRow row in dgViewOrderQueue.SelectedRows)
            {
                int orderId = Convert.ToInt32(row.Cells["OrderId"].Value);
                OrderModel order = context.OrderModels.FirstOrDefault(o => o.OrderId == orderId);
                if (order != null)
                {
                    order.OrderStatus = newStatus;
                    order.PaymentStatus = newStatus == "Completed" ? "Paid" : order.PaymentStatus;

                    // ... (your logging code) ...

                    updatedCount++; // Increment the counter
                }
            }

            _ = context.SaveChanges();
            LoadData();

            // Display message box indicating the number of updated orders
            MessageBox.Show($"{updatedCount} order(s) updated to '{newStatus}' status.", "Orders Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void pbCancelled_Click_1(object sender, EventArgs e)
        {
            UpdateOrderStatusForSelectedRows("Cancelled");
            Close();
            OrdersQueueForm newForm = new OrdersQueueForm(context);
            newForm.Show();
        }
        private void btnProcessOrder_Click_1(object sender, EventArgs e)
        {
            UpdateOrderStatusForSelectedRows("Processing");
            Close();
            OrdersQueueForm newForm = new OrdersQueueForm(context);
            newForm.Show();
        }
        private void pbCompleted_Click_1(object sender, EventArgs e)
        {
            UpdateOrderStatusForSelectedRows("Completed");
            Close();
            OrdersQueueForm newForm = new OrdersQueueForm(context);
            newForm.Show(); ;
        }
        private void dgViewOrderQueue_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewHelper.SortDataGridView(dgViewOrderQueue, e.ColumnIndex);
        }
        private void FilterOrderQueue()
        {
            string searchTerm = txtBoxSearchOrders.Text.ToLower().Trim();
            System.Collections.Generic.IEnumerable<SalesData> filteredOrder = salesService.GetOrderQueue()
                .Where(sale =>
                    string.IsNullOrWhiteSpace(searchTerm) ||
                     sale.OrderId.ToString().Contains(searchTerm) ||
                     sale.CustomerName.ToLower().Contains(searchTerm) ||
                     sale.PaymentMethod.ToLower().Contains(searchTerm) ||
                     sale.OrderDate.ToString("yyyy-MM-dd HH:mm:ss").Contains(searchTerm)
                );
            DataGridViewHelper.UpdateGrid(dgViewOrderQueue, bindingSource1, filteredOrder.ToList());
        }
        private void txtBoxSearchOrders_Click(object sender, EventArgs e)
        {
            FilterOrderQueue();
        }
        private void txtBoxSearchOrders_TextChanged(object sender, EventArgs e)
        {
            FilterOrderQueue();
        }
    }
}
