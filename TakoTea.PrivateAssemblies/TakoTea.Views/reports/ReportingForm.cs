using Helpers;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakoTea.Helpers;
using TakoTea.Models;
using TakoTea.Repository;


namespace TakoTea.Views.reports
{
    public partial class ReportingForm : MaterialForm
    {
        // DbContext instance
        private readonly Entities dbContext = new Entities();
        public ReportingForm()
        {
            InitializeComponent();

            // Populate ListBox with ReportType enum values
            lstReportTypes.DataSource = Enum.GetValues(typeof(ReportType));

            // Populate ComboBoxes with relevant data
            // Add event handler for the ComboBox
            cboDateRange.Items.AddRange(new object[] { "Today", "Last 7 Days", "Last 30 Days", "This Month", "All Time" });

        }

        private void lstReportTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstReportTypes.SelectedItem != null)
            {
                ReportType selectedReportType = (ReportType)lstReportTypes.SelectedItem;
                List<string> dataSource = new List<string>();

                switch (selectedReportType)
                {
                    case ReportType.SalesSummary:
                        dataSource = dbContext.OrderModels.Select(o => o.PaymentMethod).Distinct().ToList();
                        lblFilterHint.Text = "Select Payment Method:";
                        lblSearchHint.Text = "Enter Customer Name or Order ID:";
                        chkLowStockOnly.Visible = false;
                        break;
                    case ReportType.InventoryReport:
                        dataSource = dbContext.Ingredients.Select(i => i.IngredientCategory).Distinct().ToList();
                        lblFilterHint.Text = "Select Ingredient Category:";
                        lblSearchHint.Text = "Enter Ingredient Name:";
                        chkLowStockOnly.Visible = true;
                        break;
                    case ReportType.OrderList:
                        dataSource = dbContext.OrderModels.Select(o => o.OrderStatus).Distinct().ToList();
                        lblFilterHint.Text = "Select Order Status:";
                        lblSearchHint.Text = "Enter Customer Name or Order ID:";
                        chkLowStockOnly.Visible = false;
                        break;
                    case ReportType.OrderWithItemsList:
                        dataSource = dbContext.Products.Select(p => p.ProductName).Distinct().ToList();
                        lblFilterHint.Text = "Select Product Name:";
                        lblSearchHint.Text = "Enter Product Name or CustomerName:";
                        chkLowStockOnly.Visible = false;
                        break;
                    case ReportType.ChangeLogs:
                        dataSource = LogChangesRepository.GetAllChangeLogs().Select(l => l.TableName).Distinct().ToList();
                        lblFilterHint.Text = "Select Table Name:";
                        lblSearchHint.Text = "Enter Column Name or User:";
                        chkLowStockOnly.Visible = false;
                        break;
                }

                dataSource.Insert(0, "All");
                cboFilter.DataSource = dataSource;
            }
            GenerateReport();
        }


        public void GenerateAndDisplayReport(string pdfPath, ReportType reportType, Dictionary<string, object> filters = null)
        {
            // Create a new PDF document (iTextSharp)
            iTextSharp.text.Document itextDoc = new iTextSharp.text.Document();
            try
            {
                // Create a MemoryStream to hold the PDF output
                using (MemoryStream stream = new MemoryStream())
                {
                    // Create a PdfWriter to write to the MemoryStream
                    _ = PdfWriter.GetInstance(itextDoc, stream);

                    // Open the document
                    itextDoc.Open();

                    // Add content to the PDF based on report type
                    switch (reportType)
                    {
                        case ReportType.SalesSummary:
                            AddSalesSummaryContent(itextDoc, filters);
                            break;
                        case ReportType.InventoryReport:
                            AddInventoryReportContent(itextDoc, filters);
                            break;
                        case ReportType.OrderList:
                            AddOrderListContent(itextDoc, filters);
                            break;
                        case ReportType.OrderWithItemsList:
                            AddOrderWithItemsListContent(itextDoc, filters);
                            break;
                        case ReportType.ChangeLogs:
                            AddChangeLogsContent(itextDoc, filters);
                            break;

                    }
                    itextDoc.Close();

                    byte[] pdfBytes = stream.ToArray();

                    PdfiumViewer.PdfDocument pdfDocument = PdfiumViewer.PdfDocument.Load(new MemoryStream(pdfBytes));

                    pdfViewer1.Document = pdfDocument;






                }

            }
            catch (Exception ex)
            {
                _ = MessageBox.Show($"An error occurred while generating the report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                itextDoc.Dispose();
            }
        }

        private void AddSalesSummaryContent(iTextSharp.text.Document document, Dictionary<string, object> filters)
        {
            IQueryable<OrderModel> salesQuery = dbContext.OrderModels.AsQueryable();

            // Apply filters
            if (filters != null)
            {
                if (filters.ContainsKey("StartDate") && filters["StartDate"] is DateTime startDate)
                {
                    salesQuery = salesQuery.Where(o => o.OrderDate >= startDate);
                }
                if (filters.ContainsKey("EndDate") && filters["EndDate"] is DateTime endDate)
                {
                    salesQuery = salesQuery.Where(o => o.OrderDate <= endDate);
                }
                if (filters.ContainsKey("PaymentMethod") && filters["PaymentMethod"] is string paymentMethod)
                {

                    if (paymentMethod == "All")
                    {

                    }
                    else
                    {
                        salesQuery = salesQuery.Where(o => o.PaymentMethod == paymentMethod);

                    }
                }
            }

            var salesSummary = salesQuery
                .Join(dbContext.OrderModels, s => s.OrderId, o => o.OrderId, (s, o) => new { Sale = s, Order = o })
                .ToList()
                .GroupBy(o => o.Sale.OrderDate.Date)
                .Select(g => new
                {
                    OrderDate = g.Key,
                    TotalAmount = g.Sum(o => o.Sale.TotalAmount),
                    GrossProfit = g.Sum(o => o.Sale.GrossProfit),
                    g.First().Order.PaymentMethod

                })
                .ToList();
            decimal totalGrossRevenue = salesSummary.Sum(s => s.TotalAmount);
            decimal totalGrossProfit = salesSummary.Sum(s => s.GrossProfit.Value);
            // Add sales summary data to the document with styling
            Paragraph titleParagraph = new Paragraph("TakoTea - Sales Summary")
            {
                Font = new Font(FontFactory.GetFont("Helvetica", 16, iTextSharp.text.Font.BOLD, BaseColor.BLUE)),
                Alignment = Element.ALIGN_CENTER
            };
            _ = document.Add(titleParagraph);

            // Add date and time
            Paragraph dateTimeParagraph = new Paragraph($"Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}") { Alignment = Element.ALIGN_CENTER };
            _ = document.Add(dateTimeParagraph);

            // Add "Printed By:"
            Paragraph printedByParagraph = new Paragraph($"Printed By: {AuthenticationHelper._loggedInUsername}\n") { Alignment = Element.ALIGN_CENTER };
            _ = document.Add(printedByParagraph);

            Paragraph totalRevenueParagraph = new Paragraph($"Total Gross Revenue: {totalGrossRevenue:C}", new Font(FontFactory.GetFont("Helvetica", 12, iTextSharp.text.Font.BOLD))) { Alignment = Element.ALIGN_RIGHT };
            _ = document.Add(totalRevenueParagraph);

            Paragraph totalProfitParagraph = new Paragraph($"Total Gross Profit: {totalGrossProfit:C}", new Font(FontFactory.GetFont("Helvetica", 12, iTextSharp.text.Font.BOLD))) { Alignment = Element.ALIGN_RIGHT };
            _ = document.Add(totalProfitParagraph);

            Paragraph totalOrdersParagraph = new Paragraph($"Total Orders: {salesSummary.Count}", new Font(FontFactory.GetFont("Helvetica", 12, iTextSharp.text.Font.BOLD))) { Alignment = Element.ALIGN_RIGHT };
            _ = document.Add(totalOrdersParagraph);
            // Add an empty paragraph for spacing
            _ = document.Add(new Paragraph(" "));
            // Add a table to organize the data
            PdfPTable table = new PdfPTable(4) { WidthPercentage = 100 };
            _ = table.AddCell(new PdfPCell(new Phrase("Order Date")) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });
            _ = table.AddCell(new PdfPCell(new Phrase("Payment Method")) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });

            _ = table.AddCell(new PdfPCell(new Phrase("Gross Revenue")) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });
            _ = table.AddCell(new PdfPCell(new Phrase("Gross Profit")) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });

            foreach (var item in salesSummary)
            {
                _ = table.AddCell(new PdfPCell(new Phrase(item.OrderDate.ToShortDateString())) { Padding = 5 });
                _ = table.AddCell(new PdfPCell(new Phrase(item.PaymentMethod.ToString())) { Padding = 5 });

                _ = table.AddCell(new PdfPCell(new Phrase("₱" + item.TotalAmount.ToString("C", new System.Globalization.CultureInfo("fil-PH")))) { Padding = 5 });
                _ = table.AddCell(new PdfPCell(new Phrase("₱" + item.GrossProfit.Value.ToString("C", new System.Globalization.CultureInfo("fil-PH")))) { Padding = 5 });
            }
            int pageCount = document.PageNumber;

            for (int i = 1; i <= pageCount; i++)
            {
                _ = document.NewPage();
                Paragraph pageNumberParagraph = new Paragraph($"Page {i} of {pageCount}", new Font(FontFactory.GetFont("Helvetica", 10))) { Alignment = Element.ALIGN_RIGHT };
                _ = document.Add(pageNumberParagraph);
            }

            _ = document.Add(table);
        }

        private void AddInventoryReportContent(iTextSharp.text.Document document, Dictionary<string, object> filters)
        {
            IQueryable<Ingredient> inventoryQuery = dbContext.Ingredients.AsQueryable();

            // Apply filters
            if (filters != null)
            {
                if (filters.ContainsKey("IngredientName") && filters["IngredientName"] is string ingredientName)
                {
                    inventoryQuery = inventoryQuery.Where(i => i.IngredientName.Contains(ingredientName));
                }
                if (filters.ContainsKey("LowStockOnly") && filters["LowStockOnly"] is bool lowStockOnly && lowStockOnly)
                {
                    inventoryQuery = inventoryQuery.Where(i => i.StockLevel <= i.LowLevel);
                }

                if (filters.ContainsKey("IngredientCategory") && filters["IngredientCategory"] is string ingredientCategory)
                {

                    if (ingredientCategory == "All")
                    {

                    }
                    else
                    {
                        inventoryQuery = inventoryQuery.Where(i => i.IngredientCategory == ingredientCategory);

                    }
                }
            }

            List<Ingredient> inventory = inventoryQuery.ToList();


            // Add inventory data to the document with styling
            // Add title with TakoTea and center alignment
            Paragraph titleParagraph = new Paragraph("TakoTea - Inventory Report")
            {
                Font = FontFactory.GetFont("Helvetica", 16, iTextSharp.text.Font.BOLD, BaseColor.GREEN),
                Alignment = Element.ALIGN_CENTER
            };
            _ = document.Add(titleParagraph);

            // Add date and time
            Paragraph dateTimeParagraph = new Paragraph($"Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}") { Alignment = Element.ALIGN_CENTER };
            _ = document.Add(dateTimeParagraph);

            // Add "Printed By:"
            Paragraph printedByParagraph = new Paragraph($"Printed By: {AuthenticationHelper._loggedInUsername}\n") { Alignment = Element.ALIGN_CENTER };
            _ = document.Add(printedByParagraph);
            // Add an empty paragraph for spacing
            // Add a paragraph for the total number of ingredients
            Paragraph totalIngredientsParagraph = new Paragraph($"Total Ingredients: {inventory.Count}", new Font(FontFactory.GetFont("Helvetica", 12, iTextSharp.text.Font.BOLD))) { Alignment = Element.ALIGN_RIGHT };
            _ = document.Add(totalIngredientsParagraph);
            _ = document.Add(new Paragraph(" "));
            // Add a table to organize the data
            PdfPTable table = new PdfPTable(3) { WidthPercentage = 100 };
            _ = table.AddCell(new PdfPCell(new Phrase("Ingredient Name")) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });
            _ = table.AddCell(new PdfPCell(new Phrase("Stock Level")) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });
            _ = table.AddCell(new PdfPCell(new Phrase("Measuring Unit")) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });

            foreach (Ingredient item in inventory)
            {
                _ = table.AddCell(new PdfPCell(new Phrase(item.IngredientName)) { Padding = 5 });
                _ = table.AddCell(new PdfPCell(new Phrase(item.StockLevel.ToString())) { Padding = 5 });
                _ = table.AddCell(new PdfPCell(new Phrase(item.MeasuringUnit)) { Padding = 5 });
            }

            _ = document.Add(table);
            int pageCount = document.PageNumber;

            for (int i = 1; i <= pageCount; i++)
            {
                _ = document.NewPage();
                Paragraph pageNumberParagraph = new Paragraph($"Page {i} of {pageCount}", new Font(FontFactory.GetFont("Helvetica", 10))) { Alignment = Element.ALIGN_RIGHT };
                _ = document.Add(pageNumberParagraph);
            }
        }


        private void AddOrderListContent(iTextSharp.text.Document document, Dictionary<string, object> filters)
        {
            IQueryable<OrderModel> ordersQuery = dbContext.OrderModels.AsQueryable();

            // Apply filters
            if (filters != null)
            {
                if (filters.ContainsKey("CustomerName") && filters["CustomerName"] is string customerName)
                {
                    ordersQuery = ordersQuery.Where(o => o.CustomerName.Contains(customerName));
                }
                if (filters.ContainsKey("OrderStatus") && filters["OrderStatus"] is string orderStatus)
                {

                    if (orderStatus == "All")
                    {

                    }
                    else
                    {
                        ordersQuery = ordersQuery.Where(o => o.OrderStatus == orderStatus);

                    }
                }
                if (filters.ContainsKey("PaymentStatus") && filters["PaymentStatus"] is string paymentStatus)
                {

                    ordersQuery = ordersQuery.Where(o => o.PaymentStatus == paymentStatus);
                }
            }

            List<OrderModel> orders = ordersQuery.ToList();

            decimal totalRevenue = ordersQuery.Sum(o => (decimal?)o.TotalAmount ?? 0);


            // Add inventory data to the document with styling
            // Add title with TakoTea and center alignment
            Paragraph titleParagraph = new Paragraph("TakoTea - Order List")
            {
                Font = FontFactory.GetFont("Helvetica", 16, iTextSharp.text.Font.BOLD, BaseColor.GREEN),
                Alignment = Element.ALIGN_CENTER
            };
            _ = document.Add(titleParagraph);

            // Add date and time
            Paragraph dateTimeParagraph = new Paragraph($"Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}") { Alignment = Element.ALIGN_CENTER };
            _ = document.Add(dateTimeParagraph);

            // Add "Printed By:"
            Paragraph printedByParagraph = new Paragraph($"Printed By: {AuthenticationHelper._loggedInUsername}\n") { Alignment = Element.ALIGN_CENTER };
            _ = document.Add(printedByParagraph);

            // Add a paragraph for the total revenue
            Paragraph totalRevenueParagraph = new Paragraph($"Total Revenue: {totalRevenue:C}", new Font(FontFactory.GetFont("Helvetica", 12, iTextSharp.text.Font.BOLD))) { Alignment = Element.ALIGN_RIGHT };
            _ = document.Add(totalRevenueParagraph);

            // Add a paragraph for the total number of orders
            Paragraph totalOrdersParagraph = new Paragraph($"Total Orders: {ordersQuery.Count()}", new Font(FontFactory.GetFont("Helvetica", 12, iTextSharp.text.Font.BOLD))) { Alignment = Element.ALIGN_RIGHT };
            _ = document.Add(totalOrdersParagraph);
            // Add an empty paragraph for spacing
            _ = document.Add(new Paragraph(" "));
            // Add a table to organize the data
            // Add a table to organize the data
            PdfPTable table = new PdfPTable(6) { WidthPercentage = 100 };
            _ = table.AddCell(new PdfPCell(new Phrase("Order ID")) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });
            _ = table.AddCell(new PdfPCell(new Phrase("Order Date")) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });
            _ = table.AddCell(new PdfPCell(new Phrase("Customer Name")) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });
            _ = table.AddCell(new PdfPCell(new Phrase("Payment Method")) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });
            _ = table.AddCell(new PdfPCell(new Phrase("Total Items")) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });
            _ = table.AddCell(new PdfPCell(new Phrase("Total Amount")) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });

            foreach (OrderModel order in orders)
            {
                _ = table.AddCell(new PdfPCell(new Phrase(order.OrderId.ToString())) { Padding = 5 });
                _ = table.AddCell(new PdfPCell(new Phrase(order.OrderDate.ToShortDateString())) { Padding = 5 });
                _ = table.AddCell(new PdfPCell(new Phrase(order.CustomerName)) { Padding = 5 });
                _ = table.AddCell(new PdfPCell(new Phrase(order.PaymentMethod)) { Padding = 5 });
                _ = table.AddCell(new PdfPCell(new Phrase(order.OrderItems.Count.ToString())) { Padding = 5 });
                _ = table.AddCell(new PdfPCell(new Phrase("₱" + order.TotalAmount.ToString("N"))) { Padding = 5 });
            }

            _ = document.Add(table);
            int pageCount = document.PageNumber;

            for (int i = 1; i <= pageCount; i++)
            {
                _ = document.NewPage();
                Paragraph pageNumberParagraph = new Paragraph($"Page {i} of {pageCount}", new Font(FontFactory.GetFont("Helvetica", 10))) { Alignment = Element.ALIGN_RIGHT };
                _ = document.Add(pageNumberParagraph);
            }
        }
        private int GetProductIdByName(string productName)
        {
            return dbContext.Products.FirstOrDefault(p => p.ProductName == productName)?.ProductID ?? 0;
        }

        private void AddChangeLogsContent(iTextSharp.text.Document document, Dictionary<string, object> filters)

        {

            IQueryable<Log> logsQuery = LogChangesRepository.GetAllChangeLogs().AsQueryable();



            if (filters != null)

            {

                if (filters.ContainsKey("TableName") && filters["TableName"] is string tableName)

                {

                    if (tableName != "All")

                    {

                        logsQuery = logsQuery.Where(l => l.TableName == tableName);

                    }

                }

                if (filters.ContainsKey("SearchText") && filters["SearchText"] is string searchText)

                {

                    logsQuery = logsQuery.Where(l =>

                        l.ColumnName.Contains(searchText) || l.Username.Contains(searchText));

                }

                if (filters.ContainsKey("StartDate") && filters["StartDate"] is DateTime startDate)

                {

                    logsQuery = logsQuery.Where(l => l.Timestamp >= startDate);

                }

                if (filters.ContainsKey("EndDate") && filters["EndDate"] is DateTime endDate)

                {

                    logsQuery = logsQuery.Where(l => l.Timestamp <= endDate);

                }

            }



            List<Log> logs = logsQuery.ToList();



            // Add logs data to the document with styling

            Font titleFont = FontFactory.GetFont("Helvetica", 16, iTextSharp.text.Font.BOLD, BaseColor.RED);

            Font headerFont = FontFactory.GetFont("Helvetica", 12, iTextSharp.text.Font.BOLD);

            Font cellFont = FontFactory.GetFont("Helvetica", 10);



            _ = document.Add(new Paragraph("TakoTea - Change Logs Report", titleFont) { Alignment = Element.ALIGN_CENTER });

            _ = document.Add(new Paragraph($"Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}") { Alignment = Element.ALIGN_CENTER });

            _ = document.Add(new Paragraph($"Printed By: {AuthenticationHelper._loggedInUsername} \n") { Alignment = Element.ALIGN_CENTER });
            Paragraph totalLogsParagraph = new Paragraph($"Total Change Logs: {logsQuery.Count()}", new Font(FontFactory.GetFont("Helvetica", 12, iTextSharp.text.Font.BOLD))) { Alignment = Element.ALIGN_RIGHT };
            _ = document.Add(totalLogsParagraph);
            _ = document.Add(new Paragraph(" "));



            // Create a table to display the logs

            PdfPTable table = new PdfPTable(7) { WidthPercentage = 100 }; // 7 columns now

            _ = table.AddCell(new PdfPCell(new Phrase("Timestamp", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });

            _ = table.AddCell(new PdfPCell(new Phrase("Table Name", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });
            _ = table.AddCell(new PdfPCell(new Phrase("Record ID", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });


            _ = table.AddCell(new PdfPCell(new Phrase("Column Name", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });

            _ = table.AddCell(new PdfPCell(new Phrase("Old Value", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });

            _ = table.AddCell(new PdfPCell(new Phrase("New Value", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });

            _ = table.AddCell(new PdfPCell(new Phrase("User", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });



            foreach (Log log in logs)

            {

                _ = table.AddCell(new PdfPCell(new Phrase(log.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"), cellFont)) { Padding = 5 });

                _ = table.AddCell(new PdfPCell(new Phrase(log.TableName, cellFont)) { Padding = 5 });
                _ = table.AddCell(new PdfPCell(new Phrase(log.RecordID.ToString(), cellFont)) { Padding = 5 }); // Add RecordID cell

                _ = table.AddCell(new PdfPCell(new Phrase(log.ColumnName, cellFont)) { Padding = 5 });

                _ = table.AddCell(new PdfPCell(new Phrase(log.OldValue, cellFont)) { Padding = 5 });

                _ = table.AddCell(new PdfPCell(new Phrase(log.NewValue, cellFont)) { Padding = 5 });

                _ = table.AddCell(new PdfPCell(new Phrase(log.Username, cellFont)) { Padding = 5 });

            }



            _ = document.Add(table);



            // Add page numbers

            int pageCount = document.PageNumber;

            for (int i = 1; i <= pageCount; i++)

            {

                _ = document.NewPage();

                Paragraph pageNumberParagraph = new Paragraph($"Page {i} of {pageCount}", new Font(FontFactory.GetFont("Helvetica", 10))) { Alignment = Element.ALIGN_RIGHT };

                _ = document.Add(pageNumberParagraph);

            }

        }
        private void AddOrderWithItemsListContent(iTextSharp.text.Document document, Dictionary<string, object> filters)
        {
            IQueryable<OrderModel> ordersQuery = dbContext.OrderModels.Include("OrderItems").AsQueryable();
            // Apply filters
            if (filters != null)
            {
                if (filters.ContainsKey("ProductName") && filters["ProductName"] is string productName)
                {
                    ordersQuery = ordersQuery.Where(o => o.OrderItems.Any(i => i.ProductName.Contains(productName)));
                }
                if (filters.ContainsKey("Customer") && filters["Customer"] is string customerName)
                {
                    ordersQuery = ordersQuery.Where(o => o.CustomerName.Contains(customerName));
                }
                if (filters.ContainsKey("ProductCategory") && filters["ProductCategory"] is string productCategory)
                {
                    if (productCategory == "All")
                    {
                        // No filter applied
                    }
                    else
                    {
                        ordersQuery = ordersQuery.Where(o => o.OrderItems.Any(i =>
                            dbContext.ProductVariants.Any(pv =>
                                pv.ProductVariantID == i.ProductVariantId &&
                                pv.ProductID == (dbContext.Products.FirstOrDefault(p => p.ProductName == productCategory) != null ? dbContext.Products.FirstOrDefault(p => p.ProductName == productCategory).ProductID : 0)
                            )
                        ));
                    }
                }
                if (filters.ContainsKey("OrderStartDate") && filters["OrderStartDate"] is DateTime orderStartDate)
                {
                    ordersQuery = ordersQuery.Where(o => o.OrderDate >= orderStartDate);
                }
                if (filters.ContainsKey("OrderEndDate") && filters["OrderEndDate"] is DateTime orderEndDate)
                {
                    ordersQuery = ordersQuery.Where(o => o.OrderDate <= orderEndDate);
                }
            }

            List<OrderModel> orders = ordersQuery.ToList();
            // Add order with items list data to the document with styling
            decimal? totalRevenue = ordersQuery.Sum(o => (decimal?)o.TotalAmount) ?? 0;
            decimal? totalProfit = ordersQuery.Sum(o => o.GrossProfit) ?? 0;

            Paragraph titleParagraph = new Paragraph("TakoTea - Order with Items List")
            {
                Font = FontFactory.GetFont("Helvetica", 16, iTextSharp.text.Font.BOLD, BaseColor.GREEN),
                Alignment = Element.ALIGN_CENTER
            };
            _ = document.Add(titleParagraph);

            // Add date and time
            Paragraph dateTimeParagraph = new Paragraph($"Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}") { Alignment = Element.ALIGN_CENTER };
            _ = document.Add(dateTimeParagraph);

            // Add "Printed By:"
            Paragraph printedByParagraph = new Paragraph($"Printed By: {AuthenticationHelper._loggedInUsername}\n") { Alignment = Element.ALIGN_CENTER };
            _ = document.Add(printedByParagraph);
            // Add an empty paragraph for spacing
            // Add a paragraph for the total revenue
            Paragraph totalRevenueParagraph = new Paragraph($"Total Revenue: {totalRevenue:C}", new Font(FontFactory.GetFont("Helvetica", 12, iTextSharp.text.Font.BOLD))) { Alignment = Element.ALIGN_RIGHT };
            _ = document.Add(totalRevenueParagraph);
            Paragraph totalProfitParagraph = new Paragraph($"Total Profit: {totalProfit:C}", new Font(FontFactory.GetFont("Helvetica", 12, iTextSharp.text.Font.BOLD))) { Alignment = Element.ALIGN_RIGHT };
            _ = document.Add(totalProfitParagraph);

            // Add a paragraph for the total number of orders
            Paragraph totalOrdersParagraph = new Paragraph($"Total Orders: {ordersQuery.Count()}", new Font(FontFactory.GetFont("Helvetica", 12, iTextSharp.text.Font.BOLD))) { Alignment = Element.ALIGN_RIGHT };
            _ = document.Add(totalOrdersParagraph);
            _ = document.Add(new Paragraph(" "));

            foreach (OrderModel order in orders)
            {
                // Add order details with styling
                _ = document.Add(new Paragraph($"Order ID: {order.OrderId}") { Font = new Font(FontFactory.GetFont("Helvetica", 15, iTextSharp.text.Font.BOLD)) });
                _ = document.Add(new Paragraph($"Order Date: {order.OrderDate}") { Font = new Font(FontFactory.GetFont("Helvetica", 12)) });
                _ = document.Add(new Paragraph($"Customer Name: {order.CustomerName}") { Font = new Font(FontFactory.GetFont("Helvetica", 12)) });
                _ = document.Add(new Paragraph($"Payment Method: {order.PaymentMethod}") { Font = new Font(FontFactory.GetFont("Helvetica", 12)) });
                _ = document.Add(new Paragraph($"Total Items: {order.OrderItems.Count}") { Font = new Font(FontFactory.GetFont("Helvetica", 12)) });
                _ = document.Add(new Paragraph(" "));

                // Add a nested table for order items
                PdfPTable itemTable = new PdfPTable(3) { WidthPercentage = 100 }; // 3 columns for Product Name, Quantity, and Price
                _ = itemTable.AddCell(new PdfPCell(new Phrase("Product Name")) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });
                _ = itemTable.AddCell(new PdfPCell(new Phrase("Quantity")) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });
                _ = itemTable.AddCell(new PdfPCell(new Phrase("Total")) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });

                foreach (OrderItem item in order.OrderItems)
                {
                    _ = itemTable.AddCell(new PdfPCell(new Phrase(item.ProductName)) { Padding = 5 });
                    _ = itemTable.AddCell(new PdfPCell(new Phrase(item.Quantity.ToString())) { Padding = 5 });
                    _ = itemTable.AddCell(new PdfPCell(new Phrase((item.Quantity * item.Price).ToString("C", new System.Globalization.CultureInfo("fil-PH")))) { Padding = 5 }); // Add Price column
                }

                _ = document.Add(itemTable);

                _ = document.Add(new Paragraph($"Revenue: {order.TotalAmount}") { Font = new Font(FontFactory.GetFont("Helvetica", 12)) });
                _ = document.Add(new Paragraph($"Profit: {order.GrossProfit}") { Font = new Font(FontFactory.GetFont("Helvetica", 12)) });

                _ = document.Add(iTextSharp.text.Chunk.NEWLINE);
                LineSeparator divider = new LineSeparator(1f, 100f, BaseColor.DARK_GRAY, Element.ALIGN_CENTER, -1f);
                _ = document.Add(divider);
                int pageCount = document.PageNumber;

                for (int i = 1; i <= pageCount; i++)
                {
                    _ = document.NewPage();
                    Paragraph pageNumberParagraph = new Paragraph($"Page {i} of {pageCount}", new Font(FontFactory.GetFont("Helvetica", 10))) { Alignment = Element.ALIGN_RIGHT };
                    _ = document.Add(pageNumberParagraph);
                }
            }
        }

        private Dictionary<string, object> GetFiltersForReportType(ReportType reportType)
        {
            Dictionary<string, object> filters = new Dictionary<string, object>();

            switch (reportType)
            {
                case ReportType.SalesSummary:
                    if (dtpStartDate.Checked)
                    {
                        filters["StartDate"] = dtpStartDate.Value.Date;
                    }

                    if (dtpEndDate.Checked)
                    {
                        filters["EndDate"] = dtpEndDate.Value.Date;
                    }

                    if (cboFilter.SelectedItem != null)
                    {
                        filters["PaymentMethod"] = cboFilter.SelectedItem.ToString();
                    }
                    // Add the TextBox value to the filters with the appropriate key
                    if (!string.IsNullOrEmpty(txtFilter.Text))
                    {
                        filters["SearchText"] = txtFilter.Text;
                    }

                    break;

                case ReportType.InventoryReport:
                    if (!string.IsNullOrEmpty(txtFilter.Text))
                    {
                        filters["IngredientName"] = txtFilter.Text;
                    }

                    if (chkLowStockOnly.Checked)
                    {
                        filters["LowStockOnly"] = chkLowStockOnly.Checked;

                    }
                    if (cboFilter.SelectedItem != null)
                    {
                        filters["IngredientCategory"] = cboFilter.SelectedItem.ToString();
                    }

                    break;

                case ReportType.OrderList:
                    if (!string.IsNullOrEmpty(txtFilter.Text))
                    {
                        filters["CustomerName"] = txtFilter.Text;
                    }

                    if (cboFilter.SelectedItem != null)
                    {
                        filters["OrderStatus"] = cboFilter.SelectedItem.ToString();
                    }

                    break;

                case ReportType.OrderWithItemsList:
                    if (!string.IsNullOrEmpty(txtFilter.Text))
                    {
                        filters["ProductName"] = txtFilter.Text;
                    }

                    filters["CustomerName"] = txtFilter.Text;

                    if (cboFilter.SelectedIndex > -1)
                    {
                        filters["ProductCategory"] = cboFilter.SelectedItem.ToString();
                    }

                    if (dtpEndDate.Checked)
                    {
                        filters["OrderStartDate"] = dtpStartDate.Value.Date;
                    }

                    if (dtpEndDate.Checked)
                    {
                        filters["OrderEndDate"] = dtpEndDate.Value.Date;
                    }

                    break;
                case ReportType.ChangeLogs:
                    if (cboFilter.SelectedItem != null)
                    {
                        filters["TableName"] = cboFilter.SelectedItem.ToString();
                    }

                    if (!string.IsNullOrEmpty(txtFilter.Text))
                    {
                        filters["SearchText"] = txtFilter.Text;
                    }

                    if (dtpStartDate.Checked)
                    {
                        filters["StartDate"] = dtpStartDate.Value.Date;
                    }

                    if (dtpEndDate.Checked)
                    {
                        filters["EndDate"] = dtpEndDate.Value.Date;
                    }

                    break;
            }

            return filters;
        }

        // Event handler for the Generate Report button
        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            if (lstReportTypes.SelectedItem != null)
            {
                ReportType selectedReportType = (ReportType)lstReportTypes.SelectedItem;
                Dictionary<string, object> filters = GetFiltersForReportType(selectedReportType);

                // Provide a temporary file path for the PDF
                string pdfPath = Path.Combine(Path.GetTempPath(), "temp_report.pdf");

                GenerateAndDisplayReport(pdfPath, selectedReportType, filters);
            }
        }
        private void GenerateReport()
        {
            if (lstReportTypes.SelectedItem != null)
            {
                ReportType selectedReportType = (ReportType)lstReportTypes.SelectedItem;
                Dictionary<string, object> filters = GetFiltersForReportType(selectedReportType);

                // Provide a temporary file path for the PDF
                string pdfPath = Path.Combine(Path.GetTempPath(), "temp_report.pdf");

                GenerateAndDisplayReport(pdfPath, selectedReportType, filters);
            }
        }


        private void cboDateRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDateRange.SelectedItem != null)
            {
                string selectedRange = cboDateRange.SelectedItem.ToString();
                DateTime startDate = DateTime.Today;
                DateTime endDate = DateTime.Today;

                switch (selectedRange)
                {
                    case "Today":
                        startDate = DateTime.Today;
                        endDate = DateTime.Today;
                        break;
                    case "Last 7 Days":
                        startDate = DateTime.Today.AddDays(-7);
                        endDate = DateTime.Today;
                        break;
                    case "Last 30 Days":
                        startDate = DateTime.Today.AddDays(-30);
                        endDate = DateTime.Today;
                        break;
                    case "This Month":
                        startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                        endDate = startDate.AddMonths(1).AddDays(-1);
                        break;
                    case "All Time":
                        startDate = DateTime.MinValue;
                        endDate = DateTime.MaxValue;
                        break;
                }

                // Update the DateTimePickers with the calculated date range
                dtpStartDate.Value = startDate;
                dtpEndDate.Value = endDate;
            }

            GenerateReport();
        }

        private void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateReport();
        }

        private async void txtFilter_TextChanged(object sender, EventArgs e)
        {
            await Task.Delay(200); // Add a delay of 500 milliseconds
            GenerateReport();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            DateHelper.ValidateDateRange(dtpStartDate, dtpEndDate, "Start date must be before end date.", 1);

            GenerateReport();
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            DateHelper.ValidateDateRange(dtpStartDate, dtpEndDate, "Start date must be before end date.", -1);

            GenerateReport();
        }
    }

    // Enum for report types
    public enum ReportType
    {
        SalesSummary,
        InventoryReport,
        OrderList,
        OrderWithItemsList,
        ChangeLogs

    }
}