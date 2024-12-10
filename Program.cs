using System;
using System.Windows.Forms;
using TakoTea.Product;
using TakoTea.View.Batches;
using TakoTea.View.Items.Item_Modals;
using TakoTea.View.Orders;
using TakoTea.View.Product.Product_Modals;
using TakoTea.Views.Batches;
using TakoTea.Views.ComboMealForms;
using TakoTea.Views.Dashboard;
using TakoTea.Views.Items;
using TakoTea.Views.mainform;
using TakoTea.Views.MainForm;
using TakoTea.Views.Order.Order_Modals;
using TakoTea.Views.Other;
using TakoTea.Views.product;
using TakoTea.Views.reports;
using TakoTea.Views.settings;
namespace TakoTea
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TakoTeaForm());
            /*      // Register the dependency in the DI container
                  services.AddSingleton<IFormFactory, TakoTea.Views.FormFactory>();
                  services.AddTransient<FormLoader>();
                  // Resolve the loader wherever needed
                  var loader = serviceProvider.GetRequiredService<FormLoader>();
                  var form = loader.LoadForm("Dashboard");*/
        }
    }
}
