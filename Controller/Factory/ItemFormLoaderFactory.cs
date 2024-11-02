using System.Windows.Forms;
using TakoTea.Interfaces;
using TakoTea.Item_Management;
using TakoTea.Items;
using TakoTea.View.Items;

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

            ItemListForm itemControl = new ItemListForm();
            itemControl.TopLevel = false;
            itemControl.FormBorderStyle = FormBorderStyle.None;
            itemControl.Dock = DockStyle.Fill;
            return itemControl;
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
            ItemCategoryForm itemControl = new ItemCategoryForm();
            itemControl.TopLevel = false;
            itemControl.FormBorderStyle = FormBorderStyle.None;
            itemControl.Dock = DockStyle.Fill;
            return itemControl;
        }
    }
}
