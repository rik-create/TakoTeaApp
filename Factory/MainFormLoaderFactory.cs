using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using TakoTea.Dashboard;
using TakoTea.Interfaces;
using TakoTea.Item_Management;
using TakoTea.Items;
using TakoTea.MainForm;
using TakoTea.Product;
using TakoTea.View.Stock;





using TakoTea.View.Reports;
using TakoyakiMilkTea;
using TakoTea.View;
using TakoTea.View.Settings;
using TakoTea.View.Sales;

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

            MainOverviewForm mainOverviewControl = new MainOverviewForm();
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

            ProductListForm productList = new ProductListForm();
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
            SalesListForm salesControl = new SalesListForm();
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
            CurrentStockForm stockControl = new CurrentStockForm();
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
            OrderList orderControl = new OrderList();
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
