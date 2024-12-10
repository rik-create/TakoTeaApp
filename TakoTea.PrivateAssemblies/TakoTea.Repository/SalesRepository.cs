using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakoTea.Models;

namespace TakoTea.Repository
{
    public class SalesRepository
    {
        public List<(string ProductName, int TotalSold)> GetSalesPerProduct(DateTime startDate, DateTime endDate)
        {
            using (var context = new Entities())
            {
                var query = from oi in context.OrderItems
                            join o in context.OrderModels on oi.OrderId equals o.OrderId
                            where o.OrderDate >= startDate && o.OrderDate <= endDate
                            group oi by oi.ProductName into g
                            select new
                            {
                                ProductName = g.Key,
                                TotalSold = g.Sum(oi => oi.Quantity)
                            };

                return query.AsEnumerable().Select(x => (x.ProductName, x.TotalSold)).ToList();
            }
        }

        public List<(DateTime Date, decimal? Revenue)> GetGrossRevenuePerDay(DateTime startDate, DateTime endDate)
        {
            using (var context = new Entities())
            {
                var query = from oi in context.OrderItems
                            join o in context.OrderModels on oi.OrderId equals o.OrderId
                            where o.OrderDate >= startDate && o.OrderDate <= endDate
                            group oi by o.OrderDate.Date into g
                            select new
                            {
                                Date = g.Key,
                                Revenue = g.Sum(oi => oi.TotalPrice)
                            };

                return query.AsEnumerable().Select(x => (x.Date, x.Revenue)).ToList();
            }
        }

        public List<(string VariantName, int TotalSold)> GetTop5ProductVariantsBySales(DateTime startDate, DateTime endDate)
        {
            using (var context = new Entities())
            {
                var query = (from oi in context.OrderItems
                             join o in context.OrderModels on oi.OrderId equals o.OrderId
                             where o.OrderDate >= startDate && o.OrderDate <= endDate
                             group oi by oi.ProductName into g
                             select new
                             {
                                 VariantName = g.Key,
                                 TotalSold = g.Sum(oi => oi.Quantity)
                             })
                             .OrderByDescending(x => x.TotalSold)
                             .Take(5);

                return query.AsEnumerable().Select(x => (x.VariantName, x.TotalSold)).ToList();
            }
        }
    }
}
