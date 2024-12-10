using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
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
            _context = context;
        }


        public void SetupGetOrderData(int orderId, OrderModel order)
        {
            Mock<OrderModel> mockOrder = new Mock<OrderModel>();
            _ = mockOrder.Setup(o => o.OrderId).Returns(orderId);
            _ = mockOrder.Setup(o => o.CustomerName).Returns(order.CustomerName);
            _ = mockOrder.Setup(o => o.PaymentMethod).Returns(order.PaymentMethod);
            _ = mockOrder.Setup(o => o.PaymentStatus).Returns(order.PaymentStatus);
            _ = mockOrder.Setup(o => o.TotalAmount).Returns(order.TotalAmount);
            _ = mockOrder.Setup(o => o.CreatedBy).Returns(order.CreatedBy);
            _ = mockOrder.Setup(o => o.ModifiedBy).Returns(order.ModifiedBy);
            _ = mockOrder.Setup(o => o.OrderStatus).Returns(order.OrderStatus);
        }

        public void SetupUpdateBatchStockLevel(int ingredientId, decimal quantityUsed)
        {
            Mock<ProductsService> mockProductsService = new Mock<ProductsService>();
            _ = mockProductsService.Setup(ps => ps.UpdateBatchStockLevel(ingredientId, quantityUsed, It.IsAny<string>()));
        }

        public void VerifyUpdateBatchStockLevel(int ingredientId, decimal quantityUsed, Times times)
        {
            Mock<ProductsService> mockProductsService = new Mock<ProductsService>();
            mockProductsService.Verify(ps => ps.UpdateBatchStockLevel(ingredientId, quantityUsed, It.IsAny<string>()), times);
        }



        public void UpdateOrderStatusForSelectedRows(DataGridView dgViewOrderQueue, string newStatus)
        {
            Entities context = new Entities();
            System.Data.Entity.DbContextTransaction transaction = context.Database.BeginTransaction();
            try
            {
                foreach (DataGridViewRow row in dgViewOrderQueue.SelectedRows)
                {
                    int orderId = Convert.ToInt32(row.Cells["OrderId"].Value);
                    OrderModel order = context.OrderModels.Include("OrderItems").FirstOrDefault(o => o.OrderId == orderId); // Fix the Include method

                    if (order != null)
                    {
                        if (newStatus == "Cancelled")
                        {
                            ReturnBatchLevels(order);
                        }

                        order.OrderStatus = newStatus;
                    }
                }

                _ = context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                _ = MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void ReturnBatchLevels(OrderModel order)
        {
            foreach (OrderItem orderItem in order.OrderItems)
            {
                if (_context.ComboMeals.Any(cm => cm.ComboMealName == orderItem.ProductName))
                {
                    ComboMeal comboMeal = _context.ComboMeals.FirstOrDefault(cm => cm.ComboMealName == orderItem.ProductName);
                    if (comboMeal != null)
                    {
                        List<int?> productVariantIds = _context.ComboMealVariants
                            .Where(cmv => cmv.ComboMealID == comboMeal.ComboMealID)
                            .Select(cmv => cmv.ProductVariantID)
                            .ToList();

                        foreach (int? variantId in productVariantIds)
                        {
                            List<int> pviIds = productsService.GetProductVariantIngredientIds((int)variantId);
                            foreach (int pviId in pviIds)
                            {
                                (int ingredientId, decimal quantityPerVariant) = productsService.GetIngredientAndQuantity(pviId);
                                productsService.UpdateBatchStockLevel(ingredientId, -quantityPerVariant * orderItem.Quantity, "Addition");
                            }
                        }
                    }
                }
                else
                {
                    int productVariantId = productsService.GetProductVariantId(orderItem.ProductName, orderItem.Size);
                    List<int> productVariantIngredientIds = productsService.GetProductVariantIngredientIds(productVariantId);

                    foreach (int pviId in productVariantIngredientIds)
                    {
                        (int ingredientId, decimal quantityPerVariant) = productsService.GetIngredientAndQuantity(pviId);
                        productsService.UpdateBatchStockLevel(ingredientId, -quantityPerVariant * orderItem.Quantity, "Addition");
                    }

                    if (!string.IsNullOrEmpty(orderItem.AddOns))
                    {
                        string[] addOnNames = orderItem.AddOns.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string addOnName in addOnNames)
                        {
                            AddOn addOn = _context.AddOns.FirstOrDefault(a => a.AddOnName == addOnName);
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
