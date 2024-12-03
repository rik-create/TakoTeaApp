using MaterialSkin.Controls;
using System;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows.Controls;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Interfaces;
using TakoTea.Models;
using TakoTea.Services;
using System.Data.Entity;
using TakoTea.Helpers;

namespace TakoTea.View.Orders
{
    public partial class OrdersQueueForm : MaterialForm
    {

        private readonly Entities context;
        private readonly ProductsService productsService;
        private readonly SalesService salesService;
        public OrdersQueueForm(Entities context)
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);

            cmbStatus.SelectedIndexChanged += cmbStatus_SelectedIndexChanged;
            pbCompleted.Click += pbCompleted_Click;
            pbCancelled.Click += pbCancelled_Click;
            btnProcessOrder.Click += btnProcessOrder_Click;
            this.context = context;
            productsService = new ProductsService();
            DataGridViewHelper.ApplyDataGridViewStyles(dgViewOrderQueue);
            salesService = new SalesService(context);
            LoadData();
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
            DataGridViewHelper.HideColumn(dgViewOrderQueue, "OrderId");

        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedStatus = cmbStatus.SelectedItem.ToString();

            // Filter the DataGridView based on the selected status
            (dgViewOrderQueue.DataSource as BindingSource).Filter = $"OrderStatus = '{selectedStatus}'";
        }

        private void pbCompleted_Click(object sender, EventArgs e)
        {
            UpdateOrderStatusForSelectedRows("Completed");
        }

        private void pbCancelled_Click(object sender, EventArgs e)
        {
            // Get the selected rows from the DataGridView
            var selectedRows = dgViewOrderQueue.SelectedRows;

            // Loop through the selected rows and extract the order information
            foreach (DataGridViewRow row in selectedRows)
            {
                int orderId = Convert.ToInt32(row.Cells["OrderId"].Value); // Assuming "OrderId" is the column name

                // Retrieve the order details from the database
                var order = context.OrderModels.Include(o => o.OrderItems).FirstOrDefault(o => o.OrderId == orderId);

                if (order != null)
                {
                    // Return the batch levels to their original state
                    ReturnBatchLevels(order);

                    // Update the order status to "Cancelled"
                    order.OrderStatus = "Cancelled";
                }
            }

            // Save the changes to the database and refresh the DataGridView
            context.SaveChanges();

            LoadData();

        }

        private void ReturnBatchLevels(OrderModel order)
        {
            foreach (var orderItem in order.OrderItems)
            {

                if (context.ComboMeals.Any(cm => cm.ComboMealName == orderItem.ProductName)) // Check if it's a combo meal
                {
                    var comboMeal = context.ComboMeals.FirstOrDefault(cm => cm.ComboMealName == orderItem.ProductName);
                    if (comboMeal != null)
                    {
                        var productVariantIds = context.ComboMealVariants
                            .Where(cmv => cmv.ComboMealID == comboMeal.ComboMealID)
                            .Select(cmv => cmv.ProductVariantID)
                            .ToList();

                        foreach (var variantId in productVariantIds)
                        {
                            var pviIds = productsService.GetProductVariantIngredientIds((int)variantId);
                            foreach (var pviId in pviIds)
                            {
                                var (ingredientId, quantityPerVariant) = productsService.GetIngredientAndQuantity(pviId);
                                productsService.UpdateBatchStockLevel(ingredientId, -quantityPerVariant * orderItem.Quantity, "ReAdd"); // Negative quantity to increase
                            }
                        }
                    }
                }

                else
                {
                    int productVariantId = productsService.GetProductVariantId(orderItem.ProductName, orderItem.Size);

                    // Get the ProductVariantIngredientIDs for the current ProductVariant
                    var productVariantIngredientIds = productsService.GetProductVariantIngredientIds(productVariantId);

                    // Loop through each ProductVariantIngredientID to get the IngredientID and QuantityPerVariant
                    foreach (var pviId in productVariantIngredientIds)
                    {
                        var (ingredientId, quantityPerVariant) = productsService.GetIngredientAndQuantity(pviId);

                        // Return the batch level for the ingredient
                        productsService.UpdateBatchStockLevel(ingredientId, -quantityPerVariant * orderItem.Quantity, "Addition"); // Negative quantity to increase stock
                    }

                    // Return batch levels for add-ons
                    if (!string.IsNullOrEmpty(orderItem.AddOns))
                    {
                        string[] addOnNames = orderItem.AddOns.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string addOnName in addOnNames)
                        {
                            var addOn = context.AddOns.FirstOrDefault(a => a.AddOnName == addOnName);
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
            UpdateOrderStatusForSelectedRows("Processing");
        }

        private void UpdateOrderStatusForSelectedRows(string newStatus)
        {

            foreach (DataGridViewRow row in dgViewOrderQueue.SelectedRows)
            {
                int orderId = Convert.ToInt32(row.Cells["OrderId"].Value); // Assuming "OrderId" is the column name

                var order = context.OrderModels.FirstOrDefault(o => o.OrderId == orderId);
                if (order != null)
                {
                    order.OrderStatus = newStatus;
                }
            }

            context.SaveChanges();
            LoadData();
        }

        private void pbCancelled_Click_1(object sender, EventArgs e)
        {

        }
    }
}
