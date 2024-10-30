using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakoTea.Dashboard.Dashboard_Modals;
using TakoTea.Dashboard;
using TakoTea.Interfaces;
using TakoTea.View.Stock;

namespace TakoTea.Factory
{
    public class StockFormLoaderFactory
    {
        public static ITabFormLoader GetFormLoader(string selectedMenuItemName)
        {
            switch (selectedMenuItemName)
            {
                case "toolStripMenuItemStockLevel":
                    return new StockLevelFormLoader();
                case "toolStripMenuItemLowStockAlerts":
                    return new LowStockAlertsFormLoader();
                case "toolStripMenuItemAdjustStock":
                    return new AdjustStockFormLoader();
                default:
                    return null;
            }
        }




    }

    public class StockLevelFormLoader : ITabFormLoader
    {


        public Form LoadForm()
        {

            CurrentStockForm currentStock = new CurrentStockForm();
            currentStock.TopLevel = false;
            currentStock.FormBorderStyle = FormBorderStyle.None;
            currentStock.Dock = DockStyle.Fill;
            return currentStock;
        }
    }

    public class LowStockAlertsFormLoader : ITabFormLoader
    {
        public Form LoadForm()
        {
            LowStockAlertsForm stockAlerts = new LowStockAlertsForm();
            stockAlerts.TopLevel = false;
            stockAlerts.FormBorderStyle = FormBorderStyle.None;
            stockAlerts.Dock = DockStyle.Fill;
            return stockAlerts;
        }
    }

    public class AdjustStockFormLoader : ITabFormLoader
    {
        public Form LoadForm()
        {
            AdjustStockForm adjustStock = new AdjustStockForm();
            adjustStock.TopLevel = false;
            adjustStock.FormBorderStyle = FormBorderStyle.None;
            adjustStock.Dock = DockStyle.Fill;
            return adjustStock;
        }
    }

}
