using System;
using System.Windows.Forms;
using TakoTea.Product;
using TakoTea.View.Batches;
using TakoTea.View.Order;
using TakoTea.View.Product.Product_Modals;
using TakoTea.Views.Batches;
using TakoTea.Views.Items;
using TakoTea.Views.MainForm;
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
            Application.Run(new AddItemModal());
            /*      // Register the dependency in the DI container
                  services.AddSingleton<IFormFactory, TakoTea.Views.FormFactory>();
                  services.AddTransient<FormLoader>();
                  // Resolve the loader wherever needed
                  var loader = serviceProvider.GetRequiredService<FormLoader>();
                  var form = loader.LoadForm("Dashboard");*/
        }
    }
}
