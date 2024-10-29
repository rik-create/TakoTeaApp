using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakoTea.Interfaces;
using TakoTea.Item_Management;
using TakoTea.Items;

namespace TakoTea.Factory
{
    public class ItemFormLoaderFactory
    {
        public static ITabFormLoader GetFormLoader(string selectedMenuItemName)
        {
            switch (selectedMenuItemName)
            {
                case "toolStripMenuItemList":
                    return new ItemListFormLoader();
                case "toolStripMenuItemEdit":
                    return new ItemEditFormLoader();
                case "toolStripMenuItemAdd":
                    return new ItemAddFormLoader();
                case "toolStripMenuItemCategory":
                    return new ItemCategoryFormLoader();
                default:
                    return null;
            }
        }
    }

    public class ItemListFormLoader : ITabFormLoader
    {


        public Form LoadForm()
        {

            ItemListForm itemList = new ItemListForm();
            itemList.TopLevel = false;
            itemList.FormBorderStyle = FormBorderStyle.None;
            itemList.Dock = DockStyle.Fill;
            return itemList;
        }
    }

    public class ItemAddFormLoader : ITabFormLoader
    {
        public Form LoadForm()
        {
            ItemAddForm stockAlerts = new ItemAddForm();
            stockAlerts.TopLevel = false;
            stockAlerts.FormBorderStyle = FormBorderStyle.None;
            stockAlerts.Dock = DockStyle.Fill;
            return stockAlerts;
        }
    }

    public class ItemEditFormLoader : ITabFormLoader
    {
        public Form LoadForm()
        {
            ItemEditForm orderQueue = new ItemEditForm();
            orderQueue.TopLevel = false;
            orderQueue.FormBorderStyle = FormBorderStyle.None;
            orderQueue.Dock = DockStyle.Fill;
            return orderQueue;
        }
    }

    public class ItemCategoryFormLoader : ITabFormLoader
    {
        public Form LoadForm()
        {
            ItemCategoryForm userActivities = new ItemCategoryForm();
            userActivities.TopLevel = false;
            userActivities.FormBorderStyle = FormBorderStyle.None;
            userActivities.Dock = DockStyle.Fill;
            return userActivities;
        }
    }
}
