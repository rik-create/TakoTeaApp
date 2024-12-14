#region
using MaterialSkin.Controls;
using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.util;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Helpers;
using TakoTea.Interfaces;
using TakoTea.Models;
using TakoTea.Repository;
using TakoTea.Services;
using TakoTea.Views.Batches;
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
            this.context = context;
            productsService = new ProductsService(context);
            DataGridViewHelper.ApplyDataGridViewStyles(dgViewOrderQueue);
            salesService = new SalesService(context);
            LoadData();
            FormatColumns();

            menuOrderFormService = new MenuOrderFormService();
            dgViewOrderQueue.CellDoubleClick += dataGridViewProductVariantList_CellDoubleClick;
            dgViewOrderQueue.CellClick += dgViewOrderQueue_CellClick;
        }
        private void FormatColumns()
        {
            Image processIcon = imageListButtons.Images["whisk-and-bowl.png"]; // Access image by   

            DataGridViewHelper.AddIconButtonColumn(dgViewOrderQueue, "ColumnProcessOrder", "Process", processIcon);
            DataGridViewHelper.AddIconButtonColumn(dgViewOrderQueue, "ColumnCancelOrder", "Cancel", TakoTea.Views.Properties.Resources.multiply);
            DataGridViewHelper.AddIconButtonColumn(dgViewOrderQueue, "ColumnCompleteOrder", "Complete", TakoTea.Views.Properties.Resources._checked);
            DataGridViewHelper.FormatColumnHeaders(dgViewOrderQueue);
            DataGridViewHelper.HideColumn(dgViewOrderQueue, "GrossProfit");
        }
     private void dgViewOrderQueue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Check for valid cell click
            {
                DataGridViewRow clickedRow = dgViewOrderQueue.Rows[e.RowIndex];
                int orderId = Convert.ToInt32(clickedRow.Cells["OrderId"].Value);

                if (e.ColumnIndex == dgViewOrderQueue.Columns["ColumnCancelOrder"].Index && e.RowIndex >= 0)
                {
                    UpdateOrderStatusForSelectedRows(clickedRow, "Cancelled");
                }
                else if (e.ColumnIndex == dgViewOrderQueue.Columns["ColumnCompleteOrder"].Index && e.RowIndex >= 0)
                {
                    UpdateOrderStatusForSelectedRows(clickedRow, "Completed");
                }
                else if (e.ColumnIndex == dgViewOrderQueue.Columns["ColumnProcessOrder"].Index && e.RowIndex >= 0)
                {
                    UpdateOrderStatusForSelectedRows(clickedRow, "Processing");
                }
            }


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

        private void UpdateOrderStatusForSelectedRows(DataGridViewRow row, string newStatus)
        {
            if (row.Cells["OrderId"].Value == null) return; // Handle potential null value

            int orderId = Convert.ToInt32(row.Cells["OrderId"].Value);
            OrderModel order = context.OrderModels.FirstOrDefault(o => o.OrderId == orderId);

            if (order != null)
            {
                string oldStatus = order.OrderStatus; if (oldStatus == newStatus)
                {
                    MessageBox.Show($"Order '{order.OrderId}' already has the status '{newStatus}'.", "No Changes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                if (newStatus == "Cancelled")
                {
                    ReturnBatchLevels(order);

                    // Log the change before actually changing the status
                    LoggingHelper.LogChange(
                        "OrderModels",
                        order.OrderId,
                        "OrderStatus",
                        oldStatus,               // Use the stored old status
                        "Cancelled",
                        "Updated",
                        $"Order '{order.OrderId}' status updated to 'Cancelled'", ""
                    );
                }

                order.OrderStatus = newStatus;
                order.PaymentStatus = newStatus == "Completed" ? "Paid" : order.PaymentStatus;

                LoggingHelper.LogChange(
                    "OrderModels",
                    order.OrderId,
                    "OrderStatus",
                    oldStatus,
                    newStatus,
                    "Updated",
                    $"Order '{order.OrderId}' status updated to {newStatus}", ""
                );

                context.SaveChanges();
            }

            LoadData(); // Refresh the DataGridView data

            // You might want to remove this MessageBox or make it optional, 
            // as it might be repetitive when clicking on individual cells.
            MessageBox.Show($"Order '{orderId}' updated to '{newStatus}' status.", "Order Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
#endregion
