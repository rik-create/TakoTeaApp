using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakoTea.Models;

namespace TakoTea.Helpers
{
    public static class ChartHelper
    {
        public static void InitializeChart<T>(LiveCharts.WinForms.CartesianChart chart, Func<IQueryable<T>> dataRetrievalFunc, Func<T, DateTime> dateSelector, Func<T, decimal> valueSelector, string xAxisTitle, string yAxisTitle)
        {
            var context = new Entities();

            var data = dataRetrievalFunc().ToList() // Retrieve data first
                .GroupBy(item => dateSelector(item).Date) // Group by date
                .Select(g => new { Date = g.Key, Value = g.Sum(valueSelector) }) // Calculate the sum of values for each date
                .OrderBy(x => x.Date)
                .ToList();

            var series = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = yAxisTitle,
                        Values = new ChartValues<decimal>(data.Select(x => x.Value)),
                    }
                };

            chart.AxisX.Add(new Axis
            {
                Title = xAxisTitle,
                Labels = data.Select(x => x.Date.ToString("yyyy-MM-dd")).ToList()
            });

            chart.AxisY.Add(new Axis
            {
                Title = yAxisTitle,
                LabelFormatter = value => value.ToString("C")
            });

            chart.Series = series;
        }
    }
}
