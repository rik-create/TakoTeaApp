using iTextSharp.text;
using iTextSharp.text.pdf;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Windows.Forms;
using TakoTea.Models;
using TakoTea.Views.reports;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using PdfiumViewer;
using PdfSharp.Drawing;
using PdfSharp.Pdf.IO;
using PdfSharp.UniversalAccessibility.Drawing;
using System.Windows.Controls;
using Microsoft.SqlServer.Management.Smo.Agent;
using System.Threading;
using System.Data.Entity.Core.Objects;
using iTextSharp.text.pdf.draw;
using TakoTea.Helpers;
using System.Threading.Tasks;
using TakoTea.Repository;
using Helpers;


namespace TakoTea.Views.reports
{
    public partial class ReportingForm : MaterialForm
    {
        // DbContext instance
        private Entities dbContext = new Entities();
        public ReportingForm()
        {
            InitializeComponent();

            // Populate ListBox with ReportType enum values
            lstReportTypes.DataSource = Enum.GetValues(typeof(ReportType));

            // Populate ComboBoxes with relevant data
            // Add event handler for the ComboBox
            cboDateRange.Items.AddRange(new object[] { "Today", "Last 7 Days", "Last 30 Days", "This Month" });

        }

        private void lstReportTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstReportTypes.SelectedItem != null)
            {
                var selectedReportType = (ReportType)lstReportTypes.SelectedItem;
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
                        lblSearchHint.Text = "Enter Product Name or Order ID:";
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
                using (var stream = new MemoryStream())
                {
                    // Create a PdfWriter to write to the MemoryStream
                    PdfWriter.GetInstance(itextDoc, stream);

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

                    // Close the iTextSharp document
                    itextDoc.Close();
          
                    int retries = 3;
                    while (retries > 0)
                    {
                        try
                        {
                            pdfPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + "_temp_report.pdf");
                            File.WriteAllBytes(pdfPath, stream.ToArray());
                            break; // Exit the loop if successful
                        }
                        catch (IOException)
                        {
                            retries--;
                            Thread.Sleep(100); // Wait for a short time before retrying
                        }
                    }

                    if (retries == 0)
                    {
                        // Handle the error if all retries fail
                        MessageBox.Show("Error saving the report. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Display the PDF in the WebBrowser control
                webBrowser1.Dock = DockStyle.Fill;
                panelReports.Controls.Add(webBrowser1);
                webBrowser1.Navigate(pdfPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while generating the report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                itextDoc.Dispose();
            }
        }

        private void AddSalesSummaryContent(iTextSharp.text.Document document, Dictionary<string, object> filters)
        {
            var salesQuery = dbContext.OrderModels.AsQueryable();

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
            .ToList()
            .GroupBy(o => o.OrderDate.Date)
            .Select(g => new
            {
                OrderDate = g.Key,
                TotalAmount = g.Sum(o => o.TotalAmount),
                GrossProfit = g.Sum(o => o.GrossProfit)
            })
            .ToList();

            // Add sales summary data to the document with styling
            var titleParagraph = new Paragraph("TakoTea - Sales Summary")
            {
                Font = new Font(FontFactory.GetFont("Helvetica", 16, iTextSharp.text.Font.BOLD, BaseColor.BLUE)),
                Alignment = Element.ALIGN_CENTER
            };
            document.Add(titleParagraph);

            // Add date and time
            var dateTimeParagraph = new Paragraph($"Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}") { Alignment = Element.ALIGN_CENTER };
            document.Add(dateTimeParagraph);

            // Add "Printed By:"
            var printedByParagraph = new Paragraph($"Printed By: {AuthenticationHelper._loggedInUsername}\n") { Alignment = Element.ALIGN_CENTER };
            document.Add(printedByParagraph);
            // Add an empty paragraph for spacing
            document.Add(new Paragraph(" "));
            // Add a table to organize the data
            var table = new PdfPTable(3) { WidthPercentage = 100 };
            table.AddCell(new PdfPCell(new Phrase("Order Date")) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });
            table.AddCell(new PdfPCell(new Phrase("Total Amount")) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });
            table.AddCell(new PdfPCell(new Phrase("Gross Profit")) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });

