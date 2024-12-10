using LiveCharts;
using LiveCharts.Wpf;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using TakoTea.Configurations;
using TakoTea.Helpers;
using TakoTea.Models;
using TakoTea.Repository;
using TakoTea.Services;
using TakoTea.View.Product.Product_Modals;

namespace TakoTea.Views.product

{
    public partial class ProductDetailsForm : MaterialForm
    {
        private readonly int _productId;
        private readonly ProductsService _productsService;
        private readonly SalesService _salesService;
        private readonly BindingSource _bindingSource;
        private DataGridView dataGridViewProductVariants;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private LiveCharts.WinForms.CartesianChart cartesianChartGrossRevenue;
        private LiveCharts.WinForms.CartesianChart cartesianChartSalesPerProduct;
        private LiveCharts.WinForms.PieChart pieChartTop5ProductVariant;
        private Entities context;

        public ProductDetailsForm(int productId)
        {
            InitializeComponent();
            _productId = productId;
            context = new Entities();
            _productsService = new ProductsService(context);
            _salesService = new SalesService(context);
            _bindingSource = new BindingSource();

            ThemeConfigurator.ApplyDarkTheme(this);
            FormSettingsConfigurator.ApplyStandardFormSettings(this);

            InitializeComponents();
            LoadData();
            InitializeCharts();
            dataGridViewProductVariants.CellDoubleClick += dataGridViewProductVariants_CellDoubleClick;
            dataGridViewProductVariants.ColumnHeaderMouseClick += dataGridViewProductVariants_ColumnHeaderMouseClick;
        }
        private void dataGridViewProductVariants_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewHelper.SortDataGridView(dataGridViewProductVariants, e.ColumnIndex);
        }
        private void dataGridViewProductVariants_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if a valid row was double-clicked
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && !dataGridViewProductVariants.Rows[e.RowIndex].IsNewRow)
            {
                try
                {
                    // Get the ProductVariantID from the selected row
                    int productVariantId = Convert.ToInt32(dataGridViewProductVariants.Rows[e.RowIndex].Cells["ProductVariantID"].Value);

                    // Create and show the EditProductVariantModal
                    EditProductVariantModal editProductVariantModal = new EditProductVariantModal(productVariantId);
                    if (editProductVariantModal.ShowDialog() == DialogResult.OK)
                    {
                        LoadData(); // Refresh data in the DataGridView after editing
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening the edit modal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void InitializeComponents()
        {

            string title = GetProductNameById(_productId);
            // Set form properties
            this.Text = title;
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterParent;

            // Create DataGridView for product variants
            dataGridViewProductVariants = new DataGridView
            {
                Location = new Point(20, 80),
                Size = new Size(740, 200),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                ReadOnly = true
            };

            // Create TabControl for charts
            tabControl1 = new TabControl
            {
                Location = new Point(20, 300),
                Size = new Size(740, 250)
            };

            // Create TabPages for the TabControl
            tabPage1 = new TabPage { Text = "Gross Revenue" };
            tabPage2 = new TabPage { Text = "Sales Per Product" };
            tabControl1.TabPages.AddRange(new TabPage[] { tabPage1, tabPage2 });

            // Create CartesianCharts for the TabPages
            cartesianChartGrossRevenue = new LiveCharts.WinForms.CartesianChart
            {
                Dock = DockStyle.Fill
            };
            tabPage1.Controls.Add(cartesianChartGrossRevenue);

            cartesianChartSalesPerProduct = new LiveCharts.WinForms.CartesianChart
            {
                Dock = DockStyle.Fill
            };
            tabPage2.Controls.Add(cartesianChartSalesPerProduct);

            // Create PieChart for top 5 product variants
            pieChartTop5ProductVariant = new LiveCharts.WinForms.PieChart
            {
                Location = new Point(20, 300),
                Size = new Size(350, 250)
            };

            // Add controls to the form
            this.Controls.AddRange(new Control[] { dataGridViewProductVariants, tabControl1, pieChartTop5ProductVariant });
        }

        private void LoadData()
        {
            try
            {
                var productVariants = _productsService.GetProductVariantsByProductId(_productId)
                .Select(pv => new
                {
                    pv.ProductID,        // Include ProductID
                    pv.ProductVariantID, // Include ProductVariantID
                    pv.VariantName,
                    pv.Size,
                    pv.Price,
                    pv.StockLevel
                })
                .ToList();
                _bindingSource.DataSource = productVariants;
                dataGridViewProductVariants.DataSource = _bindingSource;



                DataGridViewHelper.ApplyDataGridViewStyles(dataGridViewProductVariants);
                DataGridViewHelper.HideColumn(dataGridViewProductVariants, "ProductVariantID");
                DataGridViewHelper.HideColumn(dataGridViewProductVariants, "ProductID");
                DataGridViewHelper.FormatColumnHeaders(dataGridViewProductVariants);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading product variants: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeCharts()
        {
            InitializeGrossRevenueChart();
            InitializeSalesPerProductChart();
            InitializePieChartTop5ProductVariant();
        }

        private void InitializeGrossRevenueChart()
        {
            // Fetch and filter data for the _productId
            var grossRevenueData = _salesService.GetGrossRevenuePerDay(_productId);

            // Create series for the chart
            cartesianChartGrossRevenue.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Gross Revenue",
                    Values = new ChartValues<decimal>(grossRevenueData.Select(x => x.Revenue).Where(x => x.HasValue).Select(x => x.Value).ToList()),
                }
            };

            // Set X-axis labels
            cartesianChartGrossRevenue.AxisX.Add(new Axis
            {
                Title = "Date",
                Labels = grossRevenueData.Select(x => x.Date.ToShortDateString()).ToList()
            });

            // Set Y-axis title
            cartesianChartGrossRevenue.AxisY.Add(new Axis
            {
                Title = "Revenue"
            });
        }

        private void InitializeSalesPerProductChart()
        {
            // Fetch and filter data for the _productId
            var salesPerProductData = _salesService.GetSalesPerProduct(_productId);

            // Create series for the chart
            cartesianChartSalesPerProduct.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Sales",
                    Values = new ChartValues<int>(salesPerProductData.Select(x => x.Sales).ToList()),
                }
            };

            // Set X-axis labels
            cartesianChartSalesPerProduct.AxisX.Add(new Axis
            {
                Title = "Product",
                Labels = salesPerProductData.Select(x => x.ProductName).ToList()
            });

            // Set Y-axis title
            cartesianChartSalesPerProduct.AxisY.Add(new Axis
            {
                Title = "Sales"
            });
        }

        private void InitializePieChartTop5ProductVariant()
        {
            // Fetch and filter data for the _productId
            var top5VariantsData = _salesService.GetTop5ProductVariantsBySales(_productId);

            // Create series for the chart
            pieChartTop5ProductVariant.Series = new SeriesCollection();
            foreach (var variant in top5VariantsData)
            {
                pieChartTop5ProductVariant.Series.Add(new PieSeries
                {
                    Title = variant.VariantName,
                    Values = new ChartValues<int> { variant.Sales },
                    DataLabels = true
                });
            }
        }
        private string GetProductNameById(int productId)
        {
            var product = _productsService.GetProductById(productId);
            return product?.ProductName ?? "Product not found";
        }
    }
}