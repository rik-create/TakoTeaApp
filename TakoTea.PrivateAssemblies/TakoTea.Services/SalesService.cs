using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakoTea.Interfaces;
using TakoTea.Models;

namespace TakoTea.Services
{
    public class SalesService
    {
        private readonly Entities context;
        private readonly ProductsService productsService;

        public SalesService(Entities context)
        {
            this.context = context;
            productsService = new ProductsService(context);
        }// In the SalesService.cs file

        public List<(DateTime Date, decimal? Revenue)> GetGrossRevenuePerDay(int productId)
        {
            using (var context = new Entities())
            {
                var query = from oi in context.OrderItems
                            join o in context.OrderModels on oi.OrderId equals o.OrderId
                            join pv in context.ProductVariants on oi.ProductVariantId equals pv.ProductVariantID
                            where pv.ProductID == productId
                            group oi by o.OrderDate into g
                            select new
                            {
                                OrderDate = g.Key,
                                Revenue = g.Sum(oi => oi.TotalPrice)
                            };

                return query.AsEnumerable()
                            .Select(x => (x.OrderDate.Date, x.Revenue))
                            .ToList();
            }
        }

        public List<(string ProductName, int Sales)> GetSalesPerProduct(int productId)
        {
            using (var context = new Entities())
            {
                var query = from oi in context.OrderItems
                            join pv in context.ProductVariants on oi.ProductVariantId equals pv.ProductVariantID
                            where pv.ProductID == productId
                            group oi by pv.VariantName into g
                            select new
                            {
                                ProductName = g.Key,
                                Sales = g.Sum(oi => oi.Quantity)
                            };

                return query.AsEnumerable()
                            .Select(x => (x.ProductName, x.Sales))
                            .ToList();
            }
        }

        public List<(string VariantName, int Sales)> GetTop5ProductVariantsBySales(int productId)
        {
            using (var context = new Entities())
            {
                var query = (from oi in context.OrderItems
                             join pv in context.ProductVariants on oi.ProductVariantId equals pv.ProductVariantID
                             where pv.ProductID == productId
                             group oi by pv.VariantName into g
                             select new
                             {
                                 VariantName = g.Key,
                                 Sales = g.Sum(oi => oi.Quantity)
                             })
                             .OrderByDescending(x => x.Sales)
                             .Take(5);

                return query.AsEnumerable()
                            .Select(x => (x.VariantName, x.Sales))
                            .ToList();
            }
        }


        public decimal CalculateTotalRevenue(DateTime startDate, DateTime endDate)
            {
                return context.OrderModels
                    .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
                    .Sum(o => o.TotalAmount);
            }

/*        public decimal CalculateTotalProfit(DateTime startDate, DateTime endDate)
        {
            return context.OrderItems
                .Where(oi => oi.OrderModel.OrderDate >= startDate && oi.Order.OrderDate <= endDate)
                .Sum(oi => oi.GrossProfit);
        }*/
        public decimal CalculateGrossProfit(int variantId, int quantity, decimal price)
        {
            decimal grossProfit = 0;
            decimal cogs = 0;
            decimal totalPrice = price * quantity;
            var ingredientAndQuantity = productsService.GetIngredientIdsAndQuantityPerVariantByProductVariantId(variantId);

            foreach (var (ingredientId, quantityPerVariant) in ingredientAndQuantity)
            {
                var batch = context.Batches.FirstOrDefault(b => b.IngredientID == ingredientId);
                if (batch != null)
                {
                    decimal costPerUnit = batch.BatchCost / batch.InitialStockLevel.Value;
                    decimal ingredientCost = quantityPerVariant * costPerUnit * quantity;
                    cogs += ingredientCost;
                }
            }
            grossProfit = totalPrice - cogs;
            return grossProfit;
        }
        public List<SalesData> GetOrderQueue()
        {
            return context.OrderModels
                .Where(o => o.OrderStatus == "New" || o.OrderStatus == "Processing")
                .OrderByDescending(o => o.OrderDate) // Sort by OrderDate in descending order
                .Select(o => new SalesData
                {
                    OrderId = o.OrderId,
                    OrderDate = o.OrderDate,
                    CustomerName = o.CustomerName,
                    PaymentStatus = o.PaymentStatus,
                    PaymentMethod = o.PaymentMethod,
                    PaymentAmount = o.PaymentAmount ?? 0,
                    ChangeAmount = o.ChangeAmount ?? 0,

                    TotalAmount = o.TotalAmount,
                    OrderStatus = o.OrderStatus
                }).ToList();
        }
        public List<SalesData> GetNewOrders()
        {
            return context.OrderModels
                .Where(o => (o.OrderStatus == "New"))
                .Select(o => new SalesData
                {
                    OrderId = o.OrderId,
                    OrderDate = o.OrderDate,
                    CustomerName = o.CustomerName,
                    PaymentMethod = o.PaymentMethod,
                    TotalAmount = o.TotalAmount,
                }).ToList();
        }
        public List<SalesData> GetAllSales()
        {
            return context.OrderModels.Select(o => new SalesData
            {
                OrderId = o.OrderId,
                OrderDate = o.OrderDate,
                OrderStatus = o.OrderStatus,

                CustomerName = o.CustomerName,
                PaymentStatus = o.PaymentStatus,
                PaymentMethod = o.PaymentMethod,
                PaymentAmount = o.PaymentAmount ?? 0, // Handle null values
                TotalAmount = o.TotalAmount,
                GrossProfit = o.GrossProfit ?? 0

            }).ToList();
        }
        public OrderModel GetOrderModelById(int orderId)
        {
            return context.OrderModels.FirstOrDefault(o => o.OrderId == orderId);
        }

        public List<OrderModel> GetAllOrderModels()
        {
            return context.OrderModels.ToList();
        }

        
    }

    public class SalesData
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string PaymentMethod { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal PaymentAmount { get; set; }

        public decimal ChangeAmount { get; set; }
        public decimal GrossProfit { get; set; }

        public string OrderStatus { get; set; }
        public string PaymentStatus { get; set; }

    }
}
