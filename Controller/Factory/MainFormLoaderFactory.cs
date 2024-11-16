using System.Windows.Forms;
using TakoTea.Interfaces;
using TakoTea.Items;
using TakoTea.View.Batch;
using TakoTea.View.Dashboard;
using TakoTea.View.Order;
using TakoTea.View.Product;
using TakoTea.View.Reports;
using TakoTea.View.Sales;
using TakoTea.View.Settings;
using TakoTea.View.Stock;

namespace TakoTea.Factory
{
    public class MainFormLoaderFactory
    {
        public static ITabFormLoader GetFormLoader(string selectedTabName)
        {
            switch (selectedTabName)
            {
                case "tabPageDashboard":
                    return new MainOverviewFormLoader();
                case "tabPageSales":
                    return new SalesFormLoader();
                case "tabPageItem":
                    return new ItemFormLoader();
                case "tabPageStock":
                    return new StockFormLoader();
                case "tabPageOrder":
                    return new OrderFormLoader();
                case "tabPageBatch":
                    return new BatchFormLoader();
                case "tabPageReports":
                    return new ReportsFormLoader();
                case "tabPageSettings":
                    return new SettingsFormLoader();
                default:
                    return null;
            }
        }
    }

    public class MainOverviewFormLoader2 : ITabFormLoader
    {


        public Form LoadForm()
        {

            DashboardForm mainOverviewControl = new DashboardForm();
            mainOverviewControl.TopLevel = false;
            mainOverviewControl.FormBorderStyle = FormBorderStyle.None;
            mainOverviewControl.Dock = DockStyle.Fill;
            return mainOverviewControl;
        }
    }

    public class ProductFormLoader : ITabFormLoader
    {


        public Form LoadForm()
        {

            ProductCategoryForm productList = new ProductCategoryForm();
            productList.TopLevel = false;
            productList.FormBorderStyle = FormBorderStyle.None;
            productList.Dock = DockStyle.Fill;
            return productList;
        }
    }
    public class SalesFormLoader : ITabFormLoader
    {
        public Form LoadForm()
        {
            SalesHistoryForm salesControl = new SalesHistoryForm();
            salesControl.TopLevel = false;
            salesControl.FormBorderStyle = FormBorderStyle.None;
            salesControl.Dock = DockStyle.Fill;
            return salesControl;
        }
    }

    public class ItemFormLoader : ITabFormLoader
    {
        public Form LoadForm()
        {
            ItemListForm itemControl = new ItemListForm();
            itemControl.TopLevel = false;
            itemControl.FormBorderStyle = FormBorderStyle.None;
            itemControl.Dock = DockStyle.Fill;
            return itemControl;
        }
    }

    public class StockFormLoader : ITabFormLoader
    {
        public Form LoadForm()
        {
            CurrentStockLevelForm stockControl = new CurrentStockLevelForm();
            stockControl.TopLevel = false;
            stockControl.FormBorderStyle = FormBorderStyle.None;
            stockControl.Dock = DockStyle.Fill;
            return stockControl;
        }
    }

    public class OrderFormLoader : ITabFormLoader
    {
        public Form LoadForm()
        {
            MenuOrderForm orderControl = new MenuOrderForm();
            orderControl.TopLevel = false;
            orderControl.FormBorderStyle = FormBorderStyle.None;
            orderControl.Dock = DockStyle.Fill;
            return orderControl;
        }
    }

    public class BatchFormLoader : ITabFormLoader
    {
        public Form LoadForm()
        {
            BatchListForm batchControl = new BatchListForm();
            batchControl.TopLevel = false;
            batchControl.FormBorderStyle = FormBorderStyle.None;
            batchControl.Dock = DockStyle.Fill;
            return batchControl;
        }
    }

    public class ReportsFormLoader : ITabFormLoader
    {
        public Form LoadForm()
        {
            SalesReportForm reportsControl = new SalesReportForm();
            reportsControl.TopLevel = false;
            reportsControl.FormBorderStyle = FormBorderStyle.None;
            reportsControl.Dock = DockStyle.Fill;
            return reportsControl;
        }
    }

    public class SettingsFormLoader : ITabFormLoader
    {
        public Form LoadForm()
        {
            UserManagementForm settingsControl = new UserManagementForm();
            settingsControl.TopLevel = false;
            settingsControl.FormBorderStyle = FormBorderStyle.None;
            settingsControl.Dock = DockStyle.Fill;
            return settingsControl;
        }
    }




}
