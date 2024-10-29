using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakoTea.Interfaces;

namespace TakoTea.Dashboard.Dashboard_Modals
{
    public class DashboardFormLoaderFactory
    {
        public static ITabFormLoader GetFormLoader(string selectedMenuItemName)
        {
            switch (selectedMenuItemName)
            {
                case "toolStripMenuItemMainOverview":
                    return new MainOverviewFormLoader();
                case "toolStripMenuItemStockAlerts":
                    return new StockAlertsFormLoader();
                case "toolStripMenuItemOrderQueue":
                    return new OrderQueueFormLoader();
                case "toolStripMenuItemUserActivities":
                    return new UserActivitiesFormLoader();
                default:
                    return null;
            }
        }
    }

    public class MainOverviewFormLoader : ITabFormLoader
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

    public class StockAlertsFormLoader : ITabFormLoader
    {
        public Form LoadForm()
        {
            StockAlertsForm stockAlerts = new StockAlertsForm();
            stockAlerts.TopLevel = false;
            stockAlerts.FormBorderStyle = FormBorderStyle.None;
            stockAlerts.Dock = DockStyle.Fill;
            return stockAlerts;
        }
    }

    public class OrderQueueFormLoader : ITabFormLoader
    {
        public Form LoadForm()
        {
            ItemForm itemControl = new ItemForm();
            itemControl.TopLevel = false;
            itemControl.FormBorderStyle = FormBorderStyle.None;
            itemControl.Dock = DockStyle.Fill;
            return itemControl;
        }
    }

    public class UserActivitiesFormLoader : ITabFormLoader
    {
        public Form LoadForm()
        {
            StockForm stockControl = new StockForm();
            stockControl.TopLevel = false;
            stockControl.FormBorderStyle = FormBorderStyle.None;
            stockControl.Dock = DockStyle.Fill;
            return stockControl;
        }
    }



}
