using System.Windows.Forms;
using TakoTea.Dashboard;
using TakoTea.Interfaces;
using TakoTea.View.Dashboard;
using TakoTea.View.Order;

namespace TakoTea.Factory
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

            DashboardForm mainOverviewControl = new DashboardForm();
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
            OrdersQueueForm orders = new OrdersQueueForm();
            orders.TopLevel = false;
            orders.FormBorderStyle = FormBorderStyle.None;
            orders.Dock = DockStyle.Fill;
            return orders;
        }
    }

    public class UserActivitiesFormLoader : ITabFormLoader
    {
        public Form LoadForm()
        {
            UserActivitiesForm userActivities = new UserActivitiesForm();
            userActivities.TopLevel = false;
            userActivities.FormBorderStyle = FormBorderStyle.None;
            userActivities.Dock = DockStyle.Fill;
            return userActivities;
        }
    }



}