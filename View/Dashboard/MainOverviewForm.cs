using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakoTea.Configurations;
using LiveCharts.WinForms;
using DevExpress.Data.Browsing;
using System.Windows.Media;
using System.Runtime.Serialization;
using Audit_Trail;
using TakoTea.MainForm;

namespace TakoTea.Dashboard
{
    public partial class MainOverviewForm : MaterialForm
    {

        public MainOverviewForm()
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);
            InitializeChart();




        }
        public MainOverviewForm(TakoTeaForm mainForm)
        {
            InitializeComponent();
            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);
            InitializeChart();




        }



        private void InitializeChart()
        {
            cartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "2023",
                    Values = new ChartValues<double> { 10, 50, 39, 50 }
                }
            };

            cartesianChart1.Series.Add(new ColumnSeries
            {
                Title = "2024",
                Values = new ChartValues<double> { 11, 56, 42 }
            });

            cartesianChart1.Series[1].Values.Add(48d);

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Month",
                Labels = new[] { "Jan", "Feb", "Mar", "Apr" }
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Sold",
                LabelFormatter = value => value.ToString("N")
            });


        }
        private void CartesianChart1OnDataClick(object sender, ChartPoint chartPoint)
        {
        }

        private void cartesianChart1_DataClick(object sender, ChartPoint chartPoint)
        {
            MessageBox.Show("You clicked (" + chartPoint.X + "," + chartPoint.Y + ")");

        }

        private void materialCardStocks_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialCard4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialCard1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialCard9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialCardStocks_Paint_1(object sender, PaintEventArgs e)
        {

        }


        private void materialCardStocks_Click_1(object sender, EventArgs e)
        {
            var stockTab = TakoTeaForm.Instance.materialTabControl1.TabPages["tabPageStock"];

            if (stockTab != null)
            {
                TakoTeaForm.Instance.materialTabControl1.SelectedTab = stockTab; // Switch to the specified tab
            }
            else
            {
                MessageBox.Show("The specified tab was not found.");
            }

            // Close the current form
            this.Close();
        }
    }
}
