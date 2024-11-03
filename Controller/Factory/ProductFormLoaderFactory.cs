using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakoTea.Factory;
using TakoTea.Interfaces;
using TakoTea.Items;
using TakoTea.Product;
using TakoTea.View.Product;

namespace TakoTea.Controller.Factory
{
    public class ProductFormLoaderFactory
    {
        public static ITabFormLoader GetFormLoader(string selectedMenuItemName)
        {
            switch (selectedMenuItemName)
            {
                case "toolStripMenuItemProducts":
                    return new ProductsFormLoader();
                case "toolStripMenuItemProductVariant":
                    return new ProductVariantFormLoader();
                default:
                    return null;
            }
        }
    }
    public class ProductsFormLoader : ITabFormLoader
    {


        public Form LoadForm()
        {

            ProductCategoryForm itemControl = new ProductCategoryForm();
            itemControl.TopLevel = false;
            itemControl.FormBorderStyle = FormBorderStyle.None;
            itemControl.Dock = DockStyle.Fill;
            return itemControl;
        }
    }

    public class ProductVariantFormLoader : ITabFormLoader
    {
        public Form LoadForm()
        {
            ProductListForm stockAlerts = new ProductListForm();
            stockAlerts.TopLevel = false;
            stockAlerts.FormBorderStyle = FormBorderStyle.None;
            stockAlerts.Dock = DockStyle.Fill;
            return stockAlerts;
        }
    }

}

