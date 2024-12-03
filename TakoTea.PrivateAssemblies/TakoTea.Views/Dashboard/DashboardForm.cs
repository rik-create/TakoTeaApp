using LiveCharts;
using LiveCharts.Wpf;
using MaterialSkin.Controls;
using System.Linq;
using System;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Helpers;
using TakoTea.Models;
using TakoTea.Repository;
using TakoTea.Services;
using System.Runtime.InteropServices.ComTypes;
using System.Globalization;
using TakoTea.View.Orders;
using System.Collections.Generic;
using TakoTea.Views.MainForm;
using LiveCharts.Defaults;
namespace TakoTea.Views.Dashboard
{
    public partial class DashboardForm : MaterialForm
    {

        private readonly Entities context;
        private readonly SalesService salesService;
        private readonly IngredientRepository ingredientRepository;

        private TimeSpan span;

        private List<OrderModel> orders; // Declare orders as a class-level variable
        public DashboardForm()
        {
            InitializeComponent();
            context = new Entities();
            salesService = new SalesService(context);
            ingredientRepository = new IngredientRepository(context);
            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);   
            LoadDashboard();
            InitializeGrossRevenueChart(DateTime.Now.AddYears(-7), DateTime.Now);
            InitializeSalesPerProductChart(DateTime.Now.AddYears(-1), DateTime.Now);
            InitializePieChartTop5ProductVariant(DateTime.Now.AddYears(-7), DateTime.Now);
            InitializeDashboardMetrics(DateTime.Now.AddYears(-7), DateTime.Now);
            InitializeTopProductLabels();


            btnToday.Click += btnToday_Click;
            btnLast7Days.Click += btnLast7Days_Click;
            btnLast30Days.Click += btnLast30Days_Click;
            btnThisMonth.Click += btnThisMonth_Click;

            DataGridViewHelper.ApplyDataGridViewStyles(dataGridViewNewOrders);

