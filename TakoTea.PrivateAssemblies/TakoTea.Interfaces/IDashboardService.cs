using System;
using System.Collections.Generic;
using TakoTea.Models.DashboardPage;

namespace TakoTea.Interfaces
{
    public interface IDashboardService
    {
        // KPIs and Metrics
        int GetNumberOfOrders(DateTime? startDate, DateTime? endDate);
        decimal GetTotalRevenue(DateTime? startDate, DateTime? endDate);
        decimal GetTotalProfit(DateTime? startDate, DateTime? endDate);

        // Visual Components
        List<RevenueDataPoint> GetGrossRevenueOverTime(DateTime? startDate, DateTime? endDate);
        List<CategoryRevenue> GetRevenueContributionByCategory(DateTime? startDate, DateTime? endDate);

        // DataGrids
        List<LowStockItem> GetLowStockItems(bool isLowStock);
        List<OrderQueueItem> GetOrderQueue();

        // Counters
        int GetTotalProductCategories();
        int GetTotalProductVariants();
        int GetTotalIngredients();

        // Date Filtering
        DashboardMetrics GetMetricsByDateRange(DateTime? startDate, DateTime? endDate);
    }
}
