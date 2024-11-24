using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakoTea.Models.DashboardPage
{
    public class DashboardModel
    {
    }
    public class RevenueDataPoint
    {
        public DateTime Date { get; set; }
        public decimal GrossRevenue { get; set; }
    }

    public class CategoryRevenue
    {
        public string CategoryName { get; set; }
        public decimal Revenue { get; set; }
    }

    public class LowStockItem
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public int CurrentStock { get; set; }
        public int ReorderLevel { get; set; }
    }

    public class OrderQueueItem
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
    }

    public class DashboardMetrics
    {
        public int NumberOfOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalProfit { get; set; }
        public List<RevenueDataPoint> RevenueOverTime { get; set; }
        public List<CategoryRevenue> RevenueByCategory { get; set; }
    }
}