            DataGridViewHelper.ApplyDataGridViewStyles(dgvUnderstock);


        }
        private void InitializeSalesPerProductChart(DateTime startDate, DateTime endDate)
        {
            // Fetch data from OrderItem, ProductVariants, and Product tables, filtering by date
            var salesData = context.OrderItems
                .Where(oi => oi.CreatedDate >= startDate && oi.CreatedDate <= endDate) // Filter by date
                .Join(context.ProductVariants, oi => oi.ProductVariantId, pv => pv.ProductVariantID, (oi, pv) => new { oi, pv })
                .Join(context.Products, x => x.pv.ProductID, p => p.ProductID, (x, p) => new { x.oi, x.pv, p })
                .GroupBy(x => x.p.ProductName)
                .Select(g => new
                {
                    ProductName = g.Key,
                    TotalSold = g.Sum(x => x.oi.Quantity)
                })
                .ToList();
            cartesianChartSalesPerProduct.Series.Clear();
            cartesianChartSalesPerProduct.AxisX.Clear();
            cartesianChartSalesPerProduct.AxisY.Clear();

            // Create a row series for the chart
            cartesianChartSalesPerProduct.Series = new SeriesCollection
    {
        new RowSeries
        {
            Title = "Sales per Product",
            Values = new ChartValues<int>(salesData.Select(x => x.TotalSold)),
            DataLabels = true,
            LabelPoint = point => point.X.ToString()
        }
    };

            // Set chart labels
            cartesianChartSalesPerProduct.AxisY.Add(new Axis
            {
                Labels = salesData.Select(x => x.ProductName).ToList()
            });

            // Dynamically adjust X-axis based on sold items
            int maxSold = salesData.Any() ? salesData.Max(x => x.TotalSold) : 10; // Get maximum sold or default to 10
            int xAxisStep = maxSold <= 50 ? 5 : maxSold <= 200 ? 20 : 50; // Adjust step based on maxSold

            cartesianChartSalesPerProduct.AxisX.Add(new Axis
            {
                LabelFormatter = value => value.ToString("N"),
                MaxValue = maxSold, // Set max value
                Separator = new Separator { Step = xAxisStep } // Set step for separators
            });

            // Add a tooltip
            var tooltip = new DefaultTooltip
            {
                SelectionMode = TooltipSelectionMode.SharedYValues
            };
            cartesianChartSalesPerProduct.DataTooltip = tooltip;
            cartesianChartSalesPerProduct.LegendLocation = LegendLocation.Bottom;

        }
        private void InitializeGrossRevenueChart(DateTime startDate, DateTime endDate)
        {
            try
            {
                cartesianChartGrossRevenue.AxisX.Clear();
                cartesianChartGrossRevenue.AxisY.Clear();
                cartesianChartGrossRevenue.Zoom = ZoomingOptions.X;  // Enable zooming on the X-axis
                cartesianChartGrossRevenue.Pan = PanningOptions.X;
                // Fetch order data within the specified date range
                orders = context.OrderModels // Assign to the class-level 'orders' variable
                  .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
                  .OrderBy(o => o.OrderDate)
                  .ToList();
                /*               DateTime minOrderDate = orders.Any() ? orders.Min(o => o.OrderDate).Date : startDate;
                               DateTime maxOrderDate = orders.Any() ? orders.Max(o => o.OrderDate).Date : endDate;

                               // Adjust startDate and endDate based on the actual order dates
                               startDate = startDate < minOrderDate ? minOrderDate : startDate;
                               endDate = endDate > maxOrderDate ? maxOrderDate : endDate;*/

                TimeSpan timeSpan = endDate - startDate;

                Dictionary<string, decimal> revenueByLabel = new Dictionary<string, decimal>();
                Dictionary<string, decimal> grossProfitByLabel = new Dictionary<string, decimal>();
                var xAxisLabels = GenerateXAxisLabels(startDate, endDate);

                foreach (string label in xAxisLabels)
                {
                    revenueByLabel[label] = 0;
                    grossProfitByLabel[label] = 0;
                }
                // Initialize the dictionaries with labels and zero revenue/profit
                try
               {
                    foreach (var order in orders)
                    {
                        string label = GetLabelForDate(order.OrderDate, timeSpan, startDate, endDate);
                        revenueByLabel[label] += order.TotalAmount;
                        grossProfitByLabel[label] += order.GrossProfit ?? 0; // Handle null GrossProfit
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while processing orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




                // Group orders by date and calculate revenue based on the timeSpan
                var revenueData = orders
                    .GroupBy(o =>
                    {
                        if (timeSpan.Days <= 1) // Hourly labels
                            return new DateTime(o.OrderDate.Year, o.OrderDate.Month, o.OrderDate.Day, o.OrderDate.Hour, 0, 0); // Group by hour
                        else if (timeSpan.Days <= 15) // Daily labels
                            return o.OrderDate.Date; // Group by exact date
                        else if (timeSpan.Days <= 31) // Weekly labels (same month)
                            return o.OrderDate.Date.AddDays(-(o.OrderDate.Day - 1) % 7); // Group by week starting from the first day of the month
                        else if (timeSpan.Days <= 365) // Monthly labels
                            return new DateTime(o.OrderDate.Year, o.OrderDate.Month, 1); // Group by month
                        else // Yearly labels
                            return new DateTime(o.OrderDate.Year, 1, 1); // Group by year
                    })
                    .Select(g => new { Date = g.Key, Revenue = g.Sum(o => o.TotalAmount) })
                    .OrderBy(x => x.Date)
                    .ToList();

                // Calculate gross profit data
                var grossProfitData = orders
                    .GroupBy(o =>
                    {
                        if (timeSpan.Days <= 1) // Hourly labels
                            return new DateTime(o.OrderDate.Year, o.OrderDate.Month, o.OrderDate.Day, o.OrderDate.Hour, 0, 0); // Group by hour
                        else if (timeSpan.Days <= 15) // Daily labels
                            return o.OrderDate.Date; // Group by exact date
                        else if (timeSpan.Days <= 31) // Weekly labels (same month)
                            return o.OrderDate.Date.AddDays(-(o.OrderDate.Day - 1) % 7); // Group by week starting from the first day of the month
                        else if (timeSpan.Days <= 365) // Monthly labels
                            return new DateTime(o.OrderDate.Year, o.OrderDate.Month, 1); // Group by month
                        else // Yearly labels
                            return new DateTime(o.OrderDate.Year, 1, 1); // Group by year
                    })
                    .Select(g => new { Date = g.Key, GrossProfit = g.Sum(o => o.GrossProfit) })
                    .OrderBy(x => x.Date)
                    .ToList();



                cartesianChartGrossRevenue.AxisX.Add(new Axis
                {
                    Title = "Date",
                    Labels = xAxisLabels,
                    FontSize = 11,
                    FontFamily = new System.Windows.Media.FontFamily("Segoe UI"),
                    Foreground = System.Windows.Media.Brushes.DimGray,
                    Separator = new Separator { Step = 1 },
                    LabelsRotation = 45, // Rotate labels if needed for better visibility

                    // Ensure separators are shown between each label

                });


                // Create line series with Mapper
                // Create line series with improved design
                var grossRevenueSeries = new ColumnSeries // Changed to ColumnSeries for bar chart
                {
                    Title = "Gross Revenue",
                    Values = new ChartValues<decimal>(revenueByLabel.Values.ToList()),
                    // ... (other properties) ...
                    StrokeThickness = 1,

                    Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 118, 207)), // RGB(0, 118, 207)
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 118, 207))  // Same color for stroke                StrokeThickness = 1,
                };

