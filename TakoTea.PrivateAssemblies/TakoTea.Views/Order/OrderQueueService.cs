using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakoTea.Models;
using TakoTea.Services;

namespace TakoTea.Views.Order
{
    public class OrderQueueService
    {
        private readonly ProductsService productsService;
        private readonly Entities _context;

        public OrderQueueService(ProductsService productsService, Entities context)
        {
            this.productsService = productsService;
            this._context = context;
        }


        public void SetupGetOrderData(int orderId, OrderModel order)
        {
            var mockOrder = new Mock<OrderModel>();
            mockOrder.Setup(o => o.OrderId).Returns(orderId);
            mockOrder.Setup(o => o.CustomerName).Returns(order.CustomerName);
            mockOrder.Setup(o => o.PaymentMethod).Returns(order.PaymentMethod);
            mockOrder.Setup(o => o.PaymentStatus).Returns(order.PaymentStatus);
            mockOrder.Setup(o => o.TotalAmount).Returns(order.TotalAmount);
            mockOrder.Setup(o => o.CreatedBy).Returns(order.CreatedBy);
            mockOrder.Setup(o => o.ModifiedBy).Returns(order.ModifiedBy);
            mockOrder.Setup(o => o.OrderStatus).Returns(order.OrderStatus);
        }

        public void SetupUpdateBatchStockLevel(int ingredientId, decimal quantityUsed)
        {
            var mockProductsService = new Mock<ProductsService>();
            mockProductsService.Setup(ps => ps.UpdateBatchStockLevel(ingredientId, quantityUsed, It.IsAny<string>()));
        }

        public void VerifyUpdateBatchStockLevel(int ingredientId, decimal quantityUsed, Times times)
        {
            var mockProductsService = new Mock<ProductsService>();
            mockProductsService.Verify(ps => ps.UpdateBatchStockLevel(ingredientId, quantityUsed, It.IsAny<string>()), times);
        }

   

        public void UpdateOrderStatusForSelectedRows(DataGridView dgViewOrderQueue, string newStatus)
        {
            var context = new Entities();
            var transaction = context.Database.BeginTransaction();
            try
            {
                foreach (DataGridViewRow row in dgViewOrderQueue.SelectedRows)
                {
                    int orderId = Convert.ToInt32(row.Cells["OrderId"].Value);
                    var order = context.OrderModels.Include("OrderItems").FirstOrDefault(o => o.OrderId == orderId); // Fix the Include method

                    if (order != null)
                    {
                        if (newStatus == "Cancelled")
                        {
                            ReturnBatchLevels(order);
                        }

                        order.OrderStatus = newStatus;
                    }
                }

                context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void ReturnBatchLevels(OrderModel order)
        {
            foreach (var orderItem in order.OrderItems)
            {
                if (_context.ComboMeals.Any(cm => cm.ComboMealName == orderItem.ProductName))
                {
                    var comboMeal = _context.ComboMeals.FirstOrDefault(cm => cm.ComboMealName == orderItem.ProductName);
                    if (comboMeal != null)
                    {
                        var productVariantIds = _context.ComboMealVariants
                            .Where(cmv => cmv.ComboMealID == comboMeal.ComboMealID)
                            .Select(cmv => cmv.ProductVariantID)
                            .ToList();

                        foreach (var variantId in productVariantIds)
                        {
                            var pviIds = productsService.GetProductVariantIngredientIds((int)variantId);
                            foreach (var pviId in pviIds)
                            {
                                var (ingredientId, quantityPerVariant) = productsService.GetIngredientAndQuantity(pviId);
                                productsService.UpdateBatchStockLevel(ingredientId, -quantityPerVariant * orderItem.Quantity, "Addition");
                            }
                        }
                    }
                }
                else
                {
                    int productVariantId = productsService.GetProductVariantId(orderItem.ProductName, orderItem.Size);
                    var productVariantIngredientIds = productsService.GetProductVariantIngredientIds(productVariantId);

                    foreach (var pviId in productVariantIngredientIds)
                    {
                        var (ingredientId, quantityPerVariant) = productsService.GetIngredientAndQuantity(pviId);
                        productsService.UpdateBatchStockLevel(ingredientId, -quantityPerVariant * orderItem.Quantity, "Addition");
                    }

                    if (!string.IsNullOrEmpty(orderItem.AddOns))
                    {
                        string[] addOnNames = orderItem.AddOns.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string addOnName in addOnNames)
                        {
                            var addOn = _context.AddOns.FirstOrDefault(a => a.AddOnName == addOnName);
                            if (addOn != null)
                            {
                                int addOnIngredientId = addOn.IngredientID ?? 0;
                                decimal quantityUsed = (decimal)(addOn.QuantityUsedPerProduct * orderItem.Quantity);
                                productsService.UpdateBatchStockLevel(addOnIngredientId, -quantityUsed, "Addition");
                            }
                        }
                    }
                }
            }
        }
    }
}
