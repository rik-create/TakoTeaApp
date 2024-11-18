using LiveCharts;
using LiveCharts.Wpf;
using MaterialSkin.Controls;
using TakoTea.Configurations;
namespace TakoTea.Views.Dashboard
{
    public partial class DashboardForm : MaterialForm
    {
        public DashboardForm()
        {
            InitializeComponent();
            FormSettingsConfigurator.ApplyStandardFormSettings(this);
            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);
            InitializeChart();
            InitializePieChart();
        }
        private void InitializeChart()
        {
            cartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "2023",
                    Values = new ChartValues<double> { 10000, 50000, 39000, 50000 } // Gross revenue values for 2023
                },
                new ColumnSeries
                {
                    Title = "2024",
                    Values = new ChartValues<double> { 11000, 56000, 42000 } // Initial gross revenue values for 2024
                }
            };
            ; ; ;
            _ = cartesianChart1.Series[1].Values.Add(48000d); // Add another month's revenue for 2024
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Month",
                Labels = new[] { "Jan", "Feb", "Mar", "Apr" },
                FontSize = 13
            }); ;
            cartesianChart1.AxisY.Add(new Axis
            {
                LabelFormatter = value => value.ToString("C0"), // Formats as currency, e.g., "$10,000"
                FontSize = 13
            });
        }
        private void InitializePieChart()
        {
            pieChart1.Series = new SeriesCollection
    {
        new PieSeries
        {
            Title = "Takoyaki Classic",
            Values = new ChartValues<double> { 120 }, // Example sales value
            DataLabels = true
        },
        new PieSeries
        {
            Title = "Takoyaki Spicy",
            Values = new ChartValues<double> { 90 },
            DataLabels = true
        },
        new PieSeries
        {
            Title = "Milk Tea Original",
            Values = new ChartValues<double> { 150 },
            DataLabels = true
        },
        new PieSeries
        {
            Title = "Milk Tea Taro",
            Values = new ChartValues<double> { 130 },
            DataLabels = true
        },
        new PieSeries
        {
            Title = "Milk Tea Matcha",
            Values = new ChartValues<double> { 110 },
            DataLabels = true
        }
    };
            // Additional settings for the pie chart (optional)
            pieChart1.LegendLocation = LegendLocation.Bottom; // Display legend on the right
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
    }
}