                var grossProfitSeries = new ColumnSeries // Changed to ColumnSeries for bar chart
                {
                    Title = "Gross Profit",
                    Values = new ChartValues<decimal>(grossProfitByLabel.Values.ToList()),
                    StrokeThickness = 1,
                    Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(184, 35, 32)), // RGB(184, 35, 32)
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(184, 35, 32))
                };

                // Add both series to the chart
                var series = new SeriesCollection
    {
        grossRevenueSeries,
        grossProfitSeries
    };
                // Set chart labels and series with improved design


                cartesianChartGrossRevenue.AxisY.Add(new Axis
                {
                    Title = "Amount",
                    LabelFormatter = value => value.ToString("C"),
                    FontSize = 12,
                    FontFamily = new System.Windows.Media.FontFamily("Segoe UI"),
                    Foreground = System.Windows.Media.Brushes.DimGray,
                    MinValue = 0
                });

                cartesianChartGrossRevenue.Series = series;
                // Configure the legend
                cartesianChartGrossRevenue.LegendLocation = LegendLocation.Bottom;
                cartesianChartGrossRevenue.Hoverable = false;
            }



            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while initializing the gross revenue chart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private string GetLabelForDate(DateTime date, TimeSpan timeSpan, DateTime startDate, DateTime endDate)
        {
            if (timeSpan.Days <= 1)
            {
                return date.ToString("H:00");
            }
            else if (timeSpan.Days <= 15)
            {
                return date.ToString("MMM dd");
            }
            else if (timeSpan.Days <= 31)
            {
                // Weekly labels (same month)


                DateTime currentWeekStart = startDate;
                DateTime nextWeekStart = currentWeekStart.AddDays(7);

                while (currentWeekStart <= endDate)
                {
                    DateTime weekEnd = nextWeekStart <= endDate ? nextWeekStart.AddDays(-1) : endDate;

                    // Check if the date falls within the current week
                    if (date.Date >= currentWeekStart && date.Date <= weekEnd)
                    {
                        return $"{CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(currentWeekStart.Month)} {currentWeekStart.Day} - {weekEnd.Day}";
                    }

                    currentWeekStart = nextWeekStart;
                    nextWeekStart = currentWeekStart.AddDays(7);
                }

                // If no matching week is found, return an empty string or handle the error appropriately
                return "";
            }
            else if (timeSpan.Days <= 365)
            {
                return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(date.Month);
            }
            else
            {
                return date.Year.ToString();
            }
        }
        private List<string> GenerateXAxisLabels(DateTime startDate, DateTime endDate)
        {
            var labels = new List<string>();

            // Calculate the time span between start and end dates
            TimeSpan timeSpan = endDate - startDate;

            if (timeSpan.Days <= 1)
            {
                // Very short range, show hourly labels
                for (DateTime date = startDate; date <= endDate; date = date.AddHours(1))
                {
                    labels.Add(date.ToString("H:00"));
                }
            }
            else if (timeSpan.Days <= 15)
            {
                // Short range, show daily labels
                for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                {
                    labels.Add(date.ToString("MMM dd"));
                }
            }
            else if (timeSpan.Days <= 31)
            {
                DateTime currentWeekStart = startDate;
                DateTime nextWeekStart = currentWeekStart.AddDays(7);

                while (currentWeekStart <= endDate)
                {
                    DateTime weekEnd = nextWeekStart <= endDate ? nextWeekStart.AddDays(-1) : endDate;

                    labels.Add($"{CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(currentWeekStart.Month)} {currentWeekStart.Day} - {weekEnd.Day}");

                    currentWeekStart = nextWeekStart;
                    nextWeekStart = currentWeekStart.AddDays(7);
                }
            }
            // Weekly labels (same month)



            else if (timeSpan.Days <= 365)
            {
                // Same year, show monthly labels
                DateTime currentDate = new DateTime(startDate.Year, startDate.Month, 1);
                while (currentDate <= endDate)
                {
                    labels.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(currentDate.Month));
                    currentDate = currentDate.AddMonths(1);
                }
            }
            else
            {
                // Different years, show yearly labels
                for (int year = startDate.Year; year <= endDate.Year; year++)
                {
                    labels.Add(year.ToString());
                }
            }

            return labels;
        }

        public void LoadDashboard()
        {
            // Bind the data to the DataGridView
            DataGridViewHelper.LoadData(
                dataRetrievalFunc: () => salesService.GetNewOrders(),
                dataGridView: dataGridViewNewOrders,
                bindingSource: bsNewOrders,
                bindingNavigator: bnNewOrders,
                errorMessage: "Failed to load new orders."
            );
            DataGridViewHelper.LoadData(
                dataRetrievalFunc: () => ingredientRepository.GetLowStockIngredients(),
                dataGridView: dgvUnderstock,
                bindingSource: bsLowStock,
                bindingNavigator: bnLowStocks,
                errorMessage: "Failed to load low stocks."
            );

            // Hide the ImagePath column
            DataGridViewHelper.HideColumn(dataGridViewNewOrders, "OrderId");
            DataGridViewHelper.HideColumn(dataGridViewNewOrders, "GrossProfit");
            DataGridViewHelper.HideColumn(dataGridViewNewOrders, "OrderStatus");

            // Autosize the OrderDate column
            dataGridViewNewOrders.Columns["OrderDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        // Assuming you have labels named lblNumOrdersPercentChange, lblTotalRevenuePercentChange, and lblTotalProfitPercentChange




        private void InitializeDashboardMetrics(DateTime startDate, DateTime endDate)
        {
            // Calculate metrics for the current period
            var currentOrders = context.OrderModels
    .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
    .OrderBy(o => o.OrderDate) // Order by OrderDate
    .ToList();
            int numOrders = currentOrders.Count;
            decimal totalRevenue = currentOrders.Sum(o => o.TotalAmount);
            decimal totalProfit = currentOrders.Sum(o => o.GrossProfit ?? 0); // Handle null GrossProfit

            // Calculate metrics for the previous period
            DateTime prevStartDate = startDate.AddDays(-(endDate - startDate).TotalDays); // Shift the date range back
            DateTime prevEndDate = endDate.AddDays(-(endDate - startDate).TotalDays);
            var previousOrders = context.OrderModels
                .Where(o => o.OrderDate >= prevStartDate && o.OrderDate <= prevEndDate)
                    .OrderBy(o => o.OrderDate) // Order by OrderDate

                .ToList();
            int prevNumOrders = previousOrders.Count;
            decimal prevTotalRevenue = previousOrders.Sum(o => o.TotalAmount);
            decimal prevTotalProfit = previousOrders.Sum(o => o.GrossProfit ?? 0);

            // Calculate percentage changes
            // Calculate percentage changes
            // Calculate percentage changes
            // Calculate percentage changes
            double numOrdersPercentChange = ((double)numOrders - (double)prevNumOrders) / (double)prevNumOrders * 100;
            double totalRevenuePercentChange = ((double)totalRevenue - (double)prevTotalRevenue) / (double)prevTotalRevenue * 100;
            double totalProfitPercentChange = ((double)totalProfit - (double)prevTotalProfit) / (double)prevTotalProfit * 100;

            lblNumOrders.Text = numOrders.ToString();

            // Check if the percentage change is negative
            if (numOrdersPercentChange < 0)
            {
                lblNumOrdersPercentChange.Text = $"{numOrdersPercentChange:0.##}%"; // Format with a minus sign if negative
            }
            else
            {
                lblNumOrdersPercentChange.Text = $"+{numOrdersPercentChange:0.##}%"; // Format with a plus sign if positive or zero
            }

            lblTotalRevenue.Text = totalRevenue.ToString("C");

            if (totalRevenuePercentChange < 0)
            {
                lblTotalRevenuePercentChange.Text = $"{totalRevenuePercentChange:0.##}%";
            }
            else
            {
                lblTotalRevenuePercentChange.Text = $"+{totalRevenuePercentChange:0.##}%";
            }

            lblTotalProfit.Text = totalProfit.ToString("C");

            if (totalProfitPercentChange < 0)
            {
                lblTotalProfitPercentChange.Text = $"{totalProfitPercentChange:0.##}%";
            }
            else
            {
                lblTotalProfitPercentChange.Text = $"+{totalProfitPercentChange:0.##}%";
            }
        }
        private void InitializePieChartTop5ProductVariant(DateTime startDate, DateTime endDate)
        {
            // Fetch data from OrderItem, ProductVariants, and Product tables, filtering by date
            var top5ProductVariants = context.OrderItems
                .Where(oi => oi.CreatedDate >= startDate && oi.CreatedDate <= endDate)
                .Join(context.ProductVariants, oi => oi.ProductVariantId, pv => pv.ProductVariantID, (oi, pv) => new { oi, pv })
                .GroupBy(x => x.pv.VariantName)
                .Select(g => new
                {
                    VariantName = g.Key,
                    TotalSold = g.Sum(x => x.oi.Quantity)
                })
                .OrderByDescending(x => x.TotalSold) // Order by TotalSold in descending order
                .Take(5) // Take the top 5 product variants
                .ToList();

            // Create a list of colors
            List<System.Windows.Media.Brush> colors = new List<System.Windows.Media.Brush>()
{
    new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(184, 35, 32)),
    new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(145, 89, 254)),
    new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 118, 207)),
    new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 64, 78)),
    new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(40, 42, 44)),
    // Add more colors as needed
};

            // Create a pie series for the chart
            pieChartTop5ProductVariant.Series = new SeriesCollection(); // Clear existing series

            for (int i = 0; i < top5ProductVariants.Count; i++)
            {
                pieChartTop5ProductVariant.Series.Add(new PieSeries
                {
                    Title = top5ProductVariants[i].VariantName,
                    Values = new ChartValues<int> { top5ProductVariants[i].TotalSold },
                    DataLabels = true,
                    LabelPoint = point => $"{point.Y} ({point.Participation:P})", // Show value and percentage
                    Fill = colors[i % colors.Count]
                });
            }

            // Set chart title dynamically based on date range
            string chartTitle;
            if (startDate.Date == endDate.Date)
            {
                chartTitle = $"Top 5 Product Variants on {startDate.ToShortDateString()}";
            }
            else if (startDate.Year == endDate.Year && startDate.Month == endDate.Month)
            {
                chartTitle = $"Top 5 Product Variants in {startDate.ToString("MMMM yyyy")}";
            }
            else if (startDate.Year == endDate.Year)
            {
                chartTitle = $"Top 5 Product Variants from {startDate.ToString("MMMM")} to {endDate.ToString("MMMM yyyy")}";
            }
            else
            {
                chartTitle = $"Top 5 Product Variants from {startDate.ToShortDateString()} to {endDate.ToShortDateString()}";
            }

            pieChartTop5ProductVariant.LegendLocation = LegendLocation.Bottom;
        }
        private void panel7_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
        }
        private void DashboardForm_Load(object sender, System.EventArgs e)
        {
        }
        private void panel8_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
        }
        private void materialLabel1_Click(object sender, System.EventArgs e)
        {
        }
        private void panel9_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
        }
        private void panel10_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
        }
        private void materialButton1_Click(object sender, System.EventArgs e)
        {
        }
        private void panel7_Paint_1(object sender, System.Windows.Forms.PaintEventArgs e)
        {
        }

        private void cartesianChartGrossRevenue_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void labelTop1Product_Click(object sender, System.EventArgs e)
        {

        }

        private void labelTop1TotalStock_Click(object sender, System.EventArgs e)
        {

        }

        private void labelTop2Product_Click(object sender, System.EventArgs e)
        {

        }

        private void labelTop2TotalStock_Click(object sender, System.EventArgs e)
        {

        }

        private void labelTop3Product_Click(object sender, System.EventArgs e)
        {

        }

        private void lblTotalRevenuePercentChange_Click(object sender, System.EventArgs e)
        {
            TakoTeaForm teaForm = new TakoTeaForm();
            teaForm.Show();
        }

        private void lblTotalProfitPercentChange_Click(object sender, System.EventArgs e)
        {
            LoadDashboard();
            MenuOrderForm menuOrderForm = new MenuOrderForm();
            menuOrderForm.ShowDialog();
        }

        private void lblNumOrdersPercentChange_Click(object sender, System.EventArgs e)
        {

        }

        private void materialCard1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTotalRevenue_Click(object sender, EventArgs e)
        {

        }

        private void InitializeTopProductLabels()
        {
            // Fetch the top 3 products by total stock
            var top3ProductVariantsWithStock = context.OrderItems
                .GroupBy(oi => oi.ProductVariantId)
                .Select(g => new
                {
                    ProductVariantId = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(x => x.Count)
                .Take(3)
                .Join(context.ProductVariants, x => x.ProductVariantId, pv => pv.ProductVariantID, (x, pv) => new { x.ProductVariantId, x.Count, pv.StockLevel, pv.VariantName })
                .ToList();

            if (top3ProductVariantsWithStock.Count >= 1)
            {
                labelTop1Product.Text = top3ProductVariantsWithStock[0].VariantName;
                labelTop1TotalStock.Text = top3ProductVariantsWithStock[0].StockLevel.ToString();
            }
            else
            {
                labelTop1Product.Visible = false;
                labelTop1TotalStock.Visible = false;
            }

            if (top3ProductVariantsWithStock.Count >= 2)
            {
                labelTop2Product.Text = top3ProductVariantsWithStock[1].VariantName;
                labelTop2TotalStock.Text = top3ProductVariantsWithStock[1].StockLevel.ToString();
            }
            else
            {
                labelTop2Product.Visible = false;
                labelTop2TotalStock.Visible = false;
            }
            if (top3ProductVariantsWithStock.Count == 3)
            {
                labelTop3Product.Text = top3ProductVariantsWithStock[2].VariantName;
                labelTop3TotalStock.Text = top3ProductVariantsWithStock[2].StockLevel.ToString();
            }
            else
            {
                labelTop3Product.Visible = false;
                labelTop3TotalStock.Visible = false;
            }
        }

        private void btnCustomDate_Click(object sender, EventArgs e)
        {
            if (btnCustomDate.Text == "Custom")
            {
                // Show draft orders
                btnCustomDate.Text = "Disable";
                dtpEndDate.Enabled = true;
                dtpStartDate.Enabled = true;
                btnOkCustomDate.Enabled = true;
            }
            else
            {
                // Close draft orders view
                btnCustomDate.Text = "Custom";
                dtpEndDate.Enabled = false;
                dtpStartDate.Enabled = false;
                btnOkCustomDate.Enabled = false;
            }
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
        DateHelper.ValidateDateRange(dtpStartDate, dtpEndDate, "Start date must be before end date.", -1);
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            DateHelper.ValidateDateRange(dtpStartDate, dtpEndDate, "End date must be after start date.", 1);

        }

        private void btnOkCustomDate_Click(object sender, EventArgs e)
        {
            span = dtpEndDate.Value - dtpStartDate.Value;
            
            if (span.Days <= 1)
            {
                InitializeGrossRevenueChart(dtpStartDate.Value, dtpEndDate.Value);
                InitializeSalesPerProductChart(dtpStartDate.Value, dtpEndDate.Value);
                InitializePieChartTop5ProductVariant(dtpStartDate.Value, dtpEndDate.Value);

                InitializeDashboardMetrics(dtpStartDate.Value, dtpEndDate.Value);

            }
            else
            {

                InitializeGrossRevenueChart(dtpStartDate.Value.Date, dtpEndDate.Value.Date);
                InitializeSalesPerProductChart(dtpStartDate.Value.Date, dtpEndDate.Value.Date);
                InitializePieChartTop5ProductVariant(dtpStartDate.Value.Date, dtpEndDate.Value.Date);
                InitializeDashboardMetrics(dtpStartDate.Value.Date, dtpEndDate.Value.Date);
            }

        }

        private void cartesianChartGrossRevenue_ChildChanged_1(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {
        }

        private void cartesianChartGrossRevenue_ChildChanged_2(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
        private List<string> GetAllProductNames()
        {
            return context.Products.Select(p => p.ProductName).ToList();
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            InitializeGrossRevenueChart(today, today);
            InitializeSalesPerProductChart(today, today);
            InitializeDashboardMetrics(today, today);
            InitializePieChartTop5ProductVariant(today, today);

        }

        private void btnLast7Days_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today.Date;
            DateTime sevenDaysAgo = today.AddDays(-7).Date;
            InitializeGrossRevenueChart(sevenDaysAgo, today);
            InitializeSalesPerProductChart(sevenDaysAgo, today);
            InitializePieChartTop5ProductVariant(sevenDaysAgo, today);
            InitializeDashboardMetrics(sevenDaysAgo, today);
        }

        private void btnLast30Days_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today.Date;
            DateTime thirtyDaysAgo = today.AddDays(-30).Date;
            InitializeGrossRevenueChart(thirtyDaysAgo, today);
            InitializeSalesPerProductChart(thirtyDaysAgo, today);
            InitializePieChartTop5ProductVariant(thirtyDaysAgo, today);
            InitializeDashboardMetrics(thirtyDaysAgo, today);
        }

        private void btnThisMonth_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today.Date;
            DateTime startOfMonth = new DateTime(today.Year, today.Month, 1).Date;
            DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);



            InitializeGrossRevenueChart(startOfMonth, endOfMonth);
            InitializeSalesPerProductChart(startOfMonth, endOfMonth);
            InitializePieChartTop5ProductVariant(startOfMonth, endOfMonth);
            InitializeDashboardMetrics(startOfMonth, endOfMonth);
        }

        private void lblNumOrders_Click(object sender, EventArgs e)
        {

        }

        private void lblNumOrders_Click_1(object sender, EventArgs e)
        {

        }
    }
}