            foreach (var item in salesSummary)
            {
                table.AddCell(new PdfPCell(new Phrase(item.OrderDate.ToShortDateString())) { Padding = 5 });
                table.AddCell(new PdfPCell(new Phrase("₱" + item.TotalAmount.ToString("C", new System.Globalization.CultureInfo("fil-PH")))) { Padding = 5 });
                table.AddCell(new PdfPCell(new Phrase("₱" + item.GrossProfit.Value.ToString("C", new System.Globalization.CultureInfo("fil-PH")))) { Padding = 5 });
            }
            int pageCount = document.PageNumber;

            for (int i = 1; i <= pageCount; i++)
            {
                document.NewPage();
                var pageNumberParagraph = new Paragraph($"Page {i} of {pageCount}", new Font(FontFactory.GetFont("Helvetica", 10))) { Alignment = Element.ALIGN_RIGHT };
                document.Add(pageNumberParagraph);
            }

            document.Add(table);
        }

        private void AddInventoryReportContent(iTextSharp.text.Document document, Dictionary<string, object> filters)
        {
            var inventoryQuery = dbContext.Ingredients.AsQueryable();

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
                    inventoryQuery = inventoryQuery.Where(i => i.IngredientCategory == ingredientCategory);
                }
            }

            var inventory = inventoryQuery.ToList();

            // Add inventory data to the document with styling
            // Add title with TakoTea and center alignment
            var titleParagraph = new Paragraph("TakoTea - Inventory Report")
            {
                Font = FontFactory.GetFont("Helvetica", 16, iTextSharp.text.Font.BOLD, BaseColor.GREEN),
                Alignment = Element.ALIGN_CENTER
            };
            document.Add(titleParagraph);

            // Add date and time
            var dateTimeParagraph = new Paragraph($"Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}") { Alignment = Element.ALIGN_CENTER };
            document.Add(dateTimeParagraph);

            // Add "Printed By:"
            var printedByParagraph = new Paragraph($"Printed By: {AuthenticationHelper._loggedInUsername}\n") { Alignment = Element.ALIGN_CENTER };
            document.Add(printedByParagraph);
            // Add an empty paragraph for spacing
            document.Add(new Paragraph(" "));
            // Add a table to organize the data
            var table = new PdfPTable(3) { WidthPercentage = 100 };
            table.AddCell(new PdfPCell(new Phrase("Ingredient Name")) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });
            table.AddCell(new PdfPCell(new Phrase("Stock Level")) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });
            table.AddCell(new PdfPCell(new Phrase("Measuring Unit")) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });

            foreach (var item in inventory)
            {
                table.AddCell(new PdfPCell(new Phrase(item.IngredientName)) { Padding = 5 });
                table.AddCell(new PdfPCell(new Phrase(item.StockLevel.ToString())) { Padding = 5 });
                table.AddCell(new PdfPCell(new Phrase(item.MeasuringUnit)) { Padding = 5 });
            }

            document.Add(table);
            int pageCount = document.PageNumber;

            for (int i = 1; i <= pageCount; i++)
            {
                document.NewPage();
                var pageNumberParagraph = new Paragraph($"Page {i} of {pageCount}", new Font(FontFactory.GetFont("Helvetica", 10))) { Alignment = Element.ALIGN_RIGHT };
                document.Add(pageNumberParagraph);
            }
        }


        private void AddOrderListContent(iTextSharp.text.Document document, Dictionary<string, object> filters)
        {
            var ordersQuery = dbContext.OrderModels.AsQueryable();

            // Apply filters
            if (filters != null)
            {
                if (filters.ContainsKey("CustomerName") && filters["CustomerName"] is string customerName)
                {
                    ordersQuery = ordersQuery.Where(o => o.CustomerName.Contains(customerName));
                }
                if (filters.ContainsKey("OrderStatus") && filters["OrderStatus"] is string orderStatus)
                {
                    ordersQuery = ordersQuery.Where(o => o.OrderStatus == orderStatus);
                }
                if (filters.ContainsKey("PaymentStatus") && filters["PaymentStatus"] is string paymentStatus)
                {
                    ordersQuery = ordersQuery.Where(o => o.PaymentStatus == paymentStatus);
                }
            }

            var orders = ordersQuery.ToList();



            // Add inventory data to the document with styling
            // Add title with TakoTea and center alignment
            var titleParagraph = new Paragraph("TakoTea - Order List")
            {
                Font = FontFactory.GetFont("Helvetica", 16, iTextSharp.text.Font.BOLD, BaseColor.GREEN),
                Alignment = Element.ALIGN_CENTER
            };
            document.Add(titleParagraph);

            // Add date and time
            var dateTimeParagraph = new Paragraph($"Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}") { Alignment = Element.ALIGN_CENTER };
            document.Add(dateTimeParagraph);

            // Add "Printed By:"
            var printedByParagraph = new Paragraph($"Printed By: {AuthenticationHelper._loggedInUsername}\n") { Alignment = Element.ALIGN_CENTER };
            document.Add(printedByParagraph);
            // Add an empty paragraph for spacing
            document.Add(new Paragraph(" "));
            // Add a table to organize the data
            // Add a table to organize the data
            var table = new PdfPTable(6) { WidthPercentage = 100 };
            table.AddCell(new PdfPCell(new Phrase("Order ID")) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });
            table.AddCell(new PdfPCell(new Phrase("Order Date")) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });
            table.AddCell(new PdfPCell(new Phrase("Customer Name")) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });
            table.AddCell(new PdfPCell(new Phrase("Payment Method")) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });
            table.AddCell(new PdfPCell(new Phrase("Total Items")) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });
            table.AddCell(new PdfPCell(new Phrase("Total Amount")) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });

            foreach (var order in orders)
            {
                table.AddCell(new PdfPCell(new Phrase(order.OrderId.ToString())) { Padding = 5 });
                table.AddCell(new PdfPCell(new Phrase(order.OrderDate.ToShortDateString())) { Padding = 5 });
                table.AddCell(new PdfPCell(new Phrase(order.CustomerName)) { Padding = 5 });
                table.AddCell(new PdfPCell(new Phrase(order.PaymentMethod)) { Padding = 5 });
                table.AddCell(new PdfPCell(new Phrase(order.OrderItems.Count.ToString())) { Padding = 5 });
                table.AddCell(new PdfPCell(new Phrase("₱" + order.TotalAmount.ToString("N"))) { Padding = 5 });
            }

            document.Add(table);
            int pageCount = document.PageNumber;

            for (int i = 1; i <= pageCount; i++)
            {
                document.NewPage();
                var pageNumberParagraph = new Paragraph($"Page {i} of {pageCount}", new Font(FontFactory.GetFont("Helvetica", 10))) { Alignment = Element.ALIGN_RIGHT };
                document.Add(pageNumberParagraph);
            }
        }
        private int GetProductIdByName(string productName)
        {
            return dbContext.Products.FirstOrDefault(p => p.ProductName == productName)?.ProductID ?? 0;
        }

        private void AddChangeLogsContent(iTextSharp.text.Document document, Dictionary<string, object> filters)

        {

            var logsQuery = LogChangesRepository.GetAllChangeLogs().AsQueryable();



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



            var logs = logsQuery.ToList();



            // Add logs data to the document with styling

            var titleFont = FontFactory.GetFont("Helvetica", 16, iTextSharp.text.Font.BOLD, BaseColor.RED);

            var headerFont = FontFactory.GetFont("Helvetica", 12, iTextSharp.text.Font.BOLD);

            var cellFont = FontFactory.GetFont("Helvetica", 10);



            document.Add(new Paragraph("TakoTea - Change Logs Report", titleFont) { Alignment = Element.ALIGN_CENTER });

            document.Add(new Paragraph($"Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}") { Alignment = Element.ALIGN_CENTER });

            document.Add(new Paragraph($"Printed By: {AuthenticationHelper._loggedInUsername} \n") { Alignment = Element.ALIGN_CENTER });

            document.Add(new Paragraph(" "));



            // Create a table to display the logs

            var table = new PdfPTable(7) { WidthPercentage = 100 }; // 7 columns now

            table.AddCell(new PdfPCell(new Phrase("Timestamp", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });

            table.AddCell(new PdfPCell(new Phrase("Table Name", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });
            table.AddCell(new PdfPCell(new Phrase("Record ID", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });


            table.AddCell(new PdfPCell(new Phrase("Column Name", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });

            table.AddCell(new PdfPCell(new Phrase("Old Value", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });

            table.AddCell(new PdfPCell(new Phrase("New Value", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });

            table.AddCell(new PdfPCell(new Phrase("User", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });



            foreach (var log in logs)

            {

                table.AddCell(new PdfPCell(new Phrase(log.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"), cellFont)) { Padding = 5 });

                table.AddCell(new PdfPCell(new Phrase(log.TableName, cellFont)) { Padding = 5 });
                table.AddCell(new PdfPCell(new Phrase(log.RecordID.ToString(), cellFont)) { Padding = 5 }); // Add RecordID cell

                table.AddCell(new PdfPCell(new Phrase(log.ColumnName, cellFont)) { Padding = 5 });

                table.AddCell(new PdfPCell(new Phrase(log.OldValue, cellFont)) { Padding = 5 });

                table.AddCell(new PdfPCell(new Phrase(log.NewValue, cellFont)) { Padding = 5 });

                table.AddCell(new PdfPCell(new Phrase(log.Username, cellFont)) { Padding = 5 });

            }



            document.Add(table);



            // Add page numbers

            int pageCount = document.PageNumber;

            for (int i = 1; i <= pageCount; i++)

            {

                document.NewPage();

                var pageNumberParagraph = new Paragraph($"Page {i} of {pageCount}", new Font(FontFactory.GetFont("Helvetica", 10))) { Alignment = Element.ALIGN_RIGHT };

                document.Add(pageNumberParagraph);

            }

        }
        private void AddOrderWithItemsListContent(iTextSharp.text.Document document, Dictionary<string, object> filters)
        {
            var ordersQuery = dbContext.OrderModels.Include("OrderItems").AsQueryable();
            // Apply filters
            if (filters != null)
            {
                if (filters.ContainsKey("ProductName") && filters["ProductName"] is string productName)
                {
                    ordersQuery = ordersQuery.Where(o => o.OrderItems.Any(i => i.ProductName.Contains(productName)));
                }
                if (filters.ContainsKey("ProductCategory") && filters["ProductCategory"] is string productCategory)
                {

                    if (productCategory == "All")
                    {

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

            var orders = ordersQuery.ToList();
            // Add order with items list data to the document with styling
            // Add title with TakoTea and center alignment
            var titleParagraph = new Paragraph("TakoTea - Order with Items List")
            {
                Font = FontFactory.GetFont("Helvetica", 16, iTextSharp.text.Font.BOLD, BaseColor.GREEN),
                Alignment = Element.ALIGN_CENTER
            };
            document.Add(titleParagraph);

            // Add date and time
            var dateTimeParagraph = new Paragraph($"Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}") { Alignment = Element.ALIGN_CENTER };
            document.Add(dateTimeParagraph);

            // Add "Printed By:"
            var printedByParagraph = new Paragraph($"Printed By: [Your Name or User ID]\n") { Alignment = Element.ALIGN_CENTER };
            document.Add(printedByParagraph);
            // Add an empty paragraph for spacing
            document.Add(new Paragraph(" "));


            foreach (var order in orders)
            {
                // Add order details with styling
                document.Add(new Paragraph($"Order ID: {order.OrderId}") { Font = new Font(FontFactory.GetFont("Helvetica", 15, iTextSharp.text.Font.BOLD)) });
                document.Add(new Paragraph($"Order Date: {order.OrderDate}") { Font = new Font(FontFactory.GetFont("Helvetica", 12)) });
                document.Add(new Paragraph($"Customer Name: {order.CustomerName}") { Font = new Font(FontFactory.GetFont("Helvetica", 12)) });
                document.Add(new Paragraph($"Payment Method: {order.PaymentMethod}") { Font = new Font(FontFactory.GetFont("Helvetica", 12)) });
                document.Add(new Paragraph($"Total Items: {order.OrderItems.Count}") { Font = new Font(FontFactory.GetFont("Helvetica", 12)) });
                document.Add(new Paragraph(" "));
             

                // Add a nested table for order items
                var itemTable = new PdfPTable(3) { WidthPercentage = 100 }; // 3 columns for Product Name, Quantity, and Price
                itemTable.AddCell(new PdfPCell(new Phrase("Product Name")) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });
                itemTable.AddCell(new PdfPCell(new Phrase("Quantity")) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });
                itemTable.AddCell(new PdfPCell(new Phrase("Price")) { BackgroundColor = BaseColor.LIGHT_GRAY, Padding = 5 });

                foreach (var item in order.OrderItems)
                {
                    itemTable.AddCell(new PdfPCell(new Phrase(item.ProductName)) { Padding = 5 });
                    itemTable.AddCell(new PdfPCell(new Phrase(item.Quantity.ToString())) { Padding = 5 });
                    itemTable.AddCell(new PdfPCell(new Phrase(item.Price.ToString("C"))) { Padding = 5 }); // Add Price column
                }

                document.Add(itemTable);

                document.Add(new Paragraph($"Total Amount: {order.TotalAmount}") { Font = new Font(FontFactory.GetFont("Helvetica", 12)) });
                document.Add(iTextSharp.text.Chunk.NEWLINE);
                var divider = new LineSeparator(1f, 100f, BaseColor.DARK_GRAY, Element.ALIGN_CENTER, -1f);
                document.Add(divider);
                int pageCount = document.PageNumber;

                for (int i = 1; i <= pageCount; i++)
                {
                    document.NewPage();
                    var pageNumberParagraph = new Paragraph($"Page {i} of {pageCount}", new Font(FontFactory.GetFont("Helvetica", 10))) { Alignment = Element.ALIGN_RIGHT };
                    document.Add(pageNumberParagraph);
                }
            }
        }

        private Dictionary<string, object> GetFiltersForReportType(ReportType reportType)
        {
            var filters = new Dictionary<string, object>();

            switch (reportType)
            {
                case ReportType.SalesSummary:
                    if (dtpStartDate.Checked)
                        filters["StartDate"] = dtpStartDate.Value.Date;
                    if (dtpEndDate.Checked)
                        filters["EndDate"] = dtpEndDate.Value.Date;
                    if (cboFilter.SelectedItem != null)
                        filters["PaymentMethod"] = cboFilter.SelectedItem.ToString();
                    // Add the TextBox value to the filters with the appropriate key
                    if (!string.IsNullOrEmpty(txtFilter.Text))
                        filters["SearchText"] = txtFilter.Text;
                    break;

                case ReportType.InventoryReport:
                    if (!string.IsNullOrEmpty(txtFilter.Text))
                        filters["IngredientName"] = txtFilter.Text;
                    filters["LowStockOnly"] = chkLowStockOnly.Checked;
                    if (cboFilter.SelectedItem != null)
                        filters["IngredientCategory"] = cboFilter.SelectedItem.ToString();
                    break;

                case ReportType.OrderList:
                    if (!string.IsNullOrEmpty(txtFilter.Text))
                        filters["CustomerName"] = txtFilter.Text;
                    if (cboFilter.SelectedItem != null)
                        filters["OrderStatus"] = cboFilter.SelectedItem.ToString();
                    break;

                case ReportType.OrderWithItemsList:
                    if (!string.IsNullOrEmpty(txtFilter.Text))
                        filters["ProductName"] = txtFilter.Text;
                    if (cboFilter.SelectedIndex > -1)
                        filters["ProductCategory"] = cboFilter.SelectedItem.ToString();
                    if (dtpEndDate.Checked)
                        filters["OrderStartDate"] = dtpStartDate.Value.Date;
                    if (dtpEndDate.Checked)
                        filters["OrderEndDate"] = dtpEndDate.Value.Date;
                    break;
                case ReportType.ChangeLogs:
                    if (cboFilter.SelectedItem != null)
                        filters["TableName"] = cboFilter.SelectedItem.ToString();
                    if (!string.IsNullOrEmpty(txtFilter.Text))
                        filters["SearchText"] = txtFilter.Text;
                    if (dtpStartDate.Checked)
                        filters["StartDate"] = dtpStartDate.Value.Date;
                    if (dtpEndDate.Checked)
                        filters["EndDate"] = dtpEndDate.Value.Date;
                    break;
            }

            return filters;
        }

        // Event handler for the Generate Report button
        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            if (lstReportTypes.SelectedItem != null)
            {
                var selectedReportType = (ReportType)lstReportTypes.SelectedItem;
                var filters = GetFiltersForReportType(selectedReportType);

                // Provide a temporary file path for the PDF
                string pdfPath = Path.Combine(Path.GetTempPath(), "temp_report.pdf");

                GenerateAndDisplayReport(pdfPath, selectedReportType, filters);
            }
        }
        private void GenerateReport()
        {
            if (lstReportTypes.SelectedItem != null)
            {
                var selectedReportType = (ReportType)lstReportTypes.SelectedItem;
                var filters = GetFiltersForReportType(selectedReportType);

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
            await Task.Delay(1500); // Add a delay of 500 milliseconds
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