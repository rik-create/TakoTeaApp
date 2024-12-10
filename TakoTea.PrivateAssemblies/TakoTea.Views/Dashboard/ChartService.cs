using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakoTea.Views.Dashboard
{
    public class ChartService
    {
        public void InitializeSalesPerProductChart(LiveCharts.WinForms.CartesianChart chart, List<(string ProductName, int TotalSold)> salesData)
        {
            chart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Total Sold",
                    Values = new ChartValues<int>(salesData.Select(x => x.TotalSold)),
                    DataLabels = true
                }
            };

            chart.AxisX.Add(new Axis
            {
                Title = "Product",
                Labels = salesData.Select(x => x.ProductName).ToList()
            });

            chart.AxisY.Add(new Axis
            {
                Title = "Total Sold"
            });
        }

        public void InitializeGrossRevenueChart(LiveCharts.WinForms.CartesianChart chart, List<(DateTime Date, decimal Revenue)> grossRevenueData)
        {
            chart.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Gross Revenue",
                    Values = new ChartValues<decimal>(grossRevenueData.Select(x => x.Revenue)),
                }
            };

            chart.AxisX.Add(new Axis
            {
                Title = "Date",
                Labels = grossRevenueData.Select(x => x.Date.ToShortDateString()).ToList()
            });

            chart.AxisY.Add(new Axis
            {
                Title = "Revenue"
            });
        }

        public void InitializePieChartTop5ProductVariant(LiveCharts.WinForms.PieChart chart, List<(string VariantName, int TotalSold)> top5VariantsData)
        {
            chart.Series = new SeriesCollection();
            foreach (var variant in top5VariantsData)
            {
                chart.Series.Add(new PieSeries
                {
                    Title = variant.VariantName,
                    Values = new ChartValues<int> { variant.TotalSold },
                    DataLabels = true
                });
            }
        }
    }
}
